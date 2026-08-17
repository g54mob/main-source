using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Upgrades;
using Assets.Scripts.UI.HUD;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups;

public class TomeUtility
{
	private static float balanceTomeValue = 0.015f;

	private static float chaosTomeMultiplier = 1.4f;

	public unsafe static void CheckSpecialTomes(TomeData tomeData, ERarity rarity)
	{
		//IL_008f: Expected I, but got O
		//IL_0170: Expected O, but got Ref
		//IL_04a6: Expected F4, but got I4
		StatModifier statModifier;
		bool flag6 = default(bool);
		ScoreUi scoreUi;
		bool useSfx;
		bool isPositive;
		if (tomeData.eTome != ETome.Chaos)
		{
			if (tomeData.eTome != ETome.Gambler)
			{
				if (tomeData.eTome == ETome.Hoarder)
				{
					Vector3 randomSpawnPositionOnMap = SpawnPositions.GetRandomSpawnPositionOnMap();
					nint num = (nint)typeof(SpawnPositions);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rax_v51 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
					nint num2 = 0;
					float num3 = randomSpawnPositionOnMap.x - (float)SpawnPositions.INVALID_POS;
					float num4 = randomSpawnPositionOnMap.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v31 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
					float num5 = num4 - 0f;
					float num6 = randomSpawnPositionOnMap.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v31 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
					float num7 = num6 - 0f;
					float num8 = num5 * num5;
					float num9 = num7 * num7;
					float num10 = num3 * num3;
					float num11 = num8 + num10;
					float num12 = num11 + num9;
					if (!(9.9999994E-11f > num12))
					{
						EffectManager instance = EffectManager.Instance;
						object obj = default(object);
						EffectManager.Instance.SpawnChest(instance.openChestNormal, (Vector3)(&obj));
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					}
				}
				return;
			}
			List<EncounterOffer> randomStatOffers = EncounterUtility.GetRandomStatOffers(1);
			EncounterOffer encounterOffer = randomStatOffers.get_Item(0);
			EffectStat[] effects = encounterOffer.effects;
			EffectStat effectStat = effects[0];
			statModifier = effectStat.statModifier;
			float rarityValue = StatUtility.GetRarityValue(statModifier.modification *= 1.5f, rarity, 3);
			statModifier.modification = rarityValue;
			bool flag = (nint)MyRandom.random < 0;
			bool flag2 = MyRandom.random == null;
			double num13 = MyRandom.random.NextDouble();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [18262EF48h]\"");
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			if (!flag5)
			{
				float modification = statModifier.modification * -1f;
				statModifier.modification = modification;
			}
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			inventory.statInventory.ChangeStat(statModifier, permanent: true, 0f, flag6);
			UiManager instance3 = UiManager.Instance;
			scoreUi = instance3.scoreUi;
			useSfx = true;
			isPositive = flag5;
		}
		else
		{
			List<EncounterOffer> randomStatOffers2 = EncounterUtility.GetRandomStatOffers(1, forceLegendary: false, useShrineStats: false);
			EncounterOffer encounterOffer2 = randomStatOffers2.get_Item(0);
			EffectStat[] effects2 = encounterOffer2.effects;
			EffectStat effectStat2 = effects2[0];
			statModifier = effectStat2.statModifier;
			float rarityValue2 = StatUtility.GetRarityValue(statModifier.modification *= chaosTomeMultiplier, rarity, 3);
			statModifier.modification = rarityValue2;
			MyPlayer instance4 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance4.inventory;
			inventory2.statInventory.ChangeStat(statModifier, permanent: true, 0f, flag6);
			UiManager instance5 = UiManager.Instance;
			scoreUi = instance5.scoreUi;
			useSfx = true;
			isPositive = true;
		}
		scoreUi.AddScore(statModifier, isPositive, useSfx, flag6 ? 1 : 0);
	}

	public unsafe static string GetUpgradeDescription(TomeData tomeData, ERarity rarity)
	{
		//IL_0030: Expected O, but got Ref
		if (tomeData.eTome != ETome.Balance)
		{
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			return "No description for: " + text;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		float rarityValue = StatUtility.GetRarityValue(balanceTomeValue, rarity, 3);
		float num = rarityValue * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"+{arg}%";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value", (object)value);
			return LocalizationUtility.GetLocalizedString("Tomes", "TOME_BALANCE_DESC", dictionary);
		}
		return (string)(object)new NullReferenceException();
	}
}
