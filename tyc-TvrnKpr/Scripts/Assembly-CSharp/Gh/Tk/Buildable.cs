using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LitJson;
using Pathfinding;
using UnityEngine;

namespace Gh.Tk
{
	public class Buildable : AttachedBehaviour
	{
		private class SnappingInformation
		{
			public Vector3 position;

			public Quaternion rotation;

			public Snapping sourceSnappingPoint;

			public Snapping targetSnappingPoint;

			public bool isValid;

			public bool IsPreferred()
			{
				return false;
			}
		}

		[HideInInspector]
		public int BuildCost;

		public int BuildLimit;

		[HideInInspector]
		public string[] BuildCategories;

		[HideInInspector]
		public string[] BuildSubCategories;

		[HideInInspector]
		public bool IsRotationDisabled;

		[PersistenceOptIn]
		private string _sourceTemplateUniqueKey;

		[JsonIgnore]
		private BuildableTemplate _sourceTemplate;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _effectiveBuildCost;

		[Header("Access Point Options")]
		public bool staffRequired;

		public bool patronRequired;

		[Header("Buildable where")]
		public bool outDoor;

		public bool inDoor;

		public bool SnappingRequired;

		private List<Snapping> _ownSnappingPoints;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		[PersistenceAllowBrokenReferenceOnLoad]
		private Snapping _snappedTo;

		private Quaternion _lastUnsnappedRotation;

		private List<bool> _particleSystemStates;

		private List<bool> _lightStates;

		private List<bool> _objectAmbienceStates;

		private readonly List<Action> _postBuiltActions;

		private List<Collider> _obstacleModifiedColliders;

		private List<NavmeshCut> _modifiedNavmeshCuts;

		private List<GraphUpdateSceneX> _modifiedGraphUpdateScenes;

		private Dictionary<Snapping, List<SnappingInformation>> _possibleSnappedPositions;

		private float _searchRadiusForSnappingPoints;

		private Transform _ourTransform;

		private readonly List<SnappingInformation> _snappingInformationsBuffer;

		private readonly List<Snapping> _snappingsToDelete;

		private Vector3 _lastCoordinates;

		private bool _shiftPressed;

		private bool _shiftPressedChanged;

		protected bool _isDemolished;

		private CollisionDetector[] _collisionDetectors;

		private Collider[] _collidersToReset;

		private AccessPoint[] _accessPoints;

		private bool _buildValid;

		private bool _firstCheck;

		private Snapping _cachedSnapping;

		private HashSet<Snapping> _availableSnappings;

		[JsonIgnore]
		internal BuildableTemplate SourceTemplate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int EffectiveBuildCost
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsBuilt { get; set; }

		[PersistenceOptIn]
		public float BuiltAtDayF { get; private set; }

		public bool IsEditing { get; set; }

		private float SnappingThreshold => 0f;

		public bool IsDemolished => false;

		public static event EventHandler<EventArgs<Buildable>> BuiltEvent
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

		public static event EventHandler<EventArgs<Buildable>> DemolishedEvent
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

		public static event EventHandler<EventArgs<Buildable>> EditedEvent
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

		public event EventHandler PostBuiltEvent
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

		public event EventHandler PositionChangedEvent
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

		public event EventHandler EditModeEnteredEvent
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

		public event EventHandler EditModeExitedEvent
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

		public event EventHandler<EventArgs<bool>> ShowHelperVisualsEvent
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

		public static event EventHandler BuildableRotated
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

		public event EventHandler Demolished
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

		public string GetNonVariantBuildableUniqueKey()
		{
			return null;
		}

		public string GetBuildableUniqueKey()
		{
			return null;
		}

		public GameObjectX GetSnappedTo()
		{
			return null;
		}

		public void CopyRotation(Buildable buildable)
		{
		}

		public void Init(bool isLoading = false)
		{
		}

		public void PreBuilt()
		{
		}

		public void PostBuilt()
		{
		}

		private void HandleFreeProps()
		{
		}

		public void Rebuild()
		{
		}

		public void Rotate(float rotateDegree = 45f)
		{
		}

		public void SetAsObstacle(bool obstacle)
		{
		}

		public void UpdateObstacles()
		{
		}

		public void FetchAvailableSnappingPoints()
		{
		}

		private void CheckAdditionalSnappingPoints(Vector3 position)
		{
		}

		private void UpdateCollisionsSilently()
		{
		}

		private SnappingInformation GetSnappingInformation(Snapping sourceSnappingPoint, Snapping targetSnappingPoint)
		{
			return null;
		}

		public void SetPosition(Vector3 coordinates, int step = 4, bool ignoreShiftPressed = false)
		{
		}

		public void RefreshAllCollisions()
		{
		}

		private void SnappedToBuildable_Demolished(object sender, EventArgs e)
		{
		}

		public int GetRefundValue()
		{
			return 0;
		}

		public virtual void Demolish(bool withRefund = true)
		{
		}

		public void SetSnappingDemolishListener(bool enable)
		{
		}

		public override void UpdateObject()
		{
		}

		protected override void UpdateInternal()
		{
		}

		private bool CheckAccessPoints()
		{
			return false;
		}

		private bool IsColliding()
		{
			return false;
		}

		public virtual bool IsBuildValid(bool ignoreCost = false)
		{
			return false;
		}

		protected bool IsLocationValid()
		{
			return false;
		}

		public bool CanMoveBuildable(out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		public bool CanSellBuildable(out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		public bool CanEditBuildable(out string reasonKey)
		{
			reasonKey = null;
			return false;
		}

		protected void RefreshColor()
		{
		}

		public virtual void EnterEditMode(bool ignoreSnapping = false)
		{
		}

		public void RefreshCollisionDetectors()
		{
		}

		public virtual void ExitEditMode()
		{
		}

		public void CacheRequiredSnapping()
		{
		}

		public void RestoreCachedSnapping()
		{
		}

		public void ShowHelperVisuals(bool show)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public bool TryDemolish(bool withRefund = true)
		{
			return false;
		}
	}
}
