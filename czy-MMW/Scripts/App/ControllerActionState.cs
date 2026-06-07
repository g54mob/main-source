using System;
using UnityEngine;

public class ControllerActionState : IComparable<ControllerActionState>
{
	public bool BoolValue { get; protected set; }

	public Vector2 Vector2Value { get; protected set; }

	protected ControllerActionState()
	{
	}

	public static ControllerActionState CreateBoolActionState(bool boolValue)
	{
		return new ControllerActionState
		{
			BoolValue = boolValue
		};
	}

	public static ControllerActionState CreateVector2ActionState(bool boolValue, Vector2 vectorValue)
	{
		return new ControllerActionState
		{
			BoolValue = boolValue,
			Vector2Value = vectorValue
		};
	}

	public int CompareTo(ControllerActionState other)
	{
		return BoolValue.CompareTo(other.BoolValue);
	}
}
