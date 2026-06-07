using System;
using System.Collections.Generic;

[Serializable]
public class SetInstruction : Instruction
{
	public SocketIO SocketInput => GetSocketIO(0);

	public SocketIO SocketValueIO => GetSocketIO(1);

	public SetValueType ValueType { get; set; }

	public float Value { get; set; }

	public SetInstruction(Logic parentLogic)
		: base(parentLogic)
	{
		base.Type = InstructionType.Set;
		ValueType = SetValueType.Normal;
		Value = 0f;
		SocketInput.Accessibility = SocketIOAccessibility.Writable;
	}

	public override IEnumerable<int> Execute()
	{
		if (SocketInput.LogicIO != null && SocketInput.LogicIO.Direction == LogicIODirection.Input && (ValueType != SetValueType.IO || SocketValueIO.LogicIO != null))
		{
			float signal = 0f;
			switch (ValueType)
			{
			case SetValueType.Normal:
				signal = Value;
				break;
			case SetValueType.Toggle:
				signal = (SocketInput.LogicIO.ReadDigitalSignal() ? 0f : 1f);
				break;
			case SetValueType.IO:
				signal = SocketValueIO.LogicIO.ReadAnalogSignal();
				break;
			}
			SocketInput.LogicIO.SetSignal(signal);
			yield return 0;
		}
	}
}
