using UnityEngine;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_projectileBounceData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/ProjectileBounce")]
public class GE_ProjectileBounceData : GameplayEffectData
{
	[Header("Projectile bounce")]
	[SerializeField]
	private int bounces = 1;

	[SerializeField]
	private float bounceRadius = 1f;

	[SerializeField]
	private float bounceDamageMultiplier = 1f;

	public int Bounces => bounces;

	public float BounceRadius => bounceRadius;

	public float BounceDamageMultiplier => bounceDamageMultiplier;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetLocalizedString("GameplayEffects", "GE_bounce_name", null, FallbackBehavior.UseProjectSettings);

	public override string Description => string.Format(LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_bounce_description").Entry.GetLocalizedString(), bounces, FunctionLibrary.RoundToDecimals(BounceRadius, 1), (int)(BounceDamageMultiplier * 100f));

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_ProjectileBounce();
	}

	protected override bool ShowNameInInspector()
	{
		return false;
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}
}
