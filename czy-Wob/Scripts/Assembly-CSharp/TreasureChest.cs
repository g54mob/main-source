using UnityEngine;

public class TreasureChest : MonoBehaviour
{
	public Animator animationRef;

	public ParticleSystem particlesRef;

	private float bubblesDelayLow;

	private float bubblesDelayHigh = 5f;

	private bool isDelaying;

	private float currentTimer;

	private void Update()
	{
		if (isDelaying)
		{
			currentTimer -= Time.deltaTime;
			if (currentTimer <= 0f)
			{
				isDelaying = false;
				animationRef.enabled = true;
			}
		}
	}

	public void RequestBubbles()
	{
		particlesRef.Play();
	}

	public void BubblesEnd()
	{
		isDelaying = true;
		animationRef.enabled = false;
		currentTimer = Random.Range(bubblesDelayLow, bubblesDelayHigh);
	}
}
