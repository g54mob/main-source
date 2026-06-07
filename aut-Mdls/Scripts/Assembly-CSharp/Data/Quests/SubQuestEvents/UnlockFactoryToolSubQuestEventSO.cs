#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using System.Linq;
using Data.SaveData.PersistentSOs;
using Logic.FactoryTools;
using NaughtyAttributes;
using UnityEngine;
using Utils;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Unlock FactoryTool", fileName = "UnlockFactoryTool", order = 6)]
	public class UnlockFactoryToolSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private LockedFactoryToolsPersistentSO _lockedFactoryToolsPersistentSO;

		[SerializeField]
		private List<FactoryTool> _factoryTools;

		public override void Execute()
		{
			if (_lockedFactoryToolsPersistentSO == null)
			{
				this.LogError("Needs ref to persistent SO", "Execute", 21);
			}
			foreach (FactoryTool factoryTool in _factoryTools)
			{
				_lockedFactoryToolsPersistentSO.UnlockTool(factoryTool);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AddAllFactoryTools()
		{
			_factoryTools = Resources.FindObjectsOfTypeAll(typeof(FactoryTool)).Cast<FactoryTool>().ToList();
		}
	}
}
