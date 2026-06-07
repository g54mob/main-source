using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupPanel : MonoBehaviour
{
	public GameObject popupPanel;

	public Button closeButton;

	public float appearSpeed = 0.5f;

	public float disappearSpeed = 0.5f;

	private CanvasGroup canvasGroup;

	private void Start()
	{
		canvasGroup = popupPanel.GetComponent<CanvasGroup>();
		canvasGroup.alpha = 0f;
		StartCoroutine(AppearPanel());
		closeButton.onClick.AddListener(delegate
		{
			StartCoroutine(DisappearPanel());
		});
	}

	private IEnumerator AppearPanel()
	{
		while (canvasGroup.alpha < 1f)
		{
			canvasGroup.alpha += Time.deltaTime / appearSpeed;
			yield return null;
		}
	}

	private IEnumerator DisappearPanel()
	{
		while (canvasGroup.alpha > 0f)
		{
			canvasGroup.alpha -= Time.deltaTime / disappearSpeed;
			yield return null;
		}
		popupPanel.SetActive(value: false);
	}
}
