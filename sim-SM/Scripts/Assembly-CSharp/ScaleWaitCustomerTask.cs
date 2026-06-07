using System;
using System.Collections.Generic;

public class ScaleWaitCustomerTask : MissionTask
{
	private readonly TutorialObjectiveDisplay m_Display;

	private readonly TutorialObjectiveData m_ObjectiveData;

	private List<DisplaySlot> m_WeightableProducts;

	public ScaleWaitCustomerTask(TutorialObjectiveDisplay display, TutorialObjectiveData objectiveData)
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

	private void OnCustomerProductCreated(object sender, EventArgs e)
	{
	}
}
