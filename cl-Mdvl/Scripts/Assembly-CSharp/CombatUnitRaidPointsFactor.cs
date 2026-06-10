using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;

[FVSerializableKey("CombatUnitRaidPointsFactor", "")]
public class CombatUnitRaidPointsFactor : RaidPointsFactor
{
	private List<HumanoidInstance> units;

	protected override string NamePlayerTextKey => "settlers_lost";

	protected override string NameEnemyTextKey => "enemies_killed";

	public CombatUnitRaidPointsFactor(ActiveRaidInfo raid, IEnumerable<HumanoidInstance> units)
		: base(raid)
	{
		this.units = units.ToList();
		foreach (HumanoidInstance unit in this.units)
		{
			base.MaxPoints += unit.ActiveBehaviour.Blueprint.RaidBattleScalesPointsMultiplier;
		}
		base.CurrentPoints = base.MaxPoints;
		Subscribe();
		bool isEnabled;
		FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidPointsFactors\\CombatUnitRaidPointsFactor.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("CombatUnitRaidPointsFactor initialized with MaxPoints - ");
			messageBuilder.AppendFormatted(base.MaxPoints);
		}
		Log.Debug(messageBuilder);
	}

	public override void InitAfterLoad()
	{
		bool isEnabled;
		FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidPointsFactors\\CombatUnitRaidPointsFactor.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("CombatUnitRaidPointsFactor initialized with MaxPoints - ");
			messageBuilder.AppendFormatted(base.MaxPoints);
		}
		Log.Debug(messageBuilder);
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
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(126, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidPointsFactors\\CombatUnitRaidPointsFactor.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Worker death/faint regarded as NOT in combat, so it won't be counted in the battle scales (max points will also be decreased) ");
				messageBuilder.AppendFormatted(humanoidUnit);
			}
			Log.Info(messageBuilder);
			base.MaxPoints -= humanoidUnit.ActiveBehaviour.Blueprint.RaidBattleScalesPointsMultiplier;
		}
		base.CurrentPoints -= humanoidUnit.ActiveBehaviour.Blueprint.RaidBattleScalesPointsMultiplier;
		FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(64, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidPointsFactors\\CombatUnitRaidPointsFactor.cs");
		if (isEnabled)
		{
			messageBuilder2.AppendLiteral("CombatUnitRaidPointsFactor OnUnitKilled, CurrentPoints: ");
			messageBuilder2.AppendFormatted(base.CurrentPoints);
			messageBuilder2.AppendLiteral(", unit: ");
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
	}

	public CombatUnitRaidPointsFactor(FVDeserializer deserializer)
		: base(deserializer)
	{
		units = deserializer.ReadObjectList<HumanoidInstance>("units");
	}
}
