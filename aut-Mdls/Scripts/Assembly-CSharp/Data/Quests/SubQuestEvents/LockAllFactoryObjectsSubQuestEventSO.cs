using Data.Operator;
using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Lock All FactoryObjects", fileName = "LockAllFactoryObjects", order = 5)]
	public class LockAllFactoryObjectsSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private bool _lockFlag = true;

		public override void Execute()
		{
			if (!_lockFlag)
			{
				_lockedFactoryObjectsPersistentSO.UnlockAll();
				return;
			}
			foreach (FactoryObjectData allFactoryObjectsDatum in _factoryObjectDatabase.AllFactoryObjectsData)
			{
				_lockedFactoryObjectsPersistentSO.Lock(allFactoryObjectsDatum);
			}
		}
	}
}
