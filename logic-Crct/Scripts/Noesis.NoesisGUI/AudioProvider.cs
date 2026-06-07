using System.Collections.Generic;
using UnityEngine;

public class AudioProvider
{
	public struct Value
	{
		public int refs;

		public AudioClip audio;
	}

	public static AudioProvider instance;

	private Dictionary<string, Value> _audios;

	private AudioProvider()
	{
	}

	public void Register(string uri, AudioClip audio)
	{
	}

	public void Unregister(string uri)
	{
	}

	public void PlayAudio(string uri, float volume)
	{
	}
}
