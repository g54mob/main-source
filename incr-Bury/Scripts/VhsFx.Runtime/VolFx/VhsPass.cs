using System;
using System.Linq;
using UnityEngine;

namespace VolFx
{
	[ShaderName("Hidden/Vol/Vhs")]
	public class VhsPass : VolFx.Pass
	{
		public enum Mode
		{
			Tape = 0,
			Noise = 1,
			Shades = 2
		}

		[Serializable]
		public class NoiseSettings
		{
			[Tooltip("Noise resolution - height in pixels")]
			public int _height = 180;

			[Range(0f, 1f)]
			[Tooltip("Noise texture aspect")]
			public float _aspect = 0.3f;

			[Tooltip("Use point filter")]
			public bool _point = true;

			[Tooltip("Grayscale noise")]
			[Range(0f, 1f)]
			public float _color = 1f;

			[Tooltip("Red color range")]
			public Vector2 _red = new Vector2(0f, 1f);

			[Tooltip("Green color range")]
			public Vector2 _green = new Vector2(0f, 1f);

			[Tooltip("Blue color range")]
			public Vector2 _blue = new Vector2(0f, 1f);

			[CurveRange]
			[Tooltip("Interpolation of noise intensity parameter")]
			public AnimationCurve _intencityToHardness = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
		}

		private static readonly int s_VhsTex = Shader.PropertyToID("_VhsTex");

		private static readonly int s_ShadesTex = Shader.PropertyToID("_ShadesTex");

		private static readonly int s_NoiseTex = Shader.PropertyToID("_NoiseTex");

		private static readonly int s_InputA = Shader.PropertyToID("_InputA");

		private static readonly int s_InputB = Shader.PropertyToID("_InputB");

		private static readonly int s_Glitch = Shader.PropertyToID("_Glitch");

		private static readonly int s_Noise = Shader.PropertyToID("_Noise");

		private static readonly int s_NoiseOffset = Shader.PropertyToID("_NoiseOffset");

		[Tooltip("Default Glitch color")]
		public Color _colorDefault = Color.red;

		public NoiseSettings _noiseSettings;

		private float _flicker;

		private Texture2D _noiseTex;

		[HideInInspector]
		public float _frameRate = 20f;

		[HideInInspector]
		public Texture2D[] _tape;

		[HideInInspector]
		public Texture2D[] _shades;

		private float _playTimeTape;

		private float _playTimeShades;

		private float _yScanline;

		private float _xScanline;

		private bool _lineDis;

		public override string ShaderName => string.Empty;

		protected override bool Invert => true;

		protected override bool _editorValidate
		{
			get
			{
				if (_tape != null && _tape.Length != 0 && (Application.isPlaying || !_tape.Any((Texture2D n) => n == null)) && _shades != null && _shades.Length != 0)
				{
					if (!Application.isPlaying)
					{
						return _shades.Any((Texture2D n) => n == null);
					}
					return false;
				}
				return true;
			}
		}

		public override void Init()
		{
			_lineDis = false;
		}

		public override bool Validate(Material mat)
		{
			VhsVol component = base.Stack.GetComponent<VhsVol>();
			if (!component.IsActive())
			{
				return false;
			}
			_validateNoise();
			_yScanline += Time.deltaTime * 0.01f * component._flow.value;
			_xScanline -= Time.deltaTime * 0.1f * component._pulsation.value;
			Color value = (component._color.overrideState ? component._color.value : _colorDefault);
			if (_yScanline >= 1f)
			{
				_yScanline = UnityEngine.Random.value;
			}
			if (_xScanline <= 0f || (double)UnityEngine.Random.value < 0.05)
			{
				_xScanline = UnityEngine.Random.value;
			}
			if (component._lines.value != _lineDis)
			{
				if (component._lines.value)
				{
					mat.EnableKeyword("_LINE_DISTORTION_ON");
				}
				else
				{
					mat.DisableKeyword("_LINE_DISTORTION_ON");
				}
				_lineDis = component._lines.value;
			}
			mat.SetColor(s_Glitch, value);
			mat.SetVector(s_InputA, new Vector4(_yScanline, _xScanline, component._weight.value, component._rocking.value * component._weight.value));
			mat.SetVector(s_InputB, new Vector4(component._tape.value, (component._squeeze.value == 0f) ? 0f : (1f / Mathf.Lerp(1000f, 2f, component._squeeze.value)), component._flickering.value, component._bleed.value));
			float num = component._density.value;
			if (num == 0f)
			{
				num = -1f;
			}
			mat.SetVector(s_NoiseOffset, new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value));
			mat.SetVector(s_Noise, new Vector4(Mathf.Clamp01(component._intensity.value + _noiseSettings._intencityToHardness.Evaluate(component._density.value)), num, component._scale.value, component._shades.value));
			_playTimeTape = (_playTimeTape + Time.unscaledDeltaTime) % ((float)_tape.Length / _frameRate);
			mat.SetTexture(s_VhsTex, _tape[Mathf.FloorToInt(_playTimeTape * _frameRate)]);
			_playTimeShades = (_playTimeShades + Time.unscaledDeltaTime) % ((float)_shades.Length / _frameRate);
			mat.SetTexture(s_ShadesTex, _shades[Mathf.FloorToInt(_playTimeShades * _frameRate)]);
			mat.SetTexture(s_NoiseTex, _noiseTex);
			return true;
		}

		private void OnValidate()
		{
			_validateNoise();
		}

		private void _validateNoise()
		{
			float num = (float)Screen.width / (float)Screen.height;
			Vector2Int vector2Int = new Vector2Int((int)((float)_noiseSettings._height * num * _noiseSettings._aspect), _noiseSettings._height);
			if (vector2Int.x < 4)
			{
				vector2Int.x = 4;
			}
			if (vector2Int.y < 4)
			{
				vector2Int.y = 4;
			}
			if (!(_noiseTex == null) && _noiseTex.width == vector2Int.x && _noiseTex.height == vector2Int.y)
			{
				return;
			}
			_noiseTex = new Texture2D(vector2Int.x, vector2Int.y, TextureFormat.RGBA32, mipChain: false);
			_noiseTex.filterMode = ((!_noiseSettings._point) ? FilterMode.Bilinear : FilterMode.Point);
			_noiseTex.wrapMode = TextureWrapMode.Repeat;
			for (int i = 0; i < _noiseTex.width; i++)
			{
				for (int j = 0; j < _noiseTex.height; j++)
				{
					Color b = new Color(UnityEngine.Random.Range(_noiseSettings._red.x, _noiseSettings._red.y), UnityEngine.Random.Range(_noiseSettings._green.x, _noiseSettings._green.y), UnityEngine.Random.Range(_noiseSettings._blue.x, _noiseSettings._blue.y), UnityEngine.Random.value);
					float grayscale = b.grayscale;
					b = Color.Lerp(new Color(grayscale, grayscale, grayscale, b.a), b, _noiseSettings._color);
					_noiseTex.SetPixel(i, j, b);
				}
			}
			_noiseTex.Apply();
		}

		protected override void _editorSetup(string folder, string asset)
		{
		}
	}
}
