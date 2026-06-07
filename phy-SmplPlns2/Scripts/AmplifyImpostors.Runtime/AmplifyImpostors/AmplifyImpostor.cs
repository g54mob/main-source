using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace AmplifyImpostors
{
	[HelpURL("https://wiki.amplify.pt/index.php?title=Unity_Products:Amplify_Impostors/Manual")]
	public class AmplifyImpostor : MonoBehaviour
	{
		private enum RenderImpostorMode
		{
			Alpha = 0,
			Normal = 1
		}

		public const string DefaultPreset = "e4786beb7716da54dbb02a632681cc37";

		public const string ShaderBiRP = "e82933f4c0eb9ba42aab0739f48efe21";

		public const string ShaderOctaBiRP = "572f9be5706148142b8da6e9de53acdb";

		public const string ShaderHDRP = "175c951fec709c44fa2f26b8ab78b8dd";

		public const string ShaderOctaHDRP = "56236dc63ad9b7949b63a27f0ad180b3";

		public const string ShaderURP = "da79d698f4bf0164e910ad798d07efdf";

		public const string ShaderOctaURP = "83dd8de9a5c14874884f9012def4fdcc";

		public const string DilateGUID = "57c23892d43bc9f458360024c5985405";

		public const string PackerGUID = "31bd3cd74692f384a916d9d7ea87710d";

		public const string GBufferToOutputGUID = "9587d58ea8f1dac478d1adbf2a63d31f";

		private const string GlobalShaderVariablesQualifiedNameHDRP = "UnityEngine.Rendering.HighDefinition.ShaderVariablesGlobal, Unity.RenderPipelines.HighDefinition.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";

		public static readonly int _DetailNormalMap_PID = Shader.PropertyToID("_DetailNormalMap");

		[SerializeField]
		private AmplifyImpostorAsset m_data;

		[SerializeField]
		private Transform m_rootTransform;

		[SerializeField]
		private LODGroup m_lodGroup;

		[SerializeField]
		private Renderer[] m_renderers;

		public LODReplacement m_lodReplacement = LODReplacement.ReplaceLast;

		[SerializeField]
		public RenderPipelineInUse m_renderPipelineInUse;

		public int m_insertIndex = 1;

		[SerializeField]
		public GameObject m_lastImpostor;

		[SerializeField]
		public string m_folderPath;

		[NonSerialized]
		public string m_impostorName = string.Empty;

		[SerializeField]
		public CutMode m_cutMode;

		[NonSerialized]
		private const float StartXRotation = -90f;

		[NonSerialized]
		private const float StartYRotation = 90f;

		[NonSerialized]
		private const int MinAlphaResolution = 256;

		[NonSerialized]
		private RenderTexture[] m_rtGBuffers;

		[NonSerialized]
		private RenderTexture[] m_outBuffers;

		[NonSerialized]
		private RenderTexture[] m_alphaGBuffers;

		[NonSerialized]
		private RenderTexture m_trueDepth;

		[NonSerialized]
		public Texture2D m_alphaTex;

		[NonSerialized]
		private float m_xyFitSize;

		[NonSerialized]
		private float m_depthFitSize;

		[NonSerialized]
		private Vector2 m_pixelOffset = Vector2.zero;

		[NonSerialized]
		private Bounds m_originalBound;

		[NonSerialized]
		private Vector3 m_oriPos = Vector3.zero;

		[NonSerialized]
		private Quaternion m_oriRot = Quaternion.identity;

		[NonSerialized]
		private Vector3 m_oriSca = Vector3.one;

		[NonSerialized]
		private const int BlockSize = 65536;

		[NonSerialized]
		private Matrix4x4[] m_cameraInvViewProjPerFrame;

		public AmplifyImpostorAsset Data
		{
			get
			{
				return m_data;
			}
			set
			{
				m_data = value;
			}
		}

		public Transform RootTransform
		{
			get
			{
				return m_rootTransform;
			}
			set
			{
				m_rootTransform = value;
			}
		}

		public LODGroup LodGroup
		{
			get
			{
				return m_lodGroup;
			}
			set
			{
				m_lodGroup = value;
			}
		}

		public Renderer[] Renderers
		{
			get
			{
				return m_renderers;
			}
			set
			{
				m_renderers = value;
			}
		}

		private void GenerateTextures(List<TextureOutput> outputList, bool standardRendering)
		{
			m_outBuffers = new RenderTexture[outputList.Count];
			for (int i = 0; i < outputList.Count; i++)
			{
				m_outBuffers[i] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, (!outputList[i].SRGB) ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32);
				m_outBuffers[i].Create();
			}
			if (standardRendering)
			{
				m_rtGBuffers = new RenderTexture[4];
				if (m_renderPipelineInUse == RenderPipelineInUse.HDRP)
				{
					m_rtGBuffers[0] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R8G8B8A8_SRGB);
					m_rtGBuffers[0].Create();
					m_rtGBuffers[1] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R8G8B8A8_UNorm);
					m_rtGBuffers[1].Create();
					m_rtGBuffers[2] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R8G8B8A8_UNorm);
					m_rtGBuffers[2].Create();
					m_rtGBuffers[3] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R16G16B16A16_SFloat);
					m_rtGBuffers[3].Create();
				}
				else if (m_renderPipelineInUse == RenderPipelineInUse.URP)
				{
					m_rtGBuffers[0] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R8G8B8A8_SRGB);
					m_rtGBuffers[0].Create();
					m_rtGBuffers[1] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R8G8B8A8_UNorm);
					m_rtGBuffers[1].Create();
					m_rtGBuffers[2] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R8G8B8A8_SNorm);
					m_rtGBuffers[2].Create();
					m_rtGBuffers[3] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R16G16B16A16_SFloat);
					m_rtGBuffers[3].Create();
				}
				else
				{
					m_rtGBuffers[0] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R8G8B8A8_SRGB);
					m_rtGBuffers[0].Create();
					m_rtGBuffers[1] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R8G8B8A8_SRGB);
					m_rtGBuffers[1].Create();
					m_rtGBuffers[2] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.A2B10G10R10_UNormPack32);
					m_rtGBuffers[2].Create();
					m_rtGBuffers[3] = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, GraphicsFormat.R16G16B16A16_SFloat);
					m_rtGBuffers[3].Create();
				}
			}
			else
			{
				m_rtGBuffers = m_outBuffers;
			}
			m_trueDepth = new RenderTexture((int)m_data.TexSize.x, (int)m_data.TexSize.y, 16, RenderTextureFormat.Depth);
			m_trueDepth.Create();
		}

		private void GenerateAlphaTextures(int targetAmount)
		{
			m_alphaGBuffers = new RenderTexture[targetAmount];
			for (int i = 0; i < m_alphaGBuffers.Length; i++)
			{
				m_alphaGBuffers[i] = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
				m_alphaGBuffers[i].Create();
			}
			m_trueDepth = new RenderTexture(256, 256, 16, RenderTextureFormat.Depth);
			m_trueDepth.Create();
		}

		private void ClearBuffers()
		{
			RenderTexture.active = null;
			RenderTexture[] rtGBuffers = m_rtGBuffers;
			for (int i = 0; i < rtGBuffers.Length; i++)
			{
				rtGBuffers[i].Release();
			}
			m_rtGBuffers = null;
			rtGBuffers = m_outBuffers;
			for (int i = 0; i < rtGBuffers.Length; i++)
			{
				rtGBuffers[i].Release();
			}
			m_outBuffers = null;
		}

		private void ClearAlphaBuffers()
		{
			RenderTexture.active = null;
			RenderTexture[] alphaGBuffers = m_alphaGBuffers;
			for (int i = 0; i < alphaGBuffers.Length; i++)
			{
				alphaGBuffers[i].Release();
			}
			m_alphaGBuffers = null;
		}

		public static void GetFrameInfo(AmplifyImpostorAsset data, out int hframes, out int vframes)
		{
			hframes = data.HorizontalFrames;
			vframes = ((data.ImpostorType == ImpostorType.Spherical && data.DecoupleAxisFrames) ? data.VerticalFrames : data.HorizontalFrames);
		}

		private Cubemap CreateBlackCubemap()
		{
			Cubemap cubemap = new Cubemap(1, TextureFormat.RGBA32, mipChain: false);
			cubemap.name = "BlackCube";
			cubemap.SetPixel(CubemapFace.PositiveX, 1, 1, Color.black);
			cubemap.SetPixel(CubemapFace.NegativeX, 1, 1, Color.black);
			cubemap.SetPixel(CubemapFace.PositiveY, 1, 1, Color.black);
			cubemap.SetPixel(CubemapFace.NegativeY, 1, 1, Color.black);
			cubemap.SetPixel(CubemapFace.PositiveZ, 1, 1, Color.black);
			cubemap.SetPixel(CubemapFace.NegativeZ, 1, 1, Color.black);
			cubemap.Apply(updateMipmaps: false, makeNoLongerReadable: true);
			return cubemap;
		}

		private unsafe void CopyConstantStructToArray(object constants, Vector4[] array, int stride)
		{
			GCHandle gCHandle = GCHandle.Alloc(constants, GCHandleType.Pinned);
			try
			{
				IntPtr intPtr = gCHandle.AddrOfPinnedObject();
				fixed (Vector4* destination = array)
				{
					Buffer.MemoryCopy((void*)intPtr, destination, stride, stride);
				}
			}
			finally
			{
				gCHandle.Free();
			}
		}

		private void RenderImpostor(int targetAmount, RenderImpostorMode mode, bool useMinResolution = false, Shader customShader = null)
		{
			if (targetAmount <= 0)
			{
				return;
			}
			bool flag = customShader == null;
			Dictionary<Material, Material> dictionary = new Dictionary<Material, Material>();
			CommandBuffer commandBuffer = new CommandBuffer();
			if (mode == RenderImpostorMode.Normal)
			{
				commandBuffer.name = "GBufferCatcher";
				RenderTargetIdentifier[] array = new RenderTargetIdentifier[targetAmount];
				for (int i = 0; i < targetAmount; i++)
				{
					array[i] = m_rtGBuffers[i];
				}
				commandBuffer.SetRenderTarget(array, m_trueDepth);
				commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear, 1f);
			}
			if (mode == RenderImpostorMode.Alpha)
			{
				commandBuffer.name = "DepthAlphaCatcher";
				RenderTargetIdentifier[] array2 = new RenderTargetIdentifier[targetAmount];
				for (int j = 0; j < targetAmount; j++)
				{
					array2[j] = m_alphaGBuffers[j];
				}
				commandBuffer.SetRenderTarget(array2, m_trueDepth);
				commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear, 1f);
			}
			GetFrameInfo(m_data, out var hframes, out var vframes);
			List<MeshFilter> list = new List<MeshFilter>();
			for (int k = 0; k < Renderers.Length; k++)
			{
				if (Renderers[k] == null || !Renderers[k].enabled || Renderers[k].shadowCastingMode == ShadowCastingMode.ShadowsOnly)
				{
					list.Add(null);
					continue;
				}
				MeshFilter component = Renderers[k].GetComponent<MeshFilter>();
				if (component == null || component.sharedMesh == null)
				{
					list.Add(null);
				}
				else
				{
					list.Add(component);
				}
			}
			int count = list.Count;
			Type type = null;
			ComputeBuffer computeBuffer = null;
			object obj = null;
			Vector4[] array3 = null;
			if (m_renderPipelineInUse == RenderPipelineInUse.HDRP)
			{
				type = Type.GetType("UnityEngine.Rendering.HighDefinition.ShaderVariablesGlobal, Unity.RenderPipelines.HighDefinition.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
				if (type != null)
				{
					computeBuffer = new ComputeBuffer(1, Marshal.SizeOf(type), ComputeBufferType.Constant);
					array3 = new Vector4[computeBuffer.stride / Marshal.SizeOf<Vector4>()];
					obj = Activator.CreateInstance(type, nonPublic: true);
				}
			}
			Cubemap cubemap = CreateBlackCubemap();
			Bounds bounds = default(Bounds);
			for (int l = 0; l < count; l++)
			{
				if (!(list[l] == null))
				{
					if (bounds.size == Vector3.zero)
					{
						bounds = list[l].sharedMesh.bounds.Transform(m_rootTransform.worldToLocalMatrix * Renderers[l].localToWorldMatrix);
					}
					else
					{
						bounds.Encapsulate(list[l].sharedMesh.bounds.Transform(m_rootTransform.worldToLocalMatrix * Renderers[l].localToWorldMatrix));
					}
				}
			}
			m_originalBound = bounds;
			for (int m = 0; m < hframes; m++)
			{
				for (int n = 0; n < vframes; n++)
				{
					float num = m_xyFitSize * 0.5f;
					Matrix4x4 cameraRotationMatrix = GetCameraRotationMatrix(m_data.ImpostorType, hframes, vframes, m, n);
					Bounds bounds2 = bounds.Transform(cameraRotationMatrix);
					Matrix4x4 proj = Matrix4x4.Ortho(0f - num + m_pixelOffset.x, num + m_pixelOffset.x, 0f - num + m_pixelOffset.y, num + m_pixelOffset.y, 0f, 0f - m_depthFitSize);
					Matrix4x4 m2 = Matrix4x4.Inverse(cameraRotationMatrix) * Matrix4x4.LookAt(bounds2.center - new Vector3(0f, 0f, m_depthFitSize * 0.5f), bounds2.center, Vector3.up);
					m2 = Matrix4x4.Inverse(m2) * m_rootTransform.worldToLocalMatrix;
					commandBuffer.SetViewProjectionMatrices(m2, proj);
					proj = GL.GetGPUProjectionMatrix(proj, renderIntoTexture: true);
					Matrix4x4 matrix4x = proj * m2;
					Matrix4x4 matrix4x2 = Matrix4x4.Inverse(matrix4x);
					if (m_renderPipelineInUse == RenderPipelineInUse.HDRP)
					{
						if (obj != null)
						{
							type.GetField("_ViewMatrix").SetValue(obj, m2);
							type.GetField("_CameraViewMatrix").SetValue(obj, m2);
							type.GetField("_InvViewMatrix").SetValue(obj, Matrix4x4.Inverse(m2));
							type.GetField("_ProjMatrix").SetValue(obj, proj);
							type.GetField("_InvProjMatrix").SetValue(obj, Matrix4x4.Inverse(proj));
							type.GetField("_ViewProjMatrix").SetValue(obj, matrix4x);
							type.GetField("_CameraViewProjMatrix").SetValue(obj, matrix4x);
							type.GetField("_InvViewProjMatrix").SetValue(obj, matrix4x2);
							type.GetField("_ProbeExposureScale").SetValue(obj, 1);
						}
						CopyConstantStructToArray(obj, array3, computeBuffer.stride);
						commandBuffer.SetBufferData(computeBuffer, array3);
						commandBuffer.SetGlobalConstantBuffer(computeBuffer, "ShaderVariablesGlobal", 0, computeBuffer.stride);
					}
					else if (m_renderPipelineInUse == RenderPipelineInUse.URP)
					{
						commandBuffer.SetGlobalTexture("_GlossyEnvironmentCubeMap", cubemap);
					}
					if (mode == RenderImpostorMode.Normal && m_cameraInvViewProjPerFrame != null)
					{
						m_cameraInvViewProjPerFrame[n * hframes + m] = Matrix4x4.Transpose(matrix4x2);
					}
					commandBuffer.SetGlobalVector("unity_SHAr", Vector4.zero);
					commandBuffer.SetGlobalVector("unity_SHAg", Vector4.zero);
					commandBuffer.SetGlobalVector("unity_SHAb", Vector4.zero);
					commandBuffer.SetGlobalVector("unity_SHBr", Vector4.zero);
					commandBuffer.SetGlobalVector("unity_SHBg", Vector4.zero);
					commandBuffer.SetGlobalVector("unity_SHBb", Vector4.zero);
					commandBuffer.SetGlobalVector("unity_SHC", Vector4.zero);
					commandBuffer.SetGlobalTexture("unity_SpecCube0", cubemap);
					commandBuffer.SetGlobalTexture("unity_SpecCube1", cubemap);
					commandBuffer.SetGlobalVector("unity_SpecCube0_HDR", Vector4.zero);
					commandBuffer.SetGlobalVector("unity_SpecCube1_HDR", Vector4.zero);
					commandBuffer.SetGlobalVector("_AI_BoundsMin", m_originalBound.min);
					commandBuffer.SetGlobalVector("_AI_BoundsSize", m_originalBound.size);
					switch (mode)
					{
					case RenderImpostorMode.Normal:
					{
						float width2 = m_data.TexSize.x / (float)m_data.HorizontalFrames;
						float height2 = m_data.TexSize.y / (float)m_data.VerticalFrames;
						commandBuffer.SetViewport(new Rect(m_data.TexSize.x / (float)hframes * (float)m, m_data.TexSize.y / (float)vframes * (float)n, width2, height2));
						break;
					}
					case RenderImpostorMode.Alpha:
					{
						float width = 256f;
						float height = 256f;
						commandBuffer.SetViewport(new Rect(0f, 0f, width, height));
						break;
					}
					}
					for (int num2 = 0; num2 < count; num2++)
					{
						if (list[num2] == null)
						{
							continue;
						}
						Material[] sharedMaterials = Renderers[num2].sharedMaterials;
						for (int num3 = 0; num3 < sharedMaterials.Length; num3++)
						{
							Material value = null;
							_ = list[num2].sharedMesh;
							int num4 = 0;
							int num5 = 0;
							if (flag)
							{
								value = sharedMaterials[num3];
								num4 = value.FindPass("DEFERRED");
								if (num4 == -1)
								{
									num4 = value.FindPass("Deferred");
								}
								if (num4 == -1)
								{
									num4 = value.FindPass("GBuffer");
								}
								num5 = value.FindPass("DepthOnly");
								if (num4 == -1)
								{
									num4 = 0;
									for (int num6 = 0; num6 < value.passCount; num6++)
									{
										if (value.GetTag("LightMode", searchFallbacks: true).Equals("Deferred"))
										{
											num4 = num6;
											break;
										}
									}
								}
								commandBuffer.EnableShaderKeyword("UNITY_HDR_ON");
							}
							else
							{
								num5 = -1;
								if (!dictionary.TryGetValue(sharedMaterials[num3], out value))
								{
									value = new Material(customShader)
									{
										hideFlags = HideFlags.HideAndDontSave
									};
									value.CopyPropertiesFromMaterial(sharedMaterials[num3]);
									if (m_renderPipelineInUse == RenderPipelineInUse.URP && sharedMaterials[num3].HasProperty(_DetailNormalMap_PID) && sharedMaterials[num3].GetTexture(_DetailNormalMap_PID) == null)
									{
										value.SetTexture(_DetailNormalMap_PID, Texture2D.normalTexture);
									}
									dictionary.Add(sharedMaterials[num3], value);
								}
							}
							bool flag2 = Renderers[num2].lightmapIndex > -1;
							bool flag3 = Renderers[num2].realtimeLightmapIndex > -1;
							if ((flag2 || flag3) && !flag)
							{
								commandBuffer.EnableShaderKeyword("LIGHTMAP_ON");
								if (flag2)
								{
									commandBuffer.SetGlobalVector("unity_LightmapST", Renderers[num2].lightmapScaleOffset);
								}
								if (flag3)
								{
									commandBuffer.EnableShaderKeyword("DYNAMICLIGHTMAP_ON");
									commandBuffer.SetGlobalVector("unity_DynamicLightmapST", Renderers[num2].realtimeLightmapScaleOffset);
								}
								else
								{
									commandBuffer.DisableShaderKeyword("DYNAMICLIGHTMAP_ON");
								}
								if (flag2 && flag3)
								{
									commandBuffer.EnableShaderKeyword("DIRLIGHTMAP_COMBINED");
								}
								else
								{
									commandBuffer.DisableShaderKeyword("DIRLIGHTMAP_COMBINED");
								}
							}
							else
							{
								commandBuffer.DisableShaderKeyword("LIGHTMAP_ON");
								commandBuffer.DisableShaderKeyword("DYNAMICLIGHTMAP_ON");
								commandBuffer.DisableShaderKeyword("DIRLIGHTMAP_COMBINED");
							}
							commandBuffer.DisableShaderKeyword("LIGHTPROBE_SH");
							commandBuffer.DisableShaderKeyword("USING_STEREO_MATRICES");
							commandBuffer.DisableShaderKeyword("SHADEROPTIONS_CAMERA_RELATIVE_RENDERING");
							commandBuffer.DisableShaderKeyword("WRITE_DECAL_BUFFER");
							if (num5 > -1)
							{
								commandBuffer.DrawRenderer(Renderers[num2], value, num3, num5);
							}
							commandBuffer.DrawRenderer(Renderers[num2], value, num3, num4);
						}
					}
				}
			}
			Graphics.ExecuteCommandBuffer(commandBuffer);
			computeBuffer?.Release();
			list.Clear();
			UnityEngine.Object.DestroyImmediate(cubemap);
			foreach (KeyValuePair<Material, Material> item in dictionary)
			{
				Material value2 = item.Value;
				if (value2 != null)
				{
					if (!Application.isPlaying)
					{
						UnityEngine.Object.DestroyImmediate(value2);
					}
					value2 = null;
				}
			}
			dictionary.Clear();
			commandBuffer.Release();
			commandBuffer = null;
		}

		private static Matrix4x4 GetCameraRotationMatrix(ImpostorType impostorType, int hframes, int vframes, int x, int y)
		{
			Matrix4x4 result = Matrix4x4.identity;
			switch (impostorType)
			{
			case ImpostorType.Spherical:
			{
				float num = 0f;
				if (vframes > 0)
				{
					num = 0f - 180f / ((float)vframes - 1f);
				}
				Quaternion quaternion = Quaternion.Euler(num * (float)y + 90f, 0f, 0f);
				Quaternion quaternion2 = Quaternion.Euler(0f, 360f / (float)hframes * (float)x + -90f, 0f);
				result = Matrix4x4.Rotate(quaternion * quaternion2);
				break;
			}
			case ImpostorType.Octahedron:
			{
				Vector3 vector2 = OctahedronToVector((float)x / ((float)hframes - 1f) * 2f - 1f, (float)y / ((float)vframes - 1f) * 2f - 1f);
				result = Matrix4x4.Rotate(Quaternion.LookRotation(new Vector3(vector2.x * -1f, vector2.z * -1f, vector2.y * -1f), Vector3.up)).inverse;
				break;
			}
			case ImpostorType.HemiOctahedron:
			{
				Vector3 vector = HemiOctahedronToVector((float)x / ((float)hframes - 1f) * 2f - 1f, (float)y / ((float)vframes - 1f) * 2f - 1f);
				result = Matrix4x4.Rotate(Quaternion.LookRotation(new Vector3(vector.x * -1f, vector.z * -1f, vector.y * -1f), Vector3.up)).inverse;
				break;
			}
			}
			return result;
		}

		private static Vector3 OctahedronToVector(Vector2 oct)
		{
			Vector3 value = new Vector3(oct.x, oct.y, 1f - Mathf.Abs(oct.x) - Mathf.Abs(oct.y));
			float num = Mathf.Clamp01(0f - value.z);
			value.Set(value.x + ((value.x >= 0f) ? (0f - num) : num), value.y + ((value.y >= 0f) ? (0f - num) : num), value.z);
			return Vector3.Normalize(value);
		}

		private static Vector3 OctahedronToVector(float x, float y)
		{
			Vector3 value = new Vector3(x, y, 1f - Mathf.Abs(x) - Mathf.Abs(y));
			float num = Mathf.Clamp01(0f - value.z);
			value.Set(value.x + ((value.x >= 0f) ? (0f - num) : num), value.y + ((value.y >= 0f) ? (0f - num) : num), value.z);
			return Vector3.Normalize(value);
		}

		private static Vector3 HemiOctahedronToVector(float x, float y)
		{
			float num = x;
			float num2 = y;
			x = (num + num2) * 0.5f;
			y = (num - num2) * 0.5f;
			return Vector3.Normalize(new Vector3(x, y, 1f - Mathf.Abs(x) - Mathf.Abs(y)));
		}

		public void GenerateAutomaticMesh(AmplifyImpostorAsset data)
		{
			SpriteUtilityEx.GenerateOutline(rect: new Rect(0f, 0f, m_alphaTex.width, m_alphaTex.height), texture: m_alphaTex, detail: data.Tolerance, alphaTolerance: 254, holeDetection: false, paths: out var paths);
			int num = 0;
			for (int i = 0; i < paths.Length; i++)
			{
				num += paths[i].Length;
			}
			data.ShapePoints = new Vector2[num];
			int num2 = 0;
			for (int j = 0; j < paths.Length; j++)
			{
				for (int k = 0; k < paths[j].Length; k++)
				{
					data.ShapePoints[num2] = paths[j][k] + new Vector2((float)m_alphaTex.width * 0.5f, (float)m_alphaTex.height * 0.5f);
					data.ShapePoints[num2] = Vector2.Scale(data.ShapePoints[num2], new Vector2(1f / (float)m_alphaTex.width, 1f / (float)m_alphaTex.height));
					num2++;
				}
			}
			data.ShapePoints = Vector2Ex.ConvexHull(data.ShapePoints);
			data.ShapePoints = Vector2Ex.ReduceVertices(data.ShapePoints, data.MaxVertices);
			data.ShapePoints = Vector2Ex.ScaleAlongNormals(data.ShapePoints, data.NormalScale);
			for (int l = 0; l < data.ShapePoints.Length; l++)
			{
				data.ShapePoints[l].x = Mathf.Clamp01(data.ShapePoints[l].x);
				data.ShapePoints[l].y = Mathf.Clamp01(data.ShapePoints[l].y);
			}
			data.ShapePoints = Vector2Ex.ConvexHull(data.ShapePoints);
			for (int m = 0; m < data.ShapePoints.Length; m++)
			{
				data.ShapePoints[m] = new Vector2(data.ShapePoints[m].x, 1f - data.ShapePoints[m].y);
			}
		}

		public Mesh GenerateMesh(Vector2[] points, Vector3 offset, float width = 1f, float height = 1f, bool invertY = true)
		{
			Vector2[] array = new Vector2[points.Length];
			Vector2[] array2 = new Vector2[points.Length];
			Array.Copy(points, array, points.Length);
			float num = width * 0.5f;
			float num2 = height * 0.5f;
			if (invertY)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new Vector2(array[i].x, 1f - array[i].y);
				}
			}
			Array.Copy(array, array2, array.Length);
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = new Vector2(array[j].x * width - num + m_pixelOffset.x, array[j].y * height - num2 + m_pixelOffset.y);
			}
			Triangulator triangulator = new Triangulator(array);
			int[] triangles = triangulator.Triangulate();
			Vector3[] array3 = new Vector3[triangulator.Points.Count];
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k] = new Vector3(triangulator.Points[k].x, triangulator.Points[k].y, 0f);
			}
			Mesh mesh = new Mesh();
			mesh.vertices = array3;
			mesh.uv = array2;
			mesh.triangles = triangles;
			mesh.RecalculateNormals();
			mesh.bounds = new Bounds(offset, m_originalBound.size);
			return mesh;
		}
	}
}
