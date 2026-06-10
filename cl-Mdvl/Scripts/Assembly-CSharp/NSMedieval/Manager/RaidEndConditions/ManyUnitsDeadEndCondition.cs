using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager.RaidPointsFactors;
using NSMedieval.Serialization;
using NSMedieval.State;

namespace NSMedieval.Manager.RaidEndConditions
{
	[FVSerializableKey("ManyUnitsDeadEndCondition", "")]
	public class ManyUnitsDeadEndCondition : RaidEndCondition
	{
		private List<HumanoidInstance> units;

		private int numberOfDeadUnits;

		public override bool ShouldEnd => (float)numberOfDeadUnits / (float)units.Count > SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.GetUnitsDeadEndConditionPercent(units.Count);

		public ManyUnitsDeadEndCondition(ActiveRaidInfo raid, IEnumerable<HumanoidInstance> units)
			: base(raid)
		{
			this.units = units.ToList();
			Subscribe();
		}

		public override void InitAfterLoad()
		{
			Subscribe();
		}

		private void Subscribe()
		{
			foreach (HumanoidInstance unit in units)
			{
				unit.BeforeDeathEvent += OnUnitKilledOrFainted;
				unit.BeforeFaintEvent += OnUnitKilledOrFainted;
			}
		}

		private void Unsubscribe()
		{
			foreach (HumanoidInstance unit in units)
			{
				if (!unit.HasDisposed)
				{
					unit.BeforeDeathEvent -= OnUnitKilledOrFainted;
					unit.BeforeFaintEvent -= OnUnitKilledOrFainted;
				}
			}
		}

		private void OnUnitKilledOrFainted(HumanoidInstance humanoidUnit)
		{
			humanoidUnit.BeforeDeathEvent -= OnUnitKilledOrFainted;
			humanoidUnit.BeforeFaintEvent -= OnUnitKilledOrFainted;
			bool isEnabled;
			if (humanoidUnit.IsWorker() && !CombatUtils.CheckIsInCombat(humanoidUnit))
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(104, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidEndConditions\\ManyUnitsDeadEndCondition.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Worker death/faint regarded as NOT in combat, so it won't be counted in the battle scales end condition ");
					messageBuilder.AppendFormatted(humanoidUnit);
				}
				Log.Info(messageBuilder);
				return;
			}
			numberOfDeadUnits++;
			FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(38, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidEndConditions\\ManyUnitsDeadEndCondition.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("OnUnitKilled++, current count: ");
				messageBuilder2.AppendFormatted(numberOfDeadUnits);
				messageBuilder2.AppendLiteral(", unit ");
				messageBuilder2.AppendFormatted(humanoidUnit);
			}
			Log.Debug(messageBuilder2);
		}

		public override void Dispose()
		{
			Unsubscribe();
			base.Dispose();
			units = null;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("units", units);
			serializer.Write("numberOfDeadUnits", numberOfDeadUnits);
		}

		public ManyUnitsDeadEndCondition(FVDeserializer deserializer)
			: base(deserializer)
		{
			units = deserializer.ReadObjectList<HumanoidInstance>("units");
			numberOfDeadUnits = deserializer.ReadInt("numberOfDeadUnits");
		}
	}
}
