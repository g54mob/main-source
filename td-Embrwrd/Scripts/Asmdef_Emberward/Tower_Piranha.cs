using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Piranha : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CCR_ShootProc_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Piranha _003C_003E4__this;

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
		public _003CCR_ShootProc_003Ed__17(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CCR_Upgrade_A_Bite_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Piranha _003C_003E4__this;

		private int _003Cdamage_003E5__2;

		private int _003CextraDamage_003E5__3;

		private float _003Ctimer_003E5__4;

		private float _003CtickDamageTimer_003E5__5;

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
		public _003CCR_Upgrade_A_Bite_003Ed__14(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Piranha _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__12(int _003C_003E1__state)
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
	private Animator animator_Piranha;

	[SerializeField]
	private List<Collider> list_AdditionalColliders;

	[SerializeField]
	private ParticleSystem particle_Bite;

	[SerializeField]
	private Transform node_PiranhaHead;

	[Header("放置時的煙霧特效")]
	[SerializeField]
	protected ParticleSystem particle_PlacementCloud;

	private Vector3 headModelForward;

	private bool isBiteAttack;

	private Vector3 piranhaHeadOriLocalPosition;

	private void Start()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	private void LateUpdate()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__12))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Upgrade_A_Bite_003Ed__14))]
	private IEnumerator CR_Upgrade_A_Bite()
	{
		return null;
	}

	protected override void ShootProc()
	{
	}

	private int CalculateExtraDamage()
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CCR_ShootProc_003Ed__17))]
	private IEnumerator CR_ShootProc()
	{
		return null;
	}
}
