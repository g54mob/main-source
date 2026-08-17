using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loading;

public static class ThosePeopleLoader
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Action> _003C_003E9__3_0;

		public static Action<Action> _003C_003E9__3_1;

		public static Action<Action> _003C_003E9__3_2;

		public static Action<Action> _003C_003E9__3_3;

		public static Action<Action> _003C_003E9__3_4;

		public static Action<Action> _003C_003E9__3_5;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CLoadBossFightAssets_003Eb__3_0(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass3_0 obj = new _003C_003Ec__DisplayClass3_0();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass3_0)(object)action)._003CLoadBossFightAssets_003Eb__6((byte)(int)obj != 0);
			bool flag = SpriteLoader.LoadTexture("TP_Death", "Gameplay", (DlcType?)(object)1, action);
		}

		internal void _003CLoadBossFightAssets_003Eb__3_1(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass3_1 obj = new _003C_003Ec__DisplayClass3_1();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass3_1)(object)action)._003CLoadBossFightAssets_003Eb__7((byte)(int)obj != 0);
			bool flag = SpriteLoader.LoadTexture("DeathFightBG", "Gameplay", (DlcType?)(object)1, action);
		}

		internal void _003CLoadBossFightAssets_003Eb__3_2(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass3_2 obj = new _003C_003Ec__DisplayClass3_2();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass3_2)(object)action)._003CLoadBossFightAssets_003Eb__8((byte)(int)obj != 0);
			bool flag = SpriteLoader.LoadTexture("DeathFightTop", "Gameplay", (DlcType?)(object)1, action);
		}

		internal void _003CLoadBossFightAssets_003Eb__3_3(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass3_3 obj = new _003C_003Ec__DisplayClass3_3();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass3_3)(object)action)._003CLoadBossFightAssets_003Eb__9((byte)(int)obj != 0);
			bool flag = SpriteLoader.LoadTexture("DeathFightTile", "Gameplay", (DlcType?)(object)1, action);
		}

		internal void _003CLoadBossFightAssets_003Eb__3_4(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadBgmAsync(BgmType.BGM_TP_hod_DanceOfIllusions, "BGM", (DlcType?)(object)1, cb);
		}

		internal void _003CLoadBossFightAssets_003Eb__3_5(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.Wind, "Gameplay", (DlcType?)(object)1, cb);
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public Action cb;

		internal void _003CLoadBossFightAssets_003Eb__6(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public Action cb;

		internal void _003CLoadBossFightAssets_003Eb__7(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_2
	{
		public Action cb;

		internal void _003CLoadBossFightAssets_003Eb__8(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_3
	{
		public Action cb;

		internal void _003CLoadBossFightAssets_003Eb__9(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public static void UnloadGameplayAssets()
	{
		AddressableCache.ReleaseCustomOperationHandleGroup("BGM");
		AddressableCache.ReleaseCustomOperationHandleGroup("SFX");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"DopplegangerLight");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"MapTP");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"MapTP_Full");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		AddressableCache.ReleaseCustomOperationHandles("Gameplay", list);
	}

	public static void LoadCutsceneSfx()
	{
		//IL_001a: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		AudioLoader.LoadSFX(SfxType.TP_sfx_Coffin1, "TP_Cutscene_SFX", (DlcType?)(object)1);
		AudioLoader.LoadSFX(SfxType.TP_sfx_Coffin2, "TP_Cutscene_SFX", (DlcType?)(object)1);
		AudioLoader.LoadSFX(SfxType.TP_sfx_Death, "TP_Cutscene_SFX", (DlcType?)(object)1);
		AudioLoader.LoadSFX(SfxType.TP_sfx_ThroneRoom, "TP_Cutscene_SFX", (DlcType?)(object)1);
	}

	public static void UnloadCutsceneSfx()
	{
		AddressableCache.ReleaseCustomOperationHandleGroup("TP_Cutscene_SFX");
	}

	public static void LoadBossFightAssets(Action onComplete)
	{
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		Action<Action> loadCall = _003C_003Ec._003C_003E9__3_0;
		if (_003C_003Ec._003C_003E9__3_0 == null)
		{
			loadCall = (_003C_003Ec._003C_003E9__3_0 = delegate(Action cb)
			{
				//IL_0029: Expected I4, but got O
				//IL_0046: Expected O, but got I4
				_003C_003Ec__DisplayClass3_0 obj = new _003C_003Ec__DisplayClass3_0();
				obj.cb = cb;
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass3_0)(object)action)._003CLoadBossFightAssets_003Eb__6((byte)(int)obj != 0);
				bool flag = SpriteLoader.LoadTexture("TP_Death", "Gameplay", (DlcType?)(object)1, action);
			});
		}
		asyncLoader.Add(loadCall);
		Action<Action> loadCall2 = _003C_003Ec._003C_003E9__3_1;
		if (_003C_003Ec._003C_003E9__3_1 == null)
		{
			loadCall2 = (_003C_003Ec._003C_003E9__3_1 = delegate(Action cb)
			{
				//IL_0029: Expected I4, but got O
				//IL_0046: Expected O, but got I4
				_003C_003Ec__DisplayClass3_1 obj = new _003C_003Ec__DisplayClass3_1();
				obj.cb = cb;
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass3_1)(object)action)._003CLoadBossFightAssets_003Eb__7((byte)(int)obj != 0);
				bool flag = SpriteLoader.LoadTexture("DeathFightBG", "Gameplay", (DlcType?)(object)1, action);
			});
		}
		asyncLoader.Add(loadCall2);
		Action<Action> loadCall3 = _003C_003Ec._003C_003E9__3_2;
		if (_003C_003Ec._003C_003E9__3_2 == null)
		{
			loadCall3 = (_003C_003Ec._003C_003E9__3_2 = delegate(Action cb)
			{
				//IL_0029: Expected I4, but got O
				//IL_0046: Expected O, but got I4
				_003C_003Ec__DisplayClass3_2 obj = new _003C_003Ec__DisplayClass3_2();
				obj.cb = cb;
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass3_2)(object)action)._003CLoadBossFightAssets_003Eb__8((byte)(int)obj != 0);
				bool flag = SpriteLoader.LoadTexture("DeathFightTop", "Gameplay", (DlcType?)(object)1, action);
			});
		}
		asyncLoader.Add(loadCall3);
		Action<Action> loadCall4 = _003C_003Ec._003C_003E9__3_3;
		if (_003C_003Ec._003C_003E9__3_3 == null)
		{
			loadCall4 = (_003C_003Ec._003C_003E9__3_3 = delegate(Action cb)
			{
				//IL_0029: Expected I4, but got O
				//IL_0046: Expected O, but got I4
				_003C_003Ec__DisplayClass3_3 obj = new _003C_003Ec__DisplayClass3_3();
				obj.cb = cb;
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass3_3)(object)action)._003CLoadBossFightAssets_003Eb__9((byte)(int)obj != 0);
				bool flag = SpriteLoader.LoadTexture("DeathFightTile", "Gameplay", (DlcType?)(object)1, action);
			});
		}
		asyncLoader.Add(loadCall4);
		Action<Action> loadCall5 = _003C_003Ec._003C_003E9__3_4;
		if (_003C_003Ec._003C_003E9__3_4 == null)
		{
			loadCall5 = (_003C_003Ec._003C_003E9__3_4 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadBgmAsync(BgmType.BGM_TP_hod_DanceOfIllusions, "BGM", (DlcType?)(object)1, cb);
			});
		}
		asyncLoader.Add(loadCall5);
		Action<Action> loadCall6 = _003C_003Ec._003C_003E9__3_5;
		if (_003C_003Ec._003C_003E9__3_5 == null)
		{
			loadCall6 = (_003C_003Ec._003C_003E9__3_5 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadSFXAsync(SfxType.Wind, "Gameplay", (DlcType?)(object)1, cb);
			});
		}
		asyncLoader.Add(loadCall6);
		asyncLoader.Load();
	}

	public static void SwapBossFightAudio()
	{
		//IL_0038: Expected O, but got I4
		//IL_004d: Expected O, but got I4
		AddressableCache.ReleaseCustomOperationHandleGroup("BGM");
		AddressableCache.ReleaseCustomOperationHandleGroup("SFX");
		AudioLoader.LoadBgm(BgmType.BGM_TP_VS_BlackDisk, "BGM", (DlcType?)(object)1);
		AudioLoader.LoadSFX(SfxType.TP_sfx_BlackDisk_FX, "SFX", (DlcType?)(object)1);
	}

	public unsafe static void LoadAlliesForDeathFight(List<CharacterType> chars)
	{
		//IL_021d: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_012d: Expected O, but got Ref
		//IL_00c8: Expected I, but got O
		object obj = default(object);
		object obj2 = default(object);
		nint num = default(nint);
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		List<CharacterType> list;
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-70_v3+1C]");
				if (obj2 != null)
				{
					break;
				}
				nint intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-70_v3+18]");
				if (intPtr >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-70_v3+10]");
				object obj3 = 0;
				num++;
				GameManager core = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rdx_v10+20+v581 @ rcx_v16 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)*4]");
				List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(CharacterType.VOID, core._playerOptions, core._dataManager);
				while (enumerator.MoveNext())
				{
					nint num2 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v655 @ rax_v42 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num3 = 0;
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rdx_v10+20+v581 @ rcx_v16 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)*4]");
						CharacterLoader.LoadCharacterTexture(null, CharacterType.VOID, core2._dataManager, "Gameplay");
						continue;
					}
					throw new NullReferenceException();
				}
				list = (List<CharacterType>)(&enumerator);
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		list = (List<CharacterType>)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-70_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			list = null;
		}
		throw new NullReferenceException();
	}
}
