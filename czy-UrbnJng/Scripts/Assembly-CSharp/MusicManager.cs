using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	public static MusicManager Instance;

	public AudioClip[] musicClips;

	private AudioSource audioSource;

	private string _sceneName;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		_sceneName = SceneManager.GetActiveScene().name;
		PlayLevelMusic();
	}

	public void PlayLevelMusic()
	{
		if (musicClips.Length == 0)
		{
			Debug.LogError("The audio clip array is empty");
			return;
		}
		int num = GetMusicIndexByLevel(_sceneName);
		if (AllServices.Container.Single<IPersistentProgressService>().Progress.ShowCurtain)
		{
			num = 11;
		}
		if (num >= 0 && num < musicClips.Length)
		{
			audioSource.clip = musicClips[num];
			audioSource.Play();
			CancelInvoke("OnMusicFinished");
			Invoke("OnMusicFinished", audioSource.clip.length);
		}
		else
		{
			PlayRandomMusic();
		}
	}

	public void ChangeVolume(float newVolume)
	{
		audioSource.volume = newVolume;
	}

	private void OnMusicFinished()
	{
		PlayRandomMusic();
	}

	private void PlayRandomMusic()
	{
		if (musicClips.Length != 0)
		{
			int num = Random.Range(0, musicClips.Length - 1);
			audioSource.clip = musicClips[num];
			audioSource.Play();
			Invoke("OnMusicFinished", audioSource.clip.length);
		}
		else
		{
			Debug.LogError("The audio clip array is empty");
		}
	}

	private int GetMusicIndexByLevel(string levelName)
	{
		return levelName switch
		{
			"Level_0_New" => 0, 
			"Level_1_New" => 1, 
			"Level_2_New" => 2, 
			"Level_3_New" => 3, 
			"Level_4_New" => 4, 
			"Level_5_New" => 5, 
			"Level_6_New" => 6, 
			"Level_7_New" => 7, 
			"Level_8_New" => 8, 
			"Level_9_New" => 9, 
			"Level_10_New" => 10, 
			"Level_0_CreativeMode" => 0, 
			"Level_1_CreativeMode" => 1, 
			"Level_2_CreativeMode" => 2, 
			"Level_3_CreativeMode" => 3, 
			"Level_4_CreativeMode" => 4, 
			"Level_5_CreativeMode" => 5, 
			"Level_6_CreativeMode" => 6, 
			"Level_7_CreativeMode" => 7, 
			"Level_8_CreativeMode" => 8, 
			"Level_9_CreativeMode" => 9, 
			"Level_10_CreativeMode" => 10, 
			_ => 0, 
		};
	}
}
