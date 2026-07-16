using UnityEngine;

public class ExplodingObstacle : InteractableObstacle
{
	[Header("Explosion")]
	[SerializeField]
	protected float explosionRadius = 0.25f;

	[SerializeField]
	protected float explosionForce = 200f;

	[SerializeField]
	protected GameObject explosionPrefab;

	[SerializeField]
	protected ExplodeSprite explodeSprite;

	protected override void HandleEnemyTriggerEnter(EnemyBase enemy)
	{
		enemy.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, enemy.HealthComponent, 0f - damage));
		Explode(enemy);
	}

	protected virtual Explosion Explode(EnemyBase enemy)
	{
		Explosion explosion = null;
		if ((bool)explosionPrefab)
		{
			GameObject obj = Object.Instantiate(explosionPrefab, base.transform.position, base.transform.rotation);
			obj.layer = 15;
			explosion = obj.GetComponent<Explosion>();
			explosion.Initialize(null, explosionRadius, damage);
		}
		if ((bool)explodeSprite)
		{
			explodeSprite.Explode();
		}
		Collider2D[] array = Physics2D.OverlapCircleAll(base.transform.position, explosionRadius);
		for (int i = 0; i < array.Length; i++)
		{
			Rigidbody2D component = array[i].GetComponent<Rigidbody2D>();
			if (component != null)
			{
				component.AddForce(((Vector2)(component.transform.position - base.transform.position)).normalized * explosionForce);
			}
		}
		return explosion;
	}

	public override void SetSprite(int i)
	{
		base.SetSprite(i);
		if ((bool)explodeSprite)
		{
			explodeSprite.SetSprite(obstaclesArt[i]);
		}
	}
}
