using System;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.UI;
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
			string text = _type switch
			{
				UITooltipStatsType.Production => "Production: " + UIHelper.HighlightText(GameMath.FormatNumber(GamePlayer.Current.GetProductionStats(_item), 1) + "/s"), 
				UITooltipStatsType.Consumption => "Consumption: " + UIHelper.HighlightText(GameMath.FormatNumber(GamePlayer.Current.GetConsumptionStats(_item), 1) + "/s"), 
				UITooltipStatsType.Total => "In storage: " + UIHelper.HighlightText(GameMath.FormatItemCount(_item, GamePlayer.Current.GetInventoryCount(_item))), 
				_ => throw new NotImplementedException(), 
			};
			_text.text = text;
			_updateTimer = 0.5f;
		}
	}

	public void SetItem(ItemType item, UITooltipStatsType type)
	{
		_item = item;
		_type = type;
	}
}
