using System;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.PlanetStudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Input;
using ModApi.Input.Events;
using ModApi.Ioc;
using ModApi.Settings;
using UnityEngine;
using UnityEngine.EventSystems;
using Vectrosity;

namespace Assets.Scripts.Flight.MapView
{
	public class MapCameraScript : MonoBehaviour, ICurrentCameraTarget
	{
		public delegate void CameraRenderHandler();

		public class CameraRepositionedEventArgs : EventArgs
		{
			public MapCameraScript MapCameraScript { get; private set; }

			public CameraRepositionedEventArgs(MapCameraScript mapCameraScript)
			{
				MapCameraScript = mapCameraScript;
			}
		}

		private class CameraTweenInfo
		{
			private const float FastPositionResponsiveness = 10f;

			private const float FastRotationResponsiveness = 1000f;

			private const float MediumPositionResponsiveness = 10f;

			private const float MediumRotationResponsiveness = 10f;

			private const float NormalCameraPositionResponsiveness = 10f;

			private const float NormalCameraRotationResponsiveness = 1000f;

			private TweenerCore<float, float, FloatOptions> _positionResponsivenessTween;

			private TweenerCore<float, float, FloatOptions> _rotationResponsivenessTween;

			public float PositionResponsiveness { get; private set; } = 10f;

			public float RotationResponsiveness { get; private set; } = 10f;

			public void CompleteTweens()
			{
				if (_positionResponsivenessTween != null && !_positionResponsivenessTween.IsComplete())
				{
					_positionResponsivenessTween.Complete();
				}
				if (_rotationResponsivenessTween != null && !_rotationResponsivenessTween.IsComplete())
				{
					_rotationResponsivenessTween.Complete();
				}
			}

			public void SetResponsivenessAndTweenBack(CameraTransitionSpeed transitionSpeed)
			{
				switch (transitionSpeed)
				{
				case CameraTransitionSpeed.Medium:
				case CameraTransitionSpeed.Default:
					SetResponsivenessAndTweenBack(SetMediumResponsiveness);
					break;
				case CameraTransitionSpeed.Fast:
					SetResponsivenessAndTweenBack(SetFastResponsiveness);
					break;
				default:
					Debug.LogError($"Unsupported transition speed: {transitionSpeed}");
					break;
				}
			}

			private void SetFastResponsiveness()
			{
				PositionResponsiveness = 10f;
				RotationResponsiveness = 1000f;
			}

			private void SetMediumResponsiveness()
			{
				PositionResponsiveness = 10f;
				RotationResponsiveness = 10f;
			}

			private void SetResponsivenessAndTweenBack(Action setResponsiveness)
			{
				CompleteTweens();
				setResponsiveness();
				_positionResponsivenessTween = DOTween.To(() => PositionResponsiveness, delegate(float x)
				{
					PositionResponsiveness = x;
				}, 10f, 4f).SetEase(Ease.InOutQuint);
				_rotationResponsivenessTween = DOTween.To(() => RotationResponsiveness, delegate(float x)
				{
					RotationResponsiveness = x;
				}, 1000f, 4f).SetEase(Ease.InOutQuint);
			}
		}

		private Camera _camera;

		private ICameraFocusable _cameraTarget;

		private Vector2 _deltaRotation = new Vector2(-30f, -30f);

		private float _distanceFromTarget;

		private bool _firstTargetSet = true;

		private InputResponder _inputResponder = new InputResponder("MapCameraScript");

		private IItemRegistry _itemRegistry;

		private IMapView _mapView;

		private IMapViewCoordinateConverter _mapViewCoordinateConverter;

		private float _maxNearClip;

		private double _maxZoomDistance;

		private float _medNearClip;

		private float _medNearClipStartDist;

		private double _minZoomDistance;

		private MouseInputSettingsFlight _mouseInputSettings;

		private IPlayerCraftProvider _playerCraftProvider;

		private Vector3 _positionOffset;

		private Vector3 _prevDeltaVec;

		private CameraTweenInfo _tweenInfo;

		public Camera Camera => _camera;

		public float CurrentZoomPercent
		{
			get
			{
				float num = (float)(MaxZoomDistance - MinZoomDistance);
				float num2 = (float)((double)DistanceFromTarget - MinZoomDistance);
				return 1f - num2 / num;
			}
		}

		public float DistanceFromTarget
		{
			get
			{
				return _distanceFromTarget;
			}
			private set
			{
				bool num = _distanceFromTarget != value;
				_distanceFromTarget = value;
				if (num)
				{
					SetCameraClipPlanes();
				}
			}
		}

