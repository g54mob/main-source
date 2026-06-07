using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class BuildController : SingletonMonoBehaviour<BuildController>
	{
		public enum BuildControllerState
		{
			InActive = 0,
			Idle = 1,
			Zoning = 2,
			BuildProps = 3,
			PropEdit = 4,
			DemolishProps = 5
		}

		public LayerMask buildCollisionLayers;

		private readonly int _floor;

		private DecorationBuilder _decorationBuilder;

		private DragBuilder _dragBuilder;

		private GeneralBuilder _generalBuilder;

		private WallAddOnBuilder _wallAddOnBuilder;

		private ZoneBuilder _zoneBuilder;

		private BaseBuilder _currentBuilder;

		private Vector3 _currentCoords;

		private Vector3 _lastIdleCoords;

		private GameController _gc;

		public Material OutsideDoorMaterial;

		public Color buildValidOutlineColor;

		public Color buildInvalidOutlineColor;

		public float floorAnimDuration;

		public GameObject demolishEffectPrefab;

		public Material defaultBlueprintMaterial;

		public GameObject buildParticlePrefabMedium;

		public GameObject buildParticlePrefabSmall;

		private int _currentCost;

		private BuildControllerState _currentState;

		private List<Buildable> _allPropBuildables;

		private List<Buildable> _currentBuildablesToDemolish;

		private List<Buildable> _currentHighlightedBuildables;

		public const string BUILDCONTROLLER_DISALLOW_PLACING_FLAG = "BUILDCONTROLLER_DISALLOW_PLACING_FLAG";

		private bool _refreshWallEdgeEnabled;

		private static readonly float _accessPointSpotlightRange;

		private static AnimationCurve _accessPointSpotlightFadeCurve;

		internal Dictionary<string, GameObject> _buildablePrefabs;

		private bool _selectStartedInEditMode;

		private EntityObject _lastSelectedDecoration;

		private float _lastSelectedDecorationTime;

		private readonly Dictionary<string, BuildableTemplate> _templateDictionary;

		private static BuildableTemplate _currentCloneTemplate;

		public BaseBuilder CurrentBuilder => null;

		public int CurrentCost
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public BuildControllerState CurrentState
		{
			get
			{
				return default(BuildControllerState);
			}
			set
			{
			}
		}

		public bool IsBuilding => false;

		public bool IsEditing => false;

		public string SelectedBuildableId => null;

		public Buildable SelectedBuildable => null;

		public List<string> AvailableBuildCategories { get; private set; }

		public List<string> DefaultBuildCategories { get; }

		public event EventHandler<EventArgs> CurrentCostChangedEvent
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

		public event EventHandler<EventArgs> HasPendingChangesEvent
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

		public static event EventHandler LongClickPickupHappened
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

		public static event EventHandler StateChanged
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

		public static event EventHandler FullInnerWallsStateChanged
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

		public override void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnUIReset(object sender, EventArgs e)
		{
		}

		private void OnHasPendingChangesChanged(object sender, EventArgs e)
		{
		}

		public bool HasPendingChanges()
		{
			return false;
		}

		public void SpawnBuildParticles(Transform temp)
		{
		}

		private void OnResearchChanged(object sender, EventArgs e)
		{
		}

		private void OnStarRatingChanged(object sender, EventArgs<float> e)
		{
		}

		public void AttemptToEditObject(GameObject obj)
		{
		}

		private void OnLongLeftClickHappened(object sender, EventArgs e)
		{
		}

		public string GetCostTooltip()
		{
			return null;
		}

		public void SelectZone(string zoneName)
		{
		}

		public string GetSelectedZone()
		{
			return null;
		}

		public bool Confirm()
		{
			return false;
		}

		public IEnumerable<Tuple<string, int>> GetTileCountPerZoneChanging()
		{
			return null;
		}

		public void Cancel()
		{
		}

		public void Init()
		{
		}

		public void Refresh()
		{
		}

		public void SwitchState(BuildControllerState state)
		{
		}

		public string GetCurrentZone(int x, int y, int z)
		{
			return null;
		}

		public void SwitchSelectedBuildItem(string uniqueType, bool ignoreCostRestriction = false)
		{
		}

		public void SwitchToDecorationBuilder()
		{
		}

		public IEnumerable<Buildable> GetAllBuildables()
		{
			return null;
		}

		public void RefreshAvailableBuildCategories()
		{
		}

		private void FetchAllBuildables()
		{
		}

		private void StartEditingBuildable(Buildable selectedBuildable)
		{
		}

		private void UpdateDemolishBuildables()
		{
		}

		private IEnumerable<Buildable> GetSelectedBuildables(Buildable startBuildable)
		{
			return null;
		}

		private IEnumerable<Buildable> GetAttachedProps(IEnumerable<Wall> walls)
		{
			return null;
		}

		private IEnumerable<Wall> GetSelectableWalls(Wall wall, bool vertical)
		{
			return null;
		}

		private static Wall GetWallSeparatingZone(Vector3 position, string zone, int[] roomIds)
		{
			return null;
		}

		private void ClearCurrentBuildablesToDemolish()
		{
		}

		private void ClearCurrentHighlights()
		{
		}

		public bool CanBuild(string uniqueType, bool ignoreCostRestriction = false)
		{
			return false;
		}

		public bool CanAfford(string uniqueType)
		{
			return false;
		}

		public bool CanAfford(BuildableTemplate template)
		{
			return false;
		}

		public void EnableRefreshWallEdges(bool enable)
		{
		}

		public void RefreshWallEdges()
		{
		}

		public void ExitBuildMode()
		{
		}

		public void ExitEditMode()
		{
		}

		public Vector3 GetMouseCoords()
		{
			return default(Vector3);
		}

		private void ShowBuildHelpers(bool show)
		{
		}

		private void StartBuilding()
		{
		}

		public bool StopBuilding()
		{
			return false;
		}

		public bool Esc()
		{
			return false;
		}

		public void UpdateAccessPointSpotlight(Vector3 spotlightPosition, GameObjectX targetObject = null)
		{
		}

		public void SetAllAccessPointVisibility(float alphaPercentage)
		{
		}

		public GameObject GetPrefabForBuildableKey(string key)
		{
			return null;
		}

		public GameObject GetPrefabForBuildableTemplate(BuildableTemplate template, bool registerIfNew = true)
		{
			return null;
		}

		private GameObject CreatePrefabFromTemplate(BuildableTemplate template)
		{
			return null;
		}

		public IEnumerable<ContextMenuItem> GetDecorationContextMenu(EntityObject dp)
		{
			return null;
		}

		public bool IsPlacingDisabled()
		{
			return false;
		}

		private void RaiseFullInnerWallStateChanged(object sender, EventArgs e)
		{
		}

		public bool IsFullInnerWallsEnabled()
		{
			return false;
		}

		private void OnUnlocksStateChanged(object sender, EventArgs e)
		{
		}

		private void RegisterInputs()
		{
		}

		private EntityObject GetHitObjectEntityObject()
		{
			return null;
		}

		private void HandleSelectNoEntityObject()
		{
		}

		private void HandleSelectSingleEntityObject(EntityObject hitEntityObject)
		{
		}

		private void HandleSelectAdditionalEntityObject(EntityObject hitEntityObject)
		{
		}

		private void HandleSelectAllEntityObjects(EntityObject hitEntityObject)
		{
		}

		private void BuildableData_TemplateRemoved(object sender, EventArgs<BuildableTemplate> e)
		{
		}

		private void BuildableData_TemplateAdded(object sender, EventArgs<BuildableTemplate> e)
		{
		}

		internal void LoadPropTemplates()
		{
		}

		private string FetchDescription(string description)
		{
			return null;
		}

		private void RegisterVariantsFromPrefabs()
		{
		}

		public BuildableTemplate CreateCloneTemplate(GameObjectX gox)
		{
			return null;
		}

		public BuildableTemplate CreateCloneTemplate(EntityObject eo)
		{
			return null;
		}

		public IEnumerable<BuildableTemplate> GetAllBuildableTemplates()
		{
			return null;
		}

		public BuildableTemplate GetBuildableTemplateForUniqueKey(string uniqueKey)
		{
			return null;
		}

		private BuildableTemplate CreateTemplateFromBuildable(Buildable buildable)
		{
			return null;
		}

		public void RegisterTemplate(BuildableTemplate obj, bool supressGroupCheck = false)
		{
		}

		private void EnsureVariantGrouping(BuildableTemplate template)
		{
		}

		private void CycleVariant(int direction)
		{
		}

		public void CycleVariant(string currentPrefabId, int direction)
		{
		}
	}
}
