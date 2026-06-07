using Assets.Source.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipSource : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private string _title;

	[SerializeField]
	private string _bodyText;

	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			_title = value;
		}
	}

	public string BodyText
	{
		get
		{
			return _bodyText;
		}
		set
		{
			_bodyText = value;
		}
	}

	public virtual string GetTitle()
	{
		if (string.IsNullOrEmpty(_title))
		{
			return GetComponentInParent<ITooltipTitleSource>()?.GetTooltipTitle();
		}
		return _title;
	}

	public virtual string GetBodyText()
	{
		if (string.IsNullOrEmpty(_bodyText))
		{
			return GetComponentInParent<ITooltipTextSource>()?.GetTooltipText();
		}
		return _bodyText;
	}

	public virtual void AddCustomContent(UITooltip tooltip)
	{
		GetComponentInParent<ITooltipCustomSource>()?.AddTooltipCustomContent(tooltip);
	}

	private void OnDisable()
	{
		UITooltip.Hide(this);
	}

	private void OnDestroy()
	{
		UITooltip.Hide(this);
	}

	private void OnMouseEnter()
	{
		if (base.isActiveAndEnabled && !UIHelper.IsMouseOverUi)
		{
			UITooltip.Show(this);
		}
	}

	private void OnMouseExit()
	{
		UITooltip.Hide(this);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		UITooltip.Show(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UITooltip.Hide(this);
	}
}
