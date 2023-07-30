using UnityEngine;

[CreateAssetMenu(menuName = "Kevin/Data Health")]
public class DataHealth : ScriptableObject
{
	[Header("HP"), Range(1, 5000)]
	public float hp = 100;
}
