using UnityEngine;

[AddComponentMenu("FingerGestures/Finger Events/Finger Down Detector")]
public class FingerDownDetector : FingerEventDetector<FingerDownEvent>
{
	public string MessageName = "OnFingerDown";

	public event FingerEventHandler OnFingerDown;

	protected override void ProcessFinger(FingerGestures.Finger finger)
	{
		if (finger.IsDown && !finger.WasDown)
		{
			FingerDownEvent fingerDownEvent = GetEvent(finger.Index);
			fingerDownEvent.Name = MessageName;
			UpdateSelection(fingerDownEvent);
			if (this.OnFingerDown != null)
			{
				this.OnFingerDown(fingerDownEvent);
			}
			TrySendMessage(fingerDownEvent);
		}
	}
}
