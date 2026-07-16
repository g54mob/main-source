using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomerUIInfo : MonoBehaviour
{
	private enum CustomerInfoType
	{
		None = -1,
		DefaultInfo = 0,
		WaitingTime = 1,
		ItIsDirty = 2
	}

	private CustomerInfoType customerInfoType = CustomerInfoType.None;

	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private Image fill;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private Sprite spriteClosing;

	[SerializeField]
	private Sprite spriteNoSeat;

	[SerializeField]
	private Sprite spriteTooExpensive;

	[SerializeField]
	private Sprite spriteHappy;

	[SerializeField]
	private Sprite spriteUnhappy;

	[SerializeField]
	private DialogBoxComponent dialogBoxComponent;

	[SerializeField]
	private GameObject nameTag;

	[SerializeField]
	private TMP_Text labelName;

	private Color startFillColor;

	private bool isVisible;

	private void Start()
	{
		startFillColor = fill.color;
		UnityAction call = delegate
		{
			fill.fillAmount = 0f;
			fill.color = startFillColor;
		};
		animator.OnFinishedReverse.AddListener(call);
		animator.BeginWithNormalState();
		if (!(dialogBoxComponent == null))
		{
			dialogBoxComponent.StopDialog();
		}
	}

	public bool IsVisible()
	{
		return isVisible;
	}

	public DialogBoxComponent GetLocalDialogBoxComponent()
	{
		return dialogBoxComponent;
	}

	private void PopIcon(float duration = 2f, Sprite sprite = null, Action onFinsihed = null)
	{
		icon.sprite = sprite;
		animator.OnPlay();
		TweenerManager.TweenTimeAction("HidePopUpMessage", duration, delegate
		{
			animator.OnReverse();
			if (onFinsihed != null)
			{
				onFinsihed();
			}
		});
		isVisible = true;
	}

	public void ShowPop()
	{
		animator.OnPlay();
		isVisible = true;
	}

	public void HidePop()
	{
		animator.OnReverse();
		isVisible = false;
	}

	public void PopInfo(float duration)
	{
		PopIcon(duration);
	}

	public void PopHappy()
	{
		PopIcon(2f, spriteHappy);
	}

	public void PopUnhappy()
	{
		PopIcon(2f, spriteUnhappy);
	}

	public void PopNoSeat()
	{
		PopIcon(2f, spriteNoSeat);
	}

	public void PopTooExpensive(float duration = 2f, Action onFinished = null)
	{
		PopIcon(duration, spriteTooExpensive, onFinished);
	}

	public void PopWaitingDuration(float timeValue, float min, float max)
	{
		animator.OnPlay();
		UpdateFillAndColor(timeValue, min, max);
		isVisible = true;
	}

	public void PopClosingDuration(float timeValue, float min, float max)
	{
		icon.sprite = spriteClosing;
		animator.OnPlay();
		UpdateFillAndColor(timeValue, min, max);
		isVisible = true;
	}

	public void SetIconClosing()
	{
		icon.sprite = spriteClosing;
	}

	public void ShowName(string name, Color prefferedColor)
	{
		labelName.text = name;
		nameTag.SetActive(value: true);
	}

	public void HideName()
	{
		nameTag.SetActive(value: false);
	}

	public void UpdateFillAndColor(float timeValue, float min, float max)
	{
		fill.fillAmount = Mathf.InverseLerp(min, max, timeValue);
		fill.color = Color.Lerp(startFillColor, Color.red, fill.fillAmount);
	}

	public void HideInfo()
	{
		animator.OnReverse();
		isVisible = false;
	}
}
