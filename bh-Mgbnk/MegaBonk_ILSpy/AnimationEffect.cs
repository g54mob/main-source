using UnityEngine;

public class AnimationEffect : MonoBehaviour
{
	public RandomSfx[] audioSources;

	public ParticleSystem[] particles;

	public void PlayEffect(int index)
	{
		ParticleSystem[] array = particles;
		array[index].Play();
	}

	public void PlayAudio(int index)
	{
		RandomSfx[] array = audioSources;
		array[index].Play();
	}
}
