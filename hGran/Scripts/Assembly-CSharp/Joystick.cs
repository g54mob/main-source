using System;
using UnityEngine;

[Serializable]
public class Joystick : MonoBehaviour
{
	private static Joystick[] joysticks;

	private static bool enumeratedJoysticks;

	private static float tapTimeDelta;

	public bool touchPad;

	public Rect touchZone;

	public Vector2 deadZone;

	public bool normalize;

	public Vector2 position;

	public int tapCount;

	private int lastFingerId;

	private float tapTimeWindow;

	private Vector2 fingerDownPos;

	private float fingerDownTime;

	private float firstDeltaTime;

	private Rect defaultRect;

	private Boundary guiBoundary;

	private Vector2 guiTouchOffset;

	private Vector2 guiCenter;

	public bool havestopped;

	public GameObject footstepScriptHolder;

	public GameObject JoystickBase;

	public GameObject joystickCircle;

	public virtual void Start()
	{
	}

	public virtual void Disable()
	{
	}

	public virtual void ResetJoystick()
	{
	}

	public virtual bool IsFingerDown()
	{
		return false;
	}

	public virtual void LatchedFinger(int fingerId)
	{
	}

	public virtual void Update()
	{
	}

	static Joystick()
	{
	}
}
