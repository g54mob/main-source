using System;
using System.Collections.Generic;
using System.Linq;
using Client;
using Factory;
using Factory.Pools;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways.Views
{
	public class BuildingsIndicatorView : MonoBehaviour, IView, IViewClientObserver, IReusable, IReleasedFromScopeHandler, DestinationView.IObserver
	{
		[System.Serializable]
		private struct IndicatorSharedSettings
		{
			[Tooltip("The time to wait once the building spawns before the echo starts playing.")]
			[MinValue(0f)]
			public float echoDelayInSeconds;

			[MinValue(0f)]
			[Tooltip("The time it takes the echo to go from the scale Min to Max.")]
			public float echoDurationInSeconds;

			[Tooltip("The width of the echo ring on the screen as progress goes from 0 to 1")]
			public AnimationCurve echoRingWidthCurve;

			[MinValue(0f)]
			[Tooltip("The initial scale of the echo when it spawns.")]
			public float echoScaleMin;

			[MinValue(0f)]
			[Tooltip("The final scale of the echo before it is destroyed.")]
			public float echoScaleMax;

			[MinValue(0f)]
			[Tooltip("The time between echos for an event which has multiple echos.")]
			public float echoRepeatDelayInSeconds;

			[MinValue(0f)]
			[Space]
			[Tooltip("The time to wait once the building spawns before the dark echo starts playing.")]
			public float darkEchoDelayInSeconds;

			[Tooltip("The final scale of the dark echo before it is destroyed.")]
			[MinValue(0f)]
			public float darkEchoScaleMax;

			[Tooltip("The time to wait once the building spawns before the arrow appears.")]
			[Space]
			[MinValue(0f)]
			public float arrowDelayInSeconds;

			public override int GetHashCode()
			{
				return echoDelayInSeconds.GetHashCode() ^ echoDurationInSeconds.GetHashCode() ^ echoScaleMin.GetHashCode() ^ echoScaleMax.GetHashCode() ^ echoRepeatDelayInSeconds.GetHashCode() ^ darkEchoDelayInSeconds.GetHashCode() ^ darkEchoScaleMax.GetHashCode() ^ arrowDelayInSeconds.GetHashCode();
			}
		}

		[System.Serializable]
		private struct IndicatorSettings
		{
			[MinValue(1)]
			[Tooltip("The number of echos to display with a timing interval of echoRepeatDelayInSeconds.")]
			public int echoCount;

			[Tooltip("If the building this indicator relates to is offscreen, clampToScreen will keep the indicator half on screen.")]
			public bool clampToScreen;

			[Tooltip("If a dark echo should be played for this indicator.")]
			public bool hasDarkEcho;

			[Tooltip("The arrow type changes the arrow icon and color.")]
			public IndicatorArrowView.IndicatorType arrowType;
		}

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private MotorwaysGame _game;

		[Dependency]
		private City _city;

		[Dependency]
		private MotorwaysThemeDatabase _themeDatabase;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private GameUIScreen _gameUiScreen;

		[Dependency]
		private VisualConstantsData _constants;

		[Header("Indicator Event Shared Settings")]
		[MinValue(0f)]
		[Tooltip("When buildings spawn offscreen in edit mode, this is the time between echos when the player exits edit mode.")]
		[SerializeField]
		private float _echoRate;

		[MinValue(0f)]
		[SerializeField]
		private float _arrowExitDelay;

		[SerializeField]
		[MinValue(0)]
		private int _arrowKnockNumber;

		[SerializeField]
		[MinValue(0f)]
		private float _arrowKnockDelayInSeconds;

		[SerializeField]
		private IndicatorSharedSettings _houseSharedSettings;

		[SerializeField]
		private IndicatorSharedSettings _destinationSharedSettings;

		[Header("Indicator Event Settings")]
		[SerializeField]
		private IndicatorSettings _houseAppearIndicatorSettings;

		[SerializeField]
		private IndicatorSettings _destinationAppearIndicatorSettings;

		[SerializeField]
		private IndicatorSettings _destinationDemandUpgradedIndicatorSettings;

		[SerializeField]
		private IndicatorSettings _destinationBigPinIndicatorSettings;

		[SerializeField]
		private IndicatorSettings _destinationImminentFailIndicatorSettings;

		[Header("Pulse Settings")]
		[SerializeField]
		[MinValue(0f)]
		[Tooltip("The time it takes a building to begin pulsing since it was spawned.")]
		private float _pulseDelayInSeconds;

		[SerializeField]
		[MinValue(0f)]
		[Tooltip("The time interval between the start of each pulse. Timing does not wait until the pulse has finished.")]
		private float _pulseRateInSeconds;

		private RectTransform _safeAreaRect;

		private bool _pulsingEnabled;

		private float _timeUntilPulseInSeconds;

		private float _timeUntilPendingIndicator;

		private readonly List<HouseView> _pendingIndicators = new List<HouseView>();

		public bool AlertsEnabled { get; set; } = true;

		public bool PulsingEnabled => _pulsingEnabled;

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_viewClient.OnFirstFrame)
			{
				_viewClient.Subscribe(this);
				if (!_city.Rules.ShowDisconnectedBuildingsUI())
				{
					return TickResult.Destroy;
				}
				foreach (DestinationView destinationView in _city.Scope.Get<ViewIndex>().DestinationViews)
				{
					destinationView.Subscribe(this);
				}
				SafeArea safeArea = _gameUiScreen.safeArea;
				if (Diagnostics.Verify(safeArea != null, _gameUiScreen, "Safe area hasn't been set on the GameUIScreen component. We need to update the prefab"))
				{
					_safeAreaRect = safeArea.GetComponent<RectTransform>();
				}
				_timeUntilPulseInSeconds = _pulseDelayInSeconds;
			}
			if (!_game.HasGameEnded)
			{
				TickPendingIndicators(timeInterval.Delta);
				TickPulses(timeInterval.Delta);
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void TickPendingIndicators(float tickTime)
		{
			if (_timeUntilPendingIndicator > 0f && !_cameraView.IsFocussedIn)
			{
				_timeUntilPendingIndicator -= tickTime;
				if (_timeUntilPendingIndicator <= 0f && _pendingIndicators.Count > 0)
				{
					HouseView houseView = _pendingIndicators[0];
					_pendingIndicators.RemoveAt(0);
					CreateHouseAddedIndicator(houseView);
					_timeUntilPendingIndicator += _echoRate;
				}
			}
		}

		private void TickPulses(float tickTime)
		{
			if (_pulsingEnabled)
			{
				_timeUntilPulseInSeconds -= tickTime;
				if (_timeUntilPulseInSeconds < 0f)
				{
					_timeUntilPulseInSeconds += _pulseRateInSeconds;
					DoPulse();
				}
			}
		}

		private void DoPulse()
		{
			foreach (DestinationView destinationView in _city.Scope.Get<ViewIndex>().DestinationViews)
			{
				if (IsValidForPulse(destinationView))
				{
					destinationView.DoDisconnectedPulse();
				}
			}
		}

		private bool IsValidForPulse(DestinationView destinationView)
		{
			if (destinationView.NetworkConnectivity != NetworkConnectivity.Disconnected)
			{
				return false;
			}
			if (Time.time - destinationView.SpawnTime < _pulseDelayInSeconds)
			{
				return false;
			}
			return true;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_viewClient.Unsubscribe(this);
		}

		public void OnViewAdded(IClient client, IView view)
		{
			if (view is HouseView houseView)
			{
				OnHouseAdded(houseView);
			}
			else if (view is DestinationView destinationView)
			{
				CreateDestinationAddedIndicator(destinationView);
				destinationView.Subscribe(this);
			}
		}

		public void OnViewRemoved(IClient client, IView view)
		{
		}

		public void OnDemandLevelChanged(DestinationView owner)
		{
			if (owner.Model.IsUpgraded)
			{
				CreateDestinationUpgradedEcho(owner);
			}
		}

		public void OnImminentFailAlert(DestinationView destinationView, bool isInitialAlert)
		{
			if (isInitialAlert)
			{
				CreateDestinationImminentFailEcho(destinationView);
			}
			else
			{
				CreateDestinationAlert(destinationView);
			}
		}

		public void OnBigPinAppeared(DestinationView destinationView)
		{
			CreateDestinationBigPinEcho(destinationView);
		}

		private BuildingIndicatorEventView.Config BuildIndicatorConfig(IndicatorSharedSettings sharedSettings, IndicatorSettings settings)
		{
			BuildingIndicatorEventView.Config result = new BuildingIndicatorEventView.Config
			{
				echoDelayInSeconds = sharedSettings.echoDelayInSeconds,
				echoRingWidthCurve = sharedSettings.echoRingWidthCurve,
				echoScaleMin = sharedSettings.echoScaleMin,
				echoScaleMax = sharedSettings.echoScaleMax,
				echoDurationInSeconds = sharedSettings.echoDurationInSeconds,
				clampToScreen = settings.clampToScreen,
				echoCount = settings.echoCount,
				echoCircleRate = sharedSettings.echoRepeatDelayInSeconds,
				darkEchoDelayInSeconds = sharedSettings.darkEchoDelayInSeconds,
				darkEchoScaleMax = NormaliseDarkEchoScale(sharedSettings.darkEchoScaleMax),
				arrowDelayInSeconds = sharedSettings.arrowDelayInSeconds,
				arrowType = settings.arrowType,
				arrowKnockNumber = _arrowKnockNumber,
				arrowKnockDelay = _arrowKnockDelayInSeconds,
				arrowExitDelay = _arrowExitDelay
			};
			if (!settings.hasDarkEcho)
			{
				result.darkEchoDelayInSeconds = -1f;
			}
			return result;
		}

		private static float NormaliseDarkEchoScale(float scale)
		{
			return scale * 0.8f - 1f;
		}

		private void OnHouseAdded(HouseView houseView)
		{
			Bounds bounds = houseView.GetBounds();
			bool flag = IsBoundsIntersectingScreen(bounds);
			if (!_cameraView.IsFocussedIn || flag)
			{
				CreateHouseAddedIndicator(houseView);
				return;
			}
			_pendingIndicators.Add(houseView);
			if (_timeUntilPendingIndicator <= 0f)
			{
				_timeUntilPendingIndicator = _echoRate;
			}
		}

		private bool IsBoundsIntersectingScreen(Bounds bounds)
		{
			Camera defaultCamera = _gameCamera.DefaultCamera;
			Rect other = new Rect
			{
				max = new Vector2(defaultCamera.pixelWidth, defaultCamera.pixelHeight)
			};
			Rect rect = new Rect
			{
				min = defaultCamera.WorldToScreenPoint(bounds.min),
				max = defaultCamera.WorldToScreenPoint(bounds.max)
			};
			return rect.Overlaps(other);
		}

		private bool IsDestinationIntersectionScreen(DestinationView destinationView)
		{
			Bounds bounds = destinationView.GetBounds();
			return IsBoundsIntersectingScreen(bounds);
		}

		private void CreateHouseAddedIndicator(HouseView houseView)
		{
			if (AlertsEnabled)
			{
				BuildingIndicatorEventView.Config config = BuildIndicatorConfig(_houseSharedSettings, _houseAppearIndicatorSettings);
				config.position = houseView.transform.position;
				BuildingIndicatorEventView.CreateHouseIndicator(_viewClient, houseView, ref config);
			}
		}

		private void CreateDestinationAddedIndicator(DestinationView destinationView)
		{
			if (AlertsEnabled)
			{
				if (IsDestinationIntersectionScreen(destinationView))
				{
					CreateDestinationAlert(destinationView);
				}
				BuildingIndicatorEventView.Config config = BuildIndicatorConfig(_destinationSharedSettings, _destinationAppearIndicatorSettings);
				config.position = destinationView.transform.position;
				BuildingIndicatorEventView.CreateDestinationIndicator(_viewClient, destinationView, _safeAreaRect, ref config);
			}
		}

		private void CreateDestinationBigPinEcho(DestinationView destinationView)
		{
			if (AlertsEnabled)
			{
				BuildingIndicatorEventView.Config config = BuildIndicatorConfig(_destinationSharedSettings, _destinationBigPinIndicatorSettings);
				config.position = destinationView.BigPinAlertPosition;
				BuildingIndicatorEventView.CreateDestinationIndicator(_viewClient, destinationView, _safeAreaRect, ref config);
			}
		}

		private void CreateDestinationUpgradedEcho(DestinationView destinationView)
		{
			if (AlertsEnabled)
			{
				BuildingIndicatorEventView.Config config = BuildIndicatorConfig(_destinationSharedSettings, _destinationDemandUpgradedIndicatorSettings);
				config.position = destinationView.transform.position;
				BuildingIndicatorEventView.CreateDestinationIndicator(_viewClient, destinationView, _safeAreaRect, ref config);
			}
		}

		private void CreateDestinationImminentFailEcho(DestinationView destinationView)
		{
			if (AlertsEnabled)
			{
				BuildingIndicatorEventView.Config config = BuildIndicatorConfig(_destinationSharedSettings, _destinationImminentFailIndicatorSettings);
				config.position = destinationView.BigPinAlertPosition;
				BuildingIndicatorEventView.CreateDestinationIndicator(_viewClient, destinationView, _safeAreaRect, ref config);
			}
		}

		private void CreateDestinationAlert(DestinationView destinationView)
		{
			if (AlertsEnabled && _city.Rules.ShowsUI())
			{
				AlertView.Create(_viewClient, destinationView.transform.position, _themeDatabase.GetGlobalColor(_constants.BuildingEchoAlertColor));
			}
		}

		public void Reset()
		{
			_pulsingEnabled = false;
			AlertsEnabled = true;
			_timeUntilPulseInSeconds = 0f;
			_timeUntilPendingIndicator = 0f;
			_pendingIndicators.Clear();
		}

		public void StartPulsing()
		{
			_pulsingEnabled = true;
		}

		public void StopPulsing()
		{
			_pulsingEnabled = false;
			_timeUntilPulseInSeconds = _pulseRateInSeconds;
		}

		public IEnumerable<HouseView> EDITOR_GetHouseViews()
		{
			if (_city == null)
			{
				return Enumerable.Empty<HouseView>();
			}
			return _city.Scope.Get<ViewIndex>().HouseViews;
		}

		public IEnumerable<DestinationView> EDITOR_GetDestinationViews()
		{
			if (_city == null)
			{
				return Enumerable.Empty<DestinationView>();
			}
			return _city.Scope.Get<ViewIndex>().DestinationViews;
		}

		public void EDITOR_CreateHouseAddedIndicator(HouseView houseView)
		{
			CreateHouseAddedIndicator(houseView);
		}

		public void EDITOR_CreateDestinationAddedIndicator(DestinationView destinationView)
		{
			CreateDestinationAddedIndicator(destinationView);
		}

		public void EDITOR_CreateDestinationBigPinEcho(DestinationView destinationView)
		{
			CreateDestinationBigPinEcho(destinationView);
		}

		public void EDITOR_CreateDestinationUpgradedEcho(DestinationView destinationView)
		{
			CreateDestinationUpgradedEcho(destinationView);
		}

		public void EDITOR_CreateDestinationImminentFailEcho(DestinationView destinationView)
		{
			CreateDestinationImminentFailEcho(destinationView);
		}
	}
}
