using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy;

[Serializable]
public class SoundGroupData : ScriptableObject
{
	public enum PlayMode
	{
		Random,
		Sequence
	}

	public const bool DEFAULT_IGNORE_LISTENER_PAUSE = true;

	public const bool DEFAULT_LOOP = false;

	public const bool DEFAULT_RESET_SEQUENCE_AFTER_INACTIVE_TIME = false;

	public const float DEFAULT_PITCH = 0f;

	public const float DEFAULT_SEQUENCE_RESET_TIME = 5f;

	public const float DEFAULT_SPATIAL_BLEND = 0f;

	public const float DEFAULT_VOLUME = 0f;

	public const float MAX_PITCH = 24f;

	public const float MAX_SPATIAL_BLEND = 1f;

	public const float MAX_VOLUME = 0f;

	public const float MIN_PITCH = -24f;

	public const float MIN_SPATIAL_BLEND = 0f;

	public const float MIN_VOLUME = -80f;

	public const PlayMode DEFAULT_PLAY_MODE = PlayMode.Random;

	public const string DEFAULT_SOUND_NAME = "No Sound";

	public string DatabaseName;

	public string SoundName;

	public bool IgnoreListenerPause;

	public RangedFloat Volume;

	public RangedFloat Pitch;

	public float SpatialBlend;

	public bool Loop;

	public PlayMode Mode;

	public bool ResetSequenceAfterInactiveTime;

	public float SequenceResetTime;

	public List<AudioData> Sounds;

	private int m_lastPlayedSoundsIndex;

	private float m_lastPlayedSoundTime;

	private readonly List<AudioData> m_playedSounds;

	private AudioData m_lastPlayedAudioData;

