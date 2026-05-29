using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHotbarItem : MonoBehaviour, ITooltipTitleSource, ITooltipCustomSource
{
	[SerializeField]
	private TMP_Text _text;

	[SerializeField]
	private Image _icon;

	public ItemType Contained { get; private set; }

	public void SetContainedItem(ItemType i)
	{
		Contained = i;
		_icon.sprite = i.Icon;
	}

	public void UpdateItem()
	{
		_text.text = GameMath.FormatItemCount(Contained, GamePlayer.Current.GetInventoryCount(Contained));
		((RectTransform)base.transform).sizeDelta = new Vector2((int)_text.preferredWidth + 40, 32f);
	}

	public string GetTooltipTitle()
	{
		return Contained.DisplayName;
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		tooltip.AddItemTooltip(Contained);
	}
}
