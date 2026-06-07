using UnityEngine;

public class Bullet_PoisonAreaSplash : AProjectile
{
	[SerializeField]
	private ParticleSystem particle_PoisonSplash;

	[SerializeField]
	private Transform node_ParticleScale;

	[SerializeField]
	private float originalRange;

	private float range;

	private int damage;

	private void LateUpdate()
	{
	}

	public void Setup(float range, int damage)
	{
	}

	private void SetEffectScale(float scale)
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
