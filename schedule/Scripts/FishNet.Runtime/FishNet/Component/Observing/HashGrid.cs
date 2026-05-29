using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Managing;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Component.Observing
{
	public class HashGrid : MonoBehaviour
	{
		public enum GridAxes : byte
		{
			XY = 0,
			YZ = 1,
			XZ = 2
		}

		internal static Vector2Int UnsetGridPosition;

		internal static GridEntry EmptyGridEntry;

		[Tooltip("Axes of world space to base the grid on.")]
		[SerializeField]
		private GridAxes _gridAxes;

		[SerializeField]
		[Tooltip("Accuracy of the grid. Objects will be considered nearby if they are within this number of units. Lower values may be more expensive.")]
		[Range(1f, 65535f)]
		private ushort _accuracy;

		private int _halfAccuracy;

		private Stack<HashSet<GridEntry>> _gridEntryHashSetCache;

		private Stack<GridEntry> _gridEntryCache;

		private Dictionary<Vector2Int, GridEntry> _gridEntries;

		private NetworkManager _networkManager;

		private void Awake()
		{
		}

		private void OutputNewGridCollections(out GridEntry gridEntry, out HashSet<GridEntry> gridEntries)
		{
			gridEntry = null;
			gridEntries = null;
		}

		private GridEntry CreateGridEntry(Vector2Int position)
		{
			return null;
		}

		internal void GetNearbyHashGridPositions(NetworkObject nob, ref HashSet<Vector2Int> collection)
		{
		}

		internal Vector2Int GetHashGridPosition(NetworkObject nob)
		{
			return default(Vector2Int);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal GridEntry GetGridEntry(NetworkObject nob)
		{
			return null;
		}

		internal GridEntry GetGridEntry(Vector2Int position)
		{
			return null;
		}
	}
}
