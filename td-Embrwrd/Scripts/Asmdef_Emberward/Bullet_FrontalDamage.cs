using UnityEngine;

public class Bullet_FrontalDamage : AProjectile
{
	private Vector3 boxCenter;

	private Vector3 halfExtent;

	private int damage;

	private eDamageType damageType;

	private Quaternion boxRotation;

	private float range;

	private bool isSetupDone;

	private void LateUpdate()
	{
	}

	public void Setup(float range, float width, int damage, eDamageType damageType)
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
