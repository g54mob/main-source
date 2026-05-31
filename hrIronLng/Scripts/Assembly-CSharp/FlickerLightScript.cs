using UnityEngine;

public class FlickerLightScript : MonoBehaviour
{
	public float FlickerTime;

	public Vector2 FlickerRange;

	private float FlickerTimer;

	private Light MyLight;

	public bool VaryTime;

	public bool PlaySound = true;

	private AudioSource aud;

	private void Start()
	{
		MyLight = GetComponent<Light>();
		aud = GetComponent<AudioSource>();
	}

	private void Update()
	{
		FlickerTimer -= Time.deltaTime;
		if (FlickerTimer <= 0f)
		{
			FlickerTimer = FlickerTime;
			if (VaryTime)
			{
				FlickerTimer = Random.Range(0f, FlickerTimer);
			}
			MyLight.intensity = Random.Range(FlickerRange.x, FlickerRange.y);
			if (PlaySound)
			{
				aud.Play();
			}
		}
	}
}
