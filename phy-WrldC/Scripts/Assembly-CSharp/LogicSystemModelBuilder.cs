using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class LogicSystemModelBuilder
{
	public const string TAG_LOGIC_SYSTEM = "logicSystem";

	private const string TAG_LOGICS = "logics";

	private const string TAG_LOGIC = "logic";

	private const string ATTR_LOGIC_NAME = "name";

	private const string ATTR_LOGIC_ACTIVE = "active";

	private const string ATTR_LOGIC_TYPE = "type";

	private const string TAG_INSTRUCTIONS = "instructions";

	private const string TAG_INSTRUCTION = "instruction";

	private const string ATTR_I_TYPE = "type";

	private const string TAG_FIRST_INSTRUCTIONS_LIST = "firstInstructions";

	private const string TAG_SECOND_INSTRUCTIONS_LIST = "secondInstructions";

	private const string ATTR_INSTRUCTION_LIST_HIDDEN = "hidden";

	private const string TAG_KEY_TRIGGER_INSTRUCTION = "keyTriggerInstruction";

	private const string ATTR_KTI_LABEL = "label";

	private const string ATTR_KTI_TRIGGER_TYPE = "t_type";

	private const string ATTR_KTI_KEY = "key";

	private const string TAG_COMPARATOR_INSTRUCTION = "comparatorInstruction";

	private const string ATTR_CI_COMPARATOR_TYPE = "c_type";

	private const string ATTR_CI_COMPARATOR_VALUE = "c_value";

	private const string ATTR_CI_VALUE = "value";

	private const string TAG_SET_INSTRUCTION = "setInstruction";

	private const string ATTR_SI_VALUE_TYPE = "v_type";

	private const string ATTR_SI_VALUE = "value";

	private const string TAG_ACCUMULATOR_INSTRUCTION = "accumulatorInstruction";

	private const string ATTR_ACCI_VALUE_TYPE = "v_type";

	private const string ATTR_ACCI_VALUE = "value";

	private const string TAG_OPERATION_INSTRUCTION = "operationInstruction";

	private const string ATTR_OP_VALUE_TYPE = "v_type";

	private const string ATTR_OP_VALUE = "value";

	private const string ATTR_OP_TYPE = "op_type";

	private const string TAG_DELAY_INSTRUCTION = "delayInstruction";

	private const string ATTR_DI_TIME = "time";

	private const string TAG_GROUP_INSTRUCTION = "groupInstruction";

	private const string ATTR_GRP_LABEL = "label";

	private const string TAG_SOCKET_IOS = "socketIOs";

	private const string TAG_SOCKET_IO = "socketIO";

	private const string ATTR_S_ID = "id";

	private const string ATTR_S_BLOCK_ID = "b_id";

	private const string ATTR_S_BODY_INDEX = "b_idx";

	private const string ATTR_S_NAME = "name";

	private const string ATTR_S_LOGIC_ATTACHED = "is_l_a";

	public static XElement SaveXml(LogicSystemModel logicSystemModel)
	{
		XElement xElement = new XElement("logicSystem");
		XElement xElement2 = new XElement("logics");
		foreach (Logic allLogic in logicSystemModel.GetAllLogics())
		{
			XElement xElement3 = new XElement("logic");
			xElement3.Add(new XAttribute("name", allLogic.Name));
			xElement3.Add(new XAttribute("active", allLogic.Active));
			xElement3.Add(new XAttribute("type", allLogic.Type));
			XElement xElement4 = new XElement("instructions");
			foreach (Instruction allInstruction in allLogic.InstructionsList.GetAllInstructions())
			{
				XElement content = SaveInstructionXml(allInstruction);
				xElement4.Add(content);
			}
			xElement3.Add(xElement4);
			xElement2.Add(xElement3);
		}
		xElement.Add(xElement2);
		return xElement;
	}

	private static XElement SaveInstructionXml(Instruction instruction)
	{
		XElement xElement = new XElement("instruction");
		xElement.Add(new XAttribute("type", instruction.Type));
		switch (instruction.Type)
		{
		case InstructionType.KeyTrigger:
			if (instruction is KeyTriggerInstruction keyTriggerInstruction)
			{
				XElement xElement7 = new XElement("keyTriggerInstruction");
				if (keyTriggerInstruction.WasKeyLabelChanged)
				{
					xElement7.Add(new XAttribute("label", keyTriggerInstruction.KeyLabel));
				}
				xElement7.Add(new XAttribute("t_type", keyTriggerInstruction.TriggerType));
				xElement7.Add(new XAttribute("key", keyTriggerInstruction.Key));
				xElement.Add(xElement7);
			}
			break;
		case InstructionType.Comparator:
			if (instruction is ComparatorInstruction comparatorInstruction)
			{
				XElement xElement3 = new XElement("comparatorInstruction");
				xElement3.Add(new XAttribute("c_type", comparatorInstruction.ComparatorType));
				xElement3.Add(new XAttribute("c_value", comparatorInstruction.ComparatorValue));
				xElement3.Add(new XAttribute("value", comparatorInstruction.Value));
				xElement.Add(xElement3);
			}
			break;
		case InstructionType.Set:
			if (instruction is SetInstruction setInstruction)
			{
				XElement xElement5 = new XElement("setInstruction");
				xElement5.Add(new XAttribute("v_type", setInstruction.ValueType));
				xElement5.Add(new XAttribute("value", setInstruction.Value));
				xElement.Add(xElement5);
			}
			break;
		case InstructionType.Accumulator:
			if (instruction is AccumulatorInstruction accumulatorInstruction)
			{
				XElement xElement8 = new XElement("accumulatorInstruction");
				xElement8.Add(new XAttribute("v_type", accumulatorInstruction.ValueType));
				xElement8.Add(new XAttribute("value", accumulatorInstruction.Value));
				xElement.Add(xElement8);
			}
			break;
		case InstructionType.Operation:
			if (instruction is OperationInstruction operationInstruction)
			{
				XElement xElement6 = new XElement("operationInstruction");
				xElement6.Add(new XAttribute("v_type", operationInstruction.ValueType));
				xElement6.Add(new XAttribute("value", operationInstruction.Value));
				xElement6.Add(new XAttribute("op_type", operationInstruction.OperationType));
				xElement.Add(xElement6);
			}
			break;
		case InstructionType.Delay:
			if (instruction is DelayInstruction delayInstruction)
			{
				XElement xElement4 = new XElement("delayInstruction");
				xElement4.Add(new XAttribute("time", delayInstruction.Time));
				xElement.Add(xElement4);
			}
			break;
		case InstructionType.Group:
			if (instruction is GroupInstruction groupInstruction)
			{
				XElement xElement2 = new XElement("groupInstruction");
				xElement2.Add(new XAttribute("label", groupInstruction.GroupLabel));
				xElement.Add(xElement2);
			}
			break;
		}
		XElement xElement9 = new XElement("firstInstructions");
		xElement9.Add(new XAttribute("hidden", instruction.FirstInstructionsList.IsListHidden));
		if (instruction.FirstInstructionsList.InstructionsCount > 0)
		{
			foreach (Instruction allInstruction in instruction.FirstInstructionsList.GetAllInstructions())
			{
				XElement content = SaveInstructionXml(allInstruction);
				xElement9.Add(content);
			}
		}
		xElement.Add(xElement9);
		XElement xElement10 = new XElement("secondInstructions");
		xElement10.Add(new XAttribute("hidden", instruction.SecondInstructionsList.IsListHidden));
		if (instruction.SecondInstructionsList.InstructionsCount > 0)
		{
			foreach (Instruction allInstruction2 in instruction.SecondInstructionsList.GetAllInstructions())
			{
				XElement content2 = SaveInstructionXml(allInstruction2);
				xElement10.Add(content2);
			}
		}
		xElement.Add(xElement10);
		if (instruction.SocketIOs.Count > 0)
		{
			XElement xElement11 = new XElement("socketIOs");
			foreach (KeyValuePair<int, SocketIO> socketIO in instruction.SocketIOs)
			{
				XElement content3 = SaveSocketIOXml(socketIO.Value, socketIO.Key);
				xElement11.Add(content3);
			}
			xElement.Add(xElement11);
		}
		return xElement;
	}

	private static XElement SaveSocketIOXml(SocketIO socketIO, int id)
	{
		XElement xElement = new XElement("socketIO");
		xElement.Add(new XAttribute("id", id));
		xElement.Add(new XAttribute("b_id", socketIO.BlockId));
		xElement.Add(new XAttribute("b_idx", socketIO.BodyIndex));
		xElement.Add(new XAttribute("name", socketIO.Name));
		xElement.Add(new XAttribute("is_l_a", socketIO.IsLogicIOAttached));
		return xElement;
	}

	public static LogicSystemModel LoadXml(XElement xLogicSystemModel)
	{
		LogicSystemModel logicSystemModel = new LogicSystemModel();
		XElement xElement = xLogicSystemModel.Element("logics");
		if (xElement != null)
		{
			foreach (XElement item in xElement.Elements())
			{
				Logic logic = new Logic
				{
					Name = item.GetAttributeAsString("name"),
					Active = item.GetAttributeAsBool("active"),
					Type = item.GetAttributeAsEnum("type", LogicType.Loop)
				};
				foreach (XElement item2 in item.Element("instructions").Elements())
				{
					Instruction instruction = LoadInstructionXml(item2, logic);
					logic.InstructionsList.AddInstruction(instruction);
				}
				logicSystemModel.AddLogic(logic);
			}
		}
		return logicSystemModel;
	}

	private static Instruction LoadInstructionXml(XElement xInstruction, Logic parentLogic)
	{
		Instruction instruction = null;
		switch (xInstruction.GetAttributeAsEnum("type", InstructionType.Delay))
		{
		case InstructionType.KeyTrigger:
		{
			XElement xElement2 = xInstruction.Element("keyTriggerInstruction");
			KeyTriggerInstruction keyTriggerInstruction = new KeyTriggerInstruction(parentLogic)
			{
				TriggerType = xElement2.GetAttributeAsEnum("t_type", KeyTriggerType.Down),
				Key = xElement2.GetAttributeAsKeyCode("key")
			};
			string attributeAsString2 = xElement2.GetAttributeAsString("label");
			if (!string.IsNullOrEmpty(attributeAsString2))
			{
				keyTriggerInstruction.KeyLabel = attributeAsString2;
				keyTriggerInstruction.WasKeyLabelChanged = true;
			}
			instruction = keyTriggerInstruction;
			break;
		}
		case InstructionType.Comparator:
		{
			XElement xElement3 = xInstruction.Element("comparatorInstruction");
			instruction = new ComparatorInstruction(parentLogic)
			{
				ComparatorType = xElement3.GetAttributeAsEnum("c_type", ComparatorType.Equal),
				ComparatorValue = xElement3.GetAttributeAsEnum("c_value", ComparatorValue.LogicIO),
				Value = xElement3.GetAttributeAsFloat("value")
			};
			break;
		}
		case InstructionType.Set:
		{
			XElement xElement7 = xInstruction.Element("setInstruction");
			instruction = new SetInstruction(parentLogic)
			{
				ValueType = xElement7.GetAttributeAsEnum("v_type", SetValueType.Normal),
				Value = xElement7.GetAttributeAsFloat("value")
			};
			break;
		}
		case InstructionType.Accumulator:
		{
			XElement xElement6 = xInstruction.Element("accumulatorInstruction");
			instruction = new AccumulatorInstruction(parentLogic)
			{
				ValueType = xElement6.GetAttributeAsEnum("v_type", AccumulatorInstruction.ValueTypeEnum.Constant),
				Value = xElement6.GetAttributeAsFloat("value")
			};
			break;
		}
		case InstructionType.Operation:
		{
			XElement xElement5 = xInstruction.Element("operationInstruction");
			instruction = new OperationInstruction(parentLogic)
			{
				ValueType = xElement5.GetAttributeAsEnum("v_type", OperationInstruction.ValueTypeEnum.Constant),
				Value = xElement5.GetAttributeAsFloat("value"),
				OperationType = xElement5.GetAttributeAsEnum("op_type", OperationInstruction.OperationTypeEnum.Plus)
			};
			break;
		}
		case InstructionType.Delay:
		{
			XElement xElement4 = xInstruction.Element("delayInstruction");
			instruction = new DelayInstruction(parentLogic)
			{
				Time = xElement4.GetAttributeAsInt("time")
			};
			break;
		}
		case InstructionType.Group:
		{
			XElement xElement = xInstruction.Element("groupInstruction");
			GroupInstruction groupInstruction = new GroupInstruction(parentLogic);
			string attributeAsString = xElement.GetAttributeAsString("label");
			if (!string.IsNullOrEmpty(attributeAsString))
			{
				groupInstruction.GroupLabel = attributeAsString;
				groupInstruction.WasGroupLabelChanged = true;
			}
			instruction = groupInstruction;
			break;
		}
		}
		if (instruction != null)
		{
			XElement xElement8 = xInstruction.Element("firstInstructions");
			if (xElement8 != null)
			{
				bool attributeAsBool = xElement8.GetAttributeAsBool("hidden");
				instruction.FirstInstructionsList.IsListHidden = attributeAsBool;
				foreach (XElement item in xElement8.Elements("instruction"))
				{
					Instruction instruction2 = LoadInstructionXml(item, parentLogic);
					instruction.FirstInstructionsList.AddInstruction(instruction2);
				}
			}
			XElement xElement9 = xInstruction.Element("secondInstructions");
			if (xElement9 != null)
			{
				bool attributeAsBool2 = xElement9.GetAttributeAsBool("hidden");
				instruction.SecondInstructionsList.IsListHidden = attributeAsBool2;
				foreach (XElement item2 in xElement9.Elements("instruction"))
				{
					Instruction instruction3 = LoadInstructionXml(item2, parentLogic);
					instruction.SecondInstructionsList.AddInstruction(instruction3);
				}
			}
			XElement xElement10 = xInstruction.Element("socketIOs");
			if (xElement10 != null)
			{
				foreach (XElement item3 in xElement10.Elements("socketIO"))
				{
					int attributeAsInt = item3.GetAttributeAsInt("id");
					LoadSocketIOXml(item3, instruction.GetSocketIO(attributeAsInt));
				}
			}
		}
		return instruction;
	}

	private static void LoadSocketIOXml(XElement xSocketIO, SocketIO socketIO)
	{
		socketIO.BlockId = xSocketIO.GetAttributeAsInt("b_id", -1);
		socketIO.BodyIndex = xSocketIO.GetAttributeAsInt("b_idx", -1);
		socketIO.Name = xSocketIO.GetAttributeAsString("name");
		socketIO.IsLogicIOAttached = xSocketIO.GetAttributeAsBool("is_l_a");
	}

	public static Instruction CloneInstruction(Instruction originalInstruction)
	{
		Instruction instruction = LoadInstructionXml(SaveInstructionXml(originalInstruction), originalInstruction.ParentLogic);
		SocketIO[] array = originalInstruction.GetAllScoketIOs().ToArray();
		SocketIO[] array2 = instruction.GetAllScoketIOs().ToArray();
		if (array.Length == array2.Length)
		{
			for (int i = 0; i < array2.Length; i++)
			{
				if (array[i].LogicIO != null)
				{
					array2[i].AttachIO(array[i].LogicIO);
				}
			}
		}
		return instruction;
	}

	public static Logic CloneLogic(Logic originalLogic)
	{
		Logic logic = new Logic
		{
			Name = originalLogic.Name,
			Active = originalLogic.Active,
			Type = originalLogic.Type
		};
		foreach (Instruction allInstruction in originalLogic.InstructionsList.GetAllInstructions())
		{
			Instruction instruction = CloneInstruction(allInstruction);
			logic.InstructionsList.AddInstruction(instruction);
		}
		return logic;
	}
}
