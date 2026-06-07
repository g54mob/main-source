public abstract class ContinuousGestureRecognizer<T> : GestureRecognizerTS<T> where T : ContinuousGesture, new()
{
	protected override void Reset(T gesture)
	{
		base.Reset(gesture);
	}

	protected override void OnStateChanged(Gesture sender)
	{
		base.OnStateChanged(sender);
		T val = (T)sender;
		switch (val.State)
		{
		case GestureRecognitionState.Started:
			RaiseEvent(val);
			break;
		case GestureRecognitionState.Ended:
			RaiseEvent(val);
			break;
		case GestureRecognitionState.Failed:
			if (val.PreviousState != GestureRecognitionState.Ready)
			{
				RaiseEvent(val);
			}
			break;
		case GestureRecognitionState.InProgress:
			break;
		}
	}
}
