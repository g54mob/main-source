using System;
using TMPro;
using UnityEngine;

public class StretchingBackground : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private RectTransform stretchableImage;

	[SerializeField]
	private RectTransform movingImage;

	[SerializeField]
	private float stretchDistance = 200f;

	[SerializeField]
	private float moveDistance = 200f;

	[SerializeField]
	private float duration = 1f;

	[SerializeField]
	private LeanTweenType easeType = LeanTweenType.easeInOutQuad;

	[SerializeField]
	private TextMeshProUGUI tabTooltipTxt;

	private Vector2 originalStretchSize;

	private Vector2 originalStretchPos;

	private Vector2 originalMovePos;

	private void Awake()
	{
		originalStretchSize = stretchableImage.sizeDelta;
		originalStretchPos = stretchableImage.anchoredPosition;
		originalMovePos = movingImage.anchoredPosition;
	}

	private void Start()
	{
		LevelManager.Instance.DestinationReached += HandleDestinationReached;
		LevelManager.Instance.NextLevelSelected += delegate
		{
			HandleNextLevelSelected();
		};
	}

	private void HandleDestinationReached()
	{
		StartAnimation();
	}

	private void HandleNextLevelSelected()
	{
		ResetAnimation();
	}

	public void StartAnimation()
	{
		LeanTween.cancel(stretchableImage.gameObject);
		LeanTween.cancel(movingImage.gameObject);
		_ = originalStretchPos;
		_ = stretchDistance;
		LeanTween.value(stretchableImage.gameObject, 0f, 1f, duration).setEase(easeType).setIgnoreTimeScale(useUnScaledTime: true)
			.setOnUpdate(delegate(float t)
			{
				stretchableImage.sizeDelta = new Vector2(originalStretchSize.x + stretchDistance * t, originalStretchSize.y);
				stretchableImage.anchoredPosition = new Vector2(originalStretchPos.x + stretchDistance * t / 2f, originalStretchPos.y);
			})
			.setOnComplete((Action)delegate
			{
			});
		LeanTween.moveX(movingImage, originalMovePos.x + moveDistance, duration).setEase(easeType).setIgnoreTimeScale(useUnScaledTime: true);
	}

	public void ResetAnimation()
	{
		LeanTween.value(stretchableImage.gameObject, 1f, 0f, duration).setEase(easeType).setIgnoreTimeScale(useUnScaledTime: true)
			.setOnUpdate(delegate(float t)
			{
				stretchableImage.sizeDelta = new Vector2(originalStretchSize.x + stretchDistance * t, originalStretchSize.y);
				stretchableImage.anchoredPosition = new Vector2(originalStretchPos.x + stretchDistance * t / 2f, originalStretchPos.y);
			});
		LeanTween.moveX(movingImage, originalMovePos.x, duration).setEase(easeType).setIgnoreTimeScale(useUnScaledTime: true);
	}

	public void OpenInventory()
	{
		MenuManager.Instance.OpenMenu(MenuType.Inventory);
	}
}
