using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using ModApi;
using ModApi.Audio;
using ModApi.Common;
using ModApi.Craft;
using ModApi.Expressions;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	public class MusicPlayer : MonoBehaviour, IMusicPlayer
	{
		private const string MusicPath = "Audio/Music/";

		private AudioExpressionContext _audioExpressionContext;

		private Func<double> _compiledIntensityFunction;

		private string _expressionTrackedString;

		[SerializeField]
		private float _fadeInTime = 10f;

		[SerializeField]
		private float _fadeOutTime = 10f;

		private bool _fading;

		private bool _haltPlayback;

		private AudioSource _mainLayer;

		private string _mainLayerClipName;

		[SerializeField]
		private List<MusicTrack> _musicTracks;

		private float _musicVolume;

		private AudioSource _secondaryLayer;

		public static MusicPlayer Instance { get; private set; }

		public float Intensity { get; set; }

		public bool IsPlaying => _mainLayer?.isPlaying ?? false;

		public List<MusicTrack> MusicTracks => _musicTracks;

		public void CalculateMusicIntensity(ICraftScript craftScript)
		{
			if (!IsPlaying)
			{
				return;
			}
			string musicIntensityExpression = craftScript.FlightData.Orbit.Parent.PlanetData.MusicIntensityExpression;
			float num;
			if (!string.IsNullOrEmpty(musicIntensityExpression))
			{
				if (_audioExpressionContext == null)
				{
					GenerateContext();
				}
				_audioExpressionContext.CraftNode = craftScript.CraftNode;
				if (_compiledIntensityFunction == null || _expressionTrackedString != musicIntensityExpression)
				{
					_expressionTrackedString = musicIntensityExpression;
					CompileIntensityExpressions(musicIntensityExpression);
				}
				num = Mathf.Clamp01((float)_compiledIntensityFunction());
			}
			else
			{
				float num2 = (float)craftScript.FlightData.AltitudeAboveGroundLevel;
				if (num2 < 500f)
				{
					num2 = 500f;
				}
				num = (float)craftScript.FlightData.SurfaceVelocityMagnitude * 3f / num2;
				num = Mathf.Clamp01(Mathf.Max(num, craftScript.ReEntryIntensity * 3f));
				if (num < 0.5f)
				{
					num = 0f;
				}
			}
			Intensity = num;
		}

		[ContextMenu("Toggle \"Intense\" Layer")]
		public void ToggleIntensity()
		{
			StartCoroutine(ToggleIntensityNextFrame());
		}

		public IEnumerator ToggleIntensityNextFrame()
		{
			yield return new WaitForEndOfFrame();
			Intensity = ((!(Intensity > 0f)) ? 1 : 0);
		}

		private void CompileIntensityExpressions(string expression)
		{
			_compiledIntensityFunction = Parser.Process<double>(expression, GenerateContext());
		}

		private IEnumerator FadeTo(MusicTrack musicTrack, float outTime = 5f, float inTime = 5f)
		{
			if (_fading)
			{
				Debug.LogWarning("Do not call FadeMainTo while this._fading is true");
				yield break;
			}
			_fading = true;
			IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
			ResourceRequestWrapper<AudioClip> requestPrimary = (string.IsNullOrWhiteSpace(musicTrack.PrimaryAudioClipName) ? null : resourceLoader.LoadAsync<AudioClip>("Audio/Music/" + musicTrack.PrimaryAudioClipName));
			ResourceRequestWrapper<AudioClip> requestSecondary = ((string.IsNullOrWhiteSpace(musicTrack.SecondaryAudioClipName) || Game.Instance.Settings.Game.Audio.MusicQuality.Value == ModApi.Settings.AudioSettings.MusicLevel.Low) ? null : resourceLoader.LoadAsync<AudioClip>("Audio/Music/" + musicTrack.SecondaryAudioClipName));
			yield return new WaitForEndOfFrame();
			while (_mainLayer.volume > 0f && _fading)
			{
				_mainLayer.volume = Mathf.Clamp01(_mainLayer.volume - Time.unscaledDeltaTime / outTime);
				_secondaryLayer.volume = Mathf.Clamp01(_mainLayer.volume * Intensity);
				yield return new WaitForEndOfFrame();
			}
			_mainLayer.Stop();
			_secondaryLayer.Stop();
			AudioClip clip = _mainLayer.clip;
			AudioClip clip2 = _secondaryLayer.clip;
			try
			{
				if (clip != null)
				{
					Resources.UnloadAsset(clip);
				}
				if (clip2 != null)
				{
					Resources.UnloadAsset(clip2);
				}
			}
			catch (Exception message)
			{
				Debug.LogWarning(message);
			}
			yield return requestPrimary?.Request;
			yield return requestSecondary?.Request;
			SetMainLayerClip(requestPrimary?.Asset);
			SetSecondaryClip(requestSecondary?.Asset);
			while (_mainLayer.clip != null && _mainLayer.clip.loadState == AudioDataLoadState.Loading)
			{
				yield return null;
			}
			while (_secondaryLayer.clip != null && _secondaryLayer.clip.loadState == AudioDataLoadState.Loading)
			{
				yield return null;
			}
			_mainLayer.Play();
			_secondaryLayer.Play();
			while (_mainLayer.volume < 1f && _fading)
			{
				_mainLayer.volume = Mathf.Clamp01(_mainLayer.volume + Time.unscaledDeltaTime / inTime);
				_secondaryLayer.volume = Mathf.Clamp01(_mainLayer.volume * Intensity);
				yield return new WaitForEndOfFrame();
			}
			if (_fading)
			{
				_fading = false;
			}
		}

		private Context GenerateContext()
		{
			if (_audioExpressionContext == null)
			{
				_audioExpressionContext = new AudioExpressionContext();
			}
			return new Context(true, (typeof(AudioExpressionContext), _audioExpressionContext, null, true));
		}

		private bool IsPlayingSongForPlanet(IPlanetData planet)
		{
			if (_mainLayerClipName.Contains(planet.Name))
			{
				return true;
			}
			string[] musicKeywords = planet.MusicKeywords;
			foreach (string value in musicKeywords)
			{
				if (_mainLayerClipName.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		private void MusicVolume_Changed(object sender, SettingChangedEventArgs<float> e)
		{
			_musicVolume = e.Setting.Value;
			if (!(_musicVolume <= 0f))
			{
				return;
			}
			_mainLayer.Stop();
			_secondaryLayer.Stop();
			if (_mainLayer.clip != null)
			{
				AudioClip clip = _mainLayer.clip;
				try
				{
					if (clip != null)
					{
						Resources.UnloadAsset(clip);
					}
					SetMainLayerClip(null);
				}
				catch (Exception message)
				{
					Debug.LogWarning(message);
				}
			}
			if (!(_secondaryLayer.clip != null))
			{
				return;
			}
			AudioClip clip2 = _secondaryLayer.clip;
			try
			{
				if (clip2 != null)
				{
					Resources.UnloadAsset(clip2);
				}
				SetSecondaryClip(null);
			}
			catch (Exception message2)
			{
				Debug.LogWarning(message2);
			}
		}

		private void OnDestroy()
		{
			Game.Instance.Settings.Game.Audio.MusicVolume.Changed -= MusicVolume_Changed;
		}

		private MusicTrack PickRandomTrackForPlanet(IPlanetData planet)
		{
			List<MusicTrack> list = new List<MusicTrack>();
			string[] musicKeywords = planet.MusicKeywords;
			foreach (string keyword in musicKeywords)
			{
				list.AddRange(MusicTracks.Where((MusicTrack x) => x.PrimaryAudioClipName.Contains(keyword)).ToList());
			}
			if (list.Count == 0)
			{
				return PickRandomTrackForPlanetName(planet.Name);
			}
			if (list.Count != 0)
			{
				return list[UnityEngine.Random.Range(0, list.Count)];
			}
			return null;
		}

		private MusicTrack PickRandomTrackForPlanetName(string planetName)
		{
			List<MusicTrack> list = MusicTracks.Where((MusicTrack x) => x.PrimaryAudioClipName.Contains(planetName)).ToList();
			if (list.Count != 0)
			{
				return list[UnityEngine.Random.Range(0, list.Count)];
			}
			return null;
		}

		private void SetMainLayerClip(AudioClip clip)
		{
			_mainLayer.clip = clip;
			_mainLayerClipName = clip?.name;
		}

		private void SetSecondaryClip(AudioClip clip)
		{
			_secondaryLayer.clip = clip;
		}

		private void Start()
		{
			Instance = this;
			AudioSource[] components = GetComponents<AudioSource>();
			_mainLayer = components[0];
			_secondaryLayer = components[1];
			_musicVolume = Game.Instance.Settings.Game.Audio.MusicVolume.Value;
			if (_musicVolume > 0f)
			{
				SetMainLayerClip(Resources.Load<AudioClip>("Audio/Music/Menu Theme"));
				_mainLayer.Play();
			}
			Game.Instance.Settings.Game.Audio.MusicVolume.Changed += MusicVolume_Changed;
		}

		private void ToggleMusic()
		{
			_haltPlayback = !_haltPlayback;
			if (_haltPlayback)
			{
				_mainLayer.Pause();
				_secondaryLayer.Pause();
			}
			else
			{
				_mainLayer.UnPause();
				_secondaryLayer.UnPause();
			}
		}

		private void Update()
		{
			if (Game.Instance.Inputs.ToggleMusic.GetButtonDownIfEnabled() && !Game.Instance.UserInterface.IgnoreKeyboardInputs)
			{
				ToggleMusic();
			}
			if (!_fading && _musicVolume > 0f && !_haltPlayback)
			{
				bool inFlightScene = Game.InFlightScene;
				bool inDesignerScene = Game.InDesignerScene;
				IPlanetData planetData = ((!inFlightScene) ? null : FlightSceneScript.Instance?.CraftNode?.Parent.PlanetData);
				if ((inDesignerScene || inFlightScene) && (_mainLayer.clip == null || _mainLayerClipName == "Menu Theme" || !_mainLayer.isPlaying || _mainLayer.time + _fadeOutTime >= _mainLayer.clip.length))
				{
					MusicTrack musicTrack = null;
					if (planetData != null)
					{
						musicTrack = PickRandomTrackForPlanet(planetData);
					}
					if (musicTrack == null)
					{
						musicTrack = PickRandomTrackForPlanetName("Droo");
					}
					if (musicTrack == null)
					{
						int num = UnityEngine.Random.Range(0, MusicTracks.Count);
						if (MusicTracks[num].PrimaryAudioClipName == _mainLayerClipName)
						{
							num = ((num < MusicTracks.Count - 1) ? (num + 1) : 0);
						}
						musicTrack = MusicTracks[num];
					}
					StartCoroutine(FadeTo(musicTrack, _mainLayer.isPlaying ? _fadeOutTime : 0.001f, _fadeInTime));
				}
				else if (inFlightScene && planetData != null && !IsPlayingSongForPlanet(planetData))
				{
					MusicTrack musicTrack2 = PickRandomTrackForPlanet(planetData);
					if (musicTrack2 != null)
					{
						StartCoroutine(FadeTo(musicTrack2, _mainLayer.isPlaying ? _fadeOutTime : 0.001f, _fadeInTime));
					}
				}
				else if (!inDesignerScene && !inFlightScene && (!_mainLayer.isPlaying || _mainLayer.time + _fadeOutTime >= _mainLayer.clip.length))
				{
					MusicTrack musicTrack3 = PickRandomTrackForPlanetName("Droo");
					if (musicTrack3 == null)
					{
						int num2 = UnityEngine.Random.Range(0, MusicTracks.Count);
						if (MusicTracks[num2].PrimaryAudioClipName == _mainLayerClipName)
						{
							num2 = ((num2 < MusicTracks.Count - 1) ? (num2 + 1) : 0);
						}
						musicTrack3 = MusicTracks[num2];
					}
					StartCoroutine(FadeTo(musicTrack3, _mainLayer.isPlaying ? _fadeOutTime : 0.001f, _fadeInTime));
				}
			}
			_secondaryLayer.volume = Mathf.MoveTowards(_secondaryLayer.volume, Intensity * _mainLayer.volume, Time.unscaledDeltaTime / 3f);
		}
	}
}
