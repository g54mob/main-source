using System.Collections.Generic;

public class LogicSystemModel : BaseModel
{
	public const string AddLogicEvent = "LogicSystemModel.AddLogicEvent";

	public const string RemoveLogicEvent = "LogicSystemModel.RemoveLogicEvent";

	public const string SwapLogicEvent = "LogicSystemModel.SwapLogicEvent";

	private List<Logic> logics;

	public LogicSystemModel()
	{
		logics = new List<Logic>();
	}

	public void AddLogic(Logic logic)
	{
		logics.Add(logic);
		NotifyChange("LogicSystemModel.AddLogicEvent", logic, logics.Count - 1);
	}

	public void AddLogic(string logicName, LogicType type)
	{
		Logic logic = new Logic
		{
			Name = logicName,
			Type = type
		};
		logics.Add(logic);
		NotifyChange("LogicSystemModel.AddLogicEvent", logic, logics.Count - 1);
	}

	public Logic GetLogic(int index)
	{
		if (index >= 0 && index < logics.Count)
		{
			return logics[index];
		}
		return null;
	}

	public void RemoveLogic(int index)
	{
		logics[index].InstructionsList.RemoveAllInstructions();
		logics.RemoveAt(index);
		NotifyChange("LogicSystemModel.RemoveLogicEvent", index);
	}

	public void RemoveLogic(Logic logic)
	{
		int index = logics.IndexOf(logic);
		RemoveLogic(index);
	}

	public void SwapLogic(int oldIndex, int newIndex)
	{
		Logic item = logics[oldIndex];
		logics.RemoveAt(oldIndex);
		logics.Insert(newIndex, item);
		NotifyChange("LogicSystemModel.SwapLogicEvent", oldIndex, newIndex);
	}

	public ICollection<Logic> GetAllLogics()
	{
		return logics;
	}

	public bool HasContent()
	{
		return logics.Count > 0;
	}

	public bool IsKeyAttachedInWritableSocketIO(DefaultKeyIO defaultKeyIO)
	{
		foreach (Logic logic in logics)
		{
			if (!logic.Active)
			{
				continue;
			}
			foreach (SocketIO allScoketIO in logic.GetAllScoketIOs())
			{
				if (defaultKeyIO.ParentBlockBodyModel.ParentBlockModel.Id == allScoketIO.BlockId && defaultKeyIO.ParentBlockBodyModel.Index == allScoketIO.BodyIndex && defaultKeyIO.Name == allScoketIO.Name && allScoketIO.Accessibility == SocketIOAccessibility.Writable)
				{
					return true;
				}
			}
		}
		return false;
	}

	public ICollection<LogicKeyData> GetAllKeysFromInstructions()
	{
		List<LogicKeyData> list = new List<LogicKeyData>();
		foreach (Logic logic in logics)
		{
			if (logic.Active)
			{
				list.AddRange(logic.GetKeysFromAllInstructions());
			}
		}
		return list;
	}
}
