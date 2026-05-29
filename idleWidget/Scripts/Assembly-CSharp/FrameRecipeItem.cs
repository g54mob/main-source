using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.World;
using TMPro;
using UnityEngine;

public class FrameRecipeItem : MonoBehaviour, ITooltipTitleSource, ITooltipCustomSource
{
	[SerializeField]
	private SpriteRenderer _icon;

	[SerializeField]
	private string _itemName;

	[SerializeField]
	private TMP_Text _itemCount;

	[SerializeField]
	private SpriteRenderer _warning;

	private ItemType _item;

	private int _required;

	private void Start()
	{
		_item = _itemName;
		_icon.sprite = _item.Icon;
		if (_itemCount.gameObject.activeSelf)
		{
			_required = int.Parse(_itemCount.text);
		}
		else
		{
			_required = 1;
		}
	}

	private void Update()
	{
		_warning.gameObject.SetActive(GamePlayer.Current.GetInventoryCount(_item) < _required);
	}

	public string GetTooltipTitle()
	{
		return _item.DisplayName;
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		tooltip.AddItemTooltip(_item);
	}

	private void OnMouseUpAsButton()
	{
		CraftingFrame recipe = _item.Recipe;
		if (recipe != null)
		{
			foreach (WorldFrame frame in WorldMap.Current.Frames)
			{
				if (recipe.Identifier == frame.Identifier)
				{
					UISounds.TurnPage();
					WorldManager.Instance.ShowFrame(frame, showUI: true);
					return;
				}
			}
		}
		OverviewUI.Instance.ToggleBuildMenu();
	}
}
