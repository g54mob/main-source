public abstract class DiscreteGestureRecognizer<T> : GestureRecognizerTS<T> where T : DiscreteGesture, new()
{
	protected override void OnStateChanged(Gesture sender)
	{
		base.OnStateChanged(sender);
		T val = (T)sender;
		if (val.State == GestureRecognitionState.Ended)
		{
			RaiseEvent(val);
		}
	}
}
