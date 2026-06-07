using System;
using UnityEngine;

public class AudioHumEffect : MonoBehaviour
{
	public int HumCycle = 60;

	[Range(0f, 0.001f)]
	public float HumAmount = 0.0001f;

	[Range(0f, 0.001f)]
	public float NoiseAmount;

	private float sampleRate = 48000f;

	private float phase;

	private System.Random rand = new System.Random();

	private void Start()
	{
		sampleRate = AudioSettings.outputSampleRate;
	}

	private void OnAudioFilterRead(float[] data, int channels)
	{
		float num = (float)HumCycle * (float)Math.PI / sampleRate;
		for (int i = 0; i < data.Length; i += channels)
		{
			phase += num;
			float num2 = Mathf.Sin(phase);
			num2 = ((!(num2 >= 0f)) ? (-1f) : 1f);
			num2 *= HumAmount;
			float num3 = (float)(rand.NextDouble() * 2.0 - 1.0);
			num3 *= NoiseAmount;
			for (int j = 0; j < channels; j++)
			{
				data[i + j] += num2 + num3;
			}
			if (phase > (float)Math.PI * 2f)
			{
				phase = 0f;
			}
		}
	}
}
