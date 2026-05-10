using System;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.DevConsole.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	[DefaultExecutionOrder(-50)]
	[RequireComponent(typeof(Camera))]
	public class MainCamera : MonoSingleton<MainCamera>
	{
		[SerializeField]
		private float _heightUpdateSpeed = 3f;

		private float _planeBaseHeight;

		private float _currentHeight;

		private float _targetHeight;

		private Plane _groundPlane;

		[field: SerializeField]
		public CameraMovements Movements { get; private set; }

		[field: SerializeField]
		public CameraRotation CameraRotation { get; private set; }

		[field: SerializeField]
		public CameraZoom Zoom { get; private set; }

		[field: SerializeField]
		public CameraMouseControls MouseControls { get; private set; }

		[field: SerializeField]
		public float PlaneHeightOffset { get; private set; } = 1f;

		[field: SerializeField]
		public CVarEnumReference<CameraFollowing.LockType> CVarLockType { get; private set; }

		[field: SerializeField]
		public CVarBoolReference CVarTracking { get; private set; }

		public Vector3 GroundPoint { get; private set; }

		public static Camera CameraReference { get; private set; }

		public Quaternion Rotation => Quaternion.Euler(base.transform.eulerAngles.KeepY());

		protected override void SingletonAwake()
		{
			_targetHeight = PlaneHeightOffset + _planeBaseHeight;
			_currentHeight = _targetHeight;
			CameraReference = GetComponent<Camera>();
			_groundPlane = new Plane(Vector3.up, Vector3.up * _currentHeight);
			FindGroundPlanePoint();
			SceneManager.sceneLoaded += SceneManager_sceneLoaded;
		}

		private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
		{
			string text = arg0.name;
			SOCameraParemeters sOCameraParemeters = Resources.Load<SOCameraParemeters>("Scriptables/CameraParameters/" + text);
			if (sOCameraParemeters != null)
			{
				PlaneHeightOffset = sOCameraParemeters.HeightOffset;
				SetHeight(sOCameraParemeters.BaseHeight);
				FindGroundPlanePoint();
				if (sOCameraParemeters.WantModifyRotation)
				{
					CameraRotation.ParamsForThisScene(sOCameraParemeters.Rotate);
				}
				if (sOCameraParemeters.WantModifyMouseClick)
				{
					MouseControls.ParamsForThisScene(sOCameraParemeters.MouseClick);
				}
				if (sOCameraParemeters.WantModifyZoom)
				{
					Zoom.ParamsForThisScene(sOCameraParemeters.Zoom);
				}
				if (sOCameraParemeters.WantModifyMovement)
				{
					Movements.ParamsForThisScene(sOCameraParemeters.Movements);
				}
			}
		}

		protected override void OnSingletonDestroy()
		{
			SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
		}

		public void RenderToTexture(RenderTexture texture)
		{
			CameraReference.targetTexture = texture;
			CameraReference.Render();
			CameraReference.targetTexture = null;
		}

		private void Update()
		{
			UpdateHeight();
			FindGroundPlanePoint();
		}

		public void SetHeight(float p_height)
		{
			_targetHeight = PlaneHeightOffset + p_height;
		}

		public void FindGroundPlanePoint()
		{
			Transform obj = base.transform;
			Vector3 forward = obj.forward;
			Vector3 position = obj.position;
			Ray ray = new Ray(position, forward);
			if (_groundPlane.Raycast(ray, out var enter))
			{
				GroundPoint = position + forward * enter;
			}
		}

		private void UpdateHeight()
		{
			if (!(Math.Abs(_currentHeight - _targetHeight) <= 0.01f))
			{
				float currentHeight = _currentHeight;
				_currentHeight = Mathf.Lerp(_currentHeight, _targetHeight, Time.unscaledDeltaTime * _heightUpdateSpeed);
				float num = _currentHeight - currentHeight;
				_groundPlane = new Plane(Vector3.up, Vector3.up * _currentHeight);
				base.transform.position += Vector3.up * num;
			}
		}
	}
}
