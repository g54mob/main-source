using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Tower_ScrapTank : ABaseTower, IDynamicPlacementTarget
{
	[CompilerGenerated]
	private sealed class _003CCR_ChangeElement_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_ScrapTank _003C_003E4__this;

		public eDamageType newElement;

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
		public _003CCR_ChangeElement_003Ed__50(int _003C_003E1__state)
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
	private sealed class _003CCR_PlaceTowerProc_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_ScrapTank _003C_003E4__this;

		private int _003CtowerCost_003E5__2;

		private eDamageType _003CtowerElement_003E5__3;

		private Vector3 _003CplacementOriginalPosition_003E5__4;

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
		public _003CCR_PlaceTowerProc_003Ed__46(int _003C_003E1__state)
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
	private sealed class _003CCR_ShootProc_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_ScrapTank _003C_003E4__this;

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
		public _003CCR_ShootProc_003Ed__30(int _003C_003E1__state)
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
	private eTowerSizeType dynamicPlacementSizeType;

	[SerializeField]
	private float damageMultiplier;

	[SerializeField]
	private float rangeMultiplier;

	[SerializeField]
	private float fireRateMultiplier;

	[SerializeField]
	private ParticleSystem particle_TowerDestruction;

	[SerializeField]
	private Transform node_TowerPlacementPosition;

	[SerializeField]
	private TMP_Text text_AmmoCount;

	[SerializeField]
	private List<GameObject> list_CrusherCogs;

	[SerializeField]
	private Material mat_Element_Normal;

	[SerializeField]
	private Material mat_Element_Fire;

	[SerializeField]
	private Material mat_Element_Ice;

	[SerializeField]
	private Material mat_Element_Electric;

	[SerializeField]
	private Material mat_Element_Poison;

	[SerializeField]
	private Material mat_Element_Arcane;

	[SerializeField]
	private Dictionary<eDamageType, int> dic_DisembledTowerCount;

	[SerializeField]
	[FormerlySerializedAs("maxEnhanceLimit")]
	private int baseEnhanceLimit;

	private int currentEnhanceValue;

	private int extraPoisonDamage;

	private ABaseTower attachedTower;

	private int ammoCount;

	private eDamageType ammoElement;

	private UI_Obj_ScrapTankEnhanceHint ui_ScrapTankEnhanceHint;

	private Vector3 headModelForward;

	public Action OnScrapTankUpgraded;

	private bool isRegisteredDynamicPlacement;

	private bool isProcessingTower;

	private float processSpeedMultiplier;

	private int dismantledTowerCount;

	public int CurrentEnhanceValue => 0;

	protected override void CannonUpdateProc()
	{
	}

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void ShootProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShootProc_003Ed__30))]
	private IEnumerator CR_ShootProc()
	{
		return null;
	}

	protected override void OnMouseEnterProc()
	{
	}

	protected override void OnMouseOverProc()
	{
	}

	protected override void OnMouseExitProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	public int GetMaxEnhanceLimit()
	{
		return 0;
	}

	public bool IsHaveAllScrapMasterRelic()
	{
		return false;
	}

	protected override void CannonDespawnProc()
	{
	}

	private bool CanPlaceTower()
	{
		return false;
	}

	public Transform GetPlacementTransform()
	{
		return null;
	}

	public bool HasTower()
	{
		return false;
	}

	public void PlaceTowerProc(ABaseTower tower)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlaceTowerProc_003Ed__46))]
	private IEnumerator CR_PlaceTowerProc()
	{
		return null;
	}

	public string GetUpgradeMessage(eDamageType towerElement, int towerCost)
	{
		return null;
	}

	public string Upgrade(eDamageType towerElement, int towerCost)
	{
		return null;
	}

	private void ChangeElement(eDamageType newElement)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ChangeElement_003Ed__50))]
	private IEnumerator CR_ChangeElement(eDamageType newElement)
	{
		return null;
	}

	public void RemoveTowerProc(ABaseTower tower)
	{
	}

	protected override void CannonUpgradeProc()
	{
	}
}
