using System;
using UnityEngine;

namespace TH20
{
	public class CameraHeightFadeComponent : MonoBehaviour
	{
		private enum Mode
		{
			Default = 0,
			Fade = 1,
			Hidden = 2
		}

		[DontSave]
		private Level _level;

		[DontSave]
		private Transform _cameraTransform;

		[DontSave]
		private float _fadeSpeed;

		[DontSave]
		private float _minCullThreshold = 100f;

		[DontSave]
		private float _maxCullThreshold = 200f;

		[DontSave]
		private float _currentHeight;

		[DontSave]
		private Mode _mode;

		[DontSave]
		private bool _shouldCull;

		[DontSave]
		private float _alpha;

		public void Initialise(Level level, Transform cameraTransform, float fadeSpeed)
		{
			_level = level;
			_cameraTransform = cameraTransform;
			_fadeSpeed = fadeSpeed;
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraZoom = (Action<float>)Delegate.Combine(cameraEvents.OnCameraZoom, new Action<float>(OnCameraZoom));
			_level.LocalPreferences.Video.OnCharacterDrawDistanceChange += OnCharacterDrawDistanceChanged;
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnCharacterSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffSpawned = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffSpawned, new Action<Staff>(OnCharacterSpawned));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnVisitorSpawned = (Action<Visitor>)Delegate.Combine(characterEvents3.OnVisitorSpawned, new Action<Visitor>(OnCharacterSpawned));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnGhostSpawned = (Action<Character>)Delegate.Combine(characterEvents4.OnGhostSpawned, new Action<Character>(OnCharacterSpawned));
			Shader.SetGlobalFloat("_CharacterCullFadeAmount", 1f);
			RefreshMode(dontFade: true);
		}

		public void Destroy()
		{
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraZoom = (Action<float>)Delegate.Remove(cameraEvents.OnCameraZoom, new Action<float>(OnCameraZoom));
			_level.LocalPreferences.Video.OnCharacterDrawDistanceChange -= OnCharacterDrawDistanceChanged;
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnCharacterSpawned));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffSpawned = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffSpawned, new Action<Staff>(OnCharacterSpawned));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnVisitorSpawned = (Action<Visitor>)Delegate.Remove(characterEvents3.OnVisitorSpawned, new Action<Visitor>(OnCharacterSpawned));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnGhostSpawned = (Action<Character>)Delegate.Remove(characterEvents4.OnGhostSpawned, new Action<Character>(OnCharacterSpawned));
		}

		private void OnCharacterDrawDistanceChanged(float value)
		{
			RefreshMode(dontFade: false);
		}

		private void OnCameraZoom(float value)
		{
			RefreshMode(dontFade: false);
		}

		private void Update()
		{
			if (_shouldCull)
			{
				if (_mode == Mode.Default)
				{
					foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
					{
						allCharacter.Visual.FadingModeEnable = true;
					}
					_mode = Mode.Fade;
					Shader.SetGlobalFloat("_CharacterCullFadeAmount", 1f);
				}
				if (_mode != Mode.Fade)
				{
					return;
				}
				_alpha -= Time.unscaledDeltaTime * _fadeSpeed;
				if (_alpha <= 0f)
				{
					_alpha = 0f;
					foreach (Character allCharacter2 in _level.CharacterManager.AllCharacters)
					{
						allCharacter2.Visual.FadingModeEnable = false;
						allCharacter2.Visual.HiddenModeEnable = true;
					}
					Shader.SetGlobalFloat("_CharacterCullFadeAmount", _alpha);
					_mode = Mode.Hidden;
				}
				else
				{
					Shader.SetGlobalFloat("_CharacterCullFadeAmount", _alpha);
				}
				return;
			}
			if (_mode == Mode.Hidden)
			{
				foreach (Character allCharacter3 in _level.CharacterManager.AllCharacters)
				{
					allCharacter3.Visual.FadingModeEnable = true;
					allCharacter3.Visual.HiddenModeEnable = false;
				}
				_mode = Mode.Fade;
			}
			if (_mode != Mode.Fade)
			{
				return;
			}
			_alpha += Time.unscaledDeltaTime * _fadeSpeed;
			if (_alpha >= 1f)
			{
				_alpha = 1f;
				foreach (Character allCharacter4 in _level.CharacterManager.AllCharacters)
				{
					allCharacter4.Visual.FadingModeEnable = false;
				}
				Shader.SetGlobalFloat("_CharacterCullFadeAmount", _alpha);
				_mode = Mode.Default;
			}
			else
			{
				Shader.SetGlobalFloat("_CharacterCullFadeAmount", _alpha);
			}
		}

		private void RefreshMode(bool dontFade)
		{
			float characterDrawDistance = _level.LocalPreferences.Video.CharacterDrawDistance;
			if (characterDrawDistance >= 1f)
			{
				_shouldCull = false;
			}
			else
			{
				_currentHeight = _cameraTransform.position.y;
				float num = _minCullThreshold + (_maxCullThreshold - _minCullThreshold) * characterDrawDistance;
				_shouldCull = _currentHeight >= num;
			}
			if (!dontFade)
			{
				return;
			}
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				allCharacter.Visual.HiddenModeEnable = _shouldCull;
				allCharacter.Visual.FadingModeEnable = false;
			}
			_alpha = (_shouldCull ? 0f : 1f);
			_mode = (_shouldCull ? Mode.Hidden : Mode.Default);
		}

		private void OnCharacterSpawned(Character character)
		{
			if (_shouldCull)
			{
				character.Visual.HiddenModeEnable = true;
				character.Visual.FadingModeEnable = false;
			}
			else
			{
				character.Visual.HiddenModeEnable = false;
				character.Visual.FadingModeEnable = false;
			}
		}
	}
}
