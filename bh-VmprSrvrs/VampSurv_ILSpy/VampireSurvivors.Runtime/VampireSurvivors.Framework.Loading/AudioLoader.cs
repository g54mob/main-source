using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loading;

public static class AudioLoader
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public DlcType? dlcType;

		public string cacheGroupName;

		public BgmType bgmType;
	}

	private sealed class _003C_003Ec__DisplayClass1_1
	{
		public MusicSetting settings;

		public _003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CLoadBgmAsync_003Eb__0(Action cb)
		{
			//IL_0077: Expected O, but got Ref
			_003C_003Ec__DisplayClass1_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass1_2();
			CS_0024_003C_003E8__locals2.cb = cb;
			_003C_003Ec__DisplayClass1_0 obj = CS_0024_003C_003E8__locals1;
			MusicSetting musicSetting = settings;
			_003C_003Ec__DisplayClass1_0 obj2 = CS_0024_003C_003E8__locals1;
			MusicSetting musicSetting2 = settings;
			if (musicSetting2.songName == null)
			{
				IntPtr intPtr = default(IntPtr);
				string text = ((Enum)(&intPtr)).ToString();
			}
			Action<AudioClip> action = delegate
			{
				Action cb2 = CS_0024_003C_003E8__locals2.cb;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F95F40");
		}
	}

	private sealed class _003C_003Ec__DisplayClass1_2
	{
		public Action cb;

		internal void _003CLoadBgmAsync_003Eb__1(AudioClip ac)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public string cacheGroupName;

		public string groupName;

		public Action onComplete;

		internal void _003CLoadSFXAsync_003Eb__0(AudioClip clip)
		{
			CacheLoadedSFX(cacheGroupName, groupName);
			Action action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public static Dictionary<string, List<string>> LoadedSFX;

	public unsafe static void LoadBgmAsync(BgmType bgmType, string cacheGroupName, DlcType? dlcType, Action onComplete)
	{
		//IL_0256: Expected I, but got O
		//IL_003a: Expected O, but got Ref
		//IL_007f: Expected I, but got O
		//IL_012a: Expected I, but got O
		_003C_003Ec__DisplayClass1_0 obj = new _003C_003Ec__DisplayClass1_0();
		bool flag = obj == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass1_0);
		if (!flag)
		{
			obj.dlcType = dlcType;
			obj.cacheGroupName = cacheGroupName;
			obj.bgmType = bgmType;
			IntPtr intPtr = default(IntPtr);
			string playlistName = ((Enum)(&intPtr)).ToString();
			MasterAudio.Playlist playlist = MasterAudio.GrabPlaylist(playlistName);
			if (playlist == null)
			{
				goto IL_01f8;
			}
			num = (nint)playlist.MusicSettings;
			if (playlist.MusicSettings != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v5 (Il2CppClass<VampireSurvivors.Framework.Loading.AudioLoader+<>c__DisplayClass1_0>)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_01f8;
				}
				AsyncLoader asyncLoader = new AsyncLoader(onComplete);
				if (playlist.MusicSettings != null)
				{
					List<MusicSetting>.Enumerator enumerator = default(List<MusicSetting>.Enumerator);
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass1_1 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass1_1();
						bool flag2 = CS_0024_003C_003E8__locals11 == null;
						nint num2 = (nint)typeof(_003C_003Ec__DisplayClass1_1);
						if (!flag2)
						{
							CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 = obj;
							CS_0024_003C_003E8__locals11.settings = null;
							if (CS_0024_003C_003E8__locals11.settings == null)
							{
								continue;
							}
							MusicSetting settings = CS_0024_003C_003E8__locals11.settings;
							if (settings.audioClipAddressable == null)
							{
								continue;
							}
							Action<Action> loadCall = delegate(Action cb)
							{
								//IL_0077: Expected O, but got Ref
								_003C_003Ec__DisplayClass1_2 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass1_2();
								CS_0024_003C_003E8__locals12.cb = cb;
								_003C_003Ec__DisplayClass1_0 obj2 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
								MusicSetting settings2 = CS_0024_003C_003E8__locals11.settings;
								_003C_003Ec__DisplayClass1_0 obj3 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
								MusicSetting settings3 = CS_0024_003C_003E8__locals11.settings;
								if (settings3.songName == null)
								{
									IntPtr intPtr2 = default(IntPtr);
									string text = ((Enum)(&intPtr2)).ToString();
								}
								Action<AudioClip> action = delegate
								{
									Action cb2 = CS_0024_003C_003E8__locals12.cb;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								};
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F95F40");
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
					bool flag3 = asyncLoader == null;
					num = (nint)(&enumerator);
					if (!flag3)
					{
						asyncLoader.Load();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_01f8:
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe static void LoadBgm(BgmType bgmType, string cacheGroupName, DlcType? dlcType, Action onComplete = null)
	{
		//IL_0168: Expected O, but got Ref
		//IL_003c: Expected O, but got I4
		//IL_0089: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		IntPtr intPtr = default(IntPtr);
		string playlistName = ((Enum)(&intPtr)).ToString();
		MasterAudio.Playlist playlist = MasterAudio.GrabPlaylist(playlistName);
		bool flag = playlist == null;
		List<MusicSetting> list = null;
		Action action = onComplete;
		object obj = 0;
		if (!flag)
		{
			List<MusicSetting> musicSettings = playlist.MusicSettings;
			bool flag2 = musicSettings._size <= 0;
			list = null;
			action = onComplete;
			obj = 0;
			if (!flag2)
			{
				obj = 0;
				action = (Action)(object)musicSettings;
				List<MusicSetting>.Enumerator enumerator = default(List<MusicSetting>.Enumerator);
				while (enumerator.MoveNext())
				{
					BgmType bgmType2 = BgmType.BGM_Forest;
				}
				list = musicSettings;
			}
		}
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe static void LoadSFX(SfxType sfxType, string cacheGroupName, DlcType? dlcType, Action onComplete = null)
	{
		//IL_014a: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_0094: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_00aa: Expected O, but got Ref
		string soundGroupFromType = SoundManager.GetSoundGroupFromType(sfxType);
		MasterAudioGroup masterAudioGroup = MasterAudio.GrabGroup(soundGroupFromType);
		bool flag = (object)masterAudioGroup == null;
		List<SoundGroupVariation>.Enumerator enumerator = (List<SoundGroupVariation>.Enumerator)0;
		Action action = onComplete;
		object obj = 0;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)masterAudioGroup).m_CachedPtr == (IntPtr)0;
			enumerator = (List<SoundGroupVariation>.Enumerator)0;
			action = onComplete;
			obj = 0;
			if (!flag2)
			{
				action = (Action)(object)masterAudioGroup.groupVariations;
				obj = 0;
				List<SoundGroupVariation>.Enumerator enumerator2 = default(List<SoundGroupVariation>.Enumerator);
				if (enumerator2.MoveNext())
				{
					object obj2 = 0;
					List<SoundGroupVariation>.Enumerator enumerator3 = (List<SoundGroupVariation>.Enumerator)(&enumerator2);
					throw new NullReferenceException();
				}
				enumerator = (List<SoundGroupVariation>.Enumerator)action;
			}
		}
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public static void LoadSFXAsync(SfxType sfxType, string cacheGroupName, DlcType? dlcType, Action onComplete = null)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals8.cacheGroupName = cacheGroupName;
		CS_0024_003C_003E8__locals8.onComplete = onComplete;
		string soundGroupFromType = SoundManager.GetSoundGroupFromType(sfxType);
		CS_0024_003C_003E8__locals8.groupName = soundGroupFromType;
		MasterAudioGroup masterAudioGroup = MasterAudio.GrabGroup(CS_0024_003C_003E8__locals8.groupName);
		if ((object)masterAudioGroup == null || ((UnityEngine.Object)masterAudioGroup).m_CachedPtr == (IntPtr)0 || masterAudioGroup.groupVariations == null)
		{
			return;
		}
		List<SoundGroupVariation> groupVariations = masterAudioGroup.groupVariations;
		if (groupVariations._size > 0)
		{
			SoundGroupVariation[] items = groupVariations._items;
			SoundGroupVariation soundGroupVariation = items[0];
			if (soundGroupVariation.audioClipAddressable == null)
			{
				return;
			}
			Action<AudioClip> action = delegate
			{
				CacheLoadedSFX(CS_0024_003C_003E8__locals8.cacheGroupName, CS_0024_003C_003E8__locals8.groupName);
				Action onComplete2 = CS_0024_003C_003E8__locals8.onComplete;
				if (CS_0024_003C_003E8__locals8.onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F95F40");
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private static void CacheLoadedSFX(string cacheGroupName, string sfxGroupName)
	{
		int num = LoadedSFX.FindEntry(cacheGroupName);
		if (num < 0)
		{
			List<string> value = new List<string>();
			bool flag = ((Dictionary<object, object>)(object)LoadedSFX).TryInsert((object)cacheGroupName, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			List<string> list = LoadedSFX.get_Item(cacheGroupName);
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)sfxGroupName);
				return;
			}
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		else
		{
			List<string> list2 = LoadedSFX.get_Item(cacheGroupName);
			List<string> list3 = ((Dictionary<string, List<string>>)(object)list2).get_Item(sfxGroupName);
			if (list3 == null)
			{
				List<string> list4 = LoadedSFX.get_Item(cacheGroupName);
				list4.Add(sfxGroupName);
			}
		}
	}

	public unsafe static bool IsSFXLoaded(SfxType sfx)
	{
		//IL_0020: Expected I, but got O
		//IL_0048: Expected I, but got O
		//IL_0069: Expected O, but got Ref
		//IL_0085: Expected I8, but got I4
		//IL_00ab: Expected I8, but got I4
		string soundGroupFromType = SoundManager.GetSoundGroupFromType(sfx);
		nint num = (nint)typeof(AudioLoader);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v4 (Il2CppClass<VampireSurvivors.Framework.Loading.AudioLoader>)+E4]");
		bool flag = (nint)0 != 0;
		nint num2 = (nint)typeof(AudioLoader);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v5 (Il2CppClass<VampireSurvivors.Framework.Loading.AudioLoader>)+B8]");
		nint num3 = 0;
		if (LoadedSFX == null)
		{
			throw new NullReferenceException();
		}
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
		List<string>.Enumerator enumerator4 = default(List<string>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag2 = (object)enumerator2 == null;
				Dictionary<object, object>.Enumerator enumerator3 = (Dictionary<object, object>.Enumerator)(&enumerator);
				if (flag2)
				{
					break;
				}
				while (enumerator4.MoveNext())
				{
					ulong num4 = 0uL;
					if (0 != (nint)soundGroupFromType)
					{
						ulong num5 = 0uL;
						continue;
					}
					return true;
				}
				continue;
			}
			return false;
		}
		throw new NullReferenceException();
	}

	public static void ReleaseCachedGroup(string cacheGroup)
	{
		int num = LoadedSFX.FindEntry(cacheGroup);
		if (num >= 0)
		{
			bool flag = ((Dictionary<object, object>)(object)LoadedSFX).Remove((object)cacheGroup);
		}
	}

	public static void ReleaseCachedKey(string keyName)
	{
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			List<object> list = null;
			throw new NullReferenceException();
		}
	}

	static AudioLoader()
	{
		Dictionary<string, List<string>> loadedSFX = new Dictionary<string, List<string>>();
		LoadedSFX = loadedSFX;
	}
}
