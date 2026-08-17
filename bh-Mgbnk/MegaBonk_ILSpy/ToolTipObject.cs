using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipObject : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public string text;

	private float hoverTimeForShow = 0.25f;

	private float startedHoveringTime;

	private bool hovering;

	private bool showed;

	public void OnPointerEnter(PointerEventData eventData)
	{
		bool flag = string.IsNullOrWhiteSpace(text);
		if (!flag && hovering == flag)
		{
			hovering = true;
			float time = Time.time;
			startedHoveringTime = time;
		}
	}

	private void Update()
	{
		if (hovering && !showed)
		{
			float time = Time.time;
			float num = time - startedHoveringTime;
			if (num > hoverTimeForShow)
			{
				showed = true;
				ToolTip.Instance.SetTip(text);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (hovering || showed)
		{
			hovering = false;
			ToolTip.Instance.HideTip();
		}
	}

	private void CloseTooltip()
	{
		if (hovering || showed)
		{
			hovering = false;
			ToolTip.Instance.HideTip();
		}
	}

	public void OnDisable()
	{
		if (hovering || showed)
		{
			hovering = false;
			ToolTip.Instance.HideTip();
		}
	}
}
