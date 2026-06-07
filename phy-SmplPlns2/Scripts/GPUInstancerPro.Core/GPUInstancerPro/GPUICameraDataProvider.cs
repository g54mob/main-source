using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUICameraDataProvider : GPUIDataProvider<int, GPUICameraData>
	{
		private Queue<int> _removalQueue;

		public override void Initialize()
		{
			base.Initialize();
			_removalQueue = new Queue<int>();
		}

		public override void ReleaseBuffers()
		{
			if (_dataDict != null)
			{
				foreach (GPUICameraData value in base.Values)
				{
					value?.ReleaseBuffers();
				}
			}
			base.ReleaseBuffers();
		}

		public override void Dispose()
		{
			_removalQueue = null;
			base.Dispose();
		}

		public override bool AddOrSet(int cameraInstanceID, GPUICameraData value)
		{
			if (base.AddOrSet(cameraInstanceID, value))
			{
				GPUIRenderingSystem.Instance.UpdateCommandBuffers(value);
				return true;
			}
			return false;
		}

		public override bool Remove(int cameraInstanceID)
		{
			if (base.IsInitialized && _dataDict.TryGetValue(cameraInstanceID, out var value))
			{
				value?.Dispose();
			}
			if (base.Remove(cameraInstanceID))
			{
				return true;
			}
			return false;
		}

		internal bool ClearEmptyCameraData()
		{
			bool result = false;
			foreach (KeyValuePair<int, GPUICameraData> item in _dataDict)
			{
				if (item.Value == null || item.Value.ActiveCamera == null)
				{
					_removalQueue.Enqueue(item.Key);
					result = true;
				}
			}
			int result2;
			while (_removalQueue.TryDequeue(out result2))
			{
				Remove(result2);
			}
			return result;
		}

		internal GPUICameraData AddCamera(Camera camera)
		{
			if (!camera.gameObject.TryGetComponent<GPUICamera>(out var component))
			{
				component = camera.gameObject.AddComponent<GPUICamera>();
			}
			component.Initialize();
			AddCameraData(component._cameraData);
			return component._cameraData;
		}

		internal void AddCameraData(GPUICameraData cameraData)
		{
			if (cameraData.ActiveCamera != null && !AddOrSet(cameraData.ActiveCamera.GetInstanceID(), cameraData))
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not add Camera Data.", cameraData.ActiveCamera.gameObject);
			}
		}

		internal void RemoveCamera(Camera camera)
		{
			if (camera != null)
			{
				Remove(camera.GetInstanceID());
			}
		}

		internal bool RegisterDefaultCamera()
		{
			Camera camera = null;
			if (GPUIRuntimeSettings.Instance.cameraLoadingType != GPUICameraLoadingType.GPUICameraComponent)
			{
				camera = Camera.main;
				if (camera == null && GPUIRuntimeSettings.Instance.cameraLoadingType == GPUICameraLoadingType.Any)
				{
					Camera[] allCameras = Camera.allCameras;
					if (allCameras.Length != 0)
					{
						camera = allCameras[0];
					}
				}
			}
			if (camera == null)
			{
				return false;
			}
			AddCamera(camera);
			return true;
		}

		public override bool ContainsValue(GPUICameraData value)
		{
			return base.ContainsValue(value);
		}
	}
}
