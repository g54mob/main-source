using UnityEngine;

public class FireManagerScript : MonoBehaviour
{
	public FireScript[] Fires;

	private float Intensity;

	public bool GrowFire;

	public float GrowFireSpeed;

	private int CurrentIndex;

	public float ExtinguishSpeed;

	public AudioSource FireSound;

	private void Start()
	{
		Intensity = 0f;
	}

	private void Update()
	{
		if (GrowFire)
		{
			Intensity += Time.deltaTime * GrowFireSpeed;
			if (Intensity >= 1f)
			{
				Intensity = 0f;
				CurrentIndex++;
			}
			if (CurrentIndex < Fires.Length)
			{
				Fires[CurrentIndex].SetIntensity(Intensity);
			}
		}
	}

	private void FixedUpdate()
	{
		float num = 0f;
		for (int i = 0; i < Fires.Length; i++)
		{
			num += Fires[i].MyIntensity;
			FireSound.volume = num / (float)Fires.Length;
		}
	}
}
