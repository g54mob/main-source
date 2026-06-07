using System.Text.RegularExpressions;
using Assets.Scripts.Vizzy.UI.Elements;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI
{
	public class CreateCustomNodeDialogScript : DialogScript
	{
		private VizzyUIController _controller;

		private bool _expression;

		private string _format;

		private string _name;

		private BlockElementScript _nodeElement;

		private XmlElement _nodePanel;

		private XmlElement _panel;

		public static CreateCustomNodeDialogScript Create(Transform parent)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/Vizzy/CreateCustomNodeDialog", parent, delegate(CreateCustomNodeDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				Object.Destroy(base.gameObject);
			});
		}

		public void Initialize(VizzyUIController controller, bool expression, string name)
		{
			_panel.AddClass(expression ? "node-expression" : "node-instruction");
			_expression = expression;
			_controller = controller;
			_name = name;
			_format = name;
			UpdateNode();
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show();
		}

		private string GenerateCallFormat(string format)
		{
			Regex regex = new Regex("\\|[^\\|]+\\|");
			string text = format;
			int num = 0;
			Match match = regex.Match(text);
			while (match.Success)
			{
				text = text.Replace(match.Value, "(" + num + ")");
				num++;
				match = match.NextMatch();
			}
			return text;
		}

		private string GetStyle()
		{
			if (_expression)
			{
				return "custom-expression";
			}
			return "custom-instruction";
		}

		private void OnAddTextButtonClicked(XmlElement element)
		{
			InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.MessageText = "Add Text";
			inputDialogScript.InputPlaceholderText = "Enter Text";
			inputDialogScript.InvalidCharacters.AddRange("([{|)]}|");
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				string inputText = d.InputText;
				if (inputText.Length > 0)
				{
					_format += inputText;
				}
				d.Close();
				UpdateNode();
			};
		}

		private void OnAddParameterButtonClicked(XmlElement element)
		{
			InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.MessageText = "Add Parameter\nParameters can be used to pass data into your custom expression/instruction when they are executed.";
			inputDialogScript.InputPlaceholderText = "ParameterName";
			inputDialogScript.InvalidCharacters.AddRange("([{|)]}|");
			inputDialogScript.InvalidCharacters.AddRange("!@#$%^&*()-+={}[]|\\:\";',/<>.? ");
			inputDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				string text = "|" + d.InputText.Trim() + "|";
				if (text.Length > 2)
				{
					if (!_format.Contains(text))
					{
						if (!_format.EndsWith(" "))
						{
							_format += " ";
						}
						_format = _format + text + " ";
						d.Close();
						UpdateNode();
					}
					else
					{
						Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You cannot use that parameter name because it has already been used";
					}
				}
			};
		}

		private void OnCancelButtonClicked()
		{
			Close();
		}

		private void OnCreateButtonClicked()
		{
			if (!string.IsNullOrEmpty(_format))
			{
				FlightProgram flightProgram = _controller.VizzyUI.FlightProgram;
				if (_expression)
				{
					CustomExpression customExpression = new CustomExpression();
					customExpression.Name = _name;
					customExpression.Style = GetStyle();
					customExpression.Format = _format + " return (0)";
					customExpression.CallFormat = GenerateCallFormat(_format);
					customExpression.InitializeExpressions(new ProgramExpression[1]);
					customExpression.SetExpression(0, new ConstantExpression(0.0));
					flightProgram.AddCustomExpression(customExpression);
					_controller.VizzyUI.CreateElementForNode(customExpression);
				}
				else
				{
					CustomInstruction customInstruction = new CustomInstruction();
					customInstruction.Name = _name;
					customInstruction.Style = GetStyle();
					customInstruction.Format = _format;
					customInstruction.CallFormat = GenerateCallFormat(_format);
					customInstruction.InitializeExpressions();
					flightProgram.AddCustomInstruction(customInstruction);
					_controller.VizzyUI.CreateElementForNode(customInstruction);
				}
				_controller.RefreshUI();
				Close();
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You must add some text before you can create a custom expression/instruction.";
			}
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_nodePanel = xmlLayout.GetElementById("node-panel");
			_panel.SetAttribute("active", "false");
		}

		private void UpdateNode()
		{
			if (_nodeElement != null)
			{
				_nodeElement.Destroy();
			}
			ProgramNode programNode = null;
			programNode = ((!_expression) ? ((ProgramNode)new CustomInstruction
			{
				Style = GetStyle(),
				Format = _format
			}) : ((ProgramNode)new CustomExpression
			{
				Style = GetStyle(),
				Format = _format
			}));
			_nodeElement = _controller.VizzyUI.NodeBuilder.BuildProgramNodeElement(programNode);
			_nodeElement.RectTransform.pivot = new Vector2(0.5f, 0.5f);
			_nodeElement.RectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			_nodeElement.RectTransform.anchorMax = new Vector2(0.5f, 0.5f);
			_nodeElement.RectTransform.anchoredPosition = new Vector2(0f, 0f);
			_nodeElement.transform.SetParent(_nodePanel.transform, worldPositionStays: false);
			float num = _nodePanel.rectTransform.rect.width * 0.95f;
			if (_nodeElement.Size.x > num)
			{
				float num2 = num / _nodeElement.Size.x;
				_nodeElement.RectTransform.localScale = new Vector3(num2, num2, 1f);
			}
			_nodeElement.DragBehavior = DragBehaviorType.Disabled;
			_nodeElement.SupportsClone = false;
			foreach (BlockElementScript childBlock in _nodeElement.ChildBlocks)
			{
				childBlock.DragBehavior = DragBehaviorType.Disabled;
				childBlock.SupportsClone = false;
			}
		}
	}
}
