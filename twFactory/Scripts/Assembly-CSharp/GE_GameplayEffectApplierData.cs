using UnityEngine;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_gameplayEffectApplierData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/GameplayEffectApplier")]
public class GE_GameplayEffectApplierData : GameplayEffectData
{
	[Header("GameplayEffect Applier")]
	[SerializeField]
	private GameplayEffectData geData;

	[SerializeField]
	private int stacksToApply = 1;

	[SerializeField]
	[Tooltip("Tiempo mínimo que tiene que pasar entre aplicaciones del efecto sobre el mismo enemigo, para evitar exploits.")]
	private float minIntervalPerEnemy;

	public int StacksToApply => stacksToApply;

	public GameplayEffectData GEData => geData;

	public float MinIntervalPerEnemy
	{
		get
		{
			return minIntervalPerEnemy;
		}
		set
		{
			minIntervalPerEnemy = value;
		}
	}

	public override string DisplayName
	{
		get
		{
			return geData.DisplayName;
		}
		set
		{
			base.DisplayName = value;
		}
	}

	public override string Description => string.Concat(string.Format(LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_gameplayEffectApplier_description").Entry.GetLocalizedString(), stacksToApply, geData.DisplayName) + "\n\n" + geData.DisplayName, "\n", geData.Description);

	private void OnValidate()
	{
		if ((bool)geData)
		{
			DisplayName = geData.DisplayName;
			base.Icon = geData.Icon;
			base.MaxStacks = 0;
		}
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_GameplayEffectApplier();
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
