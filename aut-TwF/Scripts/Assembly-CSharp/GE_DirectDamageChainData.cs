using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_directDamageChainData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/Direct Damage Chain")]
public class GE_DirectDamageChainData : GameplayEffectData
{
	[Header("Direct Damage Chain")]
	[SerializeField]
	[Min(0f)]
	private int chainAmount;

	[SerializeField]
	private float chainRadius = 1f;

	[SerializeField]
	private float chainDamageMultiplier = 1f;

	[SerializeField]
	private DirectDamageParticles directDamageParticlesPrefab;

	public int ChainAmount => chainAmount;

	public float ChainRadius => chainRadius;

	public float ChainDamageMultiplier => chainDamageMultiplier;

	public DirectDamageParticles DirectDamageParticlesPrefab => directDamageParticlesPrefab;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetLocalizedString("GameplayEffects", "GE_directDamageChain_name", null, FallbackBehavior.UseProjectSettings);

	public override string Description
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "chain-amount", ChainAmount },
				{
					"damage-multiplier",
					(int)(ChainDamageMultiplier * 100f)
				}
			};
			return new LocalizedString("GameplayEffects", "GE_directDamageChain_description").GetLocalizedString(dictionary);
		}
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_DirectDamageChain();
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
