using System;
using System.Runtime.CompilerServices;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class MovementInputHandler : MonoBehaviour
{
	public float MouseMovementAreaSize;

	public static Vector2 MovementDirection;

	public static float MovementSpeedModifier;

	public static BoolContainer CursorMovementActive;

	public static bool SprintingToggling;

	public static BoolContainer Sprinting;

	public static MovementInputHandler Instance;

	public static event Action<Vector2, float> AnnounceMovement
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void OnCursorMoveStart()
	{
	}

	public void OnCursorMovePerformed()
	{
	}

	public Vector2 GetEdgeScrollVector()
	{
		return default(Vector2);
	}

	public void OnToggleSprintToggleSetting(bool value)
	{
	}

	private void OnSprintingStart()
	{
	}

	private void OnSprintingPerformed()
	{
	}

	public void ToggleSprinting()
	{
	}
}
