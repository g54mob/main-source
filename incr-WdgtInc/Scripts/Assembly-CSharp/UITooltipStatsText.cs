using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using UnityEngine;

public class UITooltipStatsText : UITooltipText
{
	private ItemType _item;

	private UITooltipStatsType _type;

	private float _updateTimer;

	public void Update()
	{
		_updateTimer -= Time.deltaTime;
		if (_updateTimer <= 0f)
		{
			if (_type == UITooltipStatsType.Production)
			{
				_text.TL("@InventoryProduction", GameMath.FormatNumber(GamePlayer.Current.GetProductionStats(_item), 1));
			}
			else if (_type == UITooltipStatsType.Consumption)
			{
				_text.TL("@InventoryConsumption", GameMath.FormatNumber(GamePlayer.Current.GetConsumptionStats(_item), 1));
			}
			else
			{
				BigInteger inventoryCount = GamePlayer.Current.GetInventoryCount(_item);
				_text.text = Translation.Highlight("@InventoryInStorage", (inventoryCount == 0L) ? "red" : "#00bb00", GameMath.FormatItemCount(_item, inventoryCount));
			}
			_updateTimer = 0.5f;
		}
	}

	public void SetItem(ItemType item, UITooltipStatsType type)
	{
		_item = item;
		_type = type;
	}
}
