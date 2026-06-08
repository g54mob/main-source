using System;

[Serializable]
public class InteractionRestriction
{
	public bool cameraControlsAllowed;

	public bool tileControlsAllowed;

	public InteractionRestriction()
	{
		cameraControlsAllowed = true;
		tileControlsAllowed = true;
	}
}
