using System.Collections.Generic;
using System.Linq;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using NaughtyAttributes;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Lock FactoryObject", fileName = "LockFactoryObject", order = 5)]
	public class LockFactoryObjectSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

		[SerializeField]
		private List<FactoryObjectData> _factoryObjectDatas;

		public override void Execute()
		{
			foreach (FactoryObjectData factoryObjectData in _factoryObjectDatas)
			{
				_lockedFactoryObjectsPersistentSO.Lock(factoryObjectData);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AddAllFactoryObjectDatas()
		{
			_factoryObjectDatas = Resources.FindObjectsOfTypeAll(typeof(FactoryObjectData)).Cast<FactoryObjectData>().ToList();
		}
	}
}
