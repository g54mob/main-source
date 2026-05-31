using Assets.Source.Item;
using UnityEngine;
using UnityEngine.UI;

public class UITooltipItemText : UITooltipText
{
	[SerializeField]
	private Image _icon;

	protected ItemType _item;

	public override float Height => Mathf.Max(_text.preferredHeight, _icon.rectTransform.sizeDelta.y) + _spacing;

	public void SetItem(ItemType item)
	{
		_item = item;
		_icon.sprite = item.Icon;
	}
}
