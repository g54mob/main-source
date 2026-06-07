using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI totalLoadedText;

	[SerializeField]
	private Slider loadBarSlider;

	private float smoothProgress;

	private float currentVelocity;

	private void Start()
	{
		SetLoadingProgress(0f);
		StartCoroutine(LoadGameCore());
	}

	private IEnumerator LoadGameCore()
	{
		AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Gameplay");
		loadOperation.allowSceneActivation = false;
		yield return StartCoroutine(UpdateLoadingProgress(loadOperation));
		loadOperation.allowSceneActivation = true;
		yield return new WaitForEndOfFrame();
	}

	private IEnumerator UpdateLoadingProgress(AsyncOperation loadOperation)
	{
		while (loadOperation.progress < 0.899f)
		{
			SetLoadingProgress(loadOperation.progress * 0.05f);
			yield return new WaitForEndOfFrame();
		}
		SetLoadingProgress(0.05f);
		yield return new WaitForEndOfFrame();
	}

	private void SetLoadingProgress(float value)
	{
		totalLoadedText.text = "[" + Mathf.CeilToInt(value * 100f) + "%]";
		loadBarSlider.value = value;
	}
}
