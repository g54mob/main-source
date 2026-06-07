using UnityEngine;

public class Obj_ScrapMasterMachineWeapon_Cannon : AObj_ScrapMasterMachineWeapon
{
	[SerializeField]
	private float shootInterval;

	[SerializeField]
	private float shootRange;

	[SerializeField]
	private int damage;

	[SerializeField]
	private Transform node_ShootPosition;

	[SerializeField]
	private ParticleSystem particle_ShootEffect;

	[SerializeField]
	private GameObject prefab_Bullet;

	protected override void Update()
	{
	}

	private void Shoot()
	{
	}

	public void OverrideAttributes(float newShootInterval, int newDamage)
	{
	}

	protected override void OverchargeProc()
	{
	}
}
