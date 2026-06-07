using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[CreateAssetMenu(fileName = "Prototype Scenario", menuName = "Flotsam/Scenarios/Prototype")]
	public class PrototypeScenario : ScenarioBase
	{
		[Serializable]
		public class PersistentData : PersistentDataBase
		{
			public PersistentData(PrototypeScenario instance)
				: base(instance)
			{
			}

			public override ScenarioBase Restore(PrototypeScenario fallbackScenario = null)
			{
				ScenarioBase scenarioBase = base.Restore(fallbackScenario);
				if (scenarioBase == null)
				{
					scenarioBase = fallbackScenario.GetInstance();
					RestoreQueuedWorldTiles(scenarioBase);
				}
				return scenarioBase;
			}
		}

		[SerializeReference]
		[InstantiateSerializeReference]
		private IScenarioTrigger[] _triggers;

		public override void OnFirstStart()
		{
			base.WorldTileProvider.QueueStartTiles();
		}

		protected override void OnStart()
		{
			IScenarioTrigger[] triggers = _triggers;
			for (int i = 0; i < triggers.Length; i++)
			{
				triggers[i].Initialize();
			}
		}

		public override IScenarioPersistentData GetPersistentData()
		{
			return new PersistentData(this);
		}
	}
}
