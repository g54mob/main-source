using UnityEngine;

public class MenuMusicScript : MonoBehaviour
{
	private AudioSource MyAud;

	private bool FadingOut;

	public float FadeOutSpeed;

	private void Start()
	{
		Object.DontDestroyOnLoad(base.transform.gameObject);
		MyAud = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (FadingOut)
		{
			MyAud.volume -= Time.deltaTime * FadeOutSpeed;
		}
	}

	public void FadeOut()
	{
		FadingOut = true;
	}

	public void PlayMusic()
	{
		MyAud = GetComponent<AudioSource>();
		FadingOut = false;
		MyAud.volume = 1f;
		MyAud.Play();
	}
}
