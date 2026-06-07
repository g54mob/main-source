using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_splashGameplayEffectApplierData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/SplashGameplayEffectApplier")]
public class GE_SplashGameplayEffectApplierData : GE_SplashData
{
	[Header("Splash GameplayEffect Applier")]
	[SerializeField]
	private GameplayEffectData geData;

	[SerializeField]
	private int stacksToApply = 1;

	public int StacksToApply => stacksToApply;

	public GameplayEffectData GEData => geData;

	public override string DisplayName
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> { { "ge-name", geData.DisplayName } };
			return new LocalizedString("GameplayEffects", "GE_splashGameplayEffectApplier_name").GetLocalizedString(dictionary);
		}
	}

	public override string Description => string.Concat(string.Format(LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_splashGameplayEffectApplier_description").Entry.GetLocalizedString(), stacksToApply, geData.DisplayName, FunctionLibrary.RoundToDecimals(base.SplashRadius, 1)) + "\n\n" + geData.DisplayName, "\n", geData.Description);

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_SplashGameplayEffectApplier();
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

	protected override bool ShowMaxStacksInInspector()
	{
		return false;
	}
}
