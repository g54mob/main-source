using System;
using System.Collections.Generic;
using UnityEngine;

public class Obj_ScrapMasterMachineWeapon_MachineGun : AObj_ScrapMasterMachineWeapon
{
	[Serializable]
	public class MissileShootData
	{
		public Transform shootNode;

		public ParticleSystem shootParticle;
	}

	[SerializeField]
	private float shootInterval;

	[SerializeField]
	private float shootRange;

	[SerializeField]
	private int damage;

	[SerializeField]
	private List<MissileShootData> list_MissileShootData;

	[SerializeField]
	private GameObject prefab_Bullet;

	private AMonsterBase currentTarget;

	private int bulletShootCount;

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
