using UnityEngine;

[AddComponentMenu("FingerGestures/Gestures/Pinch Recognizer")]
public class PinchRecognizer : ContinuousGestureRecognizer<PinchGesture>
{
	public float MinDOT = -0.7f;

	public float MinDistance = 0.25f;

	public override int RequiredFingerCount
	{
		get
		{
			return 2;
		}
		set
		{
			if (Application.isPlaying)
			{
				Debug.LogWarning("Pinch only supports 2 fingers");
			}
		}
	}

	public override bool SupportFingerClustering => false;

	public override string GetDefaultEventMessageName()
	{
		return "OnPinch";
	}

	protected override GameObject GetDefaultSelectionForSendMessage(PinchGesture gesture)
	{
		return gesture.StartSelection;
	}

	public override GestureResetMode GetDefaultResetMode()
	{
		return GestureResetMode.NextFrame;
	}

	protected override bool CanBegin(PinchGesture gesture, FingerGestures.IFingerList touches)
	{
		if (!base.CanBegin(gesture, touches))
		{
			return false;
		}
		FingerGestures.Finger finger = touches[0];
		FingerGestures.Finger finger2 = touches[1];
		float num = Vector2.SqrMagnitude(finger.StartPosition - finger2.StartPosition);
		float num2 = Vector2.SqrMagnitude(finger.Position - finger2.Position);
		if (Mathf.Abs(num - num2) < ToSqrPixels(MinDistance))
		{
			return false;
		}
		return true;
	}

	protected override void OnBegin(PinchGesture gesture, FingerGestures.IFingerList touches)
	{
		FingerGestures.Finger finger = touches[0];
		FingerGestures.Finger finger2 = touches[1];
		gesture.StartPosition = 0.5f * (finger.StartPosition + finger2.StartPosition);
		gesture.Position = 0.5f * (finger.Position + finger2.Position);
		float num = Vector2.Distance(finger.PreviousPosition, finger2.PreviousPosition);
		float num2 = Vector2.Distance(finger.Position, finger2.Position);
		gesture.Delta = num2 - num;
		gesture.Gap = num2;
	}

	protected override GestureRecognitionState OnRecognize(PinchGesture gesture, FingerGestures.IFingerList touches)
	{
		if (touches.Count != RequiredFingerCount)
		{
			gesture.Delta = 0f;
			if (touches.Count < RequiredFingerCount)
			{
				return GestureRecognitionState.Ended;
			}
			return GestureRecognitionState.Failed;
		}
		FingerGestures.Finger finger = touches[0];
		FingerGestures.Finger finger2 = touches[1];
		gesture.Position = 0.5f * (finger.Position + finger2.Position);
		float num = Vector2.Distance(finger.Position, finger2.Position);
		float num2 = num - gesture.Gap;
		gesture.Gap = num;
		if (Mathf.Abs(num2) > 0.001f)
		{
			gesture.Delta = num2;
			RaiseEvent(gesture);
		}
		return GestureRecognitionState.InProgress;
	}

	private bool FingersMovedInOppositeDirections(FingerGestures.Finger finger0, FingerGestures.Finger finger1)
	{
		return FingerGestures.FingersMovedInOppositeDirections(finger0, finger1, MinDOT);
	}
}
