using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Upgrades;
using Assets.Scripts.UI.InGame.Rewards;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityGamba : PassiveAbility
{
	private float upgradeMultiplier = 0.75f;

	private float minMultiplier = 0.06f;

	private float maxMultiplier = 1f;

	private int currentLevel;

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<int> b = OnLevelup;
		Delegate obj = Delegate.Combine(PlayerXp.A_LevelUp, b);
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		if (action != null)
		{
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Tick()
	{
	}

	private void OnLevelup(int level)
	{
		//IL_01ca: Expected F4, but got I4
		//IL_01d2: Expected I4, but got O
		if (currentLevel >= level)
		{
			return;
		}
		int num = level;
		PassiveAbilityGamba passiveAbilityGamba = this;
		bool flag = default(bool);
		do
		{
			float num2 = (float)currentLevel / 50f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
			float num3 = num2 + 1f;
			float num4 = 1f / num3;
			float num5 = num4 * upgradeMultiplier;
			if (!(minMultiplier > num5))
			{
				if (num5 > maxMultiplier)
				{
					num5 = maxMultiplier;
				}
			}
			else
			{
				num5 = minMultiplier;
			}
			List<EncounterOffer> randomStatOffers = EncounterUtility.GetRandomStatOffers(1, forceLegendary: false, useShrineStats: false);
			EncounterOffer encounterOffer = randomStatOffers.get_Item(0);
			EffectStat[] effects = encounterOffer.effects;
			EffectStat effectStat = effects[0];
			StatModifier statModifier = effectStat.statModifier;
			float rarityValue = StatUtility.GetRarityValue(statModifier.modification, ERarity.Common, 3);
			float modification = rarityValue * num5;
			statModifier.modification = modification;
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			inventory.statInventory.ChangeStat(statModifier, permanent: true, 0f, flag);
			UiManager instance2 = UiManager.Instance;
			int queueCount = instance2.scoreUi.GetQueueCount();
			bool flag2 = queueCount >= 10;
			num = 0;
			nint num6 = 1;
			bool flag3 = false;
			passiveAbilityGamba = (PassiveAbilityGamba)(object)instance2.scoreUi;
			if (!flag2)
			{
				UiManager instance3 = UiManager.Instance;
				instance3.scoreUi.AddScore(statModifier, isPositive: true, useSfx: true, flag ? 1 : 0);
				num = (int)statModifier;
				num6 = 1;
				flag3 = true;
				passiveAbilityGamba = (PassiveAbilityGamba)(object)instance3.scoreUi;
			}
		}
		while (++currentLevel < level);
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<int> value = OnLevelup;
		Delegate obj = Delegate.Remove(PlayerXp.A_LevelUp, value);
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		if (action != null)
		{
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Gamba;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		if (localizedString != null)
		{
			return localizedString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}
}
