using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;

namespace Pug.RP
{
	public static class Shadows
	{
		public const int MAX_SHADOW_COUNT = 128;

		public static int maxShadowUpdatesPerFrameOverride = -1;

		public static bool debugDirtyAreas;

		public static Quaternion raymapOrientation;

		private static string[] s_cubemapFaceNames = new string[6] { "PositiveX", "NegativeX", "PositiveY", "NegativeY", "PositiveZ", "NegativeZ" };

		private static Dictionary<Light, ShadowData> s_shadowData = new Dictionary<Light, ShadowData>();

		private static HashSet<Light> s_dirtyLights = new HashSet<Light>();

		private static Queue<Light> s_shadowUpdateQueue = new Queue<Light>();

		private static HashSet<Light> s_shadowUpdateList = new HashSet<Light>();

		private static HashSet<Light> s_degenerateLights = new HashSet<Light>();

		private static Stack<int> s_pointIndices;

		private static Stack<int> s_spotIndices;

		private static RenderTexture s_pointTarget;

		private static RenderTexture s_shadowTarget;

		private static RenderTexture s_pointShadows;

		private static RenderTexture s_spotShadows;

		private static CommandBuffer s_cmd;

		private static string s_pointShadowTargetName = "Shadow Target (Point)";

		private static string s_shadowTargetName = "Shadow Target";

		private static string s_pointShadowsName = "Shadow Atlas (Point Lights)";

		private static string s_spotShadowsName = "Shadow Atlas (Spotlights)";

		private static string s_singlePassSampleName = "Single Pass";

		private static Dictionary<Light, Camera> s_shadowCameras = new Dictionary<Light, Camera>();

		private static GlobalKeyword s_punctualShadowCasterKeyword = GlobalKeyword.Create("PUNCTUAL_SHADOWCASTER");

		private static Matrix4x4[] s_shadowCubeVP = new Matrix4x4[6];

		private static Material s_shadowUtilityMaterial;

		private static Vector4[] s_pointSampleKernel = new Vector4[16];

		private static List<Bounds> s_dirtyAreas = new List<Bounds>();

		private static Queue<Bounds> s_dirtyAreasQueued = new Queue<Bounds>();

		public static int numShadowUpdates { get; private set; }

		public static AvgFloat avgShadowUpdates { get; private set; } = new AvgFloat(50, 500);

		public static void MarkAreaDirty(Bounds bounds, bool allowAmortization)
		{
			if (allowAmortization)
			{
				s_dirtyAreasQueued.Enqueue(bounds);
			}
			else
			{
				s_dirtyAreas.Add(bounds);
			}
		}

