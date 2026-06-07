using System.Collections;
using DV;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

public class PullerAudio : MonoBehaviour
{
	private const float HIT_TOLERANCE_PERCENTAGE = 0.01f;

	public AudioClip dragClip;

	public AudioClip hitClip;

	public AudioClip notchClip;

	public float muteAfterStart = 0.5f;

	private Rigidbody rb;

	private PullerBase puller;

	private SteppedPuller steppedPuller;

	private AudioSource dragSound;

	private AudioSource hitSound;

	private AudioSource notchSound;

	private bool muted = true;

	private bool justPlayedHit;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		puller = GetComponentInParent<PullerBase>();
		if (rb == null)
		{
			Debug.LogError("PullerAudio's rigidbody is null", this);
		}
		if (notchClip != null)
		{
			if (!SingletonBehaviour<AudioManager>.Instance)
			{
				Debug.LogWarning("PullerAudio couldn't find an AudioManager instance, removing itself", base.gameObject);
				Object.Destroy(this);
				return;
			}
			steppedPuller = puller.GetComponent<SteppedPuller>();
			if ((bool)steppedPuller)
			{
				notchSound = NAudio.CreateSource(base.transform, notchClip, 1f, 1f, loop: false).source;
				steppedPuller.PositionChanged += PlayNotchSound;
			}
		}
		dragSound = NAudio.CreateSource(base.transform, dragClip, 0f).source;
		hitSound = NAudio.CreateSource(base.transform, hitClip, 0f, 1f, loop: false).source;
		muted = true;
		StartCoroutine(Unmute(muteAfterStart));
	}

	private void OnDestroy()
	{
		if ((bool)steppedPuller)
		{
			steppedPuller.PositionChanged -= PlayNotchSound;
		}
	}

	private IEnumerator Unmute(float timeout)
	{
		yield return WaitFor.Seconds(timeout);
		muted = false;
	}

	private void Update()
	{
		if (muted || !TimeUtil.IsFlowing)
		{
			hitSound.Stop();
			dragSound.Stop();
			if ((bool)notchSound)
			{
				notchSound.Stop();
			}
			return;
		}
		float sqrMagnitude = rb.velocity.sqrMagnitude;
		if (Mathf.Approximately(sqrMagnitude, 0f) && dragSound.isPlaying)
		{
			dragSound.Stop();
		}
		else if (!Mathf.Approximately(sqrMagnitude, 0f) && !dragSound.isPlaying)
		{
			dragSound.Play();
		}
		if (dragSound.isPlaying)
		{
			dragSound.volume = rb.velocity.sqrMagnitude * 10f;
		}
		if (!justPlayedHit && (puller.GetNormalizedPosition() >= 0.99f || puller.GetNormalizedPosition() <= 0.01f))
		{
			hitSound.volume = rb.velocity.sqrMagnitude * 10f;
			hitSound.Play();
			justPlayedHit = true;
		}
		if (justPlayedHit && puller.GetNormalizedPosition() < 0.99f && puller.GetNormalizedPosition() > 0.01f)
		{
			justPlayedHit = false;
		}
	}

	private void PlayNotchSound(ValueChangedEventArgs _)
	{
		if ((bool)notchSound)
		{
			notchSound.Play();
		}
	}
}
