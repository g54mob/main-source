using System.Collections.Generic;
using UnityEngine;

namespace Kengine
{
	public class Audio : MonoBehaviour
	{
		public static Dictionary<string, AudioClip> data = new Dictionary<string, AudioClip>();

		public static AudioSource audioSource;

		public static void SetSource(AudioSource source)
		{
			audioSource = source;
		}

		public static void LoadAudio(string folder)
		{
			Object[] array = Resources.LoadAll(folder, typeof(AudioClip));
			foreach (Object obj in array)
			{
				data.Add(folder + "/" + obj.name, obj as AudioClip);
			}
		}

		public static void PrepareAudio(AudioSource source, string folder)
		{
			SetSource(source);
			LoadAudio(folder);
		}

		public static AudioClip Load(string audio)
		{
			if (audio.Contains(","))
			{
				audio = audio.Replace(" ", "");
				string[] array = audio.Split(","[0]);
				int num = Random.Range(0, array.Length);
				return data[array[num]];
			}
			return data[audio];
		}

		public static void Play(string audio, bool pitch = true, float volume = 1f)
		{
			if (pitch)
			{
				audioSource.pitch = Random.Range(0.8f, 1.2f);
			}
			AudioClip clip = Load(audio);
			audioSource.PlayOneShot(clip, volume);
		}

		public static AudioSource PlayAt(string audio, Vector3 position, bool pitch = true, float volume = 1f, float range = 30f)
		{
			AudioClip audioClip = Load(audio);
			GameObject obj = new GameObject("audioClip");
			obj.transform.position = position;
			AudioSource audioSource = obj.AddComponent(typeof(AudioSource)) as AudioSource;
			audioSource.clip = audioClip;
			if (pitch)
			{
				audioSource.pitch = Random.Range(0.8f, 1.2f);
			}
			audioSource.volume = volume;
			audioSource.minDistance = range;
			audioSource.maxDistance = range;
			audioSource.spatialBlend = 1f;
			audioSource.Play();
			Object.Destroy(obj, audioClip.length);
			return audioSource;
		}
	}
}
