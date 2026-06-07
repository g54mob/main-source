using System;
using System.Xml.Serialization;

[Serializable]
public class SocketIO
{
	public int BlockId { get; set; }

	public int BodyIndex { get; set; }

	public string Name { get; set; }

	public bool IsLogicIOAttached { get; set; }

	public Instruction ParentInstruction { get; private set; }

	[XmlIgnore]
	public LogicIO LogicIO { get; private set; }

	public SocketIOAccessibility Accessibility { get; set; }

	public SocketIO(Instruction parentInstruction)
	{
		ParentInstruction = parentInstruction;
		Accessibility = SocketIOAccessibility.Readable;
		DetachIO();
	}

	public void AttachIO(LogicIO logicIO)
	{
		BlockId = logicIO.BlockId;
		BodyIndex = logicIO.BodyIndex;
		Name = logicIO.Name;
		logicIO.SocketIOs.Add(this);
		LogicIO = logicIO;
		IsLogicIOAttached = true;
	}

	public void DetachIO()
	{
		BlockId = -1;
		BodyIndex = -1;
		Name = "";
		LogicIO?.RemoveSocketIO(this);
		LogicIO = null;
		IsLogicIOAttached = false;
	}

	public void RemoveLogicIO()
	{
		LogicIO = null;
	}
}
