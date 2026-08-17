using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups;

public static class Rarity
{
	public static ERarity GetUpgradeOfferRarity(float luck)
	{
		//IL_0046: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_013f: Expected I4, but got O
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_009c: Invalid comparison between O and F4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		ERarity[] array = new ERarity[5]
		{
			ERarity.Common,
			ERarity.Uncommon,
			ERarity.Rare,
			ERarity.Epic,
			ERarity.Legendary
		};
		float[] array2 = new float[5] { 1.5f, 0.3f, 0.15f, 0.04f, 0.0085f };
		CalculateRarityWeights(array2, luck);
		float num = UnityEngine.Random.Range(0f, 1f);
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		while (true)
		{
			if ((nint)obj < array2.Length)
			{
				if ((nint)obj2 >= array2.Length)
				{
					break;
				}
				obj3 += array2[obj2];
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
				{
					obj2++;
					obj = obj2;
					continue;
				}
				if ((nint)obj2 >= array.Length)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (Assets.Scripts.Inventory__Items__Pickups.ERarity[])+20+v77 @ rcx_v10*4]");
				return ERarity.New;
			}
			return ERarity.Common;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (ERarity)ex;
	}

	public static ERarity GetEncounterOfferRarity(float luck)
	{
		//IL_0046: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_013f: Expected I4, but got O
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_009c: Invalid comparison between O and F4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		ERarity[] array = new ERarity[5]
		{
			ERarity.Common,
			ERarity.Uncommon,
			ERarity.Rare,
			ERarity.Epic,
			ERarity.Legendary
		};
		float[] array2 = new float[5] { 1.5f, 0.3f, 0.15f, 0.04f, 0.0085f };
		CalculateRarityWeights(array2, luck);
		float num = UnityEngine.Random.Range(0f, 1f);
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		while (true)
		{
			if ((nint)obj < array2.Length)
			{
				if ((nint)obj2 >= array2.Length)
				{
					break;
				}
				obj3 += array2[obj2];
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
				{
					obj2++;
					obj = obj2;
					continue;
				}
				if ((nint)obj2 >= array.Length)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (Assets.Scripts.Inventory__Items__Pickups.ERarity[])+20+v77 @ rcx_v10*4]");
				return ERarity.New;
			}
			return ERarity.Common;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (ERarity)ex;
	}

