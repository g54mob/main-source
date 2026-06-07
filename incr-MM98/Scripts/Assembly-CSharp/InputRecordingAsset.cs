using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Testing/Input Recording", menuName = "Testing/Input Recording")]
public class InputRecordingAsset : ScriptableObject
{
	[Serializable]
	public struct Sample
	{
		public double time;

		public Vector2 position;

		public Vector2 delta;

		public bool leftDown;

		public bool leftPressed;

		public bool leftReleased;
	}

	public ulong seed0;

	public ulong seed1;

	public ulong seed2;

	public ulong seed3;

	public List<Sample> samples = new List<Sample>();

	public void Track(double time, Mouse mouse)
	{
		samples.Add(new Sample
		{
			time = time,
			position = mouse.position.value,
			delta = mouse.delta.value,
			leftDown = mouse.leftButton.isPressed,
			leftPressed = mouse.leftButton.wasPressedThisFrame,
			leftReleased = mouse.leftButton.wasReleasedThisFrame
		});
	}

	public void Clear()
	{
		samples.Clear();
	}
}
