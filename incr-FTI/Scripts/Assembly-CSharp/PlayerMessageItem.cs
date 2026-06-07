using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMessageItem : MonoBehaviour
{
	public Image background;

	public Image leftIcon;

	public Image rightIcon;

	public TextMeshProUGUI messageLabel;

	public TextMeshProUGUI rightIconLabel;

	public RectTransform labelRectTransform;

	public CanvasGroup canvasGroup;

	public bool isAnimatingIn;

	public float animatePositionProgress;

	public float displayProgress;

	private const float displayDurationMax = 3f;

	public float positionChangeSpeed = 3f;

	public float flashSpeed = 2f;

	private Color FlashColor = new Color(0.52f, 0.88f, 1f, 1f);

	private Color RegularColor = new Color(0.15f, 0.27f, 0.27f, 0.95f);

	public float flashProgress;

	public bool fixedPosition;

	[NonSerialized]
	public bool isCurrentNotificationPermanent;

	[NonSerialized]
	public bool isCenterNotification;

	private void Update()
	{
		if (flashProgress < 1f)
		{
			flashProgress += TimeManager.MenuDelta * flashSpeed;
			if (flashProgress >= 1f)
			{
				flashProgress = 1f;
			}
		}
		if (isAnimatingIn)
		{
			if (animatePositionProgress >= 1f)
			{
				displayProgress += TimeManager.MenuDelta;
				if (displayProgress >= 4f)
				{
					if (isCenterNotification)
					{
						isAnimatingIn = false;
					}
					else if (!MenuManager.Instance.TryNextNotification() && displayProgress >= 10f)
					{
						isAnimatingIn = false;
					}
				}
			}
			else
			{
				animatePositionProgress += TimeManager.MenuDelta * positionChangeSpeed;
				if (animatePositionProgress >= 1f)
				{
					animatePositionProgress = 1f;
					displayProgress = 0f;
				}
			}
		}
		else if (!isCurrentNotificationPermanent)
		{
			animatePositionProgress -= TimeManager.MenuDelta * positionChangeSpeed;
			if (animatePositionProgress <= 0f)
			{
				animatePositionProgress = 0f;
				isCurrentNotificationPermanent = false;
				if (!fixedPosition && !fixedPosition)
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		if (fixedPosition)
		{
			background.color = Color.Lerp(FlashColor, ColorManager.backgroundNormal, flashProgress);
		}
		else
		{
			background.color = Color.Lerp(FlashColor, RegularColor, flashProgress);
		}
		float num = DOVirtual.EasedValue(0f, 1f, animatePositionProgress, Ease.OutBack);
		if (null != canvasGroup)
		{
			if (isAnimatingIn)
			{
				canvasGroup.alpha = 1f;
			}
			else
			{
				canvasGroup.alpha = animatePositionProgress;
			}
		}
		if (!fixedPosition && base.transform is RectTransform rectTransform)
		{
			rectTransform.SetPosY(num * (rectTransform.rect.height + 20f));
		}
	}

	public void DisplayNotification(Notification n)
	{
		base.gameObject.SetActive(value: true);
		isCurrentNotificationPermanent = n.isPermanent;
		if (n.useImages)
		{
			if (!fixedPosition)
			{
				labelRectTransform.SetLeft(90f);
				if (null != rightIconLabel)
				{
					labelRectTransform.SetRight(90f);
				}
			}
			leftIcon.sprite = n.leftImage;
			rightIcon.sprite = n.rightImage;
			messageLabel.text = n.message;
			rightIconLabel.enabled = true;
			rightIcon.enabled = null != n.rightImage;
			leftIcon.enabled = null != n.leftImage;
			rightIconLabel.text = n.rightValue;
			SoundManager.isNotificationSoundQueued = true;
		}
		else
		{
			if (!fixedPosition)
			{
				labelRectTransform.SetLeft(5f);
				labelRectTransform.SetRight(5f);
			}
			messageLabel.text = n.message;
			rightIconLabel.enabled = false;
			rightIcon.enabled = false;
			leftIcon.enabled = false;
		}
		AnimateIn();
	}

	public void AnimateIn()
	{
		flashProgress = 0f;
		displayProgress = 0f;
		if (base.gameObject.activeInHierarchy)
		{
			if (isAnimatingIn)
			{
				if (animatePositionProgress >= 1f)
				{
					displayProgress = 0f;
				}
			}
			else
			{
				isAnimatingIn = true;
			}
		}
		else
		{
			isAnimatingIn = true;
			base.gameObject.SetActive(value: true);
		}
		UpdateDisplay();
	}

	public void Reset()
	{
		isAnimatingIn = false;
		animatePositionProgress = 0f;
		displayProgress = 0f;
		base.gameObject.SetActive(value: false);
		messageLabel.text = string.Empty;
		rightIconLabel.enabled = false;
		rightIcon.enabled = false;
		leftIcon.enabled = false;
		UpdateDisplay();
	}
}
