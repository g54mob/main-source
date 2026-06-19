using UnityEngine;

namespace Water2D
{
	public class WaterSimulationSimple : WaterSimulation
	{
		private Material _waveShader;

		[SerializeField]
		private RenderTexture CurrentState;

		[SerializeField]
		private RenderTexture Temporary;

		[SerializeField]
		private RenderTexture ObstructionTex;

		[SerializeField]
		private Vector4 ObstructionTexPos;

		[SerializeField]
		private Vector2Int resolution;

		[SerializeField]
		private SpriteRenderer sr;

		[SerializeField]
		private float waveRad;

		[SerializeField]
		private float waveHeight;

		[SerializeField]
		private float dispersion;

		[SerializeField]
		private float simSpeed;

		[SerializeField]
		private int iterations;

		[SerializeField]
		private int diffusionSize;

		[SerializeField]
		private float rainSpeed;

		[SerializeField]
		private float rainWaveH;

		[SerializeField]
		private int rainSizeX;

		[SerializeField]
		private int rainSizeY;

		[SerializeField]
		private bool enableRain;

		[SerializeField]
		[HideInInspector]
		private Camera _mainCam;

		private Vector4 TexturePos;

		private Vector4 lastTexturePos;

		private Material waveShader
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private Camera mainCam
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Setup(Camera mainCam, float simSpeed, Vector2Int resolution, SpriteRenderer sr, RenderTexture obstruction, float rainSpeed = 1f, int rainSizeX = 1, int rainSizeY = 1, float rainWaveH = 1f, float waveRad = 0.005f, float waveHeight = 1f, float dispersion = 0.98f, int iterations = 3, bool enableRain = false)
		{
		}

		public override RenderTexture GetRT()
		{
			return null;
		}

		private void InitTex(out RenderTexture rt)
		{
			rt = null;
		}

		private void Init()
		{
		}

		private void CreateIfNull()
		{
		}

		private Vector4 GetObstructionPositions()
		{
			return default(Vector4);
		}

		private Camera GetCameraRenderingScreen()
		{
			return null;
		}

		private Vector4 GetTexturePositions()
		{
			return default(Vector4);
		}

		private void Render()
		{
		}

		public override void UpdLoop()
		{
		}

		public Vector4 FutureSight()
		{
			return default(Vector4);
		}

		public override void Loop()
		{
		}

		public override void Setup(SimulationSettings value)
		{
		}

		public override void UpdateSettings(SimulationSettings value)
		{
		}
	}
}
