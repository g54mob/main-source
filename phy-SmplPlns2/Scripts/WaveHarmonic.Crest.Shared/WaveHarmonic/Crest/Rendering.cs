using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR;

namespace WaveHarmonic.Crest
{
	internal static class Rendering
	{
		public static class BIRP
		{
			private static class ShaderIDs
			{
				public static readonly int s_InverseViewProjection = Shader.PropertyToID("_Crest_InverseViewProjection");

				public static readonly int s_StereoInverseViewProjection = Shader.PropertyToID("_Crest_StereoInverseViewProjection");
			}

			public enum FrameBufferFormatOverride
			{
				None = 0,
				LDR = 1,
				HDR = 2
			}

			internal enum UtilityPass
			{
				CopyDepth = 0,
				Copy = 1,
				MergeDepth = 2
			}

			private static Material s_UtilityMaterial;

			private const int k_MaximumViewsXR = 2;

			private static readonly List<XRDisplaySubsystem> s_DisplayListXR = new List<XRDisplaySubsystem>();

			private static Texture2DArray s_WhiteTextureXR = null;

			public static Material UtilityMaterial
			{
				get
				{
					if (s_UtilityMaterial == null)
					{
						s_UtilityMaterial = new Material(Shader.Find("Hidden/Crest/Legacy/Blit"));
					}
					return s_UtilityMaterial;
				}
			}

			private static XRDisplaySubsystem DisplayXR
			{
				get
				{
					if (!XRSettings.enabled)
					{
						return null;
					}
					return s_DisplayListXR[0];
				}
			}

			private static Matrix4x4[] InverseViewProjectionMatrixXR { get; set; } = new Matrix4x4[2];

			public static Texture2DArray WhiteTextureXR
			{
				get
				{
					if (s_WhiteTextureXR == null)
					{
						s_WhiteTextureXR = TextureArrayHelpers.CreateTexture2DArray(Texture2D.whiteTexture, 2);
						s_WhiteTextureXR.name = "_Crest_WhiteTextureXR";
					}
					return s_WhiteTextureXR;
				}
			}

			public static Texture GetWhiteTexture(Camera camera)
			{
				if (camera.stereoEnabled && SinglePassXR)
				{
					return WhiteTextureXR;
				}
				return Texture2D.whiteTexture;
			}

			public static void SetMatrices(Camera camera)
			{
				Shader.SetGlobalMatrix(ShaderIDs.s_InverseViewProjection, (GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: true) * camera.worldToCameraMatrix).inverse);
				SetMatricesXR(camera);
			}

			public static RenderTextureDescriptor GetCameraTargetDescriptor(Camera camera, FrameBufferFormatOverride hdrOverride = FrameBufferFormatOverride.None)
			{
				RenderTextureDescriptor result = ((!camera.stereoEnabled) ? new RenderTextureDescriptor(camera.pixelWidth, camera.pixelHeight, SystemInfo.GetGraphicsFormat(DefaultFormat.LDR), 0) : XRSettings.eyeTextureDesc);
				if (camera.allowHDR && QualitySettings.activeColorSpace == ColorSpace.Linear)
				{
					DefaultFormat format = DefaultFormat.HDR;
					if (hdrOverride != FrameBufferFormatOverride.None)
					{
						format = ((hdrOverride == FrameBufferFormatOverride.HDR) ? DefaultFormat.HDR : DefaultFormat.LDR);
					}
					result.graphicsFormat = SystemInfo.GetGraphicsFormat(format);
				}
				return result;
			}

			[Conditional("_XR_ENABLED")]
			public static void EnableXR(CommandBuffer commands, Camera camera)
			{
				if (SinglePassXR && camera.stereoEnabled)
				{
					commands.EnableKeyword(SinglePassKeyword);
				}
			}

			[Conditional("_XR_ENABLED")]
			public static void DisableXR(CommandBuffer commands, Camera camera)
			{
				if (SinglePassXR && camera.stereoEnabled)
				{
					commands.DisableKeyword(SinglePassKeyword);
				}
			}

