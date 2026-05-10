using System;
using CTS.Core.Utilities;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace CTS
{
	public class LoadingScreen : MenuScreen
	{
		[SerializeField]
		private TMP_Text _tipText;

		[SerializeField]
		private LocalizedStringList _tips;

		[SerializeField]
		private AudioMixer _audioMixer;

		[SerializeField]
		private SoundType[] _soundTypesToMute;

		private float[] _originalMixersValues;

		public static LoadingScreen Instance { get; private set; }

		public static event Action EndLoadingScreen;

		public static event Action StartloadingScreen;

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
			_originalMixersValues = new float[_soundTypesToMute.Length];
		}

		private void OnDestroy()
		{
			Instance = null;
		}

		protected override Tween OnShow()
		{
			_tipText.text = _tips.Strings.GetRandom().GetLocalizedString();
			LoadingScreen.StartloadingScreen?.Invoke();
			for (int i = 0; i < _soundTypesToMute.Length; i++)
			{
				SoundType soundType = _soundTypesToMute[i];
				_originalMixersValues[i] = (_audioMixer.GetFloat(soundType.Key, out var value) ? value : 1f);
				_audioMixer.SetFloat(soundType.Key, -80f);
			}
			return base.OnShow();
		}

		protected override Tween OnHide()
		{
			for (int i = 0; i < _soundTypesToMute.Length; i++)
			{
				SoundType soundType = _soundTypesToMute[i];
				_audioMixer.SetFloat(soundType.Key, _originalMixersValues[i]);
			}
			LoadingScreen.EndLoadingScreen?.Invoke();
			return base.OnHide();
		}
	}
}
