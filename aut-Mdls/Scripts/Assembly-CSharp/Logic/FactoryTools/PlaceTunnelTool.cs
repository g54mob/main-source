using System.Collections.Generic;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
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
	[CreateAssetMenu(menuName = "Factory/Tools/PlaceTunnelTool", fileName = "PlaceTunnelTool", order = 0)]
	public class PlaceTunnelTool : FactoryTool
	{
		[Header("Tunnel refs")]
		[SerializeField]
		private FactoryObjectData _inputTunnelObjectData;

		[SerializeField]
		private FactoryObjectData _outputTunnelObjectData;

		[SerializeField]
		private IntVariableSO _maxDistance;

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

		private int _savedRotation;

		private List<BlueprintElement> _tunnelSavedPositions = new List<BlueprintElement>();

		private Blueprint _selectedBlueprint;

		private BlueprintViewDto _blueprintViewDto;

		private Vector3Int _firstInputPosition;

		private bool _inputPlaced;

		private bool _previewStarted;

		public int MaxDistance => _maxDistance.Value;

		public override bool CanAutoSwapAwayFrom => false;

		public override string BreadcrumbId => _inputTunnelObjectData.BreadcrumbId;

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_inputPlaced = false;
			_tunnelSavedPositions = new List<BlueprintElement>
			{
				new BlueprintElement(GetNewPosition(Vector3Int.zero), _inputTunnelObjectData, 0, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int>())
			};
			_selectedBlueprint = new Blueprint(new Vector3Int(0, 0, 0), _savedRotation, _tunnelSavedPositions);
			_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
		}

		private List<Vector3Int> GetNewPosition(Vector3Int position)
		{
			List<Vector3Int> relativePositions = _inputTunnelObjectData.RelativePositions;
			List<Vector3Int> list = new List<Vector3Int>(relativePositions.Count);
			foreach (Vector3Int item in relativePositions)
			{
				list.Add(item + position);
			}
			return list;
		}

		private void UpdatePreview(Vector3Int position)
		{
			bool canBePlaced = BlueprintPlacementValidator.CanBePlaced(position, _selectedBlueprint, _factoryLayer.Value, _terrainLayer);
			_blueprintViewDto.Position = _gridLocator.GetWorldPosition(position);
			if (!_previewStarted)
			{
				_startPreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, canBePlaced));
				_previewStarted = true;
			}
			else
			{
				_updatePreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, canBePlaced));
			}
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_inputPlaced)
			{
				int rotation;
				Vector3Int vector3Int = CalculateFinalRelativePosition(gridPos, out rotation);
				_selectedBlueprint.Elements[1] = new BlueprintElement(GetNewPosition(vector3Int), _outputTunnelObjectData, 0, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int>());
				_selectedBlueprint.Elements[0].HardLinkedToRelativePositions = new List<Vector3Int> { vector3Int };
				_selectedBlueprint.SetRotation(rotation);
				_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
				UpdatePreview(_firstInputPosition);
			}
			else
			{
				UpdatePreview(gridPos);
			}
		}

		private Vector3Int CalculateFinalRelativePosition(Vector3Int position, out int rotation)
		{
			Vector3Int result = new Vector3Int(0, 0, 0);
			int num = position.x - _firstInputPosition.x;
			int num2 = position.z - _firstInputPosition.z;
			rotation = 0;
			if (Mathf.Abs(num) > Mathf.Abs(num2))
			{
				int num3 = (int)Mathf.Sign(num);
				int b = Mathf.Min(Mathf.Abs(num), _maxDistance.Value) * num3;
				b = ((num3 <= 0) ? Mathf.Min(-1, b) : Mathf.Max(1, b));
				result.x = b;
				rotation = ((num3 == 1) ? 90 : 270);
				return result;
			}
			int num4 = (int)Mathf.Sign(num2);
			int b2 = Mathf.Min(Mathf.Abs(num2), _maxDistance.Value) * num4;
			b2 = ((num4 <= 0) ? Mathf.Min(-1, b2) : Mathf.Max(1, b2));
			result.z = b2;
			rotation = ((num4 != 1) ? 180 : 0);
			return result;
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
		}

		public override void Rotate(int rotation)
		{
			_savedRotation = _selectedBlueprint.ClampAngle(_savedRotation + rotation);
			if (!_inputPlaced)
			{
				_selectedBlueprint.Rotate(rotation);
				Vector3 position = _blueprintViewDto.Position;
				_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
				_audioManagerLocator.AudioManager.PlayRotateObject(position, _inputTunnelObjectData.ObjectSize);
			}
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			if (!_inputPlaced)
			{
				_firstInputPosition = gridPos;
				_tunnelSavedPositions.Add(new BlueprintElement(GetNewPosition(Vector3Int.zero), _outputTunnelObjectData, 0, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int>()));
				_inputPlaced = true;
				_audioManagerLocator.AudioManager.PlayPlaceObject(gridPos);
			}
			else
			{
				PlaceBlueprintCommand command = new PlaceBlueprintCommand(_factoryLayer.Value, _terrainLayer, _firstInputPosition, _selectedBlueprint.Rotation, _selectedBlueprint, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator);
				_commandManager.DoCommand(command);
				_inputPlaced = false;
				_stopPreviewEvent.Fire();
				_previewStarted = false;
				SelectTool(null);
			}
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
