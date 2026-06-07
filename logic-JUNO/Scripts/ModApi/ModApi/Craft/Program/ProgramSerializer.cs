using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.ModTools.Serialization.Xml;
using ModApi.Common.Extensions;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;
using UnityEngine;

namespace ModApi.Craft.Program
{
	public class ProgramSerializer : IProgramSerializer
	{
		private class ProgramNodeCreator
		{
			public Func<ProgramNode> CreateFunc { get; set; }

			public string TypeName { get; set; }

			public string XmlName { get; set; }

			public ProgramNodeCreator(string xmlName, Type programNodeType, Func<ProgramNode> createFunc)
			{
				XmlName = xmlName;
				TypeName = programNodeType.Name;
				CreateFunc = createFunc;
			}
		}

		public const string ChildInstructionsElementName = "Instructions";

		public const string InstructionsElementName = "Instructions";

		public const string ProgramElementName = "Program";

		public const string RootExpressionsElementName = "Expressions";

		private static Dictionary<string, ProgramNodeCreator> _typeNameLookup;

		private static Dictionary<string, ProgramNodeCreator> _xmlNameLookup;

		private static UnityXmlSerializer _xmlSerializer;

		static ProgramSerializer()
		{
			_typeNameLookup = new Dictionary<string, ProgramNodeCreator>();
			_xmlNameLookup = new Dictionary<string, ProgramNodeCreator>();
			foreach (ProgramNodeCreator item in new List<ProgramNodeCreator>
			{
				new ProgramNodeCreator("ActivateStage", typeof(ActivateStageInstruction), () => new ActivateStageInstruction()),
				new ProgramNodeCreator("Break", typeof(BreakInstruction), () => new BreakInstruction()),
				new ProgramNodeCreator("ChangeVariable", typeof(ChangeVariableInstruction), () => new ChangeVariableInstruction()),
				new ProgramNodeCreator("If", typeof(IfInstruction), () => new IfInstruction()),
				new ProgramNodeCreator("ElseIf", typeof(ElseIfInstruction), () => new ElseIfInstruction()),
				new ProgramNodeCreator("Repeat", typeof(RepeatInstruction), () => new RepeatInstruction()),
				new ProgramNodeCreator("WaitSeconds", typeof(WaitSecondsInstruction), () => new WaitSecondsInstruction()),
				new ProgramNodeCreator("WaitUntil", typeof(WaitUntilInstruction), () => new WaitUntilInstruction()),
				new ProgramNodeCreator("Repeat", typeof(RepeatInstruction), () => new RepeatInstruction()),
				new ProgramNodeCreator("SetList", typeof(SetListInstruction), () => new SetListInstruction()),
				new ProgramNodeCreator("SetVariable", typeof(SetVariableInstruction), () => new SetVariableInstruction()),
				new ProgramNodeCreator("SetInput", typeof(SetCraftInputInstruction), () => new SetCraftInputInstruction()),
				new ProgramNodeCreator("LockNavSphere", typeof(LockNavSphereInstruction), () => new LockNavSphereInstruction()),
				new ProgramNodeCreator("DisplayMessage", typeof(DisplayMessageInstruction), () => new DisplayMessageInstruction()),
				new ProgramNodeCreator("LogMessage", typeof(LogMessageInstruction), () => new LogMessageInstruction()),
				new ProgramNodeCreator("LogFlight", typeof(LogFlightInstruction), () => new LogFlightInstruction()),
				new ProgramNodeCreator("SetActivationGroup", typeof(SetActivationGroupInstruction), () => new SetActivationGroupInstruction()),
				new ProgramNodeCreator("SetTargetHeading", typeof(SetTargetHeadingInstruction), () => new SetTargetHeadingInstruction()),
				new ProgramNodeCreator("SetTarget", typeof(SetTargetInstruction), () => new SetTargetInstruction()),
				new ProgramNodeCreator("SetTimeMode", typeof(SetTimeModeInstruction), () => new SetTimeModeInstruction()),
				new ProgramNodeCreator("Event", typeof(EventInstruction), () => new EventInstruction()),
				new ProgramNodeCreator("BroadcastMessage", typeof(BroadcastMessageInstruction), () => new BroadcastMessageInstruction()),
				new ProgramNodeCreator("While", typeof(WhileInstruction), () => new WhileInstruction()),
				new ProgramNodeCreator("Comment", typeof(CommentInstruction), () => new CommentInstruction()),
				new ProgramNodeCreator("SetCameraProperty", typeof(SetCameraPropertyInstruction), () => new SetCameraPropertyInstruction()),
				new ProgramNodeCreator("CustomInstruction", typeof(CustomInstruction), () => new CustomInstruction()),
				new ProgramNodeCreator("CallCustomInstruction", typeof(CallCustomInstruction), () => new CallCustomInstruction()),
				new ProgramNodeCreator("For", typeof(ForInstruction), () => new ForInstruction()),
				new ProgramNodeCreator("SetCraftProperty", typeof(SetCraftPropertyInstruction), () => new SetCraftPropertyInstruction()),
				new ProgramNodeCreator("SwitchCraft", typeof(SwitchCraftInstruction), () => new SwitchCraftInstruction()),
				new ProgramNodeCreator("UserInput", typeof(UserInputInstruction), () => new UserInputInstruction()),
				new ProgramNodeCreator("ActivationGroup", typeof(ActivationGroupExpression), () => new ActivationGroupExpression()),
				new ProgramNodeCreator("BinaryOp", typeof(BinaryOperatorExpression), () => new BinaryOperatorExpression()),
				new ProgramNodeCreator("BoolOp", typeof(BoolOperatorExpression), () => new BoolOperatorExpression()),
				new ProgramNodeCreator("Comparison", typeof(ComparisonExpression), () => new ComparisonExpression()),
				new ProgramNodeCreator("Not", typeof(NotExpression), () => new NotExpression()),
				new ProgramNodeCreator("Constant", typeof(ConstantExpression), () => new ConstantExpression()),
				new ProgramNodeCreator("Variable", typeof(VariableExpression), () => new VariableExpression()),
				new ProgramNodeCreator("MathFunction", typeof(MathFunctionExpression), () => new MathFunctionExpression()),
				new ProgramNodeCreator("CraftProperty", typeof(CraftPropertyExpression), () => new CraftPropertyExpression()),
				new ProgramNodeCreator("StringOp", typeof(StringOperatorExpression), () => new StringOperatorExpression()),
				new ProgramNodeCreator("CustomExpression", typeof(CustomExpression), () => new CustomExpression()),
				new ProgramNodeCreator("CallCustomExpression", typeof(CallCustomExpression), () => new CallCustomExpression()),
				new ProgramNodeCreator("Conditional", typeof(ConditionalExpression), () => new ConditionalExpression()),
				new ProgramNodeCreator("VectorOp", typeof(VectorOperatorExpression), () => new VectorOperatorExpression()),
				new ProgramNodeCreator("Vector", typeof(VectorExpression), () => new VectorExpression()),
				new ProgramNodeCreator("Planet", typeof(PlanetExpression), () => new PlanetExpression()),
				new ProgramNodeCreator("ListOp", typeof(ListOperatorExpression), () => new ListOperatorExpression()),
				new ProgramNodeCreator("EvaluateExpression", typeof(EvaluationExpression), () => new EvaluationExpression())
			})
			{
				_typeNameLookup[item.TypeName] = item;
				_xmlNameLookup[item.XmlName] = item;
			}
			_xmlSerializer = new UnityXmlSerializer(new UnityXmlSerializerContext
			{
				IgnoreUnderscorePrefix = true
			});
		}

