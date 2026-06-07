using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	public class Outliner : MonoBehaviour
	{
		private static List<Outlinable> temporaryOutlinables;

		private OutlineParameters parameters;

		private Camera targetCamera;

		[SerializeField]
		private RenderStage stage;

		[SerializeField]
		private OutlineRenderingStrategy renderingStrategy;

		[SerializeField]
		private RenderingMode renderingMode;

		[SerializeField]
		private long outlineLayerMask;

		[SerializeField]
		private BufferSizeMode primaryBufferSizeMode;

		[SerializeField]
		[Range(0.15f, 1f)]
		private float primaryRendererScale;

		[SerializeField]
		private int primarySizeReference;

		[SerializeField]
		[Range(0f, 2f)]
		private float blurShift;

		[SerializeField]
		[Range(0f, 2f)]
		private float dilateShift;

		[SerializeField]
		private int dilateIterations;

		[SerializeField]
		private DilateQuality dilateQuality;

		[SerializeField]
		private int blurIterations;

		[SerializeField]
		private BlurType blurType;

		private RTHandle target;

		private RTHandle primaryBuffer;

		private RTHandle targetBuffer;

		private OutlineParameters Parameters => null;

		private CameraEvent Event => default(CameraEvent);

		public int PrimarySizeReference
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public BufferSizeMode PrimaryBufferSizeMode
		{
			get
			{
				return default(BufferSizeMode);
			}
			set
			{
			}
		}

		public OutlineRenderingStrategy RenderingStrategy
		{
			get
			{
				return default(OutlineRenderingStrategy);
			}
			set
			{
			}
		}

		public RenderStage RenderStage
		{
			get
			{
				return default(RenderStage);
			}
			set
			{
			}
		}

		public DilateQuality DilateQuality
		{
			get
			{
				return default(DilateQuality);
			}
			set
			{
			}
		}

		public RenderingMode RenderingMode
		{
			get
			{
				return default(RenderingMode);
			}
			set
			{
			}
		}

		public float BlurShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float DilateShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public long OutlineLayerMask
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public float PrimaryRendererScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int BlurIterations
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public BlurType BlurType
		{
			get
			{
				return default(BlurType);
			}
			set
			{
			}
		}

		public int DilateIterations
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void UpdateBuffer(Camera cameraToUpdate, CommandBufferWrapper buffer, bool removeOnly)
		{
		}

		private void OnPreRender()
		{
		}

		private void SetupOutline(Camera cameraToUse, OutlineParameters parametersToUse, bool isEditor)
		{
		}

		public StereoTargetEyeMask GetTargetEyeMask(Camera cameraTarget)
		{
			return default(StereoTargetEyeMask);
		}

		public void UpdateSharedParameters(OutlineParameters parametersToUpdate, Camera cameraToUpdate, bool editorCamera, bool forceNative, bool forceHDR)
		{
		}

		public void ReplaceHandles(OutlineParameters parametersToUpdate)
		{
		}

		private static void Replace(ref RTHandle handle, int width, int height, OutlineParameters parameters, Func<int, int, OutlineParameters, RTHandle> newHandle)
		{
		}

		private void PrepareParameters(OutlineParameters parametersToPrepare, Camera cameraToUse, bool editorCamera)
		{
		}
	}
}
