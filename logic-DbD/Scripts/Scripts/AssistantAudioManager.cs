using System.Collections;
using UnityEngine;

public class AssistantAudioManager : MonoBehaviour
{
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip oh;

	[SerializeField]
	private AudioClip hello;

	[SerializeField]
	private AudioClip thinking;

	[SerializeField]
	private AudioClip hey;

	[SerializeField]
	private AudioClip pop;

	[SerializeField]
	private AudioClip woosh;

	[SerializeField]
	private AudioClip swish;

	[SerializeField]
	private AudioClip yeah;

	[SerializeField]
	private AudioClip mhm;

	[SerializeField]
	private AudioClip mhm2;

	[SerializeField]
	private AudioClip mhm4;

	[SerializeField]
	private AudioClip aha2;

	[SerializeField]
	private AudioClip hey2;

	[SerializeField]
	private AudioClip gibberish;

	[SerializeField]
	private AudioClip click;

	[SerializeField]
	private AudioClip hmm;

	public float popTime;

	private bool isClicked;

	public void PlayThinking()
	{
		audioSource.PlayOneShot(thinking);
	}

	public void PlayGibber()
	{
		audioSource.PlayOneShot(gibberish);
	}

	public void PlayOh()
	{
		audioSource.PlayOneShot(oh);
	}

	public void PlayHelloReal()
	{
		audioSource.PlayOneShot(hello);
	}

	public void PlayHello()
	{
		PlayDelayed(hey2, 0.4f);
	}

	public void PlayHey(float waitTime)
	{
		isClicked = false;
		audioSource.clip = hey;
		StartCoroutine(PlayHeyCoroutine(waitTime));
	}

	public void PlayHey2()
	{
		audioSource.PlayOneShot(hey2);
	}

	public void PlayWoosh()
	{
		audioSource.PlayOneShot(woosh);
	}

	public void PlayPop()
	{
		StartCoroutine(PlayPopCoroutine());
	}

	public void PlayPopNoDelay()
	{
		audioSource.PlayOneShot(pop);
	}

	public void PlayYeah()
	{
		audioSource.PlayOneShot(yeah);
	}

	public void PlayMhm()
	{
		audioSource.PlayOneShot(mhm);
	}

	public void PlayMhm2()
	{
		audioSource.PlayOneShot(mhm2);
	}

	public void PlayMhm4()
	{
		audioSource.PlayOneShot(mhm4);
	}

	public void PlayAha2()
	{
		audioSource.PlayOneShot(aha2);
	}

	public void PlaySwish()
	{
		audioSource.PlayOneShot(swish);
	}

	public void PlayClick()
	{
		audioSource.PlayOneShot(click);
	}

	public void PlayDelayed(AudioClip clip, float delay)
	{
		audioSource.clip = clip;
		audioSource.PlayDelayed(delay);
	}

	public IEnumerator PlayPopCoroutine()
	{
		yield return new WaitForSeconds(popTime);
		audioSource.PlayOneShot(pop);
	}

	public IEnumerator PlayHeyCoroutine(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		if (!isClicked)
		{
			audioSource.Play();
		}
	}

	public void PlayHmm()
	{
		audioSource.clip = hmm;
		audioSource.Play();
		isClicked = true;
	}
}
