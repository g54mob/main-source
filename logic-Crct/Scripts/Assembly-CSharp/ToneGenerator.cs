using UnityEngine;

public class ToneGenerator : MonoBehaviour
{
	[Range(1f, 20000f)]
	public float frequency1;

	[Range(1f, 20000f)]
	public float frequency2;

	public float sampleRate;

	public float waveLengthInSeconds;

	private AudioSource audioSource;

	private int timeIndex;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnAudioFilterRead(float[] data, int channels)
	{
	}

	public float CreateSine(int timeIndex, float frequency, float sampleRate)
	{
		return 0f;
	}

	public float CreateSquare(int timeIndex, float frequency, float sampleRate)
	{
		return 0f;
	}
}
