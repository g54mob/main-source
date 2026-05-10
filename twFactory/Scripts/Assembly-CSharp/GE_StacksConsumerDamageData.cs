using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_stacksConsumerDamageData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/Stacks Consumer Damage")]
public class GE_StacksConsumerDamageData : GE_StacksConsumerData
{
	[Header("Stacks Consumer Damage")]
	[SerializeField]
	private int damagePerStack = 1;

	[SerializeField]
	private EDamageMultiplier healthMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private EDamageMultiplier armorMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private EDamageMultiplier shieldMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private GameObject vfxPrefab;

	[SerializeField]
	private AudioData sound;

	[Header("Splash")]
	[SerializeField]
	private float splashRadius;

	[SerializeField]
	private bool affectsTarget = true;

	[Header("Debug")]
	[SerializeField]
	private bool debug;

	[SerializeField]
	private GameObject debugObject;

	public int DamagePerStack => damagePerStack;

	public EDamageMultiplier HealthMultiplier => healthMultiplier;

	public EDamageMultiplier ArmorMultiplier => armorMultiplier;

	public EDamageMultiplier ShieldMultiplier => shieldMultiplier;

	public GameObject VfxPrefab => vfxPrefab;

	public AudioData Sound => sound;

	public float SplashRadius => splashRadius;

	public bool AffectsTarget => affectsTarget;

	public bool Debug => debug;

	public GameObject DebugObject => debugObject;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_stackConsumerDamage_name").Entry.GetLocalizedString();

	public override string Description
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "stacks-to-consume", base.MaxStacksToConsume },
				{
					"ge-name",
					base.GameplayEffectToConsume.DisplayName
				},
				{ "damage-per-stack", DamagePerStack },
				{ "splash-radius", SplashRadius }
			};
			return new LocalizedString("GameplayEffects", "GE_stackConsumerDamage_description").GetLocalizedString(dictionary);
		}
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_StacksConsumerDamage();
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
