using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsSceneManager : MonoBehaviour
{
	public static CreditsSceneManager Singleton;

	[SerializeField]
	private AudioClip goodEnding_MusicTrack;

	[SerializeField]
	private AudioClip belladonnaEnding_MusicTrack;

	[SerializeField]
	private AudioClip gnomeEnding_MusicTrack;

	[SerializeField]
	private AudioSource creditsMusicSource;

	[Header("Texts")]
	[SerializeField]
	private GameObject titleText;

	[SerializeField]
	private GameObject text_GetColorGames;

	[SerializeField]
	private GameObject text_ByTrevorVaughn;

	[SerializeField]
	private GameObject text_imtired;

	[SerializeField]
	private GameObject text_additionalcredits;

	[SerializeField]
	private GameObject text_communitymanagerandplaytesters;

	[SerializeField]
	private GameObject text_LocalizationCredits;

	[SerializeField]
	private GameObject text_thanksforplaying;

	[SerializeField]
	private GameObject text_pressAnyKey;

	[Header("Gnome Swap")]
	[SerializeField]
	private Image image_Title;

	[SerializeField]
	private Sprite gnomeTitleSprite;

	[Header("Skipping")]
	[SerializeField]
	private Image ui_skipFillImage;

	private float skipTimer_Curr;

	private float skipTimer_FillSpeed = 0.5f;

	private bool isAtEndOfCredits;

	private bool hasStartedLoadingResultsScene;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		PickMusicTrack();
		StartCoroutine(StartCreditsEndSceneScroll());
	}

	private void Update()
	{
		if (isAtEndOfCredits && Input.anyKeyDown)
		{
			LoadResultsScene();
		}
		if (Input.anyKey)
		{
			if (skipTimer_Curr < 1f)
			{
				skipTimer_Curr += Time.deltaTime;
			}
		}
		else if (skipTimer_Curr >= 1f)
		{
			LoadResultsScene();
		}
		else
		{
			skipTimer_Curr -= Time.deltaTime * 2f;
		}
		skipTimer_Curr = Mathf.Clamp(skipTimer_Curr, 0f, 1f);
		UpdateSkipUI();
	}

	private void UpdateSkipUI()
	{
		ui_skipFillImage.fillAmount = skipTimer_Curr;
	}

	private void PickMusicTrack()
	{
		try
		{
			if (MenuToGameBridger.Singleton.endingCompletedString == "Truth" || MenuToGameBridger.Singleton.endingCompletedString == "A")
			{
				creditsMusicSource.clip = goodEnding_MusicTrack;
				creditsMusicSource.Play();
			}
			else if (MenuToGameBridger.Singleton.endingCompletedString == "Belladonna" || MenuToGameBridger.Singleton.endingCompletedString == "C")
			{
				creditsMusicSource.clip = belladonnaEnding_MusicTrack;
				creditsMusicSource.Play();
			}
			else if (MenuToGameBridger.Singleton.endingCompletedString == "Gnome" || MenuToGameBridger.Singleton.endingCompletedString == "D")
			{
				image_Title.sprite = gnomeTitleSprite;
				creditsMusicSource.clip = gnomeEnding_MusicTrack;
				creditsMusicSource.Play();
			}
			else
			{
				creditsMusicSource.Play();
			}
		}
		catch
		{
			creditsMusicSource.clip = goodEnding_MusicTrack;
			creditsMusicSource.Play();
		}
	}

	private IEnumerator StartCreditsEndSceneScroll()
	{
		titleText.SetActive(value: true);
		yield return new WaitForSeconds(3.25f);
		titleText.SetActive(value: false);
		text_GetColorGames.SetActive(value: true);
		yield return new WaitForSeconds(3f);
		text_GetColorGames.SetActive(value: false);
		text_ByTrevorVaughn.SetActive(value: true);
		yield return new WaitForSeconds(3f);
		text_imtired.SetActive(value: true);
		yield return new WaitForSeconds(2f);
		text_ByTrevorVaughn.SetActive(value: false);
		text_imtired.SetActive(value: false);
		text_additionalcredits.SetActive(value: true);
		yield return new WaitForSeconds(8f);
		text_additionalcredits.SetActive(value: false);
		text_communitymanagerandplaytesters.SetActive(value: true);
		yield return new WaitForSeconds(6f);
		text_communitymanagerandplaytesters.SetActive(value: false);
		text_LocalizationCredits.SetActive(value: true);
		yield return new WaitForSeconds(6f);
		text_LocalizationCredits.SetActive(value: false);
		text_thanksforplaying.SetActive(value: true);
		yield return new WaitForSeconds(5f);
		text_pressAnyKey.SetActive(value: true);
		isAtEndOfCredits = true;
	}

	public void LoadResultsScene()
	{
		if (!hasStartedLoadingResultsScene)
		{
			hasStartedLoadingResultsScene = true;
			if (MenuToGameBridger.Singleton.enteredCreditsFromMainMenu)
			{
				SceneManager.LoadScene("MainMenu");
			}
			else
			{
				SceneManager.LoadScene("EndingResults");
			}
		}
	}
}
