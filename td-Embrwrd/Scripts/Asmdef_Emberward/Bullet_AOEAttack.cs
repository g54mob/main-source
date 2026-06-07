using UnityEngine;

public class Bullet_AOEAttack : AProjectile
{
	[SerializeField]
	private ParticleSystem particle_ShockWave;

	private float range;

	private int damage;

	private ABaseTower.eUpgradeType towerUpgradeType;

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
