using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
	public bool started;

	public Transform cam;

	public Transform camCenter;

	public AudioSource busAudio;

	public void StartGame()
	{
		Application.Quit();
		started = true;
		Invoke("LoadGame", 2f);
	}

	public void Video()
	{
		Application.OpenURL("https://youtu.be/ieTKkmTMfSg");
	}

	private void LoadGame()
	{
		SceneManager.LoadScene("MainMenu");
	}

	private void Update()
	{
		if (started)
		{
			busAudio.volume = Mathf.Lerp(busAudio.volume, 0f, Time.deltaTime);
			cam.position = Vector3.Lerp(cam.position, camCenter.position, Time.deltaTime);
		}
	}

	public void Wishlist()
	{
		Application.OpenURL("https://store.steampowered.com/app/3722330/Shift_At_Midnight/");
	}

	public void Review()
	{
		Application.OpenURL("https://store.steampowered.com/app/4050060/Shift_At_Midnight_Multiplayer_Demo/");
	}
}
