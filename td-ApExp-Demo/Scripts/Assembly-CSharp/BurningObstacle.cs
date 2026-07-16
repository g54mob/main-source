using UnityEngine;

public class BurningObstacle : ExplodingObstacle
{
	[SerializeField]
	protected float burn;

	protected override void Start()
	{
		base.Start();
		if (explosionPrefab == null)
		{
			Debug.LogError("[BurningObstacle] " + base.name + " Explosion Prefab is required for burning obstacle.");
		}
	}

	protected override Explosion Explode(EnemyBase enemy)
	{
		Explosion explosion = base.Explode(enemy);
		enemy.HealthComponent.ApplyBurn(burn, explosion);
		return explosion;
	}

	protected override void SetColliderSize(int index)
	{
		if (hitboxCollider is BoxCollider2D boxCollider2D && index >= 0 && index < hitboxSizes.Length)
		{
			Vector4 vector = hitboxSizes[index];
			boxCollider2D.size = new Vector2(vector.x, vector.y);
			boxCollider2D.offset = new Vector2(vector.z, vector.w);
		}
	}
}
