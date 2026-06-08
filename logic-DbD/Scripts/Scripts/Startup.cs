using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
	[SerializeField]
	private AudioClip shine;

	[SerializeField]
	private AudioClip logoJingle;

	protected AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		StartCoroutine(PlayJingle(1.2f));
		StartCoroutine(PlayShine(2f));
		StartCoroutine(PlaySceneDelay(4f));
	}

	private IEnumerator PlaySceneDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene("CopOS");
	}

	private IEnumerator PlayJingle(float delay)
	{
		yield return new WaitForSeconds(delay);
		audioSource.PlayOneShot(logoJingle, 1.5f);
	}

	private IEnumerator PlayShine(float delay)
	{
		yield return new WaitForSeconds(delay);
		audioSource.PlayOneShot(shine, 2.5f);
	}
}
