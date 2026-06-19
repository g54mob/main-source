#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using TH20.Video;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace TH20
{
	public class FullScreenVideoMenu : MonoBehaviour
	{
		public class VideoContext
		{
			public VideoClip Clip;

			public SubtitlesDefinition Subtitles;

			public float Volume;

			public bool FadeIn;

			public bool FadeOut;
		}

		[SerializeField]
		private VideoPlayer _videoPlayer;

		[SerializeField]
		private AudioSource _audioSource;

		[SerializeField]
		private Image _backing;

		[SerializeField]
		private RawImage _videoRawImage;

		[SerializeField]
		private TMP_Text _subtitleText;

		[SerializeField]
		private TMP_Text _subtitleTextShadow;

		private const float CFadeInTime = 2f;

		private const float CFadeOutTime = 2f;

		private readonly Queue<SubtitlesDefinition.SubtitleEvent> _subtitlesQueue = new Queue<SubtitlesDefinition.SubtitleEvent>();

		private Coroutine _coroutine;

		private MetagameMapScene _metagameMapScene;

		private Preferences _preferences;

		private RenderTexture _renderTexture;

		public bool IsPlaying => _coroutine != null;

		public void Initialise(MetagameMapScene mapScene, Preferences userPreferences)
		{
			_metagameMapScene = mapScene;
			_preferences = userPreferences;
		}

		public void PlayVideo(VideoContext next, Action onCompleted, Action onError)
		{
			if (_coroutine != null)
			{
				Logging.Error(LogChannels.GUI, "RB: Trying to play video, but one is already playing!");
				return;
			}
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
			_coroutine = StartCoroutine(VideoCoroutine(next, onCompleted, onError));
		}

		public void Skip()
		{
			if (_coroutine != null)
			{
				StopAllCoroutines();
				_coroutine = null;
				_videoPlayer.Stop();
				GameObjectUtils.SetActive(_backing.gameObject, isActive: false);
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
			}
		}

		private IEnumerator VideoCoroutine(VideoContext video, Action onCompleted, Action onError)
		{
			if (video.Clip == null)
			{
				Logging.Error(LogChannels.GUI, "RB: Trying to play video, but clip is NULL");
				onError?.InvokeSafe();
				_coroutine = null;
				_subtitleText.text = string.Empty;
				_subtitleTextShadow.text = string.Empty;
				GameObjectUtils.SetActive(_backing.gameObject, isActive: false);
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
				yield break;
			}
			if (_renderTexture != null)
			{
				if (_renderTexture.IsCreated())
				{
					_renderTexture.Release();
				}
				_renderTexture = null;
			}
			_renderTexture = new RenderTexture(1920, 1080, 0, RenderTextureFormat.ARGB32);
			_renderTexture.Create();
			_videoPlayer.renderMode = VideoRenderMode.RenderTexture;
			_videoPlayer.targetTexture = _renderTexture;
			_videoRawImage.texture = _renderTexture;
			_subtitlesQueue.Clear();
			if (video.Subtitles != null)
			{
				video.Subtitles.SubtitleEvents.Sort();
				foreach (SubtitlesDefinition.SubtitleEvent subtitleEvent in video.Subtitles.SubtitleEvents)
				{
					_subtitlesQueue.Enqueue(subtitleEvent);
				}
			}
			_audioSource.volume = video.Volume;
			_subtitleText.text = string.Empty;
			_subtitleTextShadow.text = string.Empty;
			_videoPlayer.clip = video.Clip;
			ushort languageTrackIndex = GetLanguageTrackIndex();
			SetSoloAudioTrack(languageTrackIndex);
			GameObjectUtils.SetActive(_backing.gameObject, isActive: true);
			if (video.FadeIn)
			{
				_backing.color = Color.clear;
				float elapsedTime = 0f;
				while (elapsedTime < 2f)
				{
					elapsedTime += Time.unscaledDeltaTime;
					float p = elapsedTime / 2f;
					_backing.color = new Color(0f, 0f, 0f, EasingsUtils.CubicEaseOut(p));
					yield return null;
				}
			}
			_backing.color = Color.black;
			GameObjectUtils.SetActive(_backing.gameObject, isActive: false);
			GameObjectUtils.SetActive(_metagameMapScene.gameObject, isActive: false);
			_videoPlayer.Play();
			_subtitleText.fontMaterial = _subtitleText.font.material;
			_subtitleTextShadow.fontMaterial = _subtitleTextShadow.font.material;
			bool playbackStarted = false;
			while (!playbackStarted || _videoPlayer.isPlaying)
			{
				if (_videoPlayer.isPlaying)
				{
					playbackStarted = true;
				}
				ProcessSubtitles();
				yield return null;
			}
			_subtitleText.text = string.Empty;
			_subtitleTextShadow.text = string.Empty;
			GameObjectUtils.SetActive(_metagameMapScene.gameObject, isActive: true);
			GameObjectUtils.SetActive(_backing.gameObject, isActive: true);
			if (video.FadeOut)
			{
				float elapsedTime = 0f;
				while (elapsedTime < 2f)
				{
					elapsedTime += Time.unscaledDeltaTime;
					float num = elapsedTime / 2f;
					_backing.color = new Color(1f, 1f, 1f, EasingsUtils.CubicEaseOut(1f - num));
					yield return null;
				}
			}
			_backing.color = Color.clear;
			GameObjectUtils.SetActive(_backing.gameObject, isActive: false);
			_videoRawImage.texture = null;
			if (_renderTexture != null)
			{
				_renderTexture.Release();
				_renderTexture = null;
			}
			_coroutine = null;
			onCompleted?.InvokeSafe();
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}

		private void ProcessSubtitles()
		{
			if (_subtitlesQueue.Count <= 0)
			{
				return;
			}
			SubtitlesDefinition.SubtitleEvent subtitleEvent = _subtitlesQueue.Peek();
			if (subtitleEvent != null && (double)subtitleEvent.Time <= _videoPlayer.time)
			{
				if (subtitleEvent.Text.Term == null)
				{
					_subtitleText.text = string.Empty;
					_subtitleTextShadow.text = string.Empty;
				}
				else
				{
					_subtitleText.text = subtitleEvent.Text.Translation;
					_subtitleTextShadow.text = subtitleEvent.Text.Translation;
				}
				_subtitleText.color = subtitleEvent.Tint;
				_subtitlesQueue.Dequeue();
			}
		}

		private void SetSoloAudioTrack(ushort index)
		{
			if (index >= _videoPlayer.controlledAudioTrackCount)
			{
				index = 0;
			}
			for (ushort num = 0; num < _videoPlayer.controlledAudioTrackCount; num++)
			{
				if (num == index)
				{
					_videoPlayer.EnableAudioTrack(num, enabled: true);
					_videoPlayer.SetTargetAudioSource(num, _audioSource);
				}
				else
				{
					_videoPlayer.EnableAudioTrack(num, enabled: false);
					_videoPlayer.SetTargetAudioSource(num, null);
				}
			}
		}

		private ushort GetLanguageTrackIndex()
		{
			return _preferences.Language.SelectedAudioLanguage switch
			{
				Preferences.LanguagePreferences.AudioLanguage.German => 1, 
				Preferences.LanguagePreferences.AudioLanguage.Mandarin => 2, 
				_ => 0, 
			};
		}
	}
}
