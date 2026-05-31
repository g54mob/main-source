using UnityEngine;

public class f2 : MonoBehaviour
{
	public GameObject fl;

	public AudioSource golos;

	public AudioSource heart;

	public float timer;

	public float rand;

	public float timer2;

	public float rand2;

	private void Update()
	{
		if (fl.GetComponent<Light>().enabled)
		{
			golos.volume = 0f;
		}
		else
		{
			golos.volume = 1f;
		}
		timer += Time.deltaTime;
		timer2 += Time.deltaTime;
		if (timer > rand)
		{
			if (!heart.isPlaying)
			{
				heart.Play();
			}
			if (timer > rand + 3f)
			{
				timer = 0f;
				heart.Pause();
				rand = Random.Range(15, 45);
			}
		}
		if (timer2 > rand2)
		{
			timer2 = 0f;
			fl.GetComponent<fl>().F();
			rand2 = Random.Range(30, 180);
		}
	}
}
