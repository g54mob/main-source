using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WorldSettingsTab : RadicalMenuOption
{
	[FormerlySerializedAs("onClick")]
	public UnityEvent onTabClicked;

	public List<GameObject> enableWhenActive;

	public List<GameObject> enableWhenInactive;

	public GameObject selectedMarker;

	public SpriteRenderer notificationIcon;

	private string _tooltip;

	protected override void Awake()
	{
		base.Awake();
		selectedMarker.SetActive(value: false);
	}

	private void OnEnable()
	{
		notificationIcon.gameObject.SetActive(value: false);
		_tooltip = null;
	}

	public void HighlightUntilActivated()
	{
		notificationIcon.gameObject.SetActive(value: true);
	}

	public void SetTooltipUntilActivated(string tooltip)
	{
		_tooltip = tooltip;
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		if (_tooltip == null)
		{
			return base.GetHoverTitle();
		}
		return new TextAndFormatFields
		{
			text = _tooltip
		};
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedMarker.SetActive(value: true);
	}

	public override void OnActivated()
	{
		notificationIcon.gameObject.SetActive(value: false);
		_tooltip = null;
		onTabClicked?.Invoke();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		selectedMarker.SetActive(value: false);
	}

	public void SetActive(bool isCurrent)
	{
		foreach (GameObject item in enableWhenActive)
		{
			item.SetActive(isCurrent);
		}
		foreach (GameObject item2 in enableWhenInactive)
		{
			item2.SetActive(!isCurrent);
		}
	}
}
