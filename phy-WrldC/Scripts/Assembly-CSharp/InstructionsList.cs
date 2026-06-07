using System.Collections.Generic;

public class InstructionsList
{
	private List<Instruction> instructions;

	public Logic ParentLogic { get; private set; }

	public int InstructionsCount => instructions.Count;

	public bool IsListHidden { get; set; }

	public InstructionsList(Logic parentLogic)
	{
		ParentLogic = parentLogic;
		instructions = new List<Instruction>();
		IsListHidden = false;
	}

	public void AddInstruction(Instruction instruction)
	{
		instruction.ParentInstructionList = this;
		instructions.Add(instruction);
	}

	public Instruction GetInstruction(int index)
	{
		return instructions[index];
	}

	public ICollection<Instruction> GetAllInstructions()
	{
		return instructions;
	}

	public void LightRemoveInstruction(int index)
	{
		instructions.RemoveAt(index);
	}

	public void RemoveInstruction(Instruction instruction)
	{
		foreach (SocketIO value in instruction.SocketIOs.Values)
		{
			value.DetachIO();
		}
		instruction.FirstInstructionsList.RemoveAllInstructions();
		instruction.SecondInstructionsList.RemoveAllInstructions();
		instructions.Remove(instruction);
	}

	public void RemoveAllInstructions()
	{
		Instruction[] array = instructions.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			RemoveInstruction(array[i]);
		}
	}

	public void InsertInstruction(Instruction instruction, int index)
	{
		instruction.ParentInstructionList = this;
		instructions.Insert(index, instruction);
	}

	public void SwapInstruction(int oldIndex, int newIndex)
	{
		Instruction item = instructions[oldIndex];
		instructions.RemoveAt(oldIndex);
		instructions.Insert(newIndex, item);
	}

	public List<LogicKeyData> GetKeysFromInstruction(Instruction instruction)
	{
		List<LogicKeyData> list = new List<LogicKeyData>();
		if (instruction is KeyTriggerInstruction keyTriggerInstruction)
		{
			list.Add(new LogicKeyData
			{
				keyLabel = keyTriggerInstruction.KeyLabel,
				keyCode = keyTriggerInstruction.Key
			});
		}
		list.AddRange(instruction.FirstInstructionsList.GetKeysFromAllInstructions());
		list.AddRange(instruction.SecondInstructionsList.GetKeysFromAllInstructions());
		return list;
	}

	public List<LogicKeyData> GetKeysFromAllInstructions()
	{
		List<LogicKeyData> list = new List<LogicKeyData>();
		foreach (Instruction instruction in instructions)
		{
			list.AddRange(GetKeysFromInstruction(instruction));
		}
		return list;
	}
}
