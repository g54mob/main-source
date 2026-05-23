using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	public class PSXCamera
	{
		internal struct PSXCameraUpdateContext
		{
			public int rasterizationWidth;

			public int rasterizationHeight;

			public bool rasterizationHistoryRequested;

			public bool rasterizationPreUICopyRequested;

			public bool rasterizationRandomWriteRequested;

			public bool rasterizationDepthBufferRequested;
		}

		private struct RasterizationRTAllocator
		{
			private float scaleFactor;

			private bool enableRandomWrite;

			public RasterizationRTAllocator(float scaleFactor, bool enableRandomWrite)
			{
				this.scaleFactor = scaleFactor;
				this.enableRandomWrite = enableRandomWrite;
			}

			public RTHandle Allocator(string id, int frameIndex, RTHandleSystem rtHandleSystem)
			{
				return rtHandleSystem.Alloc(Vector2.one * scaleFactor, 1, DepthBits.None, GraphicsFormat.R8G8B8A8_UNorm, FilterMode.Bilinear, TextureWrapMode.Repeat, TextureDimension.Tex2D, enableRandomWrite, useMipMap: false, autoGenerateMips: true, isShadowMap: false, 1, 0f, MSAASamples.None, bindTextureMS: false, useDynamicScale: false, useDynamicScaleExplicit: false, RenderTextureMemoryless.None, VRTextureUsage.None, $"{id}_Rasterization RT History_{frameIndex}");
			}
		}

		private struct RasterizationPreUIRTAllocator
		{
			private float scaleFactor;

			public RasterizationPreUIRTAllocator(float scaleFactor)
			{
				this.scaleFactor = scaleFactor;
			}

			public RTHandle Allocator(string id, int frameIndex, RTHandleSystem rtHandleSystem)
			{
				return rtHandleSystem.Alloc(Vector2.one * scaleFactor, 1, DepthBits.None, GraphicsFormat.R8G8B8A8_UNorm, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex2D, enableRandomWrite: false, useMipMap: false, autoGenerateMips: true, isShadowMap: false, 1, 0f, MSAASamples.None, bindTextureMS: false, useDynamicScale: false, useDynamicScaleExplicit: false, RenderTextureMemoryless.None, VRTextureUsage.None, $"{id}_Rasterization Pre UI RT History_{frameIndex}");
			}
		}

		private struct RasterizationDepthStencilRTAllocator
		{
			private float scaleFactor;

			public RasterizationDepthStencilRTAllocator(float scaleFactor)
			{
				this.scaleFactor = scaleFactor;
			}

			public RTHandle Allocator(string id, int frameIndex, RTHandleSystem rtHandleSystem)
			{
				return rtHandleSystem.Alloc(Vector2.one * scaleFactor, 1, DepthBits.Depth24, GraphicsFormat.R8G8B8A8_SRGB, FilterMode.Point, TextureWrapMode.Repeat, TextureDimension.Tex2D, enableRandomWrite: false, useMipMap: false, autoGenerateMips: true, isShadowMap: true, 1, 0f, MSAASamples.None, bindTextureMS: false, useDynamicScale: false, useDynamicScaleExplicit: false, RenderTextureMemoryless.None, VRTextureUsage.None, $"{id}_Rasterization Depth Stencil RT History_{frameIndex}");
			}
		}

		private static Dictionary<Camera, PSXCamera> s_Cameras = new Dictionary<Camera, PSXCamera>();

		private static List<Camera> s_Cleanup = new List<Camera>();

		internal Camera camera;

		private bool isFirstFrame;

		private uint cameraFrameCount;

		private uint cameraAccumulationMotionBlurFrameCount;

		private uint cameraAccumulationMotionBlurBufferCount;

		private BufferedRTHandleSystem historyRTSystem = new BufferedRTHandleSystem();

		internal static PSXCamera GetOrCreate(Camera camera)
		{
			if (!s_Cameras.TryGetValue(camera, out var value))
			{
				value = new PSXCamera(camera);
				s_Cameras.Add(camera, value);
			}
			return value;
		}

		internal static void ClearAll()
		{
			foreach (KeyValuePair<Camera, PSXCamera> s_Camera in s_Cameras)
			{
				s_Camera.Value.Dispose();
			}
			s_Cameras.Clear();
			s_Cleanup.Clear();
		}

		internal PSXCamera(Camera cam)
		{
			camera = cam;
			Reset();
		}

		private void Reset()
		{
			isFirstFrame = true;
			cameraFrameCount = 0u;
			cameraAccumulationMotionBlurFrameCount = 0u;
			cameraAccumulationMotionBlurBufferCount = 0u;
		}

		internal void ResetAccumulationMotionBlurFrameCount()
		{
			cameraAccumulationMotionBlurFrameCount = 0u;
		}

		internal RTHandle AllocHistoryFrameRT(int id, Func<string, int, RTHandleSystem, RTHandle> allocator, int bufferCount)
		{
			historyRTSystem.AllocBuffer(id, (RTHandleSystem rts, int i) => allocator(camera.name, i, rts), bufferCount);
			return historyRTSystem.GetFrameRT(id, 0);
		}

		internal RTHandle GetPreviousFrameRT(int id)
		{
			return historyRTSystem.GetFrameRT(id, 1);
		}

		internal RTHandle GetCurrentFrameRT(int id)
		{
			return historyRTSystem.GetFrameRT(id, 0);
		}

		private void Dispose()
		{
			Reset();
			if (historyRTSystem != null)
			{
				historyRTSystem.Dispose();
				historyRTSystem = null;
			}
		}

		internal static void CleanUnused()
		{
			foreach (Camera key in s_Cameras.Keys)
			{
				PSXCamera pSXCamera = s_Cameras[key];
				if (!(pSXCamera.camera != null) || pSXCamera.camera.cameraType != CameraType.SceneView)
				{
					bool flag = false;
					bool flag2 = false;
					if (pSXCamera.camera == null || (!pSXCamera.camera.isActiveAndEnabled && pSXCamera.camera.cameraType != CameraType.Preview && !flag && !flag2))
					{
						s_Cleanup.Add(key);
					}
				}
			}
			foreach (Camera item in s_Cleanup)
			{
				s_Cameras[item].Dispose();
				s_Cameras.Remove(item);
			}
			s_Cleanup.Clear();
		}

		internal void UpdateBeginFrame(PSXCameraUpdateContext context)
		{
			RTHandles.SetReferenceSize(context.rasterizationWidth, context.rasterizationHeight);
			historyRTSystem.SwapAndSetReferenceSize(context.rasterizationWidth, context.rasterizationHeight);
			EnsureRasterizationRT(context);
			EnsureRasterizationPreUIRT(context);
			EnsureRasterizationDepthStencilRT(context);
		}

		internal void UpdateEndFrame()
		{
			isFirstFrame = false;
			cameraFrameCount++;
			cameraAccumulationMotionBlurFrameCount++;
		}

		private void EnsureRasterizationRT(PSXCameraUpdateContext context)
		{
			uint num = ((!context.rasterizationHistoryRequested) ? 1u : 2u);
			uint num2 = cameraAccumulationMotionBlurBufferCount;
			bool flag = num != num2;
			if (!flag && GetCurrentFrameRT(0).rt.descriptor.enableRandomWrite != context.rasterizationRandomWriteRequested)
			{
				flag = true;
			}
			if (flag)
			{
				historyRTSystem.ReleaseBuffer(0);
				RasterizationRTAllocator rasterizationRTAllocator = new RasterizationRTAllocator(1f, context.rasterizationRandomWriteRequested);
				AllocHistoryFrameRT(0, ((RasterizationRTAllocator)rasterizationRTAllocator).Allocator, (int)num);
				Reset();
				cameraAccumulationMotionBlurBufferCount = num;
			}
		}

		private void EnsureRasterizationPreUIRT(PSXCameraUpdateContext context)
		{
			bool flag = GetCurrentFrameRT(2) != null;
			if (context.rasterizationPreUICopyRequested)
			{
				if (!flag)
				{
					RasterizationPreUIRTAllocator rasterizationPreUIRTAllocator = new RasterizationPreUIRTAllocator(1f);
					AllocHistoryFrameRT(2, ((RasterizationPreUIRTAllocator)rasterizationPreUIRTAllocator).Allocator, 1);
				}
			}
			else if (flag)
			{
				historyRTSystem.ReleaseBuffer(2);
			}
		}

		private void EnsureRasterizationDepthStencilRT(PSXCameraUpdateContext context)
		{
			bool flag = GetCurrentFrameRT(1) != null;
			if (context.rasterizationDepthBufferRequested)
			{
				if (!flag)
				{
					RasterizationDepthStencilRTAllocator rasterizationDepthStencilRTAllocator = new RasterizationDepthStencilRTAllocator(1f);
					AllocHistoryFrameRT(1, ((RasterizationDepthStencilRTAllocator)rasterizationDepthStencilRTAllocator).Allocator, 1);
				}
			}
			else if (flag)
			{
				historyRTSystem.ReleaseBuffer(1);
			}
		}

		internal uint GetCameraFrameCount()
		{
			return cameraFrameCount;
		}

		internal bool GetIsFirstFrame()
		{
			return isFirstFrame;
		}

		internal uint GetCameraAccumulationMotionBlurFrameCount()
		{
			return cameraAccumulationMotionBlurFrameCount;
		}
	}
}
