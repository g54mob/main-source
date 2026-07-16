using UnityEngine;

public class RatTail : MonoBehaviour
{
	[SerializeField]
	private Animator Anim;

	[SerializeField]
	private float SpeedMultiplierMin = 0.7f;

	[SerializeField]
	private float SpeedMultiplierMax = 1.1f;

	private float timer;

	private bool done;

	private void Start()
	{
		Anim.speed = Random.Range(SpeedMultiplierMin, SpeedMultiplierMax);
		timer = Random.Range(0f, 1f);
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0f && !done)
		{
			done = true;
			GetComponent<Animator>().Play("RatTailWiggle");
		}
	}
}
