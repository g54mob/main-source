using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class CharacterSkillCard_RandomGenerator
{
	public enum STATNAME
	{
		Amount,
		Area,
		Armor,
		Cooldown,
		Banish,
		Charm,
		Curse,
		Defang,
		Duration,
		Fever,
		Greed,
		Growth,
		InvulTimeBonus,
		Luck,
		Magnet,
		MaxHp,
		MoveSpeed,
		Power,
		Recycle,
		Regen,
		ReRolls,
		Revivals,
		Shroud,
		Skips,
		Speed
	}

	public struct WeightedArcana
	{
		public ArcanaData data;

		public float weight;
	}

	public static Dictionary<STATNAME, float[]> StatBonuses;

	public static Dictionary<STATNAME, float[]> StatPerLevelGrowth;

	private static Array StatNameValues;

	private static bool IsInitialised;

	public static int TotalWeight;

	private static List<WeightedArcana> _003CWeightedSurvarots_003Ek__BackingField;

	public static List<ArcanaType> SubSkills_Foil;

	public static List<ArcanaType> SubSkills_All;

	public static List<ArcanaType> SubSkills_AddWeapon;

	public static List<ArcanaType> SubSkills_XLevel;

	public static List<ArcanaType> SubSkills_OnSkip;

	public static List<ArcanaType> SubSkills_EnemiesCount;

	public static List<ArcanaType> SubSkills_OnDamaged;

	public static List<ArcanaType> SubSkills_OnRevive;

	public static List<ArcanaType> SubSkills_Passives;

	public static List<ArcanaType> SubSkills_GoldCount;

	public static List<ArcanaType> SubSkills_Overheal;

	public static List<ArcanaType> SubSkills_HPCritical;

	public static int NUM_SET_DEFAULT;

	public static int NUM_SET_EXPANSION1;

	public static List<WeightedArcana> WeightedSurvarots
	{
		get
		{
			return _003CWeightedSurvarots_003Ek__BackingField;
		}
		set
		{
			_003CWeightedSurvarots_003Ek__BackingField = value;
		}
	}

	public static void Init()
	{
		//IL_0013: Expected I, but got O
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007b: Expected O, but got I
		nint num = (nint)typeof(STATNAME);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (num != 0)
		{
			object obj3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v130 @ rdx_v4+8F8] (should have been resolved before IL gen)");
			Array statNameValues = default(Array);
			StatNameValues = statNameValues;
			IsInitialised = true;
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		throw ex;
	}

	public static void GetRandomModifierStat(ModifierStats stats, bool isGrowthValue = false)
	{
		//IL_00f8: Expected O, but got I4
		//IL_0081: Expected F4, but got I
		if (!IsInitialised)
		{
			Init();
		}
		int length = StatNameValues.Length;
		System.Int32Enum int32Enum = (System.Int32Enum)UnityEngine.Random.RandomRangeInt(0, length);
		object obj = UnityEngine.Random.RandomRangeInt(0, 5);
		Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(object)(isGrowthValue ? StatPerLevelGrowth : StatBonuses);
		bool flag = dictionary.TryGetValue(int32Enum, out var value);
		if (value != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ stack_20_v3 (System.Object)+20+v255 @ rax_v23*4]");
			ChangeStats(stats, (STATNAME)int32Enum, 0f);
		}
	}

	public static void GetRandomModifierGrowth(ModifierStats stats)
	{
		GetRandomModifierStat(stats, isGrowthValue: true);
	}

	public static void ChangeStats(ModifierStats stats, STATNAME converted, float bonusAmount)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (converted <= STATNAME.Speed)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r8_v1+7575150+converted @ rdx (VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator+STATNAME)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rdx_v2 (should have been resolved before IL gen)");
		}
	}

	public static List<int> GetRandomLevelProgression()
	{
		//IL_0036: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_0f75: Expected O, but got I
		//IL_0125: Expected O, but got I
		//IL_0172: Expected I4, but got O
		//IL_01a9: Expected O, but got I
		//IL_0203: Expected O, but got I
		//IL_0fab: Expected O, but got I
		//IL_0297: Expected O, but got I
		//IL_0fd3: Expected O, but got I
		//IL_032c: Expected O, but got I
		//IL_0fe5: Expected I4, but got O
		//IL_038f: Expected O, but got I
		//IL_03e9: Expected O, but got I
		//IL_1017: Expected O, but got I
		//IL_047d: Expected O, but got I
		//IL_103f: Expected O, but got I
		//IL_0511: Expected O, but got I
		//IL_1067: Expected O, but got I
		//IL_05a5: Expected O, but got I
		//IL_108f: Expected O, but got I
		//IL_063a: Expected O, but got I
		//IL_10a1: Expected I4, but got O
		//IL_069d: Expected O, but got I
		//IL_06f7: Expected O, but got I
		//IL_10d3: Expected O, but got I
		//IL_078c: Expected O, but got I
		//IL_10e5: Expected I4, but got O
		//IL_07ef: Expected O, but got I
		//IL_0849: Expected O, but got I
		//IL_1117: Expected O, but got I
		//IL_08dd: Expected O, but got I
		//IL_113f: Expected O, but got I
		//IL_0972: Expected O, but got I
		//IL_1151: Expected I4, but got O
		//IL_09d5: Expected O, but got I
		//IL_0a2f: Expected O, but got I
		//IL_1183: Expected O, but got I
		//IL_0ac3: Expected O, but got I
		//IL_11ab: Expected O, but got I
		//IL_0b57: Expected O, but got I
		//IL_11d3: Expected O, but got I
		//IL_0beb: Expected O, but got I
		//IL_11fb: Expected O, but got I
		//IL_0c80: Expected O, but got I
		//IL_120d: Expected I4, but got O
		//IL_0ce3: Expected O, but got I
		//IL_0d3d: Expected O, but got I
		//IL_123f: Expected O, but got I
		//IL_0dd1: Expected O, but got I
		//IL_1267: Expected O, but got I
		//IL_0e65: Expected O, but got I
		//IL_128f: Expected O, but got I
		//IL_0efa: Expected O, but got I
		//IL_12a1: Expected I4, but got O
		List<List<int>> list = new List<List<int>>();
		List<int> list2 = new List<int>();
		list2._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v5+18]");
		if (num >= 0)
		{
			list2.AddWithResize(5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v5+18]");
			if (num2 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v7+18]");
		if (num3 >= 0)
		{
			list2.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v7+18]");
			if (num4 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 10;
		}
		((List<int>)(object)list).Add((int)list2);
		List<int> list3 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v11+18]");
		if (num5 >= 0)
		{
			list3.AddWithResize(5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v11+18]");
			if (num6 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v13+18]");
		if (num7 >= 0)
		{
			list3.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v13+18]");
			if (num8 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v15+18]");
		if (num9 >= 0)
		{
			list3.AddWithResize(15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v15+18]");
			if (num10 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 15;
		}
		((List<int>)(object)list).Add((int)list3);
		List<int> list4 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v19+18]");
		if (num11 >= 0)
		{
			list4.AddWithResize(5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v19+18]");
			if (num12 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v21+18]");
		if (num13 >= 0)
		{
			list4.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v21+18]");
			if (num14 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v14+18]");
		if (num15 >= 0)
		{
			list4.AddWithResize(15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v14+18]");
			if (num16 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v25+18]");
		if (num17 >= 0)
		{
			list4.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v25+18]");
			if (num18 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v27+18]");
		if (num19 >= 0)
		{
			list4.AddWithResize(25);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj20 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v27+18]");
			if (num20 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 25;
		}
		((List<int>)(object)list).Add((int)list4);
		List<int> list5 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v31+18]");
		if (num21 >= 0)
		{
			list5.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj22 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v31+18]");
			if (num22 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v33+18]");
		if (num23 >= 0)
		{
			list5.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj24 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ rax_v30 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v33+18]");
			if (num24 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 20;
		}
		((List<int>)(object)list).Add((int)list5);
		List<int> list6 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v37+18]");
		if (num25 >= 0)
		{
			list6.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj26 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v37+18]");
			if (num26 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v39+18]");
		if (num27 >= 0)
		{
			list6.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj28 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v39+18]");
			if (num28 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v41+18]");
		if (num29 >= 0)
		{
			list6.AddWithResize(30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj30 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1269 @ rax_v36 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v41+18]");
			if (num30 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 30;
		}
		((List<int>)(object)list).Add((int)list6);
		List<int> list7 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v45+18]");
		if (num31 >= 0)
		{
			list7.AddWithResize(10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj32 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v45+18]");
			if (num32 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v47+18]");
		if (num33 >= 0)
		{
			list7.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj34 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v47+18]");
			if (num34 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r8_v31+18]");
		if (num35 >= 0)
		{
			list7.AddWithResize(30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj36 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r8_v31+18]");
			if (num36 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v51+18]");
		if (num37 >= 0)
		{
			list7.AddWithResize(40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj38 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num38 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v51+18]");
			if (num38 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v53+18]");
		if (num39 >= 0)
		{
			list7.AddWithResize(50);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj40 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ rax_v43 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num40 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v53+18]");
			if (num40 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 50;
		}
		((List<int>)(object)list).Add((int)list7);
		List<int> list8 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r8_v37+18]");
		if (num41 >= 0)
		{
			list8.AddWithResize(20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj42 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r8_v37+18]");
			if (num42 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r8_v39+18]");
		if (num43 >= 0)
		{
			list8.AddWithResize(40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj44 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r8_v39+18]");
			if (num44 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v60+18]");
		if (num45 >= 0)
		{
			list8.AddWithResize(60);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj46 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num46 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v60+18]");
			if (num46 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 60;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v62+18]");
		if (num47 >= 0)
		{
			list8.AddWithResize(80);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj48 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rax_v52 (System.Collections.Generic.List`1<System.Int32>)+18]");
			nint num48 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v62+18]");
			if (num48 >= 0)
			{
				goto IL_0f7a;
			}
			_ = 80;
		}
		((List<int>)(object)list).Add((int)list8);
		return Extensions.PickRnd(list);
		IL_0f7a:
		return (List<int>)(object)new IndexOutOfRangeException();
	}

	public static ArcanaType GetRandomSubCard()
	{
		return Extensions.PickRnd(SubSkills_All);
	}

	public static ArcanaType GetRandomSubCard(List<ArcanaType> list)
	{
		return Extensions.PickRnd(list);
	}

	public unsafe static ArcanaType GetOneSurvarotFromWeightedList(List<ArcanaType> exclusions, ref Unity.Mathematics.Random random)
	{
		//IL_00a8: Expected O, but got I
		//IL_03ca: Expected I, but got O
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Expected O, but got Unknown
		//IL_0536: Expected I, but got O
		//IL_014c: Expected O, but got I4
		//IL_05df: Expected O, but got I
		//IL_029c: Expected O, but got I
		//IL_037e: Expected O, but got I4
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02cc: Expected O, but got I
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Expected O, but got Unknown
		//IL_0561: Invalid comparison between O and F4
		//IL_0324: Expected I4, but got I8
		List<WeightedArcana> list = _003CWeightedSurvarots_003Ek__BackingField;
		if (_003CWeightedSurvarots_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator+WeightedArcana>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator+WeightedArcana>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator+WeightedArcana>)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator+WeightedArcana>)+18]");
				Array.Clear((Array)num, 0, 0);
			}
		}
		List<WeightedArcana> list2 = new List<WeightedArcana>();
		_003CWeightedSurvarots_003Ek__BackingField = list2;
		TotalWeight = 0;
		nint num2 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v17 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num3 = 0;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			DataManager dataManager = core._dataManager;
			if (core._dataManager != null && dataManager._003CAllArcanas_003Ek__BackingField != null)
			{
				Dictionary<ArcanaType, ArcanaData>.Enumerator enumerator = (Dictionary<ArcanaType, ArcanaData>.Enumerator)dataManager._003CAllArcanas_003Ek__BackingField;
				Dictionary<ArcanaType, ArcanaData>.Enumerator enumerator2 = default(Dictionary<ArcanaType, ArcanaData>.Enumerator);
				if (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj = 0;
					num3 = (nint)(&enumerator2);
					throw new NullReferenceException();
				}
				object obj2 = (object)random << 13;
				object obj3 = obj2 ^ (object)random;
				object obj4 = obj3 >> 17;
				object obj5 = obj4 ^ obj3;
				object obj6 = obj5 << 5;
				object obj7 = obj6 ^ obj5;
				ref Unity.Mathematics.Random reference = ref *(Unity.Mathematics.Random*)obj7;
				object obj8 = (object)random >> 9;
				object obj9 = obj8 | 0x3F800000;
				float num4 = (float)obj9 - 1f;
				nint num5 = (nint)typeof(CharacterSkillCard_RandomGenerator);
				float num6 = (float)TotalWeight * num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1080 @ rcx_v36 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterSkillCard_RandomGenerator>)+B8]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v59+20]");
				if ((nint)0 != 0)
				{
					object obj12 = default(object);
					object obj11 = obj12;
					object obj14 = default(object);
					object obj13 = obj14;
					object obj15 = default(object);
					object obj21 = default(object);
					while (true)
					{
						if (obj13 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rcx_v45+1C]");
							if (obj15 == null)
							{
								object obj16 = obj11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rcx_v45+18]");
								if ((nint)obj16 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rcx_v45+10]");
									object obj17 = 0;
									object obj18 = obj11 + 2;
									object obj19 = obj18 + obj18;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ r8_v22+v1609 @ rax_v75*8]");
									object obj20 = 0;
									obj11++;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj21) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1610 @ xmm0_v22+10]");
										return ArcanaType.T00_KILLER;
									}
									continue;
								}
								break;
							}
							break;
						}
						throw new NullReferenceException();
					}
					if (obj13 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rcx_v45+1C]");
						if (obj15 == null)
						{
							return ArcanaType.VOID;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						obj13 = 0;
					}
					throw new NullReferenceException();
				}
			}
		}
		throw new NullReferenceException();
	}

	public static List<ArcanaType> GetWeightedSurvarots(int cardsNumber, ref Unity.Mathematics.Random random)
	{
		//IL_00c1: Expected O, but got I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		List<ArcanaType> list = new List<ArcanaType>();
		bool flag = cardsNumber <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				ArcanaType oneSurvarotFromWeightedList = GetOneSurvarotFromWeightedList(list, ref random);
				if (oneSurvarotFromWeightedList != ArcanaType.VOID)
				{
					if (list == null)
					{
						return (List<ArcanaType>)(object)new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97710");
				}
				obj++;
			}
			while ((nint)obj < cardsNumber);
		}
		return list;
	}

	static CharacterSkillCard_RandomGenerator()
	{
		//IL_0b9e: Expected O, but got I
		//IL_0bae: Expected O, but got I
		//IL_0c08: Expected O, but got I
		//IL_198a: Expected O, but got I
		//IL_199a: Expected O, but got I
		//IL_0c72: Expected O, but got I
		//IL_19c2: Expected O, but got I
		//IL_19d2: Expected O, but got I
		//IL_0cdc: Expected O, but got I
		//IL_19fa: Expected O, but got I
		//IL_1a0a: Expected O, but got I
		//IL_0d46: Expected O, but got I
		//IL_1a32: Expected O, but got I
		//IL_1a42: Expected O, but got I
		//IL_0db0: Expected O, but got I
		//IL_1a6a: Expected O, but got I
		//IL_1a7a: Expected O, but got I
		//IL_0e1a: Expected O, but got I
		//IL_1aa2: Expected O, but got I
		//IL_1ab2: Expected O, but got I
		//IL_0e84: Expected O, but got I
		//IL_1ada: Expected O, but got I
		//IL_1aea: Expected O, but got I
		//IL_0eee: Expected O, but got I
		//IL_1b12: Expected O, but got I
		//IL_1b22: Expected O, but got I
		//IL_0f58: Expected O, but got I
		//IL_1b4a: Expected O, but got I
		//IL_1b5a: Expected O, but got I
		//IL_0fc3: Expected O, but got I
		//IL_1731: Expected O, but got I
		//IL_1741: Expected O, but got I
		//IL_179b: Expected O, but got I
		//IL_17e2: Expected O, but got I
		//IL_17f2: Expected O, but got I
		//IL_184c: Expected O, but got I
		//IL_1bbf: Expected O, but got I
		//IL_1bcf: Expected O, but got I
		//IL_18b6: Expected O, but got I
		//IL_1bf7: Expected O, but got I
		//IL_1c07: Expected O, but got I
		//IL_1920: Expected O, but got I
		Dictionary<STATNAME, float[]> dictionary = new Dictionary<STATNAME, float[]>();
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, (object)new float[5] { 1f, 2f, 3f, 4f, 5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)1, (object)new float[5] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)2, (object)new float[5] { 1f, 2f, 3f, 4f, 5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)3, (object)new float[5] { -0.05f, -0.1f, -0.15f, -0.2f, -0.25f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)4, (object)new float[5] { 3f, 6f, 9f, 12f, 15f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)5, (object)new float[5] { 20f, 40f, 60f, 80f, 100f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)6, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)9, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag9 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)8, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag10 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)10, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag11 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)11, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag12 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)12, (object)new float[5] { 20f, 40f, 60f, 80f, 100f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag13 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)13, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag14 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)14, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag15 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)15, (object)new float[5] { 20f, 40f, 60f, 80f, 100f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag16 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)16, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag17 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)17, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag18 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)18, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag19 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)21, (object)new float[5] { 1f, 2f, 3f, 4f, 5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag20 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)19, (object)new float[5] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag21 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)20, (object)new float[5] { 3f, 6f, 9f, 12f, 15f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag22 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)23, (object)new float[5] { 3f, 6f, 9f, 12f, 15f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag23 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)24, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		StatBonuses = dictionary;
		Dictionary<STATNAME, float[]> dictionary2 = new Dictionary<STATNAME, float[]>();
		bool flag24 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)0, (object)new float[5] { 0.1f, 2f, 3f, 4f, 5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag25 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)1, (object)new float[5] { 0.01f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag26 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)2, (object)new float[5] { 0.1f, 2f, 3f, 4f, 5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag27 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)3, (object)new float[5] { -0.01f, -10f, -15f, -20f, -25f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag28 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)4, (object)new float[5] { 3f, 6f, 9f, 12f, 15f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag29 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)5, (object)new float[5] { 20f, 40f, 60f, 80f, 100f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag30 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)6, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag31 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)9, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag32 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)8, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag33 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)10, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag34 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)11, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag35 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)12, (object)new float[5] { 20f, 40f, 60f, 80f, 100f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag36 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)13, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag37 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)14, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag38 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)15, (object)new float[5] { 20f, 40f, 60f, 80f, 100f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag39 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)16, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag40 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)17, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag41 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)18, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag42 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)21, (object)new float[5] { 1f, 2f, 3f, 4f, 5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag43 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)19, (object)new float[5] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag44 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)20, (object)new float[5] { 3f, 6f, 9f, 12f, 15f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag45 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)23, (object)new float[5] { 3f, 6f, 9f, 12f, 15f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag46 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)24, (object)new float[5] { 10f, 20f, 30f, 40f, 50f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		StatPerLevelGrowth = dictionary2;
		IsInitialised = false;
		TotalWeight = 0;
		List<ArcanaType> list = new List<ArcanaType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v200+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1200);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = 1200;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v202+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1201);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1201;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v204+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1202);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = 1202;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v206+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1203);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1203;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v208+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2000);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj15 = (nint)0 + (nint)1;
			_ = 2000;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v210+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2004);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 2004;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v212+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2002);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj21 = (nint)0 + (nint)1;
			_ = 2002;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v214+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2001);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 2001;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v216+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3001);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj27 = (nint)0 + (nint)1;
			_ = 3001;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v218+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3000);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1649 @ rax_v154 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 3000;
		}
		list.Add(ArcanaType.SUB_ONDAMAGED_ADDCOINS);
		list.Add(ArcanaType.SUB_ONDAMAGED_GROUNDHIT);
		list.Add(ArcanaType.SUB_PASSIVE_CRITICALUP);
		list.Add(ArcanaType.SUB_PASSIVE_CHARMUP);
		list.Add(ArcanaType.SUB_PASSIVE_DEFANGUP);
		list.Add(ArcanaType.SUB_PASSIVE_GUARDIANAURA);
		list.Add(ArcanaType.SUB_ENEMIESCOUNT_ADDREVIVES);
		list.Add(ArcanaType.SUB_ENEMIESCOUNT_ADDARMOR);
		list.Add(ArcanaType.SUB_ENEMIESCOUNT_ADDAMOUNT);
		list.Add(ArcanaType.SUB_ENEMIESCOUNT_ADDCOINS);
		list.Add(ArcanaType.SUB_ENEMIESCOUNT_GOLDFEVER);
		list.Add(ArcanaType.SUB_HPCRITICAL_FIREBREATH);
		list.Add(ArcanaType.SUB_HPCRITICAL_RECOVERHP);
		list.Add(ArcanaType.SUB_HPCRITICAL_MAXARMOR);
		list.Add(ArcanaType.SUB_OVERHEAL_ICEBREATH);
		list.Add(ArcanaType.SUB_OVERHEAL_MIGHTUP);
		list.Add(ArcanaType.SUB_OVERHEAL_FEVERUP);
		list.Add(ArcanaType.SUB_OVERHEAL_REROLLUP);
		list.Add(ArcanaType.SUB_GOLDCOUNT_LIGHTSOURCES);
		list.Add(ArcanaType.SUB_GOLDCOUNT_THORNSUP);
		list.Add(ArcanaType.SUB_GOLCOUNT_ADDREVIVES);
		list.Add(ArcanaType.SUB_GOLDCOUNT_ADDPASSIVESLOTS);
		SubSkills_Foil = list;
		SubSkills_All = new List<ArcanaType>
		{
			ArcanaType.SUB_ADDWEAPON_BONE2,
			ArcanaType.SUB_ADDWEAPON_CART2EVO,
			ArcanaType.SUB_ADDWEAPON_CHERRY2,
			ArcanaType.SUB_ADDWEAPON_FLOWER2,
			ArcanaType.SUB_SKIP_COOLDOWNDOWN,
			ArcanaType.SUB_SKIP_FULLRECOVERHP,
			ArcanaType.SUB_SKIP_ROSARY,
			ArcanaType.SUB_SKIP_TIMEFREEZE,
			ArcanaType.SUB_ONREVIVE_ROSARY,
			ArcanaType.SUB_ONREVIVE_CURSEDOWN,
			ArcanaType.SUB_ONREVIVE_RAPIDFIRE,
			ArcanaType.SUB_ONREVIVE_TIMEFREEZE,
			ArcanaType.SUB_ONREVIVE_VACUUM,
			ArcanaType.SUB_ONDAMAGED_RECOVERYUP,
			ArcanaType.SUB_ONDAMAGED_ARMORUP,
			ArcanaType.SUB_ONDAMAGED_ADDCOINS,
			ArcanaType.SUB_ONDAMAGED_GROUNDHIT,
			ArcanaType.SUB_PASSIVE_CRITICALUP,
			ArcanaType.SUB_PASSIVE_CHARMUP,
			ArcanaType.SUB_PASSIVE_DEFANGUP,
			ArcanaType.SUB_PASSIVE_GUARDIANAURA,
			ArcanaType.SUB_ENEMIESCOUNT_ADDREVIVES,
			ArcanaType.SUB_ENEMIESCOUNT_ADDARMOR,
			ArcanaType.SUB_ENEMIESCOUNT_ADDAMOUNT,
			ArcanaType.SUB_ENEMIESCOUNT_ADDCOINS,
			ArcanaType.SUB_ENEMIESCOUNT_GOLDFEVER,
			ArcanaType.SUB_HPCRITICAL_FIREBREATH,
			ArcanaType.SUB_HPCRITICAL_RECOVERHP,
			ArcanaType.SUB_HPCRITICAL_MAXARMOR,
			ArcanaType.SUB_OVERHEAL_ICEBREATH,
			ArcanaType.SUB_OVERHEAL_MIGHTUP,
			ArcanaType.SUB_OVERHEAL_FEVERUP,
			ArcanaType.SUB_OVERHEAL_REROLLUP,
			ArcanaType.SUB_GOLDCOUNT_LIGHTSOURCES,
			ArcanaType.SUB_GOLDCOUNT_THORNSUP,
			ArcanaType.SUB_GOLCOUNT_ADDREVIVES,
			ArcanaType.SUB_GOLDCOUNT_ADDPASSIVESLOTS
		};
		SubSkills_AddWeapon = new List<ArcanaType>
		{
			ArcanaType.SUB_ADDWEAPON_BONE2,
			ArcanaType.SUB_ADDWEAPON_CART2EVO,
			ArcanaType.SUB_ADDWEAPON_CHERRY2,
			ArcanaType.SUB_ADDWEAPON_FLOWER2
		};
		SubSkills_XLevel = new List<ArcanaType>
		{
			ArcanaType.SUB_XLEVEL_MAXHP5,
			ArcanaType.SUB_XLEVEL_GROWTH1,
			ArcanaType.SUB_XLEVEL_MIGHT1,
			ArcanaType.SUB_XLEVEL_SPEED1,
			ArcanaType.SUB_XLEVEL_DURATION1,
			ArcanaType.SUB_XLEVEL_AREA1
		};
		SubSkills_OnSkip = new List<ArcanaType>
		{
			ArcanaType.SUB_SKIP_COOLDOWNDOWN,
			ArcanaType.SUB_SKIP_FULLRECOVERHP,
			ArcanaType.SUB_SKIP_ROSARY,
			ArcanaType.SUB_SKIP_TIMEFREEZE
		};
		SubSkills_EnemiesCount = new List<ArcanaType>
		{
			ArcanaType.SUB_ENEMIESCOUNT_ADDREVIVES,
			ArcanaType.SUB_ENEMIESCOUNT_ADDARMOR,
			ArcanaType.SUB_ENEMIESCOUNT_ADDAMOUNT,
			ArcanaType.SUB_ENEMIESCOUNT_ADDCOINS,
			ArcanaType.SUB_ENEMIESCOUNT_GOLDFEVER
		};
		SubSkills_OnDamaged = new List<ArcanaType>
		{
			ArcanaType.SUB_ONDAMAGED_RECOVERYUP,
			ArcanaType.SUB_ONDAMAGED_ARMORUP,
			ArcanaType.SUB_ONDAMAGED_ADDCOINS,
			ArcanaType.SUB_ONDAMAGED_GROUNDHIT
		};
		SubSkills_OnRevive = new List<ArcanaType>
		{
			ArcanaType.SUB_ONREVIVE_ROSARY,
			ArcanaType.SUB_ONREVIVE_CURSEDOWN,
			ArcanaType.SUB_ONREVIVE_RAPIDFIRE,
			ArcanaType.SUB_ONREVIVE_TIMEFREEZE,
			ArcanaType.SUB_ONREVIVE_VACUUM
		};
		SubSkills_Passives = new List<ArcanaType>
		{
			ArcanaType.SUB_PASSIVE_CRITICALUP,
			ArcanaType.SUB_PASSIVE_CHARMUP,
			ArcanaType.SUB_PASSIVE_DEFANGUP,
			ArcanaType.SUB_PASSIVE_GUARDIANAURA
		};
		SubSkills_GoldCount = new List<ArcanaType>
		{
			ArcanaType.SUB_GOLDCOUNT_LIGHTSOURCES,
			ArcanaType.SUB_GOLDCOUNT_THORNSUP,
			ArcanaType.SUB_GOLCOUNT_ADDREVIVES,
			ArcanaType.SUB_GOLDCOUNT_ADDPASSIVESLOTS
		};
		List<ArcanaType> list2 = new List<ArcanaType>
		{
			ArcanaType.SUB_OVERHEAL_ICEBREATH,
			ArcanaType.SUB_OVERHEAL_MIGHTUP,
			ArcanaType.SUB_OVERHEAL_FEVERUP
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2344 @ rax_v309 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2344 @ rax_v309 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2344 @ rax_v309 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2344 @ rax_v309 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v155+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)7003);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2344 @ rax_v309 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj33 = (nint)0 + (nint)1;
			_ = 7003;
		}
		SubSkills_Overheal = list2;
		List<ArcanaType> list3 = new List<ArcanaType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v158+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)6001);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 6001;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v160+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)6000);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj39 = (nint)0 + (nint)1;
			_ = 6000;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
		object obj40 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v162+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)6002);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ rax_v317 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 6002;
		}
		SubSkills_HPCritical = list3;
		NUM_SET_DEFAULT = 24;
		NUM_SET_EXPANSION1 = 18;
	}
}
