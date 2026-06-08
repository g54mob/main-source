using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Sirenix.Utilities;
using UnityEngine;

namespace Kitchen.Components
{
	public class MusicSource : MonoBehaviour
	{
		private AudioSource SourceA;

		private AudioSource SourceB;

		private SoundSource SourceBackground;

		public AudioClip BackgroundClip;

		public List<MusicTrack> SoundTracks = new List<MusicTrack>();

		private MusicState State;

		private int CurrentTrack;

		[Range(0f, 1f)]
		public float PositionInClip;

		private double NextClipScheduleTime;

		private AudioSource ActiveSource => GetSource();

		private AudioSource InactiveSource => GetSource(current: false);

		public void PlayNewTrack(bool play_menu = false)
		{
			State = MusicState.Loop;
			Season current_season = Seasons.GetSeason();
			bool has_setting_tracks = SoundTracks.Any((MusicTrack i) => i.Settings != null && i.Settings.Contains(GameInfo.CurrentSetting));
			bool has_season_menu_tracks = SoundTracks.Any((MusicTrack i) => i.IsMenuTrack && i.Season == current_season);
			List<(MusicTrack, int)> list = SoundTracks.Select((MusicTrack track, int index) => (track: track, index: index)).Where(delegate((MusicTrack track, int index) pair)
			{
				if (play_menu)
				{
					if (!pair.track.IsMenuTrack)
					{
						return false;
					}
					if (!has_season_menu_tracks)
					{
						return pair.track.Season == Season.Normal;
					}
					return pair.track.Season == current_season;
				}
				if (pair.track.IsMenuTrack)
				{
					return false;
				}
				bool flag = !pair.track.Settings.IsNullOrEmpty();
				return has_setting_tracks ? (flag && pair.track.Settings.Contains(GameInfo.CurrentSetting)) : (!flag);
			}).ToList();
			CurrentTrack = ((list.Count != 0) ? list.Random().Item2 : 0);
			Debug.LogWarning("Playing " + SoundTracks[CurrentTrack].name);
			PlayClip(SoundTracks[CurrentTrack].Intro);
			SourceBackground.TransitionTime = 1f;
			SourceBackground.Stop();
		}

		public void RequestOutro()
		{
			if (State != MusicState.None)
			{
				State = MusicState.OutroQueued;
			}
		}

		public void Stop()
		{
			State = MusicState.None;
			SourceA.Stop();
			SourceB.Stop();
			SourceBackground.TransitionTime = 10f;
			SourceBackground.Play();
		}

		public void Start()
		{
			SourceA = CreateSource();
			SourceB = CreateSource();
			CreateBackground();
			PlayNewTrack(play_menu: true);
		}

		private AudioSource CreateSource()
		{
			GameObject obj = new GameObject("Sound Source");
			obj.transform.SetParent(base.transform);
			AudioSource audioSource = obj.AddComponent<AudioSource>();
			audioSource.loop = false;
			audioSource.volume = 0f;
			return audioSource;
		}

		private void CreateBackground()
		{
			GameObject obj = new GameObject("Background Source");
			obj.transform.SetParent(base.transform);
			SoundSource soundSource = obj.AddComponent<SoundSource>();
			soundSource.Configure(SoundCategory.Music, BackgroundClip);
			soundSource.TransitionTime = 10f;
			soundSource.VolumeMultiplier = 0.5f;
			soundSource.ShouldLoop = true;
			soundSource.Stop();
			SourceBackground = soundSource;
		}

		private AudioSource GetSource(bool current = true)
		{
			if (SourceA.isPlaying != current)
			{
				return SourceB;
			}
			return SourceA;
		}

		private double ClipDuration(AudioClip clip)
		{
			return (double)clip.samples / (double)clip.frequency;
		}

		protected void Update()
		{
			float volume = VolumeManagement.GetVolume(SoundCategory.Music);
			ActiveSource.volume = volume;
			InactiveSource.volume = volume;
			if (State == MusicState.None)
			{
				return;
			}
			if (AudioSettings.dspTime > NextClipScheduleTime - 1.0)
			{
				if (State == MusicState.OutroPlaying)
				{
					SourceBackground.Play();
					State = MusicState.None;
				}
				else
				{
					QueueClip(GetNextClip());
					if (State == MusicState.OutroQueued)
					{
						State = MusicState.OutroPlaying;
					}
				}
			}
			if (ActiveSource.clip != null)
			{
				PositionInClip = ActiveSource.time / ActiveSource.clip.length;
			}
		}

		private AudioClip GetNextClip()
		{
			if (State == MusicState.OutroQueued)
			{
				return SoundTracks[CurrentTrack].Outro;
			}
			return SoundTracks[CurrentTrack].Loops.Random();
		}

		private void QueueClip(AudioClip clip)
		{
			InactiveSource.Stop();
			InactiveSource.clip = clip;
			InactiveSource.PlayScheduled(NextClipScheduleTime);
			NextClipScheduleTime += ClipDuration(clip);
		}

		private void PlayClip(AudioClip clip)
		{
			SourceB.Stop();
			SourceA.clip = clip;
			SourceA.PlayScheduled(AudioSettings.dspTime + 5.0);
			NextClipScheduleTime = AudioSettings.dspTime + 5.0 + ClipDuration(clip);
			SourceA.SetScheduledEndTime(NextClipScheduleTime);
		}
	}
}
