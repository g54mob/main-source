using System.Collections.Generic;

public class OperationInstruction : Instruction
{
	public enum ValueTypeEnum
	{
		Constant = 0,
		IO = 1
	}

	public enum OperationTypeEnum
	{
		Plus = 0,
		Minus = 1,
		Multiplier = 2,
		Divider = 3
	}

	public SocketIO SocketInput => GetSocketIO(0);

	public SocketIO SocketValueIO => GetSocketIO(1);

	public float Value { get; set; }

	public ValueTypeEnum ValueType { get; set; }

	public OperationTypeEnum OperationType { get; set; }

	public OperationInstruction(Logic parentLogic)
		: base(parentLogic)
	{
		base.Type = InstructionType.Operation;
		ValueType = ValueTypeEnum.Constant;
		Value = 0f;
		SocketInput.Accessibility = SocketIOAccessibility.Writable;
		OperationType = OperationTypeEnum.Plus;
	}

	public override IEnumerable<int> Execute()
	{
		if (SocketInput.LogicIO == null || SocketInput.LogicIO.Direction != LogicIODirection.Input || (ValueType == ValueTypeEnum.IO && SocketValueIO.LogicIO == null))
		{
			yield break;
		}
		switch (OperationType)
		{
		case OperationTypeEnum.Plus:
			if (ValueType == ValueTypeEnum.Constant)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() + Value);
			}
			else if (ValueType == ValueTypeEnum.IO)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() + SocketValueIO.LogicIO.ReadAnalogSignal());
			}
			break;
		case OperationTypeEnum.Minus:
			if (ValueType == ValueTypeEnum.Constant)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() - Value);
			}
			else if (ValueType == ValueTypeEnum.IO)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() - SocketValueIO.LogicIO.ReadAnalogSignal());
			}
			break;
		case OperationTypeEnum.Multiplier:
			if (ValueType == ValueTypeEnum.Constant)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() * Value);
			}
			else if (ValueType == ValueTypeEnum.IO)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() * SocketValueIO.LogicIO.ReadAnalogSignal());
			}
			break;
		case OperationTypeEnum.Divider:
			if (ValueType == ValueTypeEnum.Constant)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() / Value);
			}
			else if (ValueType == ValueTypeEnum.IO)
			{
				SocketInput.LogicIO.SetSignal(SocketInput.LogicIO.ReadAnalogSignal() / SocketValueIO.LogicIO.ReadAnalogSignal());
			}
			break;
		}
		yield return 0;
	}
}
