using UnityEngine;

public class Bullet_AOEStaticField : AProjectile
{
	[SerializeField]
	private ParticleSystem particle_StaticField;

	private float range;

	private int damage;

	private void LateUpdate()
	{
	}

	public void Setup(float range, int damage)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