		public static ProgramNode CreateProgramNode(XElement xml)
		{
			string text = xml.Name.ToString();
			try
			{
				return _xmlNameLookup[xml.Name.ToString()].CreateFunc();
			}
			catch (Exception)
			{
				throw new ArgumentException("Unknown program node XML name: " + text);
			}
		}

		public static ProgramInstruction DeserializeInstructionSet(XElement containerElement)
		{
			List<XElement> list = containerElement.Elements().ToList();
			ProgramInstruction programInstruction = null;
			ProgramInstruction programInstruction2 = null;
			foreach (XElement item in list)
			{
				if (DeserializeProgramNode(item) is ProgramInstruction programInstruction3)
				{
					if (programInstruction == null)
					{
						programInstruction = programInstruction3;
					}
					if (programInstruction2 != null)
					{
						programInstruction2.Next = programInstruction3;
					}
					programInstruction2 = programInstruction3;
				}
				else
				{
					Debug.LogErrorFormat("Unexpected element in instruction set: {0}", item.Name);
				}
			}
			return programInstruction;
		}

		public static ProgramNode DeserializeProgramNode(XElement nodeElement)
		{
			ProgramNode programNode = CreateProgramNode(nodeElement);
			List<XElement> list = nodeElement.Elements().ToList();
			List<ProgramExpression> list2 = new List<ProgramExpression>();
			foreach (XElement item in list)
			{
				if (item.Name == "Instructions")
				{
					if (programNode is ProgramInstruction programInstruction)
					{
						programInstruction.FirstChild = DeserializeInstructionSet(item);
						continue;
					}
					Debug.LogErrorFormat("{0} element cannot contain {1} child element.", nodeElement.Name, item.Name);
					continue;
				}
				ProgramNode programNode2 = DeserializeProgramNode(item);
				if (programNode2 is ProgramExpression)
				{
					list2.Add(programNode2 as ProgramExpression);
					continue;
				}
				Debug.LogErrorFormat("Element {0} cannot be a child of {1}.", item.Name, nodeElement.Name);
			}
			programNode.InitializeExpressions(list2.ToArray());
			_xmlSerializer.Deserialize(nodeElement, programNode.GetType(), programNode, restoreMissingValuesAsNull: false, null);
			programNode.OnDeserialized(nodeElement);
			return programNode;
		}

