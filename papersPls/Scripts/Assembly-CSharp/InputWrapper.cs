using System.Collections.Generic;
using UnityEngine;

public class InputWrapper
{
	private enum Mode
	{
		None = 0,
		Mouse = 1,
		Touch = 2
	}

	public struct PointerState
	{
		public Vector3 screenPosition;

		public bool buttonDownL;

		public bool buttonDownR;

		public bool valid;

		public bool fromMouse;

		public static PointerState Invalid()
		{
			return default(PointerState);
		}
	}

	private class FingerTracker
	{
		private int[] activeFingerIds;

		public int activeCount { get; private set; }

		public void Update(Touch[] touches)
		{
		}

		private static bool HasTouchDownWithFingerId(Touch[] touches, int fingerId)
		{
			return false;
		}

		public int GetFingerId(int pointerId)
		{
			return 0;
		}

		private bool HasFingerId(int fingerId)
		{
			return false;
		}

		public void Log()
		{
		}
	}

	private Mode mode;

	private Vector3 mousePosition;

	private Vector3 preMousePosition;

	private List<PointerState> states;

	private Dictionary<int, KeyCode> keyMap;

	private FingerTracker fingerTracker;

	public void Update()
	{
	}

	public bool GetKeyState(int key)
	{
		return false;
	}

	public PointerState GetPointerState(int pointerId)
	{
		return default(PointerState);
	}

	private static bool IsTouchDown(TouchPhase phase)
	{
		return false;
	}
}
