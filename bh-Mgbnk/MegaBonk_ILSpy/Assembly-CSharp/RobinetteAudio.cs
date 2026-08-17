using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using UnityEngine;

public class RobinetteAudio : MonoBehaviour
{
	public AudioSource audioSource;

	public float desiredVolume = 0.4f;

	public Animator animator;

	private void Awake()
	{
	}

	private void Update()
	{
		//IL_005d: Expected F4, but got I4
		//IL_00b7: Invalid comparison between I4 and F4
		//IL_0102: Expected F4, but got I4
		if (MyTime.paused || !(MyPlayer.Instance != null))
		{
			return;
		}
		float num = ((!animator.GetBool("grounded")) ? 1f : 0f);
		float volume = audioSource.volume;
		float num2 = num * desiredVolume;
		float deltaTime = Time.deltaTime;
		float num3 = deltaTime * 20f;
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = num2 - volume;
		float num5 = num4 * num3;
		float volume2 = num5 + volume;
		audioSource.volume = volume2;
		float volume3 = audioSource.volume;
		if (0.01f < volume3)
		{
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
		else
		{
			audioSource.volume = 0f;
			audioSource.Stop();
		}
	}
}
