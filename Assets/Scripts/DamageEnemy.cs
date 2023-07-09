using UnityEngine;

public class DamageEnemy : DamageSystem
{
	private DataHealthEnemy dataEnemy;

	private void Start()
	{
		dataEnemy = (DataHealthEnemy)data;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//print(collision.gameObject);

		if (collision.gameObject.name.Contains("武器"))
		{
			//print("被武器打到～");
			float attack = collision.gameObject.GetComponent<Weapon>().attack;
			GetDamage(attack);
		}

	}

	public override void GetDamage(float damage)
	{
		base.GetDamage(damage);

		AudioClip sound = SoundManager.instance.enemyHit;
		SoundManager.instance.PlaySound(sound, 0.7f, 1.3f);
	}

	protected override void Dead()
	{
		Destroy(gameObject);
		DropExp();

		AudioClip sound = SoundManager.instance.enemyDead;
		SoundManager.instance.PlaySound(sound, 0.7f, 3);
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
