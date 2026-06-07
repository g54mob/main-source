using System;
using System.Collections.Generic;
using Client;
using Factory;
using Motorways.Audio;
using Motorways.Themes;
using Motorways.Views;
using Screens;
using Unity.Profiling;
using UnityEngine;

namespace Motorways
{
	public class MotorwaysThemeDatabase : IThemeDatabase
	{
		public static int MAX_THEME_COLOR_GROUPS = 6;

		private List<MotorwaysClient> _viewClients = new List<MotorwaysClient>();

		[Dependency]
		private ActivePlayer _activePlayer;

		[Dependency]
		private ScreenStack _screenStack;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private VisualConstantsData _visualConstants;

		public static Diagnostics.Log.Channel Log = new Diagnostics.Log.Channel("Theme Database");

		private Theme _targetTheme;

		private Theme _oldTheme;

		public MotorwaysThemeDatabaseBindings bindings;

		public PerGroupMaterialBindings perGroupMaterials;

		public ThemeMaterialCollection materialCollection;

		private MotorwaysThemePreference _themePreference;

		private MotorwaysThemePreference _dayThemePreference;

		private TransitionStyle _transitionStyle;

		private float _transitionDuration = 1f;

		private float _themeTransitionTime = 0.3f;

		private float _transitionDelay;

		private const float OverridesTransitionDelay = 0.1f;

		private float _transitionProgress;

		private bool _dirty;

		private bool _forceBlend;

		private bool _applyThemeOverrides;

		private bool _isBlendingOverrides;

		private MapDefinition _currentMapDefinition;

		private MaterialPropertyBlock _materialPropertyBlock;

		private static readonly ProfilerMarker Profiler_BlendBetweenThemes = new ProfilerMarker(ProfilerCategory.Scripts, "MotorwaysThemeDatabase.BlendBetweenThemes()");

		public Theme TargetTheme => _targetTheme;

		public MotorwaysThemePreference ThemePreference => _themePreference;

		public float TransitionDuration => _transitionDuration;

		private float LerpPercentage
		{
			get
			{
				if (_transitionDuration <= float.Epsilon)
				{
					return 1f;
				}
				return _transitionProgress / _transitionDuration;
			}
		}

		public bool IsDirty => _dirty;

		public bool ApplyThemeOverrides => _applyThemeOverrides;

		public bool IsBlendingOverrides => _isBlendingOverrides;

		public MaterialPropertyBlock MaterialPropertyBlock => _materialPropertyBlock;

		public Theme ActiveColorblindTheme
		{
			get
			{
				if (!_activePlayer.IsNightModeEnabled)
				{
					return bindings.colorblindThemeColorful;
				}
				return bindings.colorblindThemeDark;
			}
		}

		public ColorGroup[] ActiveColorblindColorGroups
		{
			get
			{
				if (!_activePlayer.IsNightModeEnabled)
				{
					return _visualConstants.AvailableColorfulColorBlindColorGroups;
				}
				return _visualConstants.AvailableDarkColorBlindColorGroups;
			}
		}

		public bool IsInNightMode
		{
			get
			{
				if (_themePreference != MotorwaysThemePreference.Dark)
				{
					return _themePreference == MotorwaysThemePreference.DarkColorblind;
				}
				return true;
			}
		}

		public bool IsInColorblindMode
		{
			get
			{
				if (_themePreference != MotorwaysThemePreference.Colorblind)
				{
					return _themePreference == MotorwaysThemePreference.DarkColorblind;
				}
				return true;
			}
		}

		public MotorwaysThemeDatabase(MotorwaysThemeDatabaseBindings themeBindings)
		{
			bindings = themeBindings;
		}

		public void Start()
		{
			_themePreference = MotorwaysThemePreference.Colorful;
			_activePlayer.DataChanged += OnPlayerDataChanged;
			MotorwaysThemePreference themePreference = _themePreference;
			if (themePreference == MotorwaysThemePreference.Dark || themePreference == MotorwaysThemePreference.DarkColorblind)
			{
				Get.State |= StateType.ModeNight;
			}
			else
			{
				Get.State &= ~StateType.ModeNight;
			}
			Log.Info("Theme database initialised: {0}", bindings.name);
			_materialPropertyBlock = new MaterialPropertyBlock();
			materialCollection = bindings.materialCollection;
			materialCollection.ConstructPropertyBlocks();
			Log.Info("Instantiated material collection");
			perGroupMaterials = new PerGroupMaterialBindings(bindings.perGroupMaterials);
			perGroupMaterials.SetMaterialPropertyBlock(_materialPropertyBlock);
		}

