using System;
using System.Collections.Generic;
using Commands;
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
	[CreateAssetMenu(menuName = "Factory/Tools/Map/PlaceIslandMapTool", fileName = "PlaceIslandMapTool", order = 0)]
	public class PlaceIslandMapTool : MapEditorTool
	{
		[Header("Placement refs")]
		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private IslandDatabase _islandsDatabase;

		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private IslandConfigEvent _startIslandObjectPreviewEvent;

		[SerializeField]
		private IslandConfigEvent _updateIslandObjectPreviewEvent;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		[SerializeField]
		private IntEvent _deleteIslandEvent;

		[SerializeField]
		private IslandObjectEvent _createIslandObjectEvent;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private BaseEvent _generateGrass;

		[SerializeField]
		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		private Guid _id;

		private IslandData _islandData;

		private Vector3Int _position;

		private int _rotation;

		private Vector2Int _islandActualSize;

		private Vector2Int _gridCellSize;

		private Vector2Int _sizeScaledWithGrid;

		private IslandConfig _islandConfig;

		public override void SelectTool(EmptyIslandEditorData emptyIslandEditorData = null)
		{
			base.SelectTool(emptyIslandEditorData);
			if (emptyIslandEditorData is PlaceMapEditorData placeMapEditorData)
			{
				_id = placeMapEditorData.Id;
				_islandData = _islandsDatabase.GetIslandDataById(_id);
				_islandActualSize = _islandData.Size + new Vector2Int(16, 16);
				_gridCellSize = new Vector2Int((int)_gridMapLocator.GetCellSize().x, (int)_gridMapLocator.GetCellSize().z);
				_sizeScaledWithGrid = new Vector2Int(_islandActualSize.x / _gridCellSize.x, _islandActualSize.y / _gridCellSize.y);
			}
			_position = _gridMapLocator.GetCellPosition(_mouseToGridInput.GetSelectedMapPosition());
			_rotation = 0;
			_islandConfig = new IslandConfig(_islandData, IntIdGenerator.GetNewId, GetWorldPosition(), _islandData.Size, _islandActualSize, _rotation, default(IslandConfig.IslandBottomPrefabConfig), isGnnGateIsland: false);
			_startIslandObjectPreviewEvent.Fire(_islandConfig);
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
			_position = position;
			_islandConfig.SetPosition(GetWorldPosition());
			_islandConfig.Rotation = _rotation;
			_updateIslandObjectPreviewEvent.Fire(_islandConfig);
		}

		public override void OnActionIntent(Vector3Int position)
		{
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
			List<Vector3Int> occupiedGridPositions = GetOccupiedGridPositions(position);
			if (_islandLayer.CanPlaceIsland(occupiedGridPositions))
			{
				IslandObject islandObject = new IslandObject(_islandConfig, occupiedGridPositions, _maxZoomLevelModifier);
				_islandLayer.AddIsland(islandObject);
				_createIslandObjectEvent.Fire(islandObject);
			}
			_stopPreviewEvent.Fire();
			SelectTool(new PlaceMapEditorData
			{
				Id = _id
			});
			_generateGrass.Fire();
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
			_stopPreviewEvent.Fire();
		}
	}
}
