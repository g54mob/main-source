using System;
using Unity.Components.Events;
using UnityEngine;

public static class InputSystem
{
	public enum EventType
	{
		LeftMouseButton = 0,
		MiddleMouseButton = 1,
		RightMouseButton = 2,
		RightMouseButtonUp = 3,
		RightMouseButtonDown = 4,
		LeftMouseButtonUp = 5,
		CtrlA = 6,
		CtrlC = 7,
		CtrlV = 8,
		CtrlZ = 9,
		CtrlY = 10,
		Escape = 11,
		Space = 12,
		Enter = 13,
		Tab = 14,
		Backspace = 15,
		LeftShift = 16,
		RightShift = 17,
		MAX = 18
	}

	private class Key
	{
		public float timestamp;

		public bool pressed;

		public WeakEvent<bool, int> e = new WeakEvent<bool, int>();
	}

	public static float DoubleClickSeconds = 0.25f;

	public static float MouseWheelModifier = 1f;

	private static Key[] keys = new Key[18];

	private static WeakEvent<float> wheel = new WeakEvent<float>();

	private static Key KeyFromType(EventType type)
	{
		return keys[(int)type];
	}

	private static void HandleEvents(EventType type, bool state)
	{
		Key key = KeyFromType(type);
		if (key == null)
		{
			return;
		}
		if (state)
		{
			if (!key.pressed)
			{
				float num = Time.time - key.timestamp;
				key.timestamp = Time.time;
				key.pressed = true;
				key.e.Invoke(a1: true, (!(num <= DoubleClickSeconds)) ? 1 : 2);
			}
		}
		else if (key.pressed)
		{
			key.pressed = false;
			key.e.Invoke(a1: false, 1);
		}
	}

	public static void Init()
	{
		for (int i = 0; i < keys.Length; i++)
		{
			keys[i] = new Key();
		}
	}

	public static void Poll()
	{
		HandleEvents(EventType.LeftMouseButton, Input.GetMouseButton(0));
		HandleEvents(EventType.MiddleMouseButton, Input.GetMouseButton(2));
		HandleEvents(EventType.RightMouseButton, Input.GetMouseButton(1));
		HandleEvents(EventType.LeftMouseButtonUp, Input.GetMouseButtonUp(0));
		HandleEvents(EventType.RightMouseButtonUp, Input.GetMouseButtonUp(1));
		HandleEvents(EventType.RightMouseButtonDown, Input.GetMouseButtonDown(1));
		HandleEvents(EventType.Escape, Input.GetKey(KeyCode.Escape));
		HandleEvents(EventType.Space, Input.GetKey(KeyCode.Space));
		HandleEvents(EventType.Enter, Input.GetKey(KeyCode.Return));
		HandleEvents(EventType.Tab, Input.GetKey(KeyCode.Tab));
		HandleEvents(EventType.LeftShift, Input.GetKey(KeyCode.LeftShift));
		HandleEvents(EventType.RightShift, Input.GetKey(KeyCode.RightShift));
		HandleEvents(EventType.Backspace, Input.GetKey(KeyCode.Backspace));
		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftMeta) || Input.GetKey(KeyCode.RightMeta))
		{
			HandleEvents(EventType.CtrlA, Input.GetKey(KeyCode.A));
			HandleEvents(EventType.CtrlC, Input.GetKey(KeyCode.C));
			HandleEvents(EventType.CtrlV, Input.GetKey(KeyCode.V));
			HandleEvents(EventType.CtrlZ, Input.GetKey(KeyCode.Z));
			HandleEvents(EventType.CtrlY, Input.GetKey(KeyCode.Y));
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (axis != 0f)
		{
			wheel.Invoke(axis * MouseWheelModifier);
		}
	}

	public static void AddListener(Action<bool, int> a, EventType type)
	{
		KeyFromType(type).e.AddListener(a);
	}

	public static void RemoveListener(Action<bool, int> a, EventType type)
	{
		KeyFromType(type).e.RemoveListener(a);
	}

	public static void AddListener(Action<float> a)
	{
		wheel.AddListener(a);
	}

	public static void RemoveListener(Action<float> a)
	{
		wheel.RemoveListener(a);
	}

	public static Vector3 GetMouse(float z = 0f)
	{
		_ = Vector3.one;
		return Logic.GetMousePosition();
	}

	public static Vector3 GetCursor()
	{
		Vector3 mouse = GetMouse();
		mouse.y = (float)Screen.height - mouse.y;
		return mouse;
	}

	public static Vector3 GetMouseInWorld()
	{
		return Camera.main.ScreenToWorldPoint(GetMouse());
	}

	public static Vector3 GetCursorInWorld()
	{
		return Camera.main.ScreenToWorldPoint(GetCursor());
	}
}