		public void Tick(float deltaTime)
		{
			if (_dirty)
			{
				if (_oldTheme == null)
				{
					_transitionProgress = _transitionDuration;
					_oldTheme = _targetTheme;
				}
				if (BlendBetweenThemes(_oldTheme, _targetTheme, ((_transitionStyle == TransitionStyle.Snap || !_player.HasActivePlayer || _player.IsSkipTransitionsEnabled) && !_forceBlend) ? _transitionDuration : deltaTime))
				{
					_dirty = false;
					_forceBlend = false;
					_oldTheme = _targetTheme;
					_transitionStyle = TransitionStyle.Tween;
				}
			}
		}

		public void SnapCurrentTransition()
		{
			if (_dirty)
			{
				_transitionStyle = TransitionStyle.Snap;
			}
		}

		private bool BlendBetweenThemes(Theme oldTheme, Theme targetTheme, float deltaTime)
		{
			bool result = false;
			if (_transitionDelay > Mathf.Epsilon)
			{
				_transitionDelay -= deltaTime;
				return false;
			}
			_transitionProgress += deltaTime;
			if (_transitionProgress >= _transitionDuration)
			{
				_transitionProgress = _transitionDuration;
				_isBlendingOverrides = false;
				_transitionDelay = 0f;
				result = true;
			}
			float lerpPercentage = LerpPercentage;
			materialCollection.ApplyTheme(oldTheme, targetTheme, lerpPercentage, _applyThemeOverrides, _isBlendingOverrides);
			perGroupMaterials.ApplyTheme(oldTheme, targetTheme, lerpPercentage);
			foreach (MotorwaysClient viewClient in _viewClients)
			{
				((IClient)viewClient).ApplyBlendedTheme((ITheme)oldTheme, (ITheme)targetTheme, lerpPercentage);
			}
			if (oldTheme != targetTheme)
			{
				if (_screenStack != null)
				{
					foreach (IScreen activeScreen2 in _screenStack.GetActiveScreens())
					{
						if (activeScreen2 != null && activeScreen2 is BaseScalingScreen baseScalingScreen)
						{
							baseScalingScreen.ApplyBlendedTheme(oldTheme, targetTheme, lerpPercentage);
						}
					}
				}
			}
			else if (_isBlendingOverrides)
			{
				GameContainerScreen activeScreen = _screenStack.GetActiveScreen<GameContainerScreen>();
				if (activeScreen != null)
				{
					activeScreen.ApplyBlendedTheme(oldTheme, targetTheme, lerpPercentage);
				}
			}
			if (_gameCamera.customBlur != null)
			{
				float levelsRange = Mathf.Lerp(oldTheme.screenBackgroundBlur.blurLevelsRange, targetTheme.screenBackgroundBlur.blurLevelsRange, lerpPercentage);
				float levelsOffset = Mathf.Lerp(oldTheme.screenBackgroundBlur.blurLevelsOffset, targetTheme.screenBackgroundBlur.blurLevelsOffset, lerpPercentage);
				_gameCamera.customBlur.LevelsRange = levelsRange;
				_gameCamera.customBlur.LevelsOffset = levelsOffset;
			}
			return result;
		}

		public void SetNightMode(bool nightModeOn, bool forceBlend = false)
		{
			if (IsInNightMode != nightModeOn)
			{
				if (IsInColorblindMode)
				{
					SetThemePreference(nightModeOn ? MotorwaysThemePreference.DarkColorblind : MotorwaysThemePreference.Colorblind, saveThemePreference: true, playAudio: true, forceBlend);
				}
				else if (nightModeOn)
				{
					_dayThemePreference = _themePreference;
					SetThemePreference(MotorwaysThemePreference.Dark, saveThemePreference: true, playAudio: true, forceBlend);
				}
				else
				{
					SetThemePreference(_dayThemePreference, saveThemePreference: true, playAudio: true, forceBlend);
				}
			}
		}

		public void SetColorblindMode(bool colorblindOn, bool forceBlend = false)
		{
			if (IsInColorblindMode != colorblindOn)
			{
				if (colorblindOn)
				{
					SetThemePreference(IsInNightMode ? MotorwaysThemePreference.DarkColorblind : MotorwaysThemePreference.Colorblind, saveThemePreference: true, playAudio: true, forceBlend);
					return;
				}
				_dayThemePreference = MotorwaysThemePreference.Colorful;
				SetThemePreference(IsInNightMode ? MotorwaysThemePreference.Dark : MotorwaysThemePreference.Colorful, saveThemePreference: true, playAudio: true, forceBlend);
			}
		}

