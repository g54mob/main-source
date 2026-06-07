using System;
using UnityEngine;

namespace GPUInstancerPro
{
	[RequireComponent(typeof(Camera))]
	[DisallowMultipleComponent]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_Camera")]
	public class GPUICamera : MonoBehaviour
	{
		[SerializeField]
		private bool _enableOcclusionCulling = true;

		[SerializeField]
		[Range(0f, 10f)]
		private float _dynamicOcclusionOffsetIntensity = 1f;

		[NonSerialized]
		internal Camera _cameraRef;

		[NonSerialized]
		internal GPUICameraData _cameraData;

		[NonSerialized]
		private bool _isInitialized;

		private void OnEnable()
		{
			if (!_isInitialized)
			{
				Initialize();
			}
		}

		private void OnDisable()
		{
			Dispose();
		}

		public void Initialize()
		{
			if (_cameraRef == null)
			{
				_cameraRef = GetComponent<Camera>();
			}
			bool flag = _cameraData != null;
			if (!(_isInitialized && flag))
			{
				if (flag)
				{
					Dispose();
				}
				_cameraData = new GPUICameraData(_cameraRef);
				GPUIRenderingSystem.AddCameraData(_cameraData);
				if (_enableOcclusionCulling)
				{
					_cameraData.autoInitializeOcclusionCulling = true;
				}
				_isInitialized = true;
				SetDynamicOcclusionOffsetIntensity(_dynamicOcclusionOffsetIntensity);
				if (!base.enabled)
				{
					base.enabled = true;
				}
			}
		}

		public void Dispose()
		{
			_isInitialized = false;
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.CameraDataProvider.RemoveCamera(_cameraRef);
			}
			if (_cameraData != null)
			{
				_cameraData.Dispose();
			}
			_cameraData = null;
		}

		public GPUICameraData GetCameraData()
		{
			return _cameraData;
		}

		public Camera GetCamera()
		{
			if (_cameraRef == null)
			{
				_cameraRef = GetComponent<Camera>();
			}
			return _cameraRef;
		}

		public void SetOcclusionCullingEnabled(bool enabled)
		{
			_enableOcclusionCulling = enabled;
			if (_cameraData != null)
			{
				if (enabled)
				{
					_cameraData.autoInitializeOcclusionCulling = true;
					return;
				}
				_cameraData.autoInitializeOcclusionCulling = false;
				_cameraData.DisableOcclusionCulling();
			}
		}

		public void SetDynamicOcclusionOffsetIntensity(float intensity)
		{
			_dynamicOcclusionOffsetIntensity = intensity;
			if (_cameraData != null)
			{
				_cameraData.SetDynamicOcclusionOffsetIntensity(intensity);
			}
		}
	}
}