			public static void SetMatricesXR(Camera camera)
			{
				if (camera.stereoEnabled && SinglePassXR)
				{
					SubsystemManager.GetSubsystems(s_DisplayListXR);
					DisplayXR.GetRenderPass(0, out var renderPass);
					renderPass.GetRenderParameter(camera, 0, out var renderParameter);
					renderPass.GetRenderParameter(camera, 1, out var renderParameter2);
					InverseViewProjectionMatrixXR[0] = (GL.GetGPUProjectionMatrix(renderParameter.projection, renderIntoTexture: true) * renderParameter.view).inverse;
					InverseViewProjectionMatrixXR[1] = (GL.GetGPUProjectionMatrix(renderParameter2.projection, renderIntoTexture: true) * renderParameter2.view).inverse;
					Shader.SetGlobalMatrixArray(ShaderIDs.s_StereoInverseViewProjection, InverseViewProjectionMatrixXR);
				}
			}
		}

		public static class URP
		{
			[Conditional("_XR_ENABLED")]
			public static void EnableXR(CommandBuffer commands, UniversalCameraData camera)
			{
				if (SinglePassXR && camera.xrRendering && camera.camera.stereoTargetEye == StereoTargetEyeMask.Both)
				{
					commands.EnableKeyword(SinglePassKeyword);
				}
			}

			[Conditional("_XR_ENABLED")]
			public static void DisableXR(CommandBuffer commands, UniversalCameraData camera)
			{
				if (SinglePassXR && camera.xrRendering && camera.camera.stereoTargetEye == StereoTargetEyeMask.Both)
				{
					commands.DisableKeyword(SinglePassKeyword);
				}
			}
		}

		private static readonly GlobalKeyword s_SinglePassInstancedKeyword = new GlobalKeyword("STEREO_INSTANCING_ON");

		private static readonly GlobalKeyword s_SinglePassMultiViewKeyword = new GlobalKeyword("STEREO_MULTIVIEW_ON");

		public static bool IsRenderGraph
		{
			get
			{
				if (RenderPipelineHelper.IsUniversal)
				{
					return !GraphicsSettings.GetRenderPipelineSettings<RenderGraphSettings>().enableRenderCompatibilityMode;
				}
				return false;
			}
		}

		internal static GlobalKeyword SinglePassKeyword => XRSettings.stereoRenderingMode switch
		{
			XRSettings.StereoRenderingMode.SinglePassInstanced => s_SinglePassInstancedKeyword, 
			XRSettings.StereoRenderingMode.SinglePassMultiview => s_SinglePassMultiViewKeyword, 
			_ => throw new NotImplementedException(), 
		};

		public static bool EnabledXR => XRSettings.enabled;

		private static bool SinglePassXR
		{
			get
			{
				if (XRSettings.enabled)
				{
					XRSettings.StereoRenderingMode stereoRenderingMode = XRSettings.stereoRenderingMode;
					return stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced || stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassMultiview;
				}
				return false;
			}
		}

		private static bool MultiPassXR
		{
			get
			{
				if (XRSettings.enabled)
				{
					return XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.MultiPass;
				}
				return false;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GraphicsFormat GetDefaultDepthStencilFormat()
		{
			return GraphicsFormat.D32_SFloat_S8_UInt;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GraphicsFormat GetDefaultDepthOnlyFormat()
		{
			return GraphicsFormat.D32_SFloat;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DepthBits GetDefaultDepthBufferBits()
		{
			return DepthBits.Depth32;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GraphicsFormat GetDefaultColorFormat(bool hdr)
		{
			return SystemInfo.GetGraphicsFormat(hdr ? DefaultFormat.HDR : DefaultFormat.LDR);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GraphicsFormat GetDefaultDepthFormat(bool stencil)
		{
			if (!stencil)
			{
				return GetDefaultDepthOnlyFormat();
			}
			return GetDefaultDepthStencilFormat();
		}
	}
}