		public void SetThemePreference(MotorwaysThemePreference newPreference, bool saveThemePreference = true, bool playAudio = true, bool forceBlend = false)
		{
			_transitionDuration = _themeTransitionTime;
			if (newPreference != _themePreference)
			{
				if (_targetTheme != null)
				{
					_dirty = true;
				}
				_forceBlend = forceBlend;
			}
			_themePreference = newPreference;
			if (_currentMapDefinition != null && _dirty)
			{
				UpdateThemeFromCurrentDefinition();
			}
			if (saveThemePreference)
			{
				SaveThemePreference();
			}
			MotorwaysThemePreference themePreference = _themePreference;
			if (themePreference == MotorwaysThemePreference.Dark || themePreference == MotorwaysThemePreference.DarkColorblind)
			{
				Get.State |= StateType.ModeNight;
			}
			else
			{
				Get.State &= ~StateType.ModeNight;
			}
			if (playAudio)
			{
				AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateEvent(AudioSystem.Instance.DspTime, AudioEventType.NightMode));
			}
		}

		private void SaveThemePreference()
		{
			_activePlayer.DataChanged -= OnPlayerDataChanged;
			if (_themePreference == MotorwaysThemePreference.Colorful)
			{
				_activePlayer.ColorfulOption = MotorwaysThemeColorfulOptions.Colorful.ToString();
			}
			else if (_themePreference == MotorwaysThemePreference.Maps)
			{
				_activePlayer.ColorfulOption = MotorwaysThemeColorfulOptions.Maps.ToString();
			}
			bool isNightModeEnabled = _themePreference == MotorwaysThemePreference.Dark || _themePreference == MotorwaysThemePreference.DarkColorblind;
			bool isColorblindModeEnabled = _themePreference == MotorwaysThemePreference.Colorblind || _themePreference == MotorwaysThemePreference.DarkColorblind;
			_activePlayer.IsColorblindModeEnabled = isColorblindModeEnabled;
			_activePlayer.IsNightModeEnabled = isNightModeEnabled;
			_activePlayer.DataChanged += OnPlayerDataChanged;
		}

		private MotorwaysThemePreference GetThemePreferenceFromSave()
		{
			if (_activePlayer.IsColorblindModeEnabled)
			{
				if (_activePlayer.IsNightModeEnabled)
				{
					return MotorwaysThemePreference.DarkColorblind;
				}
				return MotorwaysThemePreference.Colorblind;
			}
			if (_activePlayer.IsNightModeEnabled)
			{
				return MotorwaysThemePreference.Dark;
			}
			if (Enum.TryParse<MotorwaysThemeColorfulOptions>(_activePlayer.ColorfulOption, out var result))
			{
				switch (result)
				{
				case MotorwaysThemeColorfulOptions.Colorful:
					return MotorwaysThemePreference.Colorful;
				case MotorwaysThemeColorfulOptions.Maps:
					return MotorwaysThemePreference.Maps;
				}
			}
			return MotorwaysThemePreference.Colorful;
		}

		public void OnPlayerDataChanged()
		{
			MotorwaysThemePreference themePreference = ThemePreference;
			MotorwaysThemePreference themePreferenceFromSave = GetThemePreferenceFromSave();
			if (themePreference != themePreferenceFromSave)
			{
				SetThemePreference(themePreferenceFromSave, saveThemePreference: false, playAudio: false);
			}
		}

		private void ApplyTheme(Theme newTheme, bool forceApply = false)
		{
			Log.Info("Applying theme!");
			if (!Diagnostics.Verify(newTheme != null, "Trying to set a theme which is null! Current preference: {0}", _themePreference))
			{
				return;
			}
			UpdateColorblindThemesFromActiveUserProfile();
			if (newTheme != _targetTheme || forceApply)
			{
				Log.Info("Applying theme {0}", newTheme.name);
				_oldTheme = _targetTheme;
				_targetTheme = newTheme;
				_transitionProgress = 0f;
				_dirty = true;
				if (_oldTheme == null)
				{
					_oldTheme = _targetTheme;
					_transitionProgress = _transitionDuration;
				}
			}
		}

		public void SetDrawMode(RoadDrawMode currentRoadDrawMode)
		{
			bool applyThemeOverrides = _applyThemeOverrides;
			_applyThemeOverrides = currentRoadDrawMode == RoadDrawMode.Remove;
			if (applyThemeOverrides != _applyThemeOverrides)
			{
				if (_isBlendingOverrides)
				{
					_transitionProgress = Mathf.Clamp(_transitionDuration - _transitionProgress, 0f, _transitionDuration);
				}
				else
				{
					_transitionProgress = 0f;
					_transitionDelay = 0.1f;
				}
				_transitionDuration = _themeTransitionTime;
				_isBlendingOverrides = true;
				_forceBlend = true;
				_dirty = true;
			}
		}

