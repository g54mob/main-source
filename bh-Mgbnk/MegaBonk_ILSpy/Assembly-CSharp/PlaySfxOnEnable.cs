using UnityEngine;

public class PlaySfxOnEnable : MonoBehaviour
{
	public RandomSfx randomSfx;

	public AudioSource audioSource;

	private void OnEnable()
	{
		if (!(randomSfx == null))
		{
			randomSfx.Play();
		}
		else
		{
			audioSource.Play();
		}
	}

	private void OnValidate()
	{
		RandomSfx component = GetComponent<RandomSfx>();
		randomSfx = component;
		AudioSource component2 = GetComponent<AudioSource>();
		audioSource = component2;
	}
}
