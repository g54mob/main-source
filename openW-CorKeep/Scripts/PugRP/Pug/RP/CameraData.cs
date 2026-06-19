using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class CameraData
	{
		private const int MAX_SSAO_KERNEL_SIZE = 128;

		public Matrix4x4 adjustedViewMatrix;

		public Matrix4x4 viewProjectionMatrix;

		public Matrix4x4 prevViewProjectionMatrix;

		public bool hasHistory;

		public GBufferData gbuffer;

		public Vector4[] ssaoKernel;

		private CullingResults m_cullingResults;

		private int m_ssaoKernelSize;

		private int m_ssaoSeed;

		public readonly RenderFeature[] renderFeatures = new RenderFeature[6]
		{
			new LightTracingRenderFeature(),
			new IndirectLightRenderFeature(),
			new ScreenSpaceAmbientOcclusionRenderFeature(),
			new VolumetricLightRenderFeature(),
			new PlanarReflectionsRenderFeature(),
			new BloomRenderFeature()
		};

		private Dictionary<Type, RenderFeature> s_renderFeatureLookup;

		public CameraData()
		{
			gbuffer = new GBufferData();
			hasHistory = false;
		}

		public Matrix4x4 GetPrevViewProjectionMatrix()
		{
			if (!hasHistory)
			{
				return viewProjectionMatrix;
			}
			return prevViewProjectionMatrix * Matrix4x4.Translate(PugRP.originShift);
		}

		public void UpdateHistory()
		{
			prevViewProjectionMatrix = viewProjectionMatrix;
			hasHistory = true;
		}

		public void Cull(ScriptableRenderContext context, ref ScriptableCullingParameters cullingParameters)
		{
			m_cullingResults = context.Cull(ref cullingParameters);
		}

		public CullingResults GetCullingResults()
		{
			if (!PugRP.useSharedCullPass)
			{
				return m_cullingResults;
			}
			return PugRP.sharedCullingResults;
		}

		public void Dispose()
		{
			for (int i = 0; i < renderFeatures.Length; i++)
			{
				renderFeatures[i].Dispose();
			}
			gbuffer.Dispose();
		}

		public void AddVisibleLights(HashSet<Light> lights)
		{
			foreach (VisibleLight visibleLight in m_cullingResults.visibleLights)
			{
				lights.Add(visibleLight.light);
			}
			for (int i = 0; i < renderFeatures.Length; i++)
			{
				renderFeatures[i].AddVisibleLights(lights);
			}
		}

		public bool TryGetRenderFeature<T>(out T renderFeature) where T : RenderFeature
		{
			renderFeature = null;
			if (s_renderFeatureLookup == null)
			{
				s_renderFeatureLookup = new Dictionary<Type, RenderFeature>();
				for (int i = 0; i < renderFeatures.Length; i++)
				{
					RenderFeature renderFeature2 = renderFeatures[i];
					s_renderFeatureLookup.Add(renderFeature2.GetType(), renderFeature2);
				}
			}
			RenderFeature value;
			bool num = s_renderFeatureLookup.TryGetValue(typeof(T), out value);
			if (num)
			{
				renderFeature = value as T;
			}
			return num;
		}

		public void SetupSSAOKernel(CommandBuffer cmd, int size, int seed)
		{
			if (ssaoKernel == null || m_ssaoKernelSize != size || m_ssaoSeed != seed)
			{
				if (ssaoKernel == null)
				{
					ssaoKernel = new Vector4[128];
				}
				PugRPUtils.UniformKernel(ssaoKernel, size, hemisphere: true, seed);
				m_ssaoKernelSize = size;
			}
		}
	}
}
