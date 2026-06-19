using System;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	public class LayerRenderer
	{
		[HideInInspector]
		[SerializeField]
		protected ModernWater2D water2D;

		[HideInInspector]
		[SerializeField]
		protected RenderTexture layerTexture;

		[HideInInspector]
		[SerializeField]
		protected LayerRendererType rendererType;

		[HideInInspector]
		[SerializeField]
		protected SpriteRenderer sr;

		[HideInInspector]
		[SerializeField]
		protected RenderTextureFormat format;

		[HideInInspector]
		[SerializeField]
		protected FilterMode fliterMode;

		[HideInInspector]
		[SerializeField]
		protected float bitDepth;

		[HideInInspector]
		[SerializeField]
		protected string layerName;

		[HideInInspector]
		[SerializeField]
		protected int layerMask;

		[HideInInspector]
		[SerializeField]
		protected Camera mainCamera;

		[HideInInspector]
		[SerializeField]
		protected Camera CameraRenderingScene;

		[HideInInspector]
		[SerializeField]
		protected Transform holder;

		[HideInInspector]
		[SerializeField]
		protected Transform follow;

		[HideInInspector]
		[SerializeField]
		[Range(0f, 1f)]
		protected float res;

		[HideInInspector]
		[SerializeField]
		[Range(1f, 2f)]
		protected Vector2 scale;

		[HideInInspector]
		[SerializeField]
		private int reflectionLayerIdx;

		private bool _run;

		[HideInInspector]
		[SerializeField]
		internal bool copyMainBackground;

		[HideInInspector]
		[SerializeField]
		private float lastOrtographicSize;

		[HideInInspector]
		[SerializeField]
		private float lastAspectRatio;

		public bool run
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public RenderTexture LayerTexture()
		{
			return null;
		}

		public void Setup(Camera mCamera, SpriteRenderer sr, Transform holder, string layerName, float resolution = 1f, RenderTextureFormat format = RenderTextureFormat.ARGB32, FilterMode filterMode = FilterMode.Point, float bitdepth = 0f)
		{
		}

		public void Setup(Camera mCamera, SpriteRenderer sr, Transform holder, int layers, float resolution = 1f, RenderTextureFormat format = RenderTextureFormat.ARGB32, FilterMode filterMode = FilterMode.Point, float bitdepth = 0f)
		{
		}

		private void CreateRT(SpriteRenderer sr, Camera mCamera, LayerRendererType type)
		{
		}

		private void CreateRTSpriteRenderer(SpriteRenderer sr, Camera mCamera)
		{
		}

		private void CreateRTCamera(Camera mCamera)
		{
		}

		private void StripCamera()
		{
		}

		public void Setup(Camera mCamera, Transform holder, string layerName, Vector2 scale, float resolution = 1f, RenderTextureFormat format = RenderTextureFormat.ARGB32, FilterMode filterMode = FilterMode.Point, float bitdepth = 0f)
		{
		}

		public void Setup(Camera mCamera, Transform holder, int layers, Vector2 scale, float resolution = 1f, RenderTextureFormat format = RenderTextureFormat.ARGB32, FilterMode filterMode = FilterMode.Point, float bitdepth = 0f)
		{
		}

		private void RTSetupExtended()
		{
		}

		private void RTSetup()
		{
		}

		public void Loop()
		{
		}

		private void UpdateCameraSize()
		{
		}

		private void RemoveLayerFromMainCamera()
		{
		}

		private void FollowCamera()
		{
		}

		public void Release()
		{
		}
	}
}
