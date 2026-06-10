using System;
using UnityEngine;

namespace Aura2API
{
	public class VolumesManager
	{
		private readonly ObjectsCuller<AuraVolume> _culler;

		private AuraVolume[] _visibleVolumes;

		private VolumeData[] _visibleVolumesDataArray;

		public FrustumSettings _frustumSettings;

		private Camera _referenceCamera;

		private ComputeBuffer _emptyBuffer;

		public ComputeBuffer EmptyBuffer
		{
			get
			{
				if (_emptyBuffer == null)
				{
					_emptyBuffer = new ComputeBuffer(1, VolumeData.Size);
				}
				return _emptyBuffer;
			}
		}

		public ComputeBuffer Buffer { get; private set; }

		public bool HasVisibleVolumes => _culler.HasVisibleObjects;

		public VolumesManager(Camera camera, FrustumSettings frustumSettings)
		{
			_referenceCamera = camera;
			_frustumSettings = frustumSettings;
			_culler = new ObjectsCuller<AuraVolume>(_referenceCamera, _frustumSettings);
			for (int i = 0; i < AuraCamera.CommonDataManager.VolumesCommonDataManager.RegisteredVolumesList.Count; i++)
			{
				_culler.Register(AuraCamera.CommonDataManager.VolumesCommonDataManager.RegisteredVolumesList[i]);
			}
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(Camera_onPreRender));
			AuraCamera.CommonDataManager.VolumesCommonDataManager.OnRegisterVolume += VolumesCommonDataManager_OnRegisterVolume;
			AuraCamera.CommonDataManager.VolumesCommonDataManager.OnUnregisterVolume += VolumesCommonDataManager_OnUnregisterVolume;
		}

		private void Camera_onPreRender(Camera camera)
		{
			_culler.Update(camera, _frustumSettings);
			SetupComputeBuffer();
			CollectData();
		}

		private void VolumesCommonDataManager_OnRegisterVolume(AuraVolume auraVolume)
		{
			_culler.Register(auraVolume);
		}

		private void VolumesCommonDataManager_OnUnregisterVolume(AuraVolume auraVolume)
		{
			_culler.Unregister(auraVolume);
		}

		private void SetupComputeBuffer()
		{
			if (Buffer == null || _culler.VisibleObjectsCount != Buffer.count)
			{
				DisposeComputeBuffer();
				if (_culler.HasVisibleObjects)
				{
					Buffer = new ComputeBuffer(_culler.VisibleObjectsCount, VolumeData.Size);
					_visibleVolumesDataArray = new VolumeData[_culler.VisibleObjectsCount];
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
				AuraVolume[] visibleObjects = _culler.GetVisibleObjects();
				for (int i = 0; i < _culler.VisibleObjectsCount; i++)
				{
					_visibleVolumesDataArray[i] = visibleObjects[i].GetData();
				}
				Buffer.SetData(_visibleVolumesDataArray);
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
			AuraCamera.CommonDataManager.VolumesCommonDataManager.OnRegisterVolume -= VolumesCommonDataManager_OnRegisterVolume;
			AuraCamera.CommonDataManager.VolumesCommonDataManager.OnUnregisterVolume -= VolumesCommonDataManager_OnUnregisterVolume;
		}
	}
}
