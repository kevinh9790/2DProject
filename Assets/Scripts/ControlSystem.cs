using UnityEngine;

public class ControlSystem : MonoBehaviour
{
	[SerializeField] SpriteRenderer a;

	[Header("移動速度"), Range(0.5f, 99.9f)]
	public float moveSpeed = 10.5f;

	[Header("2D剛體")]
	public Rigidbody2D rig;

	[Header("跑步動畫")]
	public Animator ani;

	[Header("跑步參數")]
	public string parRun = "開關跑步";

	private void Awake()
	{
		// print($"{1 + 2}");
	}

	private void Start()
	{
		// print("<color=orange>開始事件</color>");
	}

	private void Update()
	{
		MoveAndAnimation();

	}

	private void MoveAndAnimation()
	{
		// print("<color=blue>更新事件</color>");
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		rig.velocity = new Vector3(h, v, 0) * moveSpeed;

		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			//print("玩家按下左");
			//a.flipX = false;
			transform.eulerAngles = new Vector3(0, 0, 0);

		}

		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			//print("玩家按下右");
			//a.flipX = true;
			transform.eulerAngles = new Vector3(0, 180, 0);

		}

		ani.SetBool(parRun, h > 0 || h < 0 || v > 0 || v < 0);
	}
}
