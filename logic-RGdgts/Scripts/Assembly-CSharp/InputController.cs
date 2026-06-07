using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class InputController : Controller
{
	public Camera mainCamera;

	private static Player input;

	public static bool isActive;

	private static Vector3 worldMousePosition;

	private static Dictionary<RewiredEnum, int> fakeButtonDown;

	private static HashSet<RewiredEnum> fakeButtonUp;

	private static HashSet<RewiredEnum> scheduledFakeButtonDown;

	private static HashSet<RewiredEnum> scheduledFakeButtonUp;

	private static bool focusClicking;

	private static int focusClickDownSimulated;

	private static int focusClickUpSimulated;

	public static InputController instance { get; private set; }

	public override void Init()
	{
	}

	private void Update()
	{
	}

	private void OnApplicationFocus(bool focus)
	{
	}

	private IEnumerator FocusC()
	{
		return null;
	}

	private void UpdateFakeEvents()
	{
	}

	private void RefreshWorldMousePosition()
	{
	}

	public static void OnFakeButtonDown(RewiredEnum button)
	{
	}

	public static void OnFakeButtonUp(RewiredEnum button)
	{
	}

	public static void OnCameraMovement()
	{
	}

	public static Vector3 GetWorldMousePosition()
	{
		return default(Vector3);
	}

	public static bool GetButton(RewiredEnum action)
	{
		return false;
	}

	public static bool GetButtonDown(RewiredEnum action)
	{
		return false;
	}

	public static bool GetButtonUp(RewiredEnum action)
	{
		return false;
	}

	public static float GetAxis(RewiredEnum action)
	{
		return 0f;
	}

	public static float GetAxisDelta(RewiredEnum action)
	{
		return 0f;
	}

	public static Vector2 GetAxis2D(RewiredEnum actionX, RewiredEnum actionY)
	{
		return default(Vector2);
	}
}
