using UnityEngine;
using UnityEngine.EventSystems;

public class GUIToolTipper : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	public string ToolTipValue;

	[TextArea(3, 10)]
	public string TooltipDescription;

	public bool Localize = true;

	public bool TryLoc;

	public bool OnlyLocalizeDescription;

	public string KeyValue;

	public bool Disabled;

	public void OnPointerEnter(PointerEventData d)
	{
		if (!Disabled)
		{
			SetTip();
		}
	}

	private void SetTip()
	{
		Tooltip.SetToolTip(GetTitle(), (!Localize) ? TooltipDescription : (TryLoc ? TooltipDescription.LocTry() : TooltipDescription.LocColor()), GetComponent<RectTransform>());
	}

	private string GetTitle()
	{
		string text = ((!(Localize ^ OnlyLocalizeDescription)) ? ToolTipValue : (TryLoc ? ToolTipValue.LocTry() : ToolTipValue.Loc()));
		if (!string.IsNullOrEmpty(KeyValue))
		{
			string fullKeyBindString = InputController.GetFullKeyBindString(InputController.GetKeyNum(KeyValue), false, true);
			if (fullKeyBindString != null)
			{
				if (string.IsNullOrEmpty(text))
				{
					return fullKeyBindString;
				}
				return text + "(" + fullKeyBindString + ")";
			}
		}
		return text;
	}

	public void UpdateTip()
	{
		RectTransform component = GetComponent<RectTransform>();
		if (component != null && Tooltip.CurrentRect == component)
		{
			SetTip();
		}
	}
}
