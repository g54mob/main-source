using System;
using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class PlayBackgroundMusic : MonoBehaviour
	{
		public string MusicId;

		public bool CustomVolume;

		[ShowIf("CustomVolume", true)]
		public float Volume;

		private float _targetvolume;

		private float _currentVolume;

		private float _volumeSetting;

		public IEnumerator Start()
		{
			if (AudioController.GetCategory("Music").isFadeOutComplete || AudioController.GetCategory("Music").isFadingOut)
			{
				AudioController.FadeInCategory("Music", 1f);
			}
			_targetvolume = RuntimeGlobals.Settings.MusicVolume;
			if (CustomVolume)
			{
				_targetvolume = RuntimeGlobals.Settings.MusicVolume * Volume;
			}
			_currentVolume = ((RuntimeGlobals.Settings.MusicVolume <= 0f) ? 0f : AudioController.GetCategoryVolume("Music"));
			_volumeSetting = RuntimeGlobals.Settings.MusicVolume;
			AudioController.SetCategoryVolume("Music", _currentVolume);
			AudioController.SetCategoryVolume("Sound", RuntimeGlobals.Settings.SoundEffectVolume);
			if (!string.IsNullOrEmpty(MusicId))
			{
				while (RuntimeGlobals.IsGameLoading)
				{
					yield return null;
				}
				if (!AudioController.IsPlaying(MusicId))
				{
					AudioController.PlayMusic(MusicId);
				}
			}
		}

		public void Update()
		{
			if (string.IsNullOrEmpty(MusicId))
			{
				return;
			}
			if ((double)Math.Abs(_volumeSetting - RuntimeGlobals.Settings.MusicVolume) > 0.01)
			{
				_volumeSetting = RuntimeGlobals.Settings.MusicVolume;
				_currentVolume = _volumeSetting;
				AudioController.SetCategoryVolume("Music", _currentVolume);
				return;
			}
			_targetvolume = RuntimeGlobals.Settings.MusicVolume;
			if (CustomVolume)
			{
				_targetvolume = RuntimeGlobals.Settings.MusicVolume * Volume;
			}
			_currentVolume = Mathf.Lerp(_currentVolume, _targetvolume, Time.unscaledDeltaTime);
			AudioController.SetCategoryVolume("Music", _currentVolume);
		}
	}
}
