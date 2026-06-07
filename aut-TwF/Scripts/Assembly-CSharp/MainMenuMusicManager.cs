using UnityEngine;

public class MainMenuMusicManager : MonoBehaviour
{
	[SerializeField]
	private AudioData mainMenuMusic;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = new GameObject("MusicAudioSource").AddComponent<AudioSource>();
		audioSource.transform.SetParent(base.transform, worldPositionStays: false);
		audioSource.loop = true;
		audioSource.outputAudioMixerGroup = AudioSystem.Instance.GetAudioMixerConfig(AudioSystem.EAudioMixerGroup.Music).mixer;
		PlayMainMenuMusic();
	}

	private void PlayMainMenuMusic()
	{
		audioSource.clip = mainMenuMusic.GetRandomAudioClip;
		audioSource.volume = mainMenuMusic.Volume;
		audioSource.PlayDelayed(0.1f);
	}
}
