using MoreMountains.Feedbacks;
using UnityEngine;

public class NightWavePreviewCycleButton : MonoBehaviour
{
	public UIFrame frame;

	public ThronefallUIElement button;

	public PauseUILoadoutHelper target;

	public MMF_Player onIncrease;

	public MMF_Player onDecrease;

	public void Increase()
	{
		frame.Select(button);
		target.CycleNightPreview(1);
		onIncrease.PlayFeedbacks();
		frame.RefetchManagedElements();
	}

	public void Decrease()
	{
		frame.Select(button);
		target.CycleNightPreview(-1);
		onDecrease.PlayFeedbacks();
		frame.RefetchManagedElements();
	}

	public void ProcessNavigate(ThronefallUIElement.NavigationDirection direction)
	{
		switch (direction)
		{
		case ThronefallUIElement.NavigationDirection.Left:
			Decrease();
			break;
		case ThronefallUIElement.NavigationDirection.Right:
			Increase();
			break;
		}
	}
}
