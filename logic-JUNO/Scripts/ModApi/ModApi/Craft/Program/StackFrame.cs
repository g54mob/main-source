using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Program.Instructions;
using UnityEngine;

namespace ModApi.Craft.Program
{
	public class StackFrame
	{
		public VariableSet LocalVariables { get; private set; } = new VariableSet();

		public Dictionary<ProgramInstruction, double> NodeStates { get; private set; } = new Dictionary<ProgramInstruction, double>();

		public ProgramInstruction ReturnInstruction { get; set; }

		public static StackFrame Deserialize(XElement xml, FlightProgram program)
		{
			StackFrame stackFrame = new StackFrame();
			stackFrame.LocalVariables = new VariableSet(xml.Element("Variables"));
			string stringAttribute = xml.GetStringAttribute("states");
			if (stringAttribute != null)
			{
				string[] array = stringAttribute.Split(',');
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string[] array3 = array2[i].Split('=');
					if (array3.Length == 2)
					{
						if (int.TryParse(array3[0], out var result) && double.TryParse(array3[1], out var result2))
						{
							ProgramInstruction instructionById = ((IGetInstructionById)program).GetInstructionById(result);
							stackFrame.NodeStates[instructionById] = result2;
						}
					}
					else
					{
						Debug.LogErrorFormat("Unexpected tokens length ({0}) in states attribute: '{1}'", array3.Length, array);
					}
				}
			}
			int intAttribute = xml.GetIntAttribute("returnId", -1);
			if (intAttribute >= 0)
			{
				stackFrame.ReturnInstruction = ((IGetInstructionById)program).GetInstructionById(intAttribute);
			}
			return stackFrame;
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("StackFrame");
			xElement.Add(LocalVariables.Serialize());
			if (NodeStates.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (KeyValuePair<ProgramInstruction, double> nodeState in NodeStates)
				{
					stringBuilder.AppendFormat("{0}={1},", ((IInstructionId)nodeState.Key).Id, nodeState.Value);
				}
				stringBuilder.Length--;
				xElement.SetAttributeValue("states", stringBuilder);
			}
			if (ReturnInstruction != null)
			{
				xElement.Add(new XAttribute("returnId", ((IInstructionId)ReturnInstruction).Id));
			}
			return xElement;
		}
	}
}
