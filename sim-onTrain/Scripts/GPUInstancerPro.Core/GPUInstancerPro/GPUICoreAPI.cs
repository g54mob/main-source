using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GPUInstancerPro
{
	public static class GPUICoreAPI
	{
		public static void InitializeRenderingSystem()
		{
			GPUIRenderingSystem.InitializeRenderingSystem();
		}

		public static void RegenerateRenderers()
		{
			GPUIRenderingSystem.RegenerateRenderers();
		}

		public static void UpdateParameterBufferData()
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.UpdateParameterBufferData();
			}
		}

		public static void DisposeAll()
		{
			GPUIRenderingSystem.Instance.DestroyGeneric();
		}

		public static bool RegisterRenderer(Object source, GameObject prefab, out int rendererKey)
		{
			return GPUIRenderingSystem.RegisterRenderer(source, prefab, out rendererKey);
		}

		public static bool RegisterRenderer(Object source, GameObject prefab, GPUIProfile profile, out int rendererKey)
		{
			return GPUIRenderingSystem.RegisterRenderer(source, prefab, profile, out rendererKey);
		}

		public static bool RegisterRenderer(Object source, GPUIPrototype prototype, out int rendererKey)
		{
			return GPUIRenderingSystem.RegisterRenderer(source, prototype, out rendererKey);
		}

		public static void DisposeRenderer(int rendererKey)
		{
			GPUIRenderingSystem.DisposeRenderer(rendererKey);
		}

		public static bool SetTransformBufferData(int rendererKey, NativeArray<Matrix4x4> matrices, int managedBufferStartIndex = 0, int graphicsBufferStartIndex = 0, int count = 0)
		{
			return GPUIRenderingSystem.SetTransformBufferData(rendererKey, matrices, managedBufferStartIndex, graphicsBufferStartIndex, (count > 0) ? count : matrices.Length);
		}

		public static bool SetTransformBufferData(int rendererKey, Matrix4x4[] matrices, int managedBufferStartIndex = 0, int graphicsBufferStartIndex = 0, int count = 0)
		{
			return GPUIRenderingSystem.SetTransformBufferData(rendererKey, matrices, managedBufferStartIndex, graphicsBufferStartIndex, (count > 0) ? count : matrices.Length);
		}

		public static bool SetTransformBufferData(int rendererKey, List<Matrix4x4> matrices, int managedBufferStartIndex = 0, int graphicsBufferStartIndex = 0, int count = 0)
		{
			return GPUIRenderingSystem.SetTransformBufferData(rendererKey, matrices, managedBufferStartIndex, graphicsBufferStartIndex, (count > 0) ? count : matrices.Count);
		}

		public static bool TryGetTransformBuffer(int rendererKey, out GraphicsBuffer transformBuffer, out int bufferStartIndex)
		{
			int bufferSize;
			return TryGetTransformBuffer(rendererKey, out transformBuffer, out bufferStartIndex, out bufferSize);
		}

		public static bool TryGetTransformBuffer(int rendererKey, out GraphicsBuffer transformBuffer, out int bufferStartIndex, out int bufferSize)
		{
			transformBuffer = null;
			GPUIShaderBuffer shaderBuffer;
			bool num = GPUIRenderingSystem.TryGetTransformBuffer(rendererKey, out shaderBuffer, out bufferStartIndex, out bufferSize, (GPUICameraData)null, false);
			if (num)
			{
				transformBuffer = shaderBuffer.Buffer;
			}
			return num;
		}

		public static bool SetBufferSize(int rendererKey, int bufferSize)
		{
			return GPUIRenderingSystem.SetBufferSize(rendererKey, bufferSize);
		}

		public static bool SetInstanceCount(int rendererKey, int instanceCount)
		{
			return GPUIRenderingSystem.SetInstanceCount(rendererKey, instanceCount);
		}

		public static void AddMaterialPropertyOverride(int rendererKey, string propertyName, object propertyValue, int lodIndex = -1, int rendererIndex = -1)
		{
			GPUIRenderingSystem.AddMaterialPropertyOverride(rendererKey, propertyName, propertyValue, lodIndex, rendererIndex);
		}

		public static void AddMaterialPropertyOverride(int rendererKey, int nameID, object propertyValue, int lodIndex = -1, int rendererIndex = -1)
		{
			GPUIRenderingSystem.AddMaterialPropertyOverride(rendererKey, nameID, propertyValue, lodIndex, rendererIndex);
		}

		public static int AddPrototype(GPUIManager gpuiManager, GPUIPrototype prototype)
		{
			return gpuiManager.AddPrototype(prototype);
		}

		public static int AddPrototype(GPUIManager gpuiManager, GameObject prefab)
		{
			return gpuiManager.AddPrototype(prefab);
		}

		public static void AddCameraEventOnPreCull(UnityAction<GPUICameraData> cameraEvent)
		{
			if (!GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.InitializeRenderingSystem();
			}
			GPUIRenderingSystem.Instance.OnPreCull.AddListener(cameraEvent);
		}

		public static void RemoveCameraEventOnPreCull(UnityAction<GPUICameraData> cameraEvent)
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(cameraEvent);
			}
		}

		public static void AddCameraEventOnPreRender(UnityAction<GPUICameraData> cameraEvent)
		{
			if (!GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.InitializeRenderingSystem();
			}
			GPUIRenderingSystem.Instance.OnPreRender.AddListener(cameraEvent);
		}

		public static void RemoveCameraEventOnPreRender(UnityAction<GPUICameraData> cameraEvent)
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.OnPreRender.RemoveListener(cameraEvent);
			}
		}

		public static void AddCameraEventOnPostRender(UnityAction<GPUICameraData> cameraEvent)
		{
			if (!GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.InitializeRenderingSystem();
			}
			GPUIRenderingSystem.Instance.OnPostRender.AddListener(cameraEvent);
		}

		public static void RemoveCameraEventOnPostRender(UnityAction<GPUICameraData> cameraEvent)
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.OnPostRender.RemoveListener(cameraEvent);
			}
		}
	}
}
