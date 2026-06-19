using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class LightData
	{
		public const int MAX_LIGHT_COUNT = 512;

		private MaterialPropertyBlock m_properties;

		private readonly Matrix4x4[] m_transforms = new Matrix4x4[512];

		private readonly List<Matrix4x4> m_worldToShadow = new List<Matrix4x4>(512);

		private readonly List<Vector4> m_positionRange = new List<Vector4>(512);

		private readonly List<Vector4> m_colorSpotAngleNorm = new List<Vector4>(512);

		private readonly List<Vector4> m_params = new List<Vector4>(512);

		private readonly List<Vector4> m_forwardCosSpotAngle = new List<Vector4>(512);

		private int m_count;

		private LightType m_populatedDataType = (LightType)(-1);

		public MaterialPropertyBlock properties => m_properties;

		public Matrix4x4[] transforms => m_transforms;

		public int count => m_count;

		public LightData()
		{
			m_properties = new MaterialPropertyBlock();
		}

		public void Populate(HashSet<Light> lights, LightType type)
		{
			if (type != LightType.Point && type != LightType.Spot)
			{
				Debug.LogError("Error: LightData class only supports point and spotlights.");
			}
			m_populatedDataType = type;
			ClearPropertyBuffers();
			m_count = 0;
			foreach (Light light in lights)
			{
				if (light.type == type && SetLightData(light, m_count))
				{
					m_count++;
				}
			}
			m_properties.Clear();
			m_properties.SetMatrixArray(ShaderIDs.LightWorldToShadow, m_worldToShadow);
			m_properties.SetVectorArray(ShaderIDs.LightPositionRange, m_positionRange);
			m_properties.SetVectorArray(ShaderIDs.LightColorSpotAngleNorm, m_colorSpotAngleNorm);
			m_properties.SetVectorArray(ShaderIDs.LightParams, m_params);
			if (type == LightType.Spot)
			{
				m_properties.SetVectorArray(ShaderIDs.LightForwardCosSpotAngle, m_forwardCosSpotAngle);
			}
		}

		public void Draw(CommandBuffer cmd)
		{
			Mesh mesh = ((m_populatedDataType == LightType.Spot) ? PugRPUtils.spotlightShape : PugRPUtils.pointlightShape);
			int shaderPass = ((m_populatedDataType == LightType.Spot) ? 4 : 3);
			if (mesh != null)
			{
				cmd.DrawMeshInstanced(mesh, 0, PugRP.deferredMaterial, shaderPass, transforms, count, properties);
			}
			else
			{
				Debug.LogWarning("Light shape mesh failed to load (unknown reason)");
			}
		}

		private bool SetLightData(Light light, int i)
		{
			if (!light.TryGetPugLight(out var pugLight) || !pugLight.shouldRender)
			{
				return false;
			}
			Vector3 cachedPosition = pugLight.cachedPosition;
			Vector3 cachedForward = pugLight.cachedForward;
			float cachedRange = pugLight.cachedRange;
			Color color = light.color.linear * light.intensity;
			float cachedSpotAngle = pugLight.cachedSpotAngle;
			m_transforms[i] = Matrix4x4.TRS(cachedPosition, pugLight.cachedRotation, Vector3.one * cachedRange);
			m_positionRange.Add(new Vector4(cachedPosition.x, cachedPosition.y, cachedPosition.z, cachedRange));
			m_colorSpotAngleNorm.Add(new Vector4(color.r, color.g, color.b, cachedSpotAngle / 180f));
			float num = 0f;
			if (light.type == LightType.Spot)
			{
				if (PugRP.asset.punctualShadowsType == ShadowsType.Shadowmap)
				{
					Shadows.GetSpotlightMatrices(light, out var view, out var projection);
					m_worldToShadow.Add(GL.GetGPUProjectionMatrix(projection, renderIntoTexture: false) * view);
					num = m_worldToShadow[i].m00;
				}
				m_forwardCosSpotAngle.Add(new Vector4(cachedForward.x, cachedForward.y, cachedForward.z, Mathf.Cos(cachedSpotAngle * (MathF.PI / 180f) / 2f)));
			}
			if (PugRP.asset.punctualShadowsType == ShadowsType.Raymap)
			{
				m_worldToShadow.Add(Shadows.GetRaymapWorldToShadow(cachedPosition, cachedRange));
			}
			float y = (PugRP.asset.enablePhysicalLightAttenuation ? pugLight.physicality : 0f);
			float shadowBias = PugRPUtils.GetShadowBias((float)PugRP.asset.shadowResolution + num, PugRP.asset.spotShadowBias);
			if (Shadows.TryGetShadowData(light, out var shadowData))
			{
				m_params.Add(new Vector4(shadowData.atlasIndex, y, shadowBias, pugLight.size));
			}
			else
			{
				float x = ((PugRP.asset.punctualShadowsType == ShadowsType.Raymarching && light.shadows != LightShadows.None) ? pugLight.quality : (-1f));
				m_params.Add(new Vector4(x, y, 0f, pugLight.size));
			}
			return true;
		}

		private void ClearPropertyBuffers()
		{
			m_worldToShadow.Clear();
			m_positionRange.Clear();
			m_colorSpotAngleNorm.Clear();
			m_params.Clear();
			m_forwardCosSpotAngle.Clear();
		}
	}
}
