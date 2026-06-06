using System;
using System.Collections.Generic;
using UnityEngine;
using ZLinq;

public class OperationInstance
{
	public readonly string Guid;

	public readonly Operation Operation;

	public float Time;

	public float Duration;

	public readonly List<Modifier> AvailableModifiers;

	public float NormalizedTime => Mathf.Clamp01(Time / Duration);

	public bool Done => Time >= Duration;

	public OperationInstance(OperationData operation)
	{
		Guid = System.Guid.NewGuid().ToString();
		Operation = operation;
		Time = 0f;
		Duration = Database.Commands.Operations.CalculateDuration(operation);
		AvailableModifiers = (from x in operation.modifiers.AsValueEnumerable()
			select x.modifier).ToList();
	}

	public OperationInstance(OperationData operation, float time, float duration)
	{
		Guid = System.Guid.NewGuid().ToString();
		Operation = operation;
		Time = time;
		Duration = duration;
		AvailableModifiers = (from x in operation.modifiers.AsValueEnumerable()
			select x.modifier).ToList();
	}

	public virtual void AdvanceTime(float deltaTime)
	{
		Time += deltaTime;
	}
}
