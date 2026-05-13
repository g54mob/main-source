using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
	[SerializeField]
	private GameObject mainMenu;

	[SerializeField]
	private GameObject optionsMenu;

	[SerializeField]
	private GameObject black;

	[SerializeField]
	private SFX sfx;

	private bool playing;

	private void Start()
	{
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.None;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !playing)
		{
			sfx.PlaySound("Click");
		}
	}

	public void Play()
	{
		if (!playing)
		{
			playing = true;
			StartCoroutine(IPlay());
		}
	}

	private IEnumerator IPlay()
	{
		sfx.PlaySound("Tape");
		black.SetActive(value: true);
		mainMenu.SetActive(value: false);
		yield return new WaitForSeconds(2.5f);
		SceneManager.LoadScene("Scene1");
	}

	public void Discord()
	{
		Application.OpenURL("https://discord.com/invite/2002games");
	}

	public void X()
	{
		Application.OpenURL("https://x.com/2OO2STUDIO");
	}

	public void Itch()
	{
		Application.OpenURL("https://2oo2.itch.io/");
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void Options()
	{
		mainMenu.SetActive(value: false);
		optionsMenu.SetActive(value: true);
	}

	public void Back()
	{
		mainMenu.SetActive(value: true);
		optionsMenu.SetActive(value: false);
	}

	public void Gallery()
	{
		SceneManager.LoadScene("Exhibition");
	}
}
