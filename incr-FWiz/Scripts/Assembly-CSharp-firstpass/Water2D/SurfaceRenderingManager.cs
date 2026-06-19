using UnityEngine;

namespace Water2D
{
	[ExecuteAlways]
	[RequireComponent(typeof(Camera))]
	public class SurfaceRenderingManager : WaterFeatureLayerRenderer
	{
		public static SurfaceRenderingManager instance;

		public LayerRenderer layerRenderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		protected override void Update()
		{
		}

		private void Singleton()
		{
		}

		public void SetupLayerRenderer(Camera cameraRenderingScreen)
		{
		}

		private void OnDisable()
		{
		}
	}
}
