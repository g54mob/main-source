using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public abstract class APowerGrid : AGridObject, IInteractable
{
	public enum ePowerGridState
	{
		IDLE = 0,
		HAS_TETRIS = 1,
		HAS_TOWER = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_PlaceTetrisProc_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_PlaceTetrisProc_003Ed__40(int _003C_003E1__state)
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
	protected PowerGridSettingData settingData;

	[SerializeField]
	protected Animator animator;

	[SerializeField]
	protected Collider collider;

	[SerializeField]
	private MeshRenderer meshRenderer_Icon;

	[SerializeField]
	private Material material_Unavailable;

	[SerializeField]
	private bool doShowTooltip;

	[SerializeField]
	protected ePowerGridState state;

	protected Vector3Int registeredPosition;

	protected bool isRegisteredToTetris;

	protected bool isAppliedToTower;

	protected bool isFromBlockRune;

	private Obj_TetrisBlock tetrisBlock;

	private bool isInitialized;

	private bool isForPlacementPreview;

	private Material originalIconMaterial;

	private bool isRegisteredToGridSystem;

	private bool isUnavailable;

	private bool isRegisteredPlacementChangeEvent;

	private bool isWarningOn;

	private Tweener tween;

	protected ABaseTower registeredTower;

	private bool isTooltipOn;

	public PowerGridSettingData SettingData => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Initialize()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public void ToggleUnavailable(bool isUnavailable)
	{
	}

	public void SetIsForPlacementPreview(bool isPreview)
	{
	}

	private void OnPlacementPositionChanged(IPlaceable placeable)
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	private void OnDestroy()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	public virtual void SwitchBlockPlacementWarning(bool isOn)
	{
	}

	public void RegisterToTetris(Obj_TetrisBlock tetris, bool isFromBlockRune)
	{
	}

	public virtual void OnTetrisPlaced(Obj_TetrisBlock tetris)
	{
	}

	protected virtual void OnTetrisPlacedProc(Obj_TetrisBlock tetris)
	{
	}

	protected virtual void OnTetrisRemoved(Obj_TetrisBlock tetris)
	{
	}

	private void OnTetrisRemoved_SingleBlock(Obj_TetrisBlock block, Vector3Int positionInt)
	{
	}

	protected virtual void OnTetrisRemovedProc(Obj_TetrisBlock tetris)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlaceTetrisProc_003Ed__40))]
	protected virtual IEnumerator CR_PlaceTetrisProc(Obj_TetrisBlock tetris)
	{
		return null;
	}

	public void CheckIsHaveTetrisOnGrid()
	{
	}

	public void RemovePowerGrid()
	{
	}

	public void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	private void OnTowerUpgrade(ABaseTower tower)
	{
	}

	private void OnTowerElementChanged(ABaseTower tower, eDamageType element)
	{
	}

	public void ForceApplyEffectToTower(ABaseTower tower)
	{
	}

	protected virtual void ApplyEffectToTower(ABaseTower tower)
	{
	}

	protected virtual void RemoveEffectFromTower(ABaseTower tower)
	{
	}

	public void OnMouseEnter()
	{
	}

	public void OnMouseExit()
	{
	}

	public void OnMouseDown()
	{
	}

	public void OnMouseUp()
	{
	}

	private void OnMouseOver()
	{
	}

	public ePowerGridType GetPowerGridType()
	{
		return default(ePowerGridType);
	}

	public virtual string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public virtual string GetLocStatsString()
	{
		return null;
	}

	public void OnRayEnter()
	{
	}

	public void OnRayStay()
	{
	}

	public void OnRayExit()
	{
	}

	public void OnRayClickDown()
	{
	}

	public void OnRayClickUp()
	{
	}
}
