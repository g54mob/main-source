using UnityEngine;

public class JoyWtlInput : MonoBehaviour
{
	public bool inited;

	public bool anyInputThisFrame;

	public float zoomOut;

	public float zoomIn;

	public bool copy;

	public bool paste;

	public bool pressCursor;

	public bool undo;

	public bool redo;

	public bool cursorMoveStart;

	public bool cursorMove;

	public bool cursorMoveEnd;

	public Vector3 cursorDelta = Vector2.one;

	public bool areaMoveStart;

	public bool areaMove;

	public bool areaMoveEnd;

	public Vector3 areaMoveDelta = Vector2.one;

	public bool lmbDown;

	public bool lmbUp;

	public bool lmbPressed;

	public bool xDown;

	public bool xUp;

	public bool xPressed;

	public bool yDown;

	public bool yUp;

	public bool yPressed;

	public bool bDown;

	public bool bUp;

	public bool bPressed;

	public bool dragStart;

	public bool drag;

	public bool dragEnd;

	public float cursorCoef = 1f;

	public bool cursorDoubleClickDown;

	public bool cursorDoubleClickUp;

	public float multiTapWaitTime = 0.3f;

	public bool leftArrow;

	public bool rightArrow;

	public bool upArrow;

	public bool downArrow;

	public bool hardAreaMoveStartX;

	public bool hardAreaMoveStartY;

	public bool hardAreaMoveX;

	public bool hardAreaMoveY;

	public virtual void Init()
	{
	}

	public virtual float GetCurCursorMulty()
	{
		return 1f;
	}

	public virtual void Vibrate(bool vibrate = true)
	{
	}
}
