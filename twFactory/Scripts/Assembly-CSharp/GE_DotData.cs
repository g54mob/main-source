using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_dotData_default", menuName = "Tower Factory/GameplayEffect/EnemiesEffects/DOT")]
public class GE_DotData : GameplayEffectData
{
	[Header("DOT")]
	[SerializeField]
	private EDamageMultiplier healthMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private EDamageMultiplier armorMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private EDamageMultiplier shieldMultiplier = EDamageMultiplier.Normal;

	[SerializeField]
	private int damagePerStack = 1;

	private int stacksPerTick = 1;

	public EDamageMultiplier HealthMultiplier => healthMultiplier;

	public EDamageMultiplier ArmorMultiplier => armorMultiplier;

	public EDamageMultiplier ShieldMultiplier => shieldMultiplier;

	public int DamagePerStack => damagePerStack;

	public int StacksPerTick
	{
		get
		{
			return stacksPerTick;
		}
		set
		{
			stacksPerTick = value;
			base.StacksToRemove = stacksPerTick;
		}
	}

	public override string Description
	{
		get
		{
			string text = string.Format(LocalizationSettings.StringDatabase.GetTableEntry("GameplayEffects", "GE_dot_description").Entry.GetLocalizedString(), stacksPerTick, damagePerStack);
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_health").Entry.GetLocalizedString();
			string localizedString2 = LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_armor").Entry.GetLocalizedString();
			string localizedString3 = LocalizationSettings.StringDatabase.GetTableEntry("Stats", "Stat_shield").Entry.GetLocalizedString();
			if (HealthMultiplier > EDamageMultiplier.Normal)
			{
				list.Add(localizedString);
			}
			else
			{
				list2.Add(localizedString);
			}
			if (ArmorMultiplier > EDamageMultiplier.Normal)
			{
				list.Add(localizedString2);
			}
			else
			{
				list2.Add(localizedString2);
			}
			if (ShieldMultiplier > EDamageMultiplier.Normal)
			{
				list.Add(localizedString3);
			}
			else
			{
				list2.Add(localizedString3);
			}
			string localizedString4 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_goodAgainst").Entry.GetLocalizedString();
			text = text + "\n" + localizedString4;
			for (int i = 0; i < list.Count; i++)
			{
				text = text + " " + list[i];
				if (i < list.Count - 1)
				{
					text += ",";
				}
			}
			return text;
		}
	}

	private void OnValidate()
	{
		base.HasTickTime = false;
		base.MaxStacks = 0;
		base.HasDuration = true;
		base.Duration = 1f;
		base.RefreshDurationOnAddStacks = false;
		base.EndDurationPolicy = EEndDurationPolicy.RemoveStacks;
		base.StacksToRemove = stacksPerTick;
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_Dot();
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowMaxStacksInInspector()
	{
		return false;
	}
}
