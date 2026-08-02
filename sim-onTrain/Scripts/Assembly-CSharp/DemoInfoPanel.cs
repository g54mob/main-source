using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DemoInfoPanel : MonoBehaviour
{
	private const string PREFS_KEY = "DemoInfoShown";

	public GameObject englishPanel;

	[Header("UI")]
	public Button closeButton;

	public MainMenuPanel mainMenuPanel;

	public CanvasGroup canvasGroup;

	[Header("Fade")]
	public float fadeInDuration = 0.4f;

	public float fadeOutDuration = 0.3f;

	private void Awake()
	{
		canvasGroup.alpha = 0f;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}

	private void Start()
	{
		if (PlayerPrefs.GetInt("DemoInfoShown", 0) == 1)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		if (englishPanel != null)
		{
			englishPanel.SetActive(value: true);
		}
		closeButton.onClick.AddListener(Close);
		if (mainMenuPanel != null)
		{
			mainMenuPanel.HideMainMenuCanvas();
		}
		StartCoroutine(FadeIn());
	}

	private void Update()
	{
		if (canvasGroup.interactable && Input.GetKeyDown(KeyCode.Escape))
		{
			Close();
		}
	}

	private void Close()
	{
		PlayerPrefs.SetInt("DemoInfoShown", 1);
		PlayerPrefs.Save();
		StartCoroutine(FadeOutAndClose());
	}

	private IEnumerator FadeIn()
	{
		float t = 0f;
		while (t < fadeInDuration)
		{
			t += Time.deltaTime;
			canvasGroup.alpha = t / fadeInDuration;
			yield return null;
		}
		canvasGroup.alpha = 1f;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = true;
	}

	private IEnumerator FadeOutAndClose()
	{
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
		float t = 0f;
		while (t < fadeOutDuration)
		{
			t += Time.deltaTime;
			canvasGroup.alpha = 1f - t / fadeOutDuration;
			yield return null;
		}
		canvasGroup.alpha = 0f;
		base.gameObject.SetActive(value: false);
		if (mainMenuPanel != null)
		{
			mainMenuPanel.ShowMainMenuCanvas();
		}
	}
}
