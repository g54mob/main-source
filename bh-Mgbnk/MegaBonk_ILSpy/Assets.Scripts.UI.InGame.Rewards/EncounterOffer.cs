using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.UI.InGame.Rewards.Effects;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.UI.InGame.Rewards;

[Serializable]
public class EncounterOffer
{
	public ERarity rarity;

	public EffectStat[] effects;

	public string GetEffectsDescription()
	{
		//IL_00df: Expected O, but got I4
		//IL_00e8: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01f4: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317253B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		EffectStat[] array = effects;
		if (array.Length > 0)
		{
			EffectStat effectStat = array[0];
			string text2;
			if (effectStat.effectType == EEncounterEffect.StatChangeBalanceShrine)
			{
				string localizedString = LocalizationUtility.GetLocalizedString("Game_Ui", "BALANCE_SHRINE_TEXT");
				string text = localizedString + "\n\n";
				text2 = text;
			}
			else
			{
				text2 = "";
			}
			EffectStat[] array2 = effects;
			object obj = 0;
			object obj2 = 1;
			object obj3 = 0;
			while (true)
			{
				if ((nint)obj3 < array2.Length)
				{
					if ((nint)obj >= array2.Length)
					{
						break;
					}
					string text3;
					string text4;
					if (obj2 == null)
					{
						string description = array2[obj].GetDescription();
						text3 = description;
						text4 = "\n";
					}
					else
					{
						string description2 = array2[obj].GetDescription();
						text3 = "\n";
						text4 = description2;
					}
					string text5 = text2 + text4 + text3;
					obj++;
					text2 = text5;
					obj2 = 0;
					obj3 = obj;
					continue;
				}
				return text2;
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public void ApplyEffects(bool showInScoreUi = true)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		EffectStat[] array = effects;
		object obj = 0;
		object obj2 = 0;
		bool useSfx = default(bool);
		float sizeMultiplier = default(float);
		while ((nint)obj2 < array.Length)
		{
			EffectStat effectStat = array[obj];
			array[obj].ApplyEffect();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172535]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string text;
			if (effectStat.effectType != EEncounterEffect.StatChange)
			{
				text = "";
			}
			else
			{
				StatModifier statModifier = effectStat.statModifier;
				string text2 = EnumUtility.EnumToReadable(statModifier.stat);
				bool flag = text2 == null;
				text = "";
				if (!flag)
				{
					text = text2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172534]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string statTextColor = MyColorUtility.GetStatTextColor(effectStat.isPositiveEffect);
			string text3;
			string text4;
			if (effectStat.effectType != EEncounterEffect.StatChange)
			{
				text3 = "";
				text4 = "";
			}
			else
			{
				string modificationString = StatUtility.GetModificationString(effectStat.statModifier);
				string text5 = StatUtility.EncapsulateNumber(modificationString, statTextColor);
				bool flag2 = text5 == null;
				text3 = "";
				text4 = "";
				if (!flag2)
				{
					text3 = "";
					text4 = text5;
				}
			}
			if ((!(text4 == text3) || !(text == "")) && showInScoreUi)
			{
				UiManager instance = UiManager.Instance;
				instance.scoreUi.AddScore(text, text4, isPositive: true, useSfx, sizeMultiplier);
			}
			obj++;
			obj2 = obj;
		}
	}

	public unsafe bool CanAccept(out string reason)
	{
		//IL_003c: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_0295: Expected I4, but got O
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0094: Invalid comparison between I4 and F4
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0185: Invalid comparison between I4 and F4
		//IL_00d6: Expected O, but got F4
		//IL_00e3: Invalid comparison between F4 and O
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected I4, but got Unknown
		//IL_0202: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317253D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ref string reference = ref *(string*)"";
		EffectStat[] array = effects;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			bool flag = (nint)obj2 >= array.Length;
			bool result = true;
			if (!flag)
			{
				if ((nint)obj >= array.Length)
				{
					break;
				}
				EffectStat effectStat = array[obj];
				bool flag3;
				object obj4;
				if (effectStat.effectType == EEncounterEffect.EGold)
				{
					if (!(0f > effectStat.value))
					{
						goto IL_0239;
					}
					MyPlayer instance = MyPlayer.Instance;
					PlayerInventory inventory = instance.inventory;
					object obj3 = effectStat.value ^ -0f;
					float num = inventory._003Cgold_003Ek__BackingField;
					bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
					flag3 = !flag2;
					obj4 = "Not enough gold";
				}
				else
				{
					if (effectStat.effectType != EEncounterEffect.EHealth)
					{
						goto IL_0239;
					}
					MyPlayer instance2 = MyPlayer.Instance;
					PlayerInventory inventory2 = instance2.inventory;
					PlayerHealth playerHealth = inventory2.playerHealth;
					int maxHp = playerHealth.maxHp;
					float value = effectStat.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					object obj5 = value & 0;
					if (!(0f > effectStat.value))
					{
						goto IL_0239;
					}
					MyPlayer instance3 = MyPlayer.Instance;
					PlayerInventory inventory3 = instance3.inventory;
					PlayerHealth playerHealth2 = inventory3.playerHealth;
					maxHp *= obj5;
					bool flag4 = playerHealth2.hp < maxHp;
					float num2 = (float)playerHealth2.hp - (float)maxHp;
					bool flag5 = num2 == 0f;
					bool flag6 = !flag4;
					bool flag7 = !flag5;
					flag3 = flag7 & flag6;
					obj4 = "Not enough HP";
				}
				if (flag3)
				{
					goto IL_0239;
				}
				reference = ref *(string*)obj4;
				result = false;
			}
			return result;
			IL_0239:
			obj++;
			obj2 = obj;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}
}
