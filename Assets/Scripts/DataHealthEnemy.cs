using UnityEngine;

[CreateAssetMenu(menuName = "Kevin/Data Health Enemy")]
public class DataHealthEnemy : DataHealth
{
	[Header("經驗值掉落物件")]
	public GameObject prefabExp;

	[Header("經驗值掉落機率"), Range(0, 1)]
	public float dropProbability;
}
