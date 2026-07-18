using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashScreenController : MonoBehaviour
{
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip sfx_splashScreen;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private VideoPlayer videoPlayer;

	[SerializeField]
	private string sceneToLoad;

	private void Awake()
	{
		videoPlayer.Prepare();
		if (PlayerPrefs.HasKey("SFX"))
		{
			audioSource.volume = (float)PlayerPrefs.GetInt("SFX") / 10f;
		}
		else
		{
			audioSource.volume = 0.5f;
		}
		PlayerPrefs.SetInt("worldshape", 0);
		PlayerPrefs.SetInt("tilesWidthCount", 3);
	}

	private void Update()
	{
		if (videoPlayer.isPrepared && !videoPlayer.isPlaying)
		{
			videoPlayer.Play();
			animator.SetTrigger("playSplashScreen");
		}
	}

	public void PlaySound()
	{
		audioSource.PlayOneShot(sfx_splashScreen);
	}

	public void LoadScene()
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
