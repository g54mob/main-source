using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class ObjectPlacementHandler : MonoBehaviour
{
	[Serializable]
	public class DynamicPlacementTargetData
	{
		public int id;

		public IDynamicPlacementTarget dynamicPlacementTarget;

		public List<eTowerSizeType> list_DynamicPlacementSizeType;
	}

	[CompilerGenerated]
	private sealed class _003CCR_RotatePlacement_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ObjectPlacementHandler _003C_003E4__this;

		public Vector3 targetRotation;

		private float _003Cduration_003E5__2;

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
		public _003CCR_RotatePlacement_003Ed__72(int _003C_003E1__state)
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
	private Obj_PlacementEffect placementEffectPrefab;

	private GameObject curPlacementPrefab;

	private GameObject placementDemoObject;

	private IPlaceable placementDemoObjectScpt;

	private Obj_PlacementEffect placementEffectObject;

	private Plane plane_Height_0;

	private Plane plane_Height_1;

	private Vector3Int lastMouseCellPosition;

	private bool isCurrentPlacementBlocked;

	private bool isCurrentPlacementHaveObject;

	private bool isCurrentPlacementInEnemyTerritory;

	private bool isCurrentPlacementInVision;

	private bool isCurrentPlacementAvaliable;

	private int ignoreRaycastLayerMask;

	private int tetrisLayerMask;

	private int obstacleLayerMask;

	private int defaultAndObstacleLayerMask;

	private int groundLayerMask;

	private bool forceCheckBlock;

	private Action placementSuccessCallback;

	private bool isCurrentPlacementTower;

	private ABaseTower currentPlacementTower;

	private bool isCurrentPlacementTetris;

	private Obj_TetrisBlock currentPlacementTetris;

	[SerializeField]
	private List<DynamicPlacementTargetData> list_DynamicPlacementObjectsOnField;

	private IDynamicPlacementTarget dynamicPlacementTarget;

	private List<eTowerSizeType> dynamicPlacementSizeType;

	private List<eItemType> list_BuiltTowerRecord;

	private int builtTowerWithoutHoldingShiftCount;

	private bool isShownShiftNotification;

	private CardData currentPlacementCardData;

	private bool doOverrideBuildCost;

	private int overrideBuildCost;

	private bool canBuildContinuously;

	private bool isCoinEnoughLastCheck;

	private List<APowerGrid> list_WarningActivatedPowerGrid;

	private Vector3 mouseGridOffsetOnMobile;

	private Tween placementErrorRotateTween;

	private Quaternion placementErrorStartRotation;

	private bool isRotating;

	private Vector3 targetPlacementRotation;

	private int rotateCount;

	private Coroutine coroutine_Rotate;

	private Tween rotateTween;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnGridInputControlCellChanged(Vector3 vector)
	{
	}

	private void Update()
	{
	}

	private void CheckPlacementBlocking()
	{
	}

	private bool UpdateCheckBuildTowerCoinEnough(ABaseTower tower, bool forceUpdateControlTip = false)
	{
		return false;
	}

	private bool UpdateCheckTowerPlaceable(bool isPositionMoved)
	{
		return false;
	}

	private bool UpdateCheckTetrisPlaceable()
	{
		return false;
	}

	private bool CheckBlockedByGridObject(List<Collider> list_Colliders)
	{
		return false;
	}

	private bool CheckGroundExistAtPositon(IPlaceable placeable, int raycastLayerMask, bool onlyCheckFullBlock)
	{
		return false;
	}

	private bool CheckTooCloseToPlayerOrigin(IPlaceable placeable)
	{
		return false;
	}

	private bool CheckIsPlacementOccupiedAtPositon(IPlaceable placeable, int raycastLayerMask, bool onlyCheckFullBlock)
	{
		return false;
	}

	private bool CheckIsInEnemyTerritory(IPlaceable placeable)
	{
		return false;
	}

	private bool CheckIsWholeObjectInVision(IPlaceable placeable)
	{
		return false;
	}

	private bool CheckIsUpperPlacementAvaliableAtPositon(IPlaceable placeable, int tetrisLayerMask, int obstacleLayerMask, bool canPlaceWithoutTetris = false)
	{
		return false;
	}

	private bool CanPlaceTower(IEnumerable<Collider> placementColliders, bool canBuildWithoutTetrisBlock, bool requireUniformSupport)
	{
		return false;
	}

	private void SetDemoObjectPosition()
	{
	}

	private void SetDemoObjectToMousePos()
	{
	}

	private void SetDemoObjectToJoystickPos()
	{
	}

	private void OnRequestStartPlacement(GameObject prefab, Action callback, bool canBuildContinuously)
	{
	}

	private void RequestStartPlacementWithCardData(GameObject prefab, CardData cardData, Action callback)
	{
	}

	public void OnStartPlacement(GameObject prefab, Action callback, bool isRebuild = false)
	{
	}

	private void OnOverridePlacementCost(int cost)
	{
	}

	private void OnConfirmPlacement(bool doContinuousBuild)
	{
	}

	private void OnCancelPlacement()
	{
	}

	private void PlayAnim_PlacementError()
	{
	}

	private void OnRequestRotatePlacement(bool isClockwise = true)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RotatePlacement_003Ed__72))]
	private IEnumerator CR_RotatePlacement(Vector3 targetRotation)
	{
		return null;
	}

	private void OnRegisterDynamicPlacementObject(IDynamicPlacementTarget target, List<eTowerSizeType> sizeType)
	{
	}

	private void OnUnregisterDynamicPlacementObject(IDynamicPlacementTarget target)
	{
	}

	private void OnRegisterWorldDynamicPlacementObject(int guid, IDynamicPlacementTarget target, List<eTowerSizeType> list)
	{
	}

	private void OnUnregisterWorldDynamicPlacementObject(int guid)
	{
	}

	private Vector3 GetMouseGridPosition()
	{
		return default(Vector3);
	}

	private Vector3Int GetMouseCellPosition()
	{
		return default(Vector3Int);
	}

	private Vector3 GetMouseAtWorldPosition()
	{
		return default(Vector3);
	}

	public bool IsCurrentPlacementTower()
	{
		return false;
	}

	public ABaseTower GetCurrentPlacementTower()
	{
		return null;
	}

	public bool IsCurrentPlacementTetris()
	{
		return false;
	}

	public Obj_TetrisBlock GetCurrentPlacementTetris()
	{
		return null;
	}

	public bool IsCurrentDynamicPlacementTarget(IDynamicPlacementTarget target)
	{
		return false;
	}

	public bool IsCurrentInPlacement()
	{
		return false;
	}
}
