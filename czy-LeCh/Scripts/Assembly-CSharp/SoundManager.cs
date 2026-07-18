using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private float toSubtractExtra;

	private void OnEnable()
	{
		SetVolume();
	}

	public void PlaySound(AudioClip clip, bool randomPitch)
	{
		audioSource.pitch = (randomPitch ? Random.Range(1f, 1.5f) : 1f);
		audioSource.PlayOneShot(clip);
	}

	public void SetVolume()
	{
		try
		{
			if (SceneManager.GetActiveScene().name == "SplashScreen")
			{
				audioSource.volume = (PlayerPrefs.HasKey("sfxVolume") ? PlayerPrefs.GetFloat("sfxVolume") : 0.5f);
			}
			else
			{
				audioSource.volume = SettingsManager.Instance.GetSFXVolume() - toSubtractExtra;
			}
		}
		catch
		{
		}
	}

	public void ChangePitch(bool add)
	{
		audioSource.pitch += (add ? 0.01f : (-0.01f));
	}

	public void ResetPitch()
	{
		audioSource.pitch = 1f;
	}
}
