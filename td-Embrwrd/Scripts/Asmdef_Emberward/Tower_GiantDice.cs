using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class Tower_GiantDice : ARerollableTower
{
	[CompilerGenerated]
	private sealed class _003CCR_CriticalFailureProc_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_GiantDice _003C_003E4__this;

		private List<ParticleSystem>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_CriticalFailureProc_003Ed__31(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_CriticalSuccessProc_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_GiantDice _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CCR_CriticalSuccessProc_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003CCR_RollSmallDiceAnimationDelay_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public Tower_GiantDice _003C_003E4__this;

		public int value;

		public Transform node_Dice;

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
		public _003CCR_RollSmallDiceAnimationDelay_003Ed__40(int _003C_003E1__state)
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
	private sealed class _003CSpawnProc_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_GiantDice _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__24(int _003C_003E1__state)
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
	private DICE_ROLLER diceRoller;

	[SerializeField]
	private Spin spin_PlacementDiceRoll;

	[SerializeField]
	private Transform node_ShootPosition_Left;

	[SerializeField]
	private Transform node_ShootPosition_Right;

	[SerializeField]
	private Animator animator_ShootLeft;

	[SerializeField]
	private Animator animator_ShootRight;

	[SerializeField]
	private ParticleSystem particle_Shoot_Left;

	[SerializeField]
	private ParticleSystem particle_Shoot_Right;

	[SerializeField]
	private List<ParticleSystem> list_Particle_CriticalFailure;

	[SerializeField]
	private List<ParticleSystem> list_Particle_Fireworks;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	private List<Vector3> list_DiceFaceRotations;

	[Header("升級B的左邊小骰子塔")]
	[SerializeField]
	private Transform node_SmallDice_Left;

	[Header("升級B的右邊小骰子塔")]
	[SerializeField]
	private Transform node_SmallDice_Right;

	[Header("原始的小砲台renderer")]
	[SerializeField]
	private List<Renderer> list_SmallCannonRenderers;

	[Header("小骰子塔renderer")]
	[SerializeField]
	private List<Renderer> list_SmallDiceRenderers;

	private Quaternion diceOriginalRotation;

	private int diceValue;

	private int shootSideIndex;

	private Vector3 headModelForward;

	private Tweener shootTweenAnim;

	private int upgradeDiceValue;

	private void Start()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__24))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	protected override void CannonUpdateProc()
	{
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

	private void RollDice()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CriticalSuccessProc_003Ed__30))]
	private IEnumerator CR_CriticalSuccessProc()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_CriticalFailureProc_003Ed__31))]
	private IEnumerator CR_CriticalFailureProc()
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

	public float GetUpgradeBSellCoef()
	{
		return 0f;
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void OnRoundEndProc()
	{
	}

	private void UpgradeB_RollDice()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RollSmallDiceAnimationDelay_003Ed__40))]
	private IEnumerator CR_RollSmallDiceAnimationDelay(float delay, int value, Transform node_Dice)
	{
		return null;
	}

	private void RollSmallDiceAnimation(int value, Transform node_Dice)
	{
	}

	public override bool CanReroll()
	{
		return false;
	}
}
