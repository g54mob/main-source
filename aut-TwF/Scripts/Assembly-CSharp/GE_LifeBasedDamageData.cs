using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_LifeBasedDamageData_default", menuName = "Tower Factory/GameplayEffect/TowerEffects/Life Based Damage")]
public class GE_LifeBasedDamageData : GameplayEffectData
{
	public enum EMode
	{
		LessThan = 0,
		MoreThan = 1
	}

	[Header("Life Based Damage")]
	[SerializeField]
	private float enemyLifePercentageTreshold = 0.5f;

	[SerializeField]
	private EMode tresholdMode;

	[SerializeField]
	private float damageMultipler = 1f;

	public EMode TresholdMode => tresholdMode;

	public float EnemyLifePercentageTreshold => enemyLifePercentageTreshold;

	public float DamageMultipler => damageMultipler;

	public override string DisplayName
	{
		get
		{
			if (tresholdMode == EMode.LessThan)
			{
				return LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_lifeBasedDamage_lessThan_name").Entry.GetLocalizedString();
			}
			return LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_lifeBasedDamage_moreThan_name").Entry.GetLocalizedString();
		}
	}

	public override string Description
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					"treshold-mode",
					(int)tresholdMode
				},
				{
					"treshold",
					Mathf.RoundToInt(enemyLifePercentageTreshold * 100f)
				},
				{
					"multiplier",
					Mathf.RoundToInt((damageMultipler - 1f) * 100f)
				}
			};
			return new LocalizedString("GameplayEffects", "GE_lifeBasedDamage_description").GetLocalizedString(dictionary);
		}
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_LifeBasedDamage();
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
