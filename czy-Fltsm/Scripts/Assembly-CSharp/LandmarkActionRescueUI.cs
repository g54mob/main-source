using System.Collections.Generic;
using UnityEngine;

public class LandmarkActionRescueUI : LandmarkActionUI
{
	[SerializeField]
	private ChildBehaviourCache<LandmarkRescueableToggle> _toggleCache;

	public void Initialize(LandmarkActionRescue action)
	{
		base.Initialize(action);
		InitializeToggles(action.Rescueables);
	}

	private void InitializeToggles(List<LandmarkActionRescue.Rescueable> rescueables)
	{
		_toggleCache.Reset();
		foreach (LandmarkActionRescue.Rescueable rescueable in rescueables)
		{
			if ((bool)rescueable.Actor)
			{
				_toggleCache.Get().Initialize(rescueable);
			}
		}
		_toggleCache.Trim();
	}

	public override bool IsLandmarkActionUI(LandmarkAction landmarkAction)
	{
		if (!(landmarkAction is LandmarkActionRescue))
		{
			return landmarkAction is LandmarkActionAnimalRescue;
		}
		return true;
	}
}
