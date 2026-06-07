using UnityEngine;

namespace StylizedGrass
{
	[AddComponentMenu("Stylized Grass/Stylized Grass Renderer")]
	[ExecuteInEditMode]
	public class StylizedGrassRenderer : MonoBehaviour
	{
		public static StylizedGrassRenderer Instance;

		public bool debug;

		public RenderTexture vectorRT;

		[Tooltip("When a color map is assigned, this will be set as the active color map.\n\nHaving the Color Map Renderer component present would not longer be required.")]
		public GrassColorMap colorMap;

		[Tooltip("When enabled the grass Ambient and Gust strength values are multiplied by the WindZone's Main value")]
		public bool listenToWindZone;

		public WindZone windZone;

		public static int _BendMapUV;

		private static int _GlobalWindParams;

		private static int _GlobalWindDirection;

		private double lastFrameTime;

		private double timeOffset;

		private Vector3 lastDirection;

		private Vector3 windDirection;

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public static void SetWindZone(WindZone windZone)
		{
		}

		private void Update()
		{
		}

		private void UpdateWind()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
