using System;

[Serializable]
public class SideJobAffair : SideJob
{
	public SideJobAffair(JobPreset newPreset, SideJobController.JobPickData newData, bool immediatePost)
		: base(null, null, immediatePost: false)
	{
	}
}
