using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AOT;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class RadioMusicTracksSwitcher : IInitializable, IDisposable
	{
		private const int TRACKS_COUNT = 5;

		private const string STATIC_NOISE_MARKER_NAME = "Static Noise";

		private const string MUSIC_TRACK_INDEX_PARAMETER_NAME = "MusicTrack";

		private const int TRACK_WEIGHT_AFTER_PLAYING = -1;

		private readonly IAudioPlayerService audioPlayer;

		private EventReference musicSoundEvent;

		private EVENT_CALLBACK timelineCallback;

		private GCHandle timelineHandle;

		private EventInstance musicInstance;

		private readonly List<int> trackWeights;

		public RadioMusicTracksSwitcher(IAudioPlayerService audioPlayer, EventReference musicSoundEvent)
		{
			this.audioPlayer = audioPlayer;
			this.musicSoundEvent = musicSoundEvent;
			trackWeights = new List<int>();
		}

		public void Initialize()
		{
			for (int i = 0; i < 5; i++)
			{
				trackWeights.Add(5);
			}
		}

		public void Dispose()
		{
			StopPlaying();
		}

		public void StartPlaying(GameObject soundSourceObject)
		{
			if (!musicInstance.isValid())
			{
				audioPlayer.TryToCreateSoundEventAttached(musicSoundEvent, soundSourceObject, out musicInstance, startSoundEventInstance: false);
				timelineCallback = MusicEventCallback;
				musicInstance.setCallback(timelineCallback, EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
				timelineHandle = GCHandle.Alloc(this);
				musicInstance.setUserData(GCHandle.ToIntPtr(timelineHandle));
				musicInstance.start();
			}
		}

		[MonoPInvokeCallback(typeof(EVENT_CALLBACK))]
		private RESULT MusicEventCallback(EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
		{
			new EventInstance(instancePtr).getUserData(out var userdata);
			if (userdata != IntPtr.Zero && GCHandle.FromIntPtr(userdata).Target is RadioMusicTracksSwitcher radioMusicTracksSwitcher && type == EVENT_CALLBACK_TYPE.TIMELINE_MARKER && ((TIMELINE_MARKER_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(TIMELINE_MARKER_PROPERTIES))).name == "Static Noise")
			{
				radioMusicTracksSwitcher.SelectNextTrack();
			}
			return RESULT.OK;
		}

		private void SelectNextTrack()
		{
			int num = 0;
			foreach (int trackWeight in trackWeights)
			{
				if (trackWeight > 0)
				{
					num += trackWeight;
				}
			}
			int num2 = UnityEngine.Random.Range(0, num);
			num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < trackWeights.Count; i++)
			{
				if (trackWeights[i] <= 0)
				{
					continue;
				}
				num += trackWeights[i];
				if (num2 >= num)
				{
					continue;
				}
				musicInstance.setParameterByName("MusicTrack", i);
				trackWeights[i] = -1;
				for (int j = 0; j < trackWeights.Count; j++)
				{
					if (j != i)
					{
						trackWeights[j]++;
					}
					stringBuilder.AppendLine($"New weight of track with index {j} is {trackWeights[j]}");
				}
				UnityEngine.Debug.Log("[RadioMusicTracksSwitcher] is switching music tracks:" + $"\nSelected track's index is {i}\n" + stringBuilder.ToString());
				break;
			}
		}

		public void StopPlaying()
		{
			musicInstance.setCallback(null);
			audioPlayer?.StopSoundEventInstance(musicInstance, allowFadeOut: false);
			musicInstance.clearHandle();
			if (timelineHandle.IsAllocated)
			{
				timelineHandle.Free();
			}
		}
	}
}
