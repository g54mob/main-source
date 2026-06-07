using UnityEngine;

[AddComponentMenu("FingerGestures/Finger Events/Finger Up Detector")]
public class FingerUpDetector : FingerEventDetector<FingerUpEvent>
{
	public string MessageName = "OnFingerUp";

	public event FingerEventHandler OnFingerUp;

	protected override void ProcessFinger(FingerGestures.Finger finger)
	{
		if (!finger.IsDown && finger.WasDown)
		{
			FingerUpEvent fingerUpEvent = GetEvent(finger);
			fingerUpEvent.Name = MessageName;
			fingerUpEvent.TimeHeldDown = Mathf.Max(0f, Time.time - finger.StarTime);
			UpdateSelection(fingerUpEvent);
			if (this.OnFingerUp != null)
			{
				this.OnFingerUp(fingerUpEvent);
			}
			TrySendMessage(fingerUpEvent);
		}
	}
}
