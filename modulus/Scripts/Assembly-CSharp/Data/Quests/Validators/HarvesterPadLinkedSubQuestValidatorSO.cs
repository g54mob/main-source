using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.Operator;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/HarvesterPad Linked", fileName = "HarvesterPadLinked", order = 12)]
	public class HarvesterPadLinkedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectData _harvesterPadData;

		[SerializeField]
		private BuildingObjectData _targetBuilding;

		[SerializeField]
		private int _targetAmount = 1;

		public override bool IsValid()
		{
			int num = 0;
			foreach (FactoryObject objectsFromDatum in _factoryLayer.GetObjectsFromData(_harvesterPadData))
			{
				foreach (BuildingBehaviour linkedBuilding in objectsFromDatum.GetFactoryObjectBehaviour<HarvesterPadBehaviour>().LinkedBuildings)
				{
					if (linkedBuilding.BuildingObjectData == _targetBuilding)
					{
						num++;
					}
				}
				if (num >= _targetAmount)
				{
					return true;
				}
			}
			return false;
		}

		public override void Reset()
		{
		}
	}
}
