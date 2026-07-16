using MLCN_Localization;
using TMPro;
using UnityEngine;

public class PopupMessageComponent : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelMessage;

	[SerializeField]
	private TMP_Text labelTags;

	[SerializeField]
	private TMP_Text labelAmount;

	[SerializeField]
	private TMP_Text labelDuration;

	[SerializeField]
	private GameObject duration;

	[SerializeField]
	private UIContentAnimator animator;

	private bool isVisible;

	private void Start()
	{
		animator.BeginWithTargetState();
		ResetLabels();
	}

	public bool IsVisible()
	{
		return isVisible;
	}

	public void UpdateMessage(string msg)
	{
		ResetLabels();
		labelMessage.text = msg;
	}

	public void ShowMessageForSeconds(string msgKey, float duration = 1.5f, string suffix = "", string prefix = "")
	{
		ResetLabels();
		string text = prefix + LocalizationManager.GetLocalizedString(msgKey, LocalizationDataTable.Tables.UI) + suffix;
		labelMessage.text = text;
		if (isVisible)
		{
			TweenerManager.TweenTimeAction("HidePopUpMessage", duration, HideMessage);
		}
		else if (!(animator == null))
		{
			if (!animator.ValidFromReverse())
			{
				animator.BeginWithNormalState();
				isVisible = true;
				TweenerManager.TweenTimeAction("HidePopUpMessage", duration, HideMessage);
			}
			else
			{
				animator.OnReverse();
				isVisible = true;
				TweenerManager.TweenTimeAction("HidePopUpMessage", duration, HideMessage);
			}
		}
	}

	public void ShowMessageForSeconds(string msgKey, Color color, float duration = 1.5f)
	{
		ResetLabels();
		string localizedString = LocalizationManager.GetLocalizedString(msgKey, LocalizationDataTable.Tables.UI);
		localizedString = "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + localizedString + "</color>";
		labelMessage.text = localizedString;
		if (!isVisible && !(animator == null))
		{
			if (!animator.ValidFromReverse())
			{
				animator.BeginWithNormalState();
				isVisible = true;
				TweenerManager.TweenTimeAction("HidePopUpMessage", duration, HideMessage);
			}
			else
			{
				animator.OnReverse();
				isVisible = true;
				TweenerManager.TweenTimeAction("HidePopUpMessage", duration, HideMessage);
			}
		}
	}

	public void ShowPreLocalizedMessageForSeconds(string localizedMessage, float duration = 1.5f)
	{
		ResetLabels();
		labelMessage.text = localizedMessage;
		if (!isVisible && !(animator == null))
		{
			if (!animator.ValidFromReverse())
			{
				animator.BeginWithNormalState();
				isVisible = true;
				TweenerManager.TweenTimeAction("HidePopUpMessage", duration, HideMessage);
			}
			else
			{
				animator.OnReverse();
				isVisible = true;
				TweenerManager.TweenTimeAction("HidePopUpMessage", duration, HideMessage);
			}
		}
	}

	public void ShowMessage(string msg)
	{
		ResetLabels();
		if (isVisible)
		{
			if (msg != labelMessage.text)
			{
				UpdateMessage(msg);
			}
			isVisible = true;
			return;
		}
		labelMessage.text = msg;
		if (!(animator == null))
		{
			if (!animator.ValidFromReverse())
			{
				animator.BeginWithNormalState();
				isVisible = true;
			}
			else if (!isVisible)
			{
				animator.OnReverse();
				isVisible = true;
			}
		}
	}

	public void ShowMessage(string msg, Color color)
	{
		ResetLabels();
		msg = "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + msg + "</color>";
		if (isVisible)
		{
			if (msg != labelMessage.text)
			{
				UpdateMessage(msg);
			}
			return;
		}
		labelMessage.text = msg;
		if (!(animator == null))
		{
			if (!animator.ValidFromReverse())
			{
				animator.BeginWithNormalState();
				isVisible = true;
			}
			else
			{
				animator.OnReverse();
				isVisible = true;
			}
		}
	}

	public void ShowProductInfo(string productName, string tags, string amount = "", string durationAmount = "")
	{
		if (labelTags != null)
		{
			labelTags.text = tags;
		}
		if (labelAmount != null)
		{
			labelAmount.text = amount;
		}
		if (labelDuration != null)
		{
			labelDuration.text = durationAmount;
		}
		if (duration != null && durationAmount != "")
		{
			duration.SetActive(value: true);
		}
		labelMessage.text = productName;
		if (!isVisible && !(animator == null))
		{
			if (!animator.ValidFromReverse())
			{
				animator.BeginWithNormalState();
				isVisible = true;
			}
			else
			{
				animator.OnReverse();
				isVisible = true;
			}
		}
	}

	public void ShowRemainingTimeDuration(string durationAmount)
	{
		if (labelDuration != null)
		{
			labelDuration.text = durationAmount;
		}
		if (duration != null && durationAmount != "")
		{
			duration.SetActive(value: true);
		}
		if (!isVisible && !(animator == null))
		{
			animator.BeginWithNormalState();
			isVisible = true;
		}
	}

	public void Hide()
	{
		if (isVisible && !(animator == null))
		{
			if (!animator.ValidFromPlay())
			{
				animator.BeginWithTargetState();
				isVisible = false;
			}
			else
			{
				animator.OnPlay();
				isVisible = false;
			}
		}
	}

	public void HideMessage()
	{
		if (isVisible && !(animator == null))
		{
			if (!animator.ValidFromPlay())
			{
				animator.BeginWithTargetState();
				isVisible = false;
			}
			else
			{
				animator.OnPlay();
				isVisible = false;
			}
		}
	}

	public void HideForce()
	{
		if (!(animator == null))
		{
			animator.BeginWithTargetState();
			isVisible = false;
		}
	}

	public void HideProductInfo()
	{
		if (isVisible && !(animator == null))
		{
			if (!animator.ValidFromPlay())
			{
				animator.BeginWithTargetState();
				isVisible = false;
			}
			else
			{
				animator.OnPlay();
				isVisible = false;
			}
		}
	}

	private void ResetLabels()
	{
		if (labelMessage != null)
		{
			labelMessage.text = "";
		}
		if (labelTags != null)
		{
			labelTags.text = "";
		}
		if (labelAmount != null)
		{
			labelAmount.text = "";
		}
		if (labelDuration != null)
		{
			labelDuration.text = "";
		}
		if (duration != null)
		{
			duration.SetActive(value: false);
		}
	}
}
