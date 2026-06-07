using UnityEngine;

public class PlayerSound : MonoBehaviour
{
	public Rigidbody2D rb;

	private SoundManager soundManager;

	private float elapsedWalkSeconds;

	public float stepDelay;

	public void Start()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	public void Update()
	{
		if (rb.velocity.magnitude > 0f)
		{
			WalkSound();
		}
		else
		{
			elapsedWalkSeconds = 0f;
		}
	}

	public void WalkSound()
	{
		if (elapsedWalkSeconds < stepDelay)
		{
			elapsedWalkSeconds += Time.deltaTime;
			return;
		}
		SoundManager.LoadSoundEffect(base.transform, soundManager.player_walk);
		elapsedWalkSeconds = 0f;
	}
}
