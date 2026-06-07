using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class GetColorSplashScreenHandler : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> visualsQueue;

	public int queueIndex;

	public float autoTimer;

	[SerializeField]
	private TMP_Text loadingProgressText;

	private bool hasStartedLoading;

	private void Start()
	{
		StartCoroutine(SetLocaleToSystemLanguage());
		visualsQueue[0].SetActive(value: true);
		visualsQueue[1].SetActive(value: false);
		visualsQueue[2].SetActive(value: false);
		autoTimer = 2.5f;
	}

	private IEnumerator WaitForLocalizationInitializationThenForceEnglishForNow()
	{
		yield return LocalizationSettings.InitializationOperation;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
		Debug.Log("Language Set to English");
	}

	private IEnumerator SetLocaleToSystemLanguage()
	{
		yield return LocalizationSettings.InitializationOperation;
		string twoLetterISOLanguageName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
		Locale locale = LocalizationSettings.AvailableLocales.GetLocale(twoLetterISOLanguageName);
		if (locale != null)
		{
			LocalizationSettings.SelectedLocale = locale;
			yield break;
		}
		Locale locale2 = LocalizationSettings.AvailableLocales.GetLocale("en");
		if (locale2 != null)
		{
			LocalizationSettings.SelectedLocale = locale2;
		}
	}

	private void Update()
	{
		if (autoTimer > 0f)
		{
			autoTimer -= Time.deltaTime;
		}
		else
		{
			NextStep();
		}
		if (Input.anyKeyDown)
		{
			NextStep();
		}
	}

	private IEnumerator WaitThenLoadMainMenuScene()
	{
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return new WaitForSeconds(5f);
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}

	private void NextStep()
	{
		if (!hasStartedLoading)
		{
			if (queueIndex == 0)
			{
				autoTimer = 6f;
				visualsQueue[0].SetActive(value: false);
				visualsQueue[1].SetActive(value: true);
				queueIndex++;
			}
			else if (queueIndex == 1)
			{
				visualsQueue[0].SetActive(value: false);
				visualsQueue[1].SetActive(value: false);
				visualsQueue[2].SetActive(value: true);
				StartCoroutine(WaitThenLoadMainMenuScene());
				hasStartedLoading = true;
			}
		}
	}
}
