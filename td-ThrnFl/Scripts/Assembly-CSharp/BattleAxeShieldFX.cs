using System.Collections;
using UnityEngine;

public class BattleAxeShieldFX : MonoBehaviour
{
	public ParticleSystem[] particles;

	public float animationTime = 3.5f;

	private float clock;

	public void Play(float duration)
	{
		StopAllCoroutines();
		animationTime = duration;
		StartCoroutine(AnimationRoutine());
		ThronefallAudioManager.Oneshot(ThronefallAudioManager.AudioOneShot.PlayerAxeActive);
	}

	private IEnumerator AnimationRoutine()
	{
		clock = 0f;
		ParticleSystem[] array = particles;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play();
		}
		while (clock < animationTime)
		{
			clock += Time.deltaTime;
			yield return null;
		}
		array = particles;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
	}
}
