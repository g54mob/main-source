using UnityEngine;

public class SimpleSoundAnimationEvent : MonoBehaviour
{
	[SerializeField]
	private bool playOneShot;

	[SerializeField]
	private bool useOwnAudioSource = true;

	[SerializeField]
	private AudioData[] audioDatas;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void AnimationSimpleSoundEvent(int idx = -1)
	{
		if (!useOwnAudioSource)
		{
			int num = ((idx == -1) ? Random.Range(0, audioDatas.Length) : idx);
			AudioSystem.Instance.PlaySound3D(audioDatas[idx], base.transform.position, AudioSystem.EAudioMixerGroup.SFX);
		}
		else if ((bool)audioSource)
		{
			if (audioDatas != null && audioDatas.Length != 0)
			{
				int num = ((idx == -1) ? Random.Range(0, audioDatas.Length) : idx);
				audioSource.clip = audioDatas[num].GetRandomAudioClip;
				audioSource.volume = audioDatas[num].Volume;
				audioSource.pitch = audioDatas[num].Pitch;
			}
			else
			{
				audioSource.volume = 1f;
				audioSource.pitch = 1f;
			}
			if (playOneShot)
			{
				audioSource.PlayOneShot(audioSource.clip, audioSource.volume);
			}
			else
			{
				audioSource.Play();
			}
		}
	}
}
