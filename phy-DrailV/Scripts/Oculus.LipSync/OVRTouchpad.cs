using System;
using UnityEngine;

public static class OVRTouchpad
{
	public enum TouchEvent
	{
		SingleTap = 0,
		DoubleTap = 1,
		Left = 2,
		Right = 3,
		Up = 4,
		Down = 5
	}

	public delegate void OVRTouchpadCallback<TouchEvent>(TouchEvent arg);

	private static Vector3 moveAmountMouse;

	private static float minMovMagnitudeMouse = 25f;

	public static Delegate touchPadCallbacks = null;

	private static OVRTouchpadHelper touchpadHelper = new GameObject("OVRTouchpadHelper").AddComponent<OVRTouchpadHelper>();

	public static void Create()
	{
	}

	public static void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			moveAmountMouse = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			moveAmountMouse -= Input.mousePosition;
			HandleInputMouse(ref moveAmountMouse);
		}
	}

	public static void OnDisable()
	{
	}

	private static void HandleInputMouse(ref Vector3 move)
	{
		if ((object)touchPadCallbacks == null)
		{
			return;
		}
		OVRTouchpadCallback<TouchEvent> oVRTouchpadCallback = touchPadCallbacks as OVRTouchpadCallback<TouchEvent>;
		if (move.magnitude < minMovMagnitudeMouse)
		{
			oVRTouchpadCallback(TouchEvent.SingleTap);
			return;
		}
		move.Normalize();
		if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
		{
			if (move.x > 0f)
			{
				oVRTouchpadCallback(TouchEvent.Left);
			}
			else
			{
				oVRTouchpadCallback(TouchEvent.Right);
			}
		}
		else if (move.y > 0f)
		{
			oVRTouchpadCallback(TouchEvent.Down);
		}
		else
		{
			oVRTouchpadCallback(TouchEvent.Up);
		}
	}

	public static void AddListener(OVRTouchpadCallback<TouchEvent> handler)
	{
		touchPadCallbacks = (OVRTouchpadCallback<TouchEvent>)Delegate.Combine((OVRTouchpadCallback<TouchEvent>)touchPadCallbacks, handler);
	}
}
