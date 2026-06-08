using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
	protected AudioSource audioPlayer;

	protected virtual void Start()
	{
		audioPlayer = GetComponent<AudioSource>();
	}
}
