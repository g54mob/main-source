using System.Collections;
using UnityEngine;

public class PlaySoundAtInterval : MonoBehaviour
{
	public string audioName = "";

	public float interval = 0.5f;

	public bool playImmediately = true;

	public bool positionalSound = true;

	private void Awake()
	{
		StartCoroutine(PlaySoundWithDelay());
	}

	private IEnumerator PlaySoundWithDelay()
	{
		if (playImmediately)
		{
			PlaySound();
		}
		WaitForSeconds intervalWait = new WaitForSeconds(interval);
		while (base.gameObject.activeSelf)
		{
			yield return intervalWait;
			PlaySound();
		}
	}

	private void PlaySound()
	{
		if (positionalSound)
		{
			AudioController.Play(audioName, base.transform.position);
		}
		else
		{
			AudioController.Play(audioName);
		}
	}
}
