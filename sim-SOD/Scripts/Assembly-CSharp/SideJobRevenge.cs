using System;

[Serializable]
public class SideJobRevenge : SideJob
{
	public SideJobRevenge(JobPreset newPreset, SideJobController.JobPickData newData, bool immediatePost)
		: base(null, null, immediatePost: false)
	{
	}
}
