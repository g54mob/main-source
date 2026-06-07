using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePopUp : MonoBehaviour
{
	public TMP_Text numberText;

	public Image resourceImage;

	private RectTransform rect;

	private Transform trans;

	[SerializeField]
	private bool canvasOverride;

	public void SetSprite(Sprite newSp)
	{
		resourceImage.sprite = newSp;
	}

	public void DisplayNumber(int amount)
	{
		numberText.text = amount.ToString();
		if (!canvasOverride)
		{
			AnimateRect();
		}
		else
		{
			AnimateTrans();
		}
	}

	public void DisplayText(string text)
	{
		numberText.text = text;
		if (!canvasOverride)
		{
			AnimateRect();
		}
		else
		{
			AnimateTrans();
		}
	}

	private void AnimateRect()
	{
		rect = GetComponent<RectTransform>();
		rect.DOAnchorPosY(rect.anchoredPosition.y + 20f, 3f).SetEase(Ease.OutSine);
		rect.DOScale(0f, 1f).SetDelay(2f).SetEase(Ease.OutSine)
			.OnComplete(DestroyObj);
	}

	private void AnimateTrans()
	{
		trans = GetComponent<Transform>();
		trans.DOMoveY(trans.position.y + 1.25f, 3f).SetEase(Ease.OutSine);
		trans.DOScale(0f, 1f).SetDelay(2f).SetEase(Ease.OutSine)
			.OnComplete(DestroyObj);
	}

	private void DestroyObj()
	{
		Object.Destroy(base.gameObject);
	}
}
