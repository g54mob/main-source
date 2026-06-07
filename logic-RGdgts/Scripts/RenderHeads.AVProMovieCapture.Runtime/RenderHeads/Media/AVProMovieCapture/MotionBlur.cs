using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class MotionBlur : MonoBehaviour
	{
		[SerializeField]
		private RenderTextureFormat _format;

		[SerializeField]
		private int _numSamples;

		private RenderTexture _accum;

		private RenderTexture _lastComp;

		private Material _addMaterial;

		private Material _divMaterial;

		private int _frameCount;

		private int _targetWidth;

		private int _targetHeight;

		private bool _isDirty;

		private static int _propNumSamples;

		private static int _propWeight;

		[SerializeField]
		public float _bias;

		private float _total;

		public bool IsFrameAccumulated { get; private set; }

		public int NumSamples
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int FrameCount => 0;

		public RenderTexture FinalTexture => null;

		private void Awake()
		{
		}

		public void SetTargetSize(int width, int height)
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void Setup()
		{
		}

		private void ClearAccumulation()
		{
		}

		private void OnDestroy()
		{
		}

		public void OnNumSamplesChanged()
		{
		}

		private static float LerpUnclamped(float a, float b, float t)
		{
			return 0f;
		}

		private void ApplyWeighting()
		{
		}

		public void Accumulate(Texture src)
		{
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dst)
		{
		}
	}
}
