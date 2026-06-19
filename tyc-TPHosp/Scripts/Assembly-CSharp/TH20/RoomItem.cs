#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using FullInspector;
using FullSerializerSave;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class RoomItem : Entity, ICursorSelectable, IAttributesInterface, IStatusIconEmitter, fsISerializationCallbacks, IMultipleHighlight
	{
		public delegate void VisualSetDelegate();

		private Vector3 _localPosition;

		[DontSave]
		private GridCoord _localCoord;

		private float _rotation;

		[DontSave]
		private GridDirection _gridDirection;

		[DontSave]
		private RoomItemVisual _roomItemVisual;

		[DontSave]
		private Bounds[] _bounds;

		[DontSave]
		private bool _boundsCached;

		[DontSave]
		private Bounds _clipBounds;

		[DontSave]
		private bool _clipBoundsCached;

		[DontSave]
		private Bounds[] _navBounds;

		[DontSave]
		private bool _hasClipBounds;

		[DontSave]
		private bool _navBoundsCached;

		[DontSave]
		private GridBounds _mapTileBound;

		[DontSave]
		private GridBounds[] _mapTileBounds;

		[DontSave]
		private bool _mapTileBoundsDirty = true;

		[DontSave]
		private List<List<Vector3>> _collisionShapes;

		[DontSave]
		private List<List<Vector3>> _solidCollisionShapes;

		[DontSave]
		private bool _collisionShapesCached;

		[DontSave]
		private bool _collisionDirty = true;

		[DontSave]
		private bool _validCollisionShapesRadius;

		[DontSave]
		private float _collisionShapesRadius;

		[DontSave]
		private Vector2 _collisionShapesRadiusWorldCenter;

		[DontSave]
		private List<ConvexPolygon> _worldSpaceSolidShapes;

		[DontSave]
		private List<ConvexPolygon> _worldSpaceNonSolidShapes;

		[DontSave]
		private List<ConvexPolygon> _worldSpaceSolidAndNonSolidShapes;

		private readonly List<string> _startSocketNames;

		private readonly List<ObjectInteraction> _interactions;

		private ObjectAttributes _attributes;

		private FloorPlan _floorPlan;

		private int _purchasePrice = -1;

		private bool _isSelectableOverride;

		private bool _canBeSoldOverride;

		private bool _ignoredByJanitorsOverride;

		private static int _nextID;

		private readonly string _debugName;

		private InWorldMenuObject _activeMenu;

		private static int _debugItemID = -1;

		private AnimatorSavedState _animatorStateForSave;

		private RuntimeAnimatorController _animationGraphForSave;

		private int _upgradeLevel;

		private StatusIcon.Type _statusIconWhenRemoved = StatusIcon.Type.Invalid;

		private bool MaintenanceModifierState;

		public Action<Character> OnInteractionStarted;

		[DontSave]
		private bool ShowDebugInfo { get; set; }

		public string Name => Definition.GetName(_upgradeLevel);

		public string LocalisedName => Definition.GetLocalisedName(_upgradeLevel);

		public int Cost => Definition.GetCost(_upgradeLevel);

		public int EnergyCost => Definition.EnergyCost(_upgradeLevel);

		public bool HasBeenPurchased { get; set; }

		public float Prestige => Definition.GetPrestige(_upgradeLevel);

		public Sprite Icon => Definition.GetIcon(_upgradeLevel);

		public GameObject Prefab => Definition.GetPrefab(_upgradeLevel);

		public GameObject BlueprintPrefab => Definition.GetBlueprintPrefab(_upgradeLevel);

		public GameObject UpgradeAddOnPrefab => Definition.GetUpgradeAddOnPrefab(_upgradeLevel);

		public SharedInstance<AmbulanceConfig> AmbulanceConfig => Definition.GetAmbulanceConfig(_upgradeLevel);

		public GameObject UpgradeAddOnBlueprintPrefab => Definition.GetUpgradeAddOnBlueprintPrefab(_upgradeLevel);

		public bool IsInBoughtPlot { private get; set; }

		public bool IsHospitalWindow { get; set; }

		public Vector3 WorldCenter
		{
			get
			{
				if (CachedBounds.Length != 0)
				{
					return CachedBounds[0].Transform(WorldPosition, Quaternion.Euler(0f, Rotation, 0f)).center;
				}
				return WorldPosition;
			}
		}

		public IRoomItemDefinition Definition { get; private set; }

		public Bounds[] LocalNavBounds
		{
			get
			{
				CacheNavBounds();
				return _navBounds;
			}
		}

		public FloorPlan FloorPlan
		{
			get
			{
				return _floorPlan;
			}
			set
			{
				if (_floorPlan != value)
				{
					if (_floorPlan != null)
					{
						LocalPosition += (_floorPlan.Anchor - value.Anchor).ToWorldPosition();
					}
					_floorPlan = value;
				}
			}
		}

		public Room OwningRoom => FloorPlan.OwningRoom;

		public bool IsValid { get; private set; }

		public string InvalidReasonDebug { get; private set; }

		public string InvalidReasonDisplay { get; private set; }

		public RoomItemVisual Visual
		{
			get
			{
				return _roomItemVisual;
			}
			set
			{
				if (_roomItemVisual != null)
				{
					_roomItemVisual.Destroy();
				}
				_roomItemVisual = value;
				if (this.OnVisualSet != null)
				{
					this.OnVisualSet();
				}
			}
		}

		public Vector3 WorldPosition
		{
			get
			{
				return LocalPosition + FloorPlan.GetAnchorWorldPos();
			}
			set
			{
				LocalPosition = value - FloorPlan.GetAnchorWorldPos();
			}
		}

		public float WorldRotation => Rotation;

		public Vector3 LocalPosition
		{
			get
			{
				return _localPosition;
			}
			set
			{
				_collisionDirty = true;
				_mapTileBoundsDirty = true;
				_localPosition = value;
				_localCoord = _localPosition.ToGridCoord();
			}
		}

		public GridCoord LocalCoord => _localCoord;

		public string UnreachableInteraction { get; set; }

		public float Rotation
		{
			get
			{
				return _rotation;
			}
			set
			{
				_collisionDirty = true;
				_mapTileBoundsDirty = true;
				_rotation = value % 360f;
				_gridDirection = _rotation.ToGridDirection();
			}
		}

		public GridDirection GridRotation => _gridDirection;

		public List<ObjectInteraction> Interactions => _interactions;

		public AttributeFloat MaintenanceLevel
		{
			get
			{
				if (_attributes == null)
				{
					return null;
				}
				return _attributes.GetAttribute(ObjectAttributes.Type.Maintenance);
			}
		}

		public Bounds[] CachedBounds
		{
			get
			{
				CacheBounds();
				return _bounds;
			}
		}

		public int UpgradeLevel => _upgradeLevel;

		public bool ValidCollisionShapesRadius
		{
			get
			{
				CacheWorldSpaceCollisionShapes();
				return _validCollisionShapesRadius;
			}
		}

		public float CollisionShapesRadius
		{
			get
			{
				CacheWorldSpaceCollisionShapes();
				return _collisionShapesRadius;
			}
		}

		public Vector2 CollisionShapesRadiusWorldCenter
		{
			get
			{
				CacheWorldSpaceCollisionShapes();
				return _collisionShapesRadiusWorldCenter;
			}
		}

		public List<ConvexPolygon> WorldSpaceSolidShapes
		{
			get
			{
				CacheWorldSpaceCollisionShapes();
				return _worldSpaceSolidShapes;
			}
		}

		public List<ConvexPolygon> WorldSpaceNonSolidShapes
		{
			get
			{
				CacheWorldSpaceCollisionShapes();
				return _worldSpaceNonSolidShapes;
			}
		}

		public List<ConvexPolygon> WorldSpaceSolidAndNonSolidShapes
		{
			get
			{
				CacheWorldSpaceCollisionShapes();
				return _worldSpaceSolidAndNonSolidShapes;
			}
		}

		public bool CollisionDirty
		{
			set
			{
				_collisionDirty = value;
			}
		}

		public int QueueLength
		{
			get
			{
				int num = 0;
				foreach (ObjectInteraction interaction in Interactions)
				{
					num += interaction.GetQueueLength();
				}
				return num;
			}
		}

		public List<string> StartSocketNames => _startSocketNames;

		public QualificationDefinition UpgradeQualification
		{
			get
			{
				RoomItemUpgradeDefinition nextUpgrade = Definition.GetNextUpgrade(UpgradeLevel);
				if (nextUpgrade == null || !nextUpgrade.UpgradeQualification.NotNull())
				{
					return null;
				}
				return nextUpgrade.UpgradeQualification.Instance;
			}
		}

		public float WallWidth
		{
			get
			{
				CacheBounds();
				if (_bounds != null)
				{
					float num = float.MaxValue;
					float num2 = float.MinValue;
					Bounds[] bounds = _bounds;
					for (int i = 0; i < bounds.Length; i++)
					{
						Bounds bounds2 = bounds[i];
						num = Mathf.Min(num, bounds2.min.x);
						num2 = Mathf.Max(num2, bounds2.max.x);
					}
					return num2 - num;
				}
				return 0f;
			}
		}

		public GridBounds MapTileBound => _mapTileBound;

		public event VisualSetDelegate OnVisualSet;

		public string LocalisedNamePlural(int count)
		{
			return Definition.GetLocalisedNamePlural(count, _upgradeLevel);
		}

		private RoomItem(IRoomItemDefinition definition, Level level)
			: base(definition, level)
		{
			if (_nextID == _debugItemID)
			{
				Logging.Info(LogChannels.Debug, "Spawned!");
			}
			IsValid = true;
			Definition = definition;
			_debugName = string.Format("{2}{0}: {1}", _nextID.ToString().PadLeft(3, '0'), Prefab.name, (this is LandscapeRoomItem) ? "Landscape_" : "RoomItem_");
			_nextID++;
			_interactions = new List<ObjectInteraction>();
			_startSocketNames = new List<string>();
			if (definition.Interactions == null)
			{
				return;
			}
			InteractionDefinition[] interactions = definition.Interactions;
			foreach (InteractionDefinition interactionDefinition in interactions)
			{
				if (interactionDefinition.Deprecated || interactionDefinition.Sockets == null)
				{
					continue;
				}
				for (int j = 0; j < interactionDefinition.Sockets.Length; j++)
				{
					string text = interactionDefinition.Sockets[j];
					string particleEffectName = ((interactionDefinition.ParticleEffects != null && j < interactionDefinition.ParticleEffects.Length) ? interactionDefinition.ParticleEffects[j] : null);
					_interactions.Add(new ObjectInteraction(this, interactionDefinition, text, particleEffectName, base.Level.FinanceManager));
					if (!string.IsNullOrEmpty(text))
					{
						_startSocketNames.AddUnique(text);
					}
				}
			}
		}

		public RoomItem(IRoomItemDefinition definition, FloorPlan floorPlan, Level level)
			: this(definition, level)
		{
			_floorPlan = floorPlan;
			CreateAttributes();
			InitializeComponents();
			SetupMaintenanceCallbacks(checkCallback: true);
		}

		public RoomItem(RoomItem item, FloorPlan floorPlan)
			: this(item.Definition, item.Level)
		{
			_floorPlan = floorPlan;
			LocalPosition = item._localPosition;
			Rotation = item._rotation;
			IsValid = item.IsValid;
			_upgradeLevel = item._upgradeLevel;
			HasBeenPurchased = item.HasBeenPurchased;
			if (_interactions.Count != item._interactions.Count)
			{
				Logging.Warning(LogChannels.Building, "Mismatch in interactions for {0} and {1} ", this, item);
			}
			else
			{
				for (int i = 0; i < _interactions.Count; i++)
				{
					_interactions[i].ValidStartPosition = item._interactions[i].ValidStartPosition;
				}
			}
			CreateAttributes();
			InitializeComponents();
			SetupMaintenanceCallbacks(checkCallback: true);
			RoomItemUpgradeComponent component = item.GetComponent<RoomItemUpgradeComponent>();
			if (component != null)
			{
				RoomItemUpgradeComponent roomItemUpgradeComponent = AddComponent<RoomItemUpgradeComponent>();
				roomItemUpgradeComponent.Progress = component.Progress;
				if (component.Job != null)
				{
					roomItemUpgradeComponent.Job = new JobUpgrade(this);
				}
			}
			ResearchProject researchProject = item.GetComponent<ResearchProjectComponent>()?.Project;
			if (researchProject != null)
			{
				base.Level.ResearchManager.AssignProjectSilent(researchProject, this);
			}
			if (MaintenanceLevel != null && !(floorPlan is BlueprintFloorPlan))
			{
				MaintenanceLevel.SetValue(item.MaintenanceLevel.Value(), callCallbacks: true);
			}
			if (_attributes != null && item._attributes != null)
			{
				_attributes.Copy(item._attributes);
			}
			_purchasePrice = Cost;
		}

		public override void RestoreFromSave()
		{
			_localCoord = _localPosition.ToGridCoord();
			_gridDirection = _rotation.ToGridDirection();
			_mapTileBoundsDirty = true;
			_collisionDirty = true;
			IsInBoughtPlot = FloorPlan.HospitalMap.Plot.Bought;
			IsHospitalWindow = Definition.ItemType == RoomItemDefinition.Type.Window && FloorPlan._hospitalWindows.Contains(this);
			if (Visual == null)
			{
				OnVisualSet += OnVisualRestored;
			}
			else
			{
				OnVisualRestored();
			}
			foreach (ObjectInteraction interaction in _interactions)
			{
				interaction.RestoreFromSave(base.Level.FinanceManager, this);
			}
			SetupMaintenanceCallbacks(checkCallback: false);
			if (!(FloorPlan is BlueprintFloorPlan))
			{
				HasBeenPurchased = true;
			}
			if (_purchasePrice == -1 || _upgradeLevel != 0)
			{
				_purchasePrice = Cost;
			}
			if (!IsValid && Definition.MoveOutOfWay)
			{
				Level level = base.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
				{
					base.Level.BuildEvents.OnRoomItemDestroy.InvokeSafe(this);
				});
			}
			if (MaintenanceLevel != null && MaintenanceLevel.Value() >= 100f && GetComponent<RoomItemMaintenanceComponent>() == null)
			{
				Level level2 = base.Level;
				level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, (Action)delegate
				{
					Logging.Warning(LogChannels.Building, "Found {0} requiring maintenance without a maintenance component", this);
					base.Level.BuildEvents.OnRoomItemMaintenanceRequired.InvokeSafe(this);
				});
			}
			base.RestoreFromSave();
		}

		private void OnVisualRestored()
		{
			OnVisualSet -= OnVisualRestored;
			if (_animatorStateForSave != null)
			{
				Visual.AnimationGraph = _animationGraphForSave;
				_animatorStateForSave.Restore(Visual.Animator);
				_animatorStateForSave = null;
				_animationGraphForSave = null;
			}
			if (Definition.DisableParticlesOnEdit)
			{
				ParticleEffectControlComponent component = Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
				if (component != null)
				{
					component.EnableAllEffects(enable: true);
				}
			}
		}

		private void CreateAttributes()
		{
			if (Definition.Attributes != null && Definition.Attributes.Length != 0)
			{
				_attributes = new ObjectAttributes(this);
				ObjectAttributes.Definition[] attributes = Definition.Attributes;
				foreach (ObjectAttributes.Definition definition in attributes)
				{
					_attributes.Add(definition._type, new AttributeFloat(definition._initialValue, 0f, 100f));
				}
			}
		}

		private void SetupMaintenanceCallbacks(bool checkCallback)
		{
			if (_attributes != null)
			{
				AttributeFloat maintenanceLevel = MaintenanceLevel;
				if (maintenanceLevel != null)
				{
					maintenanceLevel.Changed(MaintenanceLevelChanged);
					maintenanceLevel.Equals(100f, OnBrokenDownEvent, checkCallback);
					maintenanceLevel.LessThan(GameAlgorithms.Config.ItemMaintenanceThreshold, OnRepairedEvent, checkCallback);
					maintenanceLevel.GreaterThan(GameAlgorithms.Config.ItemMaintenanceThreshold, OnNeedsMaintenanceEvent, checkCallback);
				}
			}
		}

		public override string ToString()
		{
			return _debugName;
		}

		private void CacheWorldSpaceCollisionShapes()
		{
			if (!_collisionDirty)
			{
				return;
			}
			_collisionDirty = false;
			_validCollisionShapesRadius = false;
			GetCollisionShapes(out _worldSpaceSolidShapes, worldSpace: true, includeSolid: true, includeNonSolid: false);
			GetCollisionShapes(out _worldSpaceNonSolidShapes, worldSpace: true, includeSolid: false, includeNonSolid: true);
			_worldSpaceSolidAndNonSolidShapes = new List<ConvexPolygon>();
			_worldSpaceSolidAndNonSolidShapes.AddRange(_worldSpaceSolidShapes);
			_worldSpaceSolidAndNonSolidShapes.AddRange(_worldSpaceNonSolidShapes);
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			if (_worldSpaceSolidShapes.Count > 0)
			{
				vector = _worldSpaceSolidShapes[0].Center;
				vector2 = _worldSpaceSolidShapes[0].Center;
				_validCollisionShapesRadius = true;
			}
			else if (_worldSpaceSolidAndNonSolidShapes.Count > 0)
			{
				vector = _worldSpaceSolidAndNonSolidShapes[0].Center;
				vector2 = _worldSpaceSolidAndNonSolidShapes[0].Center;
				_validCollisionShapesRadius = true;
			}
			foreach (ConvexPolygon worldSpaceSolidShape in _worldSpaceSolidShapes)
			{
				foreach (Vector2 point in worldSpaceSolidShape.Points)
				{
					vector.x = Mathf.Min(point.x, vector.x);
					vector.y = Mathf.Min(point.y, vector.y);
					vector2.x = Mathf.Max(point.x, vector2.x);
					vector2.y = Mathf.Max(point.y, vector2.y);
				}
			}
			foreach (ConvexPolygon worldSpaceSolidAndNonSolidShape in _worldSpaceSolidAndNonSolidShapes)
			{
				foreach (Vector2 point2 in worldSpaceSolidAndNonSolidShape.Points)
				{
					vector.x = Mathf.Min(point2.x, vector.x);
					vector.y = Mathf.Min(point2.y, vector.y);
					vector2.x = Mathf.Max(point2.x, vector2.x);
					vector2.y = Mathf.Max(point2.y, vector2.y);
				}
			}
			_collisionShapesRadiusWorldCenter = 0.5f * (vector + vector2);
			_collisionShapesRadius = 0.5f * (vector2 - vector).magnitude;
		}

		public override void Destroy()
		{
			RemoveRoomModifiers(RoomModifierCondition.Maintenance);
			base.Level.BuildEvents.OnRoomItemDestroyed.InvokeSafe(this);
			if (_attributes != null)
			{
				_attributes.Destroy();
			}
			_interactions.ClearAndCallDestroy();
			if (_activeMenu != null)
			{
				base.Level.HUD.DestroyMenu(_activeMenu);
			}
			base.Destroy();
		}

		private void ShowInvalidItemStatusIcon()
		{
			if (IsValid || base.Level.BuildingLogic.IsRoomItemBeingEdited(this) || !FloorPlan.HospitalMap.Plot.Bought)
			{
				return;
			}
			if (base.Level.App.IsRestoringFromSave)
			{
				Level level = base.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
				{
					base.Level.StatusIconManager.ShowStatusIcon(this, StatusIcon.Type.InvalidItem);
				});
			}
			else
			{
				base.Level.StatusIconManager.ShowStatusIcon(this, StatusIcon.Type.InvalidItem);
			}
		}

		public void SetValid(bool valid, string debug, string display)
		{
			IsValid = valid;
			InvalidReasonDebug = debug;
			InvalidReasonDisplay = display;
			ShowInvalidItemStatusIcon();
		}

		public void SetValidDebug(bool valid, string debug)
		{
			IsValid = valid;
			InvalidReasonDebug = debug;
			InvalidReasonDisplay = null;
			ShowInvalidItemStatusIcon();
		}

		public bool TryGetClipBounds(out Bounds clipBounds)
		{
			CacheClipBounds();
			clipBounds = _clipBounds;
			return _hasClipBounds;
		}

		private void CacheBounds()
		{
			if (!_boundsCached)
			{
				bool onlyIncludeSolid = Definition.ItemType == RoomItemDefinition.Type.Door || Definition.ItemType == RoomItemDefinition.Type.SideDoor;
				_bounds = GetBoundsFromBuildBoundsComponents(Prefab, onlyIncludeSolid);
				if (_bounds == null)
				{
					_bounds = GetBoundsFromBoxColliders(Prefab);
				}
				if (_bounds == null)
				{
					_bounds = GetBoundsFromRenderers(Prefab);
				}
				_boundsCached = true;
				_mapTileBounds = new GridBounds[_bounds.Length];
			}
		}

		private void CacheClipBounds()
		{
			if (!_clipBoundsCached)
			{
				ItemClipBoundsComponent componentInChildren = Prefab.GetComponentInChildren<ItemClipBoundsComponent>();
				if (componentInChildren != null)
				{
					_clipBounds = new Bounds(componentInChildren.center, componentInChildren.size);
					_hasClipBounds = true;
				}
				_clipBoundsCached = true;
			}
		}

		private void CacheNavBounds()
		{
			if (_navBoundsCached)
			{
				return;
			}
			_navBounds = GetBoundsFromNavBoundsComponents(Prefab);
			if (_navBounds == null)
			{
				_navBounds = GetBoundsFromBuildBoundsComponents(Prefab, onlyIncludeSolid: true);
			}
			if (_navBounds == null)
			{
				_navBounds = GetBoundsFromBoxColliders(Prefab);
			}
			if (_navBounds == null)
			{
				_navBounds = GetBoundsFromRenderers(Prefab);
			}
			if (_navBounds != null)
			{
				for (int i = 0; i < _navBounds.Length; i++)
				{
					Bounds bounds = _navBounds[i];
					_navBounds[i] = new Bounds
					{
						size = new Vector3(bounds.size.x, 0.5f, bounds.size.z),
						center = new Vector3(bounds.center.x, 0.25f, bounds.center.z)
					};
				}
			}
			_navBoundsCached = true;
		}

		[CanBeNull]
		private static Bounds[] GetBoundsFromNavBoundsComponents(GameObject obj)
		{
			NavBoundsComponent[] componentsInChildren = obj.GetComponentsInChildren<NavBoundsComponent>();
			if (componentsInChildren.Length == 0)
			{
				return null;
			}
			Bounds[] array = new Bounds[componentsInChildren.Length];
			for (int i = 0; i < array.Length; i++)
			{
				NavBoundsComponent navBoundsComponent = componentsInChildren[i];
				array[i] = new Bounds(navBoundsComponent.center, navBoundsComponent.size);
			}
			return array;
		}

		[CanBeNull]
		private static Bounds[] GetBoundsFromBuildBoundsComponents(GameObject obj, bool onlyIncludeSolid)
		{
			ItemBuildBoundsComponent[] componentsInChildren = obj.GetComponentsInChildren<ItemBuildBoundsComponent>();
			if (componentsInChildren.Length == 0)
			{
				return null;
			}
			List<Bounds> list = new List<Bounds>();
			foreach (ItemBuildBoundsComponent itemBuildBoundsComponent in componentsInChildren)
			{
				if (!onlyIncludeSolid || itemBuildBoundsComponent.Solid)
				{
					list.Add(new Bounds(itemBuildBoundsComponent.center, itemBuildBoundsComponent.size));
				}
			}
			return list.ToArray();
		}

		[CanBeNull]
		private static Bounds[] GetBoundsFromBoxColliders(GameObject obj)
		{
			BoxCollider[] componentsInChildren = obj.GetComponentsInChildren<BoxCollider>();
			if (componentsInChildren.Length == 0)
			{
				return null;
			}
			Bounds[] array = new Bounds[componentsInChildren.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Bounds(componentsInChildren[i].center, componentsInChildren[i].size);
			}
			return array;
		}

		private static Bounds[] GetBoundsFromRenderers(GameObject obj)
		{
			Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
			Bounds[] array = new Bounds[1];
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				array[0].Encapsulate(componentsInChildren[i].bounds);
			}
			return array;
		}

		public GridBounds[] GetTileBounds()
		{
			CacheBounds();
			CacheMapTileBounds();
			return _mapTileBounds;
		}

		private void CacheMapTileBounds()
		{
			if (!_mapTileBoundsDirty)
			{
				return;
			}
			_mapTileBound = new GridBounds(0, 0, 0, 0);
			for (int i = 0; i < _bounds.Length; i++)
			{
				Bounds bounds = _bounds[i].Transform(LocalPosition, Quaternion.Euler(0f, Rotation, 0f));
				GridBounds gridBounds = new GridBounds
				{
					Min = bounds.min.ToGridCoord(),
					Max = bounds.max.ToGridCoord()
				};
				gridBounds.Max.X++;
				gridBounds.Max.Y++;
				_mapTileBounds[i] = gridBounds;
				if (i == 0)
				{
					_mapTileBound = gridBounds;
				}
				else
				{
					_mapTileBound |= gridBounds;
				}
			}
			_mapTileBoundsDirty = false;
		}

		private void CacheCollisionShapes()
		{
			if (_collisionShapesCached)
			{
				return;
			}
			_collisionShapes = new List<List<Vector3>>();
			_solidCollisionShapes = new List<List<Vector3>>();
			ItemBuildBoundsComponent[] componentsInChildren = Prefab.GetComponentsInChildren<ItemBuildBoundsComponent>();
			if (componentsInChildren.Length != 0)
			{
				foreach (ItemBuildBoundsComponent itemBuildBoundsComponent in componentsInChildren)
				{
					Bounds bounds = new Bounds(itemBuildBoundsComponent.center, itemBuildBoundsComponent.size);
					(itemBuildBoundsComponent.Solid ? _solidCollisionShapes : _collisionShapes).Add(new List<Vector3>
					{
						new Vector3(bounds.min.x, 0f, bounds.min.z),
						new Vector3(bounds.min.x, 0f, bounds.max.z),
						new Vector3(bounds.max.x, 0f, bounds.min.z),
						new Vector3(bounds.max.x, 0f, bounds.max.z)
					});
				}
			}
			else
			{
				BoxCollider[] componentsInChildren2 = Prefab.GetComponentsInChildren<BoxCollider>();
				if (componentsInChildren2.Length != 0)
				{
					foreach (BoxCollider boxCollider in componentsInChildren2)
					{
						Bounds bounds2 = new Bounds(boxCollider.center, boxCollider.size);
						_solidCollisionShapes.Add(new List<Vector3>
						{
							new Vector3(bounds2.min.x, 0f, bounds2.min.z),
							new Vector3(bounds2.min.x, 0f, bounds2.max.z),
							new Vector3(bounds2.max.x, 0f, bounds2.min.z),
							new Vector3(bounds2.max.x, 0f, bounds2.max.z)
						});
					}
				}
				else
				{
					Renderer[] componentsInChildren3 = Prefab.GetComponentsInChildren<Renderer>();
					Bounds bounds3 = default(Bounds);
					Renderer[] array = componentsInChildren3;
					foreach (Renderer renderer in array)
					{
						bounds3.Encapsulate(renderer.bounds);
					}
					_solidCollisionShapes.Add(new List<Vector3>
					{
						new Vector3(bounds3.min.x, 0f, bounds3.min.z),
						new Vector3(bounds3.min.x, 0f, bounds3.max.z),
						new Vector3(bounds3.max.x, 0f, bounds3.min.z),
						new Vector3(bounds3.max.x, 0f, bounds3.max.z)
					});
				}
			}
			bool flag = _interactions.Count == 1;
			foreach (ObjectInteraction interaction in _interactions)
			{
				if (flag || interaction.Definition.IncludeInBounds)
				{
					Vector3 startPosition = interaction.StartPosition;
					_collisionShapes.Add(new List<Vector3>
					{
						startPosition + new Vector3(0.4f, 0f, -0.4f),
						startPosition + new Vector3(0.4f, 0f, 0.4f),
						startPosition + new Vector3(-0.4f, 0f, -0.4f),
						startPosition + new Vector3(-0.4f, 0f, 0.4f)
					});
				}
			}
			_collisionShapesCached = true;
		}

		public void GetCollisionShapes(out List<ConvexPolygon> shapes, bool worldSpace, bool includeSolid, bool includeNonSolid)
		{
			CacheCollisionShapes();
			shapes = new List<ConvexPolygon>();
			if (includeSolid)
			{
				GetCollisionShapes(_solidCollisionShapes, ref shapes, worldSpace);
			}
			if (includeNonSolid)
			{
				GetCollisionShapes(_collisionShapes, ref shapes, worldSpace);
			}
		}

		[CanBeNull]
		public ConvexPolygon GetCombinedCollisionShape(bool worldSpace, bool includeSolid, bool includeNonSolid)
		{
			GetCollisionShapes(out var shapes, worldSpace, includeSolid, includeNonSolid);
			if (shapes.Count == 0)
			{
				return null;
			}
			ConvexPolygon convexPolygon = new ConvexPolygon();
			foreach (ConvexPolygon item in shapes)
			{
				convexPolygon.Points.AddRange(item.Points);
			}
			convexPolygon.Calculate();
			return convexPolygon;
		}

		private void GetCollisionShapes(List<List<Vector3>> collisionShapes, ref List<ConvexPolygon> shapes, bool worldSpace)
		{
			Quaternion quaternion = (worldSpace ? Quaternion.Euler(0f, Rotation, 0f) : Quaternion.identity);
			Vector3 vector = (worldSpace ? WorldPosition : Vector3.zero);
			foreach (List<Vector3> collisionShape in collisionShapes)
			{
				ConvexPolygon convexPolygon = new ConvexPolygon();
				foreach (Vector3 item in collisionShape)
				{
					Vector3 vector2 = quaternion * item + vector;
					convexPolygon.Points.Add(new Vector2(vector2.x, vector2.z));
				}
				convexPolygon.Calculate();
				shapes.Add(convexPolygon);
			}
		}

		public bool HasInterationWithName(string name)
		{
			foreach (ObjectInteraction interaction in _interactions)
			{
				if (interaction.Name == name)
				{
					return true;
				}
			}
			return false;
		}

		public void GetInterationsByName(string name, List<ObjectInteraction> results)
		{
			foreach (ObjectInteraction interaction in _interactions)
			{
				if (interaction.Name == name)
				{
					results.Add(interaction);
				}
			}
		}

		public bool IsAnyoneInteracting(Character character = null)
		{
			foreach (ObjectInteraction interaction in _interactions)
			{
				if (interaction.Interactor != null && (character == null || interaction.Interactor != character))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAnyoneReservedInteraction(string interactionName, Character character)
		{
			foreach (ObjectInteraction interaction in _interactions)
			{
				if (interaction.Name == interactionName && interaction.Reserved != null && interaction.Reserved != character)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAnyoneReservedInteractionSocket(string socketName, Character character)
		{
			foreach (ObjectInteraction interaction in _interactions)
			{
				if (interaction.StartSocketName == socketName && interaction.Reserved != null && interaction.Reserved != character)
				{
					return true;
				}
			}
			return false;
		}

		public void EndAllInteractions(bool immediately)
		{
			ObjectInteraction[] array = _interactions.ToArray();
			foreach (ObjectInteraction objectInteraction in array)
			{
				Character reserved = objectInteraction.Reserved;
				if (reserved == null)
				{
					continue;
				}
				if (objectInteraction.IsInteracting(reserved))
				{
					if (immediately)
					{
						objectInteraction.EndInteraction(reserved);
					}
					else
					{
						objectInteraction.RequestExit();
					}
				}
				else
				{
					objectInteraction.FreeInteraction(reserved);
				}
			}
		}

		public AttributesManager GetAttributesManager()
		{
			return base.Level.AttributesManager;
		}

		public Attributes GetAttributes()
		{
			return _attributes;
		}

		public void EnableAttributes(bool enabled)
		{
			if (_attributes != null)
			{
				_attributes.Enabled = enabled;
			}
		}

		public float GetAttributeModifierOverTime(string attributeName)
		{
			ObjectAttributes.Type type = EnumHelper<ObjectAttributes.Type>.ToEnum(attributeName);
			return Definition.GetAttributeModifer(type);
		}

		public float GetAttributeMultiplier(int enumValue)
		{
			return 1f;
		}

		public bool IsFunctional()
		{
			if (MaintenanceLevel != null && MaintenanceLevel.Value() >= Definition.MaintenanceFunctionalLevel)
			{
				return false;
			}
			RoomItemFlammableComponent component = GetComponent<RoomItemFlammableComponent>();
			if (component != null && component.IsOnFire)
			{
				return false;
			}
			if (GetComponent<RoomItemUpgradeComponent>() != null)
			{
				return false;
			}
			RoomItemReceptionComponent component2 = GetComponent<RoomItemReceptionComponent>();
			if (component2 != null && !component2.IsStaffed())
			{
				return false;
			}
			RoomItemJobComponent component3 = GetComponent<RoomItemJobComponent>();
			if (component3 != null && !component3.IsStaffed())
			{
				return false;
			}
			ResearchProjectComponent component4 = GetComponent<ResearchProjectComponent>();
			if (component4 != null && component4.Project == null)
			{
				return false;
			}
			RoomItemEctoVatComponent component5 = GetComponent<RoomItemEctoVatComponent>();
			if (component5 != null && component5.Amount <= 0f)
			{
				return false;
			}
			if (GetComponent<EntityNavFailedComponent>() != null)
			{
				return false;
			}
			return true;
		}

		public bool IsSelectable()
		{
			if (Definition.IsSelectable && IsInBoughtPlot && !IsHospitalWindow)
			{
				return !IsSelectableOverridden();
			}
			return false;
		}

		public bool CanBeSold()
		{
			if (Definition.CanBeSold())
			{
				return !IsCanBeSoldOverridden();
			}
			return false;
		}

		public bool IgnoredByJanitors()
		{
			if (!Definition.IgnoredByJanitors)
			{
				return IsIgnoredByJanitorsOverridden();
			}
			return true;
		}

		public bool HasTooltip()
		{
			if (!Definition.HasTooltip)
			{
				return Definition.ShowQueuePositions;
			}
			return true;
		}

		public bool CanHighlight()
		{
			return IsInBoughtPlot;
		}

		public void ToggleDebugInfo()
		{
			ShowDebugInfo = !ShowDebugInfo;
		}

		public Renderer GetHighlightGameObject()
		{
			return null;
		}

		void IMultipleHighlight.GetMultipleHighlightGameObjects(List<Renderer> result)
		{
			Visual.GetHighlightRenderers(result);
		}

		public Vector3 GetMenuAnchorPosition()
		{
			return Visual.GetMenuAnchorPosition();
		}

		public Vector3 GetStatusIconPosition()
		{
			return WorldPosition;
		}

		public bool IsStatusIconEmitterVisible()
		{
			if (Visual != null && Visual.GameObject != null && Visual.GameObject.activeSelf)
			{
				return Visual.GameObject.activeInHierarchy;
			}
			return false;
		}

		[CanBeNull]
		public GameObject GetCameraTrackObject()
		{
			if (Visual == null)
			{
				return null;
			}
			return Visual.GameObject;
		}

		public bool CanDragHoldSelect()
		{
			if (IsSelectable() && Definition.CanDragHoldSelect)
			{
				return Definition.ItemType != RoomItemDefinition.Type.Door;
			}
			return false;
		}

		public void SetActiveMenu(InWorldMenuObject menu)
		{
			_activeMenu = menu;
		}

		public InWorldMenuObject GetActiveMenu()
		{
			return _activeMenu;
		}

		public void DebugGUI()
		{
			if (!ShowDebugInfo)
			{
				return;
			}
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.box);
			Vector3 position = WorldPosition + Vector3.up * 2f;
			Vector3 vector = Camera.main.WorldToScreenPoint(position);
			string empty = string.Empty;
			empty += Name;
			empty += string.Format("\n{0}", IsValid ? "Valid" : InvalidReasonDebug);
			empty = empty + "\n" + _attributes;
			foreach (ObjectInteraction interaction in _interactions)
			{
				empty += $"\n{interaction.Name} {interaction.GetQueueLength()}";
			}
			if (Visual.Animator != null && Visual.Animator.runtimeAnimatorController != null)
			{
				AnimatorClipInfo[] currentAnimatorClipInfo = Visual.Animator.GetCurrentAnimatorClipInfo(0);
				foreach (AnimatorClipInfo animatorClipInfo in currentAnimatorClipInfo)
				{
					empty += $"\nAnimation Clip: {animatorClipInfo.clip.name}";
				}
			}
			RoomItemEctoVatComponent component = GetComponent<RoomItemEctoVatComponent>();
			if (component != null)
			{
				empty += $"\nEcto level: {component.Amount}";
			}
			Vector2 vector2 = gUIStyle.CalcSize(new GUIContent(empty));
			GUI.Box(new Rect(vector.x - vector2.x / 2f, (float)Screen.height - vector.y - vector2.y, vector2.x, vector2.y), empty, gUIStyle);
		}

		public void DebugDraw()
		{
			if (!DebugVars.ShowInteractionPoints.Value && !ShowDebugInfo)
			{
				return;
			}
			foreach (ObjectInteraction interaction in _interactions)
			{
				Gizmos.color = (interaction.ValidStartPosition ? Color.green : Color.red);
				Gizmos.DrawSphere(interaction.WorldStartPosition, 0.15f);
			}
		}

		private void MaintenanceLevelChanged(float newValue)
		{
			if (Definition.RoomModifiers == null)
			{
				return;
			}
			for (int i = 0; i < Definition.RoomModifiers.Length; i++)
			{
				if (Definition.RoomModifiers[i] is RoomModifierMapAttribute roomModifierMapAttribute)
				{
					roomModifierMapAttribute.Refresh(this, FloorPlan);
				}
			}
		}

		public virtual void AddToWorld(bool updateNavigation)
		{
			if (_statusIconWhenRemoved != StatusIcon.Type.Invalid)
			{
				base.Level.StatusIconManager.ShowStatusIcon(this, _statusIconWhenRemoved);
				_statusIconWhenRemoved = StatusIcon.Type.Invalid;
			}
			AddRoomModifiers();
			if (IsRepaired())
			{
				AddRoomModifiers(RoomModifierCondition.Maintenance);
			}
			if (Definition.ItemType == RoomItemDefinition.Type.Ambulance)
			{
				if (Definition.BaseAmbulanceConfig == null)
				{
					Logging.Error(LogChannels.AmbulanceEmergency, "You defined item {0} as an ambulance but did not give it an ambulance config.", this);
				}
				else
				{
					base.Level.ChallengeManager.PlayerAmbulanceDepartment.CreateAmbulance(Definition.BaseAmbulanceConfig.Instance, this);
				}
			}
			base.Level.BuildEvents.OnRoomItemAdded.InvokeSafe(this, FloorPlan);
			if (updateNavigation && Definition.AffectsNavigation)
			{
				base.Level.WorldState.UpdateNavigation();
			}
		}

		public void AddRoomModifiers(RoomModifierCondition condition = RoomModifierCondition.None)
		{
			if (condition == RoomModifierCondition.Maintenance && MaintenanceModifierState)
			{
				return;
			}
			IterateModifiers(delegate(RoomModifier modifier)
			{
				RoomModifierCondition modifierCondition = modifier.GetModifierCondition();
				if ((modifierCondition != RoomModifierCondition.Maintenance || !MaintenanceModifierState) && (condition == RoomModifierCondition.All || modifierCondition == condition))
				{
					modifier.Apply(this, FloorPlan);
				}
			});
			if (condition == RoomModifierCondition.Maintenance || condition == RoomModifierCondition.All)
			{
				MaintenanceModifierState = true;
			}
		}

		public virtual void RemoveFromWorld(bool updateNavigation)
		{
			if (base.Level == null)
			{
				return;
			}
			if (_statusIconWhenRemoved == StatusIcon.Type.Invalid && base.Level.StatusIconManager != null)
			{
				_statusIconWhenRemoved = base.Level.StatusIconManager.GetActiveStatusIconType(this);
				if (_statusIconWhenRemoved == StatusIcon.Type.InvalidItem)
				{
					_statusIconWhenRemoved = StatusIcon.Type.Invalid;
				}
			}
			if (updateNavigation && Definition.ItemType == RoomItemDefinition.Type.Ambulance)
			{
				base.Level.ChallengeManager.PlayerAmbulanceDepartment.RemoveAmbulance(this);
			}
			RemoveRoomModifiers(RoomModifierCondition.All);
			if (base.Level.BuildEvents != null)
			{
				base.Level.BuildEvents.OnRoomItemRemoved.InvokeSafe(this, FloorPlan);
			}
			if (base.Level.StatusIconManager != null)
			{
				base.Level.StatusIconManager.DestroyStatusIcon(this);
			}
			if (updateNavigation && Definition.AffectsNavigation)
			{
				base.Level.WorldState.UpdateNavigation();
			}
		}

		public void RemoveRoomModifiers(RoomModifierCondition condition = RoomModifierCondition.None)
		{
			if (condition == RoomModifierCondition.Maintenance && !MaintenanceModifierState)
			{
				return;
			}
			IterateModifiers(delegate(RoomModifier modifier)
			{
				RoomModifierCondition modifierCondition = modifier.GetModifierCondition();
				if ((modifierCondition != RoomModifierCondition.Maintenance || MaintenanceModifierState) && (condition == RoomModifierCondition.All || modifierCondition == condition))
				{
					modifier.Remove(this, FloorPlan);
				}
			});
			if (condition == RoomModifierCondition.Maintenance || condition == RoomModifierCondition.All)
			{
				MaintenanceModifierState = false;
			}
		}

		private void OnBrokenDownEvent()
		{
			if (OwningRoom != null)
			{
				OwningRoom.OnItemBrokeDown(this);
			}
			base.Level.BuildEvents.OnRoomItemBrokenDown.InvokeSafe(this);
		}

		private void OnRepairedEvent()
		{
			if (OwningRoom != null)
			{
				OwningRoom.OnItemRepaired(this);
			}
			base.Level.BuildEvents.OnRoomItemMaintained.InvokeSafe(this);
			AddRoomModifiers(RoomModifierCondition.Maintenance);
		}

		private void OnNeedsMaintenanceEvent()
		{
			base.Level.BuildEvents.OnRoomItemMaintenanceRequired.InvokeSafe(this);
			RemoveRoomModifiers(RoomModifierCondition.Maintenance);
		}

		public int SellValue()
		{
			if (IsHospitalWindow)
			{
				return 0;
			}
			float t = ((MaintenanceLevel != null && !Definition.IgnoredByJanitors) ? (MaintenanceLevel.Value() / 100f) : 0f);
			return Mathf.CeilToInt((float)((_purchasePrice != -1) ? _purchasePrice : Cost) * Mathf.Lerp(1f, 0.25f, t) * GameAlgorithms.Config.GlobalSellValueMultiplier);
		}

		void fsISerializationCallbacks.OnBeforeSerializeInstance(Type storageType)
		{
			if (Visual != null && Visual.AnimationGraph != null)
			{
				_animationGraphForSave = Visual.AnimationGraph;
				_animatorStateForSave = new AnimatorSavedState(Visual.Animator);
			}
		}

		void fsISerializationCallbacks.OnBeforeSerialize(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnAfterSerialize(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnAfterSerializeInstance(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnBeforeDeserialize(Type storageType, ref fsData data)
		{
		}

		void fsISerializationCallbacks.OnAfterDeserialize(Type storageType)
		{
		}

		void fsISerializationCallbacks.OnAfterDeserializeInstance(Type storageType)
		{
		}

		public void Upgrade(Staff staff)
		{
			RemoveRoomModifiers(RoomModifierCondition.All);
			_upgradeLevel++;
			AddRoomModifiers();
			if (IsRepaired())
			{
				AddRoomModifiers(RoomModifierCondition.Maintenance);
			}
			if (Visual != null)
			{
				AnimatorSavedState animatorSavedState = new AnimatorSavedState(Visual.Animator);
				Visual.Destroy();
				Visual = null;
				OwningRoom.FloorPlanVisual.CreateRoomItems();
				foreach (ObjectInteraction interaction in _interactions)
				{
					interaction.RefreshSockets();
				}
				if (Visual != null)
				{
					animatorSavedState.Restore(Visual.Animator);
				}
			}
			base.Level.BuildEvents.OnRoomItemUpgradeComplete.InvokeSafe(this, staff);
			base.Level.InWorldMessages.ShowMessage(string.Format(ScriptLocalization.Misc.UpgradedTo_CS, LocalisedName), WorldPosition, 3f, InWorldMessages.MessageType.Info);
			_purchasePrice = Cost;
		}

		public void Downgrade()
		{
			_upgradeLevel = 0;
			_purchasePrice = Cost;
		}

		public void GetRoomModifiersOfType<T>(List<T> result) where T : RoomModifier
		{
			for (int i = 0; i < Definition.RoomModifiers.Length; i++)
			{
				if (Definition.RoomModifiers[i] is T)
				{
					result.Add((T)Definition.RoomModifiers[i]);
				}
			}
			RoomItemUpgradeDefinition upgrade = Definition.GetUpgrade(_upgradeLevel);
			if (upgrade == null || upgrade.RoomModifiers == null)
			{
				return;
			}
			RoomModifier[] roomModifiers = upgrade.RoomModifiers;
			foreach (RoomModifier roomModifier in roomModifiers)
			{
				if (roomModifier is T)
				{
					result.Add((T)roomModifier);
				}
			}
		}

		public void IterateModifiers<T>(Action<T> callback) where T : RoomModifier
		{
			Definition.IterateModifiers(callback);
			RoomItemUpgradeDefinition upgrade = Definition.GetUpgrade(_upgradeLevel);
			if (upgrade == null || upgrade.RoomModifiers == null)
			{
				return;
			}
			RoomModifier[] roomModifiers = upgrade.RoomModifiers;
			foreach (RoomModifier roomModifier in roomModifiers)
			{
				if (roomModifier is T)
				{
					callback((T)roomModifier);
				}
			}
		}

		public bool IsRepaired()
		{
			if (MaintenanceLevel != null)
			{
				return MaintenanceLevel.Value() < GameAlgorithms.Config.ItemMaintenanceThreshold;
			}
			return true;
		}

		public bool IsFullyRepaired()
		{
			if (MaintenanceLevel != null)
			{
				return MaintenanceLevel.Value() <= GameAlgorithms.Config.ItemFullyRepairedThreshold;
			}
			return true;
		}

		public void GetAttributeNames(out string[] names)
		{
			names = ObjectAttributes.TypeNames;
		}

		public void GetAttributeHashCodes(out int[] hashCodes)
		{
			hashCodes = ObjectAttributes.TypeHashCodes;
		}

		public bool IsBeingRepaired(Character character)
		{
			foreach (ObjectInteraction interaction in Interactions)
			{
				if (interaction.Type == InteractionAttributeModifier.Type.Maintain)
				{
					if (interaction.Reserved != null && interaction.Reserved != character)
					{
						return true;
					}
					if (interaction.Interactor != null && interaction.Interactor != character)
					{
						return true;
					}
				}
			}
			return false;
		}

		public override void VerifyAfterLoad()
		{
			base.VerifyAfterLoad();
			if (OwningRoom == null || FloorPlan is BlueprintFloorPlan || !base.Level.WorldState.AllRooms.Contains(OwningRoom) || base.Level.EntityManager.GetEntityByID(OwningRoom.ID) == null)
			{
				Logging.Warning(LogChannels.Save, "Found invalid room item, destroying");
				RemoveFromWorld(updateNavigation: false);
				Destroy();
			}
		}

		public void OverrideDefinitionCanBeSold(bool newSellableState)
		{
			_canBeSoldOverride = !newSellableState;
		}

		public void OverrideDefinitionIsSelectable(bool newSelectableState)
		{
			_isSelectableOverride = !newSelectableState;
		}

		public void OverrideDefinitionIgnoredByJanitors(bool newIgnoreState)
		{
			_ignoredByJanitorsOverride = newIgnoreState;
		}

		public bool IsSelectableOverridden()
		{
			return _isSelectableOverride;
		}

		public bool IsCanBeSoldOverridden()
		{
			return _canBeSoldOverride;
		}

		public bool IsIgnoredByJanitorsOverridden()
		{
			return _ignoredByJanitorsOverride;
		}
	}
}
