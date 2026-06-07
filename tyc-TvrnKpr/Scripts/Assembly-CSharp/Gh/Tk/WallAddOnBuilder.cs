using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class WallAddOnBuilder : BaseBuilder
	{
		private struct SnappingPosition
		{
			public Vector2 coord;

			public string orientation;

			public List<Wall> affectedWalls;
		}

		[SerializeField]
		private GameObject _propSpawnParticles;

		private WallAddOn _currentWallAddOn;

		private GridController _gridController;

		private List<Wall> _wallsToRemove;

		private float snappingThreshold;

		private SnappingPosition _lastNearestSnappingPosition;

		private List<SnappingPosition> _validSnappingPositions;

		private bool _snapped;

		private RoomController _roomController;

		private Vector3 _startingRotation;

		private bool _inverted;

		private List<Wall> _originalWallsToRemove;

		private bool _correctRotation;

		public override bool IsBuilding => false;

		public void Start()
		{
		}

		public override void EnterBuildMode(Vector3 coords)
		{
		}

		private void CreateNewWallAddOn(Vector3 coords)
		{
		}

		private void RefreshValidSnappingPositions()
		{
		}

		public override void Refresh()
		{
		}

		private void Rotate()
		{
		}

		private void RotatePreview()
		{
		}

		private void UpdateWallAddOn()
		{
		}

		private void ClearWallsToRemove()
		{
		}

		private void AddWallToRemove(Wall wall)
		{
		}

		private void Build()
		{
		}

		public override void ExitBuildMode(bool switchInputMode = true)
		{
		}

		public override void EnterEditMode(Buildable selectedBuildable)
		{
		}

		public override void ExitEditMode(bool resetPosition = false)
		{
		}

		public override bool Esc()
		{
			return false;
		}
	}
}
