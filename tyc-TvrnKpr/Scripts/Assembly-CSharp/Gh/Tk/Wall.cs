using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class Wall : GameObjectX
	{
		public static HashSet<Wall> AllWalls;

		private float _x;

		private float _y;

		private float _z;

		[PersistenceOptIn]
		private int _floorX;

		[PersistenceOptIn]
		private int _floorY;

		[PersistenceOptIn]
		private int _floorZ;

		private string _zone1;

		private string _zone2;

		public MeshCollider DecorationCollider;

		private Transform _trim1;

		private Transform _trim2;

		[PersistenceOptIn]
		public Vector3 Position;

		[PersistenceOptIn]
		public Quaternion Rotation;

		[PersistenceOptIn]
		public bool Vertical;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsOuterWall;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsActive;

		public Snapping[] LeftSnappings;

		public Snapping[] RightSnappings;

		public GameObject shadow;

		private Transform WallTransform;

		private int? _index;

		private static readonly Vector3Int BuildMenuWallPosition;

		private List<Action> _revertVisualActions;

		private TileData[] _separatedTiles;

		private List<TileData> _currentTiles;

		private Bounds _visualLowTotalBounds;

		public Vector3Int FloorPosition => default(Vector3Int);

		public Transform VisualLow { get; private set; }

		public Transform VisualFull { get; private set; }

		public override List<TileData> CurrentTiles => null;

		public static event EventHandler<EventArgs<Wall>> WallChanged
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

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private Wall()
		{
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		private void UpdateSnappingPoints()
		{
		}

		public override void OnDestroy()
		{
		}

		public override void Init()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public void SetActive(bool active)
		{
		}

		private void InstantiateVisual()
		{
		}

		private void UpdateVisualForInnerWalls()
		{
		}

		public void UpdateVisualsForInnerWalls(bool fullWalls)
		{
		}

		public int GetIndex()
		{
			return 0;
		}

		public static int CalculateIndex(Vector3Int position, bool isVertical)
		{
			return 0;
		}

		public void RefreshTrim(bool forceRefresh = false)
		{
		}

		public List<Vector3Int> GetSeperatedTilePositions()
		{
			return null;
		}

		public void UpdateSeparatedTiles()
		{
		}

		public TileData[] GetSeparatedTiles()
		{
			return null;
		}

		public IEnumerable<Buildable> GetAttachedProps()
		{
			return null;
		}

		public void RevertVisual()
		{
		}

		public void ApplyColor(Color color)
		{
		}

		protected override void UpdateInternal()
		{
		}

		public override void CatchFire(float startTemperature = 0.1f, Transform targetTransform = null)
		{
		}

		public Bounds GetVisualLowTotalBounds()
		{
			return default(Bounds);
		}

		public void UpdateVisualLowTotalBounds()
		{
		}
	}
}
