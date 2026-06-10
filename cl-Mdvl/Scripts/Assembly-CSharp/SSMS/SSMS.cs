using UnityEngine;

namespace SSMS
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("OCASM/Image Effects/SSMS")]
	[ImageEffectAllowedInSceneView]
	public class SSMS : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
		[Tooltip("Filters out pixels under this level of brightness.")]
		private float _threshold;

		[HideInInspector]
		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Makes transition between under/over-threshold gradual.")]
		private float _softKnee = 0.5f;

		[Header("Scattering")]
		[SerializeField]
		[Range(1f, 7f)]
		[Tooltip("Changes extent of veiling effects\nin a screen resolution-independent fashion.")]
		private float _radius = 7f;

		[SerializeField]
		[Range(0.1f, 100f)]
		[Tooltip("Higher number creates a softer look but artifacts are more pronounced.")]
		private float _blurWeight = 1f;

		[SerializeField]
		[Tooltip("Blend factor of the result image.")]
		[Range(0f, 1f)]
		private float _intensity = 1f;

		[SerializeField]
		[Tooltip("Controls filter quality and buffer resolution.")]
		private bool _highQuality = true;

		[SerializeField]
		[Tooltip("Reduces flashing noise with an additional filter.")]
		private bool _antiFlicker = true;

		[SerializeField]
		[Tooltip("1D gradient. Determines how the effect fades across distance.")]
		private Texture2D _fadeRamp;

		[SerializeField]
		[Tooltip("Tints the resulting blur. ")]
		private Color _blurTint = Color.white;

		[SerializeField]
		[HideInInspector]
		private Shader _shader;

		private Material _material;

		private const int kMaxIterations = 16;

		private RenderTexture[] _blurBuffer1 = new RenderTexture[16];

		private RenderTexture[] _blurBuffer2 = new RenderTexture[16];

		private Camera cam;

		private const int minWidth = 32;

		private const int minHeight = 32;

		public float thresholdGamma
		{
			get
			{
				return Mathf.Max(_threshold, 0f);
			}
			set
			{
				_threshold = value;
			}
		}

		public float thresholdLinear
		{
			get
			{
				return GammaToLinear(thresholdGamma);
			}
			set
			{
				_threshold = LinearToGamma(value);
			}
		}

		public float softKnee
		{
			get
			{
				return _softKnee;
			}
			set
			{
				_softKnee = value;
			}
		}

		public float radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
			}
		}

		public float blurWeight
		{
			get
			{
				return _blurWeight;
			}
			set
			{
				_blurWeight = value;
			}
		}

		public float intensity
		{
			get
			{
				return Mathf.Max(_intensity, 0f);
			}
			set
			{
				_intensity = value;
			}
		}

		public bool highQuality
		{
			get
			{
				return _highQuality;
			}
			set
			{
				_highQuality = value;
			}
		}

		public bool antiFlicker
		{
			get
			{
				return _antiFlicker;
			}
			set
			{
				_antiFlicker = value;
			}
		}

		public Texture2D fadeRamp
		{
			get
			{
				return _fadeRamp;
			}
			set
			{
				_fadeRamp = value;
			}
		}

		public Color blurTint
		{
			get
			{
				return _blurTint;
			}
			set
			{
				_blurTint = value;
			}
		}

		private float LinearToGamma(float x)
		{
			return Mathf.LinearToGammaSpace(x);
		}

		private float GammaToLinear(float x)
		{
			return Mathf.GammaToLinearSpace(x);
		}

		private void OnEnable()
		{
			Shader shader = (_shader ? _shader : Shader.Find("Hidden/SSMS"));
			_material = new Material(shader);
			_material.hideFlags = HideFlags.DontSave;
			cam = GetComponent<Camera>();
			if (fadeRamp == null)
			{
				_fadeRamp = Resources.Load("Textures/nonLinear2", typeof(Texture2D)) as Texture2D;
			}
		}

		private void OnDisable()
		{
			Object.DestroyImmediate(_material);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (source.width <= 32 || source.height <= 32)
			{
				return;
			}
			bool isMobilePlatform = Application.isMobilePlatform;
			int num = source.width;
			int num2 = source.height;
			if (!_highQuality)
			{
				num /= 2;
				num2 /= 2;
			}
			RenderTextureFormat format = (isMobilePlatform ? RenderTextureFormat.Default : RenderTextureFormat.DefaultHDR);
			float num3 = Mathf.Log(num2, 2f) + _radius - 8f;
			int num4 = (int)num3;
			int num5 = Mathf.Clamp(num4, 1, 16);
			float num6 = thresholdLinear;
			_material.SetFloat("_Threshold", num6);
			float num7 = num6 * _softKnee + 1E-05f;
			Vector3 vector = new Vector3(num6 - num7, num7 * 2f, 0.25f / num7);
			_material.SetVector("_Curve", vector);
			bool flag = !_highQuality && _antiFlicker;
			_material.SetFloat("_PrefilterOffs", flag ? (-0.5f) : 0f);
			_material.SetFloat("_SampleScale", 0.5f + num3 - (float)num4);
			_material.SetFloat("_Intensity", intensity);
			_material.SetTexture("_FadeTex", _fadeRamp);
			_material.SetFloat("_BlurWeight", _blurWeight);
			_material.SetFloat("_Radius", _radius);
			_material.SetColor("_BlurTint", _blurTint);
			RenderTexture temporary = RenderTexture.GetTemporary(num, num2, 0, format);
			int pass = (_antiFlicker ? 1 : 0);
			Graphics.Blit(source, temporary, _material, pass);
			RenderTexture renderTexture = temporary;
			for (int i = 0; i < num5; i++)
			{
				_blurBuffer1[i] = RenderTexture.GetTemporary(renderTexture.width / 2, renderTexture.height / 2, 0, format);
				pass = ((i == 0) ? (_antiFlicker ? 3 : 2) : 4);
				Graphics.Blit(renderTexture, _blurBuffer1[i], _material, pass);
				renderTexture = _blurBuffer1[i];
			}
			for (int num8 = num5 - 2; num8 >= 0; num8--)
			{
				RenderTexture renderTexture2 = _blurBuffer1[num8];
				_material.SetTexture("_BaseTex", renderTexture2);
				_blurBuffer2[num8] = RenderTexture.GetTemporary(renderTexture2.width, renderTexture2.height, 0, format);
				pass = (_highQuality ? 6 : 5);
				Graphics.Blit(renderTexture, _blurBuffer2[num8], _material, pass);
				renderTexture = _blurBuffer2[num8];
			}
			_material.SetTexture("_BaseTex", source);
			pass = (_highQuality ? 8 : 7);
			Graphics.Blit(renderTexture, destination, _material, pass);
			for (int j = 0; j < 16; j++)
			{
				if (_blurBuffer1[j] != null)
				{
					RenderTexture.ReleaseTemporary(_blurBuffer1[j]);
				}
				if (_blurBuffer2[j] != null)
				{
					RenderTexture.ReleaseTemporary(_blurBuffer2[j]);
				}
				_blurBuffer1[j] = null;
				_blurBuffer2[j] = null;
			}
			RenderTexture.ReleaseTemporary(temporary);
		}
	}
}
