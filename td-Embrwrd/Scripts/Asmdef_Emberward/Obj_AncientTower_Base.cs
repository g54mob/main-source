using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Obj_AncientTower_Base : AMonsterBase
{
	protected class TowerPauseData
	{
		public bool isPaused;

		public int id;
	}

	public enum eTowerState
	{
		INACTIVE = 0,
		ACTIVATED = 1,
		ACTIVATE_BUT_PAUSED = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_ActivateTower_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientTower_Base _003C_003E4__this;

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
		public _003CCR_ActivateTower_003Ed__48(int _003C_003E1__state)
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
	private sealed class _003CCR_MaterialSwapOnActivate_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientTower_Base _003C_003E4__this;

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
		public _003CCR_MaterialSwapOnActivate_003Ed__49(int _003C_003E1__state)
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
	private sealed class _003CDeathProc_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_AncientTower_Base _003C_003E4__this;

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
		public _003CDeathProc_003Ed__54(int _003C_003E1__state)
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
	[Header("啟動所需回合數")]
	protected int activateRoundNeeded;

	[SerializeField]
	[Header("發射時間間隔")]
	protected float shootInterval;

	[Header("造成故障時間")]
	[SerializeField]
	protected float stunTime;

	[SerializeField]
	[Header("攻擊距離")]
	protected float attackRange;

	[SerializeField]
	protected Material material_CorruptedTower;

	[SerializeField]
	protected Transform node_Head;

	[SerializeField]
	private bool doRotateHead;

	[SerializeField]
	protected Transform node_HeadRotate;

	[SerializeField]
	protected GameObject node_ShootPosition;

	[SerializeField]
	protected Material mat_Deactivated;

	[SerializeField]
	protected Material mat_Activated;

	[SerializeField]
	protected ParticleSystem particle_TowerActivate;

	[SerializeField]
	private ParticleSystem particle_Destroy;

	[SerializeField]
	private ParticleSystem particle_DestoryedSmoke;

	[SerializeField]
	private GameObject node_DestroyedModel;

	[SerializeField]
	protected Transform node_RangeRing;

	protected int activateRoundCount;

	protected float shootCooldown;

	protected float detectInterval;

	protected float detectCooldown;

	protected bool isShootingActivated;

	protected ABaseTower targetTower;

	private UI_AncientTowerActivateCounter ui_ActivateCounter;

	protected eTowerState towerState;

	protected List<TowerPauseData> towerPausedSetting;

	protected bool currentTowerPauseState;

	public int ActivateRoundNeeded => 0;

	public float ShootInterval => 0f;

	public float AttackRange => 0f;

	public Vector3 ShootPosition => default(Vector3);

	public eTowerState TowerState => default(eTowerState);

	protected bool IsTowerPaused => false;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	public void ForceReduceAncientTowerTimer()
	{
	}

	private void OnForceReduceAncientTowerTimer()
	{
	}

	public void OverrideActivateRoundNeeded(int roundCount)
	{
	}

	private void OnRoundEnd()
	{
	}

	public void ResetTower()
	{
	}

	public void SetTowerPaused(bool isPaused, int id)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ActivateTower_003Ed__48))]
	private IEnumerator CR_ActivateTower()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_MaterialSwapOnActivate_003Ed__49))]
	private IEnumerator CR_MaterialSwapOnActivate()
	{
		return null;
	}

	private void SwapMaterial(Material mat)
	{
	}

	private void Start()
	{
	}

	public override void Spawn(MonsterSpawner spawner, bool isCorrupted)
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	[IteratorStateMachine(typeof(_003CDeathProc_003Ed__54))]
	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	protected virtual ABaseTower GetTargetTower()
	{
		return null;
	}

	protected override void OnMouseEnterProc()
	{
	}

	protected override void OnMouseExitProc()
	{
	}

	public override float GetRemainingDistance()
	{
		return 0f;
	}

	protected virtual void TowerActivateProc()
	{
	}

	protected virtual void TowerResetProc()
	{
	}

	protected virtual void TowerUpdateProc()
	{
	}

	protected abstract void ShootProc(ABaseTower targetTower);

	protected abstract void ShowTooltipProc();

	protected abstract void HideTooltipProc();

	public void OverrideAttackRange(float newRange)
	{
	}

	public void OverrideShootInterval(float newInterval)
	{
	}

	public void SetCorruptedTowerMaterial(bool isOn)
	{
	}
}
