using System;
using System.Collections.Generic;
using Assets.Scripts.Cameras;
using Assets.Scripts.Craft;
using DG.Tweening;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerCameraScript : MonoBehaviour, IDesignerCamera
	{
		public delegate void CameraFocusDelegate(IPartScript partScript);

		public delegate void CameraMoveDelegate(Vector2 rotation, Vector2 pan, float zoomAmount);

		public delegate void CameraViewDelegate(DesignerCameraViewDirection viewDirection);

		private List<Camera> _configurableFovCameras = new List<Camera>();

		private DesignerScript _designer;

		private DesignerSettings _settings;

		private Vector3 _targetPosition;

		private Vector2 _targetRotationAngles = Vector2.zero;

		private float _targetZoom;

		public Camera Camera { get; private set; }

		public Transform CameraTarget { get; private set; }

		public float CurrentZoom => _targetZoom;

		public float FieldOfView
		{
			get
			{
				return _configurableFovCameras[0].fieldOfView;
			}
			set
			{
				foreach (Camera configurableFovCamera in _configurableFovCameras)
				{
					configurableFovCamera.fieldOfView = value;
				}
			}
		}

		public Transform Transform => base.transform;

		public DesignerCameraViewDirection ViewDirection { get; private set; }

		public event CameraFocusDelegate CameraFocusOnPart;

		public event CameraMoveDelegate CameraMoved;

		public event CameraViewDelegate CameraViewDirectionSet;

		public void FocusOnPart(IPartScript partScript)
		{
			SetTargetPosition(partScript.Transform.position);
			this.CameraFocusOnPart?.Invoke(partScript);
		}

		public void Initialize(DesignerScript designerScript)
		{
			_designer = designerScript;
			_settings = Game.Instance.Settings.Game.Designer;
			Camera = GetComponent<Camera>();
			CameraTarget = base.transform.parent;
		}

		public void Move(Vector2 direction)
		{
			Move(new Vector3(direction.x, direction.y, 0f));
		}

		public void Move(Vector3 direction)
		{
			ViewDirection = DesignerCameraViewDirection.None;
			Vector3 vector = Camera.transform.right * direction.x + Camera.transform.up * direction.y + Camera.transform.forward * direction.z;
			float num = CurrentZoom / 30f * _settings.PanSensitivity.Value;
			_targetPosition += vector * num;
			this.CameraMoved?.Invoke(Vector2.zero, direction, 0f);
		}

		public void MoveUpDown(float distance)
		{
			Move(Camera.transform.InverseTransformDirection(new Vector3(0f, distance, 0f)));
		}

		public void Rotate(Vector2 rotation)
		{
			ViewDirection = DesignerCameraViewDirection.None;
			_targetRotationAngles = LimitRotation(_targetRotationAngles + rotation * _settings.RotateSensitivity.Value);
			this.CameraMoved?.Invoke(rotation, Vector2.zero, 0f);
		}

		public Ray ScreenPointToRay(Vector2 screenCoordinates)
		{
			return Utilities.ScreenPointToRay(Camera, screenCoordinates);
		}

		public void SetTargetPosition(Vector3 position, float duration = 0.5f)
		{
			ViewDirection = DesignerCameraViewDirection.None;
			DOTween.To(() => _targetPosition, delegate(Vector3 p)
			{
				_targetPosition = p;
			}, position, duration);
		}

		public void SetTargetRotation(Vector2 rotation, float duration = 0.5f)
		{
			ViewDirection = DesignerCameraViewDirection.None;
			rotation = LimitRotation(rotation);
			DOTween.To(() => _targetRotationAngles, delegate(Vector2 p)
			{
				_targetRotationAngles = p;
			}, rotation, duration);
		}

		public void SetTargetZoom(float zoom, float duration = 0.5f)
		{
			DOTween.To(() => _targetZoom, delegate(float p)
			{
				_targetZoom = p;
			}, zoom, duration);
		}

		public void SetViewDirection(DesignerCameraViewDirection viewDirection, float duration = 0.5f)
		{
			CraftScript obj = _designer.CraftScript as CraftScript;
			obj.CalculateStartingBounds();
			Transform centerOfMass = _designer.CraftScript.CenterOfMass;
			Vector3 vector = obj.Data.InitialBoundsMax + centerOfMass.position;
			Vector3 vector2 = obj.Data.InitialBoundsMin + centerOfMass.position;
			Vector3 position = (vector + vector2) / 2f;
			Vector3 size = obj.Data.Size;
			float num = 0f;
			float num2 = 0f;
			Vector2 rotation = Vector2.one;
			switch (viewDirection)
			{
			case DesignerCameraViewDirection.Front:
				rotation = new Vector2(0f, 180f);
				num = Mathf.Max(size.x, size.y);
				num2 = size.z / 2f;
				break;
			case DesignerCameraViewDirection.Back:
				rotation = new Vector2(0f, 0f);
				num = Mathf.Max(size.x, size.y);
				num2 = size.z / 2f;
				break;
			case DesignerCameraViewDirection.Left:
				rotation = new Vector2(0f, 90f);
				num = Mathf.Max(size.z, size.y);
				num2 = size.x / 2f;
				break;
			case DesignerCameraViewDirection.Right:
				rotation = new Vector2(0f, -90f);
				num = Mathf.Max(size.z, size.y);
				num2 = size.x / 2f;
				break;
			case DesignerCameraViewDirection.Top:
				rotation = new Vector2(90f, 180f);
				num = Mathf.Max(size.x, size.z);
				num2 = size.y / 2f;
				break;
			case DesignerCameraViewDirection.Bottom:
				rotation = new Vector2(-90f, 180f);
				num = Mathf.Max(size.x, size.z);
				num2 = size.y / 2f;
				break;
			case DesignerCameraViewDirection.Showcase:
				rotation = new Vector2(30f, 210f);
				num = Mathf.Max(size.x, size.z);
				num2 = size.y;
				break;
			case DesignerCameraViewDirection.None:
				return;
			}
			float num3 = num / (Mathf.Tan(Camera.fieldOfView / 2f * (MathF.PI / 180f)) * 2f) * 1.25f + num2;
			if (num3 < 5f)
			{
				num3 = 5f;
			}
			SetTargetPosition(position, duration);
			SetTargetZoom(num3, duration);
			SetTargetRotation(rotation, duration);
			ViewDirection = viewDirection;
			this.CameraViewDirectionSet?.Invoke(viewDirection);
		}

		public void Zoom(float zoomPercentage)
		{
			float num = (zoomPercentage - 1f) * _settings.ZoomSensitivity.Value;
			float value = _targetZoom * (1f + num);
			value = Mathf.Clamp(value, 0.5f, 500f);
			float zoomAmount = value - _targetZoom;
			_targetZoom = value;
			this.CameraMoved?.Invoke(Vector2.zero, Vector2.zero, zoomAmount);
		}

		protected virtual void Start()
		{
			_targetZoom = 0f - Camera.transform.localPosition.z;
			_targetPosition = CameraTarget.position;
			Vector3 eulerAngles = CameraTarget.rotation.eulerAngles;
			_targetRotationAngles = LimitRotation(new Vector2(eulerAngles.x, eulerAngles.y));
			SceneCameraScript[] array = UnityEngine.Object.FindObjectsOfType<SceneCameraScript>();
			foreach (SceneCameraScript sceneCameraScript in array)
			{
				if (sceneCameraScript.UseConfigurableFOV)
				{
					_configurableFovCameras.Add(sceneCameraScript.Camera);
				}
			}
		}

		protected virtual void Update()
		{
			float num = Mathf.Clamp(Time.unscaledDeltaTime, 0f, 0.025f);
			Vector3 localPosition = Camera.transform.localPosition;
			localPosition.z = Mathf.Lerp(localPosition.z, 0f - _targetZoom, Mathf.Clamp01(num * 5f));
			Camera.transform.localPosition = localPosition;
			Quaternion b = Quaternion.Euler(_targetRotationAngles.x, _targetRotationAngles.y, 0f);
			CameraTarget.SetPositionAndRotation(Vector3.Lerp(CameraTarget.position, _targetPosition, Mathf.Clamp01(num * 20f)), Quaternion.Lerp(CameraTarget.rotation, b, Mathf.Clamp01(num * 15f)));
		}

		private static Vector2 LimitRotation(Vector2 rotation)
		{
			rotation.x = Utilities.LimitAngle180(rotation.x);
			rotation.y = Utilities.LimitAngle180(rotation.y);
			return rotation;
		}
	}
}
