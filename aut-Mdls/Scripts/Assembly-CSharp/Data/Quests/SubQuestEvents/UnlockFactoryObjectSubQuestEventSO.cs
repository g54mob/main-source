#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using System.Linq;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using NaughtyAttributes;
using UnityEngine;
using Utils;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Unlock FactoryObject", fileName = "UnlockFactoryObject", order = 4)]
	public class UnlockFactoryObjectSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

		[SerializeField]
		private List<FactoryObjectData> _factoryObjectDatas;

		public override void Execute()
		{
			if (_lockedFactoryObjectsPersistentSO == null)
			{
				this.LogError("Needs ref to persistent SO", "Execute", 19);
			}
			foreach (FactoryObjectData factoryObjectData in _factoryObjectDatas)
			{
				if (_lockedFactoryObjectsPersistentSO != null)
				{
					_lockedFactoryObjectsPersistentSO.UnlockObject(factoryObjectData);
				}
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AddAllFactoryObjectDatas()
		{
			_factoryObjectDatas = Resources.FindObjectsOfTypeAll(typeof(FactoryObjectData)).Cast<FactoryObjectData>().ToList();
		}
	}
}
