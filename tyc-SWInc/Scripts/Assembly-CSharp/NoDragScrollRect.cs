using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoDragScrollRect : ScrollRect, ICursorOverride
{
	[NonSerialized]
	private bool _updating;

	public string CursorOverrideName
	{
		get
		{
			return "Default";
		}
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
	}

	public override void OnDrag(PointerEventData eventData)
	{
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
	}

	public void OnChange(Vector2 pos)
	{
		if (_updating)
		{
			return;
		}
		_updating = true;
		float num = Mathf.Max(0f, base.content.rect.height - base.viewRect.rect.height);
		float num2 = (1f - pos.y) * num;
		float d = num2 + base.viewRect.rect.height;
		float num3 = 0f;
		for (int i = 0; i < base.content.childCount; i++)
		{
			RectTransform component = base.content.GetChild(i).GetComponent<RectTransform>();
			if (component.gameObject.activeSelf)
			{
				float a = num3;
				GUIWorkItem component2;
				WorkGroupItem component3;
				if (component.TryGetComponent<GUIWorkItem>(out component2) && component2 != null)
				{
					num3 += (float)(component2.work.Collapsed ? 43 : 128);
					component2.enabled = Utilities.RelaxedOverlap(a, num3, num2, d);
				}
				else if (component.TryGetComponent<WorkGroupItem>(out component3))
				{
					num3 += component3.GetHeight();
					component3.ToggleSubItems(Utilities.RelaxedOverlap(a, num3, num2, d));
				}
				else
				{
					num3 += component.rect.height;
				}
				num3 += 1f;
			}
		}
		_updating = false;
	}
}