		public float DistanceFromTargetsAssociatedPlanet { get; private set; }

		public InputResponder InputResponder => _inputResponder;

		public bool IsOffCenter => !(_positionOffset == Vector3.zero);

		public double MaxZoomDistance
		{
			get
			{
				return _maxZoomDistance;
			}
			set
			{
				_maxZoomDistance = value;
				_camera.farClipPlane = (float)value * 10f;
			}
		}

		public double MinZoomDistance => _minZoomDistance;

		public ICameraFocusable Target => _cameraTarget;

		public MapPlanet TargetsAssociatedPlanet { get; private set; }

		public float ZoomDistance { get; private set; } = 75f;

		protected bool CameraUpDownZoomSwapped { get; private set; }

		private double ZoomStep => (MaxZoomDistance - MinZoomDistance) / 50.0;

		public event CameraRenderHandler PostRender;

		public event CameraRenderHandler PreRender;

		public event CurrentCameraTargetHandler TargetChanged;

		public static MapCameraScript Create(IIocContainer ioc, IMapViewContext mapViewContext, GameObject gameObject, Camera mapCamera, double maxZoomDistance)
		{
			MapCameraScript mapCameraScript = gameObject.AddComponent<MapCameraScript>();
			mapCameraScript.Initialize(ioc, mapViewContext, mapCamera, maxZoomDistance);
			return mapCameraScript;
		}

		public bool OnScroll(PointerEventData eventData)
		{
			if (Game.Instance.UserInterface.ActiveDialog == null || Game.Instance.UserInterface.ActiveDialog.AllowCameraZoom)
			{
				bool inverted = false;
				Vector2 scrollDelta = eventData.scrollDelta;
				if (scrollDelta.x != 0f)
				{
					if (_mouseInputSettings.CanZoomCamera(InputAxis.ScrollHorizontal, out inverted))
					{
						float zoomInput = scrollDelta.x * (float)(inverted ? (-2) : 2);
						ZoomDistance = AdjustZoomDistance(zoomInput, (float)MinZoomDistance, (float)MaxZoomDistance, ZoomDistance);
					}
					else if (_mouseInputSettings.CanRotateCamera(InputAxis.ScrollHorizontal, out inverted))
					{
						float num = 15f * (float)((!inverted) ? 1 : (-1));
						Rotate(new Vector2(0f, scrollDelta.x * num));
					}
					else if (_mouseInputSettings.CanPanCamera(InputAxis.ScrollHorizontal, out inverted))
					{
						float num2 = 20f * (float)((!inverted) ? 1 : (-1));
						Pan(new Vector2((0f - scrollDelta.x) * num2, 0f));
					}
				}
				if (scrollDelta.y != 0f)
				{
					if (_mouseInputSettings.CanZoomCamera(InputAxis.ScrollVertical, out inverted))
					{
						float zoomInput2 = scrollDelta.y * (float)((!inverted) ? 1 : (-1));
						ZoomDistance = AdjustZoomDistance(zoomInput2, (float)MinZoomDistance, (float)MaxZoomDistance, ZoomDistance);
					}
					else if (_mouseInputSettings.CanRotateCamera(InputAxis.ScrollVertical, out inverted))
					{
						float num3 = 5f * (float)((!inverted) ? 1 : (-1));
						Rotate(new Vector2((0f - scrollDelta.y) * num3, 0f));
					}
					else if (_mouseInputSettings.CanPanCamera(InputAxis.ScrollVertical, out inverted))
					{
						float num4 = 20f * (float)((!inverted) ? 1 : (-1));
						Pan(new Vector2(0f, (0f - scrollDelta.y) * num4));
					}
				}
			}
			return false;
		}

		public void RecenterOnTarget()
		{
			_positionOffset = Vector3.zero;
		}

		public void SetRotationAndZoom(Vector2 rotation, float zoom)
		{
			_deltaRotation = rotation;
			ZoomDistance = zoom;
		}

