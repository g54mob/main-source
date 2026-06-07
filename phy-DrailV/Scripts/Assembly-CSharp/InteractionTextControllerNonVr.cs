using DV;
using DV.UI;
using DV.Utils;
using TMPro;
using UnityEngine;

public class InteractionTextControllerNonVr : SingletonBehaviour<InteractionTextControllerNonVr>
{
	private const float DISAPPEAR_DELAY = 0.1f;

	public TextMeshProUGUI uiText;

	public TextMeshProUGUI uiOutlineText;

	private float lastTimeUpdated;

	private string currentText = string.Empty;

	protected override void Awake()
	{
		base.Awake();
		DisplayText(InteractionInfoType.Cleared);
		if (SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.Crosshair, out var element))
		{
			Transform parent = element.reference.transform;
			base.transform.SetParent(parent, worldPositionStays: false);
			if (TryGetComponent<NestedCanvas>(out var component))
			{
				component.ResetRectTransform();
			}
		}
	}

	public void DisplayText(InteractionInfoType infoType)
	{
		lastTimeUpdated = Time.realtimeSinceStartup;
		SetText(SingletonBehaviour<InteractionText>.Instance.GetText(infoType));
	}

	public void DisplayText(string textToDisplay)
	{
		lastTimeUpdated = Time.realtimeSinceStartup;
		SetText(textToDisplay);
	}

	private void SetText(string textStr)
	{
		currentText = textStr;
		uiText.text = currentText;
		uiOutlineText.text = currentText;
	}

	private void Update()
	{
		if (!string.IsNullOrEmpty(currentText) && Time.realtimeSinceStartup > lastTimeUpdated + 0.1f)
		{
			DisplayText(InteractionInfoType.Cleared);
		}
	}
}
