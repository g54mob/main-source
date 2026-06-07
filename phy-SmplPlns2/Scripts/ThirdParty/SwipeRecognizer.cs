using UnityEngine;

[AddComponentMenu("FingerGestures/Gestures/Swipe Recognizer")]
public class SwipeRecognizer : DiscreteGestureRecognizer<SwipeGesture>
{
	private FingerGestures.SwipeDirection ValidDirections = FingerGestures.SwipeDirection.All;

	public float MinDistance = 0.5f;

	public float MaxDistance;

	public float MinVelocity = 5f;

	public float MaxDeviation = 25f;

	public override string GetDefaultEventMessageName()
	{
		return "OnSwipe";
	}

	protected override bool CanBegin(SwipeGesture gesture, FingerGestures.IFingerList touches)
	{
		if (!base.CanBegin(gesture, touches))
		{
			return false;
		}
		if (touches.GetAverageDistanceFromStart() < 0.5f)
		{
			return false;
		}
		if (!touches.AllMoving())
		{
			return false;
		}
		if (!touches.MovingInSameDirection(0.35f))
		{
			return false;
		}
		return true;
	}

	protected override void OnBegin(SwipeGesture gesture, FingerGestures.IFingerList touches)
	{
		gesture.StartPosition = touches.GetAverageStartPosition();
		gesture.Position = touches.GetAveragePosition();
		gesture.Move = Vector3.zero;
		gesture.MoveCounter = 0;
		gesture.Deviation = 0f;
		gesture.Direction = FingerGestures.SwipeDirection.None;
	}

	protected override GestureRecognitionState OnRecognize(SwipeGesture gesture, FingerGestures.IFingerList touches)
	{
		float num = ToPixels(MinDistance);
		float num2 = ToPixels(MaxDistance);
		if (touches.Count != RequiredFingerCount)
		{
			if (touches.Count > RequiredFingerCount)
			{
				return GestureRecognitionState.Failed;
			}
			if (gesture.Move.magnitude < Mathf.Max(1f, num))
			{
				return GestureRecognitionState.Failed;
			}
			gesture.Direction = FingerGestures.GetSwipeDirection(gesture.Move);
			return GestureRecognitionState.Ended;
		}
		Vector2 move = gesture.Move;
		gesture.Position = touches.GetAveragePosition();
		gesture.Move = gesture.Position - gesture.StartPosition;
		float magnitude = gesture.Move.magnitude;
		if (num2 > num && magnitude > num2)
		{
			return GestureRecognitionState.Failed;
		}
		if (gesture.ElapsedTime > 0f)
		{
			gesture.Velocity = magnitude / gesture.ElapsedTime;
		}
		else
		{
			gesture.Velocity = 0f;
		}
		if (gesture.MoveCounter > 2 && gesture.Velocity < ToPixels(MinVelocity))
		{
			return GestureRecognitionState.Failed;
		}
		if (magnitude > 50f && gesture.MoveCounter > 2)
		{
			gesture.Deviation += 57.29578f * FingerGestures.SignedAngle(move, gesture.Move);
			if (Mathf.Abs(gesture.Deviation) > MaxDeviation)
			{
				return GestureRecognitionState.Failed;
			}
		}
		gesture.MoveCounter++;
		return GestureRecognitionState.InProgress;
	}

	public bool IsValidDirection(FingerGestures.SwipeDirection dir)
	{
		if (dir == FingerGestures.SwipeDirection.None)
		{
			return false;
		}
		return (ValidDirections & dir) == dir;
	}
}
