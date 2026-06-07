using UnityEngine;

public class SineMovement : MonoBehaviour
{
	public float amp;

	public float freq;

	public bool doNoise;

	private float noise;

	public void Awake()
	{
		if (doNoise)
		{
			noise = Random.Range(0f, 1f);
		}
	}

	public void Update()
	{
		base.transform.localPosition = new Vector3(0f, Sine(amp, freq), 0f);
	}

	private float Sine(float amplitude, float frequency)
	{
		return Mathf.Sin((Time.time + noise) * frequency) * amplitude;
	}
}
