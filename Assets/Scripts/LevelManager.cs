using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour
{
	#region 資料
	[Header("等級與經驗值介面")]
	public TextMeshProUGUI textLv;
	public TextMeshProUGUI textExp;
	public Image imgExp;
	[Header("等級上限"), Range(0, 500)]
	public int lvMax = 20;

	private int lv = 1;
	private float exp;

	public float[] expNeeds = { 100, 200, 300 };

	[Header("升級面板")]
	public GameObject goLevelUp;
	[Header("技能選取區塊1~3")]
	public GameObject[] goChooseSkills;
	[Header("全部技能")]
	public DataSkill[] dataSkills;

	public List<DataSkill> randomSkill = new List<DataSkill>(); 
	#endregion

	#region 經驗值系統
	[ContextMenu("更新經驗值需求表")]
	private void UpdateExpNeeds()
	{
		expNeeds = new float[lvMax];

		for (int i = 0; i < lvMax; i++)
		{
			expNeeds[i] = (i + 1) * 100;
		}
	}


	/// <summary>
	/// 獲得經驗值
	/// </summary>
	/// <param name="getExp">取得的經驗值浮點數</param>
	public void GetExp(float getExp)
	{
		exp += getExp;


		//如果經驗值大於等於經驗值需求 和 等級小於等級上限
		if (exp >= expNeeds[lv - 1] && lv < lvMax)
		{
			exp -= expNeeds[lv - 1];
			lv++;
			textLv.text = $"Lv.{lv}";
			LevelUp();
		}
		print($"<color=yellow>當前經驗值：{ exp }</color>");
		textExp.text = $"{exp} / { expNeeds[lv - 1]}";
		imgExp.fillAmount = exp / expNeeds[lv - 1];
	}

	private void LevelUp()
	{
		//時間暫停
		Time.timeScale = 0;

		goLevelUp.SetActive(true);

		//挑選出所有lv < 5的技能
		randomSkill = dataSkills.Where(x => x.lv < 5).ToList();

		//Random.Range(0,999) 為重新排序，數字夠大可以達到隨機效果
		randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();

		for (int i = 0; i < 3; i++)
		{
			// 技能選取區塊.找到名字為《技能名稱》的子物件 並更新他的文字內容 為 隨機技能的名稱
			goChooseSkills[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
			goChooseSkills[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "技能等級 " + randomSkill[i].lv;
			goChooseSkills[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].description;
			goChooseSkills[i].transform.Find("技能圖示").GetComponent<Image>().sprite = randomSkill[i].iconSkill;

		}
	}

	public void ClickSkillButton(int number)
	{
		print("按下按鈕: " + number);

		print("玩家按下的技能是: " + randomSkill[number].nameSkill);

		randomSkill[number].lv++;

		if (randomSkill[number].nameSkill == "武器攻擊") UpdateWeaponAttack(number);
		if (randomSkill[number].nameSkill == "武器生成間隔") UpdateWeaponInterval(number);
		if (randomSkill[number].nameSkill == "玩家血量") UpdatePlayerHealth(number);
		if (randomSkill[number].nameSkill == "移動速度") UpdateMoveSpeed(number);
		if (randomSkill[number].nameSkill == "經驗值範圍") UpdateExpRange(number);

		//時間恢復
		Time.timeScale = 1;
		goLevelUp.SetActive(false);
	}
	#endregion

	#region 升級系統
	[Header("控制系統：蝸牛")]
	public ControlSystem controlSystem;

	[Header("武器系統：蝸牛")]
	public WeaponSystem weaponSystem;

	[Header("玩家血量：玩家蝸牛")]
	public DataHealth dataHealth;

	[Header("經驗物件：金幣經驗值")]
	public CircleCollider2D expCoin;

	[Header("武器：豌豆")]
	public Weapon weaponPea;

	private void Awake()
	{
		weaponPea.attack = dataSkills[0].skillValues[0];
		weaponSystem.interval = dataSkills[1].skillValues[0];
		dataHealth.hp = dataSkills[2].skillValues[0];
		controlSystem.moveSpeed = dataSkills[3].skillValues[0];
		expCoin.radius = dataSkills[4].skillValues[0];
	}

	public void UpdateWeaponAttack(int number)
	{
		int lv = randomSkill[number].lv;
		weaponPea.attack = randomSkill[number].skillValues[lv - 1];
	}

	public void UpdateWeaponInterval(int number)
	{
		int lv = randomSkill[number].lv;
		weaponSystem.interval = randomSkill[number].skillValues[lv - 1];

	}

	public void UpdatePlayerHealth(int number)
	{
		int lv = randomSkill[number].lv;
		dataHealth.hp = randomSkill[number].skillValues[lv - 1];

	}

	public void UpdateMoveSpeed(int number)
	{
		//取得玩家選取技能的等級
		int lv = randomSkill[number].lv;

		//控制系統的移動速度 = 玩家選取技能的該等級數值
		controlSystem.moveSpeed = randomSkill[number].skillValues[lv - 1];
	}

	public void UpdateExpRange(int number)
	{
		int lv = randomSkill[number].lv;
		expCoin.radius = randomSkill[number].skillValues[lv - 1];
	} 
	#endregion
}
