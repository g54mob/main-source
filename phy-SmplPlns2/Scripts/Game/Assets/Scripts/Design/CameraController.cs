using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class CameraController
	{
		public delegate void CameraMoveDelegate(Vector2 rotation, Vector2 pan, float zoomAmount);

		private List<Camera> _cameras = new List<Camera>();

		private GameObject _cameraTarget;

		private float _defaultFarPlane;

		private float _defaultNearPlane;

		private float _maxDistance = 75f;

		public Camera Camera { get; private set; }

		public float CurrentZoom => Camera.transform.localPosition.magnitude;

		public bool IsOrthographic
		{
			get
			{
				return Camera.orthographic;
			}
			set
			{
				if (!Camera.orthographic && value)
				{
					_defaultNearPlane = Camera.nearClipPlane;
					_defaultFarPlane = Camera.farClipPlane;
					_cameras.ForEach(delegate(Camera camera)
					{
						camera.nearClipPlane = -50f;
					});
				}
				else if (Camera.orthographic && !value)
				{
					_cameras.ForEach(delegate(Camera camera)
					{
						camera.nearClipPlane = _defaultNearPlane;
						camera.farClipPlane = _defaultFarPlane;
					});
				}
				_cameras.ForEach(delegate(Camera camera)
				{
					camera.orthographic = value;
				});
			}
		}

		public Vector3 TargetPosition
		{
			get
			{
				return _cameraTarget.transform.position;
			}
			set
			{
				_cameraTarget.transform.position = value;
			}
		}

		public event CameraMoveDelegate CameraMoved;

		public CameraController(Camera camera, GameObject cameraTarget, Camera[] additionalCameras)
		{
			Camera = camera;
			_cameras.Add(camera);
			_cameras.AddRange(additionalCameras);
			_cameraTarget = cameraTarget;
		}

		public void Move(Vector2 direction)
		{
			Move(new Vector3(direction.x, direction.y, 0f));
		}

		public void Move(Vector3 direction)
		{
			Vector3 vector = Camera.transform.right * direction.x + Camera.transform.up * direction.y + Camera.transform.forward * direction.z;
			_cameraTarget.transform.position += vector;
			EnsureCameraIsInBounds();
			if (this.CameraMoved != null)
			{
				this.CameraMoved(Vector2.zero, direction, 0f);
			}
		}

		public void Rotate(Vector2 rotation)
		{
			Camera.transform.RotateAround(_cameraTarget.transform.position, Vector3.up, rotation.x);
			Camera.transform.RotateAround(_cameraTarget.transform.position, Camera.transform.right, rotation.y);
			EnsureCameraIsInBounds();
			if (this.CameraMoved != null)
			{
				this.CameraMoved(rotation, Vector2.zero, 0f);
			}
		}

		public void UpdateOrthographicSize()
		{
			float magnitude = (Camera.transform.position - _cameraTarget.transform.position).magnitude;
			float num = Camera.fieldOfView * (MathF.PI / 180f);
			float height = Mathf.Tan(num / 2f) * magnitude;
			_cameras.ForEach(delegate(Camera camera)
			{
				camera.orthographicSize = height;
			});
		}

		public void Zoom(float amount)
		{
			float num = CurrentZoom / 10f;
			float num2 = amount * num;
			Vector3 normalized = Camera.transform.localPosition.normalized;
			Camera.transform.localPosition -= normalized * num2;
			if (Camera.transform.localPosition.magnitude < 0.05f)
			{
				Camera.transform.localPosition = normalized * 0.05f;
			}
			EnsureCameraIsInBounds();
			if (this.CameraMoved != null)
			{
				this.CameraMoved(Vector2.zero, Vector2.zero, amount);
			}
		}

		private void EnsureCameraIsInBounds()
		{
			float num = _maxDistance;
			if (Game.Instance.Device.IsDesktopBuild)
			{
				num *= 2f;
			}
			Vector3 vector = Camera.transform.position - Designer.Position;
			if (vector.magnitude > num)
			{
				vector = vector.normalized * num;
				Camera.transform.position = vector + Designer.Position;
				Camera.transform.LookAt(_cameraTarget.transform);
			}
		}
	}
}
