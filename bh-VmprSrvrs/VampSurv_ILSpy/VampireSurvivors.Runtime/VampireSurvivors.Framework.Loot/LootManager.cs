using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework.Loot;

public class LootManager : IInitializable, IDisposable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__22_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CModifyItemWeight_003Eb__22_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 210;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private DataManager _dataManager;

	private GameSessionData _gameSessionData;

	private Stage _stage;

	private float _accumulatedWeight;

	private List<WeightedItem> _weightedStore;

	private List<ItemType> _forcedLootTable;

	private List<ItemType> _addedLoot;

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	public void Init()
	{
		List<ItemType> addedLoot = new List<ItemType>();
		_addedLoot = addedLoot;
		_forcedLootTable = null;
		MakeDefaultLootTable();
	}

	public void SetPlainLootTable()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0278: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_02a0: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_02f0: Expected O, but got I
		//IL_022a: Expected O, but got I
		List<ItemType> list = new List<ItemType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)12);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)17);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 17;
		}
		_forcedLootTable = list;
		RecalculateLoot();
	}

	public void AddToLootTable(ItemType itemToAdd)
	{
		//IL_0028: Expected O, but got I
		//IL_0081: Expected O, but got I
		List<ItemType> list = new List<ItemType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)itemToAdd);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			object obj2 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 104 Invalid \"Jump target not found in method: 0x186B5FF80\"");
		throw new NullReferenceException();
	}

	public void AddToLootTable(List<ItemType> itemsToAdd)
	{
		//IL_000f: Expected I, but got O
		//IL_0072: Expected O, but got I
		//IL_0217: Expected I, but got O
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_015e: Expected I, but got O
		//IL_00df: Expected O, but got I
		//IL_0106: Expected I, but got O
		//IL_0116: Expected O, but got I
		nint num = unchecked((nint)null);
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj8 = default(object);
		nint num3 = default(nint);
		object obj9 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ stack_-28_v10+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ stack_-28_v10+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ stack_-28_v10+10]");
				object obj5 = 0;
				object obj6 = obj4 + 1;
				List<ItemType> addedLoot = _addedLoot;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				bool flag = (nint)0 == 0;
				object obj7 = obj8;
				nint num2 = num3;
				nint num4 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag2 = (nint)obj9 != -1;
					num2 = 0;
					num4 = unchecked((nint)null);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					obj8 = 0;
					num3 = 0;
					obj4 = obj6;
					if (flag2)
					{
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				obj8 = obj7;
				num3 = num2;
				obj4 = obj6;
				num = (nint)_addedLoot;
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag3 = obj == null;
		num = 0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ stack_-28_v10+1C]");
			if (obj2 == null)
			{
				List<ItemType> items;
				if (_forcedLootTable == null)
				{
					Stage stage = _stage;
					StageData stageData = stage._stageData;
					if (stageData._003CLootTable_003Ek__BackingField == null)
					{
						MakeDefaultLootTable();
						goto IL_0206;
					}
					items = stageData._003CLootTable_003Ek__BackingField;
				}
				else
				{
					items = _forcedLootTable;
				}
				MakeCustomLootTable(items);
				goto IL_0206;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num = unchecked((nint)null);
		}
		throw new NullReferenceException();
		IL_0206:
		CheckForAddedLoot();
	}

	public void RecalculateLoot()
	{
		//IL_00a2: Expected O, but got I
		LootManager lootManager = default(LootManager);
		List<ItemType> items;
		if (_forcedLootTable == null)
		{
			Stage stage = _stage;
			LootManager stageData = (LootManager)(object)stage._stageData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v5 (VampireSurvivors.Framework.Loot.LootManager)+190]");
			bool flag = (nint)0 != 0;
			lootManager = this;
			if (!flag)
			{
				MakeDefaultLootTable();
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 60 Invalid \"Jump target not found in method: 0x186B602F0\"");
				stageData = this;
				LootManager lootManager2 = default(LootManager);
				lootManager = lootManager2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v5 (VampireSurvivors.Framework.Loot.LootManager)+190]");
			items = (List<ItemType>)0;
		}
		else
		{
			items = _forcedLootTable;
		}
		lootManager.MakeCustomLootTable(items);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 94 Invalid \"Jump target not found in method: 0x186B602F0\"");
		throw new NullReferenceException();
	}

	public void CheckForAddedLoot()
	{
		//IL_005c: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_00b0: Expected O, but got I
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_0242: Expected O, but got I
		//IL_03ab: Expected F4, but got I
		//IL_03d5: Expected O, but got I
		//IL_01c6: Expected O, but got I
		//IL_01ee: Expected O, but got I
		//IL_0356: Expected O, but got I
		List<ItemType> addedLoot = _addedLoot;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		List<ItemType> addedLoot2 = _addedLoot;
		object obj = 0;
		object obj2 = 0;
		ItemType item = default(ItemType);
		System.Int32Enum? int32Enum = default(System.Int32Enum?);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)obj3 >= 0)
			{
				return;
			}
			List<ItemType> addedLoot3 = _addedLoot;
			object obj4 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)obj4 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj5 = 0;
			DataManager dataManager = _dataManager;
			Dictionary<ItemType, ItemData> dictionary = dataManager._003CAllItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r9_v6+20+v140 @ rbp_v7*4]");
			int num = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
			if (num >= 0)
			{
				DataManager dataManager2 = _dataManager;
				Dictionary<ItemType, ItemData> dictionary2 = dataManager2._003CAllItems_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r9_v6+20+v140 @ rbp_v7*4]");
				object obj6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+68]");
				if ((nint)0 != 0)
				{
					GameManager core = GM.Core;
					PlayerOptionsData config = core._playerOptions.Config;
					if (!config.HasCollectedItem(item))
					{
						string text = int32Enum.ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+10]");
						string message = "missing required item for " + (string)0 + " : " + text;
						Debug.Log(message);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+68]");
						int32Enum = (System.Int32Enum?)(object)0;
						goto IL_035b;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r9_v6+20+v140 @ rbp_v7*4]");
				float num2 = ModifyItemWeight(ItemType.VOID);
				int level = activeCharacter._level;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+48]");
				bool flag = (nint)level < (nint)0;
				float num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+68]");
				int32Enum = (System.Int32Enum?)(object)0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+52]");
					if ((nint)0 == 0)
					{
						float num4 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+44]");
						float num5 = num4 * 0f;
						num3 = num5 + _accumulatedWeight;
						_accumulatedWeight = num3;
					}
					else
					{
						float num6 = activeCharacter.PLuck();
						float num7 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+44]");
						float num8 = num7 * 0f;
						float num9 = num8 * num2;
						float accumulatedWeight = num9 + _accumulatedWeight;
						_accumulatedWeight = accumulatedWeight;
						num3 = num2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+44]");
					num2 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+44]");
					bool flag2 = (nint)0 <= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+68]");
					int32Enum = (System.Int32Enum?)(object)0;
					if (!flag2)
					{
						WeightedItem weightedItem = null;
						weightedItem._weight = _accumulatedWeight;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r9_v6+20+v140 @ rbp_v7*4]");
						weightedItem._itemType = ItemType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99A70");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v22 (System.Object)+68]");
						int32Enum = (System.Int32Enum?)(object)0;
					}
				}
			}
			goto IL_035b;
			IL_035b:
			addedLoot2 = _addedLoot;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public ItemType GetRandomWeightedItem(Unity.Mathematics.Random? rng = null)
	{
		//IL_0241: Expected O, but got F4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0049: Expected O, but got I4
		//IL_005a: Invalid comparison between I and F4
		//IL_01d2->IL01ec: Incompatible stack heights: 8 vs 4
		//IL_01ec->IL026c: Incompatible stack heights: 8 vs 4
		float num = default(float);
		if (rng != null)
		{
			object obj2 = default(object);
			object obj = obj2 >> 9;
			object obj3 = obj | 0x3F800000;
			num = (float)obj3 - 1f;
		}
		else
		{
			object obj4 = UnityEngine.Random.value;
		}
		float num2 = _accumulatedWeight * num;
		List<WeightedItem>.Enumerator enumerator = default(List<WeightedItem>.Enumerator);
		object obj6 = default(object);
		object obj7 = default(object);
		while (enumerator.MoveNext())
		{
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rbx_v6+14]");
			if (0f < num2)
			{
				continue;
			}
			GameManager core = GM.Core;
			bool flag = (object)GM.Core == null;
			bool flag2 = core._playerOptions == null;
			PlayerOptionsData config = core._playerOptions.Config;
			bool flag3 = config == null;
			bool flag4 = config._003CSealedItems_003Ek__BackingField == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			if (obj6 == null)
			{
				GameManager core2 = GM.Core;
				bool flag5 = (object)GM.Core == null;
				bool flag6 = core2._playerOptions == null;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				bool flag7 = config2 == null;
				bool flag8 = config2._003CContentGroupSealedItems_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				if (obj7 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rbx_v6+10]");
					return ItemType.VOID;
				}
			}
			return ItemType.COIN;
		}
		return ItemType.VOID;
	}

	public ItemType GetItemFromExportedTable(WeightedStore store)
	{
		//IL_0221: Expected O, but got F4
		//IL_002c: Expected O, but got I4
		//IL_003d: Invalid comparison between I and F4
		//IL_01b5->IL01cf: Incompatible stack heights: 8 vs 4
		//IL_01cf->IL0213: Incompatible stack heights: 8 vs 4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = store._accumulatedWeight * (float)obj2;
		List<WeightedItem>.Enumerator enumerator = default(List<WeightedItem>.Enumerator);
		object obj4 = default(object);
		object obj5 = default(object);
		while (enumerator.MoveNext())
		{
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v4+14]");
			if (0f < num)
			{
				continue;
			}
			GameManager core = GM.Core;
			bool flag = (object)GM.Core == null;
			bool flag2 = core._playerOptions == null;
			PlayerOptionsData config = core._playerOptions.Config;
			bool flag3 = config == null;
			bool flag4 = config._003CSealedItems_003Ek__BackingField == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			if (obj4 == null)
			{
				GameManager core2 = GM.Core;
				bool flag5 = (object)GM.Core == null;
				bool flag6 = core2._playerOptions == null;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				bool flag7 = config2 == null;
				bool flag8 = config2._003CContentGroupSealedItems_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				if (obj5 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v4+10]");
					return ItemType.VOID;
				}
			}
			return ItemType.COIN;
		}
		return ItemType.VOID;
	}

	public unsafe WeightedStore ExportCustomLootTable(ItemType[] items, bool ignorePlayerLevel = false)
	{
		//IL_02b1: Expected F4, but got I4
		//IL_02b9: Expected O, but got I
		//IL_02c2: Expected O, but got I4
		//IL_02cb: Expected O, but got I4
		//IL_01be: Expected O, but got I
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_020a: Expected O, but got I
		//IL_00ee: Expected O, but got I
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		List<WeightedItem> weightedItems = new List<WeightedItem>();
		float num = 0f;
		IntPtr intPtr = default(IntPtr);
		string text = (string)(nint)intPtr;
		object obj = 0;
		object obj2 = 0;
		ItemType item = default(ItemType);
		System.Int32Enum? int32Enum = default(System.Int32Enum?);
		while (true)
		{
			if ((nint)obj2 < items.Length)
			{
				if ((nint)obj >= items.Length)
				{
					break;
				}
				DataManager dataManager = _dataManager;
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref items[obj]));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v14 (System.Object)+68]");
				if ((nint)0 != 0)
				{
					GameManager core = GM.Core;
					PlayerOptionsData config = core._playerOptions.Config;
					if (!config.HasCollectedItem(item))
					{
						string text2 = int32Enum.ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v14 (System.Object)+10]");
						string message = "missing required item for " + (string)0 + " : " + text2;
						Debug.Log(message);
						obj++;
						text = text2;
						obj2 = obj;
						continue;
					}
				}
				float num2 = ModifyItemWeight((ItemType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref items[obj]));
				if (!ignorePlayerLevel)
				{
					GameSessionData gameSessionData = _gameSessionData;
					VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
					int level = activeCharacter._level;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v14 (System.Object)+48]");
					if ((nint)level < (nint)0)
					{
						goto IL_025a;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v14 (System.Object)+52]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v14 (System.Object)+44]");
				object obj4 = 0;
				if (!flag)
				{
					GameSessionData gameSessionData2 = _gameSessionData;
					float num3 = gameSessionData2._activeCharacter.PLuck();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v14 (System.Object)+44]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v14 (System.Object)+44]");
					object obj5 = num4 * 0;
					obj4 = obj5;
				}
				float num5 = (float)obj4 * num2;
				float num6 = num5 + num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v14 (System.Object)+44]");
				bool flag2 = (nint)0 <= (nint)0;
				num = num6;
				if (!flag2)
				{
					WeightedItem weightedItem = null;
					weightedItem._weight = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [items @ rdx (VampireSurvivors.Data.ItemType[])+20+v122 @ rsi_v2*4]");
					weightedItem._itemType = ItemType.VOID;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99A70");
					num = num6;
				}
				goto IL_025a;
			}
			WeightedStore weightedStore = null;
			weightedStore._weightedItems = weightedItems;
			weightedStore._accumulatedWeight = num;
			return weightedStore;
			IL_025a:
			obj++;
			obj2 = obj;
		}
		return (WeightedStore)(object)new IndexOutOfRangeException();
	}

	private void MakeDefaultLootTable()
	{
		//IL_00dd: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_02b5: Expected O, but got I4
		//IL_02d3: Expected O, but got I
		//IL_04d8: Expected O, but got I4
		//IL_01fb: Expected O, but got I
		//IL_0331: Expected O, but got I
		//IL_0393: Expected O, but got I4
		_accumulatedWeight = 0f;
		List<WeightedItem> weightedStore = new List<WeightedItem>();
		_weightedStore = weightedStore;
		DataManager dataManager = _dataManager;
		Dictionary<ItemType, ItemData>.Enumerator enumerator = default(Dictionary<ItemType, ItemData>.Enumerator);
		object obj2 = default(object);
		ItemType item = default(ItemType);
		object obj4 = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			ItemType itemType = ItemType.VOID;
			if (0 == 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+68]");
			bool flag = (nint)0 == 0;
			object obj = obj2;
			if (!flag)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core == null)
				{
					throw new NullReferenceException();
				}
				PlayerOptionsData config = core._playerOptions.Config;
				bool flag2 = config.HasCollectedItem(item);
				bool flag3 = !flag2;
				obj = 0;
				obj2 = 0;
				if (flag3)
				{
					continue;
				}
			}
			if (false)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+81]");
				bool flag4 = (nint)0 != 0;
				obj2 = obj;
				if (flag4)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+70]");
				if ((nint)0 != 0)
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core == null)
					{
						throw new NullReferenceException();
					}
					ArcanaManager arcanaManager = core2._arcanaManager;
					if (core2._arcanaManager == null)
					{
						throw new NullReferenceException();
					}
					if (arcanaManager._003CActiveArcanas_003Ek__BackingField == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+70]");
					object obj3 = (nint)0 >> 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
					bool flag5 = obj4 == null;
					obj2 = obj;
					if (flag5)
					{
						continue;
					}
				}
				float num = ModifyItemWeight(ItemType.VOID);
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						int level = activeCharacter._level;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+48]");
						bool flag6 = (nint)level < (nint)0;
						obj2 = 0;
						if (flag6)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+44]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+52]");
						if ((nint)0 != 0)
						{
							GameSessionData gameSessionData2 = _gameSessionData;
							float num2 = gameSessionData2._activeCharacter.PLuck();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+44]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+44]");
							object obj6 = num3 * 0;
							obj5 = obj6;
						}
						float num4 = (float)obj5 * num;
						float accumulatedWeight = num4 + _accumulatedWeight;
						_accumulatedWeight = accumulatedWeight;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rdi_v6 (VampireSurvivors.Data.ItemType)+44]");
						bool flag7 = (nint)0 <= (nint)0;
						obj2 = 0;
						if (!flag7)
						{
							WeightedItem weightedItem = null;
							weightedItem._itemType = ItemType.VOID;
							weightedItem._weight = _accumulatedWeight;
							if (_weightedStore == null)
							{
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99A70");
							obj2 = 0;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public ItemType GetSurvarotDraft()
	{
		//IL_00f8: Expected O, but got F4
		//IL_009e: Expected O, but got I4
		//IL_00af: Invalid comparison between I and F4
		List<WeightedItem> list = new List<WeightedItem>();
		WeightedItem weightedItem = null;
		weightedItem._itemType = ItemType.SV_DRAFT1;
		weightedItem._weight = 5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99A70");
		WeightedItem weightedItem2 = null;
		weightedItem2._itemType = ItemType.SV_DRAFT2;
		weightedItem2._weight = 3.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99A70");
		WeightedItem weightedItem3 = null;
		weightedItem3._itemType = ItemType.SV_DRAFT3;
		weightedItem3._weight = 1.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99A70");
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * 10f;
		List<WeightedItem>.Enumerator enumerator = default(List<WeightedItem>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v27+14]");
			if (!(0f < num))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v27+10]");
				return ItemType.VOID;
			}
		}
		return ItemType.SV_DRAFT1;
	}

	public bool DropSurvarotsSuccessful()
	{
		//IL_0558: Expected I4, but got O
		//IL_0076: Expected O, but got I4
		//IL_0228: Expected I, but got O
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_0516: Invalid comparison between F4 and I4
		//IL_04b7: Invalid comparison between F4 and I4
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_0458: Invalid comparison between F4 and I4
		//IL_03f9: Invalid comparison between F4 and I4
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		//IL_0215: Expected O, but got I4
		//IL_01cc: Expected O, but got I4
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				bool flag = config._003CForcedSurvarots_003Ek__BackingField;
				object obj = 0;
				if (flag)
				{
					goto IL_021a;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._playerOptions != null)
				{
					PlayerOptionsData config2 = core2._playerOptions.Config;
					if (config2 != null)
					{
						if (!config2._003CSelectedSurvarots_003Ek__BackingField)
						{
							goto IL_0544;
						}
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null && core3._playerOptions != null)
						{
							PlayerOptionsData config3 = core3._playerOptions.Config;
							if (config3 != null)
							{
								List<ItemType> list = config3._003CCollectedItems_003Ek__BackingField;
								if (config3._003CCollectedItems_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
									bool flag2;
									if ((nint)0 == 0)
									{
										obj = 0;
										flag2 = false;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
										object obj3 = default(object);
										object obj2 = obj3 - -1;
										bool flag3 = obj2 == null;
										flag2 = !flag3;
										obj = 89;
									}
									if (flag2)
									{
										goto IL_021a;
									}
									goto IL_0544;
								}
							}
						}
					}
				}
			}
		}
		goto IL_054a;
		IL_054a:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0544:
		return false;
		IL_021a:
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v10 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core4 = GM.Core;
		if ((object)GM.Core != null)
		{
			float num3 = core4._003CSurvivedSeconds_003Ek__BackingField / 300f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			object obj5 = default(object);
			object obj4 = obj5 + 1;
			GameManager core5 = GM.Core;
			if ((object)GM.Core != null && core5._playerOptions != null)
			{
				PlayerOptionsData config4 = core5._playerOptions.Config;
				if (config4 != null)
				{
					object obj6 = obj4 + 1;
					if (config4._003CRunFoundSurvarots_003Ek__BackingField <= (nint)obj6)
					{
						bool flag4 = config4._003CRunFoundSurvarots_003Ek__BackingField == (nint)obj4;
						if (config4._003CRunFoundSurvarots_003Ek__BackingField > (nint)obj4)
						{
							float value = UnityEngine.Random.value;
							bool flag5 = 0.01f < value;
							float num4 = 0.01f - value;
							bool flag6 = num4 == 0f;
							bool flag7 = !flag5;
							bool flag8 = !flag6;
							return flag8 & flag7;
						}
						if (flag4)
						{
							float value2 = UnityEngine.Random.value;
							bool flag9 = 0.025f < value2;
							float num5 = 0.025f - value2;
							bool flag10 = num5 == 0f;
							bool flag11 = !flag9;
							bool flag12 = !flag10;
							return flag12 & flag11;
						}
						object obj7 = obj4 - 1;
						if (config4._003CRunFoundSurvarots_003Ek__BackingField < (nint)obj7)
						{
							float value3 = UnityEngine.Random.value;
							bool flag13 = 0.2f < value3;
							float num6 = 0.2f - value3;
							bool flag14 = num6 == 0f;
							bool flag15 = !flag13;
							bool flag16 = !flag14;
							return flag16 & flag15;
						}
						if (config4._003CRunFoundSurvarots_003Ek__BackingField < (nint)obj4)
						{
							float value4 = UnityEngine.Random.value;
							bool flag17 = 0.1f < value4;
							float num7 = 0.1f - value4;
							bool flag18 = num7 == 0f;
							bool flag19 = !flag17;
							bool flag20 = !flag18;
							return flag20 & flag19;
						}
					}
					goto IL_0544;
				}
			}
		}
		goto IL_054a;
	}

	private void MakeCustomLootTable(List<ItemType> items)
	{
		//IL_002f: Expected F4, but got I4
		//IL_0040: Expected F4, but got I4
		//IL_03b1: Invalid comparison between F4 and I
		//IL_0055: Invalid comparison between F4 and I
		//IL_007c: Expected O, but got I
		//IL_010d: Expected O, but got I
		//IL_03d8: Expected F4, but got I
		//IL_01a2: Expected O, but got I
		//IL_01d9: Expected O, but got I
		_accumulatedWeight = 0f;
		List<WeightedItem> list = (_weightedStore = new List<WeightedItem>());
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		float num = 0f;
		List<WeightedItem> list2 = list;
		float num2 = 0f;
		ItemType item = default(ItemType);
		System.Int32Enum? int32Enum = default(System.Int32Enum?);
		while (true)
		{
			float num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [items @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if (!(num3 < 0f))
			{
				return;
			}
			float num4 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [items @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if (!(num4 < 0f))
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [items @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj = 0;
			DataManager dataManager = _dataManager;
			Dictionary<ItemType, ItemData> dictionary = dataManager._003CAllItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r9_v5+20+v193 @ rbp_v3 (System.Single)*4]");
			int num5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
			if (num5 >= 0)
			{
				DataManager dataManager2 = _dataManager;
				Dictionary<ItemType, ItemData> dictionary2 = dataManager2._003CAllItems_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r9_v5+20+v193 @ rbp_v3 (System.Single)*4]");
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+68]");
				list2 = (List<WeightedItem>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+68]");
				if ((nint)0 != 0)
				{
					GameManager core = GM.Core;
					PlayerOptionsData config = core._playerOptions.Config;
					if (!config.HasCollectedItem(item))
					{
						string text = int32Enum.ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+10]");
						string text2 = "missing required item for " + (string)0 + " : " + text;
						Debug.Log(text2);
						num++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+68]");
						int32Enum = (System.Int32Enum?)(object)0;
						list2 = (List<WeightedItem>)(object)text2;
						num2 = num;
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r9_v5+20+v193 @ rbp_v3 (System.Single)*4]");
				float num6 = ModifyItemWeight(ItemType.VOID);
				int level = activeCharacter._level;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+48]");
				bool flag = (nint)level < (nint)0;
				float num7 = num6;
				int32Enum = (System.Int32Enum?)list2;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+52]");
					if ((nint)0 == 0)
					{
						float num8 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+44]");
						float num9 = num8 * 0f;
						num7 = num9 + _accumulatedWeight;
						_accumulatedWeight = num7;
					}
					else
					{
						float num10 = activeCharacter.PLuck();
						float num11 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+44]");
						float num12 = num11 * 0f;
						float num13 = num12 * num6;
						float accumulatedWeight = num13 + _accumulatedWeight;
						_accumulatedWeight = accumulatedWeight;
						num7 = num6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+44]");
					num6 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v21 (System.Object)+44]");
					bool flag2 = (nint)0 <= (nint)0;
					int32Enum = (System.Int32Enum?)list2;
					if (!flag2)
					{
						WeightedItem weightedItem = null;
						weightedItem._weight = _accumulatedWeight;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r9_v5+20+v193 @ rbp_v3 (System.Single)*4]");
						weightedItem._itemType = ItemType.VOID;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99A70");
						int32Enum = (System.Int32Enum?)list2;
						list2 = _weightedStore;
					}
				}
			}
			num++;
			num2 = num;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private unsafe float ModifyItemWeight(ItemType itemType)
	{
		//IL_0597: Expected I, but got O
		//IL_0013: Expected I, but got O
		//IL_04d6: Expected I, but got O
		//IL_061a: Expected I, but got O
		//IL_0645: Expected O, but got I4
		//IL_0559: Expected I, but got O
		//IL_0584: Expected O, but got I4
		//IL_01fd: Expected O, but got I4
		//IL_020a: Expected F4, but got O
		//IL_0212: Expected O, but got Ref
		//IL_0106: Expected I, but got O
		//IL_03d6: Expected F4, but got O
		float result;
		if (itemType == ItemType.OROLOGION)
		{
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v75 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num2 = 0;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				ArcanaManager arcanaManager = core._arcanaManager;
				if (core._arcanaManager != null && arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
					object obj = default(object);
					bool flag = obj == null;
					result = 1f;
					if (!flag)
					{
						result = 2f;
					}
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._characters != null)
					{
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						if (enumerator.MoveNext())
						{
							num2 = unchecked((nint)null);
							throw new NullReferenceException();
						}
						goto IL_0722;
					}
				}
			}
		}
		else if (itemType != ItemType.SORBETTO)
		{
			if (itemType != ItemType.NFT)
			{
				if (itemType == ItemType.ROSARY)
				{
					GameManager core3 = GM.Core;
					if ((object)GM.Core == null || core3._characters == null)
					{
						goto IL_0658;
					}
					result = 1f;
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
					if (enumerator2.MoveNext())
					{
						object obj2 = 0;
						float num3 = (float)core3._characters;
						UnityEngine.Object obj3 = (UnityEngine.Object)(&enumerator2);
						throw new NullReferenceException();
					}
				}
				else
				{
					if (itemType == ItemType.GOLDFINGER)
					{
						GameManager core4 = GM.Core;
						if ((object)GM.Core != null)
						{
							ArcanaManager arcanaManager2 = core4._arcanaManager;
							if (core4._arcanaManager != null && arcanaManager2._003CActiveArcanas_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
								object obj4 = default(object);
								bool flag2 = obj4 == null;
								result = 1f;
								if (!flag2)
								{
									result = 10f;
								}
								goto IL_0722;
							}
						}
						goto IL_0658;
					}
					bool flag3 = itemType != ItemType.PICKUP_REROLL_DICE;
					result = 1f;
					if (!flag3)
					{
						GameManager core5 = GM.Core;
						if ((object)GM.Core == null || core5._characters == null)
						{
							goto IL_0658;
						}
						result = 1f;
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						if (enumerator3.MoveNext())
						{
							UnityEngine.Object obj5 = null;
							float num3 = (float)core5._characters;
							UnityEngine.Object obj3 = null;
							throw new NullReferenceException();
						}
					}
				}
				goto IL_0722;
			}
			nint num4 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v25 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num5 = 0;
			GameManager core6 = GM.Core;
			bool flag4 = (object)GM.Core == null;
			nint num2 = num5;
			if (!flag4)
			{
				ArcanaManager arcanaManager3 = core6._arcanaManager;
				bool flag5 = core6._arcanaManager == null;
				num2 = num5;
				if (!flag5)
				{
					num2 = (nint)arcanaManager3._003CActiveArcanas_003Ek__BackingField;
					if (arcanaManager3._003CActiveArcanas_003Ek__BackingField != null)
					{
						object obj6 = 19;
						goto IL_080e;
					}
				}
			}
		}
		else
		{
			nint num6 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v22 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num7 = 0;
			GameManager core7 = GM.Core;
			bool flag6 = (object)GM.Core == null;
			nint num2 = num7;
			if (!flag6)
			{
				ArcanaManager arcanaManager4 = core7._arcanaManager;
				bool flag7 = core7._arcanaManager == null;
				num2 = num7;
				if (!flag7)
				{
					num2 = (nint)arcanaManager4._003CActiveArcanas_003Ek__BackingField;
					if (arcanaManager4._003CActiveArcanas_003Ek__BackingField != null)
					{
						object obj6 = 12;
						goto IL_080e;
					}
				}
			}
		}
		goto IL_0658;
		IL_0722:
		return result;
		IL_080e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj7 = default(object);
		bool flag8 = obj7 == null;
		result = 1f;
		if (!flag8)
		{
			result = 4f;
		}
		goto IL_0722;
		IL_0658:
		throw new NullReferenceException();
	}

	public LootManager()
	{
		List<WeightedItem> weightedStore = new List<WeightedItem>();
		_weightedStore = weightedStore;
		List<ItemType> addedLoot = new List<ItemType>();
		_addedLoot = addedLoot;
	}
}