	public unsafe bool HasMissingAudioClips
	{
		get
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected Ref, but got Unknown
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected Ref, but got Unknown
			//IL_00ad: Expected I8, but got I4
			//IL_0129: Expected O, but got I4
			string soundName = SoundName;
			object obj = "No Sound";
			if ((object)SoundName != "No Sound")
			{
				if ("No Sound" != null)
				{
					int stringLength = soundName._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v1+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(SoundName + 20);
						ref byte second = ref *(byte*)("No Sound" + 20);
						ulong length = (ulong)(soundName._stringLength + soundName._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first, ref second, length))
						{
							goto IL_018a;
						}
					}
				}
				if (Sounds != null)
				{
					List<AudioData> sounds = Sounds;
					if (sounds._size != 0)
					{
						List<AudioData>.Enumerator enumerator = default(List<AudioData>.Enumerator);
						if (!enumerator.MoveNext())
						{
							goto IL_018a;
						}
						object obj2 = 0;
					}
				}
				return true;
			}
			goto IL_018a;
			IL_018a:
			return false;
		}
	}

	public unsafe bool HasSound
	{
		get
		{
			//IL_014c: Expected I4, but got O
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Expected Ref, but got Unknown
			//IL_009d: Expected I8, but got I4
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected Ref, but got Unknown
			string soundName = SoundName;
			if (SoundName != null)
			{
				object obj = "No Sound";
				if ((object)SoundName != "No Sound")
				{
					if ("No Sound" != null)
					{
						int stringLength = soundName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte second = ref *(byte*)("No Sound" + 20);
							ulong length = (ulong)(soundName._stringLength + soundName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref *(byte*)(SoundName + 20), ref second, length))
							{
								goto IL_0138;
							}
						}
					}
					if (Sounds != null)
					{
						List<AudioData> sounds = Sounds;
						if (sounds._size != 0)
						{
							bool hasMissingAudioClips = HasMissingAudioClips;
							return (byte)((hasMissingAudioClips ? 1u : 0u) ^ 1u) != 0;
						}
					}
				}
				goto IL_0138;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0138:
			return false;
		}
	}

	public float RandomPitch
	{
		get
		{
			//IL_0096: Expected F4, but got I
			//IL_0096: Expected F4, but got O
			//IL_0018: Expected I, but got O
			//IL_002d: Invalid comparison between I4 and F4
			//IL_003c: Expected F4, but got I4
			RangedFloat pitch = Pitch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Soundy.SoundGroupData)+38]");
			float num = UnityEngine.Random.Range((float)pitch, 0f);
			nint num2 = (nint)typeof(SoundyUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
			bool flag = 0f > SoundyUtils.TwelfthRootOfTwo;
			float result = 0f;
			if (!flag)
			{
				bool flag2 = SoundyUtils.TwelfthRootOfTwo > 4f;
				result = 4f;
				if (!flag2)
				{
					result = SoundyUtils.TwelfthRootOfTwo;
				}
			}
			return result;
		}
	}

	public float RandomVolume
	{
		get
		{
			//IL_00af: Expected F4, but got I
			//IL_00af: Expected F4, but got O
			//IL_0093: Expected F4, but got I4
			//IL_0046: Invalid comparison between I4 and F4
			RangedFloat volume = Volume;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.Soundy.SoundGroupData)+30]");
			float num = UnityEngine.Random.Range((float)volume, 0f);
			float result;
			if (!(-80f > num))
			{
				float num2 = num / 20f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				if (!(0f > 10f))
				{
					bool flag = !(10f > 1f);
					result = 10f;
					if (!flag)
					{
						return 1f;
					}
					goto IL_00b8;
				}
			}
			result = 0f;
			goto IL_00b8;
			IL_00b8:
			return result;
		}
	}

	private void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A3E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundName = "No Sound";
		IgnoreListenerPause = true;
		Loop = false;
		SpatialBlend = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpcklpd xmm0,xmm0\"");
		RangedFloat volume = default(RangedFloat);
		Volume = volume;
		Mode = PlayMode.Random;
		ResetSequenceAfterInactiveTime = false;
		SequenceResetTime = 5f;
	}

	public bool Contains(AudioClip audioClip)
	{
		//IL_0117: Expected I4, but got O
		//IL_0063: Expected O, but got I4
		if ((object)audioClip != null && ((UnityEngine.Object)audioClip).m_CachedPtr != (IntPtr)0)
		{
			if (Sounds == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			List<AudioData>.Enumerator enumerator = default(List<AudioData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				throw new NullReferenceException();
			}
		}
		return false;
	}

	public unsafe SoundyController Play(Transform followTarget, AudioMixerGroup outputAudioMixerGroup = null)
	{
		//IL_005f: Expected O, but got Ref
		bool flag = ((UnityEngine.Object)followTarget).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)followTarget).m_CachedPtr, out Vector3 _);
		object obj = default(object);
		SoundyController soundyController = Play((Vector3)(&obj), outputAudioMixerGroup);
		soundyController.m_followTarget = followTarget;
		return soundyController;
	}

	public unsafe SoundyController Play(Vector3 position, AudioMixerGroup outputAudioMixerGroup = null)
	{
		//IL_00a5: Expected O, but got Ref
		SoundyController controllerFromPool = SoundyPooler.GetControllerFromPool();
		AudioData audioData = GetAudioData(Mode);
		m_lastPlayedAudioData = audioData;
		AudioData lastPlayedAudioData = m_lastPlayedAudioData;
		if (m_lastPlayedAudioData != null)
		{
			float randomVolume = RandomVolume;
			float randomPitch = RandomPitch;
			if ((object)controllerFromPool != null)
			{
				bool loop = default(bool);
				float spatialBlend = default(float);
				controllerFromPool.SetSourceProperties(lastPlayedAudioData.AudioClip, randomVolume, randomPitch, loop, spatialBlend);
				controllerFromPool.SetOutputAudioMixerGroup(outputAudioMixerGroup);
				object obj = default(object);
				controllerFromPool.SetPosition((Vector3)(&obj));
				if (m_lastPlayedAudioData == null)
				{
					goto IL_01e4;
				}
				GameObject gameObject = controllerFromPool.gameObject;
				string[] array = new string[5];
				if (array != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					AudioData lastPlayedAudioData2 = m_lastPlayedAudioData;
					if (m_lastPlayedAudioData != null && (object)lastPlayedAudioData2.AudioClip != null)
					{
						string text = ((UnityEngine.Object)lastPlayedAudioData2.AudioClip).GetName();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						string text2 = string.Concat(array);
						if ((object)gameObject != null)
						{
							((UnityEngine.Object)gameObject).SetName(text2);
							controllerFromPool.Play();
							goto IL_01e4;
						}
					}
				}
			}
		}
		return (SoundyController)(object)new NullReferenceException();
		IL_01e4:
		return controllerFromPool;
	}

	public void PlaySoundPreview(AudioSource audioSource, AudioMixerGroup outputAudioMixerGroup, AudioClip audioClip)
	{
		//IL_02b9: Expected I8, but got I4
		//IL_02be->IL01a8: Incompatible stack heights: 1 vs 0
		//IL_0275->IL019e: Incompatible stack heights: 1 vs 0
		if ((object)audioSource == null || ((UnityEngine.Object)audioSource).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		AudioClip audioClip2 = default(AudioClip);
		if ((object)audioClip2 != null)
		{
			bool flag = ((UnityEngine.Object)audioClip2).m_CachedPtr != (IntPtr)0;
			AudioClip audioClip3 = audioClip2;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		AudioData audioData = GetAudioData(Mode);
		m_lastPlayedAudioData = audioData;
		if (m_lastPlayedAudioData != null)
		{
			AudioData lastPlayedAudioData = m_lastPlayedAudioData;
			AudioClip audioClip3 = lastPlayedAudioData.AudioClip;
			goto IL_01f2;
		}
		return;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1863D0710");
		audioSource.ignoreListenerPause = IgnoreListenerPause;
		audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
		float randomVolume = RandomVolume;
		audioSource.volume = randomVolume;
		float randomPitch = RandomPitch;
		audioSource.pitch = randomPitch;
		audioSource.loop = Loop;
		audioSource.spatialBlend = SpatialBlend;
		Camera main = Camera.main;
		Transform transform = audioSource.transform;
		if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
		{
			Transform transform2 = main.transform;
			bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
		}
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		AudioSource.PlayHelper(audioSource, 0uL);
	}

	public void PlaySoundPreview(AudioSource audioSource, AudioMixerGroup outputAudioMixerGroup)
	{
		PlaySoundPreview(audioSource, outputAudioMixerGroup, null);
	}

	public void StopSoundPreview(AudioSource audioSource)
	{
		if ((object)audioSource != null && ((UnityEngine.Object)audioSource).m_CachedPtr != (IntPtr)0)
		{
			audioSource.Stop();
		}
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	private AudioData GetAudioData(PlayMode playMode)
	{
		//IL_03e3: Expected I4, but got I8
		//IL_0432: Expected I4, but got I8
		//IL_0539: Expected O, but got I4
		//IL_04aa->IL04d9: Incompatible stack heights: 3 vs 2
		//IL_055e->IL075f: Incompatible stack heights: 3 vs 2
		//IL_04d9->IL04d9: Incompatible stack heights: 3 vs 2
		//IL_0578->IL075f: Incompatible stack heights: 3 vs 2
		//IL_032e->IL016d: Incompatible stack heights: 8 vs 2
		//IL_02c1->IL016d: Incompatible stack heights: 7 vs 2
		if (Sounds != null)
		{
			List<AudioData> sounds = Sounds;
			if (sounds._size != 0)
			{
				if (!HasMissingAudioClips)
				{
					switch (playMode)
					{
					case PlayMode.Random:
					{
						List<AudioData> playedSounds3 = m_playedSounds;
						bool flag14 = m_playedSounds == null;
						List<AudioData> sounds6 = Sounds;
						bool flag15 = Sounds == null;
						bool flag16 = playedSounds3._size != sounds6._size;
						IntPtr intPtr = default(IntPtr);
						int num4 = (int)(nint)intPtr;
						int num2 = default(int);
						if (!flag16)
						{
							num4 = playedSounds3._size;
							int version2 = playedSounds3._version + 1;
							playedSounds3._version = version2;
							playedSounds3._size = (int)playMode;
							if (playedSounds3._size > 0)
							{
								Array.Clear(playedSounds3._items, 0, playedSounds3._size);
								num2 = 0;
							}
						}
						int num5;
						AudioData[] items3;
						nint num7 = default(nint);
						bool flag25;
						do
						{
							IL_016d:
							List<AudioData> sounds7 = Sounds;
							bool flag17 = Sounds == null;
							num5 = UnityEngine.Random.RandomRangeInt(0, sounds7._size);
							List<AudioData> sounds8 = Sounds;
							bool flag18 = Sounds == null;
							bool flag19 = num5 >= sounds8._size;
							items3 = sounds8._items;
							bool flag20 = sounds8._items == null;
							List<AudioData> playedSounds4 = m_playedSounds;
							bool flag21 = m_playedSounds == null;
							bool flag22 = playedSounds4._size == 0;
							nint num6 = num7;
							int num8 = num2;
							int num9 = num4;
							if (!flag22)
							{
								num2 = playedSounds4._size;
								int num10 = Array.IndexOf((object[])playedSounds4._items, (object)items3[num5], 0, playedSounds4._size);
								bool flag23 = num10 != -1;
								num7 = 0;
								num4 = 0;
								num6 = 0;
								num8 = playedSounds4._size;
								num9 = 0;
								if (flag23)
								{
									goto IL_016d;
								}
							}
							bool flag24 = m_playedSounds == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C330");
							m_lastPlayedSoundsIndex = num5;
							flag25 = items3[num5] == null;
							num7 = num6;
							num2 = num8;
							num4 = num9;
						}
						while (flag25);
						return items3[num5];
					}
					case PlayMode.Sequence:
					{
						List<AudioData> playedSounds = m_playedSounds;
						bool flag = m_playedSounds == null;
						List<AudioData> sounds2 = Sounds;
						bool flag2 = Sounds == null;
						if (playedSounds._size == sounds2._size)
						{
							m_lastPlayedSoundsIndex = -1;
						}
						if (ResetSequenceAfterInactiveTime)
						{
							float realtimeSinceStartup = Time.realtimeSinceStartup;
							float num = realtimeSinceStartup - m_lastPlayedSoundTime;
							if (num > SequenceResetTime)
							{
								m_lastPlayedSoundsIndex = -1;
							}
						}
						if (m_lastPlayedSoundsIndex == -1)
						{
							List<AudioData> playedSounds2 = m_playedSounds;
							bool flag3 = m_playedSounds == null;
							int version = playedSounds2._version + 1;
							playedSounds2._version = version;
							playedSounds2._size = 0;
							if (playedSounds2._size > 0)
							{
								Array.Clear(playedSounds2._items, 0, playedSounds2._size);
								int num2 = 0;
							}
						}
						bool flag4 = m_lastPlayedSoundsIndex == -1;
						int num3 = 0;
						if (!flag4)
						{
							List<AudioData> sounds3 = Sounds;
							bool flag5 = Sounds == null;
							object obj = sounds3._size - 1;
							bool flag6 = m_lastPlayedSoundsIndex >= (nint)obj;
							num3 = 0;
							if (!flag6)
							{
								num3 = m_lastPlayedSoundsIndex + 1;
							}
						}
						List<AudioData> sounds4 = Sounds;
						m_lastPlayedSoundsIndex = num3;
						bool flag7 = Sounds == null;
						bool flag8 = num3 >= sounds4._size;
						AudioData[] items = sounds4._items;
						bool flag9 = sounds4._items == null;
						bool flag10 = m_playedSounds == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C330");
						float realtimeSinceStartup2 = Time.realtimeSinceStartup;
						List<AudioData> sounds5 = Sounds;
						int lastPlayedSoundsIndex = m_lastPlayedSoundsIndex;
						m_lastPlayedSoundTime = realtimeSinceStartup2;
						bool flag11 = Sounds == null;
						bool flag12 = m_lastPlayedSoundsIndex >= sounds5._size;
						AudioData[] items2 = sounds5._items;
						bool flag13 = sounds5._items == null;
						return items2[lastPlayedSoundsIndex];
					}
					default:
						return null;
					}
				}
				string message = "Sound Group Data with the '" + SoundName + "' sound name has one or more null AudioClip references. Soundy will not play any sound from this group until the issue is resolved. Cannot continue.";
				DDebug.Log(message, this);
				return null;
			}
		}
		DDebug.Log("No sounds have been referenced to this AudioData file. Cannot continue.", this);
		return null;
	}

	public SoundGroupData()
	{
		//IL_0014: Expected I4, but got I8
		List<AudioData> sounds = new List<AudioData>();
		Sounds = sounds;
		m_lastPlayedSoundsIndex = -1;
		m_playedSounds = new List<AudioData>();
		base._002Ector();
	}
}
