using System;
using System.Collections;
using UnityEngine;

public class VoiceRecorder : MonoBehaviour
{
	private const int SAMPLE_RATE_HZ = 44100;

	private const float SILENCE_THRESHOLD = 0.02f;

	private const float PAD_SECONDS = 0.1f;

	private const float VOLUME_BOOST = 2f;

	private const float MAX_RECORD_SECOND = 3f;

	private bool _isRecording;

	private string _deviceName;

	private AudioClip _recordedClip;

	private int _meterWindowFrames = 256;

	private float _meterGain = 12f;

	private float _meterSmooth = 20f;

	private float _meterLevel;

	private float[] _meterBuffer;

	public event Action<AudioClip> OnRecordingEnd;

	public event Action<float> OnLevelChanged;

	public void StartRecording()
	{
		if (_isRecording)
		{
			return;
		}
		if (Microphone.devices == null || Microphone.devices.Length == 0)
		{
			Debug.LogWarning("마이크 장치가 없습니다.");
			return;
		}
		_deviceName = Microphone.devices[0];
		_recordedClip = Microphone.Start(_deviceName, loop: false, Mathf.CeilToInt(3f), 44100);
		if (_recordedClip == null)
		{
			Debug.Log("녹음을 시작할 수 없습니다.");
			return;
		}
		_meterLevel = 0f;
		_meterBuffer = null;
		_isRecording = true;
		Debug.Log("녹음이 시작되었습니다.");
		StartCoroutine(AutoStopRecording());
		StartCoroutine(MeterRoutine());
	}

	private IEnumerator AutoStopRecording()
	{
		yield return new WaitForSeconds(3f);
		if (_isRecording)
		{
			EndRecording();
		}
	}

	public void EndRecording()
	{
		int num = Microphone.GetPosition(_deviceName);
		if (num < 0)
		{
			num = 0;
		}
		Microphone.End(_deviceName);
		_isRecording = false;
		Debug.Log("녹음이 종료되었습니다.");
		AudioClip obj = TrimSilence(_recordedClip, num, 0.02f, 0.1f);
		this.OnRecordingEnd?.Invoke(obj);
		_meterLevel = 0f;
		this.OnLevelChanged?.Invoke(0f);
	}

	private AudioClip TrimSilence(AudioClip src, int recordedFrames, float threshold, float padSec)
	{
		if (src == null || recordedFrames <= 0)
		{
			return src;
		}
		int channels = src.channels;
		int frequency = src.frequency;
		int num = recordedFrames * channels;
		float[] array = new float[num];
		src.GetData(array, 0);
		int i;
		for (i = 0; i < num && Mathf.Abs(array[i]) < threshold; i++)
		{
		}
		int num2 = num - 1;
		while (num2 > i && Mathf.Abs(array[num2]) < threshold)
		{
			num2--;
		}
		if (i >= num2)
		{
			int num3 = Mathf.Min(Mathf.FloorToInt(0.2f * (float)frequency), recordedFrames);
			int num4 = num3 * channels;
			float[] array2 = new float[num4];
			Array.Copy(array, 0, array2, 0, num4);
			AudioClip audioClip = AudioClip.Create("Voice_Trimmed_Silent", num3, channels, frequency, stream: false);
			audioClip.SetData(array2, 0);
			return audioClip;
		}
		int num5 = Mathf.FloorToInt(padSec * (float)frequency) * channels;
		i = Mathf.Max(0, i - num5);
		num2 = Mathf.Min(num - 1, num2 + num5);
		int num6 = num2 - i + 1;
		int lengthSamples = num6 / channels;
		float[] array3 = new float[num6];
		Array.Copy(array, i, array3, 0, num6);
		for (int j = 0; j < num6; j++)
		{
			array3[j] *= 2f;
		}
		AudioClip audioClip2 = AudioClip.Create("Voice_Trimmed", lengthSamples, channels, frequency, stream: false);
		audioClip2.SetData(array3, 0);
		return ApplyFadeInOut(audioClip2, 8f, 8f);
	}

	private IEnumerator MeterRoutine()
	{
		while (_isRecording && _recordedClip != null)
		{
			int channels = _recordedClip.channels;
			int position = Microphone.GetPosition(_deviceName);
			if (position > _meterWindowFrames)
			{
				int offsetSamples = position - _meterWindowFrames;
				int num = _meterWindowFrames * channels;
				if (_meterBuffer == null || _meterBuffer.Length != num)
				{
					_meterBuffer = new float[num];
				}
				_recordedClip.GetData(_meterBuffer, offsetSamples);
				double num2 = 0.0;
				for (int i = 0; i < num; i++)
				{
					num2 += (double)(_meterBuffer[i] * _meterBuffer[i]);
				}
				float b = Mathf.Clamp01(Mathf.Sqrt((float)(num2 / (double)num)) * _meterGain);
				_meterLevel = Mathf.Lerp(_meterLevel, b, Time.deltaTime * _meterSmooth);
				this.OnLevelChanged?.Invoke(_meterLevel);
			}
			yield return null;
		}
	}

	private AudioClip ApplyFadeInOut(AudioClip src, float fadeInMs = 100f, float fadeOutMs = 100f)
	{
		if (src == null)
		{
			return null;
		}
		int channels = src.channels;
		int frequency = src.frequency;
		int samples = src.samples;
		float[] array = new float[samples * channels];
		src.GetData(array, 0);
		int num = Mathf.Clamp(Mathf.RoundToInt(fadeInMs * 0.001f * (float)frequency) * channels, 0, array.Length);
		int num2 = Mathf.Clamp(Mathf.RoundToInt(fadeOutMs * 0.001f * (float)frequency) * channels, 0, array.Length);
		for (int i = 0; i < num; i++)
		{
			float num3 = (float)i / (float)Mathf.Max(1, num);
			array[i] *= num3;
		}
		for (int j = 0; j < num2; j++)
		{
			int num4 = array.Length - 1 - j;
			float num5 = (float)j / (float)Mathf.Max(1, num2);
			array[num4] *= 1f - num5;
		}
		AudioClip audioClip = AudioClip.Create(src.name + "_faded", samples, channels, frequency, stream: false);
		audioClip.SetData(array, 0);
		return audioClip;
	}
}
