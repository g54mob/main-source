using System.Collections;
using UnityEngine;

public class PlaySoundOnAwake : MonoBehaviour
{
	public string audioName = "";

	public float delay;

	public bool positionalSound = true;

	private void Start()
	{
		StartCoroutine(PlaySoundWithDelay());
	}

	private IEnumerator PlaySoundWithDelay()
	{
		yield return new WaitForSeconds(delay);
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
