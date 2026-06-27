using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

namespace EPOOutline
{
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	public class Outliner : MonoBehaviour
	{
		private static List<Outlinable> temporaryOutlinables = new List<Outlinable>();

		private OutlineParameters parameters;

		private Camera targetCamera;

		[SerializeField]
		private RenderStage stage = RenderStage.AfterTransparents;

		[SerializeField]
		private OutlineRenderingStrategy renderingStrategy;

		[SerializeField]
		private RenderingMode renderingMode;

		[SerializeField]
		private long outlineLayerMask = -1L;

		[SerializeField]
		private BufferSizeMode primaryBufferSizeMode;

		[SerializeField]
		[Range(0.15f, 1f)]
		private float primaryRendererScale = 0.75f;

		[SerializeField]
		private int primarySizeReference = 800;

		[SerializeField]
		[Range(0f, 2f)]
		private float blurShift = 1f;

		[SerializeField]
		[Range(0f, 2f)]
		private float dilateShift = 1f;

		[SerializeField]
		private int dilateIterations = 1;

		[SerializeField]
		private DilateQuality dilateQuality;

		[SerializeField]
		private int blurIterations = 1;

		[SerializeField]
		private BlurType blurType = BlurType.Box;

		private RTHandle target;

		private RTHandle primaryBuffer;

		private RTHandle targetBuffer;

		private OutlineParameters Parameters => parameters ?? (parameters = new OutlineParameters(new BasicCommandBufferWrapper(new CommandBuffer())));

		private CameraEvent Event
		{
			get
			{
				if (stage != RenderStage.BeforeTransparents)
				{
					return CameraEvent.BeforeImageEffects;
				}
				return CameraEvent.AfterForwardOpaque;
			}
		}

		public int PrimarySizeReference
		{
			get
			{
				return primarySizeReference;
			}
			set
			{
				primarySizeReference = ((value < 10) ? 50 : value);
			}
		}

		public BufferSizeMode PrimaryBufferSizeMode
		{
			get
			{
				return primaryBufferSizeMode;
			}
			set
			{
				primaryBufferSizeMode = value;
			}
		}

		public OutlineRenderingStrategy RenderingStrategy
		{
			get
			{
				return renderingStrategy;
			}
			set
			{
				renderingStrategy = value;
			}
		}

		public RenderStage RenderStage
		{
			get
			{
				return stage;
			}
			set
			{
				stage = value;
			}
		}

		public DilateQuality DilateQuality
		{
			get
			{
				return dilateQuality;
			}
			set
			{
				dilateQuality = value;
			}
		}

		public RenderingMode RenderingMode
		{
			get
			{
				return renderingMode;
			}
			set
			{
				renderingMode = value;
			}
		}

		public float BlurShift
		{
			get
			{
				return blurShift;
			}
			set
			{
				blurShift = Mathf.Clamp(value, 0f, 2f);
			}
		}

		public float DilateShift
		{
			get
			{
				return dilateShift;
			}
			set
			{
				dilateShift = Mathf.Clamp(value, 0f, 2f);
			}
		}

		public long OutlineLayerMask
		{
			get
			{
				return outlineLayerMask;
			}
			set
			{
				outlineLayerMask = value;
			}
		}

		public float PrimaryRendererScale
		{
			get
			{
				return primaryRendererScale;
			}
			set
			{
				primaryRendererScale = Mathf.Clamp(value, 0.1f, 1f);
			}
		}

		public int BlurIterations
		{
			get
			{
				return blurIterations;
			}
			set
			{
				blurIterations = ((value > 0) ? value : 0);
			}
		}

		public BlurType BlurType
		{
			get
			{
				return blurType;
			}
			set
			{
				blurType = value;
			}
		}

		public int DilateIterations
		{
			get
			{
				return dilateIterations;
			}
			set
			{
				dilateIterations = ((value > 0) ? value : 0);
			}
		}

		private void OnValidate()
		{
			if (blurIterations < 0)
			{
				blurIterations = 0;
			}
			if (dilateIterations < 0)
			{
				dilateIterations = 0;
			}
			if (primarySizeReference < 10)
			{
				primarySizeReference = 10;
			}
			else if (primarySizeReference > 4096)
			{
				primarySizeReference = 4096;
			}
			primaryRendererScale = Mathf.Clamp(primaryRendererScale, 0.1f, 1f);
			if (blurType < BlurType.Box)
			{
				blurType = BlurType.Box;
			}
			if (blurType > BlurType.Gaussian13x13)
			{
				blurType = BlurType.Gaussian13x13;
			}
		}

		private void OnEnable()
		{
			if (targetCamera == null)
			{
				targetCamera = GetComponent<Camera>();
			}
			targetCamera.forceIntoRenderTexture = targetCamera.stereoTargetEye == StereoTargetEyeMask.None || !XRSettings.enabled;
		}

		private void OnDestroy()
		{
			Parameters.Dispose();
		}

		private void OnDisable()
		{
			if (targetCamera != null)
			{
				UpdateBuffer(targetCamera, Parameters.Buffer, removeOnly: true);
			}
		}

		private void UpdateBuffer(Camera cameraToUpdate, CommandBufferWrapper buffer, bool removeOnly)
		{
			if (RenderPipelineManager.currentPipeline == null && buffer is IUnderlyingBufferProvider { UnderlyingBuffer: { } underlyingBuffer })
			{
				cameraToUpdate.RemoveCommandBuffer(CameraEvent.BeforeImageEffects, underlyingBuffer);
				cameraToUpdate.RemoveCommandBuffer(CameraEvent.AfterForwardOpaque, underlyingBuffer);
				if (!removeOnly)
				{
					cameraToUpdate.AddCommandBuffer(Event, underlyingBuffer);
				}
			}
		}

		private void OnPreRender()
		{
			if (!(PipelineFetcher.CurrentAsset != null))
			{
				Parameters.OutlinablesToRender.Clear();
				SetupOutline(targetCamera, Parameters, isEditor: false);
			}
		}

		private void SetupOutline(Camera cameraToUse, OutlineParameters parametersToUse, bool isEditor)
		{
			UpdateBuffer(cameraToUse, parametersToUse.Buffer, removeOnly: false);
			PrepareParameters(parametersToUse, cameraToUse, isEditor);
			parametersToUse.Buffer.Clear();
			if (renderingStrategy == OutlineRenderingStrategy.Default)
			{
				OutlineEffect.SetupOutline(parametersToUse);
				parametersToUse.BlitMesh = null;
				parametersToUse.MeshPool.ReleaseAllMeshes();
				return;
			}
			temporaryOutlinables.Clear();
			temporaryOutlinables.AddRange(parametersToUse.OutlinablesToRender);
			parametersToUse.OutlinablesToRender.Clear();
			parametersToUse.OutlinablesToRender.Add(null);
			foreach (Outlinable temporaryOutlinable in temporaryOutlinables)
			{
				parametersToUse.OutlinablesToRender[0] = temporaryOutlinable;
				OutlineEffect.SetupOutline(parametersToUse);
				parametersToUse.BlitMesh = null;
			}
			parametersToUse.MeshPool.ReleaseAllMeshes();
		}

		public StereoTargetEyeMask GetTargetEyeMask(Camera cameraTarget)
		{
			if (!XRUtility.IsXRActive)
			{
				return StereoTargetEyeMask.None;
			}
			return cameraTarget.stereoTargetEye;
		}

		public void UpdateSharedParameters(OutlineParameters parametersToUpdate, Camera cameraToUpdate, bool editorCamera, bool forceNative, bool forceHDR)
		{
			parametersToUpdate.DilateQuality = DilateQuality;
			parametersToUpdate.Camera = cameraToUpdate;
			parametersToUpdate.IsEditorCamera = editorCamera;
			parametersToUpdate.PrimaryBufferScale = (forceNative ? 1f : primaryRendererScale);
			if (forceNative)
			{
				parametersToUpdate.PrimaryBufferSizeMode = BufferSizeMode.Native;
			}
			else
			{
				parametersToUpdate.PrimaryBufferSizeMode = primaryBufferSizeMode;
				parametersToUpdate.PrimaryBufferSizeReference = primarySizeReference;
			}
			parametersToUpdate.BlurIterations = blurIterations;
			parametersToUpdate.BlurType = blurType;
			parametersToUpdate.DilateIterations = dilateIterations;
			parametersToUpdate.BlurShift = blurShift;
			parametersToUpdate.DilateShift = dilateShift;
			parametersToUpdate.UseHDR = forceHDR || (cameraToUpdate.allowHDR && RenderingMode == RenderingMode.HDR);
			parametersToUpdate.EyeMask = GetTargetEyeMask(cameraToUpdate);
			parametersToUpdate.OutlineLayerMask = outlineLayerMask;
			parametersToUpdate.Prepare();
			parametersToUpdate.TextureHandleMap.Clear();
			foreach (Outlinable item in parametersToUpdate.OutlinablesToRender)
			{
				for (int i = 0; i < item.OutlineTargets.Count; i++)
				{
					OutlineTarget outlineTarget = item.OutlineTargets[i];
					if (outlineTarget.IsValidForCutout)
					{
						Texture cutoutTexture = outlineTarget.CutoutTexture;
						RTHandle value = parametersToUpdate.RTHandlePool.Allocate(cutoutTexture);
						parametersToUpdate.TextureHandleMap[cutoutTexture] = value;
					}
					if (outlineTarget.Renderer is SpriteRenderer spriteRenderer)
					{
						Texture2D texture = spriteRenderer.sprite.texture;
						RTHandle value2 = parametersToUpdate.RTHandlePool.Allocate(texture);
						parametersToUpdate.TextureHandleMap[texture] = value2;
					}
				}
			}
		}

		public void ReplaceHandles(OutlineParameters parametersToUpdate)
		{
			Replace(ref parametersToUpdate.Handles.Target, parametersToUpdate.TargetWidth, parametersToUpdate.TargetHeight, parametersToUpdate, (int width2, int height2, OutlineParameters outlineParameters) => RenderTargetUtility.GetRT(outlineParameters, width2, height2, "Target"));
			Replace(ref parametersToUpdate.Handles.InfoTarget, parametersToUpdate.TargetWidth, parametersToUpdate.TargetHeight, parametersToUpdate, (int width2, int height2, OutlineParameters outlineParameters) => RenderTargetUtility.GetRT(outlineParameters, width2, height2, "Info target"));
			var (width, height) = parametersToUpdate.ScaledSize;
			Replace(ref parametersToUpdate.Handles.PrimaryTarget, width, height, parametersToUpdate, (int width2, int height2, OutlineParameters outlineParameters) => RenderTargetUtility.GetRT(outlineParameters, width2, height2, "Primary target"));
			Replace(ref parametersToUpdate.Handles.SecondaryTarget, width, height, parametersToUpdate, (int width2, int height2, OutlineParameters outlineParameters) => RenderTargetUtility.GetRT(outlineParameters, width2, height2, "Secondary target"));
			Replace(ref parametersToUpdate.Handles.PrimaryInfoBufferTarget, width, height, parametersToUpdate, (int width2, int height2, OutlineParameters outlineParameters) => RenderTargetUtility.GetRT(outlineParameters, width2, height2, "Primary info target"));
			Replace(ref parametersToUpdate.Handles.SecondaryInfoBufferTarget, width, height, parametersToUpdate, (int width2, int height2, OutlineParameters outlineParameters) => RenderTargetUtility.GetRT(outlineParameters, width2, height2, "Secondary info target"));
		}

		private static void Replace(ref RTHandle handle, int width, int height, OutlineParameters parameters, Func<int, int, OutlineParameters, RTHandle> newHandle)
		{
			if (handle != null)
			{
				if (width == handle.rtHandleProperties.currentRenderTargetSize.x && height == handle.rtHandleProperties.currentRenderTargetSize.y && handle.rt.descriptor.msaaSamples == parameters.Antialiasing)
				{
					return;
				}
				handle.Release();
			}
			handle = newHandle(width, height, parameters);
			handle.SetCustomHandleProperties(new RTHandleProperties
			{
				currentRenderTargetSize = new Vector2Int(width, height)
			});
		}

		private void PrepareParameters(OutlineParameters parametersToPrepare, Camera cameraToUse, bool editorCamera)
		{
			parametersToPrepare.RTHandlePool.ReleaseAll();
			parametersToPrepare.DepthTarget = parametersToPrepare.RTHandlePool.Allocate(RenderTargetUtility.ComposeTarget(parametersToPrepare, BuiltinRenderTextureType.CameraTarget));
			parametersToPrepare.Target = parametersToPrepare.RTHandlePool.Allocate(RenderTargetUtility.ComposeTarget(parametersToPrepare, BuiltinRenderTextureType.CameraTarget));
			RenderTexture renderTexture = ((cameraToUse.targetTexture == null) ? cameraToUse.activeTexture : cameraToUse.targetTexture);
			if (XRUtility.IsUsingVR(parametersToPrepare))
			{
				RenderTextureDescriptor vRRenderTextureDescriptor = XRUtility.VRRenderTextureDescriptor;
				parametersToPrepare.TargetWidth = vRRenderTextureDescriptor.width;
				parametersToPrepare.TargetHeight = vRRenderTextureDescriptor.height;
			}
			else
			{
				parametersToPrepare.TargetWidth = ((renderTexture != null) ? renderTexture.width : cameraToUse.scaledPixelWidth);
				parametersToPrepare.TargetHeight = ((renderTexture != null) ? renderTexture.height : cameraToUse.scaledPixelHeight);
			}
			parametersToPrepare.Viewport = new Rect(0f, 0f, parametersToPrepare.TargetWidth, parametersToPrepare.TargetHeight);
			parametersToPrepare.Antialiasing = ((!editorCamera) ? CameraUtility.GetMSAA(targetCamera) : ((renderTexture == null) ? 1 : renderTexture.antiAliasing));
			parametersToPrepare.Camera = cameraToUse;
			(parametersToPrepare.ScaledBufferWidth, parametersToPrepare.ScaledBufferHeight) = parametersToPrepare.ScaledSize;
			Outlinable.GetAllActiveOutlinables(parametersToPrepare.OutlinablesToRender);
			RendererFilteringUtility.Filter(parametersToPrepare.Camera, parametersToPrepare);
			UpdateSharedParameters(parametersToPrepare, cameraToUse, editorCamera, forceNative: false, forceHDR: false);
			ReplaceHandles(parametersToPrepare);
		}
	}
}
