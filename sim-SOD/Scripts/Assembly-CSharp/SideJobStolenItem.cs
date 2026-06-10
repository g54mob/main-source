using System;
using UnityEngine;

[Serializable]
public class SideJobStolenItem : SideJob
{
	[Header("Serialized Data")]
	public float theftTime;

	public float theftTimeFrom;

	public float theftTimeTo;

	public int stolenItemRoom;

	public SideJobStolenItem(JobPreset newPreset, SideJobController.JobPickData newData, bool immediatePost)
		: base(null, null, immediatePost: false)
	{
	}

	public void SimulateTheft()
	{
	}

	public override void Complete()
	{
	}

	public void ReturnItem()
	{
	}

	public override void DebugDisplayAnswers()
	{
	}

	public override void OnAcquireJobInfo(string infoDialogMessage)
	{
	}
}