	public static EItemRarity GetItemRarity(float luck)
	{
		//IL_0076: Expected O, but got I
		//IL_00d0: Expected O, but got I
		//IL_022e: Expected O, but got I
		//IL_0827: Expected I4, but got O
		//IL_0132: Expected O, but got I
		//IL_0288: Expected O, but got I
		//IL_03e6: Expected O, but got I
		//IL_018c: Expected O, but got I
		//IL_02ea: Expected O, but got I
		//IL_0440: Expected O, but got I
		//IL_059e: Expected O, but got I
		//IL_0344: Expected O, but got I
		//IL_04a2: Expected O, but got I
		//IL_05f8: Expected O, but got I
		//IL_076a: Expected O, but got I4
		//IL_04fc: Expected O, but got I
		//IL_065a: Expected O, but got I
		//IL_06b4: Expected O, but got I
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Expected O, but got Unknown
		//IL_07ae: Invalid comparison between O and F4
		List<EItemRarity> list = new List<EItemRarity>();
		List<float> list2 = new List<float>();
		list2._002Ector();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)RunUnlockables.availableItems).get_Item((System.Int32Enum)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v11 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v45+18]");
			if (num >= 0)
			{
				list.AddWithResize(EItemRarity.Common);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
				object obj3 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v45+18]");
				if (num2 >= 0)
				{
					goto IL_0819;
				}
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v47+18]");
			if (num3 >= 0)
			{
				list2.AddWithResize(70f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj5 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v47+18]");
				if (num4 >= 0)
				{
					goto IL_0819;
				}
				_ = 1116471296;
			}
		}
		object obj6 = ((Dictionary<System.Int32Enum, object>)(object)RunUnlockables.availableItems).get_Item((System.Int32Enum)1);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v16 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v39+18]");
			if (num5 >= 0)
			{
				list.AddWithResize(EItemRarity.Rare);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
				object obj8 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v39+18]");
				if (num6 >= 0)
				{
					goto IL_0819;
				}
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v41+18]");
			if (num7 >= 0)
			{
				list2.AddWithResize(15f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj10 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v41+18]");
				if (num8 >= 0)
				{
					goto IL_0819;
				}
				_ = 1097859072;
			}
		}
		object obj11 = ((Dictionary<System.Int32Enum, object>)(object)RunUnlockables.availableItems).get_Item((System.Int32Enum)2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v21 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+10]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v33+18]");
			if (num9 >= 0)
			{
				list.AddWithResize(EItemRarity.Epic);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
				object obj13 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v33+18]");
				if (num10 >= 0)
				{
					goto IL_0819;
				}
				_ = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v35+18]");
			if (num11 >= 0)
			{
				list2.AddWithResize(6f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj15 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v35+18]");
				if (num12 >= 0)
				{
					goto IL_0819;
				}
				_ = 1086324736;
			}
		}
		object obj16 = ((Dictionary<System.Int32Enum, object>)(object)RunUnlockables.availableItems).get_Item((System.Int32Enum)3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v26 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v27+18]");
			if (num13 >= 0)
			{
				list.AddWithResize(EItemRarity.Legendary);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
				object obj18 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+18]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v27+18]");
				if (num14 >= 0)
				{
					goto IL_0819;
				}
				_ = 3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v29+18]");
			if (num15 >= 0)
			{
				list2.AddWithResize(1.5f);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj20 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v29+18]");
				if (num16 >= 0)
				{
					goto IL_0819;
				}
				_ = 1069547520;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)0 != 0)
		{
			float[] array = list2.ToArray();
			CalculateRarityWeights(array, luck);
			float num17 = UnityEngine.Random.Range(0f, 1f);
			int num18 = 0;
			int num19 = 0;
			object obj21 = 0;
			while (num19 < array.Length)
			{
				if (num18 < array.Length)
				{
					obj21 += array[num18];
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj21) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num17))
					{
						num18++;
						num19 = num18;
						continue;
					}
					return list.get_Item(num18);
				}
				goto IL_0819;
			}
		}
		return EItemRarity.Common;
		IL_0819:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (EItemRarity)ex;
	}

	public static EItemRarity GetShadyGuyRarity(float luck, float[] customWeights = null)
	{
		//IL_004e: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_017c: Expected I4, but got O
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00a4: Invalid comparison between O and F4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		EItemRarity[] array = new EItemRarity[4]
		{
			EItemRarity.Common,
			EItemRarity.Rare,
			EItemRarity.Epic,
			EItemRarity.Legendary
		};
		float[] array2 = new float[4] { 1f, 0.5f, 0.25f, 0.125f };
		bool flag = customWeights == null;
		float[] array3 = array2;
		if (!flag)
		{
			array3 = customWeights;
		}
		CalculateRarityWeights(array3, luck);
		float num = UnityEngine.Random.Range(0f, 1f);
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		while (true)
		{
			if ((nint)obj < array3.Length)
			{
				if ((nint)obj2 >= array3.Length)
				{
					break;
				}
				obj3 += array3[obj2];
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
				{
					obj2++;
					obj = obj2;
					continue;
				}
				if ((nint)obj2 >= array.Length)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity[])+20+v92 @ rcx_v10*4]");
				return EItemRarity.Common;
			}
			return EItemRarity.Common;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (EItemRarity)ex;
	}

	public static void CalculateRarityWeights(float[] rarityWeights, float luck)
	{
		//IL_0038: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_00e5: Expected O, but got I4
		//IL_00ee: Expected O, but got I4
		//IL_0054: Expected O, but got F4
		//IL_0064: Expected O, but got I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I4
		//IL_0102: Expected O, but got I4
		float num = luck + 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300CD0");
		float num2 = num * 1.5f;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < rarityWeights.Length)
		{
			object obj3 = num2 ^ -0f;
			object obj4 = rarityWeights.Length - 0;
			object obj5 = obj4 - 1;
			object obj6 = obj5 * obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
			float num3 = 1.5f * rarityWeights[obj];
			object obj7 = 0 + 1;
			rarityWeights[obj] = num3;
			obj2 = obj7;
		}
		float num4 = Enumerable.Sum(rarityWeights);
		object obj8 = 0;
		object obj9 = 0;
		while ((nint)obj9 < rarityWeights.Length)
		{
			object obj10 = 0 + 1;
			float num5 = rarityWeights[obj8] / num4;
			rarityWeights[obj8] = num5;
			obj9 = obj10;
		}
	}

	public static float GetMultiplier(ERarity rarity)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (rarity <= ERarity.Legendary)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+42DA48+rarity @ rcx (Assets.Scripts.Inventory__Items__Pickups.ERarity)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return 1f;
	}
}
