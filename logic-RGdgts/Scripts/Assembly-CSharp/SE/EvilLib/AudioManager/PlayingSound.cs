using System;
using System.Collections.Generic;
using UnityEngine;

namespace SE.EvilLib.AudioManager
{
	[Serializable]
	public class PlayingSound
	{
		[HideInInspector]
		public string label;

		public AudioCategory category;

		public AudioSource source;

		public float volumeMax;

		public string soundId;

		public string group;

		public List<AudioClip> clipList;

		public bool isPaused;

		private bool hasParent;

		private Transform parent;

		private bool randomClipOnLoop;

		private float timePlaying;

		private float timeTotal;

		private List<int> randomClipPlayed;

		public bool isFadingToDeath;

		public void Update()
		{
		}

		public void Destroy()
		{
		}

		public PlayingSound Play()
		{
			return null;
		}

		public void Stop(float fadeTime = 0f, Action onDone = null)
		{
		}

		public PlayingSound Pause(bool value, float time = 0f)
		{
			return null;
		}

		public PlayingSound SetVolumeLevel(float normValue, float time = 0f, Action onDone = null)
		{
			return null;
		}

		public PlayingSound FadeVolume(float normStart = -1f, float normEnd = 1f, float time = 1f, Action onDone = null)
		{
			return null;
		}

		public PlayingSound SetPriority(int value)
		{
			return null;
		}

		public PlayingSound SetSoundId(string id)
		{
			return null;
		}

		public PlayingSound SetGroup(string group)
		{
			return null;
		}

		public void SetParent(Transform parent)
		{
		}

		public void SetNextRandomClip()
		{
		}
	}
}
