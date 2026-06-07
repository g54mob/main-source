using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MusicVisualizer : Graphic
{
	[SerializeField]
	private int samples = 256;

	[SerializeField]
	[Min(0.001f)]
	private float lineThickness = 2f;

	[SerializeField]
	[Range(0f, 1f)]
	private float waveformAmplitude = 0.85f;

	[SerializeField]
	[Range(0f, 1f)]
	private float waveformSmoothing = 0.25f;

	[SerializeField]
	[Min(0.01f)]
	private float waveformGain = 6f;

	[SerializeField]
	[Range(0f, 1f)]
	private float waveformSoftClip = 0.65f;

	[SerializeField]
	[Min(1f)]
	private float refreshRate = 60f;

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
	private float beatPulseDecay = 3.5f;

	[SerializeField]
	[Min(0f)]
	private float beatMinInterval = 0.12f;

	[SerializeField]
	private bool beatAffectsColor = true;

	[SerializeField]
	[Range(0f, 2f)]
	private float beatBrightness = 0.6f;

	[SerializeField]
	[Range(0f, 1f)]
	private float beatTintStrength = 0.35f;

	[SerializeField]
	private Color beatTintColor = Color.white;

	private float[] _waveformBuffer;

	private float[] _smoothedWaveform;

	private float[] _spectrumBuffer;

	private float _beatEnergyAvg;

	private float _beatPulseValue;

	private float _beatCooldown;

	private Color _baseColor;

	private Color _lastAppliedColor;

	private readonly ReactiveProperty<float> _beatPulse = new ReactiveProperty<float>(0f);

	private MusicPlaylist _target;

	private CancellationToken _lifetimeToken;

	private bool _isInitialized;

	public void Initialize(MusicPlaylist target, CancellationToken lifetimeToken)
	{
		_target = target;
		_lifetimeToken = lifetimeToken;
		AllocateBuffersIfNeeded();
		if (!_isInitialized)
		{
			_isInitialized = true;
			RunLoopAsync(_lifetimeToken).Forget();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (!material)
		{
			material = Graphic.defaultGraphicMaterial;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		_baseColor = color;
		_lastAppliedColor = color;
		AllocateBuffersIfNeeded();
		SetVerticesDirty();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		ClearState();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (_smoothedWaveform == null || _smoothedWaveform.Length < 2)
		{
			return;
		}
		Rect rect = base.rectTransform.rect;
		if (!(rect.width <= 1f) && !(rect.height <= 1f))
		{
			float num = Mathf.Clamp01(_beatPulseValue);
			float num2 = waveformAmplitude * (1f + 0.2f * num);
			float num3 = rect.height * 0.5f;
			float num4 = rect.yMin + num3;
			float num5 = lineThickness * 0.5f;
			float num6 = rect.xMin + num5;
			float b = rect.xMax - num5;
			int num7 = _smoothedWaveform.Length;
			float num8 = 1f / (float)(num7 - 1);
			Vector2 a = new Vector2(num6, num4 + _smoothedWaveform[0] * num3 * num2);
			for (int i = 1; i < num7; i++)
			{
				float t = (float)i * num8;
				float x = Mathf.LerpUnclamped(num6, b, t);
				float y = num4 + _smoothedWaveform[i] * num3 * num2;
				Vector2 vector = new Vector2(x, y);
				AddLineSegment(vh, a, vector, lineThickness, color);
				a = vector;
			}
		}
	}

	private void AllocateBuffersIfNeeded()
	{
		int num = Mathf.Clamp(samples, 32, 2048);
		if (_waveformBuffer == null || _waveformBuffer.Length != num)
		{
			_waveformBuffer = new float[num];
			_smoothedWaveform = new float[num];
		}
		int num2 = (IsValidSpectrumSize(num) ? num : 512);
		if (_spectrumBuffer == null || _spectrumBuffer.Length != num2)
		{
			_spectrumBuffer = new float[num2];
		}
	}

	private async UniTaskVoid RunLoopAsync(CancellationToken token)
	{
		int refreshDelayMs = Mathf.Max(1, Mathf.RoundToInt(1000f / Mathf.Max(1f, refreshRate)));
		while (!token.IsCancellationRequested)
		{
			AllocateBuffersIfNeeded();
			SampleAudio();
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			_beatCooldown = Mathf.Max(0f, _beatCooldown - unscaledDeltaTime);
			_beatPulseValue = Mathf.MoveTowards(_beatPulseValue, 0f, beatPulseDecay * unscaledDeltaTime);
			_beatPulse.Value = _beatPulseValue;
			if (beatAffectsColor)
			{
				ApplyBeatColor(_beatPulseValue);
			}
			SetVerticesDirty();
			await UniTask.Delay(refreshDelayMs, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
		}
	}

	private void SampleAudio()
	{
		if (!_target.CurrentClip.CurrentValue || _target.IsPaused.CurrentValue)
		{
			DampWaveformToZero();
			return;
		}
		_target.GetOutputData(_waveformBuffer, 0);
		ApplyWaveformSmoothing();
		_target.GetSpectrumData(_spectrumBuffer, 0, FFTWindow.BlackmanHarris);
		UpdateBeatFromSpectrum();
	}

	private void ApplyWaveformSmoothing()
	{
		float num = Mathf.Clamp01(waveformSmoothing);
		float num2 = Mathf.Max(0.01f, waveformGain);
		float num3 = Mathf.Clamp01(waveformSoftClip);
		for (int i = 0; i < _waveformBuffer.Length; i++)
		{
			float num4 = Mathf.Clamp(_waveformBuffer[i], -1f, 1f);
			num4 *= num2;
			if (num3 > 0f)
			{
				num4 = Mathf.Lerp(num4, num4 / (1f + Mathf.Abs(num4)), num3);
			}
			num4 = Mathf.Clamp(num4, -1f, 1f);
			_smoothedWaveform[i] = Mathf.Lerp(_smoothedWaveform[i], num4, 1f - num);
		}
	}

	private void DampWaveformToZero()
	{
		float num = Mathf.Clamp01(waveformSmoothing);
		for (int i = 0; i < _smoothedWaveform.Length; i++)
		{
			_smoothedWaveform[i] = Mathf.Lerp(_smoothedWaveform[i], 0f, 1f - num);
		}
	}

	private void UpdateBeatFromSpectrum()
	{
		int num = Mathf.Clamp(beatLowBins, 1, Mathf.Min(beatLowBins, _spectrumBuffer.Length));
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			num2 += _spectrumBuffer[i];
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

	private void ApplyBeatColor(float pulse)
	{
		float num = Mathf.Clamp01(pulse);
		if (this.color != _lastAppliedColor && this.color != _baseColor)
		{
			_baseColor = this.color;
		}
		Color color = Color.Lerp(_baseColor, beatTintColor, beatTintStrength * num);
		float num2 = 1f + beatBrightness * num;
		color.r = Mathf.Clamp01(color.r * num2);
		color.g = Mathf.Clamp01(color.g * num2);
		color.b = Mathf.Clamp01(color.b * num2);
		if (!ApproximatelyEqualColor(color, _lastAppliedColor))
		{
			this.color = color;
			_lastAppliedColor = color;
			SetVerticesDirty();
		}
	}

	private void ClearState()
	{
		_beatEnergyAvg = 0f;
		_beatPulseValue = 0f;
		_beatCooldown = 0f;
		_beatPulse.Value = 0f;
		if (_smoothedWaveform != null)
		{
			Array.Clear(_smoothedWaveform, 0, _smoothedWaveform.Length);
		}
	}

	private static void AddLineSegment(VertexHelper vh, Vector2 a, Vector2 b, float thickness, Color32 col)
	{
		Vector2 vector = b - a;
		float magnitude = vector.magnitude;
		if (!(magnitude <= 0.0001f))
		{
			vector /= magnitude;
			Vector2 vector2 = new Vector2(0f - vector.y, vector.x);
			Vector2 vector3 = thickness * 0.5f * vector2;
			Vector2 vector4 = a - vector3;
			Vector2 vector5 = a + vector3;
			Vector2 vector6 = b + vector3;
			Vector2 vector7 = b - vector3;
			int currentVertCount = vh.currentVertCount;
			vh.AddVert(vector4, col, Vector2.zero);
			vh.AddVert(vector5, col, Vector2.zero);
			vh.AddVert(vector6, col, Vector2.zero);
			vh.AddVert(vector7, col, Vector2.zero);
			vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
			vh.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
		}
	}

	private static bool IsValidSpectrumSize(int n)
	{
		if (n != 64 && n != 128 && n != 256 && n != 512 && n != 1024 && n != 2048 && n != 4096)
		{
			return n == 8192;
		}
		return true;
	}

	private static bool ApproximatelyEqualColor(Color a, Color b)
	{
		if (Mathf.Abs(a.r - b.r) < 0.001f && Mathf.Abs(a.g - b.g) < 0.001f && Mathf.Abs(a.b - b.b) < 0.001f)
		{
			return Mathf.Abs(a.a - b.a) < 0.001f;
		}
		return false;
	}
}
