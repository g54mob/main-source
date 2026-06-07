using DG.Tweening;
using UnityEngine;

public class EndGameAnimationUI : HUDMenu
{
	[SerializeField]
	private RectTransform blackLineTopTransform;

	[SerializeField]
	private RectTransform blackLineBotTransform;

	[SerializeField]
	private float screenPercentageLineHeight = 0.05f;

	[SerializeField]
	private float blackLineAppearTime = 1f;

	public override bool BackButtonPressed()
	{
		return true;
	}

	private void OnEnable()
	{
		blackLineTopTransform.anchorMin = Vector2.up;
		blackLineTopTransform.anchorMax = Vector2.one;
		blackLineTopTransform.sizeDelta = new Vector2(0f, (float)Screen.height * screenPercentageLineHeight);
		blackLineTopTransform.anchoredPosition = new Vector3(0f, (float)Screen.height * screenPercentageLineHeight, 0f);
		blackLineTopTransform.DOAnchorPosY(0f, blackLineAppearTime);
		blackLineBotTransform.anchorMin = Vector2.zero;
		blackLineBotTransform.anchorMax = Vector2.right;
		blackLineBotTransform.sizeDelta = new Vector3(0f, (float)Screen.height * screenPercentageLineHeight);
		blackLineBotTransform.anchoredPosition = new Vector3(0f, (float)Screen.height * (0f - screenPercentageLineHeight), 0f);
		blackLineBotTransform.DOAnchorPosY(0f, blackLineAppearTime);
	}
}
