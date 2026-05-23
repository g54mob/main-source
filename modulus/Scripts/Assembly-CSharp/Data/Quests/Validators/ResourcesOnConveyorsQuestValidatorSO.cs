using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Resources On Conveyors", fileName = "ResourcesOnConveyors", order = 6)]
	public class ResourcesOnConveyorsQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectData _conveyorData;

		[SerializeField]
		private ResourceDataSO _resourceData;

		[SerializeField]
		private int _resourcesNeededOnConveyor;

		public override bool IsValid()
		{
			int num = 0;
			foreach (FactoryObject factoryObjectsOfDatum in GetFactoryObjectsOfData(_conveyorData))
			{
				ConveyorBehaviour factoryObjectBehaviour = factoryObjectsOfDatum.GetFactoryObjectBehaviour<ConveyorBehaviour>();
				if (factoryObjectBehaviour.HasResource() && factoryObjectBehaviour.Resource.Data == _resourceData)
				{
					num++;
				}
			}
			return num >= _resourcesNeededOnConveyor;
		}

		public override void Reset()
		{
		}

		private IEnumerable<FactoryObject> GetFactoryObjectsOfData(FactoryObjectData factoryObjectData)
		{
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (allDistinctObjectList.FactoryObjectData == factoryObjectData)
				{
					yield return allDistinctObjectList;
				}
			}
		}
	}
}