		public void SetTarget(ICameraFocusable target, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition)
		{
			if (target != null)
			{
				repositionCamDuringTransition = false;
				if (target != _cameraTarget)
				{
					RemoveTargetEvents();
					_cameraTarget = target;
					_cameraTarget.Destroyed += OnCameraTargetDestroyed;
					SetTargetsAssociatedPlanet();
					_positionOffset = Vector3.zero;
					_minZoomDistance = _cameraTarget.MinZoomDistance;
					UpdateCamera();
					float zoomDistance = ZoomDistance;
					ZoomDistance = Mathf.Clamp(ZoomDistance, (float)MinZoomDistance, (float)MaxZoomDistance);
					bool flag = zoomDistance != ZoomDistance;
					_prevDeltaVec = Camera.transform.position - _cameraTarget.Position;
					DistanceFromTarget = Vector3.Distance(Camera.transform.position, _cameraTarget.Position);
					if (!repositionCamDuringTransition && !flag)
					{
						if (_firstTargetSet)
						{
							ZoomDistance = (float)MinZoomDistance * 10f;
						}
						else
						{
							ZoomDistance = DistanceFromTarget;
						}
						Vector3 eulerAngles = Quaternion.FromToRotation((_cameraTarget.Position - _camera.transform.position).normalized, Vector3.forward).eulerAngles;
						_deltaRotation = new Vector2((Mathf.Abs(eulerAngles.x) > 90f) ? (eulerAngles.x - 360f) : eulerAngles.x, eulerAngles.y);
					}
					if (_cameraTarget is MapPlayerCraft)
					{
						((_cameraTarget as MapPlayerCraft).OrbitInfo.OrbitNode as CraftNode).ChangedSoI += OnTargetChangedSoi;
					}
					_tweenInfo.SetResponsivenessAndTweenBack(transitionSpeed);
					this.TargetChanged?.Invoke(_cameraTarget);
				}
				else
				{
					_positionOffset = Vector3.zero;
				}
				if (_firstTargetSet)
				{
					_firstTargetSet = false;
				}
			}
			else
			{
				MapPlayerCraft mapPlayerCraft = _playerCraftProvider?.PlayerCraft;
				if (mapPlayerCraft != null)
				{
					SetTarget(mapPlayerCraft, transitionSpeed, repositionCamDuringTransition);
				}
			}
		}

		public void UpdateCamera()
		{
			Vector3 vector = _cameraTarget.Position + _positionOffset;
			Camera.transform.position = vector + _prevDeltaVec;
			DistanceFromTarget = Vector3.Distance(Camera.transform.position, vector);
			DistanceFromTargetsAssociatedPlanet = Vector3.Distance(Camera.transform.position, TargetsAssociatedPlanet.MapPosition);
			IGameInputs inputs = Game.Instance.Inputs;
			if (inputs.CameraSwapUpDownZoom.GetButtonDownIfEnabled())
			{
				CameraUpDownZoomSwapped = !CameraUpDownZoomSwapped;
				if (Game.InFlightScene)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Camera look up/down and zoom swapped.");
				}
				else if (Game.InPlanetStudioScene)
				{
					PlanetStudioScript.Instance.PlanetStudioUI.ShowMessage("Camera look up/down and zoom swapped.");
				}
			}
			Vector2 vector2 = InputRotationMultiplier();
			float axisIfEnabled = inputs.CameraLookLeftRight.GetAxisIfEnabled();
			float num = (CameraUpDownZoomSwapped ? inputs.CameraLookZoom.GetAxisIfEnabled() : inputs.CameraLookUpDown.GetAxisIfEnabled());
			float num2 = (CameraUpDownZoomSwapped ? inputs.CameraLookUpDown.GetAxisIfEnabled() : inputs.CameraLookZoom.GetAxisIfEnabled());
			Vector2 vector3 = new Vector2(num * vector2.x, axisIfEnabled * vector2.y * -1f);
			if (Game.InPlanetStudioScene && !Game.Instance.UserInterface.IgnoreKeyboardInputs)
			{
				bool button = Game.Instance.Inputs.AccelerateMovementModifier.GetButton();
				bool button2 = Game.Instance.Inputs.DecelerateMovementModifier.GetButton();
				Vector3 zero = Vector3.zero;
				if (inputs.MoveCameraLeft.GetButton())
				{
					zero += new Vector3(2f, 0f, 0f);
				}
				else if (inputs.MoveCameraRight.GetButton())
				{
					zero += new Vector3(-2f, 0f, 0f);
				}
				else if (inputs.MoveCameraUp.GetButton())
				{
					zero += new Vector3(0f, -2f, 0f);
				}
				else if (inputs.MoveCameraDown.GetButton())
				{
					zero += new Vector3(0f, 2f, 0f);
				}
				if (inputs.MoveCameraForward.GetButton())
				{
					num2 += 0.1f;
				}
				else if (inputs.MoveCameraBackward.GetButton())
				{
					num2 -= 0.1f;
				}
				Vector2 vector4 = new Vector2(inputs.RotateCameraUp.GetButton() ? (-0.5f) : (inputs.RotateCameraDown.GetButton() ? 0.5f : 0f), inputs.RotateCameraRight.GetButton() ? 0.5f : (inputs.RotateCameraLeft.GetButton() ? (-0.5f) : 0f));
				if (button)
				{
					zero *= 10f;
					num2 *= 10f;
					vector4 *= 5f;
				}
				else if (button2)
				{
					zero /= 10f;
					num2 /= 10f;
					vector4 /= 5f;
				}
				vector3 += vector4;
				if (zero.magnitude > 0f)
				{
					Pan(zero);
				}
			}
			if (!Utilities.CompareVector3s(vector3, Vector2.zero))
			{
				Rotate(vector3);
			}
			if (num2 != 0f && (Game.Instance.UserInterface.ActiveDialog == null || Game.Instance.UserInterface.ActiveDialog.AllowCameraZoom))
			{
				ZoomDistance = AdjustZoomDistance(num2, (float)MinZoomDistance, (float)MaxZoomDistance, ZoomDistance);
			}
			Quaternion quaternion = Quaternion.Euler(0f - _deltaRotation.x, 0f - _deltaRotation.y, 0f);
			Vector3 b = vector - quaternion * Vector3.forward * ZoomDistance;
			Camera.transform.position = Vector3.Lerp(Camera.transform.position, b, _tweenInfo.PositionResponsiveness * Time.unscaledDeltaTime);
			Quaternion b2 = Quaternion.LookRotation(vector - Camera.transform.position);
			Camera.transform.localRotation = Quaternion.Lerp(Camera.transform.localRotation, b2, _tweenInfo.RotationResponsiveness * Time.unscaledDeltaTime);
			_prevDeltaVec = Camera.transform.position - vector;
		}

