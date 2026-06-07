using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Image))]
public class MilkdropVisualizer : MonoBehaviour
{
	private const int SpectrumSize = 256;

	private const int WaveformSize = 256;

	private const int BassMaxBin = 8;

	private const int MidMinBin = 8;

	private const int MidMaxBin = 64;

	private const int HighMinBin = 64;

	private const int HighMaxBin = 256;

	private static readonly int TimeCustomId = Shader.PropertyToID("_Time_Custom");

	private static readonly int BeatPulseId = Shader.PropertyToID("_BeatPulse");

	private static readonly int BassEnergyId = Shader.PropertyToID("_BassEnergy");

	private static readonly int MidEnergyId = Shader.PropertyToID("_MidEnergy");

	private static readonly int HighEnergyId = Shader.PropertyToID("_HighEnergy");

	private static readonly int SpectrumTexId = Shader.PropertyToID("_SpectrumTex");

	private static readonly int WaveformTexId = Shader.PropertyToID("_WaveformTex");

	[SerializeField]
	[Min(1f)]
	private float refreshRate = 30f;

	[SerializeField]
	[Range(0.5f, 0.99f)]
	private float spectrumSmoothing = 0.82f;

	[SerializeField]
	[Range(0.1f, 0.95f)]
	private float waveformSmoothing = 0.55f;

	[SerializeField]
	[Range(0.5f, 0.99f)]
	private float energySmoothing = 0.88f;

	[SerializeField]
	[Range(1f, 32f)]
	private int beatLowBins = 8;

	[SerializeField]
	[Range(0.01f, 0.99f)]
	private float beatEnergyEma = 0.85f;

	[SerializeField]
	[Range(1.05f, 3f)]
	private float beatThresholdMultiplier = 1.35f;

	[SerializeField]
	[Min(0.01f)]
	private float beatPulseDecay = 2.5f;

	[SerializeField]
	[Min(0f)]
	private float beatMinInterval = 0.15f;

	private float[] _spectrumBuffer;

	private float[] _waveformBuffer;

	private float[] _smoothedSpectrum;

	private float[] _smoothedWaveform;

	private Texture2D _spectrumTex;

	private Texture2D _waveformTex;

	private Color[] _spectrumPixels;

	private Color[] _waveformPixels;

	private Material _instanceMaterial;

	private Image _image;

	private float _time;

	private float _beatEnergyAvg;

	private float _beatPulseValue;

	private float _beatCooldown;

	private float _smoothBass;

	private float _smoothMid;

	private float _smoothHigh;

	private MusicPlaylist _target;

	private bool _isInitialized;

	public void Initialize(MusicPlaylist target, CancellationToken lifetimeToken)
	{
		_target = target;
		if (!_isInitialized)
		{
			_isInitialized = true;
			SetupResources();
			RunLoopAsync(lifetimeToken).Forget();
		}
	}

	private void OnDestroy()
	{
		if (_instanceMaterial != null)
		{
			Object.Destroy(_instanceMaterial);
			_instanceMaterial = null;
		}
		if (_spectrumTex != null)
		{
			Object.Destroy(_spectrumTex);
			_spectrumTex = null;
		}
		if (_waveformTex != null)
		{
			Object.Destroy(_waveformTex);
			_waveformTex = null;
		}
	}

	private void SetupResources()
	{
		_image = GetComponent<Image>();
		_spectrumBuffer = new float[256];
		_waveformBuffer = new float[256];
		_smoothedSpectrum = new float[256];
		_smoothedWaveform = new float[256];
		_spectrumPixels = new Color[256];
		_waveformPixels = new Color[256];
		for (int i = 0; i < 256; i++)
		{
			_smoothedWaveform[i] = 0.5f;
		}
		_spectrumTex = new Texture2D(256, 1, TextureFormat.RFloat, mipChain: false)
		{
			wrapMode = TextureWrapMode.Clamp,
			filterMode = FilterMode.Bilinear
		};
		_waveformTex = new Texture2D(256, 1, TextureFormat.RFloat, mipChain: false)
		{
			wrapMode = TextureWrapMode.Clamp,
			filterMode = FilterMode.Bilinear
		};
		if (_image.material != null)
		{
			_instanceMaterial = new Material(_image.material);
			_image.material = _instanceMaterial;
		}
		_instanceMaterial.SetTexture(SpectrumTexId, _spectrumTex);
		_instanceMaterial.SetTexture(WaveformTexId, _waveformTex);
	}

	private async UniTaskVoid RunLoopAsync(CancellationToken token)
	{
		int refreshDelayMs = Mathf.Max(1, Mathf.RoundToInt(1000f / Mathf.Max(1f, refreshRate)));
		while (!token.IsCancellationRequested && !(_instanceMaterial == null))
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			_time += unscaledDeltaTime;
			SampleAudio();
			_beatCooldown = Mathf.Max(0f, _beatCooldown - unscaledDeltaTime);
			_beatPulseValue = Mathf.MoveTowards(_beatPulseValue, 0f, beatPulseDecay * unscaledDeltaTime);
			UpdateMaterial();
			await UniTask.Delay(refreshDelayMs, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
		}
	}

