using UnityEngine;

public class SineScale : MonoBehaviour
{
	public float amp;

	public float freq;

	public bool doNoise;

	private float noise;

	public bool scaleOnX = true;

	public bool scaleOnY = true;

	public void Awake()
	{
		if (doNoise)
		{
			noise = Random.Range(0f, 1f);
		}
	}

	public void Update()
	{
		float x = base.transform.localScale.x;
		float y = base.transform.localScale.y;
		if (scaleOnX)
		{
			x = Sine(amp, freq) + 1f;
		}
		if (scaleOnY)
		{
			y = Sine(amp, freq) + 1f;
		}
		base.transform.localScale = new Vector3(x, y, base.transform.localScale.z);
	}

	private float Sine(float amplitude, float frequency)
	{
		return Mathf.Sin((Time.time + noise) * frequency) * amplitude;
	}
}
