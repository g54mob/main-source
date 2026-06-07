using System;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Audio;
using Motorways.Models;
using Motorways.Themes;
using Motorways.UI;
using Server;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class ClockView : MonoBehaviour, IView, IThemeComponent, ICreatedInScopeHandler, IReleasedFromScopeHandler, IReusable
	{
		public delegate void OnVisuallyPausedChanged(bool isVisuallyPaused);

		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				ClockView clockView = client.Scope.Get<ClockView>();
				clockView._clockModel = model as ClockModel;
				clockView.UpdateColors();
				client.AddView(clockView);
			}
		}

		[Dependency]
		private LocaleDatabase _localeDatabase;

		[Dependency]
		private IScope _scope;

		private ClockModel _clockModel;

		public RectTransform clockHandRectTransform;

		public RectTransform clockFaceTransform;

		public Animator animator;

		private static readonly int PulseTrigger = Animator.StringToHash("Pulse");

		public float clockHandRotationOrigin = 90f;

		private const float ClockHandAnglePerSecond = 36f;

		public LocalizedTextUI dayText;

		private Locale.DaysOfTheWeek _currentDay;

		public Image clockFace;

		public Image[] clockPips;

		public Image clockHand;

		[SerializeField]
		private ThemedMaterialType _darkThemeColor = ThemedMaterialType.Dark;

		[SerializeField]
		private ThemedMaterialType _lightThemeColor;

		[SerializeField]
		private FloatingElement _clockFloatingElement;

		[SerializeField]
		private FloatingElement _dayFloatingElement;

		[SerializeField]
		private Transform _scoreViewParent;

		[SerializeField]
		private Transform _vcrInactiveAnchor;

		private TouchButton _scoreButton;

		public Color pauseColor = Color.red;

		private Color _darkColor = Color.black;

		private Color _lightColor = Color.white;

		private bool _dayTime = true;

		private const float ColorChangeDuration = 0.1f;

		private bool _isVisuallyPaused;

		private ScoreView _scoreView;

		public ClockModel ClockModel
		{
			get
			{
				return _clockModel;
			}
			set
			{
				_clockModel = value;
			}
		}

		public TouchButton ScoreButton => _scoreButton;

		public Transform VcrInactiveAnchor => _vcrInactiveAnchor;

		public bool IsVisuallyPaused
		{
			get
			{
				return _isVisuallyPaused;
			}
			set
			{
				_isVisuallyPaused = value;
				UpdateColors();
				this.VisuallyPausedChanged?.Invoke(_isVisuallyPaused);
			}
		}

		public ScoreView ScoreView => _scoreView;

		public event OnVisuallyPausedChanged VisuallyPausedChanged;

		public event Action OnClockToggled;

		public void OnCreatedInScope(IScope scope)
		{
			_scoreView = _scope.Get<ScoreView>();
			_scoreView.transform.SetParent(_scoreViewParent, worldPositionStays: false);
			_scoreButton = _scoreView.scoreButton;
		}

		public void Initialize(ClockModel clockModel, GameObject clockAnchorActive, Transform clockAnchorInactive, GameObject dayAnchorActive, Transform dayAnchorInactive, GameObject scoreAnchorActive, Transform scoreAnchorInactive)
		{
			_clockModel = clockModel;
			_clockFloatingElement.baseElement = clockAnchorActive;
			_clockFloatingElement.SetInactiveAnchor(clockAnchorInactive);
			_dayFloatingElement.baseElement = dayAnchorActive;
			_dayFloatingElement.SetInactiveAnchor(dayAnchorInactive);
			_scoreView.FloatingElement.baseElement = scoreAnchorActive;
			_scoreView.FloatingElement.SetInactiveAnchor(scoreAnchorInactive);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			float z = clockHandRotationOrigin - 36f * _clockModel.GetInterpolatedTime(stepAlpha);
			clockHandRectTransform.rotation = Quaternion.Euler(new Vector3(0f, 0f, z));
			Locale.DaysOfTheWeek dayLabel = _localeDatabase.CurrentLocale.GetDayLabel(_clockModel.Day % 7);
			if (_currentDay != dayLabel)
			{
				_currentDay = dayLabel;
				if (Diagnostics.Verify(Enum.TryParse<StringId>(_currentDay.ToString(), out var result)))
				{
					dayText.LocString = StandaloneLocString.CreateString(_scope, result);
				}
				AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.DayStart));
			}
			if (_dayTime && !IsDayTime())
			{
				UpdateColors();
				_dayTime = false;
			}
			else if (!_dayTime && IsDayTime())
			{
				UpdateColors();
				_dayTime = true;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void UpdateColors()
		{
			bool flag = _isVisuallyPaused;
			if (FeatureToggle.IsFeatureDisabled(Feature.ClockPauseColor))
			{
				flag = false;
			}
			if (_clockModel == null)
			{
				return;
			}
			if (!IsDayTime())
			{
				clockHand.CrossFadeColor(_lightColor, 0.1f, ignoreTimeScale: false, useAlpha: false);
				Image[] array = clockPips;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CrossFadeColor(_lightColor, 0.1f, ignoreTimeScale: false, useAlpha: false);
				}
				clockFace.CrossFadeColor(flag ? pauseColor : _darkColor, 0.1f, ignoreTimeScale: false, useAlpha: false);
			}
			else
			{
				clockHand.CrossFadeColor(_darkColor, 0.1f, ignoreTimeScale: false, useAlpha: false);
				Image[] array = clockPips;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CrossFadeColor(_darkColor, 0.1f, ignoreTimeScale: false, useAlpha: false);
				}
				clockFace.CrossFadeColor(flag ? pauseColor : _lightColor, 0.1f, ignoreTimeScale: false, useAlpha: false);
			}
		}

		public void Pulse()
		{
			animator.SetTrigger(PulseTrigger);
		}

		private bool IsDayTime()
		{
			if (_clockModel.Hour % 24 >= 6)
			{
				return _clockModel.Hour % 24 < 18;
			}
			return false;
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
		}

		public void ApplyTheme(ITheme newTheme)
		{
			Theme theme = (Theme)newTheme;
			_darkColor = theme.GetColor(_darkThemeColor);
			_lightColor = theme.GetColor(_lightThemeColor);
			UpdateColors();
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			Theme theme = (Theme)newTheme;
			_darkColor = theme.GetColor(_darkThemeColor);
			_lightColor = theme.GetColor(_lightThemeColor);
			UpdateColors();
			return ThemeBlendingResult.StopBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_isVisuallyPaused = false;
		}

		public void ClockToggled()
		{
			this.OnClockToggled?.Invoke();
		}

		public void Reset()
		{
			_clockModel = null;
			_darkColor = Color.black;
			_lightColor = Color.white;
			_currentDay = Locale.DaysOfTheWeek.Monday;
			_dayTime = true;
			_isVisuallyPaused = false;
		}
	}
}
