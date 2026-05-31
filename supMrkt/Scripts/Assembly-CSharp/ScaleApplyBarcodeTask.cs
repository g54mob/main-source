using System;

public class ScaleApplyBarcodeTask : MissionTask
{
	private readonly TutorialObjectiveDisplay m_Display;

	private readonly TutorialObjectiveData m_Data;

	private readonly ScaleTutorialIndicatorDisplay m_IndicatorDisplay;

	public ScaleApplyBarcodeTask(TutorialObjectiveDisplay display, TutorialObjectiveData data, ScaleTutorialIndicatorDisplay indicatorDisplay)
	{
	}

	public override void Begin()
	{
	}

	public override void Update()
	{
	}

	public override void End()
	{
	}

	private void OnScaleBarcodeDragStarted(object sender, EventArgs e)
	{
	}

	private void OnScaleBarcodeDragEnded(object sender, EventArgs e)
	{
	}

	private void OnScaleBarcodeApplied(object sender, EventArgs args)
	{
	}
}
