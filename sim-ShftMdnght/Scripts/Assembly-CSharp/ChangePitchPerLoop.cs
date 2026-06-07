using UnityEngine;

public class ChangePitchPerLoop : MonoBehaviour
{
	public AudioSource audio;

	public float maxPitch;

	public float minPitch;

	public bool dontLoop;

	private bool justStopPlaying;

	public bool changePitchAtStart;

	private void OnEnable()
	{
		if (audio == null)
		{
			audio = GetComponent<AudioSource>();
		}
		if (changePitchAtStart)
		{
			audio.pitch = Random.Range(minPitch, maxPitch);
		}
	}

	public void ForceChangePitch()
	{
		audio.pitch = Random.Range(minPitch, maxPitch);
	}

	private void FixedUpdate()
	{
		if (!audio.isPlaying)
		{
			if (justStopPlaying)
			{
				audio.pitch = Random.Range(minPitch, maxPitch);
				if (!dontLoop)
				{
					audio.Play();
				}
				justStopPlaying = false;
			}
		}
		else
		{
			justStopPlaying = true;
		}
	}
}
