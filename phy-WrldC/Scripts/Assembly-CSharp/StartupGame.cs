using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartupGame : MonoBehaviour
{
	[SerializeField]
	private GameObject loadingCanvasObject;

	[SerializeField]
	private CanvasGroup loadingCanvasGroup;

	[SerializeField]
	private TextMeshProUGUI totalLoadedText;

	[SerializeField]
	private Slider loadBarSlider;

	[SerializeField]
	public List<GameObject> guiFolders;

	private float currentVelocity;

	private WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

	private void Awake()
	{
		loadingCanvasObject.SetActive(value: true);
		SetLoadingProgress(0.05f);
		for (int i = 0; i < guiFolders.Count; i++)
		{
			Canvas[] componentsInChildren = guiFolders[i].GetComponentsInChildren<Canvas>(includeInactive: true);
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].gameObject.SetActive(value: false);
			}
		}
	}

	public void SetLoadingProgress(float value)
	{
		totalLoadedText.text = "[" + Mathf.CeilToInt(value * 100f) + "%]";
		loadBarSlider.value = value;
	}

	public void HideLoadingPanel()
	{
		StartCoroutine(FadeLoadingPanel());
	}

	private IEnumerator FadeLoadingPanel()
	{
		yield return new WaitForSeconds(0.5f);
		while (loadingCanvasGroup.alpha > 0.01f)
		{
			loadingCanvasGroup.alpha = Mathf.SmoothDamp(loadingCanvasGroup.alpha, 0f, ref currentVelocity, 0.2f);
			yield return waitForEndOfFrame;
		}
		loadingCanvasObject.SetActive(value: false);
	}
}
