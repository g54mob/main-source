using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Vizzy.UI.Elements;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI
{
	public class NodeBuilderScript : MonoBehaviour, INodeBuilder
	{
		private const string StyleConstant = "constant";

		private const string StyleGlobalVariable = "global-variable";

		private const string StyleList = "list";

		private const string StyleListVariable = "list-variable";

		private const string StyleLocalVariable = "local-variable";

		private const string StyleText = "text";

		[SerializeField]
		private ContextMenuScript _blockContextMenu;

		[SerializeField]
		private GameObject _prefabBoolExpressionElement;

		[SerializeField]
		private GameObject _prefabCustomExpressionElement;

		[SerializeField]
		private GameObject _prefabCustomInstructionElement;

		[SerializeField]
		private GameObject _prefabEventInstructionElement;

		[SerializeField]
		private GameObject _prefabExpressionSlotElement;

		[SerializeField]
		private GameObject _prefabInstructionBlockElement;

		[SerializeField]
		private GameObject _prefabInstructionElement;

		[SerializeField]
		private GameObject _prefabListElement;

		[SerializeField]
		private GameObject _prefabLocalVariableExpressionElement;

		[SerializeField]
		private GameObject _prefabNumericExpressionElement;

		[SerializeField]
		private GameObject _prefabTextElement;

		[SerializeField]
		private GameObject _prefabTextInputElement;

		private int _uniqueDisplayId;

		private IVizzyUI _vizzyUI;

		public ContextMenuScript BlockContextMenu => _blockContextMenu;

		public ExpressionElementScript BuildExpressionElement(ProgramExpression expression, NodeFormat.Token token)
		{
			ExpressionElementScript expressionElementScript = null;
			if (expression is ConstantExpression)
			{
				ConstantExpression constantExpression = expression as ConstantExpression;
				string styleOverride = ((expression.Style != null) ? expression.Style : "constant");
				if (constantExpression.IsBoolean)
				{
					BoolExpressionElementScript boolExpressionElementScript = CreateBlock<BoolExpressionElementScript>(_prefabBoolExpressionElement, expression, styleOverride);
					expressionElementScript = boolExpressionElementScript;
					if (string.IsNullOrEmpty(expressionElementScript.Format))
					{
						boolExpressionElementScript.DragBehavior = DragBehaviorType.Disabled;
					}
					else
					{
						BuildChildrenBlocks(expression, expressionElementScript);
					}
				}
				else
				{
					TextInputElementScript textInputElementScript = CreateBlock<TextInputElementScript>(_prefabTextInputElement, expression, styleOverride);
					textInputElementScript.Text = constantExpression.ExpressionResult.TextValue;
					textInputElementScript.Token = token;
					expressionElementScript = textInputElementScript;
				}
			}
			else if (expression is VariableExpression)
			{
				VariableExpression variableExpression = expression as VariableExpression;
				string styleOverride2 = (variableExpression.IsLocal ? "local-variable" : "global-variable");
				if (variableExpression.IsList)
				{
					styleOverride2 = "list-variable";
				}
				VariableElementScript variableElementScript = CreateBlock<VariableElementScript>(_prefabLocalVariableExpressionElement, expression, styleOverride2);
				variableElementScript.Text = variableExpression.VariableName;
				expressionElementScript = variableElementScript;
			}
			else if (expression is CustomExpression)
			{
				expressionElementScript = CreateBlock<CustomExpressionElementScript>(_prefabCustomExpressionElement, expression);
				expressionElementScript.SupportsClone = false;
				BuildChildrenBlocks(expression, expressionElementScript);
			}
			else
			{
				expressionElementScript = ((!expression.IsBoolean) ? ((ExpressionElementScript)CreateBlock<TextExpressionElementScript>(_prefabNumericExpressionElement, expression)) : ((ExpressionElementScript)CreateBlock<BoolExpressionElementScript>(_prefabBoolExpressionElement, expression)));
				if (expression is CallCustomExpression)
				{
					CallCustomExpression callCustomExpression = expression as CallCustomExpression;
					expressionElementScript.Format = _vizzyUI.FlightProgram.GetCustomExpression(callCustomExpression.Call)?.CallFormat ?? ("Undefined " + callCustomExpression.Call);
				}
				BuildChildrenBlocks(expression, expressionElementScript);
			}
			if (expression.EditorPosition.HasValue)
			{
				expressionElementScript.RectTransform.anchoredPosition = expression.EditorPosition.Value;
				expression.EditorPosition = null;
			}
			expressionElementScript.LayoutElement();
			return expressionElementScript;
		}

		public InstructionElementScript BuildInstructionElement(ProgramInstruction instruction)
		{
			InstructionElementScript instructionElementScript = null;
			if (instruction is EventInstruction)
			{
				instructionElementScript = CreateBlock<InstructionElementScript>(_prefabEventInstructionElement, instruction);
			}
			else if (!(instruction is CustomInstruction))
			{
				instructionElementScript = ((!instruction.SupportsChildren) ? CreateBlock<InstructionElementScript>(_prefabInstructionElement, instruction) : CreateBlock<InstructionElementScript>(_prefabInstructionBlockElement, instruction));
			}
			else
			{
				instructionElementScript = CreateBlock<InstructionElementScript>(_prefabCustomInstructionElement, instruction);
				instructionElementScript.SupportsClone = false;
				CustomInstruction customInstruction = instruction as CustomInstruction;
				instructionElementScript.Format = customInstruction.Format;
			}
			if (instruction is CallCustomInstruction)
			{
				CallCustomInstruction callCustomInstruction = instruction as CallCustomInstruction;
				instructionElementScript.Format = _vizzyUI.FlightProgram.GetCustomInstruction(callCustomInstruction.Call)?.CallFormat ?? ("Undefined " + callCustomInstruction.Call);
			}
			BuildChildrenBlocks(instruction, instructionElementScript);
			if (instruction.Next != null)
			{
				InstructionElementScript instructionElementScript2 = BuildInstructionElement(instruction.Next);
				instructionElementScript2.PrevInstruction = instructionElementScript;
				instructionElementScript.NextInstruction = instructionElementScript2;
			}
			if (instruction.FirstChild != null)
			{
				InstructionElementScript instructionElementScript3 = BuildInstructionElement(instruction.FirstChild);
				instructionElementScript3.RectTransform.SetParent(instructionElementScript.RectTransform, worldPositionStays: false);
				instructionElementScript3.ParentInstruction = instructionElementScript;
				instructionElementScript.ChildInstruction = instructionElementScript3;
			}
			if (instruction.EditorPosition.HasValue)
			{
				instructionElementScript.RectTransform.anchoredPosition = instruction.EditorPosition.Value;
				instruction.EditorPosition = null;
			}
			instructionElementScript.LayoutElement();
			return instructionElementScript;
		}

		public BlockElementScript BuildProgramNodeElement(ProgramNode node)
		{
			BlockElementScript blockElementScript = null;
			if (node is ProgramExpression expression)
			{
				return BuildExpressionElement(expression, null);
			}
			ProgramInstruction instruction = node as ProgramInstruction;
			return BuildInstructionElement(instruction);
		}

		public List<BlockElementScript> CloneBlock(BlockElementScript block, bool cloneChain)
		{
			List<BlockElementScript> list = new List<BlockElementScript>();
			XElement xElement = new XElement("TemporaryParent");
			int instructionId = 0;
			ProgramSerializer.SerializeProgramNodes(block.Node, xElement, ref instructionId, cloneChain);
			IEnumerable<XElement> source = xElement.Elements();
			ProgramNode node = ((!(block is InstructionElementScript)) ? ProgramSerializer.DeserializeProgramNode(source.First()) : ProgramSerializer.DeserializeInstructionSet(xElement));
			BlockElementScript blockElementScript = BuildProgramNodeElement(node);
			blockElementScript.transform.SetParent(_vizzyUI.ProgramTransform, worldPositionStays: false);
			blockElementScript.transform.transform.localScale = Vector3.one;
			blockElementScript.transform.position = block.transform.position;
			list.Add(blockElementScript);
			InstructionElementScript instructionElementScript = blockElementScript as InstructionElementScript;
			if (instructionElementScript != null)
			{
				instructionElementScript.LayoutElement();
				instructionElementScript = instructionElementScript.NextInstruction;
				while (instructionElementScript != null)
				{
					list.Add(instructionElementScript);
					instructionElementScript = instructionElementScript.NextInstruction;
				}
			}
			return list;
		}

		public void Initialize(IVizzyUI vizzyUI)
		{
			_vizzyUI = vizzyUI;
			BlockContextMenu.Initialize(vizzyUI);
		}

		public void RebuildChildren(BlockElementScript blockScript)
		{
			while (blockScript.ChildBlocks.Count > 0)
			{
				BlockElementScript blockElementScript = blockScript.ChildBlocks[0];
				blockScript.RemoveChild(blockElementScript);
				blockElementScript.Destroy();
			}
			BuildChildrenBlocks(blockScript.Node, blockScript);
			blockScript.OnChildSizeChanged();
		}

		private static int GetIndexOfLastUsedExpression(ProgramNode node)
		{
			for (int num = node.Expressions.Count - 1; num >= 0; num--)
			{
				if (!(node.GetExpression(num) is ConstantExpression constantExpression) || !string.IsNullOrEmpty(constantExpression.ExpressionResult.TextValue))
				{
					return num;
				}
			}
			return 0;
		}

		private void BuildChildrenBlocks(ProgramNode node, BlockElementScript parentBlockScript)
		{
			List<NodeFormat.Token> list = NodeFormat.Tokenize(parentBlockScript.Format);
			if (parentBlockScript.Style.HasDynamicExpressionsSlots && node.Expressions.Count > 0)
			{
				int indexOfLastUsedExpression = GetIndexOfLastUsedExpression(node);
				if (indexOfLastUsedExpression == node.Expressions.Count - 1)
				{
					List<ProgramExpression> list2 = new List<ProgramExpression>();
					list2.AddRange(node.Expressions);
					list2.Add(new ConstantExpression(string.Empty));
					parentBlockScript.Node.InitializeExpressions(list2.ToArray());
				}
				else if (indexOfLastUsedExpression < node.Expressions.Count - 2)
				{
					List<ProgramExpression> list3 = new List<ProgramExpression>();
					list3.AddRange(node.Expressions.Take(indexOfLastUsedExpression + 1));
					parentBlockScript.Node.InitializeExpressions(list3.ToArray());
				}
				if (node.GetExpression(node.Expressions.Count - 1) is ConstantExpression constantExpression && string.IsNullOrEmpty(constantExpression.ExpressionResult.TextValue))
				{
					int num = node.Expressions.Count - 1;
					while (num > 0)
					{
						num--;
						if (!(node.GetExpression(num) is ConstantExpression constantExpression2) || !string.IsNullOrEmpty(constantExpression2.ExpressionResult.TextValue))
						{
							break;
						}
					}
				}
				else
				{
					List<ProgramExpression> list4 = new List<ProgramExpression>();
					list4.AddRange(node.Expressions);
					list4.Add(new ConstantExpression(string.Empty));
					parentBlockScript.Node.InitializeExpressions(list4.ToArray());
				}
				for (int i = 0; i < node.Expressions.Count; i++)
				{
					if (i > 0)
					{
						NodeFormat.Token item = new NodeFormat.Token(" ", NodeFormat.TokenType.Text);
						list.Add(item);
					}
					NodeFormat.Token item2 = new NodeFormat.Token(i.ToString(), NodeFormat.TokenType.Input);
					list.Add(item2);
				}
			}
			foreach (NodeFormat.Token item3 in list)
			{
				BlockElementScript blockElementScript = null;
				if (item3.TokenType == NodeFormat.TokenType.Boolean || item3.TokenType == NodeFormat.TokenType.Input)
				{
					blockElementScript = BuildExpressionSlotElement(node, item3);
				}
				else if (item3.TokenType == NodeFormat.TokenType.LocalVariableDefinition)
				{
					VariableExpression variableExpression = new VariableExpression();
					variableExpression.IsLocal = true;
					if (node is ForInstruction)
					{
						ForInstruction forInstruction = node as ForInstruction;
						variableExpression.VariableName = forInstruction.VariableName;
					}
					else
					{
						variableExpression.VariableName = item3.Text;
					}
					variableExpression.IsDefinition = true;
					blockElementScript = BuildExpressionElement(variableExpression, item3);
				}
				else
				{
					blockElementScript = ((item3.TokenType != NodeFormat.TokenType.List) ? BuildTextElement(item3.Text, parentBlockScript, parentBlockScript.Style.RichText) : BuildListElement(node, item3.Text));
				}
				parentBlockScript.AddChild(blockElementScript);
			}
		}

		private BlockElementScript BuildExpressionSlotElement(ProgramNode parent, NodeFormat.Token token)
		{
			ExpressionSlotElementScript expressionSlotElementScript = CreateBlock<ExpressionSlotElementScript>(_prefabExpressionSlotElement, parent);
			expressionSlotElementScript.InitializeExpression(token, this);
			return expressionSlotElementScript;
		}

		private BlockElementScript BuildListElement(ProgramNode node, string listId)
		{
			ListElementScript listElementScript = CreateBlock<ListElementScript>(_prefabListElement, node, "list");
			listElementScript.Initialize(listId);
			return listElementScript;
		}

		private BlockElementScript BuildTextElement(string text, BlockElementScript parentBlockScript, bool richText = false)
		{
			TextElementScript textElementScript = CreateBlock<TextElementScript>(_prefabTextElement, null, "text");
			textElementScript.Text = text;
			textElementScript.SetTextColor(parentBlockScript.Style.TextColor);
			textElementScript.RichText = richText;
			return textElementScript;
		}

		private T CreateBlock<T>(GameObject prefab, ProgramNode node, string styleOverride = null) where T : BlockElementScript
		{
			GameObject obj = Object.Instantiate(prefab);
			obj.name = "Node-" + _uniqueDisplayId++;
			BlockElementScript component = obj.GetComponent<BlockElementScript>();
			obj.transform.localPosition = Vector3.zero;
			string style = ((styleOverride != null) ? styleOverride : node?.Style);
			component.Initialize(_vizzyUI, node, style);
			return (T)component;
		}
	}
}
