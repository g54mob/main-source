using System;
using UnityEngine;

[Serializable]
public class SideJobMissingPerson : SideJob
{
	[Header("Saved Values")]
	public bool readyToPost;

	[Header("Unsaved Values")]
	private NewAIGoal exitBuilding;

	public SideJobMissingPerson(JobPreset newPreset, SideJobController.JobPickData newData, bool immediatePost)
		: base(null, null, immediatePost: false)
	{
	}

	public override void PostJob()
	{
	}

	public override void AcceptJob()
	{
	}

	public override void GameWorldLoop()
	{
	}
}
