using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class DragBuilder : BaseBuilder
	{
		private GameObject _currentAnchorHelper;

		private GridController _gridController;

		private bool _isDragging;

		private GameObject _startAnchor;

		private int _startX;

		private int _startZ;

		private int _endDragX;

		private int _endDragZ;

		private List<Tuple<Vector3, GameObject>> _wallHelpers;

		private Dictionary<Vector3Int, GameObject> _wallPosts;

		private bool _isValid;

		private bool? _preferHorizontal;

		private GameObject _tempParent;

		private bool _wallEdgeRefreshNeeded;

		private RoomController _roomController;

		private bool _hidingUI;

		private Dictionary<(int, int), GameObject> _currentWallPosts;

		public Color wallOutlineColour;

		private List<GameObject> _helperOutlines;

		public void Init()
		{
		}

		public override void EnterBuildMode(Vector3 coords)
		{
		}

		private void CreateNewAnchorHelper(Vector3 coords)
		{
		}

		private void CheckCollisions()
		{
		}

		public override void Refresh()
		{
		}

		public void RefreshWallEdges()
		{
		}

		private GameObject InstantiateWallPost(int x, int y)
		{
			return null;
		}

		private void ResetToStart()
		{
		}

		private void UpdateAnchor()
		{
		}

		private void AddWallPost(Vector3Int position)
		{
		}

		private bool IsInsideAnUnlockedRoom(int x, int y, int z)
		{
			return false;
		}

		public GameObject InstantiateWallHelperPrefab(Vector3Int wallPosition, bool isVertical, Vector3 targetPosition)
		{
			return null;
		}

		public void AddZoningWallHighlight(GameObject wallPartObj)
		{
		}

		private void AddLeftWall(Vector3Int position)
		{
		}

		private void AddSouthWall(Vector3Int position)
		{
		}

		public void ClearWallHelpers()
		{
		}

		private void Build()
		{
		}

		public override void ExitBuildMode(bool switchInputMode = true)
		{
		}

		public override bool Esc()
		{
			return false;
		}
	}
}
