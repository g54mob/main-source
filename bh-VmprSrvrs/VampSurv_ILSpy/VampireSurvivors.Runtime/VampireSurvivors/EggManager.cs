using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors;

public class EggManager : IInitializable, IDisposable
{
	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public GameObject gameObject;

		internal void _003CShowResultAt_003Eb__0()
		{
			UnityEngine.Object.Destroy(gameObject, 0f);
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	private Dictionary<string, float> _attributes;

	private List<string> _attributeKeys;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private GameSessionData _session;

	public const string MAX_HP_PROPNAME = "maxHp";

	public const string ARMOR_PROPNAME = "armor";

	public const string REGEN_PROPNAME = "regen";

	public const string MOVESPEED_PROPNAME = "moveSpeed";

	public const string POWER_PROPNAME = "power";

	public const string COOLDOWN_PROPNAME = "cooldown";

	public const string AREA_PROPNAME = "area";

	public const string SPEED_PROPNAME = "speed";

	public const string DURATION_PROPNAME = "duration";

	public const string AMOUNT_PROPNAME = "amount";

	public const string LUCK_PROPNAME = "luck";

	public const string GROWTH_PROPNAME = "growth";

	public const string GREED_PROPNAME = "greed";

	public const string CURSE_PROPNAME = "curse";

	public const string MAGNET_PROPNAME = "magnet";

	public const string REVIVALS_PROPNAME = "revivals";

	public const string REROLLS_PROPNAME = "rerolls";

	public const string SKIPS_PROPNAME = "skips";

	public const string BANISH_PROPNAME = "banish";

	public void Initialize()
	{
		InitializeAttributes();
	}

	public void Dispose()
	{
	}

	public KeyValuePair<string, float> AddGoldenEgg(CharacterType t, Unity.Mathematics.Random? rng = null)
	{
		//IL_0160: Expected O, but got I
		//IL_005f: Expected O, but got I
		//IL_01a0: Expected I4, but got O
		//IL_01a4: Expected O, but got I4
		//IL_0022: Expected O, but got I
		//IL_018d: Expected O, but got I
		//IL_0097: Expected O, but got I
		//IL_00b9: Expected O, but got I
		//IL_00b9: Expected O, but got I
		//IL_00e7: Expected O, but got I
		//IL_00e7: Expected I4, but got O
		//IL_00e7: Expected O, but got I
		//IL_00f7: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0144: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ rdx (VampireSurvivors.Data.CharacterType)+10]");
		object obj = 0;
		IntPtr intPtr = default(IntPtr);
		object obj5;
		if (intPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v2+20]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v2+28]");
			object obj2 = num - 0;
			object obj4 = default(object);
			object obj3 = obj2 * obj4;
			obj5 = obj3 >> 32;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v2+20]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v2+28]");
			object obj6 = num2 - 0;
			object obj7 = UnityEngine.Random.RandomRangeInt(0, (int)obj6);
			obj5 = obj7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ rdx (VampireSurvivors.Data.CharacterType)+18]");
		object obj8 = 0;
		object obj9 = obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v10+18]");
		bool flag = (nint)obj9 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v10+10]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ rdx (VampireSurvivors.Data.CharacterType)+10]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v6+20+v113 @ rcx_v9*8]");
		float value = ((Dictionary<object, float>)num3).get_Item((object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ rdx (VampireSurvivors.Data.CharacterType)+28]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v6+20+v113 @ rcx_v9*8]");
		((PlayerOptions)num4).AddGoldenEggToCharacter((CharacterType)rng, (string)0, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ rdx (VampireSurvivors.Data.CharacterType)+28]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v13+50]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v14+240]");
		float num5 = 0f + 1f;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v6+20+v113 @ rcx_v9*8]");
		EggManager eggManager = (EggManager)0;
		return (KeyValuePair<string, float>)this;
	}

	public string PickRandomAttribute()
	{
		//IL_0022: Expected O, but got I
		//IL_0084: Expected I4, but got O
		//IL_0088: Expected O, but got I4
		Dictionary<string, float> attributes = _attributes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.Dictionary`2<System.String, System.Single>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.Dictionary`2<System.String, System.Single>)+28]");
		object obj = num - 0;
		object obj2 = UnityEngine.Random.RandomRangeInt(0, (int)obj);
		List<string> attributeKeys = _attributeKeys;
		bool flag = (nint)obj2 >= attributeKeys._size;
		string[] items = attributeKeys._items;
		return items[obj2];
	}

	public void LightEgg(float amount)
	{
		//IL_0166: Expected F4, but got I4
		//IL_016f: Expected F4, but got I4
		//IL_0eb1: Invalid comparison between F4 and I4
		//IL_02e0: Invalid comparison between F4 and I4
		//IL_02f3: Expected F4, but got I4
		//IL_0190: Invalid comparison between F4 and I4
		//IL_0321: Expected O, but got I
		//IL_0ee5: Expected I4, but got O
		//IL_0ee9: Expected O, but got I4
		//IL_0799: Expected F4, but got I4
		//IL_02d7->IL0ea4: Incompatible stack heights: 1 vs 0
		//IL_040f->IL0ef8: Incompatible stack heights: 1 vs 0
		//IL_0414->IL0414: Incompatible stack heights: 1 vs 0
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)config2._selectedChar);
		System.Collections.Generic.InsertionBehavior insertionBehavior;
		if (num < 0)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			Dictionary<string, float> value = new Dictionary<string, float>();
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterEggInfo_003Ek__BackingField).TryInsert((System.Int32Enum)config3._selectedChar, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
		}
		PlayerOptionsData config4 = _playerOptions.Config;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config4._selectedChar);
		List<string> attributeKeys = _attributeKeys;
		float num2 = amount / (float)attributeKeys._size;
		Dictionary<string, float> dictionary = config._003CCharacterEggInfo_003Ek__BackingField.get_Item(config4._selectedChar);
		Dictionary<string, float> dictionary2 = config._003CCharacterEggInfo_003Ek__BackingField.get_Item(config4._selectedChar);
		List<string> attributeKeys2 = _attributeKeys;
		float num3 = amount;
		float num4 = 0f;
		float num10;
		for (float num5 = 0f; num5 < (float)attributeKeys2._size; num5 = num4)
		{
			List<string> attributeKeys3 = _attributeKeys;
			bool flag2 = !(num4 < (float)attributeKeys3._size);
			string[] items = attributeKeys3._items;
			int num6 = ((Dictionary<string, float>)obj).FindEntry(items[num4]);
			if (num6 < 0)
			{
				bool flag3 = ((Dictionary<object, float>)obj).TryInsert((object)items[num4], 0f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			float num7 = ((Dictionary<object, float>)obj).get_Item((object)items[num4]);
			float num8 = ((Dictionary<object, float>)(object)_attributes).get_Item((object)items[num4]);
			float num9 = num8 * num2;
			num3 = num9 + num7;
			bool flag4 = ((Dictionary<object, float>)obj).TryInsert((object)items[num4], num3, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			attributeKeys2 = _attributeKeys;
			num4++;
			num10 = num3;
			insertionBehavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
		}
		bool flag5 = !(amount > 0f);
		float num11 = 0f;
		if (!flag5)
		{
			bool flag8;
			do
			{
				Dictionary<string, float> attributes = _attributes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v25 (System.Collections.Generic.Dictionary`2<System.String, System.Single>)+20]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v25 (System.Collections.Generic.Dictionary`2<System.String, System.Single>)+28]");
				object obj2 = num12 - 0;
				object obj3 = UnityEngine.Random.RandomRangeInt(0, (int)obj2);
				List<string> attributeKeys4 = _attributeKeys;
				bool flag6 = (nint)obj3 >= attributeKeys4._size;
				string[] items2 = attributeKeys4._items;
				float num13 = ((Dictionary<object, float>)obj).get_Item((object)items2[obj3]);
				float num14 = ((Dictionary<object, float>)(object)_attributes).get_Item((object)items2[obj3]);
				float num15 = num14 + num13;
				bool flag7 = ((Dictionary<object, float>)obj).TryInsert((object)items2[obj3], num15, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
				num11++;
				flag8 = amount > num11;
				num10 = num15;
				num3 = num11;
				insertionBehavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			}
			while (flag8);
		}
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0f22;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0f22;
		IL_10f6:
		PlayerOptionsData playerOptionsData2;
		Dictionary<System.Int32Enum, int> dictionary3 = (Dictionary<System.Int32Enum, int>)(object)playerOptionsData2._003CRunItemsPickupCount_003Ek__BackingField;
		System.Collections.Generic.InsertionBehavior behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
		int value2 = 1;
		System.Int32Enum key = (System.Int32Enum)27;
		goto IL_1108;
		IL_1108:
		bool flag9 = dictionary3.TryInsert(key, value2, behavior);
		return;
		IL_0f7b:
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData playerOptionsData3;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData = playerOptions2._currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData3 = currentAdventureSaveData;
						goto IL_076b;
					}
				}
				playerOptionsData3 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData3 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_076b;
		IL_102d:
		PlayerOptionsData playerOptionsData4;
		float num16 = amount + playerOptionsData4._003CTotalEggCount_003Ek__BackingField;
		PlayerOptions playerOptions3 = _playerOptions;
		playerOptionsData4._003CTotalEggCount_003Ek__BackingField = num16;
		PlayerOptionsData playerOptionsData5;
		if (playerOptions3._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions3._hostGameConfig == null)
			{
				if (playerOptions3._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData2 = playerOptions3._currentAdventureSaveData;
					if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData5 = currentAdventureSaveData2;
						goto IL_1122;
					}
				}
				playerOptionsData5 = playerOptions3._mainGameConfig;
			}
			else
			{
				playerOptionsData5 = playerOptions3._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData5 = playerOptions3._onlineClientWithRunDataConfig;
		}
		goto IL_1122;
		IL_0938:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96AE0");
		float value3 = num3 + amount;
		PlayerOptionsData playerOptionsData6;
		PlayerOptionsData playerOptionsData7;
		bool flag10 = ((Dictionary<System.Int32Enum, float>)(object)playerOptionsData6._003CCharacterEggCount_003Ek__BackingField).TryInsert((System.Int32Enum)playerOptionsData7._selectedChar, value3, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		PlayerOptions playerOptions4 = _playerOptions;
		if (playerOptions4._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions4._hostGameConfig == null)
			{
				if (playerOptions4._currentAdventureSaveData != null)
				{
					playerOptionsData4 = playerOptions4._currentAdventureSaveData;
					if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_102d;
					}
				}
				playerOptionsData4 = playerOptions4._mainGameConfig;
			}
			else
			{
				playerOptionsData4 = playerOptions4._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData4 = playerOptions4._onlineClientWithRunDataConfig;
		}
		goto IL_102d;
		IL_0b7c:
		GameManager core = GM.Core;
		PlayerOptions playerOptions5 = core._playerOptions;
		PlayerOptionsData playerOptionsData8;
		if (playerOptions5._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions5._hostGameConfig == null)
			{
				if (playerOptions5._currentAdventureSaveData != null)
				{
					playerOptionsData8 = playerOptions5._currentAdventureSaveData;
					if ((object)playerOptionsData8._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0c55;
					}
				}
				playerOptionsData8 = playerOptions5._mainGameConfig;
			}
			else
			{
				playerOptionsData8 = playerOptions5._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData8 = playerOptions5._onlineClientWithRunDataConfig;
		}
		goto IL_0c55;
		IL_1122:
		List<ItemType> list = playerOptionsData5._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rcx_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				goto IL_0b7c;
			}
		}
		PlayerOptionsData config5 = _playerOptions.Config;
		_playerOptions.UnlockItem(ItemType.RELIC_GOLDENEGG, config5);
		goto IL_0b7c;
		IL_059f:
		PlayerOptionsData playerOptionsData9;
		int num17 = playerOptionsData._003CCharacterEggCount_003Ek__BackingField.FindEntry(playerOptionsData9._selectedChar);
		bool flag11 = num17 >= 0;
		nint num18 = 0;
		if (flag11)
		{
			goto IL_07ad;
		}
		PlayerOptions playerOptions6 = _playerOptions;
		PlayerOptionsData playerOptionsData10;
		if (playerOptions6._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions6._hostGameConfig == null)
			{
				if (playerOptions6._currentAdventureSaveData != null)
				{
					playerOptionsData10 = playerOptions6._currentAdventureSaveData;
					if ((object)playerOptionsData10._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0f7b;
					}
				}
				playerOptionsData10 = playerOptions6._mainGameConfig;
			}
			else
			{
				playerOptionsData10 = playerOptions6._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData10 = playerOptions6._onlineClientWithRunDataConfig;
		}
		goto IL_0f7b;
		IL_0fd4:
		PlayerOptions playerOptions7 = _playerOptions;
		if (playerOptions7._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions7._hostGameConfig == null)
			{
				if (playerOptions7._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData3 = playerOptions7._currentAdventureSaveData;
					if ((object)currentAdventureSaveData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData7 = currentAdventureSaveData3;
						goto IL_0938;
					}
				}
				playerOptionsData7 = playerOptions7._mainGameConfig;
			}
			else
			{
				playerOptionsData7 = playerOptions7._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData7 = playerOptions7._onlineClientWithRunDataConfig;
		}
		goto IL_0938;
		IL_0d62:
		PlayerOptionsData playerOptionsData11;
		int num19 = playerOptionsData11._003CRunItemsPickupCount_003Ek__BackingField.get_Item(ItemType.RELIC_GOLDENEGG);
		value2 = num19 + 1;
		behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
		key = (System.Int32Enum)27;
		dictionary3 = (Dictionary<System.Int32Enum, int>)(object)playerOptionsData11._003CRunItemsPickupCount_003Ek__BackingField;
		goto IL_1108;
		IL_076b:
		bool flag12 = ((Dictionary<System.Int32Enum, float>)(object)playerOptionsData10._003CCharacterEggCount_003Ek__BackingField).TryInsert((System.Int32Enum)playerOptionsData3._selectedChar, 0f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		num10 = 0f;
		insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
		num18 = 0;
		goto IL_07ad;
		IL_07ad:
		PlayerOptions playerOptions8 = _playerOptions;
		if (playerOptions8._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions8._hostGameConfig == null)
			{
				if (playerOptions8._currentAdventureSaveData != null)
				{
					playerOptionsData6 = playerOptions8._currentAdventureSaveData;
					if ((object)playerOptionsData6._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0fd4;
					}
				}
				playerOptionsData6 = playerOptions8._mainGameConfig;
			}
			else
			{
				playerOptionsData6 = playerOptions8._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData6 = playerOptions8._onlineClientWithRunDataConfig;
		}
		goto IL_0fd4;
		IL_0f22:
		PlayerOptions playerOptions9 = _playerOptions;
		if (playerOptions9._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions9._hostGameConfig == null)
			{
				if (playerOptions9._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData4 = playerOptions9._currentAdventureSaveData;
					if ((object)currentAdventureSaveData4._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData9 = currentAdventureSaveData4;
						goto IL_059f;
					}
				}
				playerOptionsData9 = playerOptions9._mainGameConfig;
			}
			else
			{
				playerOptionsData9 = playerOptions9._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData9 = playerOptions9._onlineClientWithRunDataConfig;
		}
		goto IL_059f;
		IL_0c55:
		int num20 = playerOptionsData8._003CRunItemsPickupCount_003Ek__BackingField.FindEntry(ItemType.RELIC_GOLDENEGG);
		if (num20 >= 0)
		{
			GameManager core2 = GM.Core;
			PlayerOptions playerOptions10 = core2._playerOptions;
			if (playerOptions10._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions10._hostGameConfig == null)
				{
					if (playerOptions10._currentAdventureSaveData != null)
					{
						playerOptionsData11 = playerOptions10._currentAdventureSaveData;
						if ((object)playerOptionsData11._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_0d62;
						}
					}
					playerOptionsData11 = playerOptions10._mainGameConfig;
				}
				else
				{
					playerOptionsData11 = playerOptions10._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData11 = playerOptions10._onlineClientWithRunDataConfig;
			}
			goto IL_0d62;
		}
		GameManager core3 = GM.Core;
		PlayerOptions playerOptions11 = core3._playerOptions;
		if (playerOptions11._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions11._hostGameConfig == null)
			{
				if (playerOptions11._currentAdventureSaveData != null)
				{
					playerOptionsData2 = playerOptions11._currentAdventureSaveData;
					if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_10f6;
					}
				}
				playerOptionsData2 = playerOptions11._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions11._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions11._onlineClientWithRunDataConfig;
		}
		goto IL_10f6;
	}

	public float GetCharacterEggStat(CharacterType t, PowerUpType p)
	{
		//IL_00b5: Expected F4, but got I4
		string typeString = GetTypeString(p);
		PlayerOptionsData config = _playerOptions.Config;
		int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)t);
		float result;
		if (num >= 0)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)t);
			int num2 = ((Dictionary<string, float>)obj).FindEntry(typeString);
			if (num2 >= 0)
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)t);
				result = ((Dictionary<object, float>)obj2).get_Item((object)typeString);
				if (p <= PowerUpType.BANISH)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt eax,ebx\"");
					if (p < PowerUpType.BANISH)
					{
						goto IL_015e;
					}
				}
				if (p == PowerUpType.REROLL)
				{
					goto IL_015e;
				}
				goto IL_0188;
			}
		}
		result = 0f;
		goto IL_0188;
		IL_0188:
		return result;
		IL_015e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num3 = default(float);
		result = num3;
		goto IL_0188;
	}

	public string GetTypeString(PowerUpType type)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F24B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		switch (type)
		{
		default:
		{
			bool flag = type == PowerUpType.REVIVAL;
			string result = "revivals";
			if (!flag)
			{
				result = "";
			}
			return result;
		}
		case PowerUpType.BANISH:
			return "banish";
		case PowerUpType.SKIP:
			return "skips";
		case PowerUpType.REROLL:
			return "rerolls";
		case PowerUpType.ARMOR:
			return "armor";
		case PowerUpType.AMOUNT:
			return "amount";
		case PowerUpType.MAGNET:
			return "magnet";
		case PowerUpType.CURSE:
			return "curse";
		case PowerUpType.GREED:
			return "greed";
		case PowerUpType.REGEN:
			return "regen";
		case PowerUpType.MAXHEALTH:
			return "maxHp";
		case PowerUpType.LUCK:
			return "luck";
		case PowerUpType.GROWTH:
			return "growth";
		case PowerUpType.MOVESPEED:
			return "moveSpeed";
		case PowerUpType.DURATION:
			return "duration";
		case PowerUpType.COOLDOWN:
			return "cooldown";
		case PowerUpType.SPEED:
			return "speed";
		case PowerUpType.AREA:
			return "area";
		case PowerUpType.POWER:
			return "power";
		}
	}

	public void ApplyBonuses(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Expected O, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Expected O, but got Unknown
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		//IL_0687: Expected O, but got Unknown
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Expected O, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Expected O, but got Unknown
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_0836: Unknown result type (might be due to invalid IL or missing references)
		//IL_083b: Expected O, but got Unknown
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected O, but got Unknown
		//IL_0910: Unknown result type (might be due to invalid IL or missing references)
		//IL_0915: Expected O, but got Unknown
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0790: Expected O, but got Unknown
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Expected O, but got Unknown
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Expected O, but got Unknown
		//IL_0ac4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac9: Expected O, but got Unknown
		//IL_093f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Expected O, but got Unknown
		//IL_0b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba3: Expected O, but got Unknown
		//IL_0a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1e: Expected O, but got Unknown
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7d: Expected O, but got Unknown
		//IL_0af3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af8: Expected O, but got Unknown
		//IL_0d52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d57: Expected O, but got Unknown
		//IL_0bcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Expected O, but got Unknown
		//IL_0e2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e31: Expected O, but got Unknown
		//IL_0ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cac: Expected O, but got Unknown
		//IL_0f06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0b: Expected O, but got Unknown
		//IL_0d81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d86: Expected O, but got Unknown
		//IL_0e5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e60: Expected O, but got Unknown
		//IL_0f35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3a: Expected O, but got Unknown
		PlayerOptionsData config = _playerOptions.Config;
		int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)player._characterType);
		if (num < 0)
		{
			return;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)player._characterType);
		int num2 = ((Dictionary<string, float>)obj).FindEntry("power");
		if (num2 < 0)
		{
			goto IL_1034;
		}
		PlayerModifierStats playerStats = player._playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float num3 = ((Dictionary<object, float>)obj).get_Item((object)"power");
		object obj2 = num3 & -2147483649L;
		if ((nint)obj2 != 2139095040)
		{
			object obj3 = num3 & -2147483649L;
			if ((nint)obj3 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186968C13h\"");
				if (num3 == -1f / 0f)
				{
					num3 = -3.4028235E+38f;
				}
				goto IL_1063;
			}
		}
		num3 = 3.4028235E+38f;
		goto IL_1063;
		IL_12be:
		int num4 = ((Dictionary<string, float>)obj).FindEntry("magnet");
		if (num4 < 0)
		{
			goto IL_12ff;
		}
		MagnetZone magnet = player._magnet;
		EggFloat radius = magnet.Radius;
		float num5 = ((Dictionary<object, float>)obj).get_Item((object)"magnet");
		object obj4 = num5 & -2147483649L;
		if ((nint)obj4 != 2139095040)
		{
			object obj5 = num5 & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001869692CCh\"");
				if (num5 == -1f / 0f)
				{
					num5 = -3.4028235E+38f;
				}
				goto IL_132e;
			}
		}
		num5 = 3.4028235E+38f;
		goto IL_132e;
		IL_12ed:
		EggFloat eggFloat2;
		float num6;
		eggFloat2._eggVal = num6;
		goto IL_12be;
		IL_1138:
		int num7 = ((Dictionary<string, float>)obj).FindEntry("growth");
		if (num7 < 0)
		{
			goto IL_1179;
		}
		PlayerModifierStats playerStats2 = player._playerStats;
		EggFloat eggFloat3 = playerStats2._003CGrowth_003Ek__BackingField;
		float num8 = ((Dictionary<object, float>)obj).get_Item((object)"growth");
		object obj6 = num8 & -2147483649L;
		if ((nint)obj6 != 2139095040)
		{
			object obj7 = num8 & -2147483649L;
			if ((nint)obj7 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186968F5Ah\"");
				if (num8 == -1f / 0f)
				{
					num8 = -3.4028235E+38f;
				}
				goto IL_11a8;
			}
		}
		num8 = 3.4028235E+38f;
		goto IL_11a8;
		IL_1167:
		EggFloat eggFloat4;
		float num9;
		eggFloat4._eggVal = num9;
		goto IL_1138;
		IL_136f:
		EggFloat eggFloat5;
		float num10;
		eggFloat5._eggVal = num10;
		goto IL_1340;
		IL_126b:
		EggFloat eggFloat6;
		float num11;
		eggFloat6._eggVal = num11;
		goto IL_123c;
		IL_1063:
		eggFloat._eggVal = num3;
		goto IL_1034;
		IL_1034:
		int num12 = ((Dictionary<string, float>)obj).FindEntry("area");
		if (num12 < 0)
		{
			goto IL_1075;
		}
		PlayerModifierStats playerStats3 = player._playerStats;
		EggFloat eggFloat7 = playerStats3._003CArea_003Ek__BackingField;
		float num13 = ((Dictionary<object, float>)obj).get_Item((object)"area");
		object obj8 = num13 & -2147483649L;
		if ((nint)obj8 != 2139095040)
		{
			object obj9 = num13 & -2147483649L;
			if ((nint)obj9 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186968CA5h\"");
				if (num13 == -1f / 0f)
				{
					num13 = -3.4028235E+38f;
				}
				goto IL_10a4;
			}
		}
		num13 = 3.4028235E+38f;
		goto IL_10a4;
		IL_1403:
		int num14 = ((Dictionary<string, float>)obj).FindEntry("banish");
		if (num14 < 0)
		{
			goto IL_1444;
		}
		PlayerModifierStats playerStats4 = player._playerStats;
		EggFloat eggFloat8 = playerStats4._003CBanish_003Ek__BackingField;
		float num15 = ((Dictionary<object, float>)obj).get_Item((object)"banish");
		object obj10 = num15 & -2147483649L;
		float eggVal;
		if ((nint)obj10 != 2139095040)
		{
			object obj11 = num15 & -2147483649L;
			if ((nint)obj11 <= 2139095040)
			{
				bool flag = num15 == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001869695A1h\"");
				eggVal = -3.4028235E+38f;
				if (!flag)
				{
					eggVal = num15;
				}
				goto IL_1473;
			}
		}
		eggVal = 3.4028235E+38f;
		goto IL_1473;
		IL_1340:
		int num16 = ((Dictionary<string, float>)obj).FindEntry("armor");
		if (num16 < 0)
		{
			goto IL_1381;
		}
		PlayerModifierStats playerStats5 = player._playerStats;
		EggFloat eggFloat9 = playerStats5._003CArmor_003Ek__BackingField;
		float num17 = ((Dictionary<object, float>)obj).get_Item((object)"armor");
		object obj12 = num17 & -2147483649L;
		if ((nint)obj12 != 2139095040)
		{
			object obj13 = num17 & -2147483649L;
			if ((nint)obj13 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001869693F0h\"");
				if (num17 == -1f / 0f)
				{
					num17 = -3.4028235E+38f;
				}
				goto IL_13b0;
			}
		}
		num17 = 3.4028235E+38f;
		goto IL_13b0;
		IL_123c:
		int num18 = ((Dictionary<string, float>)obj).FindEntry("greed");
		if (num18 < 0)
		{
			goto IL_127d;
		}
		PlayerModifierStats playerStats6 = player._playerStats;
		EggFloat eggFloat10 = playerStats6._003CGreed_003Ek__BackingField;
		float num19 = ((Dictionary<object, float>)obj).get_Item((object)"greed");
		object obj14 = num19 & -2147483649L;
		if ((nint)obj14 != 2139095040)
		{
			object obj15 = num19 & -2147483649L;
			if ((nint)obj15 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001869691A5h\"");
				if (num19 == -1f / 0f)
				{
					num19 = -3.4028235E+38f;
				}
				goto IL_12ac;
			}
		}
		num19 = 3.4028235E+38f;
		goto IL_12ac;
		IL_11a8:
		eggFloat3._eggVal = num8;
		goto IL_1179;
		IL_1179:
		int num20 = ((Dictionary<string, float>)obj).FindEntry("luck");
		if (num20 < 0)
		{
			goto IL_11ba;
		}
		PlayerModifierStats playerStats7 = player._playerStats;
		EggFloat eggFloat11 = playerStats7._003CLuck_003Ek__BackingField;
		float num21 = ((Dictionary<object, float>)obj).get_Item((object)"luck");
		object obj16 = num21 & -2147483649L;
		if ((nint)obj16 != 2139095040)
		{
			object obj17 = num21 & -2147483649L;
			if ((nint)obj17 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186968FECh\"");
				if (num21 == -1f / 0f)
				{
					num21 = -3.4028235E+38f;
				}
				goto IL_11e9;
			}
		}
		num21 = 3.4028235E+38f;
		goto IL_11e9;
		IL_10a4:
		eggFloat7._eggVal = num13;
		goto IL_1075;
		IL_1075:
		int num22 = ((Dictionary<string, float>)obj).FindEntry("speed");
		if (num22 >= 0)
		{
			PlayerModifierStats playerStats8 = player._playerStats;
			float eggVal2 = ((Dictionary<object, float>)obj).get_Item((object)"speed");
			playerStats8._003CSpeed_003Ek__BackingField.EggVal = eggVal2;
		}
		int num23 = ((Dictionary<string, float>)obj).FindEntry("cooldown");
		if (num23 < 0)
		{
			goto IL_10b6;
		}
		PlayerModifierStats playerStats9 = player._playerStats;
		EggFloat eggFloat12 = playerStats9._003CCooldown_003Ek__BackingField;
		float num24 = ((Dictionary<object, float>)obj).get_Item((object)"cooldown");
		object obj18 = num24 & -2147483649L;
		if ((nint)obj18 != 2139095040)
		{
			object obj19 = num24 & -2147483649L;
			if ((nint)obj19 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186968DA4h\"");
				if (num24 == -1f / 0f)
				{
					num24 = -3.4028235E+38f;
				}
				goto IL_10e5;
			}
		}
		num24 = 3.4028235E+38f;
		goto IL_10e5;
		IL_132e:
		radius._eggVal = num5;
		goto IL_12ff;
		IL_1444:
		int num25 = ((Dictionary<string, float>)obj).FindEntry("revivals");
		if (num25 >= 0)
		{
			PlayerModifierStats playerStats10 = player._playerStats;
			float num26 = ((Dictionary<object, float>)obj).get_Item((object)"revivals");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
			playerStats10._003CRevivals_003Ek__BackingField.EggVal = 0.0;
		}
		int num27 = ((Dictionary<string, float>)obj).FindEntry("magnet");
		if (num27 >= 0)
		{
			player._magnet.RefreshSize();
		}
		return;
		IL_1432:
		EggFloat eggFloat13;
		float num28;
		eggFloat13._eggVal = num28;
		goto IL_1403;
		IL_12ac:
		eggFloat10._eggVal = num19;
		goto IL_127d;
		IL_12ff:
		int num29 = ((Dictionary<string, float>)obj).FindEntry("amount");
		if (num29 < 0)
		{
			goto IL_1340;
		}
		PlayerModifierStats playerStats11 = player._playerStats;
		eggFloat5 = playerStats11._003CAmount_003Ek__BackingField;
		num10 = ((Dictionary<object, float>)obj).get_Item((object)"amount");
		object obj20 = num10 & -2147483649L;
		if ((nint)obj20 != 2139095040)
		{
			object obj21 = num10 & -2147483649L;
			if ((nint)obj21 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018696935Eh\"");
				if (num10 == -1f / 0f)
				{
					num10 = -3.4028235E+38f;
				}
				goto IL_136f;
			}
		}
		num10 = 3.4028235E+38f;
		goto IL_136f;
		IL_11e9:
		eggFloat11._eggVal = num21;
		goto IL_11ba;
		IL_11ba:
		int num30 = ((Dictionary<string, float>)obj).FindEntry("maxHp");
		if (num30 < 0)
		{
			goto IL_11fb;
		}
		PlayerModifierStats playerStats12 = player._playerStats;
		EggFloat eggFloat14 = playerStats12._003CMaxHp_003Ek__BackingField;
		float num31 = ((Dictionary<object, float>)obj).get_Item((object)"maxHp");
		object obj22 = num31 & -2147483649L;
		if ((nint)obj22 != 2139095040)
		{
			object obj23 = num31 & -2147483649L;
			if ((nint)obj23 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186969081h\"");
				if (num31 == -1f / 0f)
				{
					num31 = -3.4028235E+38f;
				}
				goto IL_122a;
			}
		}
		num31 = 3.4028235E+38f;
		goto IL_122a;
		IL_10e5:
		eggFloat12._eggVal = num24;
		goto IL_10b6;
		IL_10b6:
		int num32 = ((Dictionary<string, float>)obj).FindEntry("duration");
		if (num32 < 0)
		{
			goto IL_10f7;
		}
		PlayerModifierStats playerStats13 = player._playerStats;
		EggFloat eggFloat15 = playerStats13._003CDuration_003Ek__BackingField;
		float num33 = ((Dictionary<object, float>)obj).get_Item((object)"duration");
		object obj24 = num33 & -2147483649L;
		if ((nint)obj24 != 2139095040)
		{
			object obj25 = num33 & -2147483649L;
			if ((nint)obj25 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186968E36h\"");
				if (num33 == -1f / 0f)
				{
					num33 = -3.4028235E+38f;
				}
				goto IL_1126;
			}
		}
		num33 = 3.4028235E+38f;
		goto IL_1126;
		IL_127d:
		int num34 = ((Dictionary<string, float>)obj).FindEntry("curse");
		if (num34 < 0)
		{
			goto IL_12be;
		}
		PlayerModifierStats playerStats14 = player._playerStats;
		eggFloat2 = playerStats14._003CCurse_003Ek__BackingField;
		num6 = ((Dictionary<object, float>)obj).get_Item((object)"curse");
		object obj26 = num6 & -2147483649L;
		if ((nint)obj26 != 2139095040)
		{
			object obj27 = num6 & -2147483649L;
			if ((nint)obj27 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018696923Ah\"");
				if (num6 == -1f / 0f)
				{
					num6 = -3.4028235E+38f;
				}
				goto IL_12ed;
			}
		}
		num6 = 3.4028235E+38f;
		goto IL_12ed;
		IL_1473:
		eggFloat8._eggVal = eggVal;
		goto IL_1444;
		IL_13f1:
		EggFloat eggFloat16;
		float num35;
		eggFloat16._eggVal = num35;
		goto IL_13c2;
		IL_13b0:
		eggFloat9._eggVal = num17;
		goto IL_1381;
		IL_1381:
		int num36 = ((Dictionary<string, float>)obj).FindEntry("rerolls");
		if (num36 < 0)
		{
			goto IL_13c2;
		}
		PlayerModifierStats playerStats15 = player._playerStats;
		eggFloat16 = playerStats15._003CReRolls_003Ek__BackingField;
		num35 = ((Dictionary<object, float>)obj).get_Item((object)"rerolls");
		object obj28 = num35 & -2147483649L;
		if ((nint)obj28 != 2139095040)
		{
			object obj29 = num35 & -2147483649L;
			if ((nint)obj29 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186969482h\"");
				if (num35 == -1f / 0f)
				{
					num35 = -3.4028235E+38f;
				}
				goto IL_13f1;
			}
		}
		num35 = 3.4028235E+38f;
		goto IL_13f1;
		IL_1126:
		eggFloat15._eggVal = num33;
		goto IL_10f7;
		IL_10f7:
		int num37 = ((Dictionary<string, float>)obj).FindEntry("moveSpeed");
		if (num37 < 0)
		{
			goto IL_1138;
		}
		PlayerModifierStats playerStats16 = player._playerStats;
		eggFloat4 = playerStats16._003CMoveSpeed_003Ek__BackingField;
		num9 = ((Dictionary<object, float>)obj).get_Item((object)"moveSpeed");
		object obj30 = num9 & -2147483649L;
		if ((nint)obj30 != 2139095040)
		{
			object obj31 = num9 & -2147483649L;
			if ((nint)obj31 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186968EC8h\"");
				if (num9 == -1f / 0f)
				{
					num9 = -3.4028235E+38f;
				}
				goto IL_1167;
			}
		}
		num9 = 3.4028235E+38f;
		goto IL_1167;
		IL_122a:
		eggFloat14._eggVal = num31;
		goto IL_11fb;
		IL_13c2:
		int num38 = ((Dictionary<string, float>)obj).FindEntry("skips");
		if (num38 < 0)
		{
			goto IL_1403;
		}
		PlayerModifierStats playerStats17 = player._playerStats;
		eggFloat13 = playerStats17._003CSkips_003Ek__BackingField;
		num28 = ((Dictionary<object, float>)obj).get_Item((object)"skips");
		object obj32 = num28 & -2147483649L;
		if ((nint)obj32 != 2139095040)
		{
			object obj33 = num28 & -2147483649L;
			if ((nint)obj33 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186969514h\"");
				if (num28 == -1f / 0f)
				{
					num28 = -3.4028235E+38f;
				}
				goto IL_1432;
			}
		}
		num28 = 3.4028235E+38f;
		goto IL_1432;
		IL_11fb:
		int num39 = ((Dictionary<string, float>)obj).FindEntry("regen");
		if (num39 < 0)
		{
			goto IL_123c;
		}
		PlayerModifierStats playerStats18 = player._playerStats;
		eggFloat6 = playerStats18._003CRegen_003Ek__BackingField;
		num11 = ((Dictionary<object, float>)obj).get_Item((object)"regen");
		object obj34 = num11 & -2147483649L;
		if ((nint)obj34 != 2139095040)
		{
			object obj35 = num11 & -2147483649L;
			if ((nint)obj35 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186969113h\"");
				if (num11 == -1f / 0f)
				{
					num11 = -3.4028235E+38f;
				}
				goto IL_126b;
			}
		}
		num11 = 3.4028235E+38f;
		goto IL_126b;
	}

	public float RemoveBonuses()
	{
		//IL_0e78: Expected F4, but got I4
		//IL_0237: Expected F4, but got I4
		//IL_02d4: Expected F4, but got I4
		//IL_0371: Expected F4, but got I4
		//IL_040e: Expected F4, but got I4
		//IL_04ab: Expected F4, but got I4
		//IL_0548: Expected F4, but got I4
		//IL_05e5: Expected F4, but got I4
		//IL_0682: Expected F4, but got I4
		//IL_071f: Expected F4, but got I4
		//IL_07bc: Expected F4, but got I4
		//IL_0859: Expected F4, but got I4
		//IL_08f6: Expected F4, but got I4
		//IL_0993: Expected F4, but got I4
		//IL_0a30: Expected F4, but got I4
		//IL_0acd: Expected F4, but got I4
		//IL_0c99: Expected F4, but got I4
		//IL_0b6a: Expected F4, but got I4
		//IL_0c07: Expected F4, but got I4
		//IL_0e61: Expected O, but got I4
		GameSessionData session = _session;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter;
		float result = default(float);
		object obj;
		if (_session != null)
		{
			activeCharacter = session._activeCharacter;
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null && (object)session._activeCharacter != null && config._003CCharacterEggInfo_003Ek__BackingField != null)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterEggInfo_003Ek__BackingField).FindEntry((System.Int32Enum)activeCharacter._characterType);
					if (num < 0)
					{
						result = 0f;
						goto IL_0e6a;
					}
					if (_playerOptions != null)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						if (config2 != null && config2._003CCharacterEggInfo_003Ek__BackingField != null)
						{
							obj = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)activeCharacter._characterType);
							if (obj != null)
							{
								int num2 = ((Dictionary<string, float>)obj).FindEntry("power");
								if (num2 < 0)
								{
									goto IL_0eb1;
								}
								PlayerModifierStats playerStats = activeCharacter._playerStats;
								if (activeCharacter._playerStats != null)
								{
									EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
									if (playerStats._003CPower_003Ek__BackingField != null)
									{
										result = (eggFloat._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
										goto IL_0eb1;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0e7d;
		IL_123f:
		int num3 = ((Dictionary<string, float>)obj).FindEntry("rerolls");
		if (num3 >= 0)
		{
			PlayerModifierStats playerStats2 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat2 = playerStats2._003CReRolls_003Ek__BackingField;
				if (playerStats2._003CReRolls_003Ek__BackingField != null)
				{
					result = (eggFloat2._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_1280;
				}
			}
			goto IL_0e7d;
		}
		goto IL_1280;
		IL_10b9:
		int num4 = ((Dictionary<string, float>)obj).FindEntry("regen");
		if (num4 >= 0)
		{
			PlayerModifierStats playerStats3 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat3 = playerStats3._003CRegen_003Ek__BackingField;
				if (playerStats3._003CRegen_003Ek__BackingField != null)
				{
					result = (eggFloat3._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_10fa;
				}
			}
			goto IL_0e7d;
		}
		goto IL_10fa;
		IL_1302:
		int num5 = ((Dictionary<string, float>)obj).FindEntry("revivals");
		if (num5 >= 0)
		{
			PlayerModifierStats playerStats4 = activeCharacter._playerStats;
			if (activeCharacter._playerStats == null || playerStats4._003CRevivals_003Ek__BackingField == null)
			{
				goto IL_0e7d;
			}
			playerStats4._003CRevivals_003Ek__BackingField.EggVal = 0.0;
		}
		int num6 = ((Dictionary<string, float>)obj).FindEntry("magnet");
		if (num6 >= 0)
		{
			if ((object)activeCharacter._magnet == null)
			{
				goto IL_0e7d;
			}
			activeCharacter._magnet.RefreshSize();
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			core._stage.RecalculateCurseAndCharm();
			if (_playerOptions != null)
			{
				PlayerOptionsData config3 = _playerOptions.Config;
				if (config3 != null && config3._003CCharacterEggCount_003Ek__BackingField != null)
				{
					int num7 = ((Dictionary<string, float>)(object)config3._003CCharacterEggCount_003Ek__BackingField).FindEntry((string)activeCharacter._characterType);
					goto IL_0e6a;
				}
			}
		}
		goto IL_0e7d;
		IL_11bd:
		int num8 = ((Dictionary<string, float>)obj).FindEntry("amount");
		if (num8 >= 0)
		{
			PlayerModifierStats playerStats5 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat4 = playerStats5._003CAmount_003Ek__BackingField;
				if (playerStats5._003CAmount_003Ek__BackingField != null)
				{
					result = (eggFloat4._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_11fe;
				}
			}
			goto IL_0e7d;
		}
		goto IL_11fe;
		IL_0ef2:
		int num9 = ((Dictionary<string, float>)obj).FindEntry("speed");
		if (num9 >= 0)
		{
			PlayerModifierStats playerStats6 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat5 = playerStats6._003CSpeed_003Ek__BackingField;
				if (playerStats6._003CSpeed_003Ek__BackingField != null)
				{
					result = (eggFloat5._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_0f33;
				}
			}
			goto IL_0e7d;
		}
		goto IL_0f33;
		IL_1280:
		int num10 = ((Dictionary<string, float>)obj).FindEntry("skips");
		if (num10 >= 0)
		{
			PlayerModifierStats playerStats7 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat6 = playerStats7._003CSkips_003Ek__BackingField;
				if (playerStats7._003CSkips_003Ek__BackingField != null)
				{
					result = (eggFloat6._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_12c1;
				}
			}
			goto IL_0e7d;
		}
		goto IL_12c1;
		IL_1037:
		int num11 = ((Dictionary<string, float>)obj).FindEntry("luck");
		if (num11 >= 0)
		{
			PlayerModifierStats playerStats8 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat7 = playerStats8._003CLuck_003Ek__BackingField;
				if (playerStats8._003CLuck_003Ek__BackingField != null)
				{
					result = (eggFloat7._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_1078;
				}
			}
			goto IL_0e7d;
		}
		goto IL_1078;
		IL_0fb5:
		int num12 = ((Dictionary<string, float>)obj).FindEntry("moveSpeed");
		if (num12 >= 0)
		{
			PlayerModifierStats playerStats9 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat8 = playerStats9._003CMoveSpeed_003Ek__BackingField;
				if (playerStats9._003CMoveSpeed_003Ek__BackingField != null)
				{
					result = (eggFloat8._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_0ff6;
				}
			}
			goto IL_0e7d;
		}
		goto IL_0ff6;
		IL_11fe:
		int num13 = ((Dictionary<string, float>)obj).FindEntry("armor");
		if (num13 >= 0)
		{
			PlayerModifierStats playerStats10 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat9 = playerStats10._003CArmor_003Ek__BackingField;
				if (playerStats10._003CArmor_003Ek__BackingField != null)
				{
					result = (eggFloat9._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_123f;
				}
			}
			goto IL_0e7d;
		}
		goto IL_123f;
		IL_117c:
		int num14 = ((Dictionary<string, float>)obj).FindEntry("magnet");
		if (num14 >= 0)
		{
			MagnetZone magnet = activeCharacter._magnet;
			if ((object)activeCharacter._magnet != null)
			{
				EggFloat radius = magnet.Radius;
				if (magnet.Radius != null)
				{
					result = (radius._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_11bd;
				}
			}
			goto IL_0e7d;
		}
		goto IL_11bd;
		IL_0e7d:
		throw new NullReferenceException();
		IL_0f33:
		int num15 = ((Dictionary<string, float>)obj).FindEntry("cooldown");
		if (num15 >= 0)
		{
			PlayerModifierStats playerStats11 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat10 = playerStats11._003CCooldown_003Ek__BackingField;
				if (playerStats11._003CCooldown_003Ek__BackingField != null)
				{
					result = (eggFloat10._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_0f74;
				}
			}
			goto IL_0e7d;
		}
		goto IL_0f74;
		IL_1078:
		int num16 = ((Dictionary<string, float>)obj).FindEntry("maxHp");
		if (num16 >= 0)
		{
			PlayerModifierStats playerStats12 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat11 = playerStats12._003CMaxHp_003Ek__BackingField;
				if (playerStats12._003CMaxHp_003Ek__BackingField != null)
				{
					result = (eggFloat11._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_10b9;
				}
			}
			goto IL_0e7d;
		}
		goto IL_10b9;
		IL_113b:
		int num17 = ((Dictionary<string, float>)obj).FindEntry("curse");
		if (num17 >= 0)
		{
			PlayerModifierStats playerStats13 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat12 = playerStats13._003CCurse_003Ek__BackingField;
				if (playerStats13._003CCurse_003Ek__BackingField != null)
				{
					result = (eggFloat12._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_117c;
				}
			}
			goto IL_0e7d;
		}
		goto IL_117c;
		IL_0e6a:
		return result;
		IL_10fa:
		int num18 = ((Dictionary<string, float>)obj).FindEntry("greed");
		if (num18 >= 0)
		{
			PlayerModifierStats playerStats14 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat13 = playerStats14._003CGreed_003Ek__BackingField;
				if (playerStats14._003CGreed_003Ek__BackingField != null)
				{
					result = (eggFloat13._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_113b;
				}
			}
			goto IL_0e7d;
		}
		goto IL_113b;
		IL_12c1:
		int num19 = ((Dictionary<string, float>)obj).FindEntry("banish");
		if (num19 >= 0)
		{
			PlayerModifierStats playerStats15 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat14 = playerStats15._003CBanish_003Ek__BackingField;
				if (playerStats15._003CBanish_003Ek__BackingField != null)
				{
					bool flag = 0 <= 2139095040;
					float eggVal = 0f;
					if (!flag)
					{
						eggVal = 3.4028235E+38f;
					}
					eggFloat14._eggVal = eggVal;
					goto IL_1302;
				}
			}
			goto IL_0e7d;
		}
		goto IL_1302;
		IL_0eb1:
		int num20 = ((Dictionary<string, float>)obj).FindEntry("area");
		if (num20 >= 0)
		{
			PlayerModifierStats playerStats16 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat15 = playerStats16._003CArea_003Ek__BackingField;
				if (playerStats16._003CArea_003Ek__BackingField != null)
				{
					result = (eggFloat15._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_0ef2;
				}
			}
			goto IL_0e7d;
		}
		goto IL_0ef2;
		IL_0ff6:
		int num21 = ((Dictionary<string, float>)obj).FindEntry("growth");
		if (num21 >= 0)
		{
			PlayerModifierStats playerStats17 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat16 = playerStats17._003CGrowth_003Ek__BackingField;
				if (playerStats17._003CGrowth_003Ek__BackingField != null)
				{
					result = (eggFloat16._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_1037;
				}
			}
			goto IL_0e7d;
		}
		goto IL_1037;
		IL_0f74:
		int num22 = ((Dictionary<string, float>)obj).FindEntry("duration");
		if (num22 >= 0)
		{
			PlayerModifierStats playerStats18 = activeCharacter._playerStats;
			if (activeCharacter._playerStats != null)
			{
				EggFloat eggFloat17 = playerStats18._003CDuration_003Ek__BackingField;
				if (playerStats18._003CDuration_003Ek__BackingField != null)
				{
					result = (eggFloat17._eggVal = ((0 > 2139095040) ? 3.4028235E+38f : 0f));
					goto IL_0fb5;
				}
			}
			goto IL_0e7d;
		}
		goto IL_0fb5;
	}

	public unsafe void ShowResultAt(Vector2 target, KeyValuePair<string, float> result, float offsetX = -16f, float offsetY = 16f)
	{
		//IL_0577: Expected O, but got F4
		//IL_073c: Expected O, but got F4
		//IL_05e7: Expected I, but got O
		//IL_026d: Expected F4, but got I
		//IL_070c: Expected O, but got I4
		//IL_0639->IL0549: Incompatible stack heights: 2 vs 0
		//IL_051f->IL04f0: Incompatible stack heights: 4 vs 2
		//IL_020a->IL020a: Incompatible stack heights: 5 vs 4
		//IL_04b7->IL04f0: Incompatible stack heights: 4 vs 2
		//IL_04d9->IL04f0: Incompatible stack heights: 4 vs 2
		//IL_04f0->IL04f0: Incompatible stack heights: 4 vs 2
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass33_0();
		object obj = default(object);
		float num = (float)obj * 0.01f;
		object obj2 = UnityEngine.Random.value;
		object obj3 = UnityEngine.Random.value;
		object obj4 = default(object);
		float num2 = (float)obj4 + num;
		object obj5 = default(object);
		float num3 = (float)obj5 * num;
		float num4 = num3 + num2;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "EggySpritey");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector2 value = default(Vector2);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			CS_0024_003C_003E8__locals6.gameObject = gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer component = RenderingExtensions.AddSprite(spriteName: LookUpFrame((string)result), gameObject: CS_0024_003C_003E8__locals6.gameObject, pos: pos, textureName: "items");
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 2f);
			bool flag2 = ((EggManager)(object)spriteRenderer)._attributes == null;
			Renderer.set_sortingOrder_Injected((IntPtr)((EggManager)(object)spriteRenderer)._attributes, 3100);
			GameObject gameObject2 = Resources.Load<GameObject>("GoldenEggText");
			if ((object)gameObject2 != null && ((string)(object)gameObject2)._stringLength != 0)
			{
				if ((object)CS_0024_003C_003E8__locals6.gameObject == null)
				{
					goto IL_0549;
				}
				Transform transform2 = CS_0024_003C_003E8__locals6.gameObject.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
				GameObject gameObject3 = default(GameObject);
				if ((object)gameObject3 != null && ((UnityEngine.Object)gameObject3).m_CachedPtr != (IntPtr)0)
				{
					Transform transform3 = gameObject3.transform;
					bool flag3 = (object)transform3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1793 @ rax_v86 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1793 @ rax_v86 (UnityEngine.Transform)+10]");
					Vector2 value2 = default(Vector2);
					Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value2));
					TextMeshPro componentInChildren = gameObject3.GetComponentInChildren<TextMeshPro>(includeInactive: false);
					if ((object)componentInChildren != null && ((UnityEngine.Object)componentInChildren).m_CachedPtr != (IntPtr)0)
					{
						uint[] array = new uint[3] { 16776960u, 65280u, 65535u };
						if (array != null && array.Length != 0)
						{
							object obj6 = UnityEngine.Random.RandomRangeInt(0, array.Length);
							bool flag5 = (nint)obj6 >= array.Length;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
						}
						componentInChildren.sortingOrder = 3101;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [result @ r8 (System.Collections.Generic.KeyValuePair`2<System.String, System.Single>)+8]");
						bool flag6 = (nint)0 <= (nint)0;
						string text = "";
						if (!flag6)
						{
							text = "+";
						}
						NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [result @ r8 (System.Collections.Generic.KeyValuePair`2<System.String, System.Single>)+8]");
						string text2 = System.Number.FormatSingle(0f, null, currentInfo);
						string text3 = text + text2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
						Sequence sequence = DOTween.Sequence();
						TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(spriteRenderer, 0f, 2f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
						{
							Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
						}
						Transform transform4 = spriteRenderer.transform;
						float endValue = num4 + 0.19999999f;
						TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOMoveY(transform4, endValue, 2f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
						{
							Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
						}
						TweenerCore<Color, Color, ColorOptions> t3 = DOTweenModuleUI.DOFade(componentInChildren, 0f, 2f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t3, false))
						{
							Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t3, 0f);
						}
						Transform transform5 = componentInChildren.transform;
						float endValue2 = num4 + 0.19999999f;
						TweenerCore<Vector3, Vector3, VectorOptions> t4 = ShortcutExtensions.DOMoveY(transform5, endValue2, 2f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t4, false))
						{
							Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)t4, 0f);
						}
						Sequence sequence6 = VampireSurvivors.Tools.TweenExtensions.SetGameId(sequence);
						TweenCallback onComplete = delegate
						{
							UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals6.gameObject, 0f);
							UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals6.gameObject, 0f);
						};
						if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
						{
							sequence.onComplete = onComplete;
						}
					}
					else
					{
						GameObject gameObject4 = spriteRenderer.gameObject;
						UnityEngine.Object.Destroy(gameObject4);
						UnityEngine.Object.Destroy(gameObject3);
					}
					return;
				}
			}
			GameObject gameObject5 = spriteRenderer.gameObject;
			UnityEngine.Object.Destroy(gameObject5, 0f);
			return;
		}
		goto IL_0549;
		IL_0549:
		throw new NullReferenceException();
	}

	public void RemoveAllEggs()
	{
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96AE0");
		PlayerOptionsData config3 = _playerOptions.Config;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
		((Dictionary<string, float>)obj).Clear();
		PlayerOptionsData config4 = _playerOptions.Config;
		bool flag = ((Dictionary<System.Int32Enum, float>)(object)config4._003CCharacterEggCount_003Ek__BackingField).TryInsert((System.Int32Enum)config._selectedChar, 0f, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		PlayerOptionsData config5 = _playerOptions.Config;
		object obj2 = default(object);
		float num = config5._003CTotalEggCount_003Ek__BackingField - (float)obj2;
		config5._003CTotalEggCount_003Ek__BackingField = num;
	}

	public KeyValuePair<string, float> RemoveAllSpecificEggs(string attributeName)
	{
		//IL_04a6: Expected O, but got I4
		//IL_0016: Expected O, but got I
		//IL_0059: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_00cf: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_0122: Expected O, but got I4
		//IL_013f: Expected O, but got I
		//IL_0155: Expected O, but got I
		//IL_01ba: Expected O, but got I
		//IL_01fa: Invalid comparison between F4 and I4
		//IL_0229: Expected O, but got I
		//IL_029b: Expected O, but got I
		//IL_02f2: Expected O, but got I
		//IL_0344: Expected O, but got I
		//IL_03b1: Expected O, but got I
		//IL_03de: Invalid comparison between I4 and F4
		//IL_044a: Expected O, but got I
		//IL_0406: Expected O, but got I
		EggManager eggManager = (EggManager)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
		PlayerOptionsData config = ((PlayerOptions)0).Config;
		if (attributeName._stringLength != 0)
		{
			List<KeyValuePair<object, float>> list = new List<KeyValuePair<object, float>>((IEnumerable<KeyValuePair<object, float>>)attributeName._stringLength);
			Dictionary<string, float>.KeyCollection keys = ((Dictionary<string, float>)attributeName._stringLength).Keys;
			if (keys != null)
			{
				List<object> list2 = new List<object>(keys);
				IntPtr intPtr = default(IntPtr);
				int num = Array.IndexOf(list2._items, (nint)intPtr, 0, list2._size);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ rax_v21 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Object, System.Single>>)+18]");
				if ((nint)num < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ rax_v21 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Object, System.Single>>)+10]");
					object obj = 0;
					object obj2 = num + 2;
					object obj3 = obj2 + obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rcx_v28+v148 @ rax_v32*8]");
					eggManager = (EggManager)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
					PlayerOptionsData config2 = ((PlayerOptions)0).Config;
					object obj4 = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
					int num2 = ((Dictionary<string, float>)obj4).FindEntry((string)(object)this);
					if (num2 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
						PlayerOptionsData config3 = ((PlayerOptions)0).Config;
						object obj5 = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
						float num3 = ((Dictionary<object, float>)obj5).get_Item((object)this);
						bool flag = num3 == 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018696B4ABh\"");
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
							PlayerOptionsData config4 = ((PlayerOptions)0).Config;
							object obj6 = ((Dictionary<System.Int32Enum, object>)(object)config4._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
							float num4 = ((Dictionary<object, float>)obj6).get_Item((object)this);
							float num5 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.EggManager)+8]");
							float num6 = num5 / 0f;
							float num7 = ((Dictionary<string, float>)obj6).get_Item((string)(object)this);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
							PlayerOptionsData config5 = ((PlayerOptions)0).Config;
							object obj7 = ((Dictionary<System.Int32Enum, object>)(object)config5._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
							bool flag2 = ((Dictionary<object, float>)obj7).TryInsert((object)this, 0f, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
							PlayerOptionsData config6 = ((PlayerOptions)0).Config;
							int num8 = config6._003CCharacterEggCount_003Ek__BackingField.FindEntry(config._selectedChar);
							if (num8 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
								PlayerOptionsData config7 = ((PlayerOptions)0).Config;
								int num9 = config7._003CCharacterEggCount_003Ek__BackingField.FindEntry(config._selectedChar);
								float num10 = num6 - num6;
								bool flag3 = ((Dictionary<System.Int32Enum, float>)(object)config7._003CCharacterEggCount_003Ek__BackingField).TryInsert((System.Int32Enum)config._selectedChar, num10, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
								PlayerOptionsData config8 = ((PlayerOptions)0).Config;
								int num11 = config8._003CCharacterEggCount_003Ek__BackingField.FindEntry(config._selectedChar);
								if (0f > num10)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
									PlayerOptionsData config9 = ((PlayerOptions)0).Config;
									bool flag4 = ((Dictionary<System.Int32Enum, float>)(object)config9._003CCharacterEggCount_003Ek__BackingField).TryInsert((System.Int32Enum)config._selectedChar, 0f, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [attributeName @ rdx (System.String)+28]");
								PlayerOptionsData config10 = ((PlayerOptions)0).Config;
								float num12 = config10._003CTotalEggCount_003Ek__BackingField - num6;
								config10._003CTotalEggCount_003Ek__BackingField = num12;
							}
							goto IL_04e6;
						}
					}
					eggManager = (EggManager)(object)"undefined";
					_ = 0;
					goto IL_04e6;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
		IL_04e6:
		return (KeyValuePair<string, float>)this;
	}

	public unsafe KeyValuePair<string, float> RemoveRandomEgg()
	{
		//IL_05ec: Expected O, but got I4
		//IL_0016: Expected O, but got I
		//IL_0030: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_00aa: Expected O, but got I
		//IL_00cc: Expected O, but got I
		//IL_05ff: Expected I4, but got O
		//IL_0603: Expected O, but got I4
		//IL_0104: Expected O, but got I
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0134: Expected O, but got I
		//IL_014a: Expected O, but got I
		//IL_01af: Expected O, but got I
		//IL_01ef: Invalid comparison between F4 and I4
		//IL_021e: Expected O, but got I
		//IL_028d: Expected I, but got O
		//IL_0441: Expected O, but got I
		//IL_0382: Expected O, but got I
		//IL_0493: Expected O, but got I
		//IL_03c2: Invalid comparison between I4 and F4
		//IL_0501: Expected O, but got I
		//IL_052e: Invalid comparison between I4 and F4
		//IL_03ea: Expected O, but got I
		//IL_059a: Expected O, but got I
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected Ref, but got Unknown
		//IL_0343: Expected I8, but got I
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected Ref, but got Unknown
		//IL_0556: Expected O, but got I
		EggManager eggManager = (EggManager)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
		PlayerOptionsData config = ((PlayerOptions)0).Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
		PlayerOptionsData config2 = ((PlayerOptions)0).Config;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+10]");
		List<KeyValuePair<object, float>> list = new List<KeyValuePair<object, float>>((IEnumerable<KeyValuePair<object, float>>)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v24+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v24+28]");
		object obj3 = num - 0;
		object obj4 = UnityEngine.Random.RandomRangeInt(0, (int)obj3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rax_v22 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Object, System.Single>>)+18]");
		bool flag2 = (nint)obj4 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rax_v22 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Object, System.Single>>)+10]");
		object obj5 = 0;
		object obj6 = obj4 + 2;
		object obj7 = obj6 + obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v22+v145 @ rax_v30*8]");
		eggManager = (EggManager)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
		PlayerOptionsData config3 = ((PlayerOptions)0).Config;
		object obj8 = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
		int num2 = ((Dictionary<string, float>)obj8).FindEntry((string)(object)this);
		float num6;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
			PlayerOptionsData config4 = ((PlayerOptions)0).Config;
			object obj9 = ((Dictionary<System.Int32Enum, object>)(object)config4._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
			float num3 = ((Dictionary<object, float>)obj9).get_Item((object)this);
			bool flag3 = num3 == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018696BB32h\"");
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
				PlayerOptionsData config5 = ((PlayerOptions)0).Config;
				object obj10 = ((Dictionary<System.Int32Enum, object>)(object)config5._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
				float num4 = ((Dictionary<object, float>)obj10).get_Item((object)this);
				float num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.EggManager)+8]");
				num6 = num5 - 0f;
				bool flag4 = ((Dictionary<object, float>)obj10).TryInsert((object)this, num6, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
				nint num7 = (nint)this;
				object obj11 = "cooldown";
				if ((object)this != "cooldown")
				{
					if (this != null && "cooldown" != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rcx_v42 (Il2CppClass<VampireSurvivors.EggManager>)+10]");
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1062 @ rdx_v29+10]");
						if (num8 == 0)
						{
							ref byte second = ref *(byte*)("cooldown" + 20);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rcx_v42 (Il2CppClass<VampireSurvivors.EggManager>)+10]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rcx_v42 (Il2CppClass<VampireSurvivors.EggManager>)+10]");
							ulong length = (ulong)(num9 + 0);
							if (System.SpanHelpers.SequenceEqual(ref *(byte*)(this + 20), ref second, length))
							{
								goto IL_0430;
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
					PlayerOptionsData config6 = ((PlayerOptions)0).Config;
					object obj12 = ((Dictionary<System.Int32Enum, object>)(object)config6._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
					num6 = ((Dictionary<object, float>)obj12).get_Item((object)this);
					if (0f > num6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
						PlayerOptionsData config7 = ((PlayerOptions)0).Config;
						object obj13 = ((Dictionary<System.Int32Enum, object>)(object)config7._003CCharacterEggInfo_003Ek__BackingField).get_Item((System.Int32Enum)config._selectedChar);
						bool flag5 = ((Dictionary<object, float>)obj13).TryInsert((object)this, 0f, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
					}
				}
				goto IL_0430;
			}
		}
		eggManager = (EggManager)(object)"undefined";
		_ = 0;
		goto IL_0608;
		IL_0608:
		return (KeyValuePair<string, float>)this;
		IL_0430:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
		PlayerOptionsData config8 = ((PlayerOptions)0).Config;
		int num10 = config8._003CCharacterEggCount_003Ek__BackingField.FindEntry(config._selectedChar);
		if (num10 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
			PlayerOptionsData config9 = ((PlayerOptions)0).Config;
			int num11 = config9._003CCharacterEggCount_003Ek__BackingField.FindEntry(config._selectedChar);
			float num12 = num6 - 1f;
			bool flag6 = ((Dictionary<System.Int32Enum, float>)(object)config9._003CCharacterEggCount_003Ek__BackingField).TryInsert((System.Int32Enum)config._selectedChar, num12, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
			PlayerOptionsData config10 = ((PlayerOptions)0).Config;
			int num13 = config10._003CCharacterEggCount_003Ek__BackingField.FindEntry(config._selectedChar);
			if (0f > num12)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
				PlayerOptionsData config11 = ((PlayerOptions)0).Config;
				bool flag7 = ((Dictionary<System.Int32Enum, float>)(object)config11._003CCharacterEggCount_003Ek__BackingField).TryInsert((System.Int32Enum)config._selectedChar, 0f, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
			PlayerOptionsData config12 = ((PlayerOptions)0).Config;
			float num14 = config12._003CTotalEggCount_003Ek__BackingField - 1f;
			config12._003CTotalEggCount_003Ek__BackingField = num14;
		}
		goto IL_0608;
	}

	public static string GetFormattedEggCount(float eggCount)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F252]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (eggCount > 10000f)
		{
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			return System.Number.FormatSingle(eggCount, null, currentInfo);
		}
		NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
		return System.Number.FormatSingle(eggCount, "F0", currentInfo2);
	}

	private void InitializeAttributes()
	{
		bool flag = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"maxHp", 1f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"armor", 0.1f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"regen", 0.1f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"moveSpeed", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"power", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag6 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"cooldown", -0.005f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag7 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"area", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag8 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"speed", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag9 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"duration", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag10 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"amount", 0.1f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag11 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"luck", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag12 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"growth", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag13 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"greed", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag14 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"curse", 0.01f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag15 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"magnet", 0.3f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag16 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"revivals", 0.1f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag17 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"rerolls", 0.1f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag18 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"skips", 0.2f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag19 = ((Dictionary<object, float>)(object)_attributes).TryInsert((object)"banish", 0.2f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Dictionary<string, float>.KeyCollection keys = _attributes.Keys;
		if (keys != null)
		{
			List<object> attributeKeys = new List<object>(keys);
			_attributeKeys = (List<string>)(object)attributeKeys;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private unsafe string LookUpFrame(string frameName)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004a: Expected O, but got I4
		//IL_0057: Expected O, but got I8
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_12d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12da: Expected Ref, but got Unknown
		//IL_12f1: Expected I8, but got I4
		//IL_12fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1300: Expected Ref, but got Unknown
		//IL_13cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d2: Expected Ref, but got Unknown
		//IL_13e9: Expected I8, but got I4
		//IL_13f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f8: Expected Ref, but got Unknown
		//IL_10e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ea: Expected Ref, but got Unknown
		//IL_1101: Expected I8, but got I4
		//IL_110b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1110: Expected Ref, but got Unknown
		//IL_0ed5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eda: Expected Ref, but got Unknown
		//IL_0ef1: Expected I8, but got I4
		//IL_0efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f00: Expected Ref, but got Unknown
		//IL_09bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c2: Expected Ref, but got Unknown
		//IL_09d9: Expected I8, but got I4
		//IL_09e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Expected Ref, but got Unknown
		//IL_11dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e2: Expected Ref, but got Unknown
		//IL_11f9: Expected I8, but got I4
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_1208: Expected Ref, but got Unknown
		//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd2: Expected Ref, but got Unknown
		//IL_0fe9: Expected I8, but got I4
		//IL_0ff3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff8: Expected Ref, but got Unknown
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf2: Expected Ref, but got Unknown
		//IL_0c09: Expected I8, but got I4
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c18: Expected Ref, but got Unknown
		//IL_0ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aba: Expected Ref, but got Unknown
		//IL_0ad1: Expected I8, but got I4
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Expected Ref, but got Unknown
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Expected Ref, but got Unknown
		//IL_06e9: Expected I8, but got I4
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected Ref, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected Ref, but got Unknown
		//IL_04d1: Expected I8, but got I4
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected Ref, but got Unknown
		//IL_0ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cea: Expected Ref, but got Unknown
		//IL_0d01: Expected I8, but got I4
		//IL_0d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d10: Expected Ref, but got Unknown
		//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Expected Ref, but got Unknown
		//IL_07e5: Expected I8, but got I4
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Expected Ref, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Expected Ref, but got Unknown
		//IL_05cd: Expected I8, but got I4
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected Ref, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected Ref, but got Unknown
		//IL_01dd: Expected I8, but got I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected Ref, but got Unknown
		//IL_0ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de2: Expected Ref, but got Unknown
		//IL_0df9: Expected I8, but got I4
		//IL_0e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e08: Expected Ref, but got Unknown
		//IL_08c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected Ref, but got Unknown
		//IL_08e1: Expected I8, but got I4
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Expected Ref, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected Ref, but got Unknown
		//IL_02d9: Expected I8, but got I4
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected Ref, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected Ref, but got Unknown
		//IL_03d5: Expected I8, but got I4
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F254]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (frameName != null)
		{
			object obj = frameName + 20;
			object obj2 = 0;
			object obj3 = 2166136261L;
			string result = default(string);
			while ((nint)obj2 < frameName._stringLength)
			{
				if ((nint)obj2 < frameName._stringLength)
				{
					obj2++;
					object obj4 = obj ^ obj3;
					obj3 = obj4 * 16777619;
					obj += 2;
					continue;
				}
				System.ThrowHelper.ThrowIndexOutOfRangeException();
				return result;
			}
			if ((nint)obj3 > 1478134073)
			{
				if ((long)obj3 > 2601460036L)
				{
					if ((long)obj3 > 4115604294L)
					{
						if ((long)obj3 == 4145017712L)
						{
							object obj5 = "luck";
							if ((object)frameName == "luck")
							{
								goto IL_021a;
							}
							if ("luck" != null)
							{
								int stringLength = frameName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v58+10]");
								if ((nint)stringLength == 0)
								{
									ref byte first = ref *(byte*)(frameName + 20);
									ulong length = (ulong)(frameName._stringLength + frameName._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("luck" + 20), length))
									{
										goto IL_021a;
									}
								}
							}
						}
						else if ((long)obj3 == 4152741449L)
						{
							object obj6 = "amount";
							if ((object)frameName == "amount")
							{
								goto IL_0316;
							}
							if ("amount" != null)
							{
								int stringLength2 = frameName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v55+10]");
								if ((nint)stringLength2 == 0)
								{
									ref byte first2 = ref *(byte*)(frameName + 20);
									ulong length2 = (ulong)(frameName._stringLength + frameName._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("amount" + 20), length2))
									{
										goto IL_0316;
									}
								}
							}
						}
						else if ((long)obj3 == 4165567700L)
						{
							object obj7 = "armor";
							if ((object)frameName == "armor")
							{
								goto IL_0412;
							}
							if ("armor" != null)
							{
								int stringLength3 = frameName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v52+10]");
								if ((nint)stringLength3 == 0)
								{
									ref byte first3 = ref *(byte*)(frameName + 20);
									ulong length3 = (ulong)(frameName._stringLength + frameName._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("armor" + 20), length3))
									{
										goto IL_0412;
									}
								}
							}
						}
					}
					else if ((long)obj3 == 2905847715L)
					{
						object obj8 = "skips";
						if ((object)frameName == "skips")
						{
							goto IL_050e;
						}
						if ("skips" != null)
						{
							int stringLength4 = frameName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v49+10]");
							if ((nint)stringLength4 == 0)
							{
								ref byte first4 = ref *(byte*)(frameName + 20);
								ulong length4 = (ulong)(frameName._stringLength + frameName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("skips" + 20), length4))
								{
									goto IL_050e;
								}
							}
						}
					}
					else if ((long)obj3 == 4115604294L)
					{
						object obj9 = "power";
						if ((object)frameName == "power")
						{
							goto IL_060a;
						}
						if ("power" != null)
						{
							int stringLength5 = frameName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v46+10]");
							if ((nint)stringLength5 == 0)
							{
								ref byte first5 = ref *(byte*)(frameName + 20);
								ulong length5 = (ulong)(frameName._stringLength + frameName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("power" + 20), length5))
								{
									goto IL_060a;
								}
							}
						}
					}
				}
				else if ((nint)obj3 > 2072037248)
				{
					if ((long)obj3 == 2245568488L)
					{
						object obj10 = "cooldown";
						if ((object)frameName == "cooldown")
						{
							goto IL_0726;
						}
						if ("cooldown" != null)
						{
							int stringLength6 = frameName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v43+10]");
							if ((nint)stringLength6 == 0)
							{
								ref byte first6 = ref *(byte*)(frameName + 20);
								ulong length6 = (ulong)(frameName._stringLength + frameName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("cooldown" + 20), length6))
								{
									goto IL_0726;
								}
							}
						}
					}
					else if ((long)obj3 == 2369798645L)
					{
						object obj11 = "curse";
						if ((object)frameName == "curse")
						{
							goto IL_0822;
						}
						if ("curse" != null)
						{
							int stringLength7 = frameName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v40+10]");
							if ((nint)stringLength7 == 0)
							{
								ref byte first7 = ref *(byte*)(frameName + 20);
								ulong length7 = (ulong)(frameName._stringLength + frameName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("curse" + 20), length7))
								{
									goto IL_0822;
								}
							}
						}
					}
					else if ((long)obj3 == 2601460036L)
					{
						object obj12 = "area";
						if ((object)frameName == "area")
						{
							goto IL_091e;
						}
						if ("area" != null)
						{
							int stringLength8 = frameName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v37+10]");
							if ((nint)stringLength8 == 0)
							{
								ref byte first8 = ref *(byte*)(frameName + 20);
								ulong length8 = (ulong)(frameName._stringLength + frameName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first8, ref *(byte*)("area" + 20), length8))
								{
									goto IL_091e;
								}
							}
						}
					}
				}
				else if ((nint)obj3 == 1772300454)
				{
					object obj13 = "growth";
					if ((object)frameName == "growth")
					{
						goto IL_0a16;
					}
					if ("growth" != null)
					{
						int stringLength9 = frameName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v34+10]");
						if ((nint)stringLength9 == 0)
						{
							ref byte first9 = ref *(byte*)(frameName + 20);
							ulong length9 = (ulong)(frameName._stringLength + frameName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first9, ref *(byte*)("growth" + 20), length9))
							{
								goto IL_0a16;
							}
						}
					}
				}
				else if ((nint)obj3 == 2072037248)
				{
					object obj14 = "speed";
					if ((object)frameName == "speed")
					{
						goto IL_0b0e;
					}
					if ("speed" != null)
					{
						int stringLength10 = frameName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v31+10]");
						if ((nint)stringLength10 == 0)
						{
							ref byte first10 = ref *(byte*)(frameName + 20);
							ulong length10 = (ulong)(frameName._stringLength + frameName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first10, ref *(byte*)("speed" + 20), length10))
							{
								goto IL_0b0e;
							}
						}
					}
				}
			}
			else if ((nint)obj3 > 382147848)
			{
				if ((nint)obj3 > 799079693)
				{
					if ((nint)obj3 == 1157950271)
					{
						object obj15 = "moveSpeed";
						if ((object)frameName == "moveSpeed")
						{
							goto IL_0c46;
						}
						if ("moveSpeed" != null)
						{
							int stringLength11 = frameName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdx_v28+10]");
							if ((nint)stringLength11 == 0)
							{
								ref byte first11 = ref *(byte*)(frameName + 20);
								ulong length11 = (ulong)(frameName._stringLength + frameName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first11, ref *(byte*)("moveSpeed" + 20), length11))
								{
									goto IL_0c46;
								}
							}
						}
					}
					else if ((nint)obj3 == 1321633417)
					{
						object obj16 = "maxHp";
						if ((object)frameName == "maxHp")
						{
							goto IL_0d3e;
						}
						if ("maxHp" != null)
						{
							int stringLength12 = frameName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v25+10]");
							if ((nint)stringLength12 == 0)
							{
								ref byte first12 = ref *(byte*)(frameName + 20);
								ulong length12 = (ulong)(frameName._stringLength + frameName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first12, ref *(byte*)("maxHp" + 20), length12))
								{
									goto IL_0d3e;
								}
							}
						}
					}
					else if ((nint)obj3 == 1478134073)
					{
						object obj17 = "revivals";
						if ((object)frameName == "revivals")
						{
							goto IL_0e36;
						}
						if ("revivals" != null)
						{
							int stringLength13 = frameName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v22+10]");
							if ((nint)stringLength13 == 0)
							{
								ref byte first13 = ref *(byte*)(frameName + 20);
								ulong length13 = (ulong)(frameName._stringLength + frameName._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first13, ref *(byte*)("revivals" + 20), length13))
								{
									goto IL_0e36;
								}
							}
						}
					}
				}
				else if ((nint)obj3 == 730421894)
				{
					object obj18 = "banish";
					if ((object)frameName == "banish")
					{
						goto IL_0f2e;
					}
					if ("banish" != null)
					{
						int stringLength14 = frameName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v19+10]");
						if ((nint)stringLength14 == 0)
						{
							ref byte first14 = ref *(byte*)(frameName + 20);
							ulong length14 = (ulong)(frameName._stringLength + frameName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first14, ref *(byte*)("banish" + 20), length14))
							{
								goto IL_0f2e;
							}
						}
					}
				}
				else if ((nint)obj3 == 799079693)
				{
					object obj19 = "duration";
					if ((object)frameName == "duration")
					{
						goto IL_1026;
					}
					if ("duration" != null)
					{
						int stringLength15 = frameName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v16+10]");
						if ((nint)stringLength15 == 0)
						{
							ref byte first15 = ref *(byte*)(frameName + 20);
							ulong length15 = (ulong)(frameName._stringLength + frameName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first15, ref *(byte*)("duration" + 20), length15))
							{
								goto IL_1026;
							}
						}
					}
				}
			}
			else if ((nint)obj3 > 16724762)
			{
				if ((nint)obj3 == 186514554)
				{
					object obj20 = "greed";
					if ((object)frameName == "greed")
					{
						goto IL_113e;
					}
					if ("greed" != null)
					{
						int stringLength16 = frameName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v13+10]");
						if ((nint)stringLength16 == 0)
						{
							ref byte first16 = ref *(byte*)(frameName + 20);
							ulong length16 = (ulong)(frameName._stringLength + frameName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first16, ref *(byte*)("greed" + 20), length16))
							{
								goto IL_113e;
							}
						}
					}
				}
				else if ((nint)obj3 == 382147848)
				{
					object obj21 = "rerolls";
					if ((object)frameName == "rerolls")
					{
						goto IL_1236;
					}
					if ("rerolls" != null)
					{
						int stringLength17 = frameName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v10+10]");
						if ((nint)stringLength17 == 0)
						{
							ref byte first17 = ref *(byte*)(frameName + 20);
							ulong length17 = (ulong)(frameName._stringLength + frameName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first17, ref *(byte*)("rerolls" + 20), length17))
							{
								goto IL_1236;
							}
						}
					}
				}
			}
			else if ((nint)obj3 == 3835839)
			{
				object obj22 = "magnet";
				if ((object)frameName == "magnet")
				{
					goto IL_132e;
				}
				if ("magnet" != null)
				{
					int stringLength18 = frameName._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v7+10]");
					if ((nint)stringLength18 == 0)
					{
						ref byte first18 = ref *(byte*)(frameName + 20);
						ulong length18 = (ulong)(frameName._stringLength + frameName._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first18, ref *(byte*)("magnet" + 20), length18))
						{
							goto IL_132e;
						}
					}
				}
			}
			else if ((nint)obj3 == 16724762)
			{
				object obj23 = "regen";
				if ((object)frameName == "regen")
				{
					goto IL_1426;
				}
				if ("regen" != null)
				{
					int stringLength19 = frameName._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v4+10]");
					if ((nint)stringLength19 == 0)
					{
						ref byte first19 = ref *(byte*)(frameName + 20);
						ulong length19 = (ulong)(frameName._stringLength + frameName._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first19, ref *(byte*)("regen" + 20), length19))
						{
							goto IL_1426;
						}
					}
				}
			}
		}
		return "";
		IL_113e:
		return "Mask.png";
		IL_050e:
		return "Skip.png";
		IL_0412:
		return "ArmorIron.png";
		IL_060a:
		return "Leaf.png";
		IL_1026:
		return "EmblemEye.png";
		IL_1236:
		return "Dice.png";
		IL_0b0e:
		return "Gauntlet.png";
		IL_0f2e:
		return "Banish.png";
		IL_0822:
		return "Curse.png";
		IL_0c46:
		return "Wing.png";
		IL_0726:
		return "Book2.png";
		IL_091e:
		return "Candelabra.png";
		IL_021a:
		return "Clover.png";
		IL_1426:
		return "HeartRuby.png";
		IL_0d3e:
		return "HeartBlack.png";
		IL_0316:
		return "Ring.png";
		IL_0a16:
		return "Crown.png";
		IL_0e36:
		return "Tiramisu.png";
		IL_132e:
		return "OrbGlow.png";
	}

	public EggManager()
	{
		Dictionary<string, float> attributes = new Dictionary<string, float>();
		_attributes = attributes;
		List<string> attributeKeys = new List<string>();
		_attributeKeys = attributeKeys;
	}
}