		public void UpdateThemeFromCurrentDefinition(bool forceUpdate = false)
		{
			if (Diagnostics.Verify(_currentMapDefinition != null, "No currentMapDefinition set in the ThemeDatabase. Call SetCurrentMapDefinition()"))
			{
				Theme theme = _currentMapDefinition.themes[(int)_themePreference];
				if (forceUpdate)
				{
					theme.Initialize();
				}
				if (Diagnostics.Verify(theme != null, "{0} doesn't have a theme for {1}!", _currentMapDefinition, _themePreference))
				{
					ApplyTheme(theme, forceUpdate);
				}
			}
		}

		public void SetCurrentMapDefinition(MapDefinition newMapDefinition, float blendDuration)
		{
			_transitionDuration = blendDuration;
			Log.Info("Setting new map definition: {0}", newMapDefinition.cityName);
			_currentMapDefinition = newMapDefinition;
			UpdateThemeFromCurrentDefinition();
		}

		public Color GetGlobalColor(ThemedMaterialType target)
		{
			if (_dirty)
			{
				return materialCollection.GetBlendedColor(target, _oldTheme, _targetTheme, LerpPercentage, _applyThemeOverrides, _isBlendingOverrides);
			}
			return _targetTheme.GetColor(target);
		}

		public void RegisterGameObjectToThemeByGroupIndex(GameObject gameObject, int groupIndex)
		{
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer renderer in componentsInChildren)
			{
				int perGroupThemeTargetForMaterial = bindings.GetPerGroupThemeTargetForMaterial(renderer.sharedMaterial);
				if (perGroupThemeTargetForMaterial >= 0)
				{
					perGroupMaterials.BindRendererToThemeTarget(renderer, groupIndex, (ThemeComponentGroupTarget)perGroupThemeTargetForMaterial);
				}
			}
		}

		public void RegisterGameObjectToThemeByGroupIndex(GameObject gameObject, int groupIndex, ThemeComponentGroupTarget groupTarget)
		{
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer renderer in componentsInChildren)
			{
				perGroupMaterials.BindRendererToThemeTarget(renderer, groupIndex, groupTarget);
			}
		}

		public bool UnregisterGameObjectFromThemeByGroupIndex(GameObject gameObject, int groupIndex)
		{
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			bool flag = true;
			Renderer[] array = componentsInChildren;
			foreach (Renderer renderer in array)
			{
				flag = perGroupMaterials.UnbindRendererFromThemeTarget(renderer, groupIndex) && flag;
			}
			return flag;
		}

		public ITheme GetTheme()
		{
			return TargetTheme;
		}

		public void AddView(IClient view)
		{
			if (typeof(MotorwaysClient).IsAssignableFrom(view.GetType()))
			{
				MotorwaysClient item = (MotorwaysClient)view;
				if (!_viewClients.Contains(item))
				{
					_viewClients.Add(item);
				}
			}
		}

		public void RemoveView(IClient view)
		{
			if (typeof(MotorwaysClient).IsAssignableFrom(view.GetType()))
			{
				MotorwaysClient item = (MotorwaysClient)view;
				_viewClients.Remove(item);
			}
		}

		public void DisableDeleteModeOverrides()
		{
			bool applyThemeOverrides = _applyThemeOverrides;
			_applyThemeOverrides = false;
			if (applyThemeOverrides != _applyThemeOverrides)
			{
				if (_isBlendingOverrides)
				{
					_transitionProgress = Mathf.Clamp(_transitionDuration - _transitionProgress, 0f, _transitionDuration);
				}
				else
				{
					_transitionProgress = 0f;
				}
				_transitionDuration = _themeTransitionTime;
				_isBlendingOverrides = true;
				_dirty = true;
			}
		}

		public void UpdateColorblindThemesFromActiveUserProfile()
		{
			Theme colorblindThemeColorful = bindings.colorblindThemeColorful;
			Theme colorblindThemeDark = bindings.colorblindThemeDark;
			List<int> playerColorblindPaletteIndexes = _activePlayer.MotorwaysExtendedUserProfile.PlayerColorblindPaletteIndexes;
			ColorGroup[] availableColorfulColorBlindColorGroups = _visualConstants.AvailableColorfulColorBlindColorGroups;
			ColorGroup[] availableDarkColorBlindColorGroups = _visualConstants.AvailableDarkColorBlindColorGroups;
			for (int i = 0; i < MAX_THEME_COLOR_GROUPS; i++)
			{
				colorblindThemeColorful.buildingColorGroups[i] = availableColorfulColorBlindColorGroups[playerColorblindPaletteIndexes[i]];
				colorblindThemeDark.buildingColorGroups[i] = availableDarkColorBlindColorGroups[playerColorblindPaletteIndexes[i]];
			}
		}
	}
}
