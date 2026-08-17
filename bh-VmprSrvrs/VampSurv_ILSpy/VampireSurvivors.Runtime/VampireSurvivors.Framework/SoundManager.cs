using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework;

public class SoundManager : IInitializable, IDisposable
{
	public class SoundConfig
	{
		public bool Mute;

		public float? Volume;

		public float Rate = 1f;

		public float Detune;

		public float Seek;

		public bool Loop;

		public float Delay;

		public float Pan;
	}

	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public SfxType sfxType;

		internal void _003CPlaySound_003Eb__0()
		{
			int num = SoundInstances.get_Item(sfxType);
			int value = num - 1;
			bool flag = ((Dictionary<System.Int32Enum, int>)(object)SoundInstances).TryInsert((System.Int32Enum)sfxType, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public SfxType sfxType;

		internal void _003CPlaySoundNonAlloc_003Eb__0()
		{
			int num = SoundInstances.get_Item(sfxType);
			int value = num - 1;
			bool flag = ((Dictionary<System.Int32Enum, int>)(object)SoundInstances).TryInsert((System.Int32Enum)sfxType, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
	}

	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public float fadeOutDuration;

		public PlaySoundResult prevSound;

		internal void _003CHandlePlaybackSkipping_003Eb__0()
		{
			PlaySoundResult playSoundResult = prevSound;
			playSoundResult._003CActingVariation_003Ek__BackingField.FadeOutNowAndStop(fadeOutDuration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public BgmType newTrack;

		public float? finalVolume;

		public float durationMillisIn;

		internal void _003CTransitionMusic_003Eb__0()
		{
			//IL_0078: Expected O, but got I4
			//IL_004c: Expected F4, but got I
			SoundConfig soundConfig = new SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Loop = true;
			PlayMusic(newTrack, soundConfig);
			bool flag = (object)finalVolume == null;
			float volume = 0.3f;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.SoundManager+<>c__DisplayClass34_0)+18]");
				volume = 0f;
			}
			FadeMusic(volume, durationMillisIn);
		}
	}

	private static PlayerOptions _playerOptions;

	private static readonly Dictionary<SfxType, int> SoundInstances;

	private static float _currentVolume;

	private static Dictionary<SfxType, PlaySoundResult> _prevSkippableSounds;

	private static DataManager _dataManager;

	private static BgmType _003CCurrentBgm_003Ek__BackingField;

	private static SoundConfig _003CCurrentMusicSoundConfig_003Ek__BackingField;

	private static bool _003CAllowUIFades_003Ek__BackingField;

	public const string BGM_CACHE_GROUP = "BGM";

	public const string SFX_CACHE_GROUP = "SFX";

	public static BgmType CurrentBgm
	{
		get
		{
			return _003CCurrentBgm_003Ek__BackingField;
		}
		set
		{
			_003CCurrentBgm_003Ek__BackingField = value;
		}
	}

	public static SoundConfig CurrentMusicSoundConfig
	{
		get
		{
			return _003CCurrentMusicSoundConfig_003Ek__BackingField;
		}
		set
		{
			_003CCurrentMusicSoundConfig_003Ek__BackingField = value;
		}
	}

	public static bool AllowUIFades
	{
		get
		{
			return _003CAllowUIFades_003Ek__BackingField;
		}
		set
		{
			_003CAllowUIFades_003Ek__BackingField = value;
		}
	}

	public static float NormalMusicVolume => 0.3f;

	private void Construct(PlayerOptions playerOptions, DataManager data)
	{
		_playerOptions = playerOptions;
		_dataManager = data;
	}

	public unsafe void Initialize()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_005d: Expected O, but got I4
		//IL_00d9: Expected O, but got Ref
		//IL_01bd: Expected O, but got I4
		//IL_016b: Expected O, but got I
		//IL_020e: Expected O, but got I
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		_prevSkippableSounds.Clear();
		SoundInstances.Clear();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = 0;
		object obj5 = default(object);
		object obj4 = obj5;
		if (obj4 != null)
		{
			object obj6 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v320 @ rdx_v8+8F8] (should have been resolved before IL gen)");
			IEnumerable source = default(IEnumerable);
			IEnumerable<SfxType> enumerable = Enumerable.Cast<SfxType>(source);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj8 = default(object);
			object obj7 = (object)(&obj8);
			Dictionary<System.Int32Enum, int> dictionary = null;
			object obj9 = default(object);
			object obj19 = default(object);
			System.Int32Enum key = default(System.Int32Enum);
			while (true)
			{
				object obj11;
				object obj18;
				if (obj8 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj9 != null)
					{
						bool flag = obj8 == null;
						dictionary = null;
						if (flag)
						{
							break;
						}
						object obj10 = obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r10_v6+12E]");
						if ((nint)obj3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r10_v6+B0]");
							obj11 = 0;
							object obj12 = obj3;
							while (true)
							{
								object obj13 = obj12 + obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r8_v11+v478 @ rax_v50*8]");
								if (0 == (nint)typeof(IEnumerator<SfxType>))
								{
									break;
								}
								obj12++;
								object obj14 = obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r10_v6+12E]");
								if ((nint)obj14 < 0)
								{
									continue;
								}
								goto IL_01aa;
							}
							object obj15 = obj12 + obj12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r8_v11+8+v534 @ rcx_v37*8]");
							object obj16 = (nint)0 << 4;
							object obj17 = obj16 + 312;
							obj18 = obj17 + obj10;
							goto IL_0317;
						}
						goto IL_01aa;
					}
					if (obj7 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					return;
				}
				throw new NullReferenceException();
				IL_01aa:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj11 = 0;
				obj18 = obj19;
				goto IL_0317;
				IL_0317:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v539 @ rdx_v19] (should have been resolved before IL gen)");
				bool flag2 = ((Dictionary<System.Int32Enum, int>)(object)SoundInstances).TryInsert(key, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			throw new NullReferenceException();
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		ex._002Ector("enumType");
		throw ex;
	}

	public void Dispose()
	{
	}

	public unsafe static void Cleanup()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_005d: Expected O, but got I4
		//IL_00d9: Expected O, but got Ref
		//IL_01bd: Expected O, but got I4
		//IL_016b: Expected O, but got I
		//IL_020e: Expected O, but got I
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		_prevSkippableSounds.Clear();
		SoundInstances.Clear();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = 0;
		object obj5 = default(object);
		object obj4 = obj5;
		if (obj4 != null)
		{
			object obj6 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v320 @ rdx_v8+8F8] (should have been resolved before IL gen)");
			IEnumerable source = default(IEnumerable);
			IEnumerable<SfxType> enumerable = Enumerable.Cast<SfxType>(source);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj8 = default(object);
			object obj7 = (object)(&obj8);
			Dictionary<System.Int32Enum, int> dictionary = null;
			object obj9 = default(object);
			object obj19 = default(object);
			System.Int32Enum key = default(System.Int32Enum);
			while (true)
			{
				object obj11;
				object obj18;
				if (obj8 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj9 != null)
					{
						bool flag = obj8 == null;
						dictionary = null;
						if (flag)
						{
							break;
						}
						object obj10 = obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r10_v6+12E]");
						if ((nint)obj3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r10_v6+B0]");
							obj11 = 0;
							object obj12 = obj3;
							while (true)
							{
								object obj13 = obj12 + obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r8_v11+v478 @ rax_v50*8]");
								if (0 == (nint)typeof(IEnumerator<SfxType>))
								{
									break;
								}
								obj12++;
								object obj14 = obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r10_v6+12E]");
								if ((nint)obj14 < 0)
								{
									continue;
								}
								goto IL_01aa;
							}
							object obj15 = obj12 + obj12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r8_v11+8+v534 @ rcx_v37*8]");
							object obj16 = (nint)0 << 4;
							object obj17 = obj16 + 312;
							obj18 = obj17 + obj10;
							goto IL_0317;
						}
						goto IL_01aa;
					}
					if (obj7 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					return;
				}
				throw new NullReferenceException();
				IL_01aa:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj11 = 0;
				obj18 = obj19;
				goto IL_0317;
				IL_0317:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v539 @ rdx_v19] (should have been resolved before IL gen)");
				bool flag2 = ((Dictionary<System.Int32Enum, int>)(object)SoundInstances).TryInsert(key, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			throw new NullReferenceException();
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		ex._002Ector("enumType");
		throw ex;
	}

	public static PlaySoundResult PlaySound(SfxType sfxType, SoundConfig soundConfig = null, float durationMillis = 0f, int maxInstances = 10, float time = 0f)
	{
		//IL_0561: Expected O, but got I4
		//IL_056a: Expected O, but got I4
		//IL_01d2: Invalid comparison between F4 and I4
		//IL_01e3: Expected I4, but got O
		//IL_01eb: Expected I4, but got O
		//IL_0213: Expected I4, but got O
		//IL_021b: Expected I4, but got O
		//IL_0088: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_0407: Expected O, but got I4
		//IL_03c9: Expected O, but got I4
		//IL_03f9: Expected O, but got I4
		//IL_05a2: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		//IL_0127: Expected O, but got I4
		//IL_049e: Expected O, but got I4
		//IL_049e: Expected O, but got I4
		//IL_049e: Expected F4, but got I
		//IL_0154: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals12.sfxType = sfxType;
		bool flag7 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num4 = default(int);
		TimerType timerType = default(TimerType);
		if (sfxType != SfxType.None)
		{
			string soundGroupFromType = GetSoundGroupFromType(sfxType);
			MasterAudioGroup masterAudioGroup = MasterAudio.GrabGroup(soundGroupFromType);
			bool flag = (object)masterAudioGroup == null;
			Action action = (Action)maxInstances;
			DlcType? dlcType = (DlcType?)(object)0;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)masterAudioGroup).m_CachedPtr == (IntPtr)0;
				action = (Action)maxInstances;
				dlcType = (DlcType?)(object)0;
				if (!flag2)
				{
					List<SoundGroupVariation> groupVariations = masterAudioGroup.groupVariations;
					if (groupVariations._size <= 0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						goto IL_05a7;
					}
					SoundGroupVariation[] items = groupVariations._items;
					SoundGroupVariation soundGroupVariation = items[0];
					bool flag3 = soundGroupVariation.audLocation != MasterAudio.AudioLocation.Addressable;
					action = (Action)maxInstances;
					dlcType = (DlcType?)(object)0;
					if (!flag3)
					{
						bool flag4 = AudioLoader.IsSFXLoaded(CS_0024_003C_003E8__locals12.sfxType);
						action = (Action)maxInstances;
						dlcType = (DlcType?)(object)0;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B7F160");
							DlcUtils dlcUtils = default(DlcUtils);
							DlcType? sFXDlcType = dlcUtils.GetSFXDlcType(CS_0024_003C_003E8__locals12.sfxType, _dataManager);
							AudioLoader.LoadSFX(CS_0024_003C_003E8__locals12.sfxType, "SFX", sFXDlcType);
							action = null;
							dlcType = sFXDlcType;
						}
					}
				}
			}
			bool flag5 = !(durationMillis > 0f);
			System.Collections.Generic.InsertionBehavior insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)action;
			int num = (int)dlcType;
			if (!flag5)
			{
				bool flag6 = maxInstances <= 0;
				insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)action;
				num = (int)dlcType;
				if (!flag6)
				{
					int num2 = SoundInstances.FindEntry(CS_0024_003C_003E8__locals12.sfxType);
					if (num2 >= 0)
					{
						int num3 = SoundInstances.get_Item(CS_0024_003C_003E8__locals12.sfxType);
						if (num3 < maxInstances)
						{
							Action onComplete = delegate
							{
								int num6 = SoundInstances.get_Item(CS_0024_003C_003E8__locals12.sfxType);
								int value = num6 - 1;
								bool flag11 = ((Dictionary<System.Int32Enum, int>)(object)SoundInstances).TryInsert((System.Int32Enum)CS_0024_003C_003E8__locals12.sfxType, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
							};
							float duration = durationMillis * 0.001f;
							Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag7, monoBehaviour, num4, timerType, isOnlineTimer: false, canPause: false);
							int num5 = SoundInstances.get_Item(CS_0024_003C_003E8__locals12.sfxType);
							num = num5 + 1;
							bool flag8 = ((Dictionary<System.Int32Enum, int>)(object)SoundInstances).TryInsert((System.Int32Enum)CS_0024_003C_003E8__locals12.sfxType, num, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
							insertionBehavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
							goto IL_034f;
						}
					}
					goto IL_052d;
				}
			}
			goto IL_034f;
		}
		goto IL_052d;
		IL_05b1:
		PlaySoundResult playSoundResult;
		return playSoundResult;
		IL_052d:
		playSoundResult = null;
		goto IL_05b1;
		IL_05a7:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		PlaySoundResult result = default(PlaySoundResult);
		return result;
		IL_034f:
		bool flag9 = soundConfig != null;
		SoundConfig soundConfig2 = soundConfig;
		if (!flag9)
		{
			SoundConfig soundConfig3 = new SoundConfig();
			soundConfig3.Rate = 1f;
			soundConfig2 = soundConfig3;
		}
		bool flag10 = (object)(soundConfig2.Volume = (float?)(((object)soundConfig2.Volume == null) ? ((object)1) : (((object)soundConfig2.Volume == null) ? ((object)0) : ((object)1)))) != null;
		soundConfig2.Volume = (float?)(object)flag10;
		string soundGroupFromType2 = GetSoundGroupFromType(CS_0024_003C_003E8__locals12.sfxType);
		if ((object)soundConfig2.Volume == null)
		{
			goto IL_05a7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rdi_v8 (VampireSurvivors.Framework.SoundManager+SoundConfig)+18]");
		playSoundResult = MasterAudio.PlaySound(soundGroupFromType2, 0f, (float?)(object)1, soundConfig2.Delay, (string)flag7, (double?)monoBehaviour, (byte)num4 != 0, (byte)timerType != 0);
		if (playSoundResult != null)
		{
			AudioSource varAudio = playSoundResult._003CActingVariation_003Ek__BackingField.VarAudio;
			varAudio.loop = soundConfig2.Loop;
			AudioSource varAudio2 = playSoundResult._003CActingVariation_003Ek__BackingField.VarAudio;
			float time2 = default(float);
			varAudio2.time = time2;
			HandlePlaybackSkipping(playSoundResult, CS_0024_003C_003E8__locals12.sfxType);
		}
		goto IL_05b1;
	}

	public static PlaySoundResult PlaySoundNonAlloc(SfxType sfxType, float durationMillis = 0f, int maxInstances = 10, float time = 0f, float? Volume = null, float Rate = 1f, float Detune = 0f, bool Loop = false, float Delay = 0f)
	{
		//IL_054b: Expected O, but got I4
		//IL_01c9: Invalid comparison between F4 and I4
		//IL_01e3: Expected I4, but got O
		//IL_037f: Expected O, but got I4
		//IL_0214: Expected I4, but got O
		//IL_009d: Expected O, but got I4
		//IL_0371: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_0401: Expected O, but got I4
		//IL_0401: Expected O, but got I4
		//IL_0159: Expected O, but got I4
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals12.sfxType = sfxType;
		bool flag7 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num4 = default(int);
		TimerType timerType = default(TimerType);
		if (sfxType != SfxType.None)
		{
			string soundGroupFromType = GetSoundGroupFromType(sfxType);
			MasterAudioGroup masterAudioGroup = MasterAudio.GrabGroup(soundGroupFromType);
			bool flag = (object)masterAudioGroup == null;
			DlcType? dlcType = (DlcType?)(object)0;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)masterAudioGroup).m_CachedPtr == (IntPtr)0;
				dlcType = (DlcType?)(object)0;
				if (!flag2)
				{
					List<SoundGroupVariation> groupVariations = masterAudioGroup.groupVariations;
					if (groupVariations._size <= 0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						goto IL_056e;
					}
					SoundGroupVariation[] items = groupVariations._items;
					SoundGroupVariation soundGroupVariation = items[0];
					bool flag3 = soundGroupVariation.audLocation != MasterAudio.AudioLocation.Addressable;
					dlcType = (DlcType?)(object)0;
					if (!flag3)
					{
						bool flag4 = AudioLoader.IsSFXLoaded(CS_0024_003C_003E8__locals12.sfxType);
						dlcType = (DlcType?)(object)0;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B7F160");
							DlcUtils dlcUtils = default(DlcUtils);
							DlcType? sFXDlcType = dlcUtils.GetSFXDlcType(CS_0024_003C_003E8__locals12.sfxType, _dataManager);
							AudioLoader.LoadSFX(CS_0024_003C_003E8__locals12.sfxType, "SFX", sFXDlcType);
							dlcType = sFXDlcType;
						}
					}
				}
			}
			bool flag5 = !(durationMillis > 0f);
			System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
			int num = (int)dlcType;
			if (!flag5)
			{
				bool flag6 = maxInstances <= 0;
				insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
				num = (int)dlcType;
				if (!flag6)
				{
					int num2 = SoundInstances.FindEntry(CS_0024_003C_003E8__locals12.sfxType);
					if (num2 >= 0)
					{
						int num3 = SoundInstances.get_Item(CS_0024_003C_003E8__locals12.sfxType);
						if (num3 < maxInstances)
						{
							Action onComplete = delegate
							{
								int num6 = SoundInstances.get_Item(CS_0024_003C_003E8__locals12.sfxType);
								int value = num6 - 1;
								bool flag10 = ((Dictionary<System.Int32Enum, int>)(object)SoundInstances).TryInsert((System.Int32Enum)CS_0024_003C_003E8__locals12.sfxType, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
							};
							float duration = durationMillis * 0.001f;
							Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag7, monoBehaviour, num4, timerType, isOnlineTimer: false, canPause: false);
							int num5 = SoundInstances.get_Item(CS_0024_003C_003E8__locals12.sfxType);
							num = num5 + 1;
							bool flag8 = ((Dictionary<System.Int32Enum, int>)(object)SoundInstances).TryInsert((System.Int32Enum)CS_0024_003C_003E8__locals12.sfxType, num, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
							insertionBehavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
							goto IL_0348;
						}
					}
					goto IL_0516;
				}
			}
			goto IL_0348;
		}
		goto IL_0516;
		IL_05c1:
		PlaySoundResult playSoundResult;
		return playSoundResult;
		IL_0516:
		playSoundResult = null;
		goto IL_05c1;
		IL_056e:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		PlaySoundResult result = default(PlaySoundResult);
		return result;
		IL_0348:
		IntPtr intPtr = default(IntPtr);
		object obj = ((intPtr != (IntPtr)0) ? ((object)1) : ((object)1));
		bool flag9 = obj != null;
		string soundGroupFromType2 = GetSoundGroupFromType(CS_0024_003C_003E8__locals12.sfxType);
		if (!flag9)
		{
			goto IL_056e;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		float delaySoundTime = default(float);
		playSoundResult = MasterAudio.PlaySound(soundGroupFromType2, 0.1f, (float?)(object)1, delaySoundTime, (string)flag7, (double?)monoBehaviour, (byte)num4 != 0, (byte)timerType != 0);
		if (playSoundResult != null)
		{
			SoundGroupVariation soundGroupVariation2 = playSoundResult._003CActingVariation_003Ek__BackingField;
			if ((object)playSoundResult._003CActingVariation_003Ek__BackingField != null && ((UnityEngine.Object)soundGroupVariation2).m_CachedPtr != (IntPtr)0)
			{
				AudioSource varAudio = playSoundResult._003CActingVariation_003Ek__BackingField.VarAudio;
				if ((object)varAudio != null && ((UnityEngine.Object)varAudio).m_CachedPtr != (IntPtr)0)
				{
					AudioSource varAudio2 = playSoundResult._003CActingVariation_003Ek__BackingField.VarAudio;
					bool loop = default(bool);
					varAudio2.loop = loop;
					AudioSource varAudio3 = playSoundResult._003CActingVariation_003Ek__BackingField.VarAudio;
					varAudio3.time = time;
					HandlePlaybackSkipping(playSoundResult, CS_0024_003C_003E8__locals12.sfxType);
				}
			}
		}
		goto IL_05c1;
	}

	private static void HandlePlaybackSkipping(PlaySoundResult sound, SfxType sfxType)
	{
		//IL_0085: Expected F4, but got I4
		//IL_008e: Expected F4, but got I4
		//IL_040a: Expected O, but got F4
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals6.fadeOutDuration = 0.01f;
		float num;
		float num2;
		float num3;
		switch (sfxType)
		{
		case SfxType.Coin:
			num = 15.6f;
			num2 = -0.01f;
			num3 = 0.005f;
			break;
		case SfxType.Gem:
			num = 250f;
			num2 = 0f;
			num3 = 0f;
			break;
		default:
			return;
		}
		if (sound != null)
		{
			SoundGroupVariation soundGroupVariation = sound._003CActingVariation_003Ek__BackingField;
			if ((object)sound._003CActingVariation_003Ek__BackingField == null || ((UnityEngine.Object)soundGroupVariation).m_CachedPtr == (IntPtr)0)
			{
				Debug.LogError("VACUUM :: SOUND ActingVariation IS NULL");
			}
			AudioSource varAudio = sound._003CActingVariation_003Ek__BackingField.VarAudio;
			if ((object)varAudio == null || ((UnityEngine.Object)varAudio).m_CachedPtr == (IntPtr)0)
			{
				Debug.LogError("VACUUM :: SOUND VarAudio IS NULL");
			}
			AudioSource varAudio2 = sound._003CActingVariation_003Ek__BackingField.VarAudio;
			if (((UnityEngine.Object)varAudio2).m_CachedPtr != (IntPtr)0)
			{
				object obj = AudioSource.get_time_Injected(((UnityEngine.Object)varAudio2).m_CachedPtr);
				object obj2 = default(object);
				float time = (float)obj2 + num3;
				varAudio2.time = time;
				AudioSource varAudio3 = sound._003CActingVariation_003Ek__BackingField.VarAudio;
				float pitch = varAudio3.pitch;
				float pitch2 = pitch + num2;
				varAudio3.pitch = pitch2;
				if (_prevSkippableSounds == null)
				{
					return;
				}
				int num4 = ((Dictionary<System.Int32Enum, object>)(object)_prevSkippableSounds).FindEntry((System.Int32Enum)sfxType);
				Dictionary<System.Int32Enum, object> prevSkippableSounds;
				System.Collections.Generic.InsertionBehavior behavior;
				if (num4 >= 0)
				{
					object prevSound = ((Dictionary<System.Int32Enum, object>)(object)_prevSkippableSounds).get_Item((System.Int32Enum)sfxType);
					CS_0024_003C_003E8__locals6.prevSound = (PlaySoundResult)prevSound;
					if (CS_0024_003C_003E8__locals6.prevSound == null)
					{
						Debug.LogError("VACUUM :: prevSound IS NULL");
					}
					PlaySoundResult prevSound2 = CS_0024_003C_003E8__locals6.prevSound;
					SoundGroupVariation soundGroupVariation2 = prevSound2._003CActingVariation_003Ek__BackingField;
					if ((object)prevSound2._003CActingVariation_003Ek__BackingField == null || ((UnityEngine.Object)soundGroupVariation2).m_CachedPtr == (IntPtr)0)
					{
						Debug.LogError("VACUUM :: prevSound ActingVariation IS NULL");
					}
					Action onComplete = delegate
					{
						PlaySoundResult prevSound3 = CS_0024_003C_003E8__locals6.prevSound;
						prevSound3._003CActingVariation_003Ek__BackingField.FadeOutNowAndStop(CS_0024_003C_003E8__locals6.fadeOutDuration);
					};
					float duration = num * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					prevSkippableSounds = (Dictionary<System.Int32Enum, object>)(object)_prevSkippableSounds;
					behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
				}
				else
				{
					prevSkippableSounds = (Dictionary<System.Int32Enum, object>)(object)_prevSkippableSounds;
					behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
				}
				bool flag = prevSkippableSounds.TryInsert((System.Int32Enum)sfxType, (object)sound, behavior);
				return;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(varAudio2);
		}
		Debug.LogError("VACUUM :: SOUND IS NULL");
		throw new NullReferenceException();
	}

	public static void StopSound(SfxType sfxType)
	{
		MasterAudio safeInstance = MasterAudio.SafeInstance;
		if ((object)safeInstance != null && ((UnityEngine.Object)safeInstance).m_CachedPtr != (IntPtr)0)
		{
			string soundGroupFromType = GetSoundGroupFromType(sfxType);
			MasterAudio.StopAllOfSound(soundGroupFromType);
		}
	}

	public static void StopAll()
	{
		MasterAudio.StopMixer();
	}

	public unsafe static void GetPlaylistSource(BgmType bgmType)
	{
		//IL_000e: Expected O, but got Ref
		if (bgmType != BgmType.NONE)
		{
			object obj = default(object);
			string playlistName = ((Enum)(&obj)).ToString();
			MasterAudio.Playlist playlist = MasterAudio.GrabPlaylist(playlistName);
		}
	}

	public static void PreloadBgmAsync(BgmType bgmType)
	{
		//IL_0028: Expected O, but got I
		//IL_0081: Expected O, but got I
		List<BgmType> list = new List<BgmType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)bgmType);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj2 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 117 Invalid \"Jump target not found in method: 0x1877FB760\"");
		throw new NullReferenceException();
	}

	public unsafe static void PreloadBgmAsync(List<BgmType> bgmTypes)
	{
		//IL_026d: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00bf: Expected O, but got Ref
		//IL_0159: Expected O, but got Ref
		//IL_0105: Expected O, but got I4
		//IL_010d: Expected O, but got Ref
		object obj = default(object);
		object obj2 = default(object);
		List<MusicSetting>.Enumerator enumerator2 = default(List<MusicSetting>.Enumerator);
		IntPtr intPtr = default(IntPtr);
		List<MusicSetting>.Enumerator enumerator3 = default(List<MusicSetting>.Enumerator);
		List<BgmType> list;
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-70_v3+1C]");
				if (obj2 == null)
				{
					List<MusicSetting>.Enumerator enumerator = enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-70_v3+18]");
					if ((nint)enumerator < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-70_v3+10]");
						object obj3 = 0;
						enumerator2 = (List<MusicSetting>.Enumerator)(enumerator2 + 1);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rdi_v9+20+v627 @ rcx_v16 (System.Collections.Generic.List`1<DarkTonic.MasterAudio.MusicSetting>+Enumerator<DarkTonic.MasterAudio.MusicSetting>)*4]");
						if ((nint)0 != 14)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rdi_v9+20+v627 @ rcx_v16 (System.Collections.Generic.List`1<DarkTonic.MasterAudio.MusicSetting>+Enumerator<DarkTonic.MasterAudio.MusicSetting>)*4]");
							DlcSystem.PrepareBgmLoad(BgmType.BGM_Forest);
							string text = ((Enum)(&intPtr)).ToString();
							MasterAudio.Playlist playlist = MasterAudio.GrabPlaylist(text, logErrorIfNotFound: false);
							if (playlist == null)
							{
								string message = "Playlist " + text + " does not exist in MA. Please check the data matches the MA playlist config";
								Debug.LogWarning(message);
								return;
							}
							if (enumerator3.MoveNext())
							{
								object obj4 = 0;
								List<MusicSetting>.Enumerator enumerator4 = (List<MusicSetting>.Enumerator)(&enumerator3);
								throw new NullReferenceException();
							}
							list = (List<BgmType>)(&enumerator3);
							continue;
						}
						return;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		list = (List<BgmType>)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-70_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			list = null;
		}
		throw new NullReferenceException();
	}

	public unsafe static void PlayMusic(BgmType bgmType, SoundConfig config = null)
	{
		//IL_00d3: Expected O, but got Ref
		//IL_00e5: Expected O, but got I4
		//IL_00ed: Expected O, but got Ref
		//IL_00fb: Expected O, but got I4
		//IL_0082: Expected O, but got Ref
		//IL_0094: Expected O, but got I4
		//IL_009c: Expected O, but got Ref
		//IL_00aa: Expected O, but got I4
		//IL_0128: Expected O, but got Ref
		//IL_01f8: Expected O, but got I4
		//IL_0218: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_0387: Expected O, but got I4
		//IL_03bc: Expected O, but got I4
		//IL_0401: Expected F4, but got I
		if (bgmType == BgmType.NONE)
		{
			return;
		}
		BgmType bgmType2 = default(BgmType);
		object arg = bgmType2;
		System.ParamsArray paramsArray = default(System.ParamsArray);
		string message;
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		float? num;
		if (config != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg2 = default(object);
			object arg3 = default(object);
			paramsArray = new System.ParamsArray(arg, arg2, arg3);
			message = string.FormatHelper((IFormatProvider)null, "playing BGM {0} with rate {1} and detune {2}", (System.ParamsArray)(&paramsArray2));
			object obj = 0;
			System.ParamsArray paramsArray3 = (System.ParamsArray)(&paramsArray2);
			List<MusicSetting> list = null;
			num = (float?)(object)0;
			System.ParamsArray paramsArray4 = paramsArray;
		}
		else
		{
			paramsArray2 = new System.ParamsArray(arg);
			message = string.FormatHelper((IFormatProvider)null, "playing BGM {0} with default/null config", (System.ParamsArray)(&paramsArray));
			object obj = 0;
			System.ParamsArray paramsArray3 = (System.ParamsArray)(&paramsArray);
			List<MusicSetting> list = null;
			num = (float?)(object)0;
			System.ParamsArray paramsArray4 = paramsArray2;
		}
		Debug.Log(message);
		DlcSystem.PrepareBgmLoad(bgmType);
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187806D00");
		float? num2 = ((config == null) ? num : config.Volume);
		float num3 = default(float);
		float currentVolume = (((object)num2 == null) ? 1f : num3);
		_currentVolume = currentVolume;
		MasterAudio.Playlist playlist = MasterAudio.GrabPlaylist(text, logErrorIfNotFound: false);
		if (playlist != null)
		{
			List<MusicSetting> musicSettings = playlist.MusicSettings;
			bool flag = musicSettings._size <= 0;
			object obj2 = 0;
			bool flag2 = false;
			if (!flag)
			{
				obj2 = 0;
				List<MusicSetting> list = musicSettings;
				List<MusicSetting>.Enumerator enumerator = default(List<MusicSetting>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj3 = 0;
					throw new NullReferenceException();
				}
				flag2 = false;
			}
			if (config != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				float pitch = 1.0005778f * config.Rate;
				MasterAudio.ChangePlaylistPitch(text, pitch);
				PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
				AudioSource activeAudioSource = onlyPlaylistController.ActiveAudioSource;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				float pitch2 = 1.0005778f * config.Rate;
				activeAudioSource.pitch = pitch2;
			}
			MasterAudio.StartPlaylist("~only~", text);
			if (config != null)
			{
				if ((object)config.Volume == null)
				{
					config.Volume = (float?)(object)1;
				}
				else
				{
					if ((object)config.Volume != null)
					{
						num = (float?)(object)1;
					}
					config.Volume = num;
				}
				PlaylistController onlyPlaylistController2 = MasterAudio.OnlyPlaylistController;
				if ((object)config.Volume == null)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.SoundManager+SoundConfig)+18]");
				onlyPlaylistController2._playlistVolume = 0f;
				onlyPlaylistController2.UpdateMasterVolume();
			}
			PlaylistController onlyPlaylistController3 = MasterAudio.OnlyPlaylistController;
			AudioSource activeAudioSource2 = onlyPlaylistController3.ActiveAudioSource;
			activeAudioSource2.priority = 10;
		}
		else
		{
			string message2 = "Playlist " + text + " does not exist in MA. Please check the data matches the MA playlist config";
			Debug.LogWarning(message2);
		}
	}

	public static void TransitionMusic(BgmType newTrack, float durationMillisOut, float durationMillisIn, float? finalVolume = null)
	{
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass34_0();
		CS_0024_003C_003E8__locals6.durationMillisIn = durationMillisIn;
		CS_0024_003C_003E8__locals6.newTrack = newTrack;
		CS_0024_003C_003E8__locals6.finalVolume = finalVolume;
		FadeMusic(0f, durationMillisOut);
		Action onComplete = delegate
		{
			//IL_0078: Expected O, but got I4
			//IL_004c: Expected F4, but got I
			SoundConfig soundConfig = new SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Loop = true;
			PlayMusic(CS_0024_003C_003E8__locals6.newTrack, soundConfig);
			bool flag = (object)CS_0024_003C_003E8__locals6.finalVolume == null;
			float volume = 0.3f;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.SoundManager+<>c__DisplayClass34_0)+18]");
				volume = 0f;
			}
			FadeMusic(volume, CS_0024_003C_003E8__locals6.durationMillisIn);
		};
		float duration = durationMillisOut * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public static void FadeInMusic(BgmType newTrack, float fadeInTimeMillis, float? finalVolume = null)
	{
		//IL_004c: Expected O, but got I4
		SoundConfig soundConfig = new SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Loop = true;
		PlayMusic(newTrack, soundConfig);
		if ((object)finalVolume != null)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 104 Invalid \"Jump target not found in method: 0x1877FC7B0\"");
	}

	public static void StopMusic(BgmType bgmType)
	{
		MasterAudio.StopPlaylist("~only~");
	}

	public static void FadeMusic(float volume, float durationMillis)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 74 Invalid \"Jump target not found in method: 0x1877FC860\"");
	}

	public static void FadeMusic(BgmType bgmType, float volume, float durationMillis)
	{
		//IL_0025: Invalid comparison between I4 and F4
		_currentVolume = volume;
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		if (0f < mainGameConfig._003CMusicVolume_003Ek__BackingField)
		{
			PlayerOptions playerOptions2 = _playerOptions;
			PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
			float fadeTime = durationMillis * 0.001f;
			float targetVolume = mainGameConfig2._003CMusicVolume_003Ek__BackingField * volume;
			MasterAudio.FadePlaylistToVolume("~only~", targetVolume, fadeTime);
		}
		else
		{
			PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
			onlyPlaylistController._playlistVolume = 0f;
			onlyPlaylistController.UpdateMasterVolume();
		}
	}

	public static void UpdateMusicVolume(float volume)
	{
		if (_003CCurrentMusicSoundConfig_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D20");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v8+14]");
			if ((nint)0 != 0)
			{
				PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
				float playlistVolume = volume * _currentVolume;
				onlyPlaylistController._playlistVolume = playlistVolume;
				onlyPlaylistController.UpdateMasterVolume();
			}
		}
	}

	public static void UpdateSfxVolume(float volume)
	{
		MasterAudio.MasterVolumeLevel = volume;
	}

	public unsafe static void UpdateCurrentMusicWithConfig(SoundConfig config)
	{
		//IL_002c: Expected O, but got Ref
		if (config != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187806D00");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			IntPtr intPtr = default(IntPtr);
			string playlistName = ((Enum)(&intPtr)).ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
			float pitch = 1.0005778f * config.Rate;
			MasterAudio.ChangePlaylistPitch(playlistName, pitch);
			PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
			AudioSource activeAudioSource = onlyPlaylistController.ActiveAudioSource;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
			float pitch2 = 1.0005778f * config.Rate;
			activeAudioSource.pitch = pitch2;
		}
	}

	public static string GetSoundGroupFromType(SfxType sfxType)
	{
		//IL_00b1: Expected O, but got I4
		//IL_0040: Expected O, but got I8
		//IL_005a: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A66B1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = sfxType - 1;
		if ((nint)obj <= 552)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v4+7800C64+v32 @ rax_v2*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v52 @ rcx_v11 (should have been resolved before IL gen)");
		}
		SfxType sfxType2 = default(SfxType);
		object actualValue = sfxType2;
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("sfxType", actualValue, null);
		throw ex;
	}

	private static float CalculatePitch(float detune, float rate)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		return 1.0005778f * rate;
	}

	static SoundManager()
	{
		Dictionary<SfxType, int> soundInstances = new Dictionary<SfxType, int>();
		SoundInstances = soundInstances;
		_currentVolume = 1f;
		Dictionary<SfxType, PlaySoundResult> prevSkippableSounds = new Dictionary<SfxType, PlaySoundResult>();
		_prevSkippableSounds = prevSkippableSounds;
		_003CAllowUIFades_003Ek__BackingField = true;
	}
}
