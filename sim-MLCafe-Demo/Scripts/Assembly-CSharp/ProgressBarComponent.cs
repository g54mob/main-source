using UnityEngine;
using UnityEngine.UI;

public class ProgressBarComponent : MonoBehaviour
{
	[SerializeField]
	private Image image_fill;

	[SerializeField]
	private UIContentAnimator animator;

	[SerializeField]
	private bool noAnimationFade;

	[SerializeField]
	private bool hideOnClearEvent;

	[SerializeField]
	private bool hideOnStopHoldingInteraction;

	private bool isVisible;

	private void Start()
	{
		if (animator == null)
		{
			return;
		}
		if (noAnimationFade)
		{
			animator.GetCanvasGroup().alpha = 0f;
			isVisible = false;
			return;
		}
		animator.BeginWithTargetState();
		if (hideOnClearEvent)
		{
			MouseCursorInteraction.OnClearCasted.AddListener(HideWhenNotHoldingInteractionButton);
		}
		if (hideOnStopHoldingInteraction)
		{
			InputManager.OnStopHoldingInteraction.AddListener(HideForce);
		}
	}

	public bool IsVisible()
	{
		return isVisible;
	}

	public float GetFillAmount()
	{
		return image_fill.fillAmount;
	}

	public void AddAmount(float amount)
	{
		image_fill.fillAmount += amount;
	}

	public void UpdateBar(float progress, bool useLimit = true)
	{
		image_fill.fillAmount = progress;
		if (useLimit)
		{
			if (progress >= 1f)
			{
				HideForce();
			}
			if (progress <= 0f)
			{
				HideForce();
			}
		}
	}

	public void ResetFill()
	{
		image_fill.fillAmount = 0f;
	}

	public void ShowProgressbar(float initialValue = 0f)
	{
		image_fill.fillAmount = initialValue;
		if (noAnimationFade)
		{
			animator.GetCanvasGroup().alpha = 1f;
			isVisible = true;
		}
		else if (!(animator == null))
		{
			isVisible = true;
			animator.OnReverse();
		}
	}

	public void HideProgressbar()
	{
		image_fill.fillAmount = 0f;
		if (noAnimationFade)
		{
			animator.GetCanvasGroup().alpha = 0f;
			isVisible = false;
		}
		else if (!(animator == null))
		{
			isVisible = false;
			animator.OnPlay();
		}
	}

	public void ShowForced(float initialValue = 0f)
	{
		image_fill.fillAmount = initialValue;
		if (noAnimationFade)
		{
			animator.GetCanvasGroup().alpha = 1f;
			isVisible = true;
			return;
		}
		isVisible = true;
		if (!(animator == null))
		{
			animator.BeginWithNormalState();
		}
	}

	public void HideForce()
	{
		isVisible = false;
		if (noAnimationFade)
		{
			animator.GetCanvasGroup().alpha = 0f;
			isVisible = false;
		}
		else if (!(animator == null))
		{
			animator.BeginWithTargetState();
		}
	}

	private void HideWhenNotHoldingInteractionButton()
	{
		if (!InputManager.IsHoldingInteraction())
		{
			HideForce();
		}
	}
}
