using UnityEngine;

[AddComponentMenu("FingerGestures/Gestures/Tap Recognizer")]
public class TapRecognizer : DiscreteGestureRecognizer<TapGesture>
{
	public int RequiredTaps = 1;

	public float MoveTolerance = 0.5f;

	public float MaxDuration;

	public float MaxDelayBetweenTaps = 0.5f;

	private bool IsMultiTap => RequiredTaps > 1;

	public override bool SupportFingerClustering
	{
		get
		{
			if (IsMultiTap)
			{
				return false;
			}
			return base.SupportFingerClustering;
		}
	}

	private bool HasTimedOut(TapGesture gesture)
	{
		if (MaxDuration > 0f && gesture.ElapsedTime > MaxDuration)
		{
			return true;
		}
		if (IsMultiTap && MaxDelayBetweenTaps > 0f && Time.time - gesture.LastTapTime > MaxDelayBetweenTaps)
		{
			return true;
		}
		return false;
	}

	protected override void Reset(TapGesture gesture)
	{
		gesture.Taps = 0;
		gesture.Down = false;
		gesture.WasDown = false;
		base.Reset(gesture);
	}

	private GestureRecognitionState RecognizeSingleTap(TapGesture gesture, FingerGestures.IFingerList touches)
	{
		if (touches.Count != RequiredFingerCount)
		{
			if (touches.Count == 0)
			{
				return GestureRecognitionState.Ended;
			}
			return GestureRecognitionState.Failed;
		}
		if (HasTimedOut(gesture))
		{
			return GestureRecognitionState.Failed;
		}
		if (Vector3.SqrMagnitude(touches.GetAveragePosition() - gesture.StartPosition) >= ToSqrPixels(MoveTolerance))
		{
			return GestureRecognitionState.Failed;
		}
		return GestureRecognitionState.InProgress;
	}

	private GestureRecognitionState RecognizeMultiTap(TapGesture gesture, FingerGestures.IFingerList touches)
	{
		gesture.WasDown = gesture.Down;
		gesture.Down = false;
		if (touches.Count == RequiredFingerCount)
		{
			gesture.Down = true;
			gesture.LastDownTime = Time.time;
		}
		else if (touches.Count == 0)
		{
			gesture.Down = false;
		}
		else if (touches.Count < RequiredFingerCount)
		{
			if (Time.time - gesture.LastDownTime > 0.25f)
			{
				return GestureRecognitionState.Failed;
			}
		}
		else if (!Young(touches))
		{
			return GestureRecognitionState.Failed;
		}
		if (HasTimedOut(gesture))
		{
			return GestureRecognitionState.Failed;
		}
		if (gesture.Down && Vector3.SqrMagnitude(touches.GetAveragePosition() - gesture.StartPosition) >= ToSqrPixels(MoveTolerance))
		{
			return GestureRecognitionState.FailAndRetry;
		}
		if (gesture.WasDown != gesture.Down && !gesture.Down)
		{
			int taps = gesture.Taps + 1;
			gesture.Taps = taps;
			gesture.LastTapTime = Time.time;
			if (gesture.Taps >= RequiredTaps)
			{
				return GestureRecognitionState.Ended;
			}
		}
		return GestureRecognitionState.InProgress;
	}

	public override string GetDefaultEventMessageName()
	{
		return "OnTap";
	}

	protected override void OnBegin(TapGesture gesture, FingerGestures.IFingerList touches)
	{
		gesture.Position = touches.GetAveragePosition();
		gesture.StartPosition = gesture.Position;
		gesture.LastTapTime = Time.time;
	}

	protected override GestureRecognitionState OnRecognize(TapGesture gesture, FingerGestures.IFingerList touches)
	{
		if (!IsMultiTap)
		{
			return RecognizeSingleTap(gesture, touches);
		}
		return RecognizeMultiTap(gesture, touches);
	}
}
