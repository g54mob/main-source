using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VolFx
{
	[ShaderName("Hidden/VolFx/Dither")]
	public class DitherPass : VolFx.Pass
	{
		public class PaletteCash
		{
			public Texture2D _palette;

			public Texture2D _quant;

			public Texture2D _measure;
		}

		public enum Mode
		{
			Dither = 0,
			Noise = 1
		}

		public static class LutGenerator
		{
			[Serializable]
			public enum LutSize
			{
				x16 = 0,
				x32 = 1,
				x64 = 2
			}

			[Serializable]
			public enum Gamma
			{
				rec601 = 0,
				rec709 = 1,
				rec2100 = 2,
				average = 3
			}

			private static Texture2D _lut16;

			private static Texture2D _lut32;

			private static Texture2D _lut64;

			public static PaletteCash Generate(Texture2D _palette, LutSize lutSize = LutSize.x16, Gamma gamma = Gamma.rec601)
			{
				Texture2D texture2D = _getLut(lutSize);
				Color[] pixels = texture2D.GetPixels();
				Color[] colors = _palette.GetPixels();
				Texture2D texture2D2 = new Texture2D(texture2D.width, texture2D.height, TextureFormat.ARGB32, mipChain: false);
				Texture2D texture2D3 = new Texture2D(texture2D.width, texture2D.height, TextureFormat.ARGB32, mipChain: false);
				Texture2D texture2D4 = new Texture2D(texture2D.width, texture2D.height, TextureFormat.ARGB32, mipChain: false);
				Color[] pixels2 = (from lutColor in pixels
					select (from gradeColor in colors
						select (grade: compare(lutColor, gradeColor), color: gradeColor) into n
						orderby n.grade
						select n).First() into n
					select n.color).ToArray();
				Color[] pixels3 = pixels.Select((Color lutColor) => (from gradeColor in colors
					select (grade: compare(lutColor, gradeColor), color: gradeColor) into n
					orderby n.grade
					select n).ToArray()[1].color).ToArray();
				colors = _palette.GetPixels().Select(_lutAt).ToArray();
				Color[] pixels4 = pixels.Select(delegate(Color lutColor)
				{
					(float grade, Color color)[] array = (from gradeColor in colors
						select (grade: compare(lutColor, gradeColor), color: gradeColor) into n
						orderby n.grade
						select n).ToArray();
					(float, Color) tuple = array[0];
					(float, Color) tuple2 = array[1];
					float num = 1f - tuple.Item1 / tuple2.Item1;
					return new Color(num, num, num);
				}).ToArray();
				texture2D2.SetPixels(pixels2);
				texture2D2.filterMode = FilterMode.Point;
				texture2D2.wrapMode = TextureWrapMode.Clamp;
				texture2D2.Apply();
				texture2D3.SetPixels(pixels3);
				texture2D3.filterMode = FilterMode.Point;
				texture2D3.wrapMode = TextureWrapMode.Clamp;
				texture2D3.Apply();
				texture2D4.SetPixels(pixels4);
				texture2D4.filterMode = FilterMode.Bilinear;
				texture2D4.wrapMode = TextureWrapMode.Clamp;
				texture2D4.Apply();
				return new PaletteCash
				{
					_palette = texture2D2,
					_measure = texture2D4,
					_quant = texture2D3
				};
				Color _lutAt(Color c)
				{
					if (c.r >= 1f)
					{
						c.r = 0.999f;
					}
					if (c.g >= 1f)
					{
						c.g = 0.999f;
					}
					if (c.b >= 1f)
					{
						c.b = 0.999f;
					}
					int _lutSize = _getLutSize(lutSize);
					float num = ((float)_lutSize - 1f) / (float)_lutSize;
					float num2 = 0.5f * (1f / (float)_lutSize);
					float num3 = 1f / (float)_lutSize;
					int x = Mathf.FloorToInt((c.r * num + num2) / num3);
					int y = Mathf.FloorToInt((c.g * num + num2) / num3);
					int z = Mathf.FloorToInt((c.b * num + num2) / num3);
					return lutAt(x, y, z);
					Color lutAt(int num4, int num5, int num6)
					{
						return new Color((float)num4 / ((float)_lutSize - 1f), (float)num5 / ((float)_lutSize - 1f), (float)num6 / ((float)_lutSize - 1f), 1f);
					}
				}
				float compare(Color a, Color b)
				{
					Vector3 vector = gamma switch
					{
						Gamma.rec601 => new Vector3(0.299f, 0.587f, 0.114f), 
						Gamma.rec709 => new Vector3(0.2126f, 0.7152f, 0.0722f), 
						Gamma.rec2100 => new Vector3(0.2627f, 0.678f, 0.0593f), 
						Gamma.average => new Vector3(0.33333f, 0.33333f, 0.33333f), 
						_ => throw new ArgumentOutOfRangeException(), 
					};
					return (new Vector3(a.r * vector.x, a.g * vector.y, a.b * vector.z) - new Vector3(b.r * vector.x, b.g * vector.y, b.b * vector.z)).magnitude;
				}
			}

			internal static int _getLutSize(LutSize lutSize)
			{
				return lutSize switch
				{
					LutSize.x16 => 16, 
					LutSize.x32 => 32, 
					LutSize.x64 => 64, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}

			internal static Texture2D _getLut(LutSize lutSize)
			{
				int size = _getLutSize(lutSize);
				Texture2D texture2D = lutSize switch
				{
					LutSize.x16 => _lut16, 
					LutSize.x32 => _lut32, 
					LutSize.x64 => _lut64, 
					_ => throw new ArgumentOutOfRangeException("lutSize", lutSize, null), 
				};
				if (texture2D != null && texture2D.height == size)
				{
					return texture2D;
				}
				texture2D = new Texture2D(size * size, size, TextureFormat.RGBA32, 0, linear: false);
				texture2D.filterMode = FilterMode.Point;
				for (int i = 0; i < size; i++)
				{
					for (int j = 0; j < size * size; j++)
					{
						texture2D.SetPixel(j, i, _lutAt(j, i));
					}
				}
				texture2D.Apply();
				return texture2D;
				Color _lutAt(int x, int y)
				{
					return new Color((float)(x % size) / ((float)size - 1f), (float)y / ((float)size - 1f), (float)Mathf.FloorToInt((float)x / (float)size) * (1f / ((float)size - 1f)), 1f);
				}
			}
		}

		private static readonly int s_PaletteTex = Shader.PropertyToID("_PaletteTex");

		private static readonly int s_QuantTex = Shader.PropertyToID("_QuantTex");

		private static readonly int s_MeasureTex = Shader.PropertyToID("_MeasureTex");

		private static readonly int s_DitherTex = Shader.PropertyToID("_DitherTex");

		private static readonly int s_Data = Shader.PropertyToID("_Data");

		private static readonly int s_PatternData = Shader.PropertyToID("_PatternData");

		private static readonly int s_DitherMad = Shader.PropertyToID("_DitherMad");

		[HideInInspector]
		[Tooltip("Dithering pattern tiling range mapped from Scale value")]
		public Vector2Int _scaleRange = new Vector2Int(1, 100);

		[Tooltip("Random noise texture resolution (noise texture with random values will used if custom texture is not set)")]
		public int _noiseResolution = 512;

		[Header("Default volume overrides")]
		[Tooltip("Default palette")]
		public Texture2D _palette;

		[Tooltip("Default pattern dithering pattern")]
		public Texture2D _pattern;

		[Tooltip("Default screen noise mode")]
		public Mode _noiseMode = Mode.Noise;

		[Tooltip("Default pixelate state if not set in volume")]
		public bool _pixelate = true;

		[Range(0f, 1f)]
		[Tooltip("Default image scale")]
		public float _scale = 0.735f;

		[Tooltip("Default frame rate, dithering jitter")]
		[Range(0f, 120f)]
		public int _frameRate;

		private LutGenerator.LutSize _lutSize;

		private LutGenerator.Gamma _gamma;

		private int _frame;

		private Dictionary<Texture2D, PaletteCash> _paletteCash = new Dictionary<Texture2D, PaletteCash>();

		private Texture2D _noiseTex;

		private Vector4 _ditherMad;

		private Mode _noiseModePrev;

		private LutGenerator.LutSize _lutSizePrev;

		public override string ShaderName => string.Empty;

		protected override bool _editorValidate
		{
			get
			{
				if (!(_palette == null))
				{
					return _pattern == null;
				}
				return true;
			}
		}

		public override void Init()
		{
			_frame = 0;
			_paletteCash.Clear();
			_noiseModePrev = Mode.Dither;
		}

		public override bool Validate(Material mat)
		{
			DitherVol component = base.Stack.GetComponent<DitherVol>();
			if (!component.IsActive())
			{
				return false;
			}
			float num = (float)Screen.width / (float)Screen.height;
			int num2 = (component.m_Fps.overrideState ? component.m_Fps.value : _frameRate);
			int num3 = Mathf.FloorToInt(Time.unscaledTime / (1f / (float)num2));
			bool num4 = _frame != num3;
			if (num4)
			{
				_frame = num3;
			}
			bool flag = (component.m_Pixelate.overrideState ? component.m_Pixelate.value : _pixelate);
			if ((component.m_Scale.overrideState ? component.m_Scale.value : _scale) >= 1f)
			{
				flag = false;
			}
			_validatePix(flag);
			Mode mode = (component.m_Mode.overrideState ? component.m_Mode.value : _noiseMode);
			_validateMode(mode);
			Texture2D texture2D = (component.m_Palette.overrideState ? (component.m_Palette.value as Texture2D) : _palette);
			if (texture2D == null)
			{
				texture2D = _palette;
			}
			if (!_paletteCash.TryGetValue(texture2D, out var value))
			{
				value = LutGenerator.Generate(texture2D, _lutSize, _gamma);
				_paletteCash.Add(texture2D, value);
			}
			Texture2D palette = value._palette;
			Texture2D quant = value._quant;
			Texture2D measure = value._measure;
			Texture2D texture2D2 = (component.m_Pattern.overrideState ? (component.m_Pattern.value as Texture2D) : _pattern);
			if (texture2D2 == null)
			{
				texture2D2 = _pattern;
			}
			mat.SetVector(s_Data, new Vector4(component.m_Impact.value, component.m_Power.value));
			mat.SetTexture(s_PaletteTex, palette);
			mat.SetTexture(s_QuantTex, quant);
			mat.SetTexture(s_MeasureTex, measure);
			mat.SetTexture(s_DitherTex, texture2D2);
			float num5 = Mathf.Lerp(_scaleRange.x, _scaleRange.y, component.m_Scale.overrideState ? component.m_Scale.value : _scale);
			float num6 = texture2D2.width / texture2D2.height;
			_ditherMad.x = num5 * num;
			_ditherMad.y = num5;
			if (num4)
			{
				float num7 = (float)texture2D2.width / num6;
				if (mode == Mode.Noise)
				{
					_ditherMad.z = UnityEngine.Random.value;
					_ditherMad.w = UnityEngine.Random.value;
				}
				else
				{
					_ditherMad.z = Mathf.Round(UnityEngine.Random.value * num7) / num7;
					_ditherMad.w = Mathf.Round(UnityEngine.Random.value * num7) / num7;
				}
			}
			mat.SetVector(s_DitherMad, _ditherMad);
			mat.SetVector(s_PatternData, new Vector4(_ditherMad.x * ((float)texture2D2.width / num6), _ditherMad.y * (float)texture2D2.height, 1f / num6, num6));
			if (mode == Mode.Noise)
			{
				Texture texture = (component.m_Noise.overrideState ? component.m_Noise.value : null);
				if (texture != null)
				{
					mat.SetTexture(s_DitherTex, texture);
				}
				else
				{
					_validateNoise();
					mat.SetTexture(s_DitherTex, _noiseTex);
				}
				if (component.m_NoiseScale.overrideState)
				{
					float value2 = component.m_NoiseScale.value;
					mat.SetVector(s_DitherMad, new Vector4(value2, (float)Screen.width / (float)Screen.height * value2, _ditherMad.z, _ditherMad.w));
				}
				else
				{
					float value3 = component.m_NoiseScale.value;
					mat.SetVector(s_DitherMad, new Vector4(value3, value3, _ditherMad.z, _ditherMad.w));
				}
			}
			return true;
			void _validateMode(Mode mode2)
			{
				if (_noiseModePrev != mode2)
				{
					_noiseModePrev = mode2;
					_material.DisableKeyword("DITHER");
					_material.DisableKeyword("NOISE");
					switch (mode2)
					{
					case Mode.Dither:
						_material.EnableKeyword("DITHER");
						break;
					case Mode.Noise:
						_material.EnableKeyword("NOISE");
						break;
					default:
						throw new ArgumentOutOfRangeException("mode", mode2, null);
					}
				}
			}
			void _validateNoise()
			{
				float num8 = (float)Screen.width / (float)Screen.height;
				int num9 = Mathf.Max(Mathf.RoundToInt((float)_noiseResolution * num8), 4);
				int num10 = Mathf.Max(Mathf.RoundToInt(_noiseResolution), 4);
				if (_noiseTex == null || _noiseTex.width != num9 || _noiseTex.height != num10)
				{
					_noiseTex = new Texture2D(num9, num10);
					_noiseTex.filterMode = FilterMode.Point;
					_noiseTex.wrapMode = TextureWrapMode.Repeat;
					Color[] array = new Color[_noiseTex.width * _noiseTex.height];
					for (int i = 0; i < _noiseTex.width * _noiseTex.height; i++)
					{
						float num11 = (((double)UnityEngine.Random.value > 0.5) ? 1f : 0f);
						array[i] = new Color(num11, num11, num11, 1f);
					}
					_noiseTex.SetPixels(array);
					_noiseTex.Apply();
				}
			}
			void _validatePix(bool on)
			{
				if (_material.IsKeywordEnabled("PIXELATE") != on)
				{
					if (on)
					{
						_material.EnableKeyword("PIXELATE");
					}
					else
					{
						_material.DisableKeyword("PIXELATE");
					}
				}
			}
		}

		protected override void _editorSetup(string folder, string asset)
		{
		}
	}
}
