using System;

public class ClassIconButtonController : ButtonController
{
	[NonSerialized]
	public Fact connectionFact;

	[NonSerialized]
	public Evidence evidenceEntry;

	public void Setup(Evidence newEvidenceEntry, InfoWindow newParentWindow, Fact newFact)
	{
	}

	public override void VisualUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	public override void OnLeftDoubleClick()
	{
	}

	public override void UpdateTooltipText()
	{
	}
}
