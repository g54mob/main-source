using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[CreateAssetMenu(fileName = "Waves", menuName = "Crest/Wave Spectrum", order = 10000)]
	public sealed class WaveSpectrum : CustomScriptableObject
	{
		internal enum SpectrumModel
		{
			None = 0,
			PiersonMoskowitz = 1
		}

		internal const int k_NumberOfOctaves = 14;

		internal const float k_SmallestWavelengthPower2 = -4f;

		internal static readonly float s_MinimumPowerLog = -8f;

		internal static readonly float s_MaximumPowerLog = 5f;

		[Tooltip("Multiplier which scales waves")]
		[SerializeField]
		internal float _Multiplier = 1f;

		[Tooltip("Scales horizontal displacement")]
		[SerializeField]
		internal float _Chop = 1.6f;

		[Tooltip("More gravity means faster waves.")]
		[SerializeField]
		internal float _GravityScale = 1f;

		[Tooltip("Variance of wave directions, in degrees.")]
		[SerializeField]
		[HideInInspector]
		internal float _WaveDirectionVariance = 90f;

		[SerializeField]
		[HideInInspector]
		internal float[] _PowerLogarithmicScales = new float[14]
		{
			-7.10794f, -6.42794f, -5.93794f, -5.27794f, -4.67794f, -3.71794f, -3.17794f, -2.60794f, -1.93794f, -1.11794f,
			-0.85794f, -0.36794f, 0.04206f, -8f
		};

		[SerializeField]
		[HideInInspector]
		internal bool[] _PowerDisabled = new bool[14];

		[SerializeField]
		[HideInInspector]
		internal float[] _ChopScales = new float[14]
		{
			1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,
			1f, 1f, 1f, 1f
		};

		[SerializeField]
		[HideInInspector]
		internal float[] _GravityScales = new float[14]
		{
			1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,
			1f, 1f, 1f, 1f
		};

		[SerializeField]
		[HideInInspector]
		internal float[] _Attenuation = new float[14]
		{
			1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,
			1f, 1f, 1f, 1f
		};

		[SerializeField]
		[HideInInspector]
		internal bool _ShowAdvancedControls;

		[SerializeField]
		[HideInInspector]
		internal SpectrumModel _Model;

		internal float[] _PowerLinearScales = new float[14];

		[NonSerialized]
		internal Texture2D _ControlsTexture;

		[NonSerialized]
		private readonly Color[] _ScratchData = new Color[14];

		internal Texture2D ControlsTexture
		{
			get
			{
				if (_ControlsTexture == null)
				{
					_ControlsTexture = new Texture2D(14, 1, TextureFormat.RFloat, mipChain: false, linear: true);
					InitializeHandControls();
				}
				return _ControlsTexture;
			}
		}

		internal static float SmallWavelength(float octaveIndex)
		{
			return Mathf.Pow(2f, -4f + octaveIndex);
		}

		private static int GetOctaveIndex(float wavelength)
		{
			return (int)(Mathf.Log(wavelength) / Mathf.Log(2f) - -4f);
		}

		internal float GetAmplitude(float wavelength, float componentsPerOctave, float windSpeed, float gravity, out float power)
		{
			float value = Mathf.Log(wavelength) / Mathf.Log(2f);
			value = Mathf.Clamp(value, -4f, 9f);
			float num = Mathf.Pow(2f, Mathf.Floor(value));
			int num2 = (int)(value - -4f);
			if (_PowerLogarithmicScales.Length < 14 || _PowerDisabled.Length < 14)
			{
				Debug.LogWarning("Crest: Wave spectrum " + base.name + " is out of date, please open this asset and resave in editor.", this);
			}
			if (num2 >= _PowerLogarithmicScales.Length || num2 >= _PowerDisabled.Length)
			{
				power = 0f;
				return 0f;
			}
			float num3 = ((!_PowerDisabled[num2]) ? _PowerLogarithmicScales[num2] : s_MinimumPowerLog);
			int num4 = num2 + 1;
			bool flag = num4 < _PowerLogarithmicScales.Length;
			float b = ((flag && !_PowerDisabled[num4]) ? _PowerLogarithmicScales[num4] : s_MinimumPowerLog);
			gravity *= _GravityScale;
			float num5 = Mathf.Pow(2f, Mathf.Floor(value));
			float num6 = MathF.PI * 2f / num5;
			float num7 = ComputeWaveSpeed(num5, gravity);
			float num8 = num6 * num7;
			float num9 = 2f * num5;
			float num10 = MathF.PI * 2f / num9;
			float num11 = ComputeWaveSpeed(num9, gravity);
			float num12 = num10 * num11;
			float num13 = (num8 - num12) / componentsPerOctave;
			float t = (wavelength - num) / num;
			power = (flag ? Mathf.Lerp(num3, b, t) : num3);
			power = Mathf.Pow(10f, power);
			if (gravity <= 0f)
			{
				return 0f;
			}
			float num14 = 1.291f;
			float num15 = 0.87f * gravity / windSpeed;
			DeepDispersion(MathF.PI * 2f / wavelength, gravity, out var w);
			power *= Mathf.Exp((0f - num14) * Mathf.Pow(num15 / w, 4f));
			return Mathf.Sqrt(2f * power * num13) * 5f * _Multiplier;
		}

		private static float ComputeWaveSpeed(float wavelength, float gravity, float gravityMultiplier = 1f)
		{
			float num = gravity * gravityMultiplier;
			float num2 = MathF.PI * 2f / wavelength;
			return Mathf.Sqrt(num / num2);
		}

		internal void GenerateWaveData(int componentsPerOctave, ref float[] wavelengths, ref float[] anglesDeg)
		{
			int num = 14 * componentsPerOctave;
			if (wavelengths == null || wavelengths.Length != num)
			{
				wavelengths = new float[num];
			}
			if (anglesDeg == null || anglesDeg.Length != num)
			{
				anglesDeg = new float[num];
			}
			float num2 = Mathf.Pow(2f, -4f);
			float num3 = 1f / (float)componentsPerOctave;
			for (int i = 0; i < 14; i++)
			{
				for (int j = 0; j < componentsPerOctave; j++)
				{
					int num4 = i * componentsPerOctave + j;
					float num5 = num2 + num3 * num2 * (float)j;
					float b = Mathf.Min(num5 + num3 * num2, 2f * num2);
					wavelengths[num4] = Mathf.Lerp(num5, b, UnityEngine.Random.value);
					float num6 = ((float)j + UnityEngine.Random.value) * num3;
					anglesDeg[num4] = (2f * num6 - 1f) * _WaveDirectionVariance;
				}
				num2 *= 2f;
			}
		}

		internal void ApplyPiersonMoskowitzSpectrum(float gravity)
		{
			for (int i = 0; i < 14; i++)
			{
				float wavelength = SmallWavelength(i);
				float a = PiersonMoskowitzSpectrum(gravity, wavelength);
				a = Mathf.Max(a, Mathf.Pow(10f, s_MinimumPowerLog));
				_PowerLinearScales[i] = a;
				_PowerLogarithmicScales[i] = Mathf.Log10(a);
			}
		}

		private static float AlphaSpectrum(float a, float g, float w)
		{
			return a * g * g / Mathf.Pow(w, 5f);
		}

		private static void DeepDispersion(float k, float gravity, out float w)
		{
			w = Mathf.Sqrt(gravity * k);
		}

		private static float PiersonMoskowitzSpectrum(float gravity, float wavelength)
		{
			DeepDispersion(MathF.PI * 2f / wavelength, gravity, out var w);
			return AlphaSpectrum(0.0081f, gravity, w);
		}

		private void OnDestroy()
		{
			Helpers.Destroy(_ControlsTexture);
			_ControlsTexture = null;
		}

		internal void InitializeHandControls()
		{
			for (int i = 0; i < 14; i++)
			{
				float num = (_PowerDisabled[i] ? 0f : Mathf.Pow(10f, _PowerLogarithmicScales[i]));
				num *= _Multiplier * _Multiplier;
				_PowerLinearScales[i] = num;
				_ScratchData[i] = num * Color.white;
			}
			ControlsTexture.SetPixels(_ScratchData);
			ControlsTexture.Apply();
		}

		internal void OnChange(string path, object previous)
		{
			InitializeHandControls();
		}

		internal void OnGUI()
		{
			if (ControlsTexture != null)
			{
				GUI.DrawTexture(new Rect(0f, 0f, 100f, 10f), ControlsTexture);
			}
		}
	}
}
