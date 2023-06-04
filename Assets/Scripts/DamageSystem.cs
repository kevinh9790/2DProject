using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [Header("血量資料")]
    public DataHealth data;

	private float hp;

	private DataHealthEnemy dataEnemy;

	private void Awake()
	{
		hp = data.hp;
		dataEnemy = (DataHealthEnemy)data;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//print(collision.gameObject);

		if (collision.gameObject.name.Contains("武器"))
		{
			//print("被武器打到～");
			GetDamage();
		}

	}

	private void GetDamage()
	{
		hp -= 50;
		//print("血量剩下: " + hp);

		if (hp <= 0)
		{
			Dead();
		}
	}

	private void Dead()
	{
		Destroy(gameObject);
		DropExp();
	}

	private void DropExp()
	{
		//print("經驗值掉落機率: " + dataEnemy.dropProbability);

		if (Random.value <= dataEnemy.dropProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}
