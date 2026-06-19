using Pug.Conversion;

public class HealthConverter : SingleAuthoringComponentConverter<HealthAuthoring>
{
	protected override void Convert(HealthAuthoring authoring)
	{
		int num = authoring.ComputeMaxHealth(base.UseHardModeSettings, base.UseCasualModeSettings);
		AreaLevelAuthoring component;
		bool flag = TryGetActiveComponent<AreaLevelAuthoring>(authoring, out component);
		PlayerAuthoring component2;
		bool num2 = TryGetActiveComponent<PlayerAuthoring>(authoring, out component2);
		bool num3 = !authoring.dontCalculateHealthFromLevel && flag;
		int health = authoring.startHealth;
		if (num3)
		{
			health = ((!authoring.overrideStartHealth) ? num : ((int)(authoring.normalizedOverrideStartHealth * (float)num)));
		}
		AddComponentData(new HealthCD
		{
			health = health,
			maxHealth = num
		});
		EnsureHasComponent<DamageTakenTriggerCD>(componentIsEnabled: false);
		EnsureHasComponent<KilledByPlayerCD>(componentIsEnabled: false);
		if (num2)
		{
			AddComponentData(new MaxHealthChangeAffectHealthCD
			{
				previousMaxHealth = num
			});
		}
		if (TryGetActiveComponent<TileAuthoring>(authoring, out var _))
		{
			EnsureHasComponent<InitialHealthChange>(componentIsEnabled: false);
		}
		if (authoring.hasHealthRegeneration)
		{
			AddComponentData(new HealthRegenerationCD
			{
				NormalizedHealthIncreasePerFiveSeconds = (float)authoring.healthIncreasePercentPerFiveSeconds / 100f,
				HealDelayAfterLeavingCombat = authoring.healDelayAfterLeavingCombat
			});
			BossAuthoring component4;
			if (authoring.healInCombatAsWell)
			{
				EnsureHasComponent<AllowHealthRegenerationInCombatCD>();
			}
			else if (!TryGetActiveComponent<BossAuthoring>(authoring, out component4))
			{
				EnsureHasComponent<StopHealthRegenOnDamageTakenCD>();
			}
		}
		EnsureHasComponent<MarkedAsMinionAttackTarget>(componentIsEnabled: false);
		EnsureHasComponent<HoveredAsMinionAttackTarget>(componentIsEnabled: false);
	}
}