		protected virtual Vector2 InputRotationMultiplier()
		{
			return new Vector2(-360f, -360f) * Time.unscaledDeltaTime * 0.25f;
		}

		private static float AdjustZoomDistance(float zoomInput, float minZoomDistance, float maxZoomDistance, float oldZoomDistance)
		{
			if (Device.IsOsxRuntime)
			{
				zoomInput = Mathf.Clamp(zoomInput / 2f, -8f, 8f);
			}
			float num = Mathf.Sign(zoomInput);
			zoomInput = Mathf.Abs(zoomInput);
			zoomInput *= 0.1f;
			float num2 = oldZoomDistance * zoomInput * num;
			oldZoomDistance -= num2;
			oldZoomDistance = Mathf.Clamp(oldZoomDistance, minZoomDistance, maxZoomDistance);
			return oldZoomDistance;
		}

		private void Awake()
		{
			_inputResponder.IsResponding = () => base.gameObject.activeInHierarchy;
			_inputResponder.OnDrag = OnDrag;
			_inputResponder.OnPinch = OnPinch;
			_inputResponder.OnScroll = OnScroll;
		}

		private void Initialize(IIocContainer ioc, IMapViewContext mapViewContext, Camera mapCamera, double maxZoomDistance)
		{
			ioc.Register((ICurrentCameraTarget)this, (IContext)mapViewContext);
			_camera = mapCamera;
			_mapView = ioc.Resolve<IMapView>(mapViewContext);
			_mapViewCoordinateConverter = ioc.Resolve<IMapViewCoordinateConverter>(mapViewContext);
			_itemRegistry = ioc.Resolve<IItemRegistry>(mapViewContext);
			_playerCraftProvider = ioc.Resolve<IPlayerCraftProvider>(mapViewContext);
			_maxNearClip = (float)(_mapViewCoordinateConverter.MapScale * 50000000.0);
			_medNearClip = (float)(_mapViewCoordinateConverter.MapScale * 500000.0);
			_medNearClipStartDist = (float)(_mapViewCoordinateConverter.MapScale * 5000000000.0);
			MaxZoomDistance = _mapViewCoordinateConverter.MapScale * maxZoomDistance;
			_tweenInfo = new CameraTweenInfo();
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputFlight;
			if (base.gameObject.activeSelf)
			{
				VectorLine.SetCamera3D(_camera);
			}
		}

