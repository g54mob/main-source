using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	internal static class Helpers
	{
		public static class ShaderIDs
		{
			public static readonly int s_MainTexture = Shader.PropertyToID("_Utility_MainTexture");
		}

		public static class Undo
		{
			private static class Symbols
			{
				public const string k_UnityEditor = "UNITY_EDITOR";
			}

			[Conditional("UNITY_EDITOR")]
			public static void RecordObject(UnityEngine.Object @object, string label)
			{
			}

			[Conditional("UNITY_EDITOR")]
			public static void SetSiblingIndex(Transform transform, int index, string label)
			{
			}

			[Conditional("UNITY_EDITOR")]
			public static void RegisterCreatedObjectUndo(UnityEngine.Object @object, string label)
			{
			}
		}

		private static Mesh s_Plane;

		private static Mesh s_Quad;

		private static Mesh s_SphereMesh;

		public static BindingFlags s_AnyMethod = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		private static readonly GraphicsFormat s_FallbackGraphicsFormat = GraphicsFormat.R16G16B16A16_SFloat;

		internal static readonly GraphicsFormatUsage s_DataGraphicsFormatUsage = GraphicsFormatUsage.Sample | GraphicsFormatUsage.Linear | GraphicsFormatUsage.LoadStore;

		private static readonly Matrix4x4 s_ScaleMatrix = Matrix4x4.Scale(new Vector3(1f, 1f, -1f));

		private static readonly List<bool> s_RenderFeatureActiveStates = new List<bool>();

		private static readonly FieldInfo s_RenderDataListField = typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic);

		private static readonly FieldInfo s_DefaultRendererIndex = typeof(UniversalRenderPipelineAsset).GetField("m_DefaultRendererIndex", BindingFlags.Instance | BindingFlags.NonPublic);

		private static readonly FieldInfo s_RendererIndex = typeof(UniversalAdditionalCameraData).GetField("m_RendererIndex", BindingFlags.Instance | BindingFlags.NonPublic);

		private static readonly UniversalRenderPipeline.SingleCameraRequest s_RenderSingleCameraRequest = new UniversalRenderPipeline.SingleCameraRequest();

		private static readonly UnityEngine.Rendering.RenderPipeline.StandardRequest s_RenderStandardRequest = new UnityEngine.Rendering.RenderPipeline.StandardRequest();

		private static readonly List<Terrain> s_Terrains = new List<Terrain>();

		public static Mesh PlaneMesh
		{
			get
			{
				if ((bool)s_Plane)
				{
					return s_Plane;
				}
				return s_Plane = Resources.GetBuiltinResource<Mesh>("New-Plane.fbx");
			}
		}

		public static Mesh QuadMesh
		{
			get
			{
				if ((bool)s_Quad)
				{
					return s_Quad;
				}
				return s_Quad = Resources.GetBuiltinResource<Mesh>("Quad.fbx");
			}
		}

		public static Mesh SphereMesh
		{
			get
			{
				if ((bool)s_SphereMesh)
				{
					return s_SphereMesh;
				}
				return s_SphereMesh = Resources.GetBuiltinResource<Mesh>("New-Sphere.fbx");
			}
		}

		public static WaitForEndOfFrame WaitForEndOfFrame { get; } = new WaitForEndOfFrame();

		public static bool IsWebGPU => SystemInfo.graphicsDeviceType == GraphicsDeviceType.WebGPU;

		public static bool RequiresCustomClear
		{
			get
			{
				if (!IsWebGPU)
				{
					return Application.platform == RuntimePlatform.PS5;
				}
				return true;
			}
		}

		internal static int SiblingIndexComparison(int x, int y)
		{
			return x.CompareTo(y);
		}

		internal static int DuplicateComparison(int x, int y)
		{
			int num = x.CompareTo(y);
			if (num == 0)
			{
				return 1;
			}
			return num;
		}

		public static UnityEngine.Object[] FindObjectsByType(Type type, FindObjectsInactive inactive = FindObjectsInactive.Exclude)
		{
			return UnityEngine.Object.FindObjectsByType(type, inactive, FindObjectsSortMode.None);
		}

		public static T[] FindObjectsByType<T>(FindObjectsInactive inactive = FindObjectsInactive.Exclude) where T : UnityEngine.Object
		{
			return UnityEngine.Object.FindObjectsByType<T>(inactive, FindObjectsSortMode.None);
		}

		private static Vector2Int CalculateResolution(Vector2 resolution, int maximum)
		{
			float num = Mathf.Max(resolution.x, resolution.y);
			if (num > (float)maximum)
			{
				float num2 = (float)maximum / num;
				resolution *= num2;
			}
			return new Vector2Int(Mathf.CeilToInt(resolution.x), Mathf.CeilToInt(resolution.y));
		}

		internal static Vector2Int CalculateResolutionFromTexelSize(Vector2 worldSize, float texelSize, int maximum)
		{
			return CalculateResolution(new Vector2(worldSize.x / texelSize, worldSize.y / texelSize), maximum);
		}

		internal static Vector2Int CalculateResolutionFromTexelDensity(Vector2 worldSize, float texelDensity, int maximum)
		{
			return CalculateResolution(new Vector2(Mathf.RoundToInt(texelDensity * worldSize.x), Mathf.RoundToInt(texelDensity * worldSize.y)), maximum);
		}

		public static Vector2 RotateAndEncapsulateXZ(Vector2 size, float angle)
		{
			angle = Mathf.PingPong(angle, 90f);
			float num = Mathf.Cos(angle * (MathF.PI / 180f));
			float num2 = Mathf.Sin(angle * (MathF.PI / 180f));
			return new Vector2(size.x * num + size.y * num2, size.y * num + size.x * num2);
		}

		public static T GetCustomAttribute<T>(Type type) where T : Attribute
		{
			return (T)Attribute.GetCustomAttribute(type, typeof(T));
		}

		public static float Fmod(float x, float y)
		{
			return x - y * (float)Math.Truncate(x / y);
		}

		public static float NonLinearToLinear01Depth(float depth, Vector4 zBufferParameters)
		{
			return 1f / (zBufferParameters.x * depth + zBufferParameters.y);
		}

		public static float NonLinearToLinearEyeDepth(float depth, Vector4 zBufferParameters)
		{
			return 1f / (zBufferParameters.z * depth + zBufferParameters.w);
		}

		public static float LinearDepthToNonLinear(float depth, Vector4 zBufferParameters)
		{
			return (1f - depth * zBufferParameters.y) / (depth * zBufferParameters.x);
		}

		public static float EyeDepthToNonLinear(float depth, Vector4 zBufferParameters)
		{
			return (1f - depth * zBufferParameters.w) / (depth * zBufferParameters.z);
		}

		public static Vector4 GetZBufferParameters(Camera camera)
		{
			float nearClipPlane = camera.nearClipPlane;
			float farClipPlane = camera.farClipPlane;
			float num = (Mathf.Approximately(nearClipPlane, 0f) ? 0f : (1f / nearClipPlane));
			float num2 = (Mathf.Approximately(farClipPlane, 0f) ? 0f : (1f / farClipPlane));
			float num3 = 1f - farClipPlane * num;
			float num4 = farClipPlane * num;
			Vector4 result = new Vector4(num3, num4, num3 * num2, num4 * num2);
			if (SystemInfo.usesReversedZBuffer)
			{
				result.y += result.x;
				result.x = 0f - result.x;
				result.w += result.z;
				result.z = 0f - result.z;
			}
			return result;
		}

		public static GameObject InstantiatePrefab(GameObject prefab)
		{
			return UnityEngine.Object.Instantiate(prefab);
		}

		public static bool StartsWithNoAlloc(this string a, string b)
		{
			int length = a.Length;
			int length2 = b.Length;
			int num = 0;
			int num2 = 0;
			while (num < length && num2 < length2 && a[num] == b[num2])
			{
				num++;
				num2++;
			}
			return num2 == length2;
		}

		public static void ReadRenderTexturePixels(ref RenderTexture rt, ref Texture2D texture, int slice = -1)
		{
			RenderTexture renderTexture = rt;
			int num;
			if (slice > -1)
			{
				num = ((rt.volumeDepth > 1) ? 1 : 0);
				if (num != 0)
				{
					RenderTextureDescriptor descriptor = rt.descriptor;
					descriptor.volumeDepth = 1;
					renderTexture = RenderTexture.GetTemporary(descriptor);
					Graphics.CopyTexture(rt, slice, 0, renderTexture, 0, 0);
				}
			}
			else
			{
				num = 0;
			}
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			texture.ReadPixels(new Rect(0f, 0f, texture.width, texture.height), 0, 0, recalculateMipMaps: false);
			texture.Apply();
			RenderTexture.active = active;
			if (num != 0)
			{
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(renderTexture);
			}
		}

		public static void ReadRenderTexturePixel(ref RenderTexture rt, ref Texture2D texture, int x, int y, int slice = 0)
		{
			RenderTextureDescriptor descriptor = rt.descriptor;
			descriptor.width = 1;
			descriptor.height = 1;
			descriptor.volumeDepth = 1;
			RenderTexture temporary = RenderTexture.GetTemporary(descriptor);
			Graphics.CopyTexture(rt, slice, 0, x, y, 1, 1, temporary, 0, 0, 0, 0);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = temporary;
			texture.ReadPixels(new Rect(0f, 0f, texture.width, texture.height), 0, 0, recalculateMipMaps: false);
			texture.Apply();
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
		}

		public static void Blit(RenderTexture source, RenderTexture target)
		{
			RenderTexture active = RenderTexture.active;
			Graphics.Blit(source, target);
			RenderTexture.active = active;
		}

		public static float ConvertDepthBufferValueToDistance(Camera camera, float depth)
		{
			float num;
			float num2;
			if (SystemInfo.usesReversedZBuffer)
			{
				num = 1f;
				num2 = camera.farClipPlane / camera.nearClipPlane - 1f;
			}
			else
			{
				num = camera.farClipPlane / camera.nearClipPlane;
				num2 = 1f - num;
			}
			return 1f / (num2 / camera.farClipPlane * depth + num / camera.farClipPlane);
		}

		public static bool IsMSAAEnabled(Camera camera)
		{
			bool flag = camera.allowMSAA;
			if (RenderPipelineHelper.IsUniversal)
			{
				flag = flag || Rendering.EnabledXR;
			}
			if (RenderPipelineHelper.IsUniversal)
			{
				flag = flag && camera.GetUniversalAdditionalCameraData().scriptableRenderer.supportedRenderingFeatures.msaa;
			}
			return ((!flag) ? 1 : QualitySettings.antiAliasing) > 1;
		}

		public static bool IsIntelGPU()
		{
			return SystemInfo.graphicsDeviceName.ToLowerInvariant().Contains("intel");
		}

		public static bool MaskIncludesLayer(int mask, int layer)
		{
			return mask == (mask | (1 << layer));
		}

		private static bool SupportsRandomWriteOnRenderTextureFormat(GraphicsFormat format)
		{
			RenderTextureFormat renderTextureFormat = GraphicsFormatUtility.GetRenderTextureFormat(format);
			if (Enum.IsDefined(typeof(RenderTextureFormat), renderTextureFormat))
			{
				return SystemInfo.SupportsRandomWriteOnRenderTextureFormat(renderTextureFormat);
			}
			return false;
		}

		private static GraphicsFormat GetWebGPUTextureFormat(GraphicsFormat format)
		{
			if (GraphicsFormatUtility.GetComponentCount(format) == 1)
			{
				return GraphicsFormat.R32_SFloat;
			}
			return GraphicsFormat.R32G32B32A32_SFloat;
		}

		internal static GraphicsFormat GetCompatibleTextureFormat(GraphicsFormat format, GraphicsFormatUsage usage, string label, bool randomWrite = false)
		{
			GraphicsFormat graphicsFormat = SystemInfo.GetCompatibleFormat(format, usage);
			bool flag = graphicsFormat == GraphicsFormat.None;
			if (GraphicsDeviceType.Metal != SystemInfo.graphicsDeviceType && !flag && randomWrite && !SupportsRandomWriteOnRenderTextureFormat(graphicsFormat))
			{
				flag = true;
			}
			if (flag)
			{
				graphicsFormat = s_FallbackGraphicsFormat;
			}
			if (randomWrite && IsWebGPU)
			{
				graphicsFormat = GetWebGPUTextureFormat(format);
			}
			return graphicsFormat;
		}

		public static GraphicsFormat GetCompatibleTextureFormat(GraphicsFormat format, bool randomWrite)
		{
			if (randomWrite && IsWebGPU)
			{
				format = GetWebGPUTextureFormat(format);
			}
			return format;
		}

		public static void SetGlobalKeyword(string keyword, bool enabled)
		{
			if (enabled)
			{
				Shader.EnableKeyword(keyword);
			}
			else
			{
				Shader.DisableKeyword(keyword);
			}
		}

		public static void RenderTargetIdentifierXR(ref RenderTexture texture, ref RenderTargetIdentifier target)
		{
			target = new RenderTargetIdentifier(texture, 0, CubemapFace.Unknown, -1);
		}

		public static RenderTargetIdentifier RenderTargetIdentifierXR(int id)
		{
			return new RenderTargetIdentifier(id, 0, CubemapFace.Unknown, -1);
		}

		public static void CreateRenderTargetTextureReference(ref RenderTexture texture, ref RenderTargetIdentifier target)
		{
			if (texture == null)
			{
				texture = new RenderTexture(0, 0, 0);
			}
			RenderTargetIdentifierXR(ref texture, ref target);
		}

		public static void SafeCreateRenderTexture(ref RenderTexture texture, RenderTextureDescriptor descriptor)
		{
			if (texture == null)
			{
				texture = new RenderTexture(descriptor);
				return;
			}
			if (texture.IsCreated())
			{
				texture.Release();
			}
			texture.descriptor = descriptor;
		}

		public static void SafeCreateRenderTexture(string name, ref RenderTexture texture, RenderTextureDescriptor descriptor)
		{
			if (texture == null)
			{
				texture = new RenderTexture(descriptor);
				texture.name = name;
			}
			else
			{
				if (texture.IsCreated())
				{
					texture.Release();
				}
				texture.descriptor = descriptor;
			}
			texture.Create();
		}

		public static void ClearRenderTexture(RenderTexture texture, Color clear, bool depth = true, bool color = true)
		{
			RenderTexture active = RenderTexture.active;
			Graphics.SetRenderTarget(texture, 0, CubemapFace.Unknown, -1);
			GL.Clear(depth, color, clear);
			RenderTexture.active = active;
		}

		public static void VerticallyFlipRenderTexture(RenderTexture target, bool force = false)
		{
			if (force || SystemInfo.graphicsUVStartsAtTop)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(target.descriptor);
				Graphics.Blit(target, temporary, new Vector2(1f, -1f), new Vector2(0f, 1f));
				Graphics.Blit(temporary, target);
				RenderTexture.ReleaseTemporary(temporary);
			}
		}

		public static bool RenderTargetTextureNeedsUpdating(RenderTexture texture, RenderTextureDescriptor descriptor)
		{
			if (descriptor.width == texture.width && descriptor.height == texture.height && descriptor.volumeDepth == texture.volumeDepth)
			{
				return descriptor.useDynamicScale != texture.useDynamicScale;
			}
			return true;
		}

		public static bool RenderTextureNeedsUpdating(RenderTexture t1, RenderTexture t2)
		{
			if (t1.width == t2.width && t1.height == t2.height && t1.volumeDepth == t2.volumeDepth)
			{
				return t1.graphicsFormat != t2.graphicsFormat;
			}
			return true;
		}

		public static bool RenderTextureNeedsUpdating(RenderTextureDescriptor t1, RenderTextureDescriptor t2)
		{
			if (t1.width == t2.width && t1.height == t2.height && t1.volumeDepth == t2.volumeDepth)
			{
				return t1.graphicsFormat != t2.graphicsFormat;
			}
			return true;
		}

		public static int CalculateMipMapCount(int maximumDimension)
		{
			return Mathf.FloorToInt(Mathf.Log(maximumDimension, 2f));
		}

		public static void Destroy(UnityEngine.Object @object, bool undo = false)
		{
			UnityEngine.Object.Destroy(@object);
		}

		public static Matrix4x4 CalculateWorldToCameraMatrixRHS(Vector3 position, Quaternion rotation)
		{
			return s_ScaleMatrix * Matrix4x4.TRS(position, rotation, Vector3.one).inverse;
		}

		public static void Blit(CommandBuffer buffer, RenderTargetIdentifier target, Material material, int pass = -1, MaterialPropertyBlock properties = null)
		{
			CoreUtils.SetRenderTarget(buffer, target);
			buffer.DrawProcedural(Matrix4x4.identity, material, pass, MeshTopology.Triangles, 3, 1, properties);
		}

		public static void Blit(CommandBuffer buffer, RenderTexture target, Material material, int pass = -1, int depthSlice = -1, MaterialPropertyBlock properties = null)
		{
			buffer.SetRenderTarget(target, 0, CubemapFace.Unknown, depthSlice);
			buffer.DrawProcedural(Matrix4x4.identity, material, pass, MeshTopology.Triangles, 3, 1, properties);
		}

		[Conditional("d_UnityURP")]
		public static void ScaleViewport(Camera camera, CommandBuffer buffer, RTHandle handle)
		{
			if (RenderPipelineHelper.IsUniversal && !camera.allowDynamicResolution)
			{
				Vector2Int scaledSize = handle.GetScaledSize(handle.rtHandleProperties.currentViewportSize);
				if (!(scaledSize == Vector2Int.zero))
				{
					buffer.SetViewport(new Rect(0f, 0f, scaledSize.x, scaledSize.y));
				}
			}
		}

		public static void SetShaderVector(Material material, int nameID, Vector4 value, bool global = false)
		{
			if (global)
			{
				Shader.SetGlobalVector(nameID, value);
			}
			else
			{
				material.SetVector(nameID, value);
			}
		}

		public static void SetShaderInteger(Material material, int nameID, int value, bool global = false)
		{
			if (global)
			{
				Shader.SetGlobalInteger(nameID, value);
			}
			else
			{
				material.SetInteger(nameID, value);
			}
		}

		public static void SetShaderFloat(Material material, int nameID, float value, bool global = false)
		{
			if (global)
			{
				Shader.SetGlobalFloat(nameID, value);
			}
			else
			{
				material.SetFloat(nameID, value);
			}
		}

		public static bool GetGlobalBoolean(int id)
		{
			return Shader.GetGlobalFloat(id) != 0f;
		}

		public static void SetGlobalBoolean(int id, bool value)
		{
			Shader.SetGlobalFloat(id, value ? 1f : 0f);
		}

		internal static ScriptableRendererData[] UniversalRendererData(UniversalRenderPipelineAsset asset)
		{
			return (ScriptableRendererData[])s_RenderDataListField.GetValue(asset);
		}

		internal static int GetRendererIndex(Camera camera)
		{
			int num = (int)s_RendererIndex.GetValue(camera.GetUniversalAdditionalCameraData());
			if (num < 0)
			{
				num = (int)s_DefaultRendererIndex.GetValue(UniversalRenderPipeline.asset);
			}
			return num;
		}

		internal static bool IsSSAOEnabled(Camera camera)
		{
			ScriptableRendererData[] obj = (ScriptableRendererData[])s_RenderDataListField.GetValue(UniversalRenderPipeline.asset);
			int rendererIndex = GetRendererIndex(camera);
			foreach (ScriptableRendererFeature rendererFeature in obj[rendererIndex].rendererFeatures)
			{
				if (rendererFeature.GetType().Name == "ScreenSpaceAmbientOcclusion")
				{
					return rendererFeature.isActive;
				}
			}
			return false;
		}

		internal static void UniversalRenderCamera(ScriptableRenderContext context, Camera camera, int slice)
		{
			s_RenderSingleCameraRequest.destination = camera.targetTexture;
			s_RenderSingleCameraRequest.slice = slice;
			UnityEngine.Rendering.RenderPipeline.SubmitRenderRequest(camera, s_RenderSingleCameraRequest);
		}

		internal static void UniversalRenderCamera(ScriptableRenderContext context, Camera camera, int slice, bool noRenderFeatures)
		{
			UniversalRendererData universalRendererData = (UniversalRendererData)((ScriptableRendererData[])s_RenderDataListField.GetValue(UniversalRenderPipeline.asset))[GetRendererIndex(camera)];
			bool flag = !noRenderFeatures && universalRendererData.intermediateTextureMode == IntermediateTextureMode.Always;
			if (!flag)
			{
				foreach (ScriptableRendererFeature rendererFeature in universalRendererData.rendererFeatures)
				{
					if (!(rendererFeature == null))
					{
						s_RenderFeatureActiveStates.Add(rendererFeature.isActive);
						rendererFeature.SetActive(active: false);
					}
				}
			}
			UniversalRenderCamera(context, camera, slice);
			if (flag)
			{
				return;
			}
			int num = 0;
			foreach (ScriptableRendererFeature rendererFeature2 in universalRendererData.rendererFeatures)
			{
				if (!(rendererFeature2 == null))
				{
					rendererFeature2.SetActive(s_RenderFeatureActiveStates[num++]);
				}
			}
			s_RenderFeatureActiveStates.Clear();
		}

		internal static void RenderCameraWithoutCustomPasses(Camera camera)
		{
			ScriptableRendererData[] array = (ScriptableRendererData[])s_RenderDataListField.GetValue(UniversalRenderPipeline.asset);
			int rendererIndex = GetRendererIndex(camera);
			foreach (ScriptableRendererFeature rendererFeature in array[rendererIndex].rendererFeatures)
			{
				if (!(rendererFeature == null))
				{
					s_RenderFeatureActiveStates.Add(rendererFeature.isActive);
					rendererFeature.SetActive(active: false);
				}
			}
			camera.Render();
			int num = 0;
			foreach (ScriptableRendererFeature rendererFeature2 in array[rendererIndex].rendererFeatures)
			{
				if (!(rendererFeature2 == null))
				{
					rendererFeature2.SetActive(s_RenderFeatureActiveStates[num++]);
				}
			}
			s_RenderFeatureActiveStates.Clear();
		}

		public static void RenderCamera(Camera camera, ScriptableRenderContext context, int slice, bool noRenderFeatures = false)
		{
			if (RenderPipelineHelper.IsUniversal)
			{
				UniversalRenderCamera(context, camera, slice, noRenderFeatures);
			}
			else
			{
				camera.Render();
			}
		}

		internal static Terrain GetTerrainAtPosition(Vector2 position)
		{
			Terrain.GetActiveTerrains(s_Terrains);
			foreach (Terrain s_Terrain in s_Terrains)
			{
				if (!(s_Terrain.terrainData == null) && new Rect(s_Terrain.transform.position.XZ(), s_Terrain.terrainData.size.XZ()).Contains(position))
				{
					return s_Terrain;
				}
			}
			return null;
		}
	}
}
