using Assets.Source.World;

public class UITooltipConstructionText : UITooltipItemText
{
	private ConstructionProgress _progress;

	public void Update()
	{
		_text.TL("@ConstructionProgressItem", _progress.GetConsumedCount(_item), _progress.GetRequiredCount(_item), _item.DisplayName);
	}

	public void setConstruction(ConstructionProgress construction)
	{
		_progress = construction;
	}
}