		private void OnCameraTargetDestroyed(ICameraFocusable source)
		{
			_ = _cameraTarget;
			ICameraFocusable itemToFocusOnWhenDeleted = source.ItemToFocusOnWhenDeleted;
			if (itemToFocusOnWhenDeleted != null)
			{
				_mapView.SetCameraFocus(itemToFocusOnWhenDeleted, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
			}
		}

		private void OnDestroy()
		{
			RemoveTargetEvents();
		}

		private void OnDisable()
		{
			if (Camera.main != null)
			{
				VectorLine.SetCamera3D(Camera.main);
			}
		}

		private bool OnDrag(PointerEventData eventData)
		{
			bool inverted = false;
			InputButton inputButton = eventData.InputButton();
			if (eventData.IsTouchPrimary() || _mouseInputSettings.CanRotateCamera(inputButton, out inverted))
			{
				float num = 0.25f * (float)((!inverted) ? 1 : (-1));
				Vector2 delta = new Vector2(eventData.delta.y * num, (0f - eventData.delta.x) * num);
				Rotate(delta);
			}
			else if (_mouseInputSettings.CanPanCamera(inputButton, out inverted))
			{
				Pan(eventData.delta * ((!inverted) ? 1 : (-1)));
			}
			else if (_mouseInputSettings.CanZoomCamera(inputButton, out inverted))
			{
				float zoomInput = eventData.delta.y * 0.1f * (float)((!inverted) ? 1 : (-1));
				ZoomDistance = AdjustZoomDistance(zoomInput, (float)MinZoomDistance, (float)MaxZoomDistance, ZoomDistance);
			}
			return true;
		}

		private void OnEnable()
		{
			if (_camera != null)
			{
				VectorLine.SetCamera3D(_camera);
			}
		}

		private bool OnPinch(PinchEventData eventData)
		{
			float num = (eventData.Distance - eventData.DistanceDelta) / eventData.Distance;
			ZoomDistance *= num;
			Pan(eventData.MidpointDelta);
			return true;
		}

		private void OnPostRender()
		{
			this.PostRender?.Invoke();
		}

		private void OnPreRender()
		{
			this.PreRender?.Invoke();
		}

		private void OnTargetChangedSoi(IOrbitNode source)
		{
			SetTargetsAssociatedPlanet();
		}

		private void Pan(Vector2 delta)
		{
			float num = ZoomDistance * 0.001f;
			Vector3 vector = Camera.transform.right * (0f - delta.x) + Camera.transform.up * (0f - delta.y);
			vector *= num;
			_positionOffset += vector;
		}

		private void RemoveTargetEvents()
		{
			if (_cameraTarget != null)
			{
				_cameraTarget.Destroyed -= OnCameraTargetDestroyed;
				if (_cameraTarget is MapPlayerCraft)
				{
					((_cameraTarget as MapPlayerCraft).OrbitInfo.OrbitNode as CraftNode).ChangedSoI -= OnTargetChangedSoi;
				}
			}
		}

		private void Rotate(Vector2 delta, bool additiveRotation = true)
		{
			_tweenInfo.CompleteTweens();
			if (additiveRotation)
			{
				_deltaRotation += delta * 1f;
				_deltaRotation.x = Mathf.Clamp(_deltaRotation.x, -89f, 89f);
			}
			else
			{
				_deltaRotation = delta;
			}
		}

		private void SetCameraClipPlanes()
		{
			float distanceFromTarget = DistanceFromTarget;
			float b = ((!(distanceFromTarget > _medNearClipStartDist)) ? _medNearClip : _maxNearClip);
			_camera.nearClipPlane = Mathf.Min(distanceFromTarget * 0.2f, b);
		}

		private void SetTargetsAssociatedPlanet()
		{
			IPlanetNode planetNode = _cameraTarget.AssociatedPlanet;
			if (planetNode is SoiEncounterPlanetSimNode)
			{
				planetNode = (planetNode as SoiEncounterPlanetSimNode).ReferencePlanet;
			}
			MapPlanet targetsAssociatedPlanet = TargetsAssociatedPlanet;
			TargetsAssociatedPlanet = _itemRegistry.GetPlanet(planetNode);
			targetsAssociatedPlanet?.OnCameraTargetsAssociatedPlanetStateChanged(isCameraTargetsAssociatedPlanet: false);
			TargetsAssociatedPlanet?.OnCameraTargetsAssociatedPlanetStateChanged(isCameraTargetsAssociatedPlanet: true);
			_ = TargetsAssociatedPlanet == null;
		}
	}
}
