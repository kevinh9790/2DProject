using UnityEngine;

/// <summary>
/// 敵人系統
/// 1. 追蹤玩家
/// 2. 翻面
/// </summary>
public class EnemySystem : MonoBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;

	[Header("追蹤速度"), Range(0, 10)]
	public float moveSpeed = 3.5f;
	[Header("敵人資料")]
	public DataHealthEnemy data;

	private Transform player;

	private void Awake()
	{
		player = GameObject.Find("蝸牛").transform;
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
		
	}
}
