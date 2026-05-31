using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using Assets.Source.World;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TMP_Text _text;

	[SerializeField]
	private Image _statusIcon;

	[SerializeField]
	private Image _fill;

	private ItemType _item;

	private float _updateTimer;

	private void Update()
	{
		_updateTimer -= Time.deltaTime;
		if (_updateTimer < 0f)
		{
			_updateTimer = 0.5f;
			int inventoryCount = GamePlayer.Current.GetInventoryCount(_item);
			_text.text = _item.DisplayName + " " + UIHelper.HighlightText(GameMath.FormatItemCount(_item, inventoryCount)) + "\nProduction: " + UIHelper.HighlightText(GameMath.FormatNumber(GamePlayer.Current.GetProductionStats(_item), 1) + "/s") + "\nConsumption: " + UIHelper.HighlightText(GameMath.FormatNumber(GamePlayer.Current.GetConsumptionStats(_item), 1) + "/s");
			float num = Mathf.Clamp01((float)inventoryCount / (float)GamePlayer.Current.GetInventoryCapacity(_item));
			_fill.rectTransform.localScale = new Vector3(1f, num, 1f);
			_fill.color = Color.Lerp(Color.red, Color.green, num);
		}
	}

	public void SetItem(ItemType item)
	{
		_item = item;
		_icon.sprite = item.Icon;
		Update();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		CraftingFrame recipe = _item.Recipe;
		if (recipe == null)
		{
			return;
		}
		foreach (WorldFrame frame in WorldMap.Current.Frames)
		{
			if (recipe.Identifier == frame.Identifier)
			{
				UISounds.TurnPage();
				WorldManager.Instance.ShowFrame(frame, showUI: true);
				GameUI.Inventory.Hide();
				break;
			}
		}
	}
}
