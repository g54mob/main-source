using System.Collections.Generic;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.Operator;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/PlaceAreaTool", fileName = "PlaceAreaTool", order = 0)]
	public class PlaceAreaTool : FactoryTool
	{
		[Header("PlaceArea refs")]
		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private BluePrintEvent _startPreviewEvent;

		[SerializeField]
		private BluePrintEvent _updatePreviewEvent;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private CurrentFactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		protected CommandManager _commandManager;

		[SerializeField]
		protected CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		protected IntListEvent _factoryObjectsRemoveViewsEvent;

		private Blueprint _selectedBlueprint;

		private BlueprintViewDto _blueprintViewDto;

		private FactoryObjectData _objectData;

		private bool _dragStarted;

		private Vector3Int _startPosition;

		public override bool CanAutoSwapAwayFrom => false;

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_dragStarted = false;
			_objectData = blueprint.Elements[0].ObjectData;
			_selectedBlueprint = blueprint;
			_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, blueprint.Position);
			bool canBePlaced = BlueprintPlacementValidator.CanBePlaced(_selectedBlueprint.Position, _selectedBlueprint, _factoryLayer.Value, _terrainLayer);
			_startPreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, canBePlaced));
		}

		private void UpdatePreview(Vector3Int position)
		{
			bool canBePlaced = BlueprintPlacementValidator.CanBePlaced(position, _selectedBlueprint, _factoryLayer.Value, _terrainLayer);
			_blueprintViewDto.Position = _gridLocator.GetWorldPosition(position);
			_updatePreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, canBePlaced));
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (!_dragStarted)
			{
				UpdatePreview(gridPos);
				return;
			}
			_selectedBlueprint.SetElements(PlaceBlueprintElementsBetween(_startPosition, gridPos));
			_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
			UpdatePreview(_startPosition);
		}

		public List<BlueprintElement> PlaceBlueprintElementsBetween(Vector3Int startPosition, Vector3Int endPosition)
		{
			List<BlueprintElement> list = new List<BlueprintElement>();
			Vector3Int vector3Int = endPosition - startPosition;
			int num = Mathf.Min(vector3Int.x, 0);
			int num2 = Mathf.Max(vector3Int.x, 0);
			int num3 = Mathf.Min(vector3Int.z, 0);
			int num4 = Mathf.Max(vector3Int.z, 0);
			Vector3Int relativeBounds = _objectData.GetRelativeBounds();
			for (int i = num; i <= num2; i += relativeBounds.x)
			{
				for (int j = num3; j <= num4; j += relativeBounds.z)
				{
					list.Add(new BlueprintElement(GetNewPosition(new Vector3Int(i, 0, j)), _objectData, 0, mirrored: false));
				}
			}
			return list;
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
			_dragStarted = true;
			_startPosition = gridPos;
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			_commandManager.DoCommand(new PlaceBlueprintCommand(_factoryLayer.Value, _terrainLayer, _startPosition, _selectedBlueprint.Rotation, _selectedBlueprint, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator));
			StopPreviewing();
			SelectTool(new Blueprint(gridPos, 0, new List<BlueprintElement>
			{
				new BlueprintElement(GetNewPosition(Vector3Int.zero), _objectData, 0, mirrored: false)
			}));
		}

		private List<Vector3Int> GetNewPosition(Vector3Int position)
		{
			List<Vector3Int> relativePositions = _objectData.RelativePositions;
			List<Vector3Int> list = new List<Vector3Int>(relativePositions.Count);
			foreach (Vector3Int item in relativePositions)
			{
				list.Add(item + position);
			}
			return list;
		}

		public override void CancelAction()
		{
			StopPreviewing();
		}

		public override void DeSelectTool()
		{
			StopPreviewing();
		}

		private void StopPreviewing()
		{
			_stopPreviewEvent.Fire();
			_dragStarted = false;
		}
	}
}
