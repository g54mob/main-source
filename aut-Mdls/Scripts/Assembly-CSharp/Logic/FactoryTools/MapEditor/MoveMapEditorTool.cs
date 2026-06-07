#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using Data.FactoryFloor.Islands;
using Data.FactoryFloor.Maps;
using Data.Variables;
using Events;
using Events.FactoryFloor.Islands;
using Events.Generic;
using Logic.FactoryTools.IslandEditor;
using Presentation.FactoryFloor.Islands;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Logic.FactoryTools.MapEditor
{
	[CreateAssetMenu(menuName = "Factory/Tools/Map/MoveMapEditorTool", fileName = "MoveMapEditorTool", order = 0)]
	public class MoveMapEditorTool : MapEditorTool
	{
		[Header("Placement refs")]
		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private IslandDatabase _islandsDatabase;

		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private UpdateIslandEvent _updateIslandEvent;

		[SerializeField]
		private IntEvent _deleteIslandEvent;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private BaseEvent _generateGrass;

		[SerializeField]
		private IslandObjectEvent _createIslandObjectEvent;

		[SerializeField]
		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		private Vector3Int _originPosition;

		private Vector3Int _position;

		private int _selectedCreatedID;

		private Guid _selectedGuid;

		private int _rotation;

		private bool _mirrored;

		private Vector2Int _islandActualSize;

		private Vector2Int _gridCellSize;

		private Vector2Int _sizeScaledWithGrid;

		private bool _islandSelected;

		private IslandConfig _islandConfig;

		public override void SelectTool(EmptyIslandEditorData emptyIslandEditorData = null)
		{
			base.SelectTool(emptyIslandEditorData);
			_gridCellSize = new Vector2Int((int)_gridMapLocator.GetCellSize().x, (int)_gridMapLocator.GetCellSize().z);
			_position = _gridMapLocator.GetCellPosition(_mouseToGridInput.GetSelectedMapPosition());
			_rotation = 0;
			_mirrored = false;
			_islandSelected = false;
		}

		private Vector3 GetWorldPosition()
		{
			if (_sizeScaledWithGrid.x % 2 == 0)
			{
				return _gridMapLocator.GetWorldPosition(_position) - _gridMapLocator.GetCellSize() / 2f;
			}
			return _gridMapLocator.GetWorldPosition(_position);
		}

		public override void UpdateTool(Vector3Int position)
		{
			if (_islandSelected)
			{
				_position = position;
				_updateIslandEvent.Fire(new UpdateIslandDto
				{
					CreatedId = _selectedCreatedID,
					Position = GetWorldPosition(),
					Rotation = _rotation,
					Mirrored = _mirrored
				});
				_mirrored = false;
			}
		}

		public override void OnActionIntent(Vector3Int position)
		{
		}

		private void TrySelectIsland(Vector3Int position)
		{
			IslandObject islandAtGridPosition = _islandLayer.GetIslandAtGridPosition(position);
			if (islandAtGridPosition != null)
			{
				_selectedCreatedID = islandAtGridPosition.CreatedId;
				_originPosition = islandAtGridPosition.Positions[0];
				_rotation = islandAtGridPosition.Rotation;
				_selectedGuid = islandAtGridPosition.Guid;
				IslandData islandDataById = _islandsDatabase.GetIslandDataById(_selectedGuid);
				_islandActualSize = islandDataById.Size + new Vector2Int(16, 16);
				_sizeScaledWithGrid = new Vector2Int(_islandActualSize.x / _gridCellSize.x, _islandActualSize.y / _gridCellSize.y);
				_islandConfig = islandAtGridPosition.IslandConfig;
				_islandLayer.RemoveIslandAtGridPosition(position);
				_islandSelected = true;
			}
		}

		public override void Rotate(int rotation)
		{
			_rotation += rotation;
			_rotation = ClampAngle(_rotation);
		}

		public override void Mirror()
		{
		}

		public int ClampAngle(int angle)
		{
			angle %= 360;
			if (angle < 0)
			{
				angle += 360;
			}
			return angle;
		}

		public override void DoAction(Vector3Int position)
		{
			if (!_islandSelected)
			{
				TrySelectIsland(position);
				return;
			}
			_deleteIslandEvent.Fire(_selectedCreatedID);
			List<Vector3Int> occupiedGridPositions = GetOccupiedGridPositions(position);
			if (_islandLayer.CanPlaceIsland(occupiedGridPositions))
			{
				_islandConfig.Rotation = _rotation;
				_islandConfig.SetPosition(GetWorldPosition());
				IslandObject islandObject = new IslandObject(_islandConfig, occupiedGridPositions, _maxZoomLevelModifier);
				_islandLayer.AddIsland(islandObject);
				_createIslandObjectEvent.Fire(islandObject);
			}
			else
			{
				ReturnToOriginPosition();
			}
			_generateGrass.Fire();
			_islandSelected = false;
		}

		private void ReturnToOriginPosition()
		{
			List<Vector3Int> occupiedGridPositions = GetOccupiedGridPositions(_originPosition);
			if (_islandLayer.CanPlaceIsland(occupiedGridPositions))
			{
				IslandObject islandObject = new IslandObject(_islandConfig, occupiedGridPositions, _maxZoomLevelModifier);
				_islandLayer.AddIsland(islandObject);
				_createIslandObjectEvent.Fire(islandObject);
			}
			else
			{
				this.LogError("Failed", "ReturnToOriginPosition", 165);
			}
		}

		private List<Vector3Int> GetOccupiedGridPositions(Vector3Int position)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			int num = -(_sizeScaledWithGrid.x / 2);
			int num2 = -(_sizeScaledWithGrid.y / 2);
			list.Add(position);
			for (int i = 0; i < _sizeScaledWithGrid.x; i++)
			{
				for (int j = 0; j < _sizeScaledWithGrid.y; j++)
				{
					Vector3Int vector3Int = new Vector3Int(position.x + num + i, position.y, position.z + num2 + j);
					if (!(vector3Int == position))
					{
						list.Add(vector3Int);
					}
				}
			}
			return list;
		}

		public override void CancelAction()
		{
			if (_islandSelected)
			{
				_deleteIslandEvent.Fire(_selectedCreatedID);
				ReturnToOriginPosition();
			}
			_islandSelected = false;
		}
	}
}
