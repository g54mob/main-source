using System;

[Serializable]
public class SideJobSabotage : SideJob
{
	public NewAddress chosenAddress;

	public float callTime;

	private bool callTriggered;

	private TelephoneController.PhoneCall call;

	private Objective.ObjectiveTrigger getToPhone;

	public SideJobSabotage(JobPreset newPreset, SideJobController.JobPickData newData, bool immediatePost)
		: base(null, null, immediatePost: false)
	{
	}

	public override void GameWorldLoop()
	{
	}

	public override void UpdateResolveAnswers()
	{
	}
}
