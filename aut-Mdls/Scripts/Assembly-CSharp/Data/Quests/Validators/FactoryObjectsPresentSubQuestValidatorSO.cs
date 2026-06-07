using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor;
using Data.Operator;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/FactoryObjects Present", fileName = "FactoryObjectsPresent", order = 6)]
	public class FactoryObjectsPresentSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private SerializedDictionary<FactoryObjectData, int> _requiredFactoryObjects = new SerializedDictionary<FactoryObjectData, int>();

		public override bool IsValid()
		{
			Dictionary<FactoryObjectData, int> dictionary = new Dictionary<FactoryObjectData, int>(_requiredFactoryObjects);
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (dictionary.ContainsKey(allDistinctObjectList.FactoryObjectData))
				{
					dictionary[allDistinctObjectList.FactoryObjectData]--;
					if (dictionary[allDistinctObjectList.FactoryObjectData] <= 0)
					{
						dictionary.Remove(allDistinctObjectList.FactoryObjectData);
					}
				}
			}
			return dictionary.Count <= 0;
		}

		public override void Reset()
		{
		}

		public override float GetProgress()
		{
			int num = 0;
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (_requiredFactoryObjects.ContainsKey(allDistinctObjectList.FactoryObjectData))
				{
					num++;
				}
			}
			return num;
		}

		public override float GetProgressTarget()
		{
			int num = 0;
			foreach (KeyValuePair<FactoryObjectData, int> requiredFactoryObject in _requiredFactoryObjects)
			{
				num += requiredFactoryObject.Value;
			}
			return num;
		}
	}
}
