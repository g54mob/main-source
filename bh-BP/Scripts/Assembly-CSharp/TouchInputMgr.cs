using System.Collections.Generic;
using UnityEngine;

public class TouchInputMgr : MonoBehaviour
{
	public static TouchInputMgr I;

	public List<TouchInfo> ActiveTouches;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void MyUpdate()
	{
	}

	private void OnApplicationPause(bool pauseStatus)
	{
	}

	public TouchInfo GetActiveTouchById(int id)
	{
		return null;
	}

	private int GetActiveTouchIdx(Touch t)
	{
		return 0;
	}

	public bool IsAnyTouchDown()
	{
		return false;
	}

	public bool IsAnyTouchHeld()
	{
		return false;
	}

	public bool IsSingleTouchDown()
	{
		return false;
	}

	public bool IsSingleTouchHeld()
	{
		return false;
	}

	public bool IsSingleTouchUp()
	{
		return false;
	}

	public TouchInfo GetFirstTouch()
	{
		return null;
	}

	public bool IsDoubleTouchDown()
	{
		return false;
	}

	public bool IsDoubleTouchHeld()
	{
		return false;
	}

	public bool IsAnyTouchUp()
	{
		return false;
	}

	public bool IsDoubleTouchUp()
	{
		return false;
	}

	public float GetDoubleTouchDeltaPos()
	{
		return 0f;
	}

	public Vector2 GetMultiTouchCenter()
	{
		return default(Vector2);
	}

	public bool IsTouchOverUIObject(Touch t)
	{
		return false;
	}

	public Touch CreateTouchFromMouse(int id, TouchPhase ph)
	{
		return default(Touch);
	}
}
