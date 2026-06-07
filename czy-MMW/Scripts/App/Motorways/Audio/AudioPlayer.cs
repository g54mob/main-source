using System;
using System.Collections.Generic;
using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public class AudioPlayer
	{
		public static AudioPlayer UI;

		public static AudioPlayer Default;

		public GATPlayer GAT;

		public static double EarliestSchedulableTime => AudioSystem.Instance.DspTime + 2.0 * GATInfo.AudioBufferDuration;

		public AudioPlayer(string name)
		{
			AudioSource component;
			if (name == "Default")
			{
				GAT = GATManager.DefaultPlayer;
				GAT.DeleteTrack(GATManager.DefaultPlayer.GetTrack(0));
				component = GAT.gameObject.GetComponent<AudioSource>();
			}
			else
			{
				GAT = new GameObject().AddComponent<GATPlayer>();
				GAT.transform.parent = GATManager.UniqueInstance.transform;
				GAT.name = name + " Player";
				component = GAT.gameObject.GetComponent<AudioSource>();
			}
			GAT.Clip = false;
			component.bypassEffects = true;
			component.bypassListenerEffects = true;
			component.bypassReverbZones = true;
			component.outputAudioMixerGroup = Get.Mixbus.Mixer.FindMatchingGroups(name)[0];
		}

		public void PlayChord(string samplePrefix, List<string> notes, double dspTime = -1.0, float arpeggioRate = 0.05f, float gain = 1f, float gainEnd = -1f, float minPan = 0f, float maxPan = 1f, float fadeTimeStart = 0f, float fadeTimeEnd = 0f, int count = -1, bool downwards = false)
		{
			if (notes == null)
			{
				Dbug.Log.Info("PlayChord(): Notes list is null.");
				return;
			}
			if (gainEnd < 0f)
			{
				gainEnd = gain;
			}
			if (dspTime < 0.0)
			{
				dspTime = EarliestSchedulableTime + (double)arpeggioRate;
			}
			count = ((count < 1) ? notes.Count : Mathf.Min(count, notes.Count));
			for (int i = 0; i < count; i++)
			{
				int index = (downwards ? (count - 1 - i) : i);
				PlaySample(samplePrefix + "_" + notes[index], UnityEngine.Random.Range(minPan, maxPan), dspTime: dspTime + (double)(arpeggioRate * (float)i), gain: Mathf.Lerp(gain, gainEnd, (i != 0) ? (i / notes.Count - 1) : 0) * Note.GainFactor(notes[index]), pitch: 1f, fadeTime: Mathf.Lerp(fadeTimeStart, fadeTimeEnd, (i != 0) ? (i / notes.Count - 1) : 0));
			}
		}

		public AudioSample PrepSample(string sampleName, float pan = -1f, float pitch = 1f, double fadeTime = 0.0, IGATDynamicMixInfo mix = null, bool loop = false, bool randomStart = false, float startPosition = 0f, bool isImportant = false)
		{
			AudioSample sample = GetSample(sampleName);
			if (sample == null)
			{
				return null;
			}
			sample.Player = GAT;
			sample.Pitch = pitch;
			sample.Name = sampleName;
			sample.FadesIn = fadeTime > 0.0;
			sample.FadeInDuration = fadeTime;
			sample.IsLooping = loop;
			sample.IsImportant = isImportant;
			sample.FixedPan = Mathf.Clamp01(pan);
			if (randomStart)
			{
				sample.SetStartPosition(UnityEngine.Random.value * sample.Duration);
			}
			else if (startPosition > 0f)
			{
				sample.SetStartPosition(startPosition * sample.Duration);
			}
			if (mix != null)
			{
				sample.DynamicMix = mix;
			}
			return sample;
		}

		public AudioSample PlaySample(string sampleName, float pan = 0.5f, float gain = 1f, float pitch = 1f, double fadeTime = 0.0, double dspTime = -1.0, bool loop = false, IGATDynamicMixInfo mix = null, bool stereo = false, bool randomStart = false, float startPosition = 0f, bool isImportant = false)
		{
			if (stereo)
			{
				PlaySample(sampleName + "_0", Mathf.Clamp01(pan - 0.5f), gain, pitch, fadeTime, dspTime, loop, mix, stereo: false, randomStart, startPosition, isImportant);
				PlaySample(sampleName + "_1", Mathf.Clamp01(pan + 0.5f), gain, pitch, fadeTime, dspTime, loop, mix, stereo: false, randomStart, startPosition, isImportant);
				return null;
			}
			AudioSample audioSample = PrepSample(sampleName, pan, pitch, fadeTime, mix, loop, randomStart, startPosition, isImportant);
			if (audioSample == null)
			{
				return null;
			}
			return Play(audioSample, dspTime, gain);
		}

		public AudioSample PlayDurational(string sampleName, float gain = 1f, float pan = 0.5f, double dspTime = -1.0, float length = 1f, float attack = 0f, float decay = 0f, float pitch = 1f, bool stereo = false, IGATDynamicMixInfo mix = null, bool randomStart = false, bool isImportant = false)
		{
			if (stereo)
			{
				PlayDurational(sampleName + "_0", gain, Mathf.Clamp01(pan - 0.5f), dspTime, length, attack, decay, pitch, stereo: false, mix, randomStart, isImportant);
				PlayDurational(sampleName + "_1", gain, Mathf.Clamp01(pan + 0.5f), dspTime, length, attack, decay, pitch, stereo: false, mix, randomStart, isImportant);
				return null;
			}
			AudioSample audioSample = PrepSample(sampleName, pan, pitch, attack, mix, loop: true, randomStart, 0f, isImportant);
			if (audioSample == null)
			{
				return null;
			}
			AudioSample result = Play(audioSample, dspTime, gain);
			if (attack + decay > length)
			{
				attack = Maf.Map(attack, 0f, attack + decay, 0f, length);
				decay = Maf.Map(decay, 0f, attack + decay, 0f, length);
			}
			double fadeStartDspTime = ((dspTime < 0.0) ? AudioSystem.Instance.DspTime : dspTime) + (double)length - (double)decay;
			audioSample.GATRealTimeSample.ScheduleFadeOut(fadeStartDspTime, decay);
			return result;
		}

		private AudioSample Play(AudioSample sample, double dspTime, float gain)
		{
			gain = Mathf.Clamp01(gain);
			if (dspTime < 0.0)
			{
				sample.PlayPanned(gain);
			}
			else
			{
				sample.PlayScheduled(dspTime, gain);
			}
			return sample;
		}

		private AudioSample GetSample(string sampleName)
		{
			try
			{
				return AudioSystem.Instance.GetSample(AudioSystem.Instance.Database.GetSampleData(sampleName).GATData);
			}
			catch (KeyNotFoundException)
			{
				AudioSystem.Log.Warn("The sample '{0}' has a name that cannot be found. Is the sample stereo instead of mono?", sampleName);
				return null;
			}
			catch (NullReferenceException)
			{
				AudioSystem.Log.Warn("The sample '{0}' is null.", sampleName);
				return null;
			}
		}
	}
}
