using System.Collections.Generic;

public abstract class Instruction
{
	public InstructionType Type { get; protected set; }

	public Logic ParentLogic { get; private set; }

	public InstructionsList ParentInstructionList { get; set; }

	public InstructionsList FirstInstructionsList { get; private set; }

	public InstructionsList SecondInstructionsList { get; private set; }

	public Dictionary<int, SocketIO> SocketIOs { get; private set; }

	public Instruction(Logic parentLogic)
	{
		ParentLogic = parentLogic;
		FirstInstructionsList = new InstructionsList(parentLogic);
		SecondInstructionsList = new InstructionsList(parentLogic);
		SocketIOs = new Dictionary<int, SocketIO>();
	}

	public abstract IEnumerable<int> Execute();

	protected IEnumerable<int> ExecuteAllFirstInstructions()
	{
		foreach (Instruction allInstruction in FirstInstructionsList.GetAllInstructions())
		{
			foreach (int item in allInstruction.Execute())
			{
				yield return item;
			}
		}
	}

	protected IEnumerable<int> ExecuteAllSecondInstructions()
	{
		foreach (Instruction allInstruction in SecondInstructionsList.GetAllInstructions())
		{
			foreach (int item in allInstruction.Execute())
			{
				yield return item;
			}
		}
	}

	public SocketIO GetSocketIO(int id)
	{
		if (!SocketIOs.ContainsKey(id))
		{
			SocketIOs.Add(id, new SocketIO(this));
		}
		return SocketIOs[id];
	}

	public ICollection<SocketIO> GetAllScoketIOs()
	{
		List<SocketIO> list = new List<SocketIO>();
		list.AddRange(SocketIOs.Values);
		foreach (Instruction allInstruction in FirstInstructionsList.GetAllInstructions())
		{
			list.AddRange(allInstruction.GetAllScoketIOs());
		}
		foreach (Instruction allInstruction2 in SecondInstructionsList.GetAllInstructions())
		{
			list.AddRange(allInstruction2.GetAllScoketIOs());
		}
		return list;
	}
}