	private void SampleAudio()
	{
		if (_target != null)
		{
			if (!_target.CurrentClip.CurrentValue || _target.IsPaused.CurrentValue)
			{
				DampBuffersToZero();
				return;
			}
			_target.GetSpectrumData(_spectrumBuffer, 0, FFTWindow.BlackmanHarris);
			_target.GetOutputData(_waveformBuffer, 0);
			SmoothAndUploadSpectrum();
			SmoothAndUploadWaveform();
			UpdateBeatFromSpectrum();
		}
	}

	private void SmoothAndUploadSpectrum()
	{
		float t = Mathf.Clamp01(spectrumSmoothing);
		for (int i = 0; i < 256; i++)
		{
			_smoothedSpectrum[i] = Mathf.Lerp(_spectrumBuffer[i], _smoothedSpectrum[i], t);
			_spectrumPixels[i] = new Color(_smoothedSpectrum[i], 0f, 0f, 1f);
		}
		_spectrumTex.SetPixels(_spectrumPixels);
		_spectrumTex.Apply(updateMipmaps: false);
	}

	private void SmoothAndUploadWaveform()
	{
		float t = Mathf.Clamp01(waveformSmoothing);
		for (int i = 0; i < 256; i++)
		{
			float a = _waveformBuffer[i] * 0.5f + 0.5f;
			_smoothedWaveform[i] = Mathf.Lerp(a, _smoothedWaveform[i], t);
			_waveformPixels[i] = new Color(_smoothedWaveform[i], 0f, 0f, 1f);
		}
		_waveformTex.SetPixels(_waveformPixels);
		_waveformTex.Apply(updateMipmaps: false);
	}

	private void UpdateBeatFromSpectrum()
	{
		int num = Mathf.Clamp(beatLowBins, 1, Mathf.Min(beatLowBins, _smoothedSpectrum.Length));
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			num2 += _smoothedSpectrum[i];
		}
		num2 /= (float)num;
		float t = Mathf.Clamp01(beatEnergyEma);
		_beatEnergyAvg = Mathf.Lerp(num2, _beatEnergyAvg, t);
		float num3 = Mathf.Max(1E-06f, _beatEnergyAvg);
		if (!(_beatCooldown > 0f) && !(num2 <= num3 * beatThresholdMultiplier))
		{
			float num4 = Mathf.Clamp01((num2 / num3 - beatThresholdMultiplier) / beatThresholdMultiplier);
			_beatPulseValue = Mathf.Max(_beatPulseValue, 0.5f + 0.5f * num4);
			_beatCooldown = beatMinInterval;
		}
	}

	private void UpdateMaterial()
	{
		_instanceMaterial.SetFloat(TimeCustomId, _time);
		_instanceMaterial.SetFloat(BeatPulseId, _beatPulseValue);
		float a = ComputeBandEnergy(0, 8);
		float a2 = ComputeBandEnergy(8, 64);
		float a3 = ComputeBandEnergy(64, 256);
		float t = Mathf.Clamp01(energySmoothing);
		_smoothBass = Mathf.Lerp(a, _smoothBass, t);
		_smoothMid = Mathf.Lerp(a2, _smoothMid, t);
		_smoothHigh = Mathf.Lerp(a3, _smoothHigh, t);
		_instanceMaterial.SetFloat(BassEnergyId, _smoothBass);
		_instanceMaterial.SetFloat(MidEnergyId, _smoothMid);
		_instanceMaterial.SetFloat(HighEnergyId, _smoothHigh);
	}

	private float ComputeBandEnergy(int from, int to)
	{
		if (_smoothedSpectrum == null)
		{
			return 0f;
		}
		to = Mathf.Min(to, _smoothedSpectrum.Length);
		if (from >= to)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = from; i < to; i++)
		{
			num += _smoothedSpectrum[i];
		}
		return num / (float)(to - from);
	}

	private void DampBuffersToZero()
	{
		for (int i = 0; i < 256; i++)
		{
			_smoothedSpectrum[i] *= 0.92f;
			_spectrumPixels[i] = new Color(_smoothedSpectrum[i], 0f, 0f, 1f);
		}
		for (int j = 0; j < 256; j++)
		{
			_smoothedWaveform[j] = Mathf.Lerp(_smoothedWaveform[j], 0.5f, 0.07999998f);
			_waveformPixels[j] = new Color(_smoothedWaveform[j], 0f, 0f, 1f);
		}
		_spectrumTex.SetPixels(_spectrumPixels);
		_spectrumTex.Apply(updateMipmaps: false);
		_waveformTex.SetPixels(_waveformPixels);
		_waveformTex.Apply(updateMipmaps: false);
	}
}
