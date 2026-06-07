using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using RainbowArt.CleanFlatUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
	[SerializeField]
	private GameObject loadingUI;

	[SerializeField]
	private ProgressBarLoop loadingProgressBar;

	private Image loadingUIImage;

	[SerializeField]
	private ModalWindow overwriteWarningUI;

	[SerializeField]
	private ModalWindow versionWarningUI;

	[SerializeField]
	private GameObject continueBtn;

	[SerializeField]
	private ModalWindow demoCompleteUI;

	private string[] filesToKeep = new string[4] { "ES3_Setting.es3", "Unity", "Player.log", "Player-prev.log" };

	private float fadeDuration = 1f;

	private string currentVersion;

	private bool isVersionDiff;

	private bool isSaved;

	private void Awake()
	{
		loadingUIImage = loadingUI.GetComponent<Image>();
		Color color = loadingUIImage.color;
		color.a = 0f;
		loadingUIImage.color = color;
	}

	private void Start()
	{
		loadingProgressBar.gameObject.SetActive(value: false);
		overwriteWarningUI.gameObject.SetActive(value: false);
		StartCoroutine(FadeIn());
		isSaved = ES3.Load("SaveData", defaultValue: false);
		Debug.Log(isSaved);
		currentVersion = Application.version;
		string text = ES3.Load("SaveVersion", "ES3_Setting.es3", "0.0.0");
		Debug.Log(text);
		if (text != currentVersion)
		{
			isVersionDiff = true;
		}
		else
		{
			isVersionDiff = false;
		}
		if (isSaved)
		{
			continueBtn.gameObject.SetActive(value: true);
		}
		else
		{
			continueBtn.gameObject.SetActive(value: false);
		}
		if (AudioManager.S.demoComplete)
		{
			demoCompleteUI.ShowModalWindow();
			Cursor.visible = true;
			AudioManager.S.PlayDoorBell(AudioManager.S.levelUp);
			AudioManager.S.demoComplete = false;
		}
	}

	public void NewGame()
	{
		if (isVersionDiff)
		{
			if (isSaved)
			{
				ResetAllDataExceptEssential();
				StartCoroutine(FadeOut());
			}
			else
			{
				ResetAllDataExceptEssential();
				StartCoroutine(FadeOut());
			}
		}
		else if (isSaved)
		{
			overwriteWarningUI.ShowModalWindow();
		}
		else
		{
			ResetAllDataExceptEssential();
			StartCoroutine(FadeOut());
		}
	}

	public void DeleteSaveAndStartNewGame()
	{
		overwriteWarningUI.HideModalWindow();
		ResetAllDataExceptEssential();
		StartCoroutine(FadeOut());
	}

	public void DeleteSaveAndStartNewGameNewVersion()
	{
		versionWarningUI.HideModalWindow();
		ResetAllDataExceptEssential();
		StartCoroutine(FadeOut());
	}

	public void DeleteSaveFile()
	{
		if (isSaved)
		{
			ES3.DeleteFile("SaveFile.es3");
		}
	}

	public void ResetAllDataExceptEssential()
	{
		HashSet<string> hashSet = new HashSet<string>(filesToKeep);
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
		try
		{
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				if (!hashSet.Contains(fileInfo.Name))
				{
					fileInfo.Delete();
					Debug.Log("[Delete] 파일 삭제됨: " + fileInfo.Name);
				}
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				if (!hashSet.Contains(directoryInfo2.Name))
				{
					directoryInfo2.Delete(recursive: true);
					Debug.Log("[Delete] 폴더 삭제됨: " + directoryInfo2.Name);
				}
				else
				{
					Debug.Log("[Keep] 제외 대상 폴더 유지: " + directoryInfo2.Name);
				}
			}
			ES3.Save("SaveVersion", Application.version, "ES3_Setting.es3");
			isSaved = false;
			Debug.Log("필수 데이터를 제외한 초기화가 완료되었습니다.");
		}
		catch (Exception ex)
		{
			Debug.LogError("초기화 중 오류 발생: " + ex.Message);
		}
	}

	public void LoadGame()
	{
		if (isVersionDiff)
		{
			versionWarningUI.ShowModalWindow();
		}
		else
		{
			StartCoroutine(FadeOut());
		}
	}

	public IEnumerator FadeOut()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(0f, 1f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
		StartCoroutine(LoadSceneSmooth(1));
	}

	public IEnumerator FadeIn()
	{
		float time = 0f;
		Color color = loadingUIImage.color;
		while (time < fadeDuration)
		{
			time += Time.deltaTime;
			color.a = Mathf.Lerp(1f, 0f, time / fadeDuration);
			loadingUIImage.color = color;
			yield return null;
		}
	}

	private IEnumerator LoadSceneSmooth(int index)
	{
		loadingProgressBar.gameObject.SetActive(value: true);
		float minLoadTime = 1f;
		float timer = 0f;
		AsyncOperation op = SceneManager.LoadSceneAsync(index);
		op.allowSceneActivation = false;
		while (op.progress < 0.9f)
		{
			timer += Time.deltaTime;
			Mathf.Clamp01(op.progress / 0.9f);
			yield return null;
		}
		while (timer < minLoadTime)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		op.allowSceneActivation = true;
	}

	public void ExitBtn()
	{
		Application.Quit();
	}

	public void OpenWishlistPage()
	{
		Application.OpenURL("https://store.steampowered.com/app/4258880/Basement_To_The_Sky/");
	}

	public void OpenDiscordPage()
	{
		Application.OpenURL("https://discord.gg/egGtyszYqf");
	}
}
