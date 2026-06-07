using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.Operator;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/FactoryObjects Connected", fileName = "FactoryObjectsConnected", order = 6)]
	public class FactoryObjectsConnectedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectData _endPointFactoryObject;

		[SerializeField]
		private FactoryObjectData _inputFactoryObject;

		[SerializeField]
		private int _inputCount;

		private int _MaxExtractorsConnected;

		public override bool IsValid()
		{
			_MaxExtractorsConnected = 0;
			foreach (FactoryObject objectsFromDatum in _factoryLayer.GetObjectsFromData(_endPointFactoryObject))
			{
				List<FactoryObject> allInputObjects = GetAllInputObjects(objectsFromDatum);
				int num = 0;
				foreach (FactoryObject item in allInputObjects)
				{
					if (item.FactoryObjectData == _inputFactoryObject)
					{
						num++;
					}
				}
				_MaxExtractorsConnected = Mathf.Max(_MaxExtractorsConnected, num);
				if (_MaxExtractorsConnected >= _inputCount)
				{
					return true;
				}
			}
			return false;
		}

		public override void Reset()
		{
		}

		public override float GetProgress()
		{
			return _MaxExtractorsConnected;
		}

		public override float GetProgressTarget()
		{
			return _inputCount;
		}

		private List<FactoryObject> GetAllInputObjects(FactoryObject factoryObject)
		{
			List<FactoryObject> list = new List<FactoryObject>();
			foreach (FactoryObject inputConveyor in GetInputConveyors(factoryObject))
			{
				List<FactoryObject> factoryObjectsConnectedToConveyor = GetFactoryObjectsConnectedToConveyor(inputConveyor);
				list.AddRange(factoryObjectsConnectedToConveyor);
			}
			return list;
		}

		private List<FactoryObject> GetInputConveyors(FactoryObject factoryObject)
		{
			List<FactoryObject> list = new List<FactoryObject>();
			foreach (FactoryObjectData.InputData dataInputPosition in factoryObject.DataInputPositions)
			{
				FactoryObject objectAt = _factoryLayer.GetObjectAt(factoryObject.DataPosToWorldPos(dataInputPosition.Position - dataInputPosition.Direction));
				if (objectAt == null)
				{
					continue;
				}
				foreach (FactoryObjectData.OutputData outputPosition in _inputFactoryObject.OutputPositions)
				{
					Vector3Int vector3Int = factoryObject.DataPosToWorldPos(dataInputPosition.Position);
					Vector3Int vector3Int2 = factoryObject.DataDirToWorldDir(dataInputPosition.Direction);
					Vector3Int vector3Int3 = objectAt.DataPosToWorldPos(outputPosition.Position);
					Vector3Int vector3Int4 = objectAt.DataDirToWorldDir(outputPosition.Direction);
					if (vector3Int == vector3Int3 && (vector3Int2 == vector3Int4 || dataInputPosition.Direction == Vector3.zero))
					{
						list.Add(objectAt);
					}
				}
			}
			return list;
		}

		private List<FactoryObject> GetFactoryObjectsConnectedToConveyor(FactoryObject factoryObject)
		{
			List<FactoryObject> list = new List<FactoryObject>();
			if (factoryObject.HasFactoryObjectBehaviour<ConveyorBehaviour>())
			{
				foreach (FactoryObject inputFactoryObject in factoryObject.InputFactoryObjects)
				{
					foreach (FactoryObject item in GetFactoryObjectsConnectedToConveyor(inputFactoryObject))
					{
						list.Add(item);
					}
				}
			}
			if (!factoryObject.HasFactoryObjectBehaviour<ConveyorBehaviour>() || factoryObject.GetFactoryObjectBehaviours().Count > 1)
			{
				list.Add(factoryObject);
			}
			return list;
		}
	}
}
