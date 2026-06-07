using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_slowResistanceData_default", menuName = "Tower Factory/GameplayEffect/EnemiesEffects/Slow Resistance")]
public class GE_SlowResistanceData : GameplayEffectData
{
	[Header("Slow Resistance")]
	[SerializeField]
	private float slowMultiplier = 1f;

	[SerializeField]
	private float slowDurationMultiplier = 1f;

	public float SlowMultiplier => slowMultiplier;

	public float SlowDurationMultiplier => slowDurationMultiplier;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetLocalizedString("GameplayEffects", "GE_slowResistance_name", null, FallbackBehavior.UseProjectSettings);

	public override string Description
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					"slow-multiplier",
					Mathf.RoundToInt((1f - slowMultiplier) * 100f)
				},
				{
					"duration-multiplier",
					Mathf.RoundToInt((1f - SlowDurationMultiplier) * 100f)
				}
			};
			return new LocalizedString("GameplayEffects", "GE_slowResistance_description").GetLocalizedString(dictionary);
		}
	}

	private void OnValidate()
	{
		base.HasTickTime = false;
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_SlowResistance();
	}

	protected override bool ShowNameInInspector()
	{
		return false;
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}
}
