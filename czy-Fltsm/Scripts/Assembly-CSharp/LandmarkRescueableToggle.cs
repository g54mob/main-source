using UnityEngine;

public class LandmarkRescueableToggle : LandmarkActionToggle
{
	[Header("Landmark Rescue Toggle")]
	[SerializeField]
	private RescuePanel _rescuePanel;

	public void Initialize(LandmarkActionRescue.Rescueable rescuable)
	{
		Initialize((ILandmarkActionToggleable)rescuable);
		_rescuePanel.ResetPanel();
		_rescuePanel.AddRescuable(rescuable.Descriptor);
	}
}
