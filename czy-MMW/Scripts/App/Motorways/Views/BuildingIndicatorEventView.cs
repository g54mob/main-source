using System;
using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class BuildingIndicatorEventView : IView, IReusable
	{
		[System.Serializable]
		public struct Config
		{
			public float echoDelayInSeconds;

			public AnimationCurve echoRingWidthCurve;

			public float echoScaleMin;

			public float echoScaleMax;

			public float echoDurationInSeconds;

			public bool clampToScreen;

			public int echoCount;

			public float echoCircleRate;

			public float darkEchoDelayInSeconds;

			public float darkEchoScaleMax;

			public float arrowDelayInSeconds;

			public IndicatorArrowView.IndicatorType arrowType;

			public int arrowKnockNumber;

			public float arrowKnockDelay;

			public float arrowExitDelay;

			public Vector2 position;
		}

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private MotorwaysThemeDatabase _theme;

		[Dependency]
		private VisualConstantsData _constants;

		private DestinationView _destinationView;

		private HouseView _houseView;

		private Config _config;

		private RectTransform _safeAreaRect;

		private Vector3[] _safeAreaWorldCorners = new Vector3[4];

		private List<Transform> _children = new List<Transform>();

		private Color IndicatorTargetColour
		{
			get
			{
				Color result = Color.white;
				if (_destinationView != null)
				{
					result = _destinationView.GetBuildingColor(ThemeComponentGroupTarget.BuildingBase);
				}
				else if (_houseView != null)
				{
					result = _houseView.GetBuildingColor(ThemeComponentGroupTarget.BuildingBase);
				}
				return result;
			}
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			TickEchoSpawns(timeInterval.Delta);
			TickDarkEchoSpawns(timeInterval.Delta);
			TickArrowSpawn(timeInterval.Delta);
			RemoveCompletedSpawns();
			UpdateSpawnPositions();
			if (IsComplete())
			{
				return TickResult.Destroy;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
		}

		private void TickEchoSpawns(float tickTime)
		{
			if (!(_config.echoDelayInSeconds >= 0f))
			{
				return;
			}
			_config.echoDelayInSeconds -= tickTime;
			if (_config.echoDelayInSeconds < 0f)
			{
				IndicatorEchoView indicatorEchoView = IndicatorEchoView.Create(_viewClient, _config.position, IndicatorTargetColour, _config.echoRingWidthCurve, _config.echoScaleMin, _config.echoScaleMax, _config.echoDurationInSeconds);
				_children.Add(indicatorEchoView.transform);
				_config.echoCount--;
				if (_config.echoCount > 0)
				{
					_config.echoDelayInSeconds += _config.echoCircleRate;
				}
			}
		}

		private void TickDarkEchoSpawns(float tickTime)
		{
			if (_config.darkEchoDelayInSeconds >= 0f)
			{
				_config.darkEchoDelayInSeconds -= tickTime;
				if (_config.darkEchoDelayInSeconds < 0f)
				{
					AlertView alertView = AlertView.Create(_viewClient, _config.position, _theme.GetGlobalColor(_constants.BuildingEchoAlertColor), _config.darkEchoScaleMax);
					_children.Add(alertView.transform);
				}
			}
		}

		private void TickArrowSpawn(float tickTime)
		{
			if (_config.arrowDelayInSeconds >= 0f)
			{
				_config.arrowDelayInSeconds -= tickTime;
				if (_config.arrowDelayInSeconds < 0f && ShouldCreateIndicatorArrow())
				{
					IndicatorArrowView.Create(_viewClient, _destinationView, _config.arrowType, _safeAreaRect, _config.arrowKnockNumber, _config.arrowKnockDelay, _config.arrowExitDelay);
				}
			}
		}

		private bool ShouldCreateIndicatorArrow()
		{
			if (_destinationView == null)
			{
				return false;
			}
			if (!_cameraView.IsFocussedIn)
			{
				return false;
			}
			Camera defaultCamera = _gameCamera.DefaultCamera;
			_safeAreaRect.GetWorldCorners(_safeAreaWorldCorners);
			Vector3 vector = defaultCamera.WorldToScreenPoint(_safeAreaWorldCorners[0]);
			Vector3 vector2 = defaultCamera.WorldToScreenPoint(_safeAreaWorldCorners[2]);
			Rect other = Rect.MinMaxRect(vector.x, vector.y, vector2.x, vector2.y);
			Bounds bounds = _destinationView.GetBounds();
			Vector3 vector3 = defaultCamera.WorldToScreenPoint(bounds.min);
			Vector3 vector4 = defaultCamera.WorldToScreenPoint(bounds.max);
			if (Rect.MinMaxRect(vector3.x, vector3.y, vector4.x, vector4.y).Overlaps(other))
			{
				return false;
			}
			return true;
		}

		private void RemoveCompletedSpawns()
		{
			int num = 0;
			while (num < _children.Count)
			{
				if (!_children[num].gameObject.activeSelf)
				{
					_children.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
		}

		private void UpdateSpawnPositions()
		{
			if (_config.clampToScreen)
			{
				ClampToScreen();
			}
		}

		private void ClampToScreen()
		{
			Camera defaultCamera = _gameCamera.DefaultCamera;
			Vector3 position = _config.position;
			Vector3 vector = defaultCamera.WorldToScreenPoint(position);
			Vector3 position2 = new Vector3(Mathf.Clamp(vector.x, 0f, defaultCamera.pixelWidth), Mathf.Clamp(vector.y, 0f, defaultCamera.pixelHeight), vector.z);
			Vector3 position3 = defaultCamera.ScreenToWorldPoint(position2);
			foreach (Transform child in _children)
			{
				child.position = position3;
			}
		}

		private bool IsComplete()
		{
			if (_config.echoDelayInSeconds >= 0f || _config.darkEchoDelayInSeconds >= 0f)
			{
				return false;
			}
			if (_children.Count > 0)
			{
				return false;
			}
			return true;
		}

		public void Reset()
		{
			_destinationView = null;
			_houseView = null;
			_config = default(Config);
			_children.Clear();
		}

		private static BuildingIndicatorEventView Create(ViewClient viewClient, ref Config config)
		{
			BuildingIndicatorEventView buildingIndicatorEventView = viewClient.Scope.Get<BuildingIndicatorEventView>();
			buildingIndicatorEventView._config = config;
			viewClient.AddView(buildingIndicatorEventView);
			return buildingIndicatorEventView;
		}

		public static BuildingIndicatorEventView CreateHouseIndicator(ViewClient viewClient, HouseView houseView, ref Config config)
		{
			BuildingIndicatorEventView buildingIndicatorEventView = Create(viewClient, ref config);
			buildingIndicatorEventView._houseView = houseView;
			return buildingIndicatorEventView;
		}

		public static BuildingIndicatorEventView CreateDestinationIndicator(ViewClient viewClient, DestinationView destinationView, RectTransform safeAreaRect, ref Config config)
		{
			BuildingIndicatorEventView buildingIndicatorEventView = Create(viewClient, ref config);
			buildingIndicatorEventView._destinationView = destinationView;
			buildingIndicatorEventView._safeAreaRect = safeAreaRect;
			return buildingIndicatorEventView;
		}
	}
}
