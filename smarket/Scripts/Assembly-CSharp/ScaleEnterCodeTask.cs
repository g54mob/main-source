using System;

public class ScaleEnterCodeTask : MissionTask
{
	private readonly TutorialObjectiveDisplay m_Display;

	private readonly TutorialObjectiveData m_Data;

	private readonly ScaleTutorialIndicatorDisplay m_IndicatorDisplay;

	public ScaleEnterCodeTask(TutorialObjectiveDisplay display, TutorialObjectiveData data, ScaleTutorialIndicatorDisplay indicatorDisplay)
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

	private void OnScaleBarcodeCreated(object sender, EventArgs e)
	{
	}
}
