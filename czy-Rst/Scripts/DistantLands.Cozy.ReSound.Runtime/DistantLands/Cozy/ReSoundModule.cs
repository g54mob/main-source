using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.Audio;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class ReSoundModule : CozyBiomeModuleBase<ReSoundModule>
	{
		[Serializable]
		public class MixerChannel
		{
			public float volume;

			public bool transitioning;

			public IEnumerator TransitionVolume(float target, float time)
			{
				float timer = time;
				transitioning = true;
				float startingVolume = volume;
				while (timer > 0f)
				{
					timer -= Time.deltaTime;
					volume = Mathf.Lerp(startingVolume, target, 1f - timer / time);
					yield return new WaitForEndOfFrame();
				}
				transitioning = false;
				volume = target;
			}

			public MixerChannel()
			{
				volume = 0f;
				transitioning = false;
			}

			public MixerChannel(float _volume, bool _transitioning)
			{
				volume = _volume;
				transitioning = _transitioning;
			}
		}

		public Transform resoundParent;

		public ReSoundDJ DJ;

		public ReSoundSetlist setlist;

		public Dictionary<ReSoundTrack, MixerChannel> localChannelMixerState = new Dictionary<ReSoundTrack, MixerChannel>();

		public Dictionary<ReSoundTrack, AudioSource> channelMixerOutput = new Dictionary<ReSoundTrack, AudioSource>();

		public float songTimer;

		public bool paused;

		public AudioMixerGroup mixerGroup;

		public ReSoundTrack currentTrack;

		public float masterVolume = 1f;

		public Dictionary<ReSoundFX, float> fXes = new Dictionary<ReSoundFX, float>();

		internal float fxWeight;

		public ReSoundModule Root => (ReSoundModule)parentModule;

		public override void InitializeModule()
		{
			base.InitializeModule();
			if (Application.isPlaying)
			{
				base.isBiomeModule = GetComponent<CozyBiome>();
				SetupMixerChannels();
				if (base.isBiomeModule)
				{
					AddBiome();
					return;
				}
				fXes = new Dictionary<ReSoundFX, float>();
				parentModule = this;
				masterVolume = 1f;
				PlayFromBeginning();
			}
		}

		public void SetupMixerChannels()
		{
			if (base.isBiomeModule)
			{
				if (parentModule == null)
				{
					parentModule = base.weatherSphere.GetModule<ReSoundModule>();
				}
				{
					foreach (ReSoundTrack availableTrack in Root.DJ.availableTracks)
					{
						if (!localChannelMixerState.Keys.Contains(availableTrack))
						{
							localChannelMixerState.Add(availableTrack, new MixerChannel());
						}
					}
					return;
				}
			}
			SetupParent();
			foreach (ReSoundTrack availableTrack2 in DJ.availableTracks)
			{
				GameObject obj = new GameObject();
				obj.transform.parent = resoundParent;
				obj.name = availableTrack2.name;
				AudioSource audioSource = obj.AddComponent<AudioSource>();
				audioSource.volume = 0f;
				audioSource.pitch = 1f;
				audioSource.clip = availableTrack2.clip;
				audioSource.outputAudioMixerGroup = mixerGroup;
				audioSource.playOnAwake = true;
				audioSource.time = 0f;
				audioSource.Play();
				if (!localChannelMixerState.Keys.Contains(availableTrack2))
				{
					localChannelMixerState.Add(availableTrack2, new MixerChannel());
				}
				if (!channelMixerOutput.Keys.Contains(availableTrack2))
				{
					channelMixerOutput.Add(availableTrack2, audioSource);
				}
			}
		}

		private void SetupParent()
		{
			if (!(resoundParent == null))
			{
				return;
			}
			Transform[] array = UnityEngine.Object.FindObjectsByType<Transform>(FindObjectsSortMode.None);
			foreach (Transform transform in array)
			{
				if (transform.name == "ReSound Parent")
				{
					resoundParent = transform;
					return;
				}
			}
			resoundParent = new GameObject().transform;
			resoundParent.name = "ReSound Parent";
		}

		private void Update()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (!paused)
			{
				UpdateLocalMixer();
			}
			if (!base.isBiomeModule)
			{
				ComputeBiomeWeights();
				UpdateGlobalMixer();
				if (!channelMixerOutput[currentTrack].isPlaying && DJ.noSilenceMode)
				{
					channelMixerOutput[currentTrack].Play();
				}
			}
		}

		public void UpdateLocalMixer()
		{
			if (weight == 0f)
			{
				return;
			}
			if (songTimer <= ((Root.DJ.transitionType != ReSoundDJ.TransitionType.noFade) ? Root.DJ.transitionTime : 0f))
			{
				StopTrack(currentTrack);
			}
			if (songTimer <= ((Root.DJ.transitionType == ReSoundDJ.TransitionType.crossfade) ? Root.DJ.transitionTime : 0f))
			{
				PlayTrack(RandomTrack());
			}
			songTimer -= Time.deltaTime;
			foreach (KeyValuePair<ReSoundTrack, AudioSource> item in channelMixerOutput)
			{
				item.Value.volume = localChannelMixerState[item.Key].volume;
			}
		}

		public void UpdateGlobalMixer()
		{
			fxWeight = Mathf.Clamp01(fxWeight);
			foreach (KeyValuePair<ReSoundTrack, MixerChannel> item in localChannelMixerState)
			{
				channelMixerOutput[item.Key].volume = localChannelMixerState[item.Key].volume * item.Key.volume * weight * masterVolume;
			}
			foreach (CozyBiomeModuleBase<ReSoundModule> biome in biomes)
			{
				foreach (KeyValuePair<ReSoundTrack, MixerChannel> item2 in ((ReSoundModule)biome).localChannelMixerState)
				{
					ReSoundTrack key = item2.Key;
					MixerChannel value = item2.Value;
					channelMixerOutput[key].volume += biome.weight * item2.Key.volume * value.volume * masterVolume;
				}
			}
			if (!DJ.resetOnEntry)
			{
				return;
			}
			foreach (KeyValuePair<ReSoundTrack, AudioSource> item3 in channelMixerOutput)
			{
				if (item3.Value.volume == 0f)
				{
					AudioClip clip = ((item3.Key.clipType == ReSoundTrack.ClipType.singleClip) ? item3.Key.clip : item3.Key.playlist[UnityEngine.Random.Range(0, item3.Key.playlist.Length - 1)]);
					item3.Value.clip = clip;
					item3.Value.Play();
					item3.Value.time = 0f;
				}
			}
		}

		private ReSoundTrack RandomTrack()
		{
			ReSoundTrack reSoundTrack = null;
			List<float> list = new List<float>();
			float num = 0f;
			foreach (ReSoundTrack availableTrack in setlist.availableTracks)
			{
				if (availableTrack == currentTrack && DJ.preventRepeatSongs)
				{
					list.Add(0f);
					num += 0f;
				}
				else
				{
					float chance = availableTrack.GetChance(base.weatherSphere, 0f);
					list.Add(chance);
					num += chance;
				}
			}
			float num2 = UnityEngine.Random.Range(0f, num);
			int num3 = 0;
			float num4 = 0f;
			while (num4 <= num2)
			{
				if (num3 >= list.Count)
				{
					reSoundTrack = setlist.availableTracks[setlist.availableTracks.Count - 1];
					break;
				}
				if (num2 >= num4 && num2 < num4 + list[num3])
				{
					reSoundTrack = setlist.availableTracks[num3];
					break;
				}
				num4 += list[num3];
				num3++;
			}
			if (!reSoundTrack)
			{
				reSoundTrack = setlist.availableTracks[0];
			}
			return reSoundTrack;
		}

		public void PlayTrack(ReSoundTrack track)
		{
			Play();
			if (!localChannelMixerState.ContainsKey(track))
			{
				localChannelMixerState.Add(track, new MixerChannel(0f, _transitioning: true));
			}
			currentTrack = track;
			songTimer = Root.channelMixerOutput[track].clip.length + (DJ.noSilenceMode ? 0f : UnityEngine.Random.Range(setlist.minSilenceTime, setlist.maxSilenceTime));
			if (Root.DJ.transitionType == ReSoundDJ.TransitionType.noFade)
			{
				if (!base.isBiomeModule)
				{
					localChannelMixerState[track].volume = 1f;
				}
			}
			else
			{
				StartCoroutine(localChannelMixerState[track].TransitionVolume(1f, Root.DJ.transitionTime));
			}
		}

		public void StopTrack(ReSoundTrack track)
		{
			if (!(track == null))
			{
				if (Root.DJ.transitionType == ReSoundDJ.TransitionType.noFade)
				{
					localChannelMixerState[track].volume = 0f;
				}
				else
				{
					StartCoroutine(localChannelMixerState[track].TransitionVolume(0f, Root.DJ.transitionTime));
				}
			}
		}

		public void Skip()
		{
			songTimer = 0f;
		}

		public void Pause()
		{
			paused = true;
			foreach (KeyValuePair<ReSoundTrack, AudioSource> item in channelMixerOutput)
			{
				item.Value.Pause();
			}
		}

		public void Play()
		{
			paused = false;
			foreach (KeyValuePair<ReSoundTrack, AudioSource> item in channelMixerOutput)
			{
				item.Value.UnPause();
			}
		}

		public void Shuffle()
		{
			Play();
			PlayTrack(RandomTrack());
		}

		public void PlayFromBeginning()
		{
			if ((bool)setlist.initialSong && setlist.startingStyle == ReSoundSetlist.StartingStyle.startWithInitialSong)
			{
				PlayTrack(setlist.initialSong);
			}
			else
			{
				PlayTrack(RandomTrack());
			}
		}

		public IEnumerator FreezeForTime(float freezeTime)
		{
			Pause();
			yield return new WaitForSeconds(freezeTime);
			Play();
		}

		public IEnumerator FadeToVolume(float fadeTime, float targetVolume)
		{
			float currentVolume = masterVolume;
			for (float i = 0f; i < fadeTime; i += Time.deltaTime)
			{
				masterVolume = Mathf.Lerp(currentVolume, targetVolume, i);
				yield return new WaitForEndOfFrame();
			}
			masterVolume = targetVolume;
		}

		public IEnumerator FadeOutFadeIn(float fadeTime, float waitTime)
		{
			float currentVolume = masterVolume;
			for (float i = 0f; i < fadeTime; i += Time.deltaTime)
			{
				masterVolume = Mathf.Lerp(currentVolume, 0f, i);
				yield return new WaitForEndOfFrame();
			}
			masterVolume = 0f;
			yield return new WaitForSeconds(waitTime);
			for (float i = 0f; i < fadeTime; i += Time.deltaTime)
			{
				masterVolume = Mathf.Lerp(0f, currentVolume, i);
				yield return new WaitForEndOfFrame();
			}
			masterVolume = currentVolume;
		}

		public void RunFreezeForTime(float freezeTime)
		{
			StartCoroutine(FreezeForTime(freezeTime));
		}

		public void RunFadeToVolume(float targetVolume)
		{
			StartCoroutine(FadeToVolume(1f, targetVolume));
		}

		public void RunFadeOutFadeIn(float waitTime)
		{
			StartCoroutine(FadeOutFadeIn(1f, waitTime));
		}

		public override void FrameReset()
		{
			List<KeyValuePair<ReSoundFX, float>> list = fXes.ToList();
			for (int i = 0; i < fXes.Count; i++)
			{
				KeyValuePair<ReSoundFX, float> keyValuePair = list[i];
				fXes[keyValuePair.Key] = 0f;
			}
		}
	}
}
