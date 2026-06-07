using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Shapes;
using UnityEngine;

namespace Gh.Tk
{
	public class ZoneBuilder : BaseBuilder
	{
		private class ZoneChange
		{
			public Vector3Int Position { get; set; }

			public RoomZone PreviousZone { get; set; }

			public RoomZone CurrentZone { get; set; }
		}

		private struct RefundDetail
		{
			public int Refund;

			public int Count;
		}

		private class ZoneTileData
		{
			private readonly Dictionary<RoomZone, GameObject> _visuals;

			private readonly Dictionary<RoomZone, Color> _originalColors;

			private bool _useZoneColor;

			public TileData TileData { get; }

			public RoomZone Zone { get; set; }

			public bool UseZoneColor
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public ZoneTileData(TileData tileData)
			{
			}

			public void SetZone(RoomZone zone, bool useZoneColor = false)
			{
			}

			public void Clean()
			{
			}
		}

		private GameController _gc;

		private static GameObject _parentForVisuals;

		private static GameObject _parentForCurrentDraggingArea;

		private Vector3Int _startPosition;

		private Vector3Int _endPosition;

		private Vector3 _currentCoords;

		private Vector3 _lastCoords;

		private Dictionary<int, ZoneTileData> _completeUnconfirmedChanges;

		private readonly Dictionary<int, ZoneChange> _zoneChanges;

		private readonly Dictionary<int, ZoneChange> _currentZoneChanges;

		private readonly Dictionary<string, int> _unconfirmedZoneDiff;

		private static int _minX;

		private static int _minY;

		private bool _isZoning;

		private DragBuilder _dragBuilder;

		private GameObject _zoningTileVisual;

		private GameObject _lastUsedZoningTileVisual;

		private RoomZone _lastUsedSelectedZone;

		private GameObject _currentZoningTileFloorVisual;

		private Rectangle _rectangle;

		private FloatingSolidText _rectangleText;

		private Vector3 _lastMouseCoords;

		private bool _inForcedDragging;

		public static EventHandler<EventArgs> UnConfirmedZoneDifferencesChanged;

		private ILookup<Vector3Int, Wall> _currentWalls;

		private readonly Dictionary<Vector3Int, Tuple<GameObject, bool>> _horizontalWallPreviewObjects;

		private readonly Dictionary<Vector3Int, Tuple<GameObject, bool>> _verticalWallPreviewObjects;

		private readonly Dictionary<Vector3Int, GameObject> _wallPostPreviewObjects;

		private readonly Dictionary<bool, Dictionary<Vector3Int, bool>> _neededWallPreview;

		private readonly HashSet<Buildable> _currentBuildablesToDemolish;

		private readonly HashSet<Wall> _currentWallsToDemolish;

		private bool _hasPendingChanges;

		public RoomZone SelectedZone { get; private set; }

		public bool HasPendingChanges
		{
			get
			{
				return false;
			}
			private set
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

		public void Start()
		{
		}

		private void UpdateZoningTileVisual()
		{
		}

		public int GetUnconfirmedZoneDifference(string zoneId)
		{
			return 0;
		}

		public override void Refresh()
		{
		}

		private Vector3 CalculateCurrentCoords(Vector3 coords)
		{
			return default(Vector3);
		}

		private void ShowZoningTile()
		{
		}

		private void HideZoningTile()
		{
		}

		private void StartZoning()
		{
		}

		public void SelectZone(string zoneName)
		{
		}

		private ZoneTileData GetActualZoneData(Vector3Int position, bool ignoreCurrentChanges = false)
		{
			return null;
		}

		private ZoneTileData GetActualZoneData(int position, bool ignoreCurrentChanges = false)
		{
			return null;
		}

		public string GetCurrentZone(int coordX, int coordY, int coordZ)
		{
			return null;
		}

		public IEnumerable<Tuple<string, int>> GetTileCountPerZoneChanging()
		{
			return null;
		}

		private bool AnyPropsCannotBeDemolished()
		{
			return false;
		}

		public bool Confirm()
		{
			return false;
		}

		private void ResetUnconfirmedZoneDifference()
		{
		}

		private void UpdateWallTrims(IEnumerable<ZoneTileData> changes)
		{
		}

		private void GenerateWalls()
		{
		}

		private void UpdateChangedData(bool forceUpdate = false)
		{
		}

		private void UpdateChangePreview(IEnumerable<ZoneChange> changes)
		{
		}

		private Dictionary<string, RefundDetail> GetRefundDetails()
		{
			return null;
		}

		private Dictionary<string, int> GetZoneCostDetails()
		{
			return null;
		}

		public string GetCostTooltip()
		{
			return null;
		}

		private void UpdateWallsToDemolish(IEnumerable<ZoneChange> changes)
		{
		}

		private void UpdateWallPostPreviews()
		{
		}

		private void UpdateWallPreview()
		{
		}

		private void CheckWall(RoomZone zone, ZoneTileData neighbourTile, Vector3Int position, bool horizontal)
		{
		}

		private void AddWall(Vector3Int position, bool horizontal, bool needsInstantiationAfterPreview)
		{
		}

		private void RemoveWallPost(Vector3Int position)
		{
		}

		private void UpdateCollidingObjects()
		{
		}

		private static int GetPositionHash(Vector3Int position)
		{
			return 0;
		}

		private IEnumerable<ZoneChange> UpdateAreaInsideCurrentSelection()
		{
			return null;
		}

		private void AddUnconfirmedZoneDifference(ZoneChange zoneChange)
		{
		}

		private void RemoveUnconfirmedZoneDifference(ZoneChange zoneChange)
		{
		}

		private List<ZoneChange> UpdateAreaOutsideCurrentSelection()
		{
			return null;
		}

		private void StartZoning(Vector3 coords)
		{
		}

		public override void EnterBuildMode(Vector3 coords)
		{
		}

		private static void HideCurrentDraggingArea()
		{
		}

		private static void ShowCurrentDraggingArea()
		{
		}

		private void FetchCurrentWalls()
		{
		}

		public override void ExitBuildMode(bool switchInputMode = true)
		{
		}

		private void RemoveVisuals()
		{
		}

		public override bool Esc()
		{
			return false;
		}

		public void Cancel()
		{
		}

		private void RefreshGrid()
		{
		}
	}
}
