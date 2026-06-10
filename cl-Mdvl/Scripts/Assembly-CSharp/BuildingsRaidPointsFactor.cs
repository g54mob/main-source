using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Manager.RaidPointsFactors;
using NSMedieval.Serialization;
using NSMedieval.Village;

[FVSerializableKey("BuildingsRaidPointsFactor", "")]
public class BuildingsRaidPointsFactor : RaidPointsFactor
{
	private readonly FactionOwnership factionOwnership;

	protected override string NamePlayerTextKey => "buildings_lost";

	protected override string NameEnemyTextKey => "enemy_buildings_destroyed";

	public BuildingsRaidPointsFactor(ActiveRaidInfo raid, FactionOwnership factionOwnership)
		: base(raid)
	{
		base.MaxPoints = base.Map.BuildingsManagerMain.TotalBuildingWealth * SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.BuildingWealthPointsMultiplier;
		base.CurrentPoints = base.MaxPoints;
		this.factionOwnership = factionOwnership;
		Subscribe();
		bool isEnabled;
		FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(81, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidPointsFactors\\BuildingsRaidPointsFactor.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("BuildingsRaidPointsFactor initialized with max points ");
			messageBuilder.AppendFormatted(base.MaxPoints);
			messageBuilder.AppendLiteral(", total building wealth is ");
			messageBuilder.AppendFormatted(base.Map.BuildingsManagerMain.TotalBuildingWealth);
		}
		Log.Debug(messageBuilder);
	}

	public override void InitAfterLoad()
	{
		bool isEnabled;
		FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidPointsFactors\\BuildingsRaidPointsFactor.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("BuildingsRaidPointsFactor initialized with max points ");
			messageBuilder.AppendFormatted(base.MaxPoints);
		}
		Log.Debug(messageBuilder);
		Subscribe();
	}

	private void Subscribe()
	{
		base.Map.BuildingsManagerMain.BeforeBuildingDestroyedEvent += OnBuildingDestroyed;
		base.Map.DoorComponentManager.DoorForceOpenEvent += OnDoorForcedOpen;
	}

	private void Unsubscribe()
	{
		if (base.Map?.BuildingsManagerMain != null)
		{
			base.Map.BuildingsManagerMain.BeforeBuildingDestroyedEvent -= OnBuildingDestroyed;
		}
		if (base.Map?.DoorComponentManager != null)
		{
			base.Map.DoorComponentManager.DoorForceOpenEvent -= OnDoorForcedOpen;
		}
	}

	private void OnBuildingDestroyed(BaseBuildingInstance building)
	{
		if (factionOwnership == building.FactionOwnership)
		{
			base.CurrentPoints -= building.GetWealth() * SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.BuildingWealthPointsMultiplier * SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.BuildingLostAdditionalMultiplier;
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidPointsFactors\\BuildingsRaidPointsFactor.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnBuildingDestroyed, CurrentPoints: ");
				messageBuilder.AppendFormatted(base.CurrentPoints);
			}
			Log.Debug(messageBuilder);
		}
	}

	private void OnDoorForcedOpen(DoorComponentInstance door)
	{
		if (factionOwnership == door.OwnerBuilding.FactionOwnership)
		{
			base.CurrentPoints -= door.OwnerBuilding.GetWealth() * SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.BuildingWealthPointsMultiplier * SingletonModel<BattleScaleSettings, BattleScalesSettingsData>.I.BuildingLostAdditionalMultiplier;
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Raid\\RaidPointsFactors\\BuildingsRaidPointsFactor.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnDoorForcedOpen, CurrentPoints: ");
				messageBuilder.AppendFormatted(base.CurrentPoints);
			}
			Log.Debug(messageBuilder);
		}
	}

	public override void Dispose()
	{
		Unsubscribe();
		base.Dispose();
	}

	public override void Serialize(FVSerializer serializer)
	{
		base.Serialize(serializer);
		serializer.WriteEnum("factionOwnership", factionOwnership);
	}

	public BuildingsRaidPointsFactor(FVDeserializer deserializer)
		: base(deserializer)
	{
		factionOwnership = deserializer.ReadEnum("factionOwnership", FactionOwnership.Player);
	}
}
