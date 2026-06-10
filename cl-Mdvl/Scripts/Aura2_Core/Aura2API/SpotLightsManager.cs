using System;
using UnityEngine;

namespace Aura2API
{
	public class SpotLightsManager
	{
		public static readonly Vector2Int shadowMapSize = new Vector2Int(256, 256);

		public static readonly Vector2Int cookieMapSize = new Vector2Int(256, 256);

		private readonly ObjectsCuller<AuraLight> _culler;

		private SpotLightParameters[] _visibleSpotLightParametersArray;

		public FrustumSettings _frustumSettings;

		private Camera _referenceCamera;

		private ComputeBuffer _emptyBuffer;

		public ComputeBuffer EmptyBuffer
		{
			get
			{
				if (_emptyBuffer == null)
				{
					_emptyBuffer = new ComputeBuffer(1, SpotLightParameters.Size);
				}
				return _emptyBuffer;
			}
		}

		public ComputeBuffer Buffer { get; private set; }

		public bool HasVisibleLights => _culler.HasVisibleObjects;

		public SpotLightsManager(Camera camera, FrustumSettings frustumSettings)
		{
			_referenceCamera = camera;
			_frustumSettings = frustumSettings;
			_culler = new ObjectsCuller<AuraLight>(_referenceCamera, _frustumSettings);
			for (int i = 0; i < AuraCamera.CommonDataManager.LightsCommonDataManager.RegisteredSpotLightsList.Count; i++)
			{
				_culler.Register(AuraCamera.CommonDataManager.LightsCommonDataManager.RegisteredSpotLightsList[i]);
			}
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
			AuraCamera.CommonDataManager.LightsCommonDataManager.OnRegisterSpotLight += LightsCommonDataManager_OnRegisterSpotLight;
			AuraCamera.CommonDataManager.LightsCommonDataManager.OnUnregisterSpotLight += LightsCommonDataManager_OnUnregisterSpotLight;
		}

		private void Camera_onPreRender(Camera camera)
		{
			_culler.Update(camera, _frustumSettings);
			SetupComputeBuffer();
			CollectData();
		}

		private void LightsCommonDataManager_OnRegisterSpotLight(AuraLight auraLight)
		{
			_culler.Register(auraLight);
		}

		private void LightsCommonDataManager_OnUnregisterSpotLight(AuraLight auraLight)
		{
			_culler.Unregister(auraLight);
		}

		private void SetupComputeBuffer()
		{
			if (Buffer == null || _culler.VisibleObjectsCount != Buffer.count)
			{
				DisposeComputeBuffer();
				if (_culler.HasVisibleObjects)
				{
					Buffer = new ComputeBuffer(_culler.VisibleObjectsCount, SpotLightParameters.Size);
					_visibleSpotLightParametersArray = new SpotLightParameters[_culler.VisibleObjectsCount];
				}
				else
				{
					Buffer = null;
				}
			}
		}

		private void SetupBuffers()
		{
			if (Buffer == null || _culler.VisibleObjectsCount != Buffer.count)
			{
				DisposeComputeBuffer();
				if (_culler.HasVisibleObjects)
				{
					Buffer = new ComputeBuffer(_culler.VisibleObjectsCount, SpotLightParameters.Size);
					_visibleSpotLightParametersArray = new SpotLightParameters[_culler.VisibleObjectsCount];
				}
				else
				{
					Buffer = null;
				}
			}
		}

		private void CollectData()
		{
			if (_culler.HasVisibleObjects)
			{
				AuraLight[] visibleObjects = _culler.GetVisibleObjects();
				for (int i = 0; i < _culler.VisibleObjectsCount; i++)
				{
					_visibleSpotLightParametersArray[i] = visibleObjects[i].GetSpotParameters();
				}
				Buffer.SetData(_visibleSpotLightParametersArray);
			}
		}

		private void DisposeComputeBuffer()
		{
			if (Buffer != null)
			{
				Buffer.Release();
				Buffer = null;
			}
		}

		public void Dispose()
		{
			DisposeComputeBuffer();
			if (_emptyBuffer != null)
			{
				_emptyBuffer.Release();
				_emptyBuffer = null;
			}
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
			AuraCamera.CommonDataManager.LightsCommonDataManager.OnRegisterSpotLight -= LightsCommonDataManager_OnRegisterSpotLight;
			AuraCamera.CommonDataManager.LightsCommonDataManager.OnUnregisterSpotLight -= LightsCommonDataManager_OnUnregisterSpotLight;
		}
	}
}
