public class FinalGrowStage : ClickableObject
{
	private GardenPlot plotRef;

	public void SetPlotRef(GardenPlot plot)
	{
		plotRef = plot;
	}

	protected override void OnClickInternal()
	{
		base.OnClickInternal();
		plotRef.OnClick();
	}
}
