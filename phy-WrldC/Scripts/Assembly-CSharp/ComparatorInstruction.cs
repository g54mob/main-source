using System;
using System.Collections.Generic;

[Serializable]
public class ComparatorInstruction : Instruction
{
	public ComparatorType ComparatorType { get; set; }

	public ComparatorValue ComparatorValue { get; set; }

	public float Value { get; set; }

	public SocketIO FirstSocketIO => GetSocketIO(0);

	public SocketIO SecondSocketIO => GetSocketIO(1);

	public ComparatorInstruction(Logic parentLogic)
		: base(parentLogic)
	{
		base.Type = InstructionType.Comparator;
		ComparatorType = ComparatorType.Equal;
		ComparatorValue = ComparatorValue.LogicIO;
		Value = 0f;
	}

	public override IEnumerable<int> Execute()
	{
		if (FirstSocketIO.LogicIO == null || (SecondSocketIO.LogicIO == null && ComparatorValue == ComparatorValue.LogicIO))
		{
			yield break;
		}
		float num = FirstSocketIO.LogicIO.ReadAnalogSignal();
		float num2 = ((ComparatorValue == ComparatorValue.LogicIO) ? SecondSocketIO.LogicIO.ReadAnalogSignal() : Value);
		bool flag = false;
		bool flag2 = false;
		switch (ComparatorType)
		{
		case ComparatorType.Equal:
			if (num == num2)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		case ComparatorType.Different:
			if (num != num2)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		case ComparatorType.Greater:
			if (num > num2)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		case ComparatorType.GreaterEqual:
			if (num >= num2)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		case ComparatorType.Less:
			if (num < num2)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		case ComparatorType.LessEqual:
			if (num <= num2)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
			break;
		}
		if (flag)
		{
			foreach (int item in ExecuteAllFirstInstructions())
			{
				yield return item;
			}
		}
		else
		{
			if (!flag2)
			{
				yield break;
			}
			foreach (int item2 in ExecuteAllSecondInstructions())
			{
				yield return item2;
			}
		}
	}
}
