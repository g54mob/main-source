using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_splashDamageData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/SplashDamage")]
public class GE_SplashDamageData : GE_SplashData
{
	[Header("Splash damage")]
	[SerializeField]
	private float damageMultipler = 1f;

	public float DamageMultipler => damageMultipler;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_splashDamage_name").Entry.GetLocalizedString();

	public override string Description => string.Format(LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_splashDamage_description").Entry.GetLocalizedString(new Dictionary<string, string>
	{
		{
			"0",
			((int)(DamageMultipler * 100f)).ToString() ?? ""
		},
		{
			"1",
			FunctionLibrary.RoundToDecimals(base.SplashRadius, 1).ToString() ?? ""
		}
	}));

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_SplashDamage();
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
