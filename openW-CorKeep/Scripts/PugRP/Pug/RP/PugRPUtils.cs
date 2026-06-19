using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public static class PugRPUtils
	{
		private static Mesh s_quad;

		private static Mesh s_unitQuad;

		private static Mesh s_pointlightShape;

		private static Mesh s_spotlightShape;

		private static bool? s_cachedSupportsShadowMapRenderTextureFormat;

		private const int WIDEBLUR_MAX_PASS_COUNT = 16;

		private const int WIDEBLUR_CS_KERNEL_DOWNSAMPLE_BLUR_X = 0;

		private const int WIDEBLUR_CS_KERNEL_BLUR_Y = 1;

		private const int WIDEBLUR_CS_KERNEL_UPSAMPLE = 2;

		private const int WIDEBLUR_M_PASS_DOWNSAMPLEBLUR_X = 0;

		private const int WIDEBLUR_M_PASS_BLUR_Y = 1;

		private const int WIDEBLUR_M_PASS_UPSAMPLE = 2;

		private const int WIDEBLUR_M_PASS_UPSAMPLE_OPAQUE = 3;

		private static ComputeShader s_wideBlurCompute;

		private static Material s_wideBlurMaterial;

		private static RenderTextureDescriptor[] s_chainDescs = new RenderTextureDescriptor[16];

		private static int[] s_chainX;

		private static int[] s_chainY;

		private static GlobalKeyword s_thresholdEnabledKeyword = GlobalKeyword.Create("THRESHOLD_ENABLED");

		private static int s_mipsBlurTmp = Shader.PropertyToID("_MipsBlurTmp");

		private static ComputeShader s_blurComputeShader;

		private static Material s_blurRasterMaterial;

		private static GlobalKeyword s_bilateralAlphaKeyword = GlobalKeyword.Create("BILATERAL_ALPHA");

		private static LocalKeyword s_blurFloatTextureKeyword;

		private static LocalKeyword s_blurUnormTextureKeyword;

		private static Vector3[] s_frustumCorners = new Vector3[4];

		public static Mesh quad
		{
			get
			{
				if (s_quad != null)
				{
					return s_quad;
				}
				Vector3[] vertices = new Vector3[4]
				{
					new Vector3(-1f, -1f, 0f),
					new Vector3(1f, 1f, 0f),
					new Vector3(1f, -1f, 0f),
					new Vector3(-1f, 1f, 0f)
				};
				Vector2[] uv = new Vector2[4]
				{
					new Vector2(0f, 1f),
					new Vector2(1f, 0f),
					new Vector2(1f, 1f),
					new Vector2(0f, 0f)
				};
				Vector3[] normals = new Vector3[4]
				{
					new Vector3(0f, 0f, -1f),
					new Vector3(0f, 0f, -1f),
					new Vector3(0f, 0f, -1f),
					new Vector3(0f, 0f, -1f)
				};
				Vector4[] tangents = new Vector4[4]
				{
					new Vector4(1f, 0f, 0f, -1f),
					new Vector4(1f, 0f, 0f, -1f),
					new Vector4(1f, 0f, 0f, -1f),
					new Vector4(1f, 0f, 0f, -1f)
				};
				int[] triangles = new int[6] { 0, 1, 2, 1, 0, 3 };
				s_quad = new Mesh
				{
					name = "PugRP_Quad",
					vertices = vertices,
					uv = uv,
					normals = normals,
					tangents = tangents,
					triangles = triangles
				};
				s_quad.RecalculateBounds();
				return s_quad;
			}
		}

		public static Mesh unitQuad
		{
			get
			{
				if (s_unitQuad != null)
				{
					return s_unitQuad;
				}
				Vector3[] vertices = new Vector3[4]
				{
					new Vector3(-1f, -1f, 0f) / 2f,
					new Vector3(1f, 1f, 0f) / 2f,
					new Vector3(1f, -1f, 0f) / 2f,
					new Vector3(-1f, 1f, 0f) / 2f
				};
				Vector2[] uv = new Vector2[4]
				{
					new Vector2(0f, 1f),
					new Vector2(1f, 0f),
					new Vector2(1f, 1f),
					new Vector2(0f, 0f)
				};
				Vector3[] normals = new Vector3[4]
				{
					new Vector3(0f, 0f, -1f),
					new Vector3(0f, 0f, -1f),
					new Vector3(0f, 0f, -1f),
					new Vector3(0f, 0f, -1f)
				};
				Vector4[] tangents = new Vector4[4]
				{
					new Vector4(1f, 0f, 0f, -1f),
					new Vector4(1f, 0f, 0f, -1f),
					new Vector4(1f, 0f, 0f, -1f),
					new Vector4(1f, 0f, 0f, -1f)
				};
				int[] triangles = new int[6] { 0, 1, 2, 1, 0, 3 };
				s_unitQuad = new Mesh
				{
					name = "PugRP_UnitQuad",
					vertices = vertices,
					uv = uv,
					normals = normals,
					tangents = tangents,
					triangles = triangles
				};
				s_unitQuad.RecalculateBounds();
				return s_unitQuad;
			}
		}

		public static Mesh pointlightShape
		{
			get
			{
				EnsureLoadedResource(ref s_pointlightShape, "Meshes/PointlightShape");
				return s_pointlightShape;
			}
		}

		public static Mesh spotlightShape
		{
			get
			{
				EnsureLoadedResource(ref s_spotlightShape, "Meshes/SpotlightShape");
				return s_spotlightShape;
			}
		}

		public static RenderTextureFormat hdrAlphaFormat => RenderTextureFormat.DefaultHDR;

		public static RenderTextureFormat floatNoAlphaFormat => RenderTextureFormat.RGB111110Float;

		public static int depthBits => 32;

		public static RenderTextureFormat packedNormalFormat => RenderTextureFormat.ARGB2101010;

		public static bool EnsureLoadedResource<T>(ref T res, string path) where T : UnityEngine.Object
		{
			if ((object)res == null)
			{
				res = Resources.Load<T>(path);
				return true;
			}
			return false;
		}

		public static bool EnsureLoadedMaterial(ref Material material, string shaderName)
		{
			if (material == null)
			{
				Shader shader = Shader.Find(shaderName);
				if (shader == null)
				{
					Debug.LogError("Unable to find shader: " + shaderName);
					return false;
				}
				material = new Material(shader);
				return true;
			}
			return false;
		}

		public static void GetCameraCorners(Camera camera, Vector4[] corners)
		{
			Transform transform = camera.transform;
			corners[3] = (corners[2] = (corners[1] = (corners[0] = transform.position)));
			if (camera.orthographic)
			{
				float orthographicSize = camera.orthographicSize;
				float num = orthographicSize * camera.aspect;
				Vector4 vector = transform.right * num;
				Vector4 vector2 = transform.up * orthographicSize;
				corners[0] += -vector - vector2;
				corners[1] += -vector + vector2;
				corners[2] += vector + vector2;
				corners[3] += vector - vector2;
			}
		}

		public static void GetCameraRays(Camera camera, Vector4[] rays)
		{
			Matrix4x4 worldToCameraMatrix = camera.worldToCameraMatrix;
			Matrix4x4 projectionMatrix = camera.projectionMatrix;
			worldToCameraMatrix.m03 = 0f;
			worldToCameraMatrix.m13 = 0f;
			worldToCameraMatrix.m23 = 0f;
			Matrix4x4 inverse = (projectionMatrix * worldToCameraMatrix).inverse;
			rays[0] = inverse.MultiplyPoint(new Vector3(-1f, -1f, 1f)).normalized;
			rays[1] = inverse.MultiplyPoint(new Vector3(-1f, 1f, 1f)).normalized;
			rays[2] = inverse.MultiplyPoint(new Vector3(1f, 1f, 1f)).normalized;
			rays[3] = inverse.MultiplyPoint(new Vector3(1f, -1f, 1f)).normalized;
		}

		public static void Release(ref RenderTexture rt)
		{
			if (rt != null && !rt.Equals(null))
			{
				rt.Release();
				rt = null;
			}
		}

		public static void Release(RenderTexture[] rts)
		{
			if (rts != null)
			{
				for (int i = 0; i < rts.Length; i++)
				{
					RenderTexture rt = rts[i];
					Release(ref rt);
				}
			}
		}

		public static void Release(List<RenderTexture> rts)
		{
			if (rts != null)
			{
				for (int i = 0; i < rts.Count; i++)
				{
					RenderTexture rt = rts[i];
					Release(ref rt);
				}
			}
		}

		public static void Release(ref ComputeBuffer computeBuffer)
		{
			if (computeBuffer != null)
			{
				computeBuffer.Release();
				computeBuffer = null;
			}
		}

		private static bool SupportsShadowMapRenderTextureFormat()
		{
			if (!s_cachedSupportsShadowMapRenderTextureFormat.HasValue)
			{
				s_cachedSupportsShadowMapRenderTextureFormat = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Shadowmap);
			}
			return s_cachedSupportsShadowMapRenderTextureFormat.Value;
		}

		public static bool Setup(ref RenderTexture rt, string name, RenderTextureDescriptor desc)
		{
			if (desc.colorFormat == RenderTextureFormat.Shadowmap && !SupportsShadowMapRenderTextureFormat())
			{
				desc.colorFormat = RenderTextureFormat.Depth;
			}
			if (rt == null || rt.Equals(null) || !rt.IsCreated() || rt.width != desc.width || rt.height != desc.height || rt.depth != desc.depthBufferBits || rt.format != desc.colorFormat || rt.dimension != desc.dimension || rt.volumeDepth != desc.volumeDepth || rt.enableRandomWrite != desc.enableRandomWrite)
			{
				Release(ref rt);
				rt = new RenderTexture(desc)
				{
					name = name
				};
				rt.Create();
				return true;
			}
			return false;
		}

		public static bool Setup(ref RenderTexture rt, string name, int width, int height, int depth, RenderTextureFormat format)
		{
			RenderTextureDescriptor desc = new RenderTextureDescriptor(width, height, format, depth);
			return Setup(ref rt, name, desc);
		}

		public static bool Setup(ref RenderTexture rt, string name, int width, int height, GraphicsFormat colorFormat, GraphicsFormat depthFormat)
		{
			RenderTextureDescriptor desc = new RenderTextureDescriptor(width, height, colorFormat, depthFormat);
			return Setup(ref rt, name, desc);
		}

		public static bool Setup(ref ComputeBuffer computeBuffer, int count, int stride, ComputeBufferType type = ComputeBufferType.Default)
		{
			if (computeBuffer == null || computeBuffer.count != count || computeBuffer.stride != stride)
			{
				Release(ref computeBuffer);
				computeBuffer = new ComputeBuffer(count, stride, type);
				return true;
			}
			return false;
		}

		public static bool Setup(ref MaterialPropertyBlock properties)
		{
			if (properties == null)
			{
				properties = new MaterialPropertyBlock();
				return true;
			}
			return false;
		}

		public static bool CommandBuffer(ref CommandBuffer cmd, string name)
		{
			if (cmd == null)
			{
				cmd = new CommandBuffer
				{
					name = name
				};
				return true;
			}
			return false;
		}

		public static bool SetupIndirectArgs(ref ComputeBuffer argsBuffer, ref uint[] argsData, Mesh mesh, int instanceCount = -1)
		{
			if (mesh == null)
			{
				return false;
			}
			uint num = 0u;
			bool flag = false;
			if (instanceCount > -1)
			{
				num = (uint)instanceCount;
				flag = argsData != null && argsData.Length == 5 && argsData[1] != num;
			}
			if (argsData == null || argsBuffer == null || argsData.Length != 5 || argsData[0] != mesh.GetIndexCount(0) || flag || argsData[2] != mesh.GetIndexStart(0) || argsData[3] != mesh.GetBaseVertex(0) || argsData[4] != mesh.GetIndexCount(0))
			{
				argsData = new uint[5]
				{
					mesh.GetIndexCount(0),
					num,
					mesh.GetIndexStart(0),
					mesh.GetBaseVertex(0),
					0u
				};
				Release(ref argsBuffer);
				argsBuffer = new ComputeBuffer(5, 4, ComputeBufferType.DrawIndirect);
				argsBuffer.SetData(argsData);
				return true;
			}
			return false;
		}

		public static Quaternion RotationFromCubemapFace(CubemapFace face)
		{
			Vector3 forward = Vector3.right;
			Vector3 upwards = Vector3.up;
			switch (face)
			{
			case CubemapFace.NegativeX:
				forward = Vector3.left;
				break;
			case CubemapFace.PositiveY:
				forward = Vector3.up;
				upwards = Vector3.back;
				break;
			case CubemapFace.NegativeY:
				forward = Vector3.down;
				upwards = Vector3.forward;
				break;
			case CubemapFace.PositiveZ:
				forward = Vector3.forward;
				break;
			case CubemapFace.NegativeZ:
				forward = Vector3.back;
				break;
			}
			return Quaternion.LookRotation(forward, upwards);
		}

		public static Camera GetUtilityCamera(string name, bool hidden = true)
		{
			Camera camera = new GameObject(name)
			{
				hideFlags = (hidden ? HideFlags.HideAndDontSave : HideFlags.DontSave)
			}.AddComponent<Camera>();
			camera.enabled = false;
			if (PugRP.asset.logUtilityCameraCreation)
			{
				Debug.Log("Adding utility camera: " + name);
			}
			return camera;
		}

		public static int GetThreadGroupCount(int groupSize, int width)
		{
			return Mathf.CeilToInt((float)width / (float)groupSize);
		}

		public static Vector2Int GetThreadGroupCount(int groupSize, int width, int height)
		{
			return new Vector2Int(GetThreadGroupCount(groupSize, width), GetThreadGroupCount(groupSize, height));
		}

		private static void ExecuteWideBlurDownSampleMobile(CommandBuffer cmd, RenderTargetIdentifier src, RenderTargetIdentifier dst, int chainPassCount, float threshold)
		{
			cmd.SetGlobalFloat(ShaderIDs.Threshold, threshold);
			cmd.SetGlobalFloat(ShaderIDs.InputMip, 0f);
			for (int i = 0; i < chainPassCount; i++)
			{
				cmd.SetKeyword(in s_thresholdEnabledKeyword, i == 0 && threshold > Mathf.Epsilon);
				_ = s_chainDescs[i].width;
				_ = s_chainDescs[i].height;
				RenderTargetIdentifier source = ((i == 0) ? src : ((RenderTargetIdentifier)s_chainY[i - 1]));
				cmd.Blit(source, s_chainX[i], s_wideBlurMaterial, 0);
				cmd.SetKeyword(in s_thresholdEnabledKeyword, value: false);
				cmd.Blit(s_chainX[i], s_chainY[i], s_wideBlurMaterial, 1);
			}
		}

		private static void ExecuteWideBlurDownSample(CommandBuffer cmd, RenderTargetIdentifier src, RenderTargetIdentifier dst, int chainPassCount, float threshold)
		{
			cmd.SetComputeFloatParam(s_wideBlurCompute, ShaderIDs.Threshold, threshold);
			cmd.SetComputeFloatParam(s_wideBlurCompute, ShaderIDs.InputMip, 0f);
			for (int i = 0; i < chainPassCount; i++)
			{
				cmd.SetKeyword(in s_thresholdEnabledKeyword, i == 0 && threshold > Mathf.Epsilon);
				int width = s_chainDescs[i].width;
				int height = s_chainDescs[i].height;
				Vector2Int threadGroupCount = GetThreadGroupCount(8, width, height);
				if (i == 0)
				{
					cmd.SetComputeTextureParam(s_wideBlurCompute, 0, ShaderIDs.Input, src);
				}
				else
				{
					cmd.SetComputeTextureParam(s_wideBlurCompute, 0, ShaderIDs.Input, s_chainY[i - 1]);
				}
				cmd.SetComputeVectorParam(s_wideBlurCompute, ShaderIDs.InputSize, new Vector2(width, height));
				cmd.SetComputeTextureParam(s_wideBlurCompute, 0, ShaderIDs.Output, s_chainX[i]);
				cmd.DispatchCompute(s_wideBlurCompute, 0, threadGroupCount.x, threadGroupCount.y, 1);
				cmd.SetKeyword(in s_thresholdEnabledKeyword, value: false);
				threadGroupCount = GetThreadGroupCount(8, s_chainDescs[i].width / 2, s_chainDescs[i].height / 2);
				cmd.SetComputeTextureParam(s_wideBlurCompute, 1, ShaderIDs.Input, s_chainX[i]);
				cmd.SetComputeTextureParam(s_wideBlurCompute, 1, ShaderIDs.Output, s_chainY[i]);
				cmd.DispatchCompute(s_wideBlurCompute, 1, threadGroupCount.x, threadGroupCount.y, 1);
			}
		}

		public static void WideBlur(CommandBuffer cmd, RenderTargetIdentifier src, RenderTargetIdentifier dst, RenderTextureDescriptor srcDesc, float size, float alpha = 1f, float threshold = 0f, float additive = 0f)
		{
			int num = Mathf.CeilToInt(size);
			if (num < 1)
			{
				return;
			}
			EnsureLoadedResource(ref s_wideBlurCompute, "Shaders/WideBlur");
			EnsureLoadedMaterial(ref s_wideBlurMaterial, "Hidden/PugRP/WideBlur");
			if (s_wideBlurCompute == null || s_wideBlurMaterial == null)
			{
				Debug.LogError("Unable to load WideBlur resources");
				return;
			}
			if (s_chainX == null || s_chainX.Length < 16)
			{
				s_chainX = new int[16];
				s_chainY = new int[16];
				for (int i = 0; i < 16; i++)
				{
					s_chainX[i] = Shader.PropertyToID("_WideBlurPassX" + (i + 1));
					s_chainY[i] = Shader.PropertyToID("_WideBlurPassY" + (i + 1));
				}
			}
			cmd.BeginSample("Wide Blur");
			RenderTextureDescriptor renderTextureDescriptor = srcDesc;
			int num2 = 0;
			for (int j = 0; j < num; j++)
			{
				if (renderTextureDescriptor.width < 4)
				{
					break;
				}
				if (renderTextureDescriptor.height < 4)
				{
					break;
				}
				s_chainDescs[j] = renderTextureDescriptor;
				cmd.GetTemporaryRT(s_chainX[j], renderTextureDescriptor, FilterMode.Bilinear);
				renderTextureDescriptor.width /= 2;
				renderTextureDescriptor.height /= 2;
				cmd.GetTemporaryRT(s_chainY[j], renderTextureDescriptor, FilterMode.Bilinear);
				num2++;
			}
			ExecuteWideBlurDownSample(cmd, src, dst, num2, threshold);
			for (int num3 = num2 - 1; num3 >= 0; num3--)
			{
				int num4 = s_chainY[num3];
				RenderTargetIdentifier dest = ((num3 == 0) ? dst : ((RenderTargetIdentifier)s_chainY[num3 - 1]));
				cmd.SetGlobalFloat(ShaderIDs.Alpha, Mathf.Clamp01(size - (float)num3) * ((num3 == 0) ? alpha : 1f));
				cmd.SetGlobalFloat(ShaderIDs.Additive, (num3 == 0) ? 0f : additive);
				int pass = ((num3 == 0 && size > 1f && Mathf.Approximately(1f, alpha)) ? 3 : 2);
				cmd.Blit(num4, dest, s_wideBlurMaterial, pass);
			}
			for (int k = 0; k < num2; k++)
			{
				cmd.ReleaseTemporaryRT(s_chainX[k]);
				cmd.ReleaseTemporaryRT(s_chainY[k]);
			}
			cmd.EndSample("Wide Blur");
		}

		public static void WideBlur(CommandBuffer cmd, RenderTargetIdentifier src, RenderTextureDescriptor srcDesc, float size, float alpha = 1f)
		{
			WideBlur(cmd, src, src, srcDesc, size, alpha);
		}

		public static void MipsBlur(CommandBuffer cmd, RenderTargetIdentifier src, RenderTextureDescriptor srcDesc, int mipCount)
		{
			EnsureLoadedResource(ref s_wideBlurCompute, "Shaders/WideBlur");
			if (s_wideBlurCompute == null)
			{
				Debug.LogError("Unable to load MipsBlur resources");
				return;
			}
			if (!srcDesc.useMipMap || mipCount < 2)
			{
				Debug.LogError("Invalid MipsBlur src format: Must use at least 2 mip maps");
				return;
			}
			cmd.BeginSample("Mips Blur");
			RenderTextureDescriptor desc = srcDesc;
			cmd.GetTemporaryRT(s_mipsBlurTmp, desc);
			int num = s_mipsBlurTmp;
			cmd.CopyTexture(src, 0, 0, num, 0, 0);
			cmd.SetKeyword(in s_thresholdEnabledKeyword, value: false);
			for (int i = 0; i < mipCount - 1; i++)
			{
				int num2 = (int)Mathf.Pow(2f, i + 1);
				int num3 = srcDesc.width / num2;
				int num4 = srcDesc.height / num2;
				Vector2Int threadGroupCount = GetThreadGroupCount(8, num3, num4);
				cmd.SetComputeFloatParam(s_wideBlurCompute, ShaderIDs.InputMip, i);
				cmd.SetComputeVectorParam(s_wideBlurCompute, ShaderIDs.InputSize, new Vector2(num3 * 2, num4 * 2));
				cmd.SetComputeTextureParam(s_wideBlurCompute, 0, ShaderIDs.Input, num);
				cmd.SetComputeTextureParam(s_wideBlurCompute, 0, ShaderIDs.Output, src, i + 1);
				cmd.DispatchCompute(s_wideBlurCompute, 0, threadGroupCount.x, threadGroupCount.y, 1);
				cmd.SetComputeFloatParam(s_wideBlurCompute, ShaderIDs.InputMip, i + 1);
				cmd.SetComputeVectorParam(s_wideBlurCompute, ShaderIDs.InputSize, new Vector2(num3, num4));
				cmd.SetComputeTextureParam(s_wideBlurCompute, 1, ShaderIDs.Input, src);
				cmd.SetComputeTextureParam(s_wideBlurCompute, 1, ShaderIDs.Output, num, i + 1);
				cmd.DispatchCompute(s_wideBlurCompute, 1, threadGroupCount.x, threadGroupCount.y, 1);
			}
			for (int num5 = mipCount - 2; num5 >= 0; num5--)
			{
				int num6 = (int)Mathf.Pow(2f, num5);
				int num7 = srcDesc.width / num6;
				int num8 = srcDesc.height / num6;
				int num9 = num7 / 2;
				int num10 = num8 / 2;
				Vector2Int threadGroupCount2 = GetThreadGroupCount(8, num7, num8);
				cmd.SetComputeFloatParam(s_wideBlurCompute, ShaderIDs.InputMip, num5 + 1);
				cmd.SetComputeVectorParam(s_wideBlurCompute, ShaderIDs.InputSize, new Vector2(num9, num10));
				cmd.SetComputeTextureParam(s_wideBlurCompute, 2, ShaderIDs.Input, num);
				cmd.SetComputeTextureParam(s_wideBlurCompute, 2, ShaderIDs.Output, src, num5);
				cmd.DispatchCompute(s_wideBlurCompute, 2, threadGroupCount2.x, threadGroupCount2.y, 1);
			}
			cmd.ReleaseTemporaryRT(s_mipsBlurTmp);
			cmd.EndSample("Mips Blur");
		}

		public static void BlurTexture(CommandBuffer cmd, RenderTargetIdentifier src, RenderTargetIdentifier tmp, RenderTargetIdentifier dst, int width, int height, bool useUnorm, int blurWidth = 3, bool bilateralAlpha = false, float originalOpacity = 0f)
		{
			if (blurWidth < 1)
			{
				return;
			}
			string name = (bilateralAlpha ? "Blur (Bilateral)" : "Blur");
			cmd.BeginSample(name);
			blurWidth = Mathf.Min(blurWidth, 64);
			if (EnsureLoadedResource(ref s_blurComputeShader, "Shaders/Blur"))
			{
				s_blurFloatTextureKeyword = new LocalKeyword(s_blurComputeShader, "FORMAT_FLOAT");
				s_blurUnormTextureKeyword = new LocalKeyword(s_blurComputeShader, "FORMAT_UNORM");
			}
			if (originalOpacity > Mathf.Epsilon)
			{
				if (s_blurRasterMaterial == null)
				{
					s_blurRasterMaterial = new Material(Shader.Find("Hidden/PugRP/BlurRaster"));
				}
				cmd.SetGlobalFloat(ShaderIDs.Width, blurWidth);
				cmd.SetGlobalFloat(ShaderIDs.OriginalOpacity, 0f);
				cmd.SetGlobalVector(ShaderIDs.Axis, new Vector2(1f, 0f));
				cmd.Blit(src, tmp, s_blurRasterMaterial);
				cmd.SetGlobalFloat(ShaderIDs.OriginalOpacity, originalOpacity);
				cmd.SetGlobalVector(ShaderIDs.Axis, new Vector2(0f, 1f));
				cmd.Blit(tmp, dst, s_blurRasterMaterial);
			}
			else
			{
				Vector2Int threadGroupCount = GetThreadGroupCount(8, width, height);
				cmd.SetKeyword(in s_bilateralAlphaKeyword, bilateralAlpha);
				if (useUnorm)
				{
					cmd.EnableKeyword(s_blurComputeShader, in s_blurUnormTextureKeyword);
				}
				else
				{
					cmd.EnableKeyword(s_blurComputeShader, in s_blurFloatTextureKeyword);
				}
				cmd.SetComputeFloatParam(s_blurComputeShader, ShaderIDs.Width, blurWidth);
				cmd.SetComputeVectorParam(s_blurComputeShader, ShaderIDs.Axis, new Vector2(1f, 0f));
				cmd.SetComputeTextureParam(s_blurComputeShader, 0, ShaderIDs.Input, src);
				cmd.SetComputeTextureParam(s_blurComputeShader, 0, ShaderIDs.Output, tmp);
				cmd.DispatchCompute(s_blurComputeShader, 0, threadGroupCount.x, threadGroupCount.y, 1);
				cmd.SetComputeVectorParam(s_blurComputeShader, ShaderIDs.Axis, new Vector2(0f, 1f));
				cmd.SetComputeTextureParam(s_blurComputeShader, 0, ShaderIDs.Input, tmp);
				cmd.SetComputeTextureParam(s_blurComputeShader, 0, ShaderIDs.Output, dst);
				cmd.DispatchCompute(s_blurComputeShader, 0, threadGroupCount.x, threadGroupCount.y, 1);
				cmd.SetKeyword(in s_bilateralAlphaKeyword, value: false);
				if (useUnorm)
				{
					cmd.DisableKeyword(s_blurComputeShader, in s_blurUnormTextureKeyword);
				}
				else
				{
					cmd.DisableKeyword(s_blurComputeShader, in s_blurFloatTextureKeyword);
				}
			}
			cmd.EndSample(name);
		}

		public static void BlurTexture(CommandBuffer cmd, RenderTargetIdentifier src, RenderTargetIdentifier tmp, int width, int height, bool useUnorm, int blurWidth = 3, bool bilateralAlpha = false, float originalOpacity = 0f)
		{
			BlurTexture(cmd, src, tmp, src, width, height, useUnorm, blurWidth, bilateralAlpha, originalOpacity);
		}

		public static void UniformKernel(Vector4[] output, int n, bool hemisphere, int seed = 0)
		{
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(seed);
			for (int i = 0; i < n; i++)
			{
				output[i] = new Vector3(UnityEngine.Random.value * 2f - 1f, UnityEngine.Random.value * 2f - 1f, hemisphere ? UnityEngine.Random.value : (UnityEngine.Random.value * 2f - 1f)).normalized;
				float num = ((float)i + 0.5f) / (float)n;
				output[i].w = 1f;
				output[i] *= Mathf.Lerp(0.1f, 1f, num * num);
			}
			UnityEngine.Random.state = state;
		}

		public static Vector4[] SunflowerKernel(int n, bool hemisphere)
		{
			Vector4[] array = new Vector4[n];
			float num = MathF.PI * (3f - Mathf.Sqrt(5f));
			for (int i = 0; i < n; i++)
			{
				float num2 = 1f - (float)i / (float)(n - 1) * 2f;
				float num3 = Mathf.Sqrt(1f - num2 * num2);
				float f = num * (float)i;
				float x = Mathf.Cos(f) * num3;
				float num4 = Mathf.Sin(f) * num3;
				array[i] = new Vector3(x, num2, hemisphere ? Mathf.Abs(num4) : num4);
			}
			return array;
		}

		public static Vector3 SnapBufferPosition(Vector3 position, Quaternion rotation, Vector2 bufferSize, Vector2Int bufferResolution)
		{
			if (PugRP.asset.snappingAccountsForOrigin)
			{
				position -= PugRP.origin;
			}
			Vector2 vector = new Vector2(bufferSize.x / (float)bufferResolution.x, bufferSize.y / (float)bufferResolution.y);
			Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one);
			Vector3 vector2 = matrix4x.inverse.MultiplyPoint(position);
			Vector3 point = new Vector3((float)Mathf.RoundToInt(vector2.x / vector.x) * vector.x, (float)Mathf.RoundToInt(vector2.y / vector.y) * vector.y, vector2.z);
			position = matrix4x.MultiplyPoint(point);
			if (PugRP.asset.snappingAccountsForOrigin)
			{
				position += PugRP.origin;
			}
			return position;
		}

		public static Vector3 SnapBufferPosition(Vector3 position, Quaternion rotation, Vector3 bufferSize, Vector3Int bufferResolution)
		{
			if (PugRP.asset.snappingAccountsForOrigin)
			{
				position -= PugRP.origin;
			}
			Vector3 vector = new Vector3(bufferSize.x / (float)bufferResolution.x, bufferSize.y / (float)bufferResolution.y, bufferSize.z / (float)bufferResolution.z);
			Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one);
			position = matrix4x.inverse.MultiplyPoint(position);
			position.x = (float)Mathf.RoundToInt(position.x / vector.x) * vector.x;
			position.y = (float)Mathf.RoundToInt(position.y / vector.y) * vector.y;
			position.z = (float)Mathf.RoundToInt(position.z / vector.z) * vector.z;
			position = matrix4x.MultiplyPoint(position);
			if (PugRP.asset.snappingAccountsForOrigin)
			{
				position += PugRP.origin;
			}
			return position;
		}

		public static Matrix4x4 AdjustBufferMatrix(Matrix4x4 m, bool applyToZ = false)
		{
			m.m00 = 0.5f * (m.m00 + m.m30);
			m.m01 = 0.5f * (m.m01 + m.m31);
			m.m02 = 0.5f * (m.m02 + m.m32);
			m.m03 = 0.5f * (m.m03 + m.m33);
			m.m10 = 0.5f * (m.m10 + m.m30);
			m.m11 = 0.5f * (m.m11 + m.m31);
			m.m12 = 0.5f * (m.m12 + m.m32);
			m.m13 = 0.5f * (m.m13 + m.m33);
			if (applyToZ)
			{
				m.m20 = 0.5f * (m.m20 + m.m30);
				m.m21 = 0.5f * (m.m21 + m.m31);
				m.m22 = 0.5f * (m.m22 + m.m32);
				m.m23 = 0.5f * (m.m23 + m.m33);
			}
			return m;
		}

		public static void DebugDrawBounds(Bounds bounds, Color color)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			Debug.DrawLine(new Vector3(min.x, min.y, min.z), new Vector3(max.x, min.y, min.z), color);
			Debug.DrawLine(new Vector3(max.x, min.y, min.z), new Vector3(max.x, max.y, min.z), color);
			Debug.DrawLine(new Vector3(max.x, max.y, min.z), new Vector3(min.x, max.y, min.z), color);
			Debug.DrawLine(new Vector3(min.x, max.y, min.z), new Vector3(min.x, min.y, min.z), color);
			Debug.DrawLine(new Vector3(min.x, min.y, max.z), new Vector3(max.x, min.y, max.z), color);
			Debug.DrawLine(new Vector3(max.x, min.y, max.z), new Vector3(max.x, max.y, max.z), color);
			Debug.DrawLine(new Vector3(max.x, max.y, max.z), new Vector3(min.x, max.y, max.z), color);
			Debug.DrawLine(new Vector3(min.x, max.y, max.z), new Vector3(min.x, min.y, max.z), color);
			Debug.DrawLine(new Vector3(min.x, min.y, min.z), new Vector3(min.x, min.y, max.z), color);
			Debug.DrawLine(new Vector3(max.x, min.y, min.z), new Vector3(max.x, min.y, max.z), color);
			Debug.DrawLine(new Vector3(min.x, max.y, min.z), new Vector3(min.x, max.y, max.z), color);
			Debug.DrawLine(new Vector3(max.x, max.y, min.z), new Vector3(max.x, max.y, max.z), color);
		}

		public static void InitializeCurveTexture(ref Texture2D texture, int resolution, params AnimationCurve[] curves)
		{
			if (curves == null || curves.Length < 1 || resolution < 2)
			{
				return;
			}
			if (texture == null || texture.width != resolution || texture.height != curves.Length)
			{
				if (texture != null)
				{
					UnityEngine.Object.Destroy(texture);
				}
				texture = new Texture2D(resolution, curves.Length, TextureFormat.RHalf, mipChain: false, linear: true);
				texture.wrapMode = TextureWrapMode.Clamp;
			}
			for (int i = 0; i < resolution; i++)
			{
				float time = (float)i / (float)(resolution - 1);
				for (int j = 0; j < curves.Length; j++)
				{
					float num = curves[j].Evaluate(time);
					texture.SetPixel(i, j, Color.white * num);
				}
			}
			texture.Apply();
		}

		public static void InitializeGradientTexture(ref Texture2D texture, int resolution, params Gradient[] gradients)
		{
			if (gradients == null || gradients.Length < 1 || resolution < 2)
			{
				return;
			}
			if (texture == null || texture.width != resolution || texture.height != gradients.Length)
			{
				if (texture != null)
				{
					UnityEngine.Object.Destroy(texture);
				}
				texture = new Texture2D(resolution, gradients.Length, TextureFormat.ARGB32, mipChain: false, linear: true);
				texture.wrapMode = TextureWrapMode.Clamp;
			}
			for (int i = 0; i < resolution; i++)
			{
				float time = (float)i / (float)(resolution - 1);
				for (int j = 0; j < gradients.Length; j++)
				{
					Color color = gradients[j].Evaluate(time);
					texture.SetPixel(i, j, color);
				}
			}
			texture.Apply();
		}

		public static Vector3 WorldToRender(Vector3 world)
		{
			return world - PugRP.origin;
		}

		public static Vector3 RenderToWorld(Vector3 render)
		{
			return render + PugRP.origin;
		}

		public static Bounds GetCameraFrustumBounds(Camera camera)
		{
			Bounds result = new Bounds(camera.transform.position, Vector3.zero);
			camera.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, s_frustumCorners);
			for (int i = 0; i < 4; i++)
			{
				Vector3 point = camera.transform.position + camera.transform.TransformVector(s_frustumCorners[i]);
				result.Encapsulate(point);
			}
			return result;
		}

		public static float GetShadowBias(float textureSize, float biasAmount)
		{
			float num = 2f / textureSize;
			return biasAmount * num * 1.4142137f;
		}

		public static bool CheckRenderTextureSupport(RenderTextureFormat format, bool checkLinearSampling, bool checkRandomWrite)
		{
			bool flag = SystemInfo.SupportsRenderTextureFormat(format);
			if (flag)
			{
				if (checkLinearSampling)
				{
					flag = SystemInfo.IsFormatSupported(GraphicsFormatUtility.GetGraphicsFormat(format, RenderTextureReadWrite.Linear), GraphicsFormatUsage.Linear);
				}
				if (checkRandomWrite)
				{
					flag = SystemInfo.SupportsRandomWriteOnRenderTextureFormat(format);
				}
			}
			return flag;
		}
	}
}
