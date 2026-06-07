using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic
{
	public string Name { get; set; }

	public bool Active { get; set; }

	public LogicType Type { get; set; }

	public InstructionsList InstructionsList { get; private set; }

	public Logic()
	{
		InstructionsList = new InstructionsList(this);
		Active = true;
		Type = LogicType.Loop;
	}

	public IEnumerator Run()
	{
		if (Type == LogicType.Single)
		{
			yield return ExecuteAllInstructions();
		}
		else if (Type == LogicType.Loop)
		{
			while (true)
			{
				yield return ExecuteAllInstructions();
			}
		}
	}

	private IEnumerator ExecuteAllInstructions()
	{
		bool shouldBreak = false;
		foreach (Instruction allInstruction in InstructionsList.GetAllInstructions())
		{
			foreach (int item in allInstruction.Execute())
			{
				if (item > 0)
				{
					yield return new WaitForSeconds((float)item / 1000f);
				}
				else if (item == -1)
				{
					shouldBreak = true;
					break;
				}
			}
			if (shouldBreak)
			{
				break;
			}
		}
		yield return null;
	}

	public ICollection<SocketIO> GetAllScoketIOs()
	{
		List<SocketIO> list = new List<SocketIO>();
		foreach (Instruction allInstruction in InstructionsList.GetAllInstructions())
		{
			list.AddRange(allInstruction.GetAllScoketIOs());
		}
		return list;
	}

	public ICollection<LogicKeyData> GetKeysFromAllInstructions()
	{
		return InstructionsList.GetKeysFromAllInstructions();
	}
}
