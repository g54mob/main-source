using System.Collections.Generic;
using System.Linq;
using Data.SaveData.PersistentSOs;
using Logic.FactoryTools;
using NaughtyAttributes;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Lock FactoryTool", fileName = "LockFactoryTool", order = 7)]
	public class LockFactoryToolSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private LockedFactoryToolsPersistentSO lockedFactoryFactoryToolsPersistentSO;

		[SerializeField]
		private List<FactoryTool> _factoryObjectTools;

		public override void Execute()
		{
			foreach (FactoryTool factoryObjectTool in _factoryObjectTools)
			{
				lockedFactoryFactoryToolsPersistentSO.Lock(factoryObjectTool);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AddAllFactoryTools()
		{
			_factoryObjectTools = Resources.FindObjectsOfTypeAll(typeof(FactoryTool)).Cast<FactoryTool>().ToList();
		}
	}
}
