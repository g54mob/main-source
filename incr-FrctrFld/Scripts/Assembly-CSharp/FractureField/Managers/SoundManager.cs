using System;
using System.Collections.Generic;
using FractureField.Sound;
using UnityEngine;

namespace FractureField.Managers
{
	public class SoundManager : MonoBehaviour
	{
		private AudioSource _soundtrackSource;

		private float _soundtrackBaseVolume;

		private AudioSource _soundEffectSource;

		public SoundEffect _soundEffect;

		private Dictionary<SoundEffectType, DateTime> _soundEffectLastPlayed;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void SetupSceneMusic()
		{
		}

		private void SetMusicVolume()
		{
		}

		public void PauseSoundtrack()
		{
		}

		public void UnPauseSoundtrack()
		{
		}

		public void Play(SoundEffectType type)
		{
		}

		public static void PlaySound(SoundEffectType type)
		{
		}
	}
}
