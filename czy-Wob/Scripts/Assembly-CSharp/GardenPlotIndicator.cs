public class GardenPlotIndicator : WorldSpaceBillboard
{
	private float defaultYOffset = 2f;

	private float finalStageYOffset = 6f;

	private GardenPlot plotRef;

	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
		SetDefaultOffset();
	}

	public void SetGardenPlotRef(GardenPlot newRef)
	{
		plotRef = newRef;
	}

	public void SetDefaultOffset()
	{
		worldspaceOffset.y = defaultYOffset;
	}

	public void SetFinalStageOffset()
	{
		worldspaceOffset.y = finalStageYOffset;
	}

	public void OnClick()
	{
		plotRef.OnClick();
	}
}
