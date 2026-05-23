using System.Collections.Generic;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/PlaceSkylineTool", fileName = "PlaceSkylineTool", order = 0)]
	public class PlaceSkylineTool : FactoryTool
	{
		[Header("Skylines")]
		[SerializeField]
		private FactoryObjectData _skylineInData;

		[SerializeField]
		private FactoryObjectData _skylineOutData;

		[SerializeField]
		private IslandLayer _islandLayer;

		[Space]
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

		[SerializeField]
		private IntVariableSO _skylineLength;

		private Blueprint _selectedBlueprint;

		private Blueprint _onlyInBlueprint;

		private BlueprintViewDto _blueprintViewDto;

		private BlueprintViewDto _onlyInBlueprintViewDto;

		private BlueprintViewDto _currentViewDto;

		private bool _showingInAndOut;

		private bool _previewStarted;

		public override bool CanAutoSwapAwayFrom => false;

		public override string BreadcrumbId => _skylineInData.BreadcrumbId;

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			BlueprintElement item = new BlueprintElement(_skylineInData.RelativePositions, _skylineInData, 0, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int>
			{
				new Vector3Int(0, 0, _skylineLength.Value)
			});
			BlueprintElement item2 = new BlueprintElement(GetOffsetRelativePositions(_skylineOutData, new Vector3Int(0, 0, _skylineLength.Value)), _skylineOutData, 0, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int>
			{
				new Vector3Int(0, 0, -_skylineLength.Value)
			});
			List<BlueprintElement> blueprintElements = new List<BlueprintElement> { item, item2 };
			BlueprintElement item3 = new BlueprintElement(_skylineInData.RelativePositions, _skylineInData, 0, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int>
			{
				new Vector3Int(0, 0, _skylineLength.Value)
			});
			List<BlueprintElement> blueprintElements2 = new List<BlueprintElement> { item3 };
			_selectedBlueprint = new Blueprint(new Vector3Int(0, 0, 0), 0, blueprintElements);
			_onlyInBlueprint = new Blueprint(new Vector3Int(0, 0, 0), 0, blueprintElements2);
			_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
			_onlyInBlueprintViewDto = BlueprintViewDto.Create(_onlyInBlueprint, _gridLocator, _onlyInBlueprint.Position);
			_currentViewDto = _onlyInBlueprintViewDto;
			_showingInAndOut = false;
		}

		private List<Vector3Int> GetOffsetRelativePositions(FactoryObjectData data, Vector3Int offset)
		{
			List<Vector3Int> relativePositions = data.RelativePositions;
			List<Vector3Int> list = new List<Vector3Int>(relativePositions.Count);
			foreach (Vector3Int item in relativePositions)
			{
				list.Add(item + offset);
			}
			return list;
		}

		private void UpdatePreview(Vector3Int position)
		{
			_setCursorTextEvent.Fire(string.Empty);
			_failReasonEvent.Register(base.HandleFailReasonEvent);
			bool flag = BlueprintPlacementValidator.CanBePlaced(position, _selectedBlueprint, _factoryLayer.Value, _terrainLayer);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			ShowFailReasons();
			_currentViewDto = (flag ? _blueprintViewDto : _onlyInBlueprintViewDto);
			if (!_previewStarted)
			{
				_startPreviewEvent.Fire(new BlueprintViewEventDto(_onlyInBlueprintViewDto, flag));
				_previewStarted = true;
			}
			else if (flag != _showingInAndOut)
			{
				_stopPreviewEvent.Fire();
				_startPreviewEvent.Fire(new BlueprintViewEventDto(_currentViewDto, flag));
				_showingInAndOut = flag;
			}
			_currentViewDto.Position = _gridLocator.GetWorldPosition(position);
			_updatePreviewEvent.Fire(new BlueprintViewEventDto(_currentViewDto, flag));
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_islandLayer.TryGetIslandAtWorldPosition(gridPos, out var islandObject))
			{
				SnapGridPositionToIsland(islandObject, ref gridPos);
				Vector3 vector = islandObject.IslandConfig.Position - mousePos;
				int num = ((!(Mathf.Abs(vector.x) > Mathf.Abs(vector.z))) ? ((vector.z > 0f) ? 180 : 0) : ((vector.x > 0f) ? 270 : 90));
				int num2 = num - _selectedBlueprint.Rotation;
				if (num2 != 0)
				{
					_selectedBlueprint.Rotate(num2);
					_onlyInBlueprint.Rotate(num2);
					_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
					_onlyInBlueprintViewDto = BlueprintViewDto.Create(_onlyInBlueprint, _gridLocator, _onlyInBlueprint.Position);
					_audioManagerLocator.AudioManager.PlayRotateObject(gridPos, _skylineInData.ObjectSize);
				}
			}
			_selectedBlueprint.SetPosition(gridPos);
			_onlyInBlueprint.SetPosition(gridPos);
			UpdatePreview(gridPos);
		}

		private void SnapGridPositionToIsland(IslandObject island, ref Vector3Int gridPos)
		{
			int num = ((island.Size.x % 2 == 0) ? (-1) : 0);
			int max = island.Position.x + island.Size.x / 2 + num;
			int min = island.Position.x - island.Size.x / 2;
			int num2 = ((island.Size.y % 2 == 0) ? (-1) : 0);
			int max2 = island.Position.z + island.Size.y / 2 + num2;
			int min2 = island.Position.z - island.Size.y / 2;
			gridPos.x = Mathf.Clamp(gridPos.x, min, max);
			gridPos.z = Mathf.Clamp(gridPos.z, min2, max2);
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			PlaceBlueprintCommand command = new PlaceBlueprintCommand(_factoryLayer.Value, _terrainLayer, _selectedBlueprint.Position, _selectedBlueprint.Rotation, _selectedBlueprint, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator);
			_commandManager.DoCommand(command);
			_stopPreviewEvent.Fire();
			_previewStarted = false;
			_setCursorTextEvent.Fire(string.Empty);
			SelectTool(null);
		}

		public override void CancelAction()
		{
			_stopPreviewEvent.Fire();
			_previewStarted = false;
		}

		public override void DeSelectTool()
		{
			_stopPreviewEvent.Fire();
			_previewStarted = false;
		}
	}
}
