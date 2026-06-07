using UnityEngine;

public class InteriorSoundscapeScript : MonoBehaviour
{
	public Vector2 MyTime;

	private float MyTimer;

	private float MyGoal;

	private AudioSource MyAud;

	private void Start()
	{
		MyAud = GetComponent<AudioSource>();
		SetGoal();
	}

	private void Update()
	{
		if (!MyAud.isPlaying)
		{
			MyTimer += Time.deltaTime;
			if (MyTimer >= MyGoal)
			{
				PlaySound();
				SetGoal();
			}
		}
	}

	private void SetGoal()
	{
		MyGoal = Random.Range(MyTime.x, MyTime.y);
		MyTimer = 0f;
	}

	private void PlaySound()
	{
		MyAud.Play();
	}
}
