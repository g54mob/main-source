using System.Collections.Generic;
using UnityEngine;

public class AccumulatorInstruction : Instruction
{
	public enum ValueTypeEnum
	{
		Constant = 0,
		IO = 1
	}

	public SocketIO SocketInput => GetSocketIO(0);

	public SocketIO SocketValueIO => GetSocketIO(1);

	public ValueTypeEnum ValueType { get; set; }

	public float Value { get; set; }

	public AccumulatorInstruction(Logic parentLogic)
		: base(parentLogic)
	{
		base.Type = InstructionType.Accumulator;
		ValueType = ValueTypeEnum.Constant;
		Value = 0f;
		SocketInput.Accessibility = SocketIOAccessibility.Writable;
	}

	public override IEnumerable<int> Execute()
	{
		if (SocketInput.LogicIO != null && SocketInput.LogicIO.Direction == LogicIODirection.Input && (ValueType != ValueTypeEnum.IO || SocketValueIO.LogicIO != null))
		{
			if (ValueType == ValueTypeEnum.Constant)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() + Value * Time.deltaTime);
			}
			else if (ValueType == ValueTypeEnum.IO)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() + SocketValueIO.LogicIO.ReadAnalogSignal() * Time.deltaTime);
			}
			yield return 0;
		}
	}
}
