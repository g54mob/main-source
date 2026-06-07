using UnityEngine;

public class FireFlicker : MonoBehaviour
{
	private Light flameflicker;

	private float countdown;

	public float rangeMin;

	public float rangeMax;

	public float timer;

	public float intensityMin;

	public float intensityMax;

	private void Start()
	{
		flameflicker = GetComponent<Light>();
	}

	private void Update()
	{
		if (countdown <= 0f)
		{
			countdown = timer;
			float intensity = Random.Range(intensityMin, intensityMax);
			float range = Random.Range(rangeMin, rangeMax);
			flameflicker.intensity = intensity;
			flameflicker.range = range;
		}
		else
		{
			countdown -= Time.deltaTime;
		}
	}
}
