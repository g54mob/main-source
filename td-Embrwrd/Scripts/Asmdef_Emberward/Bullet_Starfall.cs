using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Starfall : ASingleTargetProjectile
{
	[Serializable]
	public class ParticleSettingForElements
	{
		public eDamageType damageType;

		public Color color_Meteor;

		public Gradient color_Trail;

		public Color color_ImpactRing;

		public Color color_Impact;

		public Color color_FloorGlow;
	}

	[CompilerGenerated]
	private sealed class _003CCR_Hit_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Bullet_Starfall _003C_003E4__this;

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
		public _003CCR_Hit_003Ed__18(int _003C_003E1__state)
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
	private ParticleSystem particle_StarFall;

	[SerializeField]
	[FormerlySerializedAs("explodeRange")]
	private float explodeRangeSetting;

	[SerializeField]
	private float delayTime;

	[SerializeField]
	private float screenShakeIntensityMultiplier;

	[SerializeField]
	private List<ParticleSettingForElements> list_ParticleSettingForElements;

	[SerializeField]
	private ParticleSystem particle_Meteor;

	[SerializeField]
	private ParticleSystem particle_Trail;

	[SerializeField]
	private ParticleSystem particle_Impact;

	[SerializeField]
	private ParticleSystem particle_ImpactRing;

	[SerializeField]
	private ParticleSystem particle_FloorGlow;

	protected ABaseTower.eUpgradeType upgradeType;

	private int damage;

	private bool isFlying;

	private Vector3 offset;

	private eDamageType damageType;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Hit_003Ed__18))]
	private IEnumerator CR_Hit()
	{
		return null;
	}

	public void Setup(int damage, eDamageType damageType)
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

	private void SwitchElement(eDamageType type)
	{
	}
}
