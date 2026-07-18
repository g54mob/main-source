using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public static MusicManager Instance;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip currentAudioClip;

	[SerializeField]
	private List<AudioClip> songs;

	private bool shuffledSongs;

	private int currentIndex = -1;

	private void Awake()
	{
		Instance = this;
		if (Object.FindObjectsOfType<MusicManager>().Length > 1)
		{
			Object.Destroy(base.gameObject);
		}
		MathEquations.Shuffle(songs);
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
		if (!audioSource.isPlaying)
		{
			currentIndex++;
			if (currentIndex == songs.Count)
			{
				currentIndex = 0;
			}
			currentAudioClip = songs[currentIndex];
			PlayMusic();
		}
	}

	public void SetVolume()
	{
		audioSource.volume = SettingsManager.Instance.GetMusicVolume();
	}

	private void PlayMusic()
	{
		audioSource.PlayOneShot(songs[currentIndex]);
	}
}
