using System;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Motorways.Utility;
using Motorways.Views.Trains;
using Server;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class CameraView : IView, InputState.IObserver, ICreatedInScopeHandler, IReusable, IReleasedFromScopeHandler
	{
		public enum CameraInterpType
		{
			Default = 0,
			PlayerPanning = 1,
			PlayerZooming = 2,
			TileFocus = 3,
			PanToAlign = 4,
			Resetting = 5
		}

		public enum CinematicModeState
		{
			Off = 0,
			AwaitingJourney = 1,
			OnJourney = 2,
			CompletedJourney = 3,
			FollowingTrain = 4,
			ExitingMode = 5
		}

		public enum CameraFocusOffsetType
		{
			FocusOnMiddle = 0,
			MaintainScreenPosition = 1
		}

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private City _city;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private TilemapView _tilemapView;

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private GameCamera _camera;

		[Dependency]
		private GameUIScreen _gameUI;

		[Dependency]
		private InputState _inputState;

		[Dependency]
		private ScreenStack _screenStack;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private VisualConstantsData _visualConstantsData;

		private bool _isFocussedIn;

		public static int potentialTapZoomIndex = 0;

		public static List<float> potentialTapZoomLevels = new List<float> { -1f, 13f, 12f, 11f, 10f, 9f, 8f, 7f, 6f };

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("CameraView");

		private CameraInterpType _interpolationType;

		private InertialFloat _panX;

		private InertialFloat _panY;

		private Vector3 _editMenuFocusPoint;

		public float playerOrthoZoom = -1f;

		public bool playerZoomedIn;

		private bool _isPlayerPanning;

		private bool _setPanToCenter;

		private bool _includeSafeAreaOffsetInZoom;

		private const float _defaultCameraMoveSpeed = 0.98f;

		private const float _defaultCameraZoomSpeed = 0.98f;

		private const float _tileFocusCameraMoveSpeed = 0.35f;

		private const float _panToAlignCameraMoveSpeed = 0.1f;

		private const float _playerPanCameraMoveSpeed = 0.98f;

		private const float _playableAreaWidthScaleToConstrainCamera = 0.6f;

		private const float _playableAreaHeightScaleToConstrainCamera = 0.5f;

		private bool _hasControlOverriden;

		private int _cinematicZoomIndex;

		private VehicleView _cinematicModeVehicleToFollow;

		private TrainView _cinematicModeTrainToFollow;

		private CinematicModeState _cinematicModeState;

		private float _cinematicModeSpeed = 1f;

		private float _durationSpentOnCurrentMode;

		private float _debugControlsZoomOffset;

		private Vector2 _debugControlsPanOffset = Vector2.zero;

		private Vector3 _debugControlsLastMouseWorldPosition = Vector3.zero;

		private const float RotationStepDegrees = 15f;

		private float _debugRotation;

		private AnchoredMessageModel _cinematicModeNoCarsMessage;

		private static readonly Vector3[] PlayableCorners = new Vector3[4];

		private static readonly Vector2 MessageAnchorOffset = new Vector2(0f, 0.8f);

		private static readonly Vector3[] ParentCorners = new Vector3[4];

		public Vector3 DesiredPosition { get; private set; }

		public Vector3 CurrentUnfocusedPosition { get; private set; }

		public float MaxZoom { get; private set; }

		public float DesiredZoom { get; private set; }

		public bool IsFocussedIn
		{
			get
			{
				return _isFocussedIn;
			}
			private set
			{
				_isFocussedIn = value;
			}
		}

		public bool CanChangeFocus { get; set; }

		public float FixedZoom { get; private set; }

		public GameCamera GameCamera => _camera;

		public int CinematicZoomIndex => _cinematicZoomIndex;

		public int ZoomLevelCount => _visualConstantsData.ZoomLevelsCameraMin.Count;

		private bool _editMenuFocusPointApplied => _editMenuFocusPoint.sqrMagnitude > 0f;

		public bool IsPlayerPanning => _isPlayerPanning;

		public float MinZoom
		{
			get
			{
				if (potentialTapZoomIndex == 0)
				{
					if (IsInCinematicMode)
					{
						return _visualConstantsData.ZoomLevelsCameraMin[_cinematicZoomIndex];
					}
					return _visualConstantsData.ZoomLevelsCameraMin[_player.ZoomLevel];
				}
				return potentialTapZoomLevels[potentialTapZoomIndex];
			}
		}

		public bool HasControlOverriden
		{
			get
			{
				return _hasControlOverriden;
			}
			set
			{
				if (_hasControlOverriden && !value)
				{
					_camera.transform.rotation = Quaternion.identity;
				}
				_hasControlOverriden = value;
			}
		}

		public bool IsInCinematicMode => _cinematicModeState != CinematicModeState.Off;

		public bool HasControl
		{
			get
			{
				if (HasControlOverriden || IsInCinematicMode)
				{
					return false;
				}
				if (IsInGame)
				{
					ScreenStack.MotorwaysScreen topActiveScreenType = _screenStack.GetTopActiveScreenType();
					if (topActiveScreenType != ScreenStack.MotorwaysScreen.InGame && topActiveScreenType != ScreenStack.MotorwaysScreen.Upgrade)
					{
						return topActiveScreenType == ScreenStack.MotorwaysScreen.CinematicMode;
					}
					return true;
				}
				return false;
			}
		}

		private bool IsInGame => _screenStack.IsScreenVisible(ScreenStack.MotorwaysScreen.InGame);

		private float DebugRotation
		{
			get
			{
				if (!HasControlOverriden)
				{
					return 0f;
				}
				if (Input.GetKeyDown(KeyCode.LeftBracket))
				{
					_debugRotation -= 15f;
				}
				if (Input.GetKeyDown(KeyCode.RightBracket))
				{
					_debugRotation += 15f;
				}
				return _debugRotation;
			}
		}

		public event Action OnCameraZoomLevelChanged;

		public void OnReleasedFromScope(IScope scope)
		{
			_inputState.Unsubscribe(this);
		}

		public void Reset()
		{
			DesiredPosition = default(Vector3);
			CurrentUnfocusedPosition = default(Vector3);
			MaxZoom = 0f;
			DesiredZoom = 0f;
			_cinematicZoomIndex = 0;
			IsFocussedIn = false;
			CanChangeFocus = false;
			FixedZoom = 0f;
			_interpolationType = CameraInterpType.Default;
			HasControlOverriden = false;
			_panX?.Reset();
			_panY?.Reset();
			playerOrthoZoom = -1f;
			playerZoomedIn = false;
			_isPlayerPanning = false;
			_setPanToCenter = false;
			_includeSafeAreaOffsetInZoom = false;
			_debugControlsPanOffset = default(Vector2);
			_debugControlsZoomOffset = 0f;
			_debugControlsLastMouseWorldPosition = default(Vector3);
			_cinematicModeVehicleToFollow = null;
			_cinematicModeState = CinematicModeState.Off;
			_cinematicModeSpeed = 1f;
			_durationSpentOnCurrentMode = 0f;
		}

		public void OnCreatedInScope(IScope scope)
		{
			_inputState.Subscribe(this);
		}

		public void Initialize(GameRules rules)
		{
			Log.Info("CameraView initialized.");
			playerOrthoZoom = _visualConstantsData.ZoomLevelsCameraMin[_player.ZoomLevel];
			CanChangeFocus = true;
			_panX = new InertialFloat(_visualConstantsData.CinematicCameraSpringDuration, _visualConstantsData.CinematicCameraEasingFunction);
			_panY = new InertialFloat(_visualConstantsData.CinematicCameraSpringDuration, _visualConstantsData.CinematicCameraEasingFunction);
			_panX.Range = rules.GetCameraPanRange();
			_panY.Range = rules.GetCameraPanRange();
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_city == null || !_city.Rules.UseCamera())
			{
				return TickResult.ContinueTicking;
			}
			Fix64 cameraSizeAtTime = _city.GetCameraSizeAtTime(_clock.GetInterpolatedExpansionTime(stepAlpha));
			FixedZoom = (float)cameraSizeAtTime;
			RectFixed clientPlayableAreaAtZoom = _city.GetClientPlayableAreaAtZoom(cameraSizeAtTime);
			RectFixed clientPlayableAreaAtZoom2 = _city.GetClientPlayableAreaAtZoom(cameraSizeAtTime, City.PlayableAreaRoundingType.ForceWholeTiles);
			_camera.debugPlayableArea = clientPlayableAreaAtZoom2;
			_camera.debugPlayerOffset = new Vector2(_panX.RawValue, _panY.RawValue);
			Vector2 vector = Vector2.zero;
			_gameUI.playableArea.GetWorldCorners(PlayableCorners);
			UpdateMaxZoom(clientPlayableAreaAtZoom);
			if (!playerZoomedIn)
			{
				playerOrthoZoom = MaxZoom;
			}
			if (!playerZoomedIn || _includeSafeAreaOffsetInZoom)
			{
				vector = GetCameraOffsetToFitPlayableArea(playerOrthoZoom, PlayableCorners);
			}
			if (_interpolationType == CameraInterpType.Resetting && Mathf.Approximately(_camera.OrthographicSize, playerOrthoZoom))
			{
				_interpolationType = CameraInterpType.Default;
			}
			if (_viewClient.OnFirstFrame)
			{
				DesiredZoom = playerOrthoZoom;
			}
			else
			{
				DesiredZoom = Mathf.Lerp(_camera.OrthographicSize, playerOrthoZoom, GetInterpolationSpeed());
			}
			Vector3 vector2 = (CurrentUnfocusedPosition = new Vector3((float)clientPlayableAreaAtZoom.Center.x + vector.x, (float)clientPlayableAreaAtZoom.Center.y + vector.y, _camera.transform.position.z));
			if (playerZoomedIn || _isPlayerPanning || _editMenuFocusPointApplied)
			{
				float num = DesiredZoom / MaxZoom;
				float num2 = ((float)clientPlayableAreaAtZoom.width - (float)clientPlayableAreaAtZoom.width * num) * 0.6f;
				float num3 = ((float)clientPlayableAreaAtZoom.height - (float)clientPlayableAreaAtZoom.height * num) * 0.5f;
				_panX.Min = vector2.x - num2;
				_panX.Max = vector2.x + num2;
				_panY.Min = vector2.y - num3;
				_panY.Max = vector2.y + num3;
				if (_setPanToCenter)
				{
					_panX.RawValue = vector2.x;
					_panY.RawValue = vector2.y;
				}
				_panX.Tick(timeInterval.Delta);
				_panY.Tick(timeInterval.Delta);
				vector2 = new Vector3(_panX.ConstrainedValue, _panY.ConstrainedValue, _camera.transform.position.z);
			}
			if (_viewClient.OnFirstFrame || !HasControl)
			{
				DesiredPosition = vector2;
			}
			else
			{
				DesiredPosition = Vector3.Lerp(DesiredPosition, vector2, GetInterpolationSpeed());
			}
			Shader.SetGlobalVector("_PLAYABLE_AREA", new Vector4((float)clientPlayableAreaAtZoom2.xMin - 1f, (float)clientPlayableAreaAtZoom2.yMin - 1f, (float)clientPlayableAreaAtZoom2.xMax + 1f, (float)clientPlayableAreaAtZoom2.yMax + 1f));
			if (HasControl)
			{
				_camera.SetPosition(DesiredPosition);
				_camera.OrthographicSize = DesiredZoom;
			}
			else if (IsInCinematicMode)
			{
				HandleCinematicCamera(timeInterval.ScaledDelta);
			}
			else if (HasControlOverriden && IsInGame)
			{
				ApplyDebugPanAndZoom();
			}
			_setPanToCenter = false;
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
		}

		public void EnterCinematicMode()
		{
			_cinematicModeState = CinematicModeState.AwaitingJourney;
			_cinematicModeSpeed = 0f;
			_cinematicZoomIndex = _player.ZoomLevel;
			GoToNextAgentInCinematicMode();
		}

		public void GoToNextAgentInCinematicMode()
		{
			TryAssignNextAvailableVehicle();
			_durationSpentOnCurrentMode = 0f;
			if (!_player.IsSkipTransitionsEnabled)
			{
				_cinematicModeSpeed = 0f;
			}
			else if (_cinematicModeSpeed > 0f)
			{
				_cinematicModeSpeed = 1f;
			}
		}

		public void ExitCinematicMode()
		{
			if (_cinematicModeNoCarsMessage != null)
			{
				_simulation.RemoveModel(_cinematicModeNoCarsMessage);
				_cinematicModeNoCarsMessage = null;
			}
			if (IsInCinematicMode && _cinematicModeState != CinematicModeState.ExitingMode)
			{
				_cinematicModeState = CinematicModeState.ExitingMode;
				_cinematicModeSpeed = 0f;
			}
		}

		public void CinematicModeDebugGUI()
		{
			if (IsInCinematicMode)
			{
				Transform transform = ((_cinematicModeState == CinematicModeState.ExitingMode || _cinematicModeState == CinematicModeState.CompletedJourney) ? null : ((_cinematicModeState != CinematicModeState.FollowingTrain) ? _cinematicModeVehicleToFollow.transform : _cinematicModeTrainToFollow.CenterTransform));
				string text = "Cinematic mode:\n" + $"Current State: {_cinematicModeState}\n" + $"Current Speed: {_cinematicModeSpeed:F1}\n" + $"Duration In state: {_durationSpentOnCurrentMode:F1}\n";
				if (transform != null)
				{
					text = text + "Current Agent: " + transform.gameObject.name;
				}
				GUI.Label(new Rect(10f, 50f, 1000f, 400f), text, new GUIStyle
				{
					fontSize = 50
				});
			}
		}

		private void HandleCinematicCamera(float deltaTime)
		{
			if ((_cinematicModeState == CinematicModeState.FollowingTrain && _durationSpentOnCurrentMode > _visualConstantsData.MaximumDurationOnTrain) || (_cinematicModeState == CinematicModeState.AwaitingJourney && _durationSpentOnCurrentMode > _visualConstantsData.MaximumDurationOnIdleCar) || (_cinematicModeState == CinematicModeState.CompletedJourney && _durationSpentOnCurrentMode > _visualConstantsData.WaitDurationBetweenCompletedJourneyAndNewAgent))
			{
				GoToNextAgentInCinematicMode();
			}
			else if (_cinematicModeState == CinematicModeState.FollowingTrain)
			{
				if (_durationSpentOnCurrentMode > _visualConstantsData.MinimumDurationOnTrain && _cinematicModeTrainToFollow.Model.distanceTraveledSinceLastStation < Fix64.One && _cinematicModeTrainToFollow.Model.state == TrainModel.BehaviorState.Stopped && _cinematicModeTrainToFollow.Model.DelayBeforeStarting < (Fix64)0.5)
				{
					_cinematicModeState = CinematicModeState.CompletedJourney;
					_durationSpentOnCurrentMode = 0f;
				}
			}
			else if (_cinematicModeState == CinematicModeState.AwaitingJourney)
			{
				if (_cinematicModeVehicleToFollow.Model.IsDrivingToDestination)
				{
					_cinematicModeState = CinematicModeState.OnJourney;
					_durationSpentOnCurrentMode = 0f;
				}
			}
			else if (_cinematicModeState == CinematicModeState.OnJourney && _cinematicModeVehicleToFollow.Model.IsWaitingAtHouse)
			{
				_cinematicModeState = CinematicModeState.CompletedJourney;
				_durationSpentOnCurrentMode = 0f;
				_cinematicModeSpeed = 0.05f;
			}
			Vector3 vector = DesiredPosition;
			if (_cinematicModeState == CinematicModeState.CompletedJourney)
			{
				vector = ((!(_cinematicModeVehicleToFollow != null)) ? _camera.transform.position : (_cinematicModeVehicleToFollow.Model.house.tileModel.Coordinates.ToVector3() * 2f));
			}
			else if (_cinematicModeState != CinematicModeState.ExitingMode)
			{
				vector = ((_cinematicModeState == CinematicModeState.FollowingTrain) ? _cinematicModeTrainToFollow.CenterTransform : _cinematicModeVehicleToFollow.transform).position;
			}
			Vector3 vector2 = vector - _camera.transform.position;
			vector2.z = 0f;
			float num = 1f;
			if (num > _cinematicModeSpeed)
			{
				_cinematicModeSpeed += deltaTime * _visualConstantsData.CinematicCameraAccelerationWhenChangingAgent;
				if (_cinematicModeSpeed > num)
				{
					_cinematicModeSpeed = num;
				}
			}
			_durationSpentOnCurrentMode += deltaTime;
			_camera.transform.position += vector2 * Mathf.Clamp(_cinematicModeSpeed * Time.deltaTime * _visualConstantsData.CinematicCameraMoveSpeed, 0f, 1f);
			float num2 = ((_cinematicModeState == CinematicModeState.ExitingMode) ? DesiredZoom : _visualConstantsData.ZoomLevelsCameraMin[_cinematicZoomIndex]) - _camera.OrthographicSize;
			_camera.OrthographicSize += num2 * Time.deltaTime * _visualConstantsData.CinematicCameraZoomSpeed * _cinematicModeSpeed;
			if (_cinematicModeState == CinematicModeState.ExitingMode && num2 <= 0.01f && vector2.sqrMagnitude <= 0.01f)
			{
				_cinematicModeState = CinematicModeState.Off;
			}
		}

		private void TryAssignNextAvailableVehicle()
		{
			List<TrainView> views = _viewClient.GetViews<TrainView>();
			if (_cinematicModeTrainToFollow == null && views.Count > 0)
			{
				Vector3 vector = views[0].CenterTransform.position - _camera.transform.position;
				vector.z = 0f;
				float magnitude = vector.magnitude;
				magnitude -= _visualConstantsData.DistanceAtWhichToLowerChanceToSelectTrain;
				float num = Mathf.Lerp(1f, 0.25f, magnitude / _visualConstantsData.DistanceAtWhichToLowerChanceToSelectTrain);
				float num2 = UnityEngine.Random.Range(0f, 1f);
				float num3 = _visualConstantsData.ChanceToSelectTrain * num;
				if (num2 < num3)
				{
					_cinematicModeTrainToFollow = views[0];
					_cinematicModeState = CinematicModeState.FollowingTrain;
					_cinematicModeVehicleToFollow = null;
					return;
				}
			}
			else
			{
				_cinematicModeTrainToFollow = null;
			}
			List<VehicleView> list = new List<VehicleView>();
			List<VehicleView> list2 = new List<VehicleView>();
			foreach (VehicleView view in _viewClient.GetViews<VehicleView>())
			{
				if (view.Model.IsDrivingToDestination && view != _cinematicModeVehicleToFollow)
				{
					list.Add(view);
				}
				else if (view.Model.IsAvailableAtHouse && view.Model.house.FirstWaitingVehicle == view.Model)
				{
					list2.Add(view);
				}
			}
			if (list.Count > 0)
			{
				_cinematicModeVehicleToFollow = list[UnityEngine.Random.Range(0, list.Count)];
				_cinematicModeState = CinematicModeState.AwaitingJourney;
				return;
			}
			if (list2.Count > 0)
			{
				_cinematicModeVehicleToFollow = list2[UnityEngine.Random.Range(0, list2.Count)];
				_cinematicModeState = CinematicModeState.AwaitingJourney;
				return;
			}
			if (views.Count > 0)
			{
				_cinematicModeTrainToFollow = views[0];
				_cinematicModeState = CinematicModeState.FollowingTrain;
				return;
			}
			List<VehicleView> views2 = _viewClient.GetViews<VehicleView>();
			if (views2.Count > 0)
			{
				_cinematicModeVehicleToFollow = views2[0];
				_cinematicModeState = CinematicModeState.AwaitingJourney;
			}
			else
			{
				if (_cinematicModeNoCarsMessage != null)
				{
					_simulation.RemoveModel(_cinematicModeNoCarsMessage);
				}
				_cinematicModeNoCarsMessage = _city.Scope.Get<AnchoredMessageModel>();
				_cinematicModeNoCarsMessage.InitializeWithScreenAnchor(StringId.CinematicMode_ErrorMessage_NoCarsToFollow, MessageAnchorOffset, CameraLayer.Overlay);
				_simulation.AddModel(_cinematicModeNoCarsMessage);
				_cinematicModeState = CinematicModeState.Off;
			}
			Diagnostics.Log.Warn("CameraView", "We couldn't find a valid car or train to cinematic mode select! Maybe there's no trains and nothing is connected.");
		}

		private void ApplyDebugPanAndZoom()
		{
			Transform transform = _camera.transform;
			float num = 5f;
			if (_camera.OrthographicSize < 10f)
			{
				num = Mathf.Lerp(5f, 0.5f, Easings.QuadraticEaseOut(1f - Mathf.Clamp01(_camera.OrthographicSize / 10f)));
			}
			Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			Vector3 worldFromScreen = _camera.GetWorldFromScreen(screenPos);
			float num2 = 0f - Input.mouseScrollDelta.y * num * Time.deltaTime;
			float num3 = DesiredZoom + _debugControlsZoomOffset;
			if (num3 >= 0.1f || (num3 < 0.1f && num2 >= 0f))
			{
				num3 += num2;
				_debugControlsZoomOffset += num2;
			}
			_camera.OrthographicSize = ((num3 >= 0.1f) ? num3 : 0.1f);
			Vector2 vector = _camera.GetWorldFromScreen(screenPos) - worldFromScreen;
			transform.position -= new Vector3(vector.x, vector.y, 0f);
			Vector3 worldFromScreen2 = _camera.GetWorldFromScreen(screenPos);
			if (Input.GetMouseButtonDown(2))
			{
				_debugControlsLastMouseWorldPosition = worldFromScreen2;
			}
			if (Input.GetMouseButton(2))
			{
				Vector3 vector2 = _debugControlsLastMouseWorldPosition - worldFromScreen2;
				transform.position += vector2;
				_debugControlsLastMouseWorldPosition = worldFromScreen2 + vector2;
			}
			transform.rotation = Quaternion.Euler(0f, 0f, DebugRotation);
		}

		public void SetDebugZoom(float zoom)
		{
			_camera.OrthographicSize = zoom;
			_debugControlsZoomOffset = zoom - DesiredZoom;
		}

		public void UpdateMaxZoom()
		{
			RectFixed clientPlayableAreaAtZoom = _city.GetClientPlayableAreaAtZoom((Fix64)FixedZoom);
			UpdateMaxZoom(clientPlayableAreaAtZoom);
		}

		private void UpdateMaxZoom(RectFixed playableArea)
		{
			Vector2 vector = new Vector2(0f, 0f);
			new Vector2(0f, 0f);
			GameObject gameObject = _gameUI.playableArea.gameObject;
			while (gameObject != null)
			{
				if (gameObject.TryGetComponent<CanvasScaler>(out var _))
				{
					vector = gameObject.GetComponent<RectTransform>().rect.size;
					break;
				}
				gameObject = gameObject.transform.parent.gameObject;
			}
			Vector2 size = _gameUI.playableArea.rect.size;
			Vector2 vector2 = vector / size;
			float a = (float)playableArea.height * vector2.y;
			float b = (float)playableArea.width * vector2.x * (vector.y / vector.x);
			MaxZoom = Mathf.Max(a, b) * 0.5f;
		}

		public float GetInterpolationSpeed()
		{
			return _interpolationType switch
			{
				CameraInterpType.Default => 0.98f, 
				CameraInterpType.PlayerPanning => 0.98f, 
				CameraInterpType.PlayerZooming => 0.98f, 
				CameraInterpType.TileFocus => 0.35f, 
				CameraInterpType.PanToAlign => 0.1f, 
				CameraInterpType.Resetting => 0.35f, 
				_ => 0.98f, 
			};
		}

		public Vector2 GetCameraOffsetToFitPlayableArea(float zoom, Vector3[] uiPlayableAreaCorners)
		{
			Vector2 vector = uiPlayableAreaCorners[0];
			Vector2 vector2 = new Vector2(uiPlayableAreaCorners[2].x - uiPlayableAreaCorners[0].x, uiPlayableAreaCorners[2].y - uiPlayableAreaCorners[0].y);
			Vector2 vector3 = new Vector2(vector.x + vector2.x * 0.5f, vector.y + vector2.y * 0.5f);
			_gameUI.GetRectTransform().GetWorldCorners(ParentCorners);
			Vector2 vector4 = ParentCorners[0];
			Vector2 vector5 = new Vector2(ParentCorners[2].x - ParentCorners[0].x, ParentCorners[2].y - ParentCorners[0].y);
			Vector2 vector6 = new Vector2(vector4.x + vector5.x * 0.5f, vector4.y + vector5.y * 0.5f);
			float num = playerOrthoZoom * 2f / vector5.x;
			return (vector6 - vector3) * num;
		}

		public void ResetPlayerViewport()
		{
			_interpolationType = CameraInterpType.Resetting;
			playerOrthoZoom = MaxZoom;
			playerZoomedIn = false;
			_panX.RawValue = 0f;
			_panY.RawValue = 0f;
			IsFocussedIn = false;
			_editMenuFocusPoint = Vector3.zero;
			_isPlayerPanning = false;
			_setPanToCenter = false;
			_includeSafeAreaOffsetInZoom = false;
			this.OnCameraZoomLevelChanged?.Invoke();
		}

		public void ApplyPlayerPanPosition(Vector2 worldPosition, Vector2 screenPosition)
		{
			_interpolationType = CameraInterpType.PlayerPanning;
			Vector2 vector = new Vector2(_camera.Width, _camera.Height);
			Vector2 vector2 = screenPosition - vector * 0.5f;
			Vector2 vector3 = worldPosition - vector2 * (_camera.OrthographicSize / (vector.y * 0.5f));
			_panX.RawValue = vector3.x;
			_panX.Hold();
			_panY.RawValue = vector3.y;
			_panY.Hold();
			_isPlayerPanning = true;
		}

		public void ReleasePlayerPan()
		{
			if (_editMenuFocusPointApplied)
			{
				FocusOnWorldPositionWithoutZoom(_editMenuFocusPoint);
				return;
			}
			_panX.SpringBackToExtents();
			_panY.SpringBackToExtents();
		}

		public void SetCinematicZoomLevel(int newZoomLevel)
		{
			if (IsInCinematicMode)
			{
				if (newZoomLevel < 0 || newZoomLevel > ZoomLevelCount - 1)
				{
					_cinematicZoomIndex = Mathf.Clamp(newZoomLevel, 0, ZoomLevelCount - 1);
					return;
				}
				_cinematicZoomIndex = newZoomLevel;
				playerOrthoZoom = _visualConstantsData.ZoomLevelsCameraMin[_cinematicZoomIndex];
				playerOrthoZoom = Mathf.Min(playerOrthoZoom, MinZoom);
			}
		}

		public void FocusOnWorldPosition(Vector3 focusPosition, CameraFocusOffsetType offsetType = CameraFocusOffsetType.FocusOnMiddle)
		{
			_interpolationType = CameraInterpType.TileFocus;
			Log.Info("Focusing on world position {0}, on tile {1}", focusPosition, _tilemapView.GetTileCoordinatesFromWorldPosition(focusPosition));
			playerOrthoZoom = Mathf.Min(playerOrthoZoom, MinZoom);
			if (!playerZoomedIn)
			{
				this.OnCameraZoomLevelChanged?.Invoke();
			}
			playerZoomedIn = true;
			IsFocussedIn = true;
			if (playerOrthoZoom < MinZoom)
			{
				_setPanToCenter = true;
				_includeSafeAreaOffsetInZoom = true;
			}
			else
			{
				switch (offsetType)
				{
				case CameraFocusOffsetType.FocusOnMiddle:
					_panX.RawValue = focusPosition.x;
					_panY.RawValue = focusPosition.y;
					_setPanToCenter = false;
					_includeSafeAreaOffsetInZoom = false;
					break;
				case CameraFocusOffsetType.MaintainScreenPosition:
				{
					Vector2 screenFromWorld = _camera.GetScreenFromWorld(focusPosition);
					float orthographicSize = _camera.OrthographicSize;
					Vector3 position = _camera.transform.position;
					_camera.OrthographicSize = MinZoom;
					_camera.SetPosition(focusPosition);
					Vector3 vector = _camera.GetWorldFromScreen(screenFromWorld) - focusPosition;
					_camera.OrthographicSize = orthographicSize;
					_camera.SetPosition(position);
					Vector2 vector2 = focusPosition - vector;
					_panX.RawValue = vector2.x;
					_panY.RawValue = vector2.y;
					_setPanToCenter = false;
					_includeSafeAreaOffsetInZoom = false;
					break;
				}
				}
			}
			_panX.Hold();
			_panY.Hold();
		}

		public void SetEditMenuFocusPoint(Vector3 focusPosition)
		{
			_editMenuFocusPoint = focusPosition;
			if (_editMenuFocusPointApplied)
			{
				FocusOnWorldPositionWithoutZoom(focusPosition);
				return;
			}
			_interpolationType = CameraInterpType.TileFocus;
			IsFocussedIn = false;
			_panX.RawValue = 0f;
			_panY.RawValue = 0f;
		}

		public void FocusOnWorldPositionWithoutZoom(Vector3 focusPosition, CameraFocusOffsetType offsetType = CameraFocusOffsetType.FocusOnMiddle)
		{
			_interpolationType = CameraInterpType.TileFocus;
			Log.Info("Focusing on world position {0}, on tile {1}", focusPosition, _tilemapView.GetTileCoordinatesFromWorldPosition(focusPosition));
			playerZoomedIn = false;
			IsFocussedIn = true;
			_includeSafeAreaOffsetInZoom = false;
			switch (offsetType)
			{
			case CameraFocusOffsetType.FocusOnMiddle:
				_panX.RawValue = focusPosition.x;
				_panY.RawValue = focusPosition.y;
				break;
			case CameraFocusOffsetType.MaintainScreenPosition:
			{
				Vector2 screenFromWorld = _camera.GetScreenFromWorld(focusPosition);
				Vector3 position = _camera.transform.position;
				_camera.SetPosition(focusPosition);
				Vector3 vector = _camera.GetWorldFromScreen(screenFromWorld) - focusPosition;
				_camera.SetPosition(position);
				Vector2 vector2 = focusPosition - vector;
				_panX.RawValue = vector2.x;
				_panY.RawValue = vector2.y;
				break;
			}
			}
			_panX.Hold();
			_panY.Hold();
		}

		public void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			if (newInputType != DeviceInputType.Touch && IsFocussedIn)
			{
				ResetPlayerViewport();
			}
		}
	}
}
