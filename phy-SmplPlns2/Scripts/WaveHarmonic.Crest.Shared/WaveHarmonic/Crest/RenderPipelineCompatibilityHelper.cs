using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal static class RenderPipelineCompatibilityHelper
	{
		internal static bool RTHandleNeedsReAlloc(RTHandle handle, in RenderTextureDescriptor descriptor, FilterMode filterMode, TextureWrapMode wrapMode, bool isShadowMap, int anisoLevel, float mipMapBias, string name, bool scaled)
		{
			if (handle == null || handle.rt == null)
			{
				return true;
			}
			if (handle.useScaling != scaled)
			{
				return true;
			}
			if (!scaled && (handle.rt.width != descriptor.width || handle.rt.height != descriptor.height))
			{
				return true;
			}
			if (handle.rt.descriptor.depthBufferBits == descriptor.depthBufferBits && (handle.rt.descriptor.depthBufferBits != 0 || isShadowMap || handle.rt.descriptor.graphicsFormat == descriptor.graphicsFormat) && handle.rt.descriptor.dimension == descriptor.dimension && handle.rt.descriptor.enableRandomWrite == descriptor.enableRandomWrite && handle.rt.descriptor.useMipMap == descriptor.useMipMap && handle.rt.descriptor.autoGenerateMips == descriptor.autoGenerateMips && handle.rt.descriptor.msaaSamples == descriptor.msaaSamples && handle.rt.descriptor.bindMS == descriptor.bindMS && handle.rt.descriptor.useDynamicScale == descriptor.useDynamicScale && handle.rt.descriptor.memoryless == descriptor.memoryless && handle.rt.filterMode == filterMode && handle.rt.wrapMode == wrapMode && handle.rt.anisoLevel == anisoLevel && handle.rt.mipMapBias == mipMapBias)
			{
				return handle.name != name;
			}
			return true;
		}

		public static bool ReAllocateIfNeeded(ref RTHandle handle, in RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Repeat, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0f, string name = "")
		{
			if (RTHandleNeedsReAlloc(handle, in descriptor, filterMode, wrapMode, isShadowMap, anisoLevel, mipMapBias, name, scaled: false))
			{
				handle?.Release();
				handle = RTHandles.Alloc(in descriptor, filterMode, wrapMode, isShadowMap, anisoLevel, mipMapBias, name);
				return true;
			}
			return false;
		}

		public static bool ReAllocateIfNeeded(ref RTHandle handle, Vector2 scaleFactor, in RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Repeat, bool isShadowMap = false, int anisoLevel = 1, float mipMapBias = 0f, string name = "")
		{
			if (RenderPipelineHelper.IsHighDefinition)
			{
				if (handle == null || !handle.useScaling || !(handle.scaleFactor == scaleFactor) || RTHandleNeedsReAlloc(handle, in descriptor, filterMode, wrapMode, isShadowMap, anisoLevel, mipMapBias, name, scaled: true))
				{
					handle?.Release();
					handle = RTHandles.Alloc(scaleFactor, in descriptor, filterMode, wrapMode, isShadowMap, anisoLevel, mipMapBias, name);
					return true;
				}
			}
			else if (RTHandleNeedsReAlloc(handle, in descriptor, filterMode, wrapMode, isShadowMap, anisoLevel, mipMapBias, name, scaled: false))
			{
				handle?.Release();
				handle = RTHandles.Alloc(in descriptor, filterMode, wrapMode, isShadowMap, anisoLevel, mipMapBias, name);
				return true;
			}
			return false;
		}
	}
}
