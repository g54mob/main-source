using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageItem : MonoBehaviour
{
	public Image image;

	[SerializeField]
	public Sprite defaultSprite;

	public TextMeshProUGUI messageText;

	public RectTransform panel;

	[SerializeField]
	private CanvasGroup cg;

	[HideInInspector]
	public bool isShowing;

	public void ShowMessage(string message, CollectableItemData data, float fadeInDuration, float displayDelay, float slideUpAmount, float fadeOutDuration)
	{
		if (data.mainItem != null)
		{
			data = data.mainItem;
		}
		Sprite itemImage = data.itemImage;
		isShowing = true;
		panel.DOKill();
		cg.DOKill();
		panel.anchoredPosition = Vector2.zero;
		panel.gameObject.SetActive(value: true);
		image.sprite = ((itemImage != null) ? itemImage : defaultSprite);
		messageText.text = message;
		cg.alpha = 0f;
		cg.DOFade(1f, fadeInDuration).SetUpdate(isIndependentUpdate: true);
		panel.DOAnchorPosY(slideUpAmount, fadeOutDuration).SetDelay(displayDelay).SetUpdate(isIndependentUpdate: true)
			.OnComplete(delegate
			{
				isShowing = false;
				panel.anchoredPosition = Vector2.zero;
				panel.gameObject.SetActive(value: false);
			});
		cg.DOFade(0f, fadeOutDuration).SetDelay(displayDelay).SetUpdate(isIndependentUpdate: true);
	}

	public void ShowMessage(string message, float fadeInDuration, float displayDelay, float slideUpAmount, float fadeOutDuration)
	{
		isShowing = true;
		panel.DOKill();
		cg.DOKill();
		panel.anchoredPosition = Vector2.zero;
		panel.gameObject.SetActive(value: true);
		image.sprite = defaultSprite;
		messageText.text = message;
		cg.alpha = 0f;
		cg.DOFade(1f, fadeInDuration).SetUpdate(isIndependentUpdate: true);
		panel.DOAnchorPosY(slideUpAmount, fadeOutDuration).SetDelay(displayDelay).SetUpdate(isIndependentUpdate: true)
			.OnComplete(delegate
			{
				isShowing = false;
				panel.anchoredPosition = Vector2.zero;
				panel.gameObject.SetActive(value: false);
			});
		cg.DOFade(0f, fadeOutDuration).SetDelay(displayDelay).SetUpdate(isIndependentUpdate: true);
	}

	public void ShowMessage(string message, CollectableItemData data)
	{
		ShowMessage(message, data, 0.5f, 1f, (float)Screen.height / 10f, 0.5f);
	}

	public void ShowMessage(string message)
	{
		ShowMessage(message, 0.5f, 1f, (float)Screen.height / 10f, 0.5f);
	}
}
