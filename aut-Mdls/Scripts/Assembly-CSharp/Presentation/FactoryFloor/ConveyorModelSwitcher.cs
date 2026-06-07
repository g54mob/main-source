using System;
using System.Linq;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.Operator;
using Events.FactoryFloor;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class ConveyorModelSwitcher : FactoryBehaviorView<ConveyorBehaviour>
	{
		public enum ConveyorType
		{
			Straight = 0,
			T = 1,
			X = 2,
			Corner = 3
		}

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private Transform _modelParent;

		[SerializeField]
		private Transform _previewModelParent;

		[SerializeField]
		private GameObject _straightConveyor;

		[SerializeField]
		private GameObject _cornerConveyor;

		[SerializeField]
		private GameObject _tConveyor;

		[SerializeField]
		private GameObject _xConveyor;

		[SerializeField]
		private GameObject _previewStraightConveyor;

		[SerializeField]
		private GameObject _previewCornerConveyor;

		[SerializeField]
		private GameObject _previewTConveyor;

		[SerializeField]
		private GameObject _previewXConveyor;

		[SerializeField]
		private bool _rotateArrow = true;

		private FactoryObject _factoryObject;

		private GameObject _currConveyorModel;

		private GameObject _previewCurrConveyorModel;

		protected override void Init()
		{
			base.Init();
			_currConveyorModel = _straightConveyor;
			_previewCurrConveyorModel = _previewStraightConveyor;
			_factoryObject = _objectView.FactoryObject;
			_objectView.FactoryObjectReset += base.ResetFactoryObjectView;
			UpdateConveyorModel();
			_factoryObject.OnInputsUpdated += UpdateConveyorModel;
		}

		protected override void PreviewInit(int objectId, BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			base.PreviewInit(objectId, blueprintViewEventDto, element);
			_currConveyorModel = _straightConveyor;
			_previewCurrConveyorModel = _previewStraightConveyor;
			_objectView.FactoryObjectReset += base.ResetFactoryObjectView;
			GetPreviewConnectedConveyors(blueprintViewEventDto, element);
		}

		protected override void UpdatePreview(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			base.UpdatePreview(blueprintViewEventDto, element);
			GetPreviewConnectedConveyors(blueprintViewEventDto, element);
		}

		protected override void ResetFactoryObject()
		{
			base.ResetFactoryObject();
			SetConveyorModel(ConveyorType.Straight, Quaternion.identity);
			SetPreviewConveyorModel(ConveyorType.Straight, Quaternion.identity);
			_modelParent.localScale = Vector3.one;
			_previewModelParent.localScale = Vector3.one;
			if (_factoryObject != null)
			{
				_factoryObject.OnInputsUpdated -= UpdateConveyorModel;
				_factoryObject = null;
			}
			_objectView.FactoryObjectReset -= base.ResetFactoryObjectView;
		}

		private void UpdateConveyorModel()
		{
			var (back, left, right) = GetConnections();
			var (type, rotation) = GetConveyorTypeAndRot(back, left, right);
			SetConveyorModel(type, rotation);
			SetPreviewConveyorModel(type, rotation);
			_modelParent.localScale = base.transform.localScale;
			_previewModelParent.localScale = _modelParent.localScale;
		}

		private void GetPreviewConnectedConveyors(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
			Vector3 worldPosition = element.Position + blueprintViewEventDto.Blueprint.Position;
			Vector3Int cellPosition = _gridLocator.GetCellPosition(worldPosition);
			Vector3Int vector3Int;
			Vector3Int vector3Int2;
			Vector3Int vector3Int3;
			switch ((element.Rotation + blueprintViewEventDto.Blueprint.Rotation) / 90 % 4)
			{
			case 0:
				vector3Int = new Vector3Int(1, 0, 0);
				vector3Int2 = new Vector3Int(-1, 0, 0);
				vector3Int3 = new Vector3Int(0, 0, -1);
				break;
			case 1:
				vector3Int = new Vector3Int(0, 0, -1);
				vector3Int2 = new Vector3Int(0, 0, 1);
				vector3Int3 = new Vector3Int(-1, 0, 0);
				break;
			case 2:
				vector3Int = new Vector3Int(-1, 0, 0);
				vector3Int2 = new Vector3Int(1, 0, 0);
				vector3Int3 = new Vector3Int(0, 0, 1);
				break;
			case 3:
				vector3Int = new Vector3Int(0, 0, 1);
				vector3Int2 = new Vector3Int(0, 0, -1);
				vector3Int3 = new Vector3Int(1, 0, 0);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			FactoryObject objectAt = _factoryLayer.GetObjectAt(cellPosition + vector3Int3);
			FactoryObject objectAt2 = _factoryLayer.GetObjectAt(cellPosition + vector3Int2);
			FactoryObject objectAt3 = _factoryLayer.GetObjectAt(cellPosition + vector3Int);
			bool isBackInput = IsFactoryObjectInput(cellPosition, objectAt);
			bool isLeftInput = IsFactoryObjectInput(cellPosition, objectAt2);
			bool isRightInput = IsFactoryObjectInput(cellPosition, objectAt3);
			IsBlueprintElementInput(cellPosition, cellPosition + vector3Int3, cellPosition + vector3Int2, cellPosition + vector3Int, blueprintViewEventDto, ref isBackInput, ref isLeftInput, ref isRightInput);
			if (element.Mirrored)
			{
				bool num = isRightInput;
				bool flag = isLeftInput;
				isLeftInput = num;
				isRightInput = flag;
			}
			var (type, rotation) = GetConveyorTypeAndRot(isBackInput, isLeftInput, isRightInput);
			SetPreviewConveyorModel(type, rotation);
		}

		private void IsBlueprintElementInput(Vector3Int pos, Vector3Int backPos, Vector3Int leftPos, Vector3Int rightPos, BlueprintViewEventDto blueprintViewEventDto, ref bool isBackInput, ref bool isLeftInput, ref bool isRightInput)
		{
			Vector3 vector = new Vector3(0.499f, 0.499f, 0.499f);
			Vector3Int cellPosition = _gridLocator.GetCellPosition(blueprintViewEventDto.Blueprint.Position + vector);
			Vector3Int key = backPos - cellPosition;
			Vector3Int key2 = leftPos - cellPosition;
			Vector3Int key3 = rightPos - cellPosition;
			if (!isBackInput && blueprintViewEventDto.Blueprint.BlueprintViewElementDtoPosLookup.TryGetValue(key, out var value))
			{
				isBackInput = IsBlueprintElementInput(pos, value, blueprintViewEventDto);
			}
			if (!isLeftInput && blueprintViewEventDto.Blueprint.BlueprintViewElementDtoPosLookup.TryGetValue(key2, out var value2))
			{
				isLeftInput = IsBlueprintElementInput(pos, value2, blueprintViewEventDto);
			}
			if (!isRightInput && blueprintViewEventDto.Blueprint.BlueprintViewElementDtoPosLookup.TryGetValue(key3, out var value3))
			{
				isRightInput = IsBlueprintElementInput(pos, value3, blueprintViewEventDto);
			}
		}

		private bool IsBlueprintElementInput(Vector3Int pos, BlueprintViewDto.BlueprintViewElementDto element, BlueprintViewEventDto blueprintViewEventDto)
		{
			FactoryObjectData objectDataWithId = _factoryObjectDatabase.GetObjectDataWithId(element.ObjectId);
			foreach (FactoryObjectData.OutputData outputPosition in objectDataWithId.OutputPositions)
			{
				if (objectDataWithId.DataPosToWorldPos(outputPosition.Position, _gridLocator.GetCellPosition(element.Position + blueprintViewEventDto.Blueprint.Position), blueprintViewEventDto.Blueprint.Rotation + element.Rotation, element.Mirrored) == pos)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsFactoryObjectInput(Vector3Int pos, FactoryObject factoryObject)
		{
			if (factoryObject == null)
			{
				return false;
			}
			foreach (FactoryObjectData.OutputData dataOutputPosition in factoryObject.DataOutputPositions)
			{
				if (factoryObject.DataPosToWorldPos(dataOutputPosition.Position) == pos)
				{
					return true;
				}
			}
			return false;
		}

		private (bool back, bool left, bool right) GetConnections()
		{
			bool item = false;
			bool item2 = false;
			bool item3 = false;
			foreach (FactoryObject inputFactoryObject in _factoryObject.InputFactoryObjects)
			{
				if (inputFactoryObject == null)
				{
					continue;
				}
				for (int i = 0; i < inputFactoryObject.OutputFactoryObjects.Length; i++)
				{
					if (inputFactoryObject.OutputFactoryObjects[i] == null)
					{
						continue;
					}
					FactoryObject.OutputFactoryObject outputFactoryObject = inputFactoryObject.OutputFactoryObjects.ElementAt(i);
					if (outputFactoryObject.FactoryObject == _factoryObject)
					{
						Vector3Int vector3Int = _factoryObject.WorldDirToDataDir(inputFactoryObject.DataDirToWorldDir(outputFactoryObject.OutputData.Direction));
						if (vector3Int.z == 1)
						{
							item = true;
							break;
						}
						if (vector3Int.x == -1)
						{
							item3 = true;
							break;
						}
						if (vector3Int.x == 1)
						{
							item2 = true;
							break;
						}
					}
				}
			}
			return (back: item, left: item2, right: item3);
		}

		private (ConveyorType type, Quaternion rot) GetConveyorTypeAndRot(bool back, bool left, bool right)
		{
			if (!left && !right)
			{
				return (type: ConveyorType.Straight, rot: Quaternion.identity);
			}
			if (left && right)
			{
				return (type: (!back) ? ConveyorType.T : ConveyorType.X, rot: back ? Quaternion.identity : Quaternion.Euler(0f, 180f, 0f));
			}
			if (back)
			{
				return (type: ConveyorType.T, rot: left ? Quaternion.Euler(0f, 90f, 0f) : Quaternion.Euler(0f, -90f, 0f));
			}
			return (type: ConveyorType.Corner, rot: left ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, -90f, 0f));
		}

		private void SetConveyorModel(ConveyorType type, Quaternion rotation)
		{
			GameObject nextConveyorModel = type switch
			{
				ConveyorType.T => _tConveyor, 
				ConveyorType.X => _xConveyor, 
				ConveyorType.Corner => _cornerConveyor, 
				_ => _straightConveyor, 
			};
			SetConveyorModelInternal(ref _currConveyorModel, nextConveyorModel, rotation);
		}

		private void SetPreviewConveyorModel(ConveyorType type, Quaternion rotation)
		{
			GameObject nextConveyorModel = type switch
			{
				ConveyorType.T => _previewTConveyor, 
				ConveyorType.X => _previewXConveyor, 
				ConveyorType.Corner => _previewCornerConveyor, 
				_ => _previewStraightConveyor, 
			};
			SetConveyorModelInternal(ref _previewCurrConveyorModel, nextConveyorModel, rotation);
		}

		private void SetConveyorModelInternal(ref GameObject currConveyorModel, GameObject nextConveyorModel, Quaternion rotation)
		{
			if (currConveyorModel != nextConveyorModel)
			{
				currConveyorModel.SetActive(value: false);
				nextConveyorModel.SetActive(value: true);
			}
			currConveyorModel = nextConveyorModel;
			currConveyorModel.transform.SetLocalPositionAndRotation(Vector3.zero, rotation);
			currConveyorModel.transform.localScale = Vector3.one;
			if (currConveyorModel.transform.childCount > 0 && _rotateArrow)
			{
				Transform child = currConveyorModel.transform.GetChild(0);
				Vector3 eulerAngles = child.localRotation.eulerAngles;
				child.localRotation = Quaternion.Euler(eulerAngles.x, 0f - rotation.eulerAngles.y, eulerAngles.z);
			}
		}
	}
}
