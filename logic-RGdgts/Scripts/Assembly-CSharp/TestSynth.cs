using UnityEngine;

public class TestSynth : MonoBehaviour
{
	public enum WaveType
	{
		Sin = 0,
		Square = 1,
		Triangle = 2
	}

	public double frequency;

	public double gain;

	private double increment;

	private double phase;

	private double sampling_frequency;

	public WaveType waveType;

	private void OnAudioFilterRead(float[] data, int channels)
	{
	}
}
