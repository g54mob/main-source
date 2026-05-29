using Assets.Source.UI;
using Assets.Source.Util;
using Assets.Source.World;

public class UITooltipConstructionText : UITooltipItemText
{
	private ConstructionProgress _progress;

	public void Update()
	{
		_text.text = UIHelper.HighlightText(GameMath.FormatNumber(_progress.GetConsumedCount(_item)) + "/" + GameMath.FormatNumber(_progress.GetRequiredCount(_item))) + " " + _item.DisplayName;
	}

	public void setConstruction(ConstructionProgress construction)
	{
		_progress = construction;
	}
}
