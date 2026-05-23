#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using UnityEngine;
using Utils;

namespace Data.Objectives.Events
{
	[CreateAssetMenu(menuName = "Objectives/Events/Unlock Cosmetic", fileName = "UnlockCosmeticObjectiveEventSO")]
	public class UnlockCosmeticObjectiveEventSO : AbstractObjectiveEvent
	{
		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

		[SerializeField]
		private List<FactoryObjectData> _cosmetics;

		public override void Execute()
		{
			this.Log("unlock cosmetic", "Execute", 17);
			if (_lockedFactoryObjectsPersistentSO == null)
			{
				this.LogError("Needs ref to persistent SO", "Execute", 20);
			}
			foreach (FactoryObjectData cosmetic in _cosmetics)
			{
				_lockedFactoryObjectsPersistentSO.UnlockObject(cosmetic);
			}
		}
	}
}
