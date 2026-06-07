using UnityEngine;

public class LandmarkActionScoutUI : LandmarkActionUI
{
	[SerializeField]
	private LandmarkActionToggle _toggle;

	public override void Initialize(ILandmarkAction action)
	{
		base.Initialize(action);
		if (action is LandmarkActionRevealMap toggleable)
		{
			_toggle.Initialize(toggleable);
		}
	}

	public override bool IsLandmarkActionUI(LandmarkAction landmarkAction)
	{
		return landmarkAction is LandmarkActionScout;
	}
}
