using System;
using UnityEngine;

[Serializable]
public class Slicer2DInputController
{
	public Slicer2DInput[] input;

	public bool multiTouch;

	private static bool useTouch;

	public void AddCompletedEvents(Slicer2DInput.InputCompleted controllerEvent, int id = 0)
	{
	}

	public bool GetVisualsEnabled(int id = 0)
	{
		return false;
	}

	public void SetVisualsState(bool state, int id = 0)
	{
	}

	public bool GetSlicingEnabled(int id = 0)
	{
		return false;
	}

	public void SetSlicingState(bool state, int id = 0)
	{
	}

	public Vector2 GetInputPosition(int id = 0)
	{
		return default(Vector2);
	}

	public bool GetInputClicked(int id = 0)
	{
		return false;
	}

	public bool GetInputPressed(int id = 0)
	{
		return false;
	}

	public bool GetInputHolding(int id = 0)
	{
		return false;
	}

	public bool GetInputReleased(int id = 0)
	{
		return false;
	}

	public void ClearActions(int id = 0)
	{
	}

	public bool Playing(int id = 0)
	{
		return false;
	}

	public void SetMouse(Vector2 position, float time, int id = 0)
	{
	}

	public void MoveMouse(Vector2 position, float time, int id = 0)
	{
	}

	public void PressMouse(float time, int id = 0)
	{
	}

	public void ReleaseMouse(float time, int id = 0)
	{
	}

	public void OnGUI()
	{
	}

	public void Update()
	{
	}

	public static Vector2 GetMousePosition()
	{
		return default(Vector2);
	}

	public static Vector2 GetTouchPosition(Vector2 touch)
	{
		return default(Vector2);
	}

	public void Update_AI(int id = 0)
	{
	}

	public void Play(int id = 0)
	{
	}

	public void Stop(int id = 0)
	{
	}

	public void Resume(int id = 0)
	{
	}

	public void SetLoop(bool l, int id = 0)
	{
	}

	public void SetRawInput(bool inp, int id = 0)
	{
	}
}
