using System.Collections;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.UI;

public class BigItemPickUpUI : MonoBehaviour
{
	[SerializeField]
	private Image fillImage;

	private MovableItem parentItem;

	private readonly float fillDuration = 0.4f;

	private Coroutine fillCoroutine;

	private void Start()
	{
		Hide();
		fillImage.fillAmount = 0f;
		parentItem = GetComponentInParent<MovableItem>();
	}

	public void StartFilling()
	{
		Show();
		if (fillCoroutine != null)
		{
			StopCoroutine(fillCoroutine);
		}
		fillCoroutine = StartCoroutine(FillCoroutine());
	}

	public void StopFilling()
	{
		if (fillCoroutine != null)
		{
			StopCoroutine(fillCoroutine);
			fillCoroutine = null;
		}
		Hide();
		fillImage.fillAmount = 0f;
	}

	private IEnumerator FillCoroutine()
	{
		float elapsedTime = 0f;
		fillImage.fillAmount = 0f;
		while (elapsedTime < fillDuration)
		{
			elapsedTime += Time.deltaTime;
			fillImage.fillAmount = Mathf.Clamp01(elapsedTime / fillDuration);
			yield return null;
		}
		fillImage.fillAmount = 1f;
		parentItem.BigItemStartMoving();
		Hide();
	}

	private void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}
}
