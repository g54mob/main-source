using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Serialization;

namespace NSMedieval.GameEventSystem.Events
{
	[Serializable]
	[FVSerializableKey("GameEvents.AnimalGroupEvent", "")]
	public class AnimalGroupEvent : GameEventInstance
	{
		public AnimalGroupEvent()
		{
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new AnimalVisitPhase());
		}

		public override bool CanStart()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				return false;
			}
			if (GlobalSaveController.CurrentVillageData.Workers.Count == 0)
			{
				return false;
			}
			if (!base.CanStart())
			{
				return false;
			}
			List<IEnemyPurchaseUnit> enemiesToSpawn;
			bool num = MonoSingleton<RaidEnemySelector>.Instance.PurchaseEnemiesForAnimalRaid(out enemiesToSpawn, base.Blueprint);
			if (!num)
			{
				GameEventInstance.Logger.Info("Cannot add animals to animal raid - not enough raid points probably.");
			}
			return num;
		}

		protected override void ShowStartText()
		{
		}

		protected override void ShowEndText()
		{
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public AnimalGroupEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
