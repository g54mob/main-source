using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

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
		[FormerlySerializedAs("dilateIterrations")]
		private int dilateIterations;

		[SerializeField]
		private DilateQuality dilateQuality;

		[SerializeField]
		[FormerlySerializedAs("blurIterrations")]
		private int blurIterations;

		[SerializeField]
		private BlurType blurType;

		[Obsolete]
		public float InfoRendererScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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

		private CameraEvent Event => default(CameraEvent);

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

		private RenderingMode RenderingMode
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

		[Obsolete("Fixed incorrect spelling. Use BlurIterations instead")]
		public int BlurIterrations
		{
			get
			{
				return 0;
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

		[Obsolete("Fixed incorrect spelling. Use DilateIterations instead")]
		public int DilateIterration
		{
			get
			{
				return 0;
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

		private void UpdateBuffer(Camera targetCamera, CommandBuffer buffer, bool removeOnly)
		{
		}

		private void OnPreRender()
		{
		}

		private void SetupOutline(Camera cameraToUse, OutlineParameters parametersToUse, bool isEditor)
		{
		}

		public void UpdateSharedParameters(OutlineParameters parameters, Camera camera, bool editorCamera)
		{
		}

		private void UpdateParameters(OutlineParameters parameters, Camera camera, bool editorCamera)
		{
		}
	}
}