		public static void ConsumeDirtyAreas(HashSet<Light> lights)
		{
			while (s_dirtyAreasQueued.Count > 0)
			{
				Bounds bounds = s_dirtyAreasQueued.Dequeue();
				bool flag = false;
				foreach (Light light in lights)
				{
					if (!light.IsShadowDirty())
					{
						float range = light.range;
						float num = range * range;
						if (bounds.SqrDistance(light.transform.position) < num)
						{
							light.SetShadowDirty();
							flag = true;
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
			foreach (Light light2 in lights)
			{
				if (light2.IsShadowDirty())
				{
					continue;
				}
				float num2 = light2.range * light2.range;
				for (int i = 0; i < s_dirtyAreas.Count; i++)
				{
					if (s_dirtyAreas[i].SqrDistance(light2.transform.position) < num2)
					{
						light2.SetShadowDirty();
						break;
					}
				}
			}
			s_dirtyAreas.Clear();
		}

		public static void Update(ScriptableRenderContext context)
		{
			Lazy();
			s_cmd.Clear();
			UpdateShadowData();
			UpdateShadows(context, s_cmd);
			context.ExecuteCommandBuffer(s_cmd);
		}

		public static void Release()
		{
			PugRPUtils.Release(ref s_shadowTarget);
			PugRPUtils.Release(ref s_pointTarget);
			PugRPUtils.Release(ref s_pointShadows);
			PugRPUtils.Release(ref s_spotShadows);
		}

		public static bool TryGetShadowData(Light light, out ShadowData shadowData)
		{
			if ((object)light == null || light.Equals(null) || !PugRP.asset.usesCachedPunctualShadows)
			{
				shadowData = ShadowData.invalid;
				return false;
			}
			return s_shadowData.TryGetValue(light, out shadowData);
		}

		public static void SetLightDirty(Light light)
		{
			s_dirtyLights.Add(light);
		}

		public static bool GetLightDirty(Light light)
		{
			return s_dirtyLights.Contains(light);
		}

		public static void SetAllShadowsDirty()
		{
			foreach (ShadowData value in s_shadowData.Values)
			{
				ReturnAtlasIndex(value.atlasIndex, value.type);
			}
			s_shadowData.Clear();
		}

		public static void GetSpotlightMatrices(Light light, out Matrix4x4 view, out Matrix4x4 projection)
		{
			float shadowNearPlane = light.shadowNearPlane;
			float zFar = Mathf.Max(shadowNearPlane + 0.01f, light.range);
			view = Matrix4x4.TRS(light.transform.position, light.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
			projection = Matrix4x4.Perspective(light.spotAngle, 1f, shadowNearPlane, zFar);
		}

		public static Matrix4x4 GetRaymapWorldToShadow(Light light)
		{
			return GetRaymapWorldToShadow(light.transform.position, light.range);
		}

		public static Matrix4x4 GetRaymapWorldToShadow(Vector3 lightPosition, float lightRange)
		{
			return Matrix4x4.TRS(lightPosition, raymapOrientation, Vector3.one * lightRange).inverse;
		}

		private static void Lazy()
		{
			if (s_pointIndices == null)
			{
				s_pointIndices = new Stack<int>();
				for (int i = 0; i < 128; i++)
				{
					s_pointIndices.Push(128 - i - 1);
				}
			}
			if (s_spotIndices == null)
			{
				s_spotIndices = new Stack<int>();
				for (int j = 0; j < 128; j++)
				{
					s_spotIndices.Push(128 - j - 1);
				}
			}
			if (s_cmd == null)
			{
				s_cmd = new CommandBuffer
				{
					name = "Update Shadows"
				};
			}
			if (s_shadowUtilityMaterial == null)
			{
				s_shadowUtilityMaterial = new Material(Shader.Find("Hidden/PugRP/ShadowUtilities"));
			}
			bool flag = PugRP.asset.punctualShadowsType == ShadowsType.Shadowmap;
			int shadowResolution = (int)PugRP.asset.shadowResolution;
			RenderTextureDescriptor desc = new RenderTextureDescriptor(shadowResolution, shadowResolution, RenderTextureFormat.Shadowmap, 16);
			RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(shadowResolution, shadowResolution, RenderTextureFormat.Shadowmap, 16);
			renderTextureDescriptor.dimension = (flag ? TextureDimension.Cube : TextureDimension.Tex2D);
			RenderTextureDescriptor desc2 = renderTextureDescriptor;
			renderTextureDescriptor = new RenderTextureDescriptor(shadowResolution, shadowResolution, RenderTextureFormat.Shadowmap, 16);
			renderTextureDescriptor.dimension = (flag ? TextureDimension.CubeArray : TextureDimension.Tex2DArray);
			renderTextureDescriptor.volumeDepth = 128 * ((!flag) ? 1 : 6);
			RenderTextureDescriptor desc3 = renderTextureDescriptor;
			renderTextureDescriptor = new RenderTextureDescriptor(shadowResolution, shadowResolution, RenderTextureFormat.Shadowmap, 16);
			renderTextureDescriptor.dimension = TextureDimension.Tex2DArray;
			renderTextureDescriptor.volumeDepth = 128;
			RenderTextureDescriptor desc4 = renderTextureDescriptor;
			if (PugRPUtils.Setup(ref s_shadowTarget, s_shadowTargetName, desc) | PugRPUtils.Setup(ref s_pointTarget, s_pointShadowTargetName, desc2) | PugRPUtils.Setup(ref s_pointShadows, s_pointShadowsName, desc3) | PugRPUtils.Setup(ref s_spotShadows, s_spotShadowsName, desc4))
			{
				SetAllShadowsDirty();
			}
		}

		private static void UpdateShadowData()
		{
			s_degenerateLights.Clear();
			foreach (KeyValuePair<Light, ShadowData> s_shadowDatum in s_shadowData)
			{
				Light key = s_shadowDatum.Key;
				ShadowData value = s_shadowDatum.Value;
				if (key == null || key.Equals(null) || !key.isActiveAndEnabled || key.shadows == LightShadows.None || TypeFromLight(key) != value.type)
				{
					s_degenerateLights.Add(key);
					DeallocateShadowData(value);
				}
			}
			foreach (Light s_degenerateLight in s_degenerateLights)
			{
				s_shadowData.Remove(s_degenerateLight);
			}
			foreach (Light visibleLight in PugRP.visibleLights)
			{
				if (!s_shadowData.ContainsKey(visibleLight) && CanAllocateShadowData(visibleLight))
				{
					s_shadowData.Add(visibleLight, AllocateShadowData(visibleLight));
				}
			}
		}

		private static void UpdateShadows(ScriptableRenderContext context, CommandBuffer cmd)
		{
			avgShadowUpdates.AddSample(numShadowUpdates);
			numShadowUpdates = 0;
			s_shadowUpdateList.Clear();
			foreach (KeyValuePair<Light, ShadowData> s_shadowDatum in s_shadowData)
			{
				Light key = s_shadowDatum.Key;
				if (key.IsShadowDirty() && key.TryGetPugLight(out var pugLight))
				{
					if (pugLight.skipShadowQueue)
					{
						s_shadowUpdateList.Add(key);
					}
					else if (!s_shadowUpdateQueue.Contains(key))
					{
						s_shadowUpdateQueue.Enqueue(key);
					}
				}
			}
			s_dirtyLights.Clear();
			int num = ((maxShadowUpdatesPerFrameOverride > 0) ? maxShadowUpdatesPerFrameOverride : PugRP.asset.maxShadowUpdatesPerFrame);
			for (int i = 0; i < num; i++)
			{
				if (s_shadowUpdateQueue.Count <= 0)
				{
					break;
				}
				s_shadowUpdateList.Add(s_shadowUpdateQueue.Dequeue());
			}
			foreach (Light s_shadowUpdate in s_shadowUpdateList)
			{
				if (!(s_shadowUpdate == null) && s_shadowData.TryGetValue(s_shadowUpdate, out var value) && s_shadowUpdate.TryGetPugLight(out var pugLight2))
				{
					UpdateShadowForLight(context, cmd, s_shadowUpdate, value);
					pugLight2.UpdatePositionalData();
					numShadowUpdates++;
				}
			}
			cmd.SetGlobalTexture(ShaderIDs.PointShadowAtlas, s_pointShadows);
			cmd.SetGlobalTexture(ShaderIDs.SpotShadowAtlas, s_spotShadows);
			cmd.SetGlobalVector(ShaderIDs.PointShadowAtlasSize, new Vector4(s_pointShadows.width, s_pointShadows.height, 1f / (float)s_pointShadows.width, 1f / (float)s_pointShadows.height));
			cmd.SetGlobalVector(ShaderIDs.SpotShadowAtlasSize, new Vector4(s_spotShadows.width, s_spotShadows.height, 1f / (float)s_spotShadows.width, 1f / (float)s_spotShadows.height));
			int pointShadowSamples = PugRP.asset.pointShadowSamples;
			if (pointShadowSamples > 1)
			{
				float num2 = MathF.PI * (3f - Mathf.Sqrt(5f));
				for (int j = 0; j < pointShadowSamples; j++)
				{
					float num3 = (float)j / (float)(pointShadowSamples - 1);
					float num4 = Mathf.Sqrt(1f - num3 * num3);
					float f = num2 * (float)j;
					float x = Mathf.Cos(f) * num4;
					float y = Mathf.Sin(f) * num4;
					s_pointSampleKernel[j] = new Vector3(x, y, num3);
					s_pointSampleKernel[j] = Vector3.Slerp(Vector3.forward, s_pointSampleKernel[j], 2f / (float)s_pointShadows.width * PugRP.asset.pointShadowSoftness * (float)pointShadowSamples / 16f);
				}
			}
			else
			{
				s_pointSampleKernel[0] = Vector3.forward;
			}
			_ = 2f / (float)PugRP.asset.shadowResolution;
			cmd.SetGlobalVectorArray(ShaderIDs.PointShadowSampleKernel, s_pointSampleKernel);
			cmd.SetGlobalFloat(ShaderIDs.PointShadowSampleCount, PugRP.asset.pointShadowSamples);
			cmd.SetGlobalFloat(ShaderIDs.PointShadowBias, PugRPUtils.GetShadowBias((float)PugRP.asset.shadowResolution, PugRP.asset.pointShadowBias));
		}

		private static void UpdateShadowForLight(ScriptableRenderContext context, CommandBuffer cmd, Light light, ShadowData shadowData)
		{
			if (!s_shadowCameras.TryGetValue(light, out var value))
			{
				value = PugRPUtils.GetUtilityCamera("_SHADOW_CAMERA");
				s_shadowCameras.Add(light, value);
			}
			ShadowsType punctualShadowsType = PugRP.asset.punctualShadowsType;
			cmd.SetGlobalVector(ShaderIDs.LightPosition, light.transform.position);
			cmd.SetGlobalFloat(ShaderIDs.LightRange, light.range);
			if (shadowData.type == ShadowType.Point)
			{
				cmd.SetKeyword(in s_punctualShadowCasterKeyword, value: true);
				switch (punctualShadowsType)
				{
				case ShadowsType.Shadowmap:
					if (PugRP.asset.singlePassPointShadows && SystemInfo.graphicsDeviceType != GraphicsDeviceType.OpenGLCore)
					{
						RenderPointLightShadowSinglePass(context, cmd, light, shadowData, value);
					}
					else
					{
						RenderPointLightShadow(context, cmd, light, shadowData, value);
					}
					break;
				case ShadowsType.Raymap:
					RenderRaymapShadow(context, cmd, light, shadowData, ShadowType.Point);
					break;
				default:
					Debug.LogError("Updating shadows with invalid shadow type");
					break;
				}
				cmd.SetKeyword(in s_punctualShadowCasterKeyword, value: false);
			}
			else if (shadowData.type == ShadowType.Spot)
			{
				switch (punctualShadowsType)
				{
				case ShadowsType.Shadowmap:
					RenderSpotlightShadow(context, cmd, light, shadowData, value);
					break;
				case ShadowsType.Raymap:
					RenderRaymapShadow(context, cmd, light, shadowData, ShadowType.Spot);
					break;
				default:
					Debug.LogError("Updating shadows with invalid shadow type");
					break;
				}
			}
		}

		private static void RenderPointLightShadowSinglePass(ScriptableRenderContext context, CommandBuffer cmd, Light light, ShadowData shadowData, Camera shadowCamera)
		{
			float shadowNearPlane = light.shadowNearPlane;
			float num = Mathf.Max(shadowNearPlane + 0.01f, light.range);
			cmd.SetInvertCulling(invertCulling: true);
			float y = (SystemInfo.graphicsUVStartsAtTop ? 1 : (-1));
			cmd.BeginSample(s_singlePassSampleName);
			for (CubemapFace cubemapFace = CubemapFace.PositiveX; cubemapFace <= CubemapFace.NegativeZ; cubemapFace++)
			{
				Quaternion q = PugRPUtils.RotationFromCubemapFace(cubemapFace);
				Matrix4x4 inverse = Matrix4x4.TRS(light.transform.position, q, new Vector3(1f, y, -1f)).inverse;
				Matrix4x4 matrix4x = Matrix4x4.Perspective(90f, 1f, shadowNearPlane, num);
				s_shadowCubeVP[(int)cubemapFace] = matrix4x * inverse;
			}
			cmd.SetGlobalMatrixArray(ShaderIDs.ShadowCubeVP, s_shadowCubeVP);
			cmd.SetRenderTarget(s_pointShadows, 0, CubemapFace.Unknown, -1);
			cmd.SetGlobalFloat(ShaderIDs.DstArraySlice, shadowData.atlasIndex);
			cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, s_shadowUtilityMaterial, 0, 0);
			shadowCamera.transform.position = light.transform.position - Vector3.forward * num;
			shadowCamera.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
			shadowCamera.worldToCameraMatrix = Matrix4x4.TRS(shadowCamera.transform.position, shadowCamera.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
			shadowCamera.projectionMatrix = Matrix4x4.Ortho(0f - num, num, 0f - num, num, shadowNearPlane, num * 2f);
			if (shadowCamera.TryGetCullingParameters(out var cullingParameters))
			{
				CullingResults cullingResult;
				if (PugRP.useSharedCullPass)
				{
					cullingResult = PugRP.sharedCullingResults;
				}
				else
				{
					cullingParameters.cullingOptions = CullingOptions.ForceEvenIfCameraIsNotActive | CullingOptions.ShadowCasters;
					cullingResult = context.Cull(ref cullingParameters);
					PugRP.cullOps++;
				}
				RendererListDesc rendererListDesc = new RendererListDesc(PugRP.shadowCasterCubeShaderTagId, cullingResult, shadowCamera);
				rendererListDesc.sortingCriteria = SortingCriteria.OptimizeStateChanges;
				rendererListDesc.renderQueueRange = RenderQueueRange.opaque;
				rendererListDesc.layerMask = PugRP.asset.shadowCastingLayers;
				RendererListDesc desc = rendererListDesc;
				RendererList rendererList = context.CreateRendererList(desc);
				cmd.DrawRendererList(rendererList);
			}
			cmd.EndSample(s_singlePassSampleName);
			cmd.SetInvertCulling(invertCulling: false);
		}

		private static void RenderPointLightShadow(ScriptableRenderContext context, CommandBuffer cmd, Light light, ShadowData shadowData, Camera shadowCamera)
		{
			float shadowNearPlane = light.shadowNearPlane;
			float zFar = Mathf.Max(shadowNearPlane + 0.01f, light.range);
			cmd.SetInvertCulling(invertCulling: true);
			float y = (SystemInfo.graphicsUVStartsAtTop ? 1 : (-1));
			for (CubemapFace cubemapFace = CubemapFace.PositiveX; cubemapFace <= CubemapFace.NegativeZ; cubemapFace++)
			{
				cmd.BeginSample(s_cubemapFaceNames[(int)cubemapFace]);
				Quaternion quaternion = PugRPUtils.RotationFromCubemapFace(cubemapFace);
				Matrix4x4 inverse = Matrix4x4.TRS(light.transform.position, quaternion, new Vector3(1f, y, -1f)).inverse;
				Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(Matrix4x4.Perspective(90f, 1f, shadowNearPlane, zFar), renderIntoTexture: true);
				Matrix4x4.Perspective(90f, 1f, shadowNearPlane, zFar);
				cmd.SetRenderTarget(s_shadowTarget);
				cmd.ClearRenderTarget(clearDepth: true, clearColor: false, Color.clear);
				cmd.SetViewProjectionMatrices(inverse, gPUProjectionMatrix);
				shadowCamera.transform.position = light.transform.position;
				shadowCamera.transform.rotation = quaternion;
				shadowCamera.worldToCameraMatrix = inverse;
				shadowCamera.projectionMatrix = gPUProjectionMatrix;
				if (shadowCamera.TryGetCullingParameters(out var cullingParameters))
				{
					CullingResults cullingResults;
					if (PugRP.useSharedCullPass)
					{
						cullingResults = PugRP.sharedCullingResults;
					}
					else
					{
						cullingParameters.cullingOptions = CullingOptions.ForceEvenIfCameraIsNotActive | CullingOptions.ShadowCasters;
						cullingResults = context.Cull(ref cullingParameters);
						PugRP.cullOps++;
					}
					PugRP.DrawShadowGeometry(context, cmd, shadowCamera, cullingResults);
					cmd.CopyTexture(s_shadowTarget, 0, s_pointShadows, (int)(shadowData.atlasIndex * 6 + cubemapFace));
				}
				cmd.EndSample(s_cubemapFaceNames[(int)cubemapFace]);
			}
			cmd.SetInvertCulling(invertCulling: false);
		}

		private static void RenderSpotlightShadow(ScriptableRenderContext context, CommandBuffer cmd, Light light, ShadowData shadowData, Camera shadowCamera)
		{
			GetSpotlightMatrices(light, out var view, out var projection);
			cmd.SetRenderTarget(s_spotShadows, 0, CubemapFace.Unknown, shadowData.atlasIndex);
			cmd.ClearRenderTarget(clearDepth: true, clearColor: false, Color.clear);
			cmd.SetViewProjectionMatrices(view, projection);
			shadowCamera.transform.position = light.transform.position;
			shadowCamera.transform.rotation = light.transform.rotation;
			shadowCamera.worldToCameraMatrix = view;
			shadowCamera.projectionMatrix = projection;
			if (shadowCamera.TryGetCullingParameters(out var cullingParameters))
			{
				CullingResults cullingResult;
				if (PugRP.useSharedCullPass)
				{
					cullingResult = PugRP.sharedCullingResults;
				}
				else
				{
					cullingParameters.cullingOptions = CullingOptions.ForceEvenIfCameraIsNotActive | CullingOptions.ShadowCasters;
					cullingResult = context.Cull(ref cullingParameters);
					PugRP.cullOps++;
				}
				RendererListDesc rendererListDesc = new RendererListDesc(PugRP.shadowCasterCubeShaderTagId, cullingResult, shadowCamera);
				rendererListDesc.sortingCriteria = SortingCriteria.OptimizeStateChanges;
				rendererListDesc.renderQueueRange = RenderQueueRange.opaque;
				rendererListDesc.layerMask = PugRP.asset.shadowCastingLayers;
				RendererListDesc desc = rendererListDesc;
				RendererList rendererList = context.CreateRendererList(desc);
				cmd.DrawRendererList(rendererList);
			}
		}

		private static void RenderRaymapShadow(ScriptableRenderContext context, CommandBuffer cmd, Light light, ShadowData shadowData, ShadowType type)
		{
			Matrix4x4 raymapWorldToShadow = GetRaymapWorldToShadow(light);
			cmd.SetGlobalMatrix(ShaderIDs.WorldToShadow, raymapWorldToShadow);
			cmd.SetGlobalMatrix(ShaderIDs.ShadowToWorld, raymapWorldToShadow.inverse);
			cmd.SetRenderTarget(s_shadowTarget);
			cmd.SetRenderTarget((type == ShadowType.Point) ? s_pointShadows : s_spotShadows, 0, CubemapFace.Unknown, shadowData.atlasIndex);
			cmd.DrawMesh(PugRPUtils.quad, Matrix4x4.identity, s_shadowUtilityMaterial, 0, 1);
		}

		private static bool CanAllocateShadowData(Light light)
		{
			return TypeFromLight(light) switch
			{
				ShadowType.Point => s_pointIndices.Count > 0, 
				ShadowType.Spot => s_spotIndices.Count > 0, 
				_ => false, 
			};
		}

		private static ShadowData AllocateShadowData(Light light)
		{
			ShadowType type = TypeFromLight(light);
			ShadowData result = new ShadowData
			{
				type = type,
				atlasIndex = GetAtlasIndex(type)
			};
			SetLightDirty(light);
			return result;
		}

		private static void DeallocateShadowData(ShadowData shadowData)
		{
			ReturnAtlasIndex(shadowData.atlasIndex, shadowData.type);
		}

		private static int GetAtlasIndex(ShadowType type)
		{
			return type switch
			{
				ShadowType.Point => s_pointIndices.Pop(), 
				ShadowType.Spot => s_spotIndices.Pop(), 
				_ => -1, 
			};
		}

		private static void ReturnAtlasIndex(int atlasIndex, ShadowType type)
		{
			switch (type)
			{
			case ShadowType.Point:
				s_pointIndices.Push(atlasIndex);
				break;
			case ShadowType.Spot:
				s_spotIndices.Push(atlasIndex);
				break;
			}
		}

		private static ShadowType TypeFromLight(Light light)
		{
			if (light.shadows == LightShadows.None)
			{
				return ShadowType.Invalid;
			}
			if (light.type == LightType.Point)
			{
				return ShadowType.Point;
			}
			if (light.type == LightType.Spot)
			{
				return ShadowType.Spot;
			}
			return ShadowType.Invalid;
		}
	}
}
