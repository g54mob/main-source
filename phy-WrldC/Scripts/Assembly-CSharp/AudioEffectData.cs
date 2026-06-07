using UnityEngine;

public class AudioEffectData
{
	public enum Loudness
	{
		VeryLow = 0,
		Low = 1,
		Medium = 2,
		High = 3,
		VeryHigh = 4
	}

	public AudioClip AudioClip { get; set; }

	public float Volume { get; set; }

	public float Pitch { get; set; }

	public Loudness LoudnessIntensity { get; set; }

	public int Priority { get; set; }

	public AudioEffectData()
	{
		Volume = 1f;
		Pitch = 1f;
		LoudnessIntensity = Loudness.Medium;
		Priority = 128;
	}
}
