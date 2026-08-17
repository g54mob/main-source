using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework.Loading;

public class MainMenuLoader : IInitializable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Action> _003C_003E9__5_0;

		public static Action<Action> _003C_003E9__5_1;

		public static Action<Action> _003C_003E9__5_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CLoad_003Eb__5_0(Action cb)
		{
			CharacterLoader.LoadAllCharacterTexturesAsync(_dataManager, cb);
		}

		internal void _003CLoad_003Eb__5_1(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass5_0 obj = new _003C_003Ec__DisplayClass5_0();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass5_0)(object)action)._003CLoad_003Eb__3((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("AdventuresUI", "MainMenu", (DlcType?)(object)0, action);
		}

		internal void _003CLoad_003Eb__5_2(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass5_1 obj = new _003C_003Ec__DisplayClass5_1();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass5_1)(object)action)._003CLoad_003Eb__4((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("UI_StageIcons", "MainMenu", (DlcType?)(object)0, action);
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Action cb;

		internal void _003CLoad_003Eb__3(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public Action cb;

		internal void _003CLoad_003Eb__4(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public KeyValuePair<AlbumType, AlbumData> albumKvp;

		public DlcType? dlcType;

		internal void _003CLoadAlbumArt_003Eb__0(Action cb)
		{
			//IL_0027: Expected O, but got I
			//IL_0047: Expected O, but got I
			//IL_0062: Expected I4, but got O
			_003C_003Ec__DisplayClass6_1 obj = new _003C_003Ec__DisplayClass6_1();
			obj.cb = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.Loading.MainMenuLoader+<>c__DisplayClass6_0)+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6+20]");
			string textureName = ((string)0).Replace(".png", "");
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass6_1)(object)action)._003CLoadAlbumArt_003Eb__1((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync(textureName, "MainMenu", dlcType, action);
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public Action cb;

		internal void _003CLoadAlbumArt_003Eb__1(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private static DataManager _dataManager;

	private static PlayerOptions _playerOptions;

	public const string CACHE_GROUP_NAME = "MainMenu";

	private void Construct(DataManager dataManager, PlayerOptions playerOptions)
	{
		_dataManager = dataManager;
		_playerOptions = playerOptions;
	}

	public void Initialize()
	{
	}

	public static void Load(Action onComplete)
	{
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		Action<Action> loadCall = _003C_003Ec._003C_003E9__5_0;
		if (_003C_003Ec._003C_003E9__5_0 == null)
		{
			loadCall = (_003C_003Ec._003C_003E9__5_0 = delegate(Action cb)
			{
				CharacterLoader.LoadAllCharacterTexturesAsync(_dataManager, cb);
			});
		}
		asyncLoader.Add(loadCall);
		Action<Action> loadCall2 = _003C_003Ec._003C_003E9__5_1;
		if (_003C_003Ec._003C_003E9__5_1 == null)
		{
			loadCall2 = (_003C_003Ec._003C_003E9__5_1 = delegate(Action cb)
			{
				//IL_0029: Expected I4, but got O
				//IL_0046: Expected O, but got I4
				_003C_003Ec__DisplayClass5_0 obj = new _003C_003Ec__DisplayClass5_0();
				obj.cb = cb;
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass5_0)(object)action)._003CLoad_003Eb__3((byte)(int)obj != 0);
				SpriteLoader.LoadTextureAsync("AdventuresUI", "MainMenu", (DlcType?)(object)0, action);
			});
		}
		asyncLoader.Add(loadCall2);
		Action<Action> loadCall3 = _003C_003Ec._003C_003E9__5_2;
		if (_003C_003Ec._003C_003E9__5_2 == null)
		{
			loadCall3 = (_003C_003Ec._003C_003E9__5_2 = delegate(Action cb)
			{
				//IL_0029: Expected I4, but got O
				//IL_0046: Expected O, but got I4
				_003C_003Ec__DisplayClass5_1 obj = new _003C_003Ec__DisplayClass5_1();
				obj.cb = cb;
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass5_1)(object)action)._003CLoad_003Eb__4((byte)(int)obj != 0);
				SpriteLoader.LoadTextureAsync("UI_StageIcons", "MainMenu", (DlcType?)(object)0, action);
			});
		}
		asyncLoader.Add(loadCall3);
		LoadAlbumArt(asyncLoader);
		asyncLoader.Load();
	}

	private static void LoadAlbumArt(AsyncLoader loader)
	{
		//IL_0036: Expected I, but got O
		//IL_0052: Expected O, but got I4
		//IL_0060: Expected I, but got O
		//IL_0075: Expected O, but got I
		Dictionary<AlbumType, AlbumData>.Enumerator enumerator = default(Dictionary<AlbumType, AlbumData>.Enumerator);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass6_0();
			bool flag = CS_0024_003C_003E8__locals4 == null;
			nint num = (nint)typeof(_003C_003Ec__DisplayClass6_0);
			if (!flag)
			{
				CS_0024_003C_003E8__locals4.albumKvp = (KeyValuePair<AlbumType, AlbumData>)0;
				num = (nint)typeof(_003C_003Ec__DisplayClass6_0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v12 (VampireSurvivors.Framework.Loading.MainMenuLoader+<>c__DisplayClass6_0)+18]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v12 (VampireSurvivors.Framework.Loading.MainMenuLoader+<>c__DisplayClass6_0)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v17+30]");
					if ((nint)0 > (nint)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rax_v17+30]");
						if (!ContentGroupMethods.IsDlcLoadedForContentGroup(ContentGroupType.BASE))
						{
							continue;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v12 (VampireSurvivors.Framework.Loading.MainMenuLoader+<>c__DisplayClass6_0)+18]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v12 (VampireSurvivors.Framework.Loading.MainMenuLoader+<>c__DisplayClass6_0)+18]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v8 (Il2CppClass<VampireSurvivors.Framework.Loading.MainMenuLoader+<>c__DisplayClass6_0>)+30]");
					DlcType? dlcTypeContentGroup = ContentGroupMethods.GetDlcTypeContentGroup(ContentGroupType.BASE);
					CS_0024_003C_003E8__locals4.dlcType = dlcTypeContentGroup;
					Action<Action> loadCall = delegate(Action cb)
					{
						//IL_0027: Expected O, but got I
						//IL_0047: Expected O, but got I
						//IL_0062: Expected I4, but got O
						_003C_003Ec__DisplayClass6_1 obj2 = new _003C_003Ec__DisplayClass6_1();
						obj2.cb = cb;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.Loading.MainMenuLoader+<>c__DisplayClass6_0)+18]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6+20]");
						string textureName = ((string)0).Replace(".png", "");
						Action<bool> action = null;
						((_003C_003Ec__DisplayClass6_1)(object)action)._003CLoadAlbumArt_003Eb__1((byte)(int)obj2 != 0);
						SpriteLoader.LoadTextureAsync(textureName, "MainMenu", CS_0024_003C_003E8__locals4.dlcType, action);
					};
					loader.Add(loadCall);
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public static void Release(Action onComplete)
	{
		while (true)
		{
			CharacterLoader.ClearCharacterTextures();
			AddressableCache.RemoveTexturesFromCacheAndSpriteManager("MainMenu");
			AddressableCache.ReleaseCustomOperationHandleGroup("MainMenu");
			IntPtr method = ((Delegate)onComplete).method;
			IntPtr method_code = ((Delegate)onComplete).method_code;
			IntPtr invoke_impl = ((Delegate)onComplete).invoke_impl;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v66 @ rax_v7 (System.IntPtr) (should have been resolved before IL gen)");
		}
	}
}
