using UnityEngine;

public class AudioPauseEcho : MonoBehaviour
{
	private AudioEchoFilter echoFilter;

	private AudioLowPassFilter lowPassFilter;

	private AudioSource audioSource;

	private bool paused;

	private float filterVel;

	private const float filterLoF = 1000f;

	private const float filterHiF = 22000f;

	private void OnEnable()
	{
		if (echoFilter == null)
		{
			echoFilter = base.gameObject.AddComponent<AudioEchoFilter>();
			echoFilter.wetMix = 0f;
			echoFilter.dryMix = 1f;
			echoFilter.decayRatio = 0.7f;
			echoFilter.delay = 200f;
			lowPassFilter = base.gameObject.AddComponent<AudioLowPassFilter>();
			lowPassFilter.enabled = false;
			lowPassFilter.lowpassResonanceQ = 0f;
			audioSource = base.gameObject.GetComponent<AudioSource>();
		}
	}

	private void Update()
	{
		if (Clock.play.running)
		{
			if (!audioSource.isPlaying)
			{
				audioSource.UnPause();
				filterVel = 0f;
				return;
			}
			float deltaTime = Clock.play.deltaTime;
			echoFilter.wetMix = Mathf.Max(0f, echoFilter.wetMix - 2f * deltaTime);
			echoFilter.dryMix = Mathf.Min(1f, echoFilter.dryMix + 2f * deltaTime);
			if (lowPassFilter.enabled)
			{
				lowPassFilter.cutoffFrequency = Mathf.SmoothDamp(lowPassFilter.cutoffFrequency, 22000f, ref filterVel, 0.1f);
				if (lowPassFilter.cutoffFrequency >= 22000f)
				{
					lowPassFilter.enabled = false;
				}
			}
		}
		else if (!Clock.play.running)
		{
			if (audioSource.isPlaying)
			{
				audioSource.Pause();
				echoFilter.wetMix = 0.4f;
				echoFilter.dryMix = 0f;
				filterVel = 0f;
				lowPassFilter.cutoffFrequency = 22000f;
				lowPassFilter.enabled = true;
			}
			else
			{
				lowPassFilter.cutoffFrequency = Mathf.SmoothDamp(lowPassFilter.cutoffFrequency, 1000f, ref filterVel, 0.75f, float.MaxValue, Clock.active.deltaTime);
			}
		}
	}
}
