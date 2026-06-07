using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh.Tk
{
	public class DecorationBuilder : GeneralBuilder
	{
		private static GameObjectX _lockedToGameObjectX;

		public Material HitLinesMaterial;

		public GameObject _handleWrapper;

		[SerializeField]
		private GameObject _decorationTreeViewPrefab;

		private readonly Dictionary<string, string> _defaultSnappingPoints;

		public static readonly UndoRedoCommandController UndoRedoCommandController;

		private const string PirateBoatItemId = "a929d2ba-9ec7-440a-908e-faea48b12d86";

		private Transform _colliderCacheParent;

		private Transform _decoBuilderMainTransform;

		public static Transform EnitiesParent;

		private List<SnappingPointInfo> _snappingPointInfo;

		public Vector3 rotationSnappingMask;

		private int _currentSnapIndex;

		private bool _decorationToolBarIsDirty;

		private bool _isEntityObjectSyncDirty;

		private InputAction _rotateLeft;

		private InputAction _rotateRight;

		private InputAction _shiftInput;

		private InputAction _alternateInput;

		private InputAction _scaleUp;

		private InputAction _scaleDown;

		private EntityObject _origEntityObject;

		public static EventHandler<EventArgs> CycleSnappingPointHappened;

		private bool _isSnapPivotMode;

		private bool _isHandleSpaceModeLocal;

		private InputAction _suppressAutoRotation;

		public Quaternion CustomRotation;

		public float3 Scale;

		private float _decoRotatePressedTimeElapsed;

		private float _scaleUpPressedTimeElapsed;

		private float _scaleDownPressedTimeElapsed;

		private readonly Dictionary<string, GameObject> _entityColliderObjects;

		private GameObject _currentActiveEntityColliderObject;

		private GameObject? _currentEntityHit;

		private bool _refreshActive;

		private static readonly string[] AllTagsToExclude;

		private static readonly string[] AdditionalTagsToExclude;

		private bool _snappedLastFrame;

		public LayerMask layersToDecorate;

		private bool _lastHitWasAWallOrDoor;

		private RaycastHit _lastWallOrDoorHit;

		private bool _skipHitRefresh;

		private float _lockedToGameObjectDistance;

		private bool _attached;

		private bool _isWallDecoEnabled;

		public static Tuple<Vector3?, Vector3?>[] LastHitVisuals;

		public static Vector3 LastHitNormal;

		private BuildableTemplate _lastGroupParent;

		private MeshCollider[] _exteriourColliders;

		private bool ExteriourCollidersDirty;

		private List<(EntityObject eo, float3 position, quaternion rotation, float3 lossyScale)> _originalPositionRotationScaleValues;

		public static string MultiSelectionAcrossDifferentPropsIsNotAllowedKey;

		private static string CannotDecorateWhilePropIsBrokenMessageKey;

		private static string CannotDecorateInLockedRoomsKey;

		public static Color ActiveGameObjectXSelectionColor;

		private const float _scaleCap = 0.01f;

		public const float MinScale = 0.1f;

		public const float MaxScale = 5f;

		private static List<GameObjectX> _editedGoxs;

		public static DecorationBuilder Instance { get; private set; }

		public static GameObjectX LastGoxHit { get; private set; }

		public static GameObjectX ActiveGameObjectX { get; private set; }

		public static GameObjectX LockedToGameObjectX
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static GameObject Handle { get; private set; }

		public static EntityObjectSync EntityObjectSync { get; private set; }

		public static DecorationTreeList3DUIView DecorationTreeView { get; private set; }

		public static int World => 0;

		public bool IsReparentingDecor { get; private set; }

		public bool IsChangingDecoPlacing { get; private set; }

		public bool IsSnapPivotMode
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool IsHandleSpaceModeLocal
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public bool UseQuickRotateZoomControllerMousePosition { get; set; }

		public bool IsWallDecoEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static event EventHandler DecorationBuilt
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LockedToGameObjectXChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LongClickItemPickupHappened
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler GizmoSnapped
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ValueChangedEventArgs<bool>> SnapPivotModeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ValueChangedEventArgs<bool>> HandleSpaceModeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler<ValueChangedEventArgs<bool>> IsWallDecoEnabledChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		public static IEnumerable<Style> GetSyncedEntityUniqueStyles()
		{
			return null;
		}

		private static bool IsActiveGameObjectXValidForBuilding()
		{
			return false;
		}

		protected override void Build()
		{
		}

		private bool CanBuild(bool excludeRoomCheck = false)
		{
			return false;
		}

		public void ApplyStyles(List<string> styleIds, bool applyCost, EntityObject[] eos, bool shouldBeUndoable)
		{
		}

		public static void PayForItem(GameObjectX owner, EntityObject piece, Vector3 coords, BuildableTemplate fromTemplate = null)
		{
		}

		public static void IssueRefundFor(GameObjectX owner, EntityObject piece, Vector3 coords)
		{
		}

		private static GameObject CreateGameObject(string name, Transform parent, Quaternion? rotation = null, Vector3? position = null)
		{
			return null;
		}

		private void Start()
		{
		}

		private void EntityObjectSync_SyncedEntitiesChanged(object sender, EventArgs e)
		{
		}

		private void HookUpInputs()
		{
		}

		private void ExtractToNewProp()
		{
		}

		private void StartParentingToDiffProp()
		{
		}

		public static void TryRedo()
		{
		}

		public static void TryUndo()
		{
		}

		public static void ToggleHierarchyView()
		{
		}

		private void RotationOrScaleStarted()
		{
		}

		public void Stop()
		{
		}

		private bool CanUnGroupSelectedEntity()
		{
			return false;
		}

		private void UnGroupSelectedEntity()
		{
		}

		public static void DestroyAsSoonAsChildBufferIsEmpty(EntityObject obj)
		{
		}

		private static bool CanGroupSelectedEntities()
		{
			return false;
		}

		private void GroupSelectedEntities()
		{
		}

		private void RotateDegrees(float degrees, Vector3 direction)
		{
		}

		public void EnablePlaceMode(EntityObject piece)
		{
		}

		public void AddRemoveSubEntityObject(EntityObject obj, bool changeSilently = false)
		{
		}

		public static void SelectAllPiecesInGox(GameObjectX gox)
		{
		}

		private void Delete(IEnumerable<EntityObject> objects)
		{
		}

		public void Duplicate(IEnumerable<EntityObject> obj)
		{
		}

		private void CycleSnapIndex()
		{
		}

		public void RefreshGizmoSnappingPoint()
		{
		}

		public void ToggleHandleSpaceMode()
		{
		}

		public void SetHandleSpaceMode(bool isLocalSpace)
		{
		}

		public void TogglePivotMode()
		{
		}

		public void SetPivotMode(bool isSnapPivot)
		{
		}

		public static List<SnappingPointInfo> FetchEntityInfo(EntityObject entityObject)
		{
			return null;
		}

		public static void MoveToSameTranslation(EntityObject origObject, EntityObject newObject)
		{
		}

		private static List<SnappingPointInfo> CreateAndGetDummySnappingPointInfos(EntityObject entityObject)
		{
			return null;
		}

		public override void Refresh()
		{
		}

		private RaycastHit? CastForDecorations(Camera camera, IEnumerable<Collider> collidersToExclude, Func<RaycastHit, bool> hitFilter)
		{
			return null;
		}

		private void RefreshInternal(List<Tuple<string, Collider>> collidersToExclude)
		{
		}

		private void UpdateActiveGameObjectX(GameObjectX goxHit)
		{
		}

		private void UpdateEditMode()
		{
		}

		private static void SetLastGoxHit(GameObjectX gox)
		{
		}

		private void RemoveCurrentEntityOutline()
		{
		}

		private void RemoveHitVisual()
		{
		}

		private void UpdateHitVisual(RaycastHit hit, Vector3 p1, Vector3 p2, Vector3 p3)
		{
		}

		private GameObject CreateEntityColliderObject(string prefabId)
		{
			return null;
		}

		private static void RefreshActiveObjectOutline()
		{
		}

		public static void SetActiveGameObjectX(GameObjectX newActive, bool lockSelection)
		{
		}

		private bool UpdateScaleDiff()
		{
			return false;
		}

		private void StopScaling()
		{
		}

		private Quaternion GetDesiredRotationChange()
		{
			return default(Quaternion);
		}

		public Vector3 GetDirection(bool right)
		{
			return default(Vector3);
		}

		private void RemoveActiveEntity()
		{
		}

		public override void EnterBuildMode(Vector3 coords)
		{
		}

		private void ResetSnapIndex()
		{
		}

		private void CreateNewEntity(bool resetSnapIndex = true, string startingStyle = null)
		{
		}

		private void SwitchToDefaultSnapPoint()
		{
		}

		public void EnterEditMode(EntityObject[] objs)
		{
		}

		public void EnterEditMode(EntityObject obj)
		{
		}

		public void TryFinishReparentingDecor()
		{
		}

		private static void Delete(EntityObject dp)
		{
		}

		public override void EnterEditMode(Buildable selectedBuildable)
		{
		}

		private void RefreshEditedGoxs()
		{
		}

		public override void ExitEditMode(bool resetPosition = false)
		{
		}

		public void ResetState()
		{
		}

		public override bool Esc()
		{
			return false;
		}

		public override void ExitBuildMode(bool switchInputMode = true)
		{
		}

		public static IEnumerable<EntityObject> GetSelectedEntityObjects()
		{
			return null;
		}

		private static void AddPositionRotationScaleCommandAfterAction(Action action)
		{
		}

		public IEnumerable<ContextMenuItem> GetContextMenuItems(EntityObject entityObject)
		{
			return null;
		}

		private static ContextMenuItem CreateSelectionContextMenuGroup(GameObjectX gox, EntityObject piece)
		{
			return null;
		}

		private void CycleVariant(int direction)
		{
		}

		public void RefreshExteriorColliders()
		{
		}

		private void EnableExteriorColliders(bool enable)
		{
		}

		public static int GetTotalDecoCount(GameObjectX gox)
		{
			return 0;
		}

		public static int GetUniqueDecoCount(GameObjectX gox)
		{
			return 0;
		}
	}
}
