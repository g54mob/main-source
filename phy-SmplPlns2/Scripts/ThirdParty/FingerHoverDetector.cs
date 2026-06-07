using UnityEngine;

[AddComponentMenu("FingerGestures/Finger Events/Finger Hover Detector")]
public class FingerHoverDetector : FingerEventDetector<FingerHoverEvent>
{
	public string MessageName = "OnFingerHover";

	public event FingerEventHandler OnFingerHover;

	protected override void Start()
	{
		base.Start();
		if (!Raycaster)
		{
			Debug.LogWarning("FingerHoverDetector component on " + base.name + " has no Raycaster set.");
		}
	}

	private bool FireEvent(FingerHoverEvent e, FingerHoverPhase phase)
	{
		e.Name = MessageName;
		e.Phase = phase;
		if (this.OnFingerHover != null)
		{
			this.OnFingerHover(e);
		}
		TrySendMessage(e);
		return true;
	}

	protected override void ProcessFinger(FingerGestures.Finger finger)
	{
		FingerHoverEvent fingerHoverEvent = GetEvent(finger);
		GameObject previousSelection = fingerHoverEvent.PreviousSelection;
		GameObject gameObject = (finger.IsDown ? PickObject(finger.Position) : null);
		if (gameObject != previousSelection)
		{
			if ((bool)previousSelection)
			{
				FireEvent(fingerHoverEvent, FingerHoverPhase.Exit);
			}
			if ((bool)gameObject)
			{
				fingerHoverEvent.Selection = gameObject;
				fingerHoverEvent.Raycast = base.Raycast;
				FireEvent(fingerHoverEvent, FingerHoverPhase.Enter);
			}
		}
		fingerHoverEvent.PreviousSelection = gameObject;
	}
}
