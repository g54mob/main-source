using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI content;

	[SerializeField]
	private RectTransform targetRect;

	[SerializeField]
	private MMF_Player onOpen;

	[SerializeField]
	private MMF_Player onClose;

	[SerializeField]
	private MMF_Player onUpdate;

	public string currentText => content.text;

	private void Awake()
	{
		base.transform.localScale = Vector3.zero;
		content.text = "";
	}

	public void SetTooltip(string tooltipTxt)
	{
		if (tooltipTxt == content.text)
		{
			return;
		}
		onOpen.StopFeedbacks();
		onClose.StopFeedbacks();
		onUpdate.StopFeedbacks();
		content.text = tooltipTxt;
		if (tooltipTxt == "")
		{
			onClose.PlayFeedbacks();
			return;
		}
		if (content.text == "")
		{
			onOpen.PlayFeedbacks();
		}
		else
		{
			onUpdate.PlayFeedbacks();
		}
		UpdateSize();
	}

	private void UpdateSize()
	{
		RectTransform component = GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(targetRect);
		component.sizeDelta = targetRect.sizeDelta;
	}
}
