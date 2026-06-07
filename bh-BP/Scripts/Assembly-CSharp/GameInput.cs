using UnityEngine;

public static class GameInput
{
	public static bool GetMouseOrTouch()
	{
		return false;
	}

	public static bool GetMouseOrTouchDown()
	{
		return false;
	}

	public static bool GetMouseOrTouchUp()
	{
		return false;
	}

	public static Vector2 GetMouseOrTouchPosition()
	{
		return default(Vector2);
	}

	public static bool GetRightMouseOrTouchDown()
	{
		return false;
	}

	public static bool GetRightMouseOrTouchUp()
	{
		return false;
	}

	public static bool IsTouchAtPhase(int fingerId, TouchPhase phase)
	{
		return false;
	}

	public static Touch GetFirstPressedTouch()
	{
		return default(Touch);
	}

	public static Touch GetFirstTouchInPhaseOnSide(TouchPhase phase, bool isLeft)
	{
		return default(Touch);
	}

	public static bool IsTouchPressed(int fingerId)
	{
		return false;
	}

	public static bool IsTouchHeld(int fingerId)
	{
		return false;
	}

	public static bool IsTouchUp(int fingerId)
	{
		return false;
	}

	public static float GetTouchDeadzoneRadius()
	{
		return 0f;
	}

	public static float GetTouchStickRadius(bool isRight)
	{
		return 0f;
	}

	public static Touch GetTouch(int id)
	{
		return default(Touch);
	}

	public static Touch CreateNullTouch()
	{
		return default(Touch);
	}
}
