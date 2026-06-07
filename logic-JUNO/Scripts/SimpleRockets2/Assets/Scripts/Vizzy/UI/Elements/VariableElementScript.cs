using ModApi.Craft.Program;
using ModApi.Craft.Program.Instructions;
using ModApi.Ui;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class VariableElementScript : ExpressionElementScript
	{
		private VariableExpression _expression;

		private TextMeshProUGUI _tmp;

		public string Text
		{
			get
			{
				return _tmp.text;
			}
			set
			{
				_tmp.text = value;
			}
		}

		public override void Initialize(IVizzyUI vizzyUI, ProgramNode node, string style)
		{
			base.Initialize(vizzyUI, node, style);
			_expression = node as VariableExpression;
			if (_expression.IsDefinition)
			{
				base.DragBehavior = DragBehaviorType.Clone;
				base.ConnectionPoints[0].CanReceive = false;
			}
		}

		public override Vector2 LayoutElement()
		{
			Text = _expression.VariableName;
			Vector2 blockSize = new Vector2(_tmp.preferredWidth + (float)base.Padding.left + (float)base.Padding.right, base.RectTransform.sizeDelta.y + (float)base.Padding.top + (float)base.Padding.bottom);
			base.Size = SetBlockSize(blockSize);
			return base.Size;
		}

		protected override void Awake()
		{
			base.Awake();
			_tmp = GetComponentInChildren<TextMeshProUGUI>();
		}

		protected override void OnPointerClick(PointerEventData eventData)
		{
			ForInstruction forInstruction = base.Parent?.Node as ForInstruction;
			if (forInstruction == null)
			{
				return;
			}
			InputDialogScript inputDialogScript = VizzyUIController.CreateVariableNameInputDialog(_expression.VariableName);
			inputDialogScript.MessageText = "RENAME LOCAL VARIABLE";
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				d.Close();
				string inputText = d.InputText;
				if (inputText != null && inputText.Length > 0)
				{
					string inputText2 = d.InputText;
					string variableName = _expression.VariableName;
					forInstruction.VariableName = inputText2;
					RenameLocalVariableInScope(forInstruction.FirstChild, variableName, inputText2);
					base.VizzyUI.NodeBuilder.RebuildChildren(base.Parent);
				}
			};
		}

		protected override void Start()
		{
			Text = _expression.VariableName;
		}

		private void RenameLocalVariableInScope(ProgramInstruction instruction, string oldName, string newName)
		{
			if (instruction == null)
			{
				return;
			}
			foreach (ProgramExpression expression in instruction.Expressions)
			{
				if (expression is VariableExpression { IsLocal: not false } variableExpression && variableExpression.VariableName == oldName)
				{
					variableExpression.VariableName = newName;
				}
			}
			if (!(instruction is ForInstruction forInstruction) || forInstruction.VariableName != oldName)
			{
				RenameLocalVariableInScope(instruction.FirstChild, oldName, newName);
			}
			RenameLocalVariableInScope(instruction.Next, oldName, newName);
		}
	}
}
