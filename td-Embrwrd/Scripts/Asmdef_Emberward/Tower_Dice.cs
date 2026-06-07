using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Dice : ARerollableTower
{
	[CompilerGenerated]
	private sealed class _003CCR_ChangeElement_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Dice _003C_003E4__this;

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
		public _003CCR_ChangeElement_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CCR_ConfettiEffect_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Dice _003C_003E4__this;

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
		public _003CCR_ConfettiEffect_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003CCR_SendDiceEvent_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Dice _003C_003E4__this;

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
		public _003CCR_SendDiceEvent_003Ed__21(int _003C_003E1__state)
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
	private Transform node_Dice;

	[SerializeField]
	private MeshRenderer renderer_Dice;

	[SerializeField]
	private ParticleSystem particle_Confetti;

	[SerializeField]
	private ParticleSystem particle_ChangeElement;

	[SerializeField]
	private List<Vector3> list_DiceFaceRotations;

	[SerializeField]
	private Spin spin_PlacementDiceRoll;

	[SerializeField]
	private Material material_Normal;

	[SerializeField]
	private Material material_Fire;

	[SerializeField]
	private Material material_Ice;

	[SerializeField]
	private Material material_Lightning;

	[SerializeField]
	private Material material_Poison;

	[SerializeField]
	private Material material_Arcane;

	private int curDamage;

	private Vector3 headModelForward;

	private Quaternion diceOriginalRotation;

	private float rollDiceCooldown;

	private void Start()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	private void RollDice()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SendDiceEvent_003Ed__21))]
	private IEnumerator CR_SendDiceEvent()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ConfettiEffect_003Ed__22))]
	private IEnumerator CR_ConfettiEffect()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ChangeElement_003Ed__23))]
	private IEnumerator CR_ChangeElement()
	{
		return null;
	}

	protected override void ShootProc()
	{
	}

	public override int GetSellValue()
	{
		return 0;
	}

	public int GetDiceValue()
	{
		return 0;
	}

	public override void Reroll()
	{
	}

	public override bool IsBestRollValue()
	{
		return false;
	}

	public void RerollDice()
	{
	}

	public void SetElement(eDamageType damageType)
	{
	}

	public override bool CanReroll()
	{
		return false;
	}
}
