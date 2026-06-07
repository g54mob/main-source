using System;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Block.Instruction;

public class Block_RotateWing : BE2_InstructionBase, I_BE2_Instruction
{
	private I_BE2_BlockSectionHeaderInput _input0;

	private string _axisString;

	private I_BE2_BlockSectionHeaderInput _input1;

	private int wingNum = 1;

	public static event Action<int, float> OnRotateWing1;

	public new void Function()
	{
		_input0 = base.Section0Inputs[0];
		_input1 = base.Section0Inputs[1];
		_axisString = _input0.StringValue;
		switch (_axisString)
		{
		case "1":
			wingNum = 1;
			break;
		case "2":
			wingNum = 2;
			break;
		case "3":
			wingNum = 3;
			break;
		case "4":
			wingNum = 4;
			break;
		default:
			wingNum = 0;
			break;
		}
		Block_RotateWing.OnRotateWing1?.Invoke(wingNum, _input1.FloatValue);
		ExecuteNextInstruction();
	}
}
