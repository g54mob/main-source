using UnityEngine;

public class SFX : MonoBehaviour
{
	private AudioSource source;

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	public void PlaySound(string name)
	{
		source.loop = false;
		source.clip = Resources.Load<AudioClip>("Sounds/SFX/" + name);
		source.Play();
	}

	public void PlaySoundLoop(string name)
	{
		source.loop = true;
		source.clip = Resources.Load<AudioClip>("Sounds/SFX/" + name);
		source.Play();
	}

	public void Stop()
	{
		source.Stop();
	}
}
