using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using Sirenix.OdinInspector;
using UnityEngine;

public class BaseGridMgr : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_MoveCameraToElevator_003Ed__181 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		public BaseState endState;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_MoveCameraToElevator_003Ed__181(int _003C_003E1__state)
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
	private sealed class _003C_MoveCameraToElevator_003Ed__182 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		public Vector3 posOffset;

		public float zoomOffset;

		public BaseState endState;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_MoveCameraToElevator_003Ed__182(int _003C_003E1__state)
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
	private sealed class _003C_MoveCameraToElevator_003Ed__183 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		public Vector3 posOffset;

		public float zoomOffset;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_MoveCameraToElevator_003Ed__183(int _003C_003E1__state)
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
	private sealed class _003C_RotateMultiSelect_003Ed__114 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		public int rotAmt;

		private float _003CstartTime_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CstartZ_003E5__4;

		private float _003CtgtZ_003E5__5;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RotateMultiSelect_003Ed__114(int _003C_003E1__state)
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
	private sealed class _003C_RunDismantleMultiple_003Ed__143 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		private List<BuildingObj> _003CbList_003E5__2;

		private int _003Ci_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunDismantleMultiple_003Ed__143(int _003C_003E1__state)
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
	private sealed class _003C_RunExpand_003Ed__175 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunExpand_003Ed__175(int _003C_003E1__state)
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
	private sealed class _003C_RunUpgradeMultiple_003Ed__138 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		private List<BuildingObj> _003CbList_003E5__2;

		private int _003Ci_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunUpgradeMultiple_003Ed__138(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndRefreshPlacePreviewColor_003Ed__127 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_WaitAndRefreshPlacePreviewColor_003Ed__127(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndTurnOffDrag_003Ed__119 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_WaitAndTurnOffDrag_003Ed__119(int _003C_003E1__state)
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
	private sealed class _003C_WaitForSwapsAndRefreshPlacePreviewColor_003Ed__129 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseGridMgr _003C_003E4__this;

		private bool _003CisMoving_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_WaitForSwapsAndRefreshPlacePreviewColor_003Ed__129(int _003C_003E1__state)
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

	public static BaseGridMgr I;

	public Dictionary<Collider2D, BuildingObj> BuildingColDict;

	public SerializedObjectPool<BaseCharObj> CharPool;

	public const float kSpaceWidth = 1.125f;

	public const float kSpaceHeight = 1.125f;

	private bool _isMouseDown;

	private Vector2 _mouseDownPos;

	private Vector2 _lastMousePos;

	private bool _isCurRearrangeClickValid;

	private bool _doesCurTouchAllowPan;

	private Vector2 _lastBuildingDragTouchPos;

	private bool _isDragging;

	public SerializedObjectPool<ExpansionHoverObj> ExpansionHoverPool;

	private ExpansionHoverObj _hoveredExpansionObj;

	private int _curExpansionX;

	private int _curExpansionY;

	public Mesh[] ChunkCoverMeshes;

	public Mesh[] ChunkVerticalCoverMeshes;

	public Mesh[] ChunkHorizontalCoverMeshes;

	public Mesh[] ChunkCornerCoverMeshes;

	public ChunkCoverObj[][] BaseCovers;

	public ChunkCoverObj[][] HorzCovers;

	public ChunkCoverObj[][] VertCovers;

	public ChunkCoverObj[][] CornerCovers;

	public Transform ElevatorHoverXfm;

	public float OutOfBoundsTopY;

	public float OutOfBoundsLeftX;

	public float OutOfBoundsRightX;

	public float LeftBorderX;

	public float RightBorderX;

	public float TopBorderY;

	public float BottomBorderY;

	public float PlayerY;

	public HarvesterHoverObj HarvesterHoverObj;

	public SpriteRenderer RendMultiselect;

	private List<BuildingObj> _multiSelectedBuildings;

	private Vector2 _minMultiSelectedOGBounds;

	private Vector2 _maxMultiSelectedOGBounds;

	private List<BuildingInst> _multiSelectedOGInst;

	private CoroutineHandle _multiSelectRoutine;

	public bool IsMultiselectEnabled;

	public bool IsAimPanEnabled;

	private BuildingObj _hoverBuilding;

	private BuildingObj _pendingDismantleBuilding;

	private float _hoverX;

	private float _hoverY;

	private BuildingObj _pendingRearrangeBuilding;

	private Vector3 _pendingRearrangeBuildingOGPos;

	private BuildingObj _pendingRearrangePlaceholder;

	private BuildingObj _placePreview;

	private List<BuildingObj> _pendingSwapBuildings;

	private List<BuildingObj> _activeSwapBuildings;

	private List<BuildingObj> _waitingSwapBuildings;

	private CoroutineHandle _activeSwapRoutine;

	private Vector3 _swapOrigin;

	private Vector3 _placePreviewOffset;

	private bool _isCurAimLauncherValid;

	private bool _isCurRightStickPressValid;

	public const int kChunkWidth = 8;

	public const int kChunkHeight = 6;

	public const float kChunkWorldWidth = 9f;

	public const float kChunkWorldHeight = 6.75f;

	public const int kChunkCols = 5;

	public const int kChunkRows = 5;

	private float[] _cursorScrollAreaTime;

	private float _lastScrollWheelTime;

	public GameObject[] WrapperCliffs;

	public MeshRenderer[] CliffRends;

	private int _numMouseDownTouches;

	private float _lastZoomTime;

	private List<BuildingObj> _bldBuffer;

	private bool _isRotatingMultiselect;

	private const float kGrowLen = 0.05f;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public Vector3 ClampInsideWalls(Vector3 pos)
	{
		return default(Vector3);
	}

	public Vector3 ClampCameraPos(Vector3 pos)
	{
		return default(Vector3);
	}

	public Vector3 ClampBuildingPreview(Vector3 pos)
	{
		return default(Vector3);
	}

	public void InitGrid()
	{
	}

	public List<Vector2Int> FindEmptySpots()
	{
		return null;
	}

	public void RefreshChunkCovers()
	{
	}

	public Vector3 GetCenterPos()
	{
		return default(Vector3);
	}

	public void RefreshBoardValues()
	{
	}

	public bool IsDragging()
	{
		return false;
	}

	public bool IsMouseDown()
	{
		return false;
	}

	public void ClearMouseDown()
	{
	}

	public void SetMouseDown()
	{
	}

	public void NormalClickOnBuilding()
	{
	}

	public void RearrangeClickOnBuilding()
	{
	}

	public void NormalRightClickOnBuilding()
	{
	}

	private void CancelDismantleBuilding()
	{
	}

	private void ClickOnExpansion()
	{
	}

	public void CancelRearrange()
	{
	}

	public void ClearRearrange()
	{
	}

	public void ClickRearrange(BuildingObj tgtBld = null)
	{
	}

	private bool IsPanAllowed()
	{
		return false;
	}

	private void UpdateMouseControls()
	{
	}

	private void UpdateTouchControls()
	{
	}

	private void UpdateControllerControls()
	{
	}

	public Vector2 GetLastBuildingDragTouchPos()
	{
		return default(Vector2);
	}

	public void ExitPlaceBuilding()
	{
	}

	private void OnInputChanged()
	{
	}

	public void ClearMultiSelect()
	{
	}

	private void InitMultiSelect()
	{
	}

	private void UpdateMultiSelect(Vector2 mousePos)
	{
	}

	private void EndMultiSelect()
	{
	}

	public void SetMultiselectEnabled(bool isOn)
	{
	}

	public void SetHarvestPanEnabled(bool isOn)
	{
	}

	public void RefreshUpgradeable(bool isEntering)
	{
	}

	private void MyUpdate()
	{
	}

	private void UpdateCursorScroll(CardinalDir dir, bool isInArea)
	{
	}

	public bool CanRotatePlacePreview()
	{
		return false;
	}

	public void RotatePlacePreview(int rotAmt)
	{
	}

	public Vector3 GetHoverPos()
	{
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(_003C_RotateMultiSelect_003Ed__114))]
	private IEnumerator<float> _RotateMultiSelect(int rotAmt)
	{
		return null;
	}

	public bool CanRotate(BuildingInfo bInf)
	{
		return false;
	}

	public bool IsValidExpansionTgt(int chunkX, int chunkY)
	{
		return false;
	}

	public void TakeResourcesFromBuilding(BuildingObj b)
	{
	}

	public void TakeResourcesFromHoverTgt()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndTurnOffDrag_003Ed__119))]
	private IEnumerator<float> _WaitAndTurnOffDrag()
	{
		return null;
	}

	public BuildingObj GetPendingRearrangeBuilding()
	{
		return null;
	}

	public BuildingObj GetPlacePreview()
	{
		return null;
	}

	public bool CanBuildPlacePreview()
	{
		return false;
	}

	public int GetNumPreviewBuildingCols(int colIdx)
	{
		return 0;
	}

	public int GetNumBuildingCols(BuildingObj b, Vector3 pos, int colIdx)
	{
		return 0;
	}

	public void ClearHover()
	{
	}

	public void SetHover(float x, float y, bool force = false)
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndRefreshPlacePreviewColor_003Ed__127))]
	private IEnumerator<float> _WaitAndRefreshPlacePreviewColor()
	{
		return null;
	}

	private void WaitForSwapsAndRefreshPlacePreviewColor()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitForSwapsAndRefreshPlacePreviewColor_003Ed__129))]
	private IEnumerator<float> _WaitForSwapsAndRefreshPlacePreviewColor()
	{
		return null;
	}

	private void RefreshPlacePreviewColor()
	{
	}

	public static void OnHousingBuilt(BuildingInst newBuild)
	{
	}

	public void BuildBuilding(float x, float y, int rot)
	{
	}

	public void AnimateCharUnlocked(CharType housingChar, BuildingObj home)
	{
	}

	public void ClearCharsTouchingBuilding(BuildingObj b)
	{
	}

	public void UpgradeBuilding(BuildingObj b)
	{
	}

	public void ShowUpgradeMultiSelectionDialog()
	{
	}

	private void UpgradeMultiSelection()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunUpgradeMultiple_003Ed__138))]
	private IEnumerator<float> _RunUpgradeMultiple()
	{
		return null;
	}

	public void ShowDismantleMultiSelectionDialog()
	{
	}

	private void DismantleMultiSelection()
	{
	}

	public void DismantleBuilding(BuildingObj b)
	{
	}

	public void DismantleHoverBuilding()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunDismantleMultiple_003Ed__143))]
	private IEnumerator<float> _RunDismantleMultiple()
	{
		return null;
	}

	public void RegisterBuilding(BuildingObj b)
	{
	}

	public void DeregisterBuilding(BuildingObj b)
	{
	}

	public bool GetNearestValidChunkPos(Vector3 worldPos, out int hoverX, out int hoverY, DelegateUtl.BoolReturnEventPos validCheck)
	{
		hoverX = default(int);
		hoverY = default(int);
		return false;
	}

	public static int GetChunkXFromWorldPos(float worldX)
	{
		return 0;
	}

	public static int GetChunkYFromWorldPos(float worldY)
	{
		return 0;
	}

	public static Vector3 GetChunkBotLeft(int x, int y)
	{
		return default(Vector3);
	}

	public static Vector3 GetChunkTopRight(int x, int y)
	{
		return default(Vector3);
	}

	public static Vector2Int GetChunkBotLeftGridPos(int x, int y)
	{
		return default(Vector2Int);
	}

	public bool IsPurchasedChunk(int x, int y)
	{
		return false;
	}

	public bool IsChunkInBounds(int x, int y)
	{
		return false;
	}

	public bool IsInWorldBounds(BuildingObj b)
	{
		return false;
	}

	public bool IsInWorldBounds(Vector3 pos)
	{
		return false;
	}

	public bool IsInWorldBounds(float x, float y)
	{
		return false;
	}

	public Vector3 GetWorldPos(Vector2Int gridPos)
	{
		return default(Vector3);
	}

	public Vector3 GetWorldPos(int x, int y)
	{
		return default(Vector3);
	}

	public float GetWorldX(int x)
	{
		return 0f;
	}

	public float GetWorldY(int y)
	{
		return 0f;
	}

	public BuildingObj GetBuildingAtWorldPos(float x, float y)
	{
		return null;
	}

	public BuildingObj GetBuildingAtWorldPos(Vector3 worldPos)
	{
		return null;
	}

	public Vector3 GetHoverPosAtScreenPos(Vector2 screenPos)
	{
		return default(Vector3);
	}

	public BuildingObj WorkerHitBuilding(Collider2D col, BallObj ball, Vector2 hitNormal)
	{
		return null;
	}

	public void WorkerHarvestResource(Collider2D col, BallObj ball)
	{
	}

	public void WorkerHarvestResource(BuildingObj b, BallObj ball, bool isDirect)
	{
	}

	public void EnterExpansionMode()
	{
	}

	public void ExitExpansionMode()
	{
	}

	public void FadeOutExpansionHover()
	{
	}

	public void SetExpansionHover(int chunkX, int chunkY)
	{
	}

	public void ClearExpansionHover()
	{
	}

	public int GetExpansionCost()
	{
		return 0;
	}

	public void ConfirmExpansion()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunExpand_003Ed__175))]
	private IEnumerator<float> _RunExpand()
	{
		return null;
	}

	public bool IsEntrance(int x, int y)
	{
		return false;
	}

	public int GetEntranceX()
	{
		return 0;
	}

	public int GetEntranceY()
	{
		return 0;
	}

	public Vector3 GetEntranceBotMid()
	{
		return default(Vector3);
	}

	public void RemoveChar(BaseCharObj b)
	{
	}

	[IteratorStateMachine(typeof(_003C_MoveCameraToElevator_003Ed__181))]
	public IEnumerator<float> _MoveCameraToElevator(BaseState endState)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MoveCameraToElevator_003Ed__182))]
	public IEnumerator<float> _MoveCameraToElevator(BaseState endState, Vector3 posOffset, float zoomOffset)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MoveCameraToElevator_003Ed__183))]
	public IEnumerator<float> _MoveCameraToElevator(Vector3 posOffset, float zoomOffset)
	{
		return null;
	}

	public List<BuildingObj> GetMultiSelectedBuildings()
	{
		return null;
	}

	private void OnStateChanged()
	{
	}
}
