using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_ScrapMasterMachineWeapon_Missile : AObj_ScrapMasterMachineWeapon
{
	[Serializable]
	public class MissileShootData
	{
		public Transform model;

		public Transform shootNode;

		public ParticleSystem shootParticle;
	}

	[CompilerGenerated]
	private sealed class _003CShootMissile_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_ScrapMasterMachineWeapon_Missile _003C_003E4__this;

		private List<AMonsterBase> _003Cmonsters_003E5__2;

		private int _003CactualShootCount_003E5__3;

		private int _003Ci_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CShootMissile_003Ed__10(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private float shootInterval;

	[SerializeField]
	private float shootRange;

	[SerializeField]
	private int shootCount;

	[SerializeField]
	private int damage;

	[SerializeField]
	private List<MissileShootData> list_MissileShootData;

	[SerializeField]
	private GameObject prefab_Missile;

	private int bulletShootCount;

	private void Start()
	{
	}

	protected override void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CShootMissile_003Ed__10))]
	private IEnumerator ShootMissile()
	{
		return null;
	}

	protected void CreateBullet(Vector3 shootPosition, Vector3 direction, AMonsterBase currentTarget)
	{
	}

	public void OverrideAttributes(float newShootInterval, int newDamage, int newShootCount)
	{
	}

	protected override void OverchargeProc()
	{
	}
}
