using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Loading;

public static class CharacterLoader
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<bool> _003C_003E9__8_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CLoadCharacterTexture_003Eb__8_0(bool loaded)
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public CharacterType characterType;
	}

	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public string texture;

		public _003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals1;

		internal void _003CLoadCharacterAsync_003Eb__0(Action cb)
		{
			//IL_0038: Expected I4, but got O
			_003C_003Ec__DisplayClass5_2 obj = new _003C_003Ec__DisplayClass5_2();
			obj.cb = cb;
			_003C_003Ec__DisplayClass5_0 obj2 = CS_0024_003C_003E8__locals1;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass5_2)(object)action)._003CLoadCharacterAsync_003Eb__1((byte)(int)obj != 0);
			GameManager core = GM.Core;
			string customCacheGroup = default(string);
			LoadCharacterTextureAsync(texture, obj2.characterType, action, core._dataManager, customCacheGroup);
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_2
	{
		public Action cb;

		internal void _003CLoadCharacterAsync_003Eb__1(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int leftToLoad;

		public Action onComplete;

		internal void _003CLoadAllCharacterTexturesAsync_003Eg__OnLoadComplete_007C0(bool loaded)
		{
			if (--leftToLoad <= 0)
			{
				Action action = onComplete;
				if (onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v16.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public Action<bool> onComplete;

		internal void _003CLoadCharacterTextureAsync_003Eb__0(bool loaded)
		{
			Action<bool> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private const string CharacterCacheGroup = "CharacterTextures";

	public unsafe static Dictionary<CharacterType, List<string>> GetTexturesAndTypesForSelectedPlayers(PlayerOptions playerOptions, DataManager dataManager)
	{
		//IL_005b: Expected O, but got I
		//IL_006b: Expected O, but got I
		//IL_00c9: Expected O, but got I
		//IL_0167: Expected I4, but got O
		//IL_032a: Expected O, but got Ref
		//IL_0338: Expected I, but got O
		//IL_03c3: Expected O, but got I4
		//IL_0713: Expected O, but got I
		//IL_0370: Expected O, but got I
		//IL_0379: Expected O, but got I4
		//IL_01ca: Expected O, but got I
		//IL_0587: Expected O, but got I
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Expected O, but got Unknown
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_020f: Expected O, but got I
		//IL_021f: Expected O, but got I
		//IL_03f5: Expected I, but got O
		//IL_0480: Expected O, but got I4
		//IL_0280: Expected O, but got I
		//IL_042d: Expected O, but got I
		//IL_0436: Expected O, but got I4
		//IL_05ca: Expected O, but got I
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Expected O, but got Unknown
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected O, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Expected O, but got Unknown
		Dictionary<CharacterType, List<string>> dictionary = new Dictionary<CharacterType, List<string>>();
		PlayerOptionsData config = playerOptions.Config;
		List<CharacterType> list = new List<CharacterType>();
		PlayerOptionsData config2 = playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v22+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)config2._selectedChar);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = config2._selectedChar;
		}
		List<string> texturesForCharacterTypes = GetTexturesForCharacterTypes(list, playerOptions, dataManager);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)config._selectedChar, (object)texturesForCharacterTypes, System.Collections.Generic.InsertionBehavior.None);
		int localPlayerCount = MultiplayerManager.s_instance.GetLocalPlayerCount();
		bool flag2 = localPlayerCount <= 1;
		List<CharacterType> list2 = null;
		System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
		if (!flag2)
		{
			List<CharacterType> characterSelections = MultiplayerManager.s_instance.GetCharacterSelections();
			insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)characterSelections;
			object obj4 = default(object);
			object obj5 = default(object);
			object obj7 = default(object);
			while (true)
			{
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ stack_-88_v17+1C]");
					if (obj5 == null)
					{
						object obj6 = obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ stack_-88_v17+18]");
						if ((nint)obj6 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ stack_-88_v17+10]");
							object obj8 = 0;
							obj7++;
							List<CharacterType> list3 = new List<CharacterType>();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1363 @ rax_v112 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1363 @ rax_v112 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1363 @ rax_v112 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1363 @ rax_v112 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rcx_v89+18]");
							if (num2 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rdx_v62+20+v1361 @ rcx_v86*4]");
								((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)0);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1363 @ rax_v112 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								object obj11 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rdx_v62+20+v1361 @ rcx_v86*4]");
								_ = 0;
							}
							List<string> texturesForCharacterTypes2 = GetTexturesForCharacterTypes(list3, playerOptions, dataManager);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rdx_v62+20+v1361 @ rcx_v86*4]");
							bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, (object)texturesForCharacterTypes2, System.Collections.Generic.InsertionBehavior.None);
							insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag4 = obj4 == null;
			MultiplayerManager multiplayerManager = (MultiplayerManager)0;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ stack_-88_v17+1C]");
				if (obj5 == null)
				{
					list2 = characterSelections;
					goto IL_068e;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				multiplayerManager = null;
			}
			throw new NullReferenceException();
		}
		goto IL_068e;
		IL_068e:
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			List<CharacterType> list4 = default(List<CharacterType>);
			object obj12 = (object)(&list4);
			object obj21 = default(object);
			object obj24 = default(object);
			object obj25 = default(object);
			object obj32 = default(object);
			System.Int32Enum int32Enum = default(System.Int32Enum);
			object message = default(object);
			while (true)
			{
				object obj13;
				object obj20;
				if (list4 != null)
				{
					nint num3 = (nint)list4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ r10_v6 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>>)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_03b0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ r10_v6 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>>)+B0]");
					obj13 = 0;
					object obj14 = 0;
					while (true)
					{
						object obj15 = obj14 + obj14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ r8_v22+v1382 @ rax_v95*8]");
						if (0 == (nint)typeof(IEnumerator))
						{
							break;
						}
						obj14++;
						object obj16 = obj14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ r10_v6 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>>)+12E]");
						if ((nint)obj16 < 0)
						{
							continue;
						}
						goto IL_03b0;
					}
					object obj17 = obj14 + obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ r8_v22+8+v1438 @ rcx_v75*8]");
					object obj18 = (nint)0 << 4;
					object obj19 = obj18 + 312;
					obj20 = obj19 + num3;
					goto IL_07de;
				}
				throw new NullReferenceException();
				IL_03b0:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj13 = 0;
				obj20 = obj21;
				goto IL_07de;
				IL_046d:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				object obj22 = 0;
				object obj23 = obj24;
				goto IL_0805;
				IL_07de:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1443 @ rdx_v30] (should have been resolved before IL gen)");
				if (obj25 == null)
				{
					break;
				}
				if (list4 != null)
				{
					nint num4 = (nint)list4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ r10_v7 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>>)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_046d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ r10_v7 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>>)+B0]");
					obj22 = 0;
					object obj26 = 0;
					while (true)
					{
						object obj27 = obj26 + obj26;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1316 @ r8_v25+v1504 @ rax_v90*8]");
						if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
						{
							break;
						}
						obj26++;
						object obj28 = obj26;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ r10_v7 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>>)+12E]");
						if ((nint)obj28 < 0)
						{
							continue;
						}
						goto IL_046d;
					}
					object obj29 = obj26 + obj26;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1316 @ r8_v25+8+v1574 @ rcx_v69*8]");
					object obj30 = (nint)0 << 4;
					object obj31 = obj30 + 312;
					obj23 = obj31 + num4;
					goto IL_0805;
				}
				throw new NullReferenceException();
				IL_0805:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1579 @ rdx_v35] (should have been resolved before IL gen)");
				if (obj32 == null)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1595 @ rax_v63+10]");
				if ((nint)0 != 0)
				{
					object obj33 = (CharacterType)int32Enum;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					Debug.Log(message);
					List<CharacterType> list5 = new List<CharacterType>();
					if (list5 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
					List<string> texturesForCharacterTypes3 = GetTexturesForCharacterTypes(list5, playerOptions, dataManager);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1595 @ rax_v63+50]");
					bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, (object)texturesForCharacterTypes3, System.Collections.Generic.InsertionBehavior.None);
				}
			}
			if (obj12 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
		}
		return dictionary;
	}

	public static List<string> GetTexturesForCharacterTypes(List<CharacterType> characters, PlayerOptions playerOptions, DataManager dataManager)
	{
		//IL_0072: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		List<string> list = new List<string>();
		List<object> list2 = null;
		object obj = default(object);
		List<object> list3 = default(List<object>);
		object obj3 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ stack_-40_v8+1C]");
				if (list3 == null)
				{
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ stack_-40_v8+18]");
					if ((nint)obj2 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ stack_-40_v8+10]");
						object obj4 = 0;
						obj3++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v18+20+v530 @ rdx_v13*4]");
						List<string> texturesForCharacterType = GetTexturesForCharacterType(CharacterType.VOID, playerOptions, dataManager);
						((List<object>)(object)list).InsertRange(list._size, (IEnumerable<object>)texturesForCharacterType);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ stack_-40_v8+1C]");
			if (list3 == null)
			{
				return list;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			list2 = null;
		}
		throw new NullReferenceException();
	}

	public unsafe static List<string> GetTexturesForCharacterType(CharacterType characterType, PlayerOptions playerOptions, DataManager dataManager)
	{
		//IL_022a: Expected O, but got I
		//IL_023f: Expected O, but got I
		List<string> list = new List<string>();
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = dataManager.GetConvertedCharacterData();
		PlayerOptionsData config = playerOptions.Config;
		int num = config._003CSelectedSkinsV2_003Ek__BackingField.FindEntry(characterType);
		if (num >= 0)
		{
			int num2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).FindEntry((System.Int32Enum)characterType);
			if (num2 >= 0)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96630");
					CharacterData characterData = default(CharacterData);
					if (characterData != null)
					{
						PlayerOptionsData config2 = playerOptions.Config;
						SkinType skinType = config2._003CSelectedSkinsV2_003Ek__BackingField.get_Item(characterType);
						Skin skinData = characterData.GetSkinData(skinType);
						if (skinData != null)
						{
							string text = skinData._003CtextureName_003Ek__BackingField;
							if (skinData._003CtextureName_003Ek__BackingField != null && text._stringLength > 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002390");
								goto IL_01a2;
							}
						}
					}
				}
			}
		}
		if (((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).TryGetValue((System.Int32Enum)characterType, out object value) && value != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_18_v5 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				List<string> result = default(List<string>);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_18_v5 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v16+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v16+20]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v15+40]");
				CharacterType characterType2 = CharacterType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v15+40]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v23 (VampireSurvivors.Data.CharacterType)+10]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v15+40]");
						bool flag = ((Dictionary<CharacterType, List<CharacterData>>)(object)list).TryGetValue(CharacterType.VOID, out *(List<CharacterData>*)null);
					}
				}
			}
		}
		if (characterType == CharacterType.MARIASOFIA)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"character_xanthia");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
		goto IL_01a2;
		IL_01a2:
		return list;
	}

	public unsafe static void ClearCharacterTextures(List<string> excludedTextures = null)
	{
		//IL_005f: Expected O, but got Ref
		//IL_0129: Expected O, but got I4
		bool flag = excludedTextures != null;
		List<string> list = excludedTextures;
		if (!flag)
		{
			List<string> list2 = new List<string>();
			list = list2;
		}
		List<string> texturesInGroup = AddressableCache.GetTexturesInGroup("CharacterTextures");
		List<string> list3 = new List<string>();
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		int num2 = default(int);
		nint num4 = default(nint);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag2 = list == null;
				List<string>.Enumerator enumerator2 = (List<string>.Enumerator)(&enumerator);
				if (!flag2)
				{
					bool flag3 = list._size == 0;
					int num = num2;
					nint num3 = num4;
					if (!flag3)
					{
						num = list._size;
						int num5 = Array.IndexOf((object[])list._items, (object)null, 0, list._size);
						bool flag4 = num5 != -1;
						num3 = 0;
						num2 = list._size;
						num4 = 0;
						if (flag4)
						{
							continue;
						}
					}
					SpriteManager.UnregisterTexture(null);
					bool flag5 = list3 == null;
					enumerator2 = (List<string>.Enumerator)0;
					if (flag5)
					{
						break;
					}
					list3.Add(null);
					num2 = num;
					num4 = num3;
					continue;
				}
				throw new NullReferenceException();
			}
			AddressableCache.RemoveTextures("CharacterTextures", list3);
			AddressableCache.ReleaseCustomOperationHandleGroupExcludingKeys("CharacterTextures", list);
			return;
		}
		throw new NullReferenceException();
	}

	public static void LoadCharacterAsync(CharacterType characterType, Action onComplete)
	{
		//IL_00bb: Expected I, but got O
		_003C_003Ec__DisplayClass5_0 obj = new _003C_003Ec__DisplayClass5_0();
		if (obj != null)
		{
			obj.characterType = characterType;
			AsyncLoader asyncLoader = new AsyncLoader(onComplete);
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				List<string> texturesForCharacterType = GetTexturesForCharacterType(obj.characterType, core._playerOptions, core._dataManager);
				if (texturesForCharacterType != null)
				{
					List<string>.Enumerator enumerator = default(List<string>.Enumerator);
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass5_1();
						bool flag = CS_0024_003C_003E8__locals5 == null;
						nint num = (nint)typeof(_003C_003Ec__DisplayClass5_1);
						if (!flag)
						{
							CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1 = obj;
							CS_0024_003C_003E8__locals5.texture = null;
							Action<Action> loadCall = delegate(Action cb)
							{
								//IL_0038: Expected I4, but got O
								_003C_003Ec__DisplayClass5_2 obj2 = new _003C_003Ec__DisplayClass5_2();
								obj2.cb = cb;
								_003C_003Ec__DisplayClass5_0 obj3 = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1;
								Action<bool> action = null;
								((_003C_003Ec__DisplayClass5_2)(object)action)._003CLoadCharacterAsync_003Eb__1((byte)(int)obj2 != 0);
								GameManager core2 = GM.Core;
								string customCacheGroup = default(string);
								LoadCharacterTextureAsync(CS_0024_003C_003E8__locals5.texture, obj3.characterType, action, core2._dataManager, customCacheGroup);
							};
							if (asyncLoader != null)
							{
								asyncLoader.Add(loadCall);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					if (asyncLoader != null)
					{
						asyncLoader.Load();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static void LoadAllCharacterTextures(DataManager dataManager)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2A7F]");
		bool flag = (nint)0 != 0;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = dataManager.GetConvertedCharacterData();
		Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator = default(Dictionary<CharacterType, List<CharacterData>>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		}
	}

	public unsafe static void LoadAllCharacterTexturesAsync(DataManager dataManager, Action onComplete)
	{
		//IL_006e: Expected O, but got I4
		//IL_0768: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2A80]");
		bool flag = (nint)0 != 0;
		_003C_003Ec__DisplayClass7_0 obj = new _003C_003Ec__DisplayClass7_0();
		obj.onComplete = onComplete;
		obj.leftToLoad = 0;
		Dictionary<CharacterType, List<string>> dictionary = new Dictionary<CharacterType, List<string>>();
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = dataManager.GetConvertedCharacterData();
		Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator = (Dictionary<CharacterType, List<CharacterData>>.Enumerator)0;
		Dictionary<CharacterType, List<CharacterData>> dictionary2 = convertedCharacterData;
		Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator2 = default(Dictionary<CharacterType, List<CharacterData>>.Enumerator);
		while (enumerator2.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		}
		Dictionary<CharacterType, List<string>>.Enumerator enumerator3 = default(Dictionary<CharacterType, List<string>>.Enumerator);
		if (enumerator3.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Dictionary<CharacterType, List<CharacterData>>.Enumerator enumerator4 = (Dictionary<CharacterType, List<CharacterData>>.Enumerator)(&enumerator3);
			throw new NullReferenceException();
		}
	}

	public static void LoadCharacterTexture(string textureName, CharacterType characterType, DataManager dataManager, string customCacheGroup = null)
	{
		//IL_00b9: Expected I4, but got O
		bool flag = customCacheGroup == null;
		string cacheGroupName = "CharacterTextures";
		if (!flag)
		{
			cacheGroupName = customCacheGroup;
		}
		DlcType? characterDlcType = DlcSystem._utils.GetCharacterDlcType(characterType, dataManager);
		Action<bool> onComplete = _003C_003Ec._003C_003E9__8_0;
		if (_003C_003Ec._003C_003E9__8_0 == null)
		{
			Action<bool> action = null;
			((_003C_003Ec)(object)action)._003CLoadCharacterTexture_003Eb__8_0((byte)(int)_003C_003Ec._003C_003E9 != 0);
			_003C_003Ec._003C_003E9__8_0 = action;
			onComplete = action;
		}
		bool flag2 = SpriteLoader.LoadTexture(textureName, cacheGroupName, characterDlcType, onComplete);
	}

	public static void LoadCharacterTextureAsync(string textureName, CharacterType characterType, Action<bool> onComplete, DataManager dataManager, string customCacheGroup = null)
	{
		//IL_007c: Expected I4, but got O
		_003C_003Ec__DisplayClass9_0 obj = new _003C_003Ec__DisplayClass9_0();
		obj.onComplete = onComplete;
		string text = default(string);
		bool flag = text == null;
		string cacheGroupName = "CharacterTextures";
		if (!flag)
		{
			cacheGroupName = text;
		}
		DlcType? characterDlcType = DlcSystem._utils.GetCharacterDlcType(characterType, dataManager);
		Action<bool> action = null;
		((_003C_003Ec__DisplayClass9_0)(object)action)._003CLoadCharacterTextureAsync_003Eb__0((byte)(int)obj != 0);
		SpriteLoader.LoadTextureAsync(textureName, cacheGroupName, characterDlcType, action);
	}
}
