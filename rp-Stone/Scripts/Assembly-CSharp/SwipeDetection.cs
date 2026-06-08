using System;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
	private Vector2 fingerDownPos;

	private Vector2 fingerUpPos;

	public bool detectSwipeAfterRelease;

	public float SWIPE_THRESHOLD = 20f;

	private float beginTime;

	public static event Action<float> OnSwipeUp;

	public static event Action<float> OnSwipeDown;

	public static event Action<float> OnSwipeLeft;

	public static event Action<float> OnSwipeRight;

	private void Update()
	{
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			if (touch.phase == TouchPhase.Began)
			{
				fingerUpPos = touch.position;
				fingerDownPos = touch.position;
				beginTime = Time.realtimeSinceStartup;
			}
			if (touch.phase == TouchPhase.Moved && !detectSwipeAfterRelease)
			{
				fingerDownPos = touch.position;
				DetectSwipe();
			}
			if (touch.phase == TouchPhase.Ended)
			{
				fingerDownPos = touch.position;
				DetectSwipe();
			}
		}
	}

	private void DetectSwipe()
	{
		if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
		{
			Debug.Log("Vertical Swipe Detected!");
			if (fingerDownPos.y - fingerUpPos.y > 0f)
			{
				FireSwipeUp();
			}
			else if (fingerDownPos.y - fingerUpPos.y < 0f)
			{
				FireSwipeDown();
			}
			fingerUpPos = fingerDownPos;
		}
		else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
		{
			Debug.Log("Horizontal Swipe Detected!");
			if (fingerDownPos.x - fingerUpPos.x > 0f)
			{
				FireSwipeRight();
			}
			else if (fingerDownPos.x - fingerUpPos.x < 0f)
			{
				FireSwipeLeft();
			}
			fingerUpPos = fingerDownPos;
		}
		else
		{
			Debug.Log("No Swipe Detected!");
		}
	}

	private float VerticalMoveValue()
	{
		return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
	}

	private float HorizontalMoveValue()
	{
		return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
	}

	private void FireSwipeUp()
	{
		float obj = Time.realtimeSinceStartup - beginTime;
		if (SwipeDetection.OnSwipeUp != null)
		{
			SwipeDetection.OnSwipeUp(obj);
		}
	}

	private void FireSwipeDown()
	{
		float obj = Time.realtimeSinceStartup - beginTime;
		if (SwipeDetection.OnSwipeDown != null)
		{
			SwipeDetection.OnSwipeDown(obj);
		}
	}

	private void FireSwipeLeft()
	{
		float obj = Time.realtimeSinceStartup - beginTime;
		if (SwipeDetection.OnSwipeLeft != null)
		{
			SwipeDetection.OnSwipeLeft(obj);
		}
	}

	private void FireSwipeRight()
	{
		float obj = Time.realtimeSinceStartup - beginTime;
		if (SwipeDetection.OnSwipeRight != null)
		{
			SwipeDetection.OnSwipeRight(obj);
		}
	}
}