		public static void SerializeProgramNodes(ProgramNode node, XElement parentElement, ref int instructionId, bool cloneChain)
		{
			SerializeProgramNode(node, parentElement, ref instructionId, cloneChain);
		}

		public FlightProgram DeserializeFlightProgram(XElement programXml)
		{
			FlightProgram flightProgram = new FlightProgram();
			flightProgram.Name = programXml.GetStringAttribute("name", "Program");
			flightProgram.RequiresMfd = programXml.GetBoolAttribute("requiresMfd");
			flightProgram.GlobalVariables = new VariableSet(programXml.Element("Variables"));
			foreach (XElement item in programXml.Elements("Instructions").ToList())
			{
				ProgramInstruction programInstruction = DeserializeInstructionSet(item);
				flightProgram.RootInstructions.Add(programInstruction);
				if (programInstruction is CustomInstruction)
				{
					flightProgram.AddCustomInstruction(programInstruction as CustomInstruction);
				}
			}
			List<XElement> list = programXml.Element("Expressions")?.Elements()?.ToList();
			if (list != null)
			{
				foreach (XElement item2 in list)
				{
					ProgramNode programNode = DeserializeProgramNode(item2);
					flightProgram.RootExpressions.Add(programNode as ProgramExpression);
					if (programNode is CustomExpression)
					{
						flightProgram.AddCustomExpression(programNode as CustomExpression);
					}
				}
			}
			return flightProgram;
		}

		public XElement SerializeFlightProgram(FlightProgram program)
		{
			XElement xElement = new XElement("Program");
			xElement.SetAttributeValue("name", program.Name);
			if (program.RequiresMfd)
			{
				xElement.SetAttributeValue("requiresMfd", program.RequiresMfd);
			}
			xElement.Add(program.GlobalVariables.Serialize());
			int instructionId = 0;
			foreach (ProgramInstruction rootInstruction in program.RootInstructions)
			{
				XElement xElement2 = new XElement("Instructions");
				xElement.Add(xElement2);
				SerializeProgramNodes(rootInstruction, xElement2, ref instructionId, cloneChain: true);
			}
			XElement xElement3 = new XElement("Expressions");
			xElement.Add(xElement3);
			foreach (ProgramExpression rootExpression in program.RootExpressions)
			{
				SerializeProgramNode(rootExpression, xElement3, ref instructionId, cloneChain: true);
			}
			return xElement;
		}

		private static string GetXmlNameForNode(ProgramNode node)
		{
			string name = node.GetType().Name;
			try
			{
				return _typeNameLookup[name].XmlName;
			}
			catch (Exception)
			{
				throw new ArgumentException("Unknown program node type: " + name);
			}
		}

		private static XElement SerializeProgramNode(ProgramNode node, XElement parentElement, ref int instructionId, bool cloneChain)
		{
			XElement xElement = new XElement(GetXmlNameForNode(node));
			parentElement.Add(xElement);
			if (node.Expressions != null)
			{
				foreach (ProgramExpression expression in node.Expressions)
				{
					SerializeProgramNode(expression, xElement, ref instructionId, cloneChain);
				}
			}
			if (node is ProgramInstruction programInstruction)
			{
				((IInstructionId)programInstruction).Id = instructionId++;
				if (cloneChain)
				{
					if (programInstruction.FirstChild != null)
					{
						XElement xElement2 = new XElement("Instructions");
						xElement.Add(xElement2);
						SerializeProgramNode(programInstruction.FirstChild, xElement2, ref instructionId, cloneChain);
					}
					if (programInstruction.Next != null)
					{
						SerializeProgramNode(programInstruction.Next, parentElement, ref instructionId, cloneChain);
					}
				}
			}
			_xmlSerializer.Serialize(xElement, node.GetType(), (object)node, (string[])null);
			node.OnSerialized(xElement);
			return xElement;
		}
	}
}
