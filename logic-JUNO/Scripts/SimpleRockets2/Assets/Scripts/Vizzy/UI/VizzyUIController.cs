using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Ui;
using Assets.Scripts.Vizzy.UI.Elements;
using Assets.Scripts.Web;
using ModApi;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;
using ModApi.Services.Purchasing;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Vizzy.UI
{
	public class VizzyUIController : XmlLayoutController
	{
		private enum CreateTypeEnum
		{
			None = 0,
			Variable = 1,
			List = 2,
			Expression = 3,
			Instruction = 4
		}

		public const string InvalidCustomNodeCharacters = "([{|)]}|";

		public const string InvalidVariableCharacters = "!@#$%^&*()-+={}[]|\\:\";',/<>.? ";

		private const string CustomExpressionsCategory = "Custom Expressions";

		private const string CustomInstructionsCategory = "Custom Instructions";

		private static bool _gridEnabled = true;

		private Dictionary<string, XmlElement> _categories = new Dictionary<string, XmlElement>();

		private XmlElement _createButton;

		private CreateTypeEnum _createType;

		private XmlElement _grid;

		private Toggle _gridToggle;

		private RectTransform _messageBackground;

		private XmlElement _messageText;

		private float _messageTime;

		private XmlElement _redoButton;

		private XmlElement _selectedCategoryButton;

		private XmlElement _templateCategoryButton;

		private XmlElement _undoButton;

		public RectTransform ConnectionHintLine { get; private set; }

		public RectTransform DragTransform { get; private set; }

		public XmlElement DropPanel { get; private set; }

		public bool GridEnabled
		{
			get
			{
				return _gridEnabled;
			}
			set
			{
				_gridEnabled = value;
				_gridToggle?.SetIsOnWithoutNotify(value);
				_grid?.SetActive(_gridEnabled);
			}
		}

		public ProgramContainerScript ProgramContainer { get; private set; }

		public RectTransform ProgramTransform { get; private set; }

		public XmlElement SelectedCategoryButton
		{
			get
			{
				return _selectedCategoryButton;
			}
			set
			{
				if (_selectedCategoryButton != null)
				{
					_selectedCategoryButton.RemoveClass("toggle-button-toggled");
				}
				_selectedCategoryButton = value;
				if (_selectedCategoryButton != null)
				{
					_selectedCategoryButton.AddClass("toggle-button-toggled");
				}
			}
		}

		public DropZoneScript TrashCanDropZone { get; private set; }

		public VizzyUIScript VizzyUI { get; private set; }

		private CreateTypeEnum CreateType
		{
			get
			{
				return _createType;
			}
			set
			{
				if (_createType == value)
				{
					return;
				}
				_createType = value;
				string value2 = string.Empty;
				string text = string.Empty;
				if (_createType == CreateTypeEnum.Variable)
				{
					value2 = "Create a new variable to use in the program.";
					text = "Create Variable";
				}
				else if (_createType == CreateTypeEnum.List)
				{
					value2 = "Create a new list variable to use in the program.";
					text = "Create List Variable";
				}
				else if (_createType == CreateTypeEnum.Expression)
				{
					value2 = "Create a custom expression to use in the program.";
					text = "Create Custom Expression";
				}
				else if (_createType == CreateTypeEnum.Instruction)
				{
					value2 = "Create a custom instruction to use in the program.";
					text = "Create Custom Instruction";
				}
				if (!string.IsNullOrEmpty(text))
				{
					_createButton.GetElementByInternalId("button-text").SetText(text);
					_createButton.SetAndApplyAttribute("tooltip", value2);
					if (!VizzyUI.Interactable)
					{
						_createButton.SetAndApplyAttribute("interactable", "false");
					}
					_createButton.Show();
				}
				else
				{
					_createButton.Hide();
				}
			}
		}

		public static ModApi.Ui.InputDialogScript CreateVariableNameInputDialog(string currentName)
		{
			ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.CancelButtonText = "CANCEL";
			inputDialogScript.InputPlaceholderText = "VariableName";
			if (currentName == null)
			{
				inputDialogScript.MessageText = "CREATE VARIABLE\nOnly letters and numbers are allowed. No special characters and no spaces.";
				inputDialogScript.OkayButtonText = "CREATE";
			}
			else
			{
				inputDialogScript.MessageText = "RENAME VARIABLE";
				inputDialogScript.OkayButtonText = "RENAME";
				inputDialogScript.InputText = currentName;
			}
			inputDialogScript.InvalidCharacters.AddRange("!@#$%^&*()-+={}[]|\\:\";',/<>.? ".ToCharArray());
			return inputDialogScript;
		}

		public void Initialize(VizzyUIScript vizzyUI)
		{
			VizzyUI = vizzyUI;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			ProgramTransform = base.xmlLayout.GetElementById<RectTransform>("program-panel");
			RectTransform elementById = base.xmlLayout.GetElementById<RectTransform>("program-container");
			ProgramContainer = elementById.gameObject.AddComponent<ProgramContainerScript>();
			ProgramContainer.VizzyUI = VizzyUI;
			XmlElement elementById2 = base.xmlLayout.GetElementById("trashcan-dropzone");
			TrashCanDropZone = elementById2.gameObject.AddComponent<DropZoneScript>();
			_createButton = base.xmlLayout.GetElementById("create-button");
			ConnectionHintLine = base.xmlLayout.GetElementById<RectTransform>("connection-hint-line");
			DragTransform = base.xmlLayout.GetElementById<RectTransform>("drag-panel");
			_undoButton = base.xmlLayout.GetElementById("undo-button");
			_redoButton = base.xmlLayout.GetElementById("redo-button");
			_messageText = base.xmlLayout.GetElementById("message-text");
			_messageBackground = base.xmlLayout.GetElementById<RectTransform>("message-background");
			_grid = base.xmlLayout.GetElementById("grid");
			_gridToggle = base.xmlLayout.GetElementById<Toggle>("grid-toggle");
			GridEnabled = _gridEnabled;
			CreateToolboxCategories();
			IInAppPurchaseFeature vizzy = Game.Instance.InAppPurchases.Features.Vizzy;
			if (!vizzy.Unlocked)
			{
				VizzyUI.Interactable = false;
				XmlElement elementById3 = base.xmlLayout.GetElementById("upgrade-panel");
				elementById3.SetActive(active: true);
				elementById3.GetElementByInternalId<TextMeshProUGUI>("label").text = "Vizzy is currently read-only and programs cannot be modified.\nUpgrade to the " + vizzy.ProductName + " to fully unlock Vizzy.";
			}
		}

		public void OnClosePanelClicked()
		{
			ClosePanel();
		}

		public void RefreshUI()
		{
			if (VizzyUI != null)
			{
				RefreshCategory();
			}
		}

		public void ShowDragUI(bool show)
		{
			base.xmlLayout.GetElementById("drop-zones").SetActive(show);
			base.xmlLayout.GetElementById("main-ui").SetAndApplyAttribute("opacity", show ? "0" : "1");
		}

		public void ShowMessage(string message, float time = 7f)
		{
			ShowMessage(message, error: false, time);
		}

		public void ShowValidationError(string message)
		{
			ShowMessage(message, error: true);
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
			if (VizzyUI.UndoHistory.RedoStepsAvailable)
			{
				_redoButton.RemoveClass("disabled");
			}
			else
			{
				_redoButton.AddClass("disabled");
			}
			if (VizzyUI.UndoHistory.UndoStepsAvailable)
			{
				_undoButton.RemoveClass("disabled");
			}
			else
			{
				_undoButton.AddClass("disabled");
			}
			if (_messageTime > 0f)
			{
				_messageTime -= Time.unscaledDeltaTime;
			}
			else if (_messageText.Visible && !_messageText.IsAnimating)
			{
				_messageBackground.gameObject.SetActive(value: false);
				_messageText.Hide();
			}
		}

		private void ClosePanel()
		{
			XmlElement elementById = base.xmlLayout.GetElementById("toolbox");
			base.xmlLayout.GetElementById("menu").Hide();
			elementById.Hide();
			SelectedCategoryButton = null;
		}

		private void CreateOrEditVariableDialog(string currentName, bool list)
		{
			CreateVariableNameInputDialog(currentName).OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				string inputText = d.InputText;
				if (inputText.Length > 0)
				{
					if (VizzyUI.FlightProgram.GlobalVariables.GetVariable(inputText) == null)
					{
						if (currentName == null)
						{
							ExpressionResult value = null;
							if (list)
							{
								value = new ExpressionResult(new List<ExpressionListItem>());
							}
							Variable variable = new Variable(inputText, value);
							VizzyUI.FlightProgram.GlobalVariables.AddVariable(variable);
						}
						else
						{
							VizzyUI.RenameVariable(currentName, inputText);
						}
						RefreshCategory();
						d.Close();
					}
					else
					{
						ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
						messageDialogScript.UseDangerButtonStyle = true;
						messageDialogScript.MessageText = "A variable with that name already exists. Please use a different name.";
					}
				}
			};
		}

		private void CreateToolboxCategories()
		{
			XmlElement elementById = base.xmlLayout.GetElementById("category-panel");
			_templateCategoryButton = base.xmlLayout.GetElementById("template-category");
			if (_templateCategoryButton == null)
			{
				Debug.LogError("Unable to find the Vizzy toolbox category template UI element.");
				return;
			}
			foreach (VizzyToolbox.NodeCategory category in VizzyUI.Toolbox.Categories)
			{
				XmlElement xmlElement = UiUtilities.CloneTemplate(_templateCategoryButton, elementById);
				xmlElement.name = "Category." + category.Name;
				xmlElement.Tooltip = category.Name;
				xmlElement.SetAttribute("name", xmlElement.name);
				xmlElement.SetAttribute("data-category-id", category.Name);
				xmlElement.childElements[0].SetAndApplyAttribute("sprite", category.IconPath);
				_categories[category.Name] = xmlElement;
			}
		}

		private void EnableCategoryButton(XmlElement xmlElement, bool enable)
		{
			xmlElement.SetActive(enable);
			if (!enable && _selectedCategoryButton == xmlElement)
			{
				ClosePanel();
			}
		}

		private Vector2 LoadNodes(List<ProgramNode> nodes, RectTransform parent, XmlElement template, float startingPosition = 10f)
		{
			float num = 0f;
			Vector2 anchoredPosition = new Vector2(20f, 0f - startingPosition);
			foreach (ProgramNode node in nodes)
			{
				BlockElementScript blockElementScript = VizzyUI.NodeBuilder.BuildProgramNodeElement(node);
				if (!string.IsNullOrEmpty(blockElementScript.Style.Tooltip))
				{
					XmlElement xmlElement = blockElementScript.gameObject.AddComponent<XmlElement>();
					xmlElement.Initialise(base.xmlLayout, (RectTransform)xmlElement.transform, null);
					xmlElement.Tooltip = blockElementScript.Style.Tooltip;
					xmlElement.SetAttribute("tooltipPosition", "Above");
				}
				if (template != null)
				{
					XmlElement xmlElement2 = UiUtilities.CloneTemplate(template, parent.GetComponent<XmlElement>());
					blockElementScript.RectTransform.SetParent(xmlElement2.rectTransform, worldPositionStays: false);
					blockElementScript.RectTransform.anchoredPosition += new Vector2(30f, 0f);
					xmlElement2.rectTransform.anchoredPosition = anchoredPosition;
				}
				else
				{
					blockElementScript.RectTransform.pivot = new Vector2(0f, 1f);
					blockElementScript.RectTransform.anchorMin = new Vector2(0f, 1f);
					blockElementScript.RectTransform.anchorMax = new Vector2(0f, 1f);
					blockElementScript.RectTransform.SetParent(parent, worldPositionStays: false);
					blockElementScript.RectTransform.anchoredPosition = anchoredPosition;
				}
				BlockElementScript[] componentsInChildren = blockElementScript.GetComponentsInChildren<BlockElementScript>();
				foreach (BlockElementScript obj in componentsInChildren)
				{
					obj.DragBehavior = DragBehaviorType.Disabled;
					obj.AllowEditing = false;
				}
				if (VizzyUI.Interactable)
				{
					blockElementScript.DragBehavior = DragBehaviorType.Clone;
					blockElementScript.RequireHorizontalDrag = true;
				}
				anchoredPosition -= new Vector2(0f, blockElementScript.Size.y + 10f);
				num = Mathf.Max(num, blockElementScript.Size.x);
			}
			Vector2 sizeDelta = parent.sizeDelta;
			sizeDelta.y = 0f - anchoredPosition.y + 50f;
			parent.sizeDelta = sizeDelta;
			return new Vector2(num, 0f - anchoredPosition.y);
		}

		private void OnButtonApplyClicked()
		{
			VizzyUI.ApplyChangesToCraft();
			VizzyUI.Close();
			Game.Instance.Designer.DesignerUi.ShowMessage("Program saved to craft.");
		}

		private void OnButtonCancelClicked()
		{
			ModApi.Ui.MessageDialogScript dialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			dialog.UseDangerButtonStyle = true;
			dialog.MessageText = "Are you sure you want to discard your changes to the craft's flight program? Unsaved changes will be lost.";
			dialog.OkayClicked += delegate
			{
				dialog.Close();
				VizzyUI.Close();
				Game.Instance.Designer.DesignerUi.ShowMessage("Program changes discarded.");
			};
		}

		private void OnButtonCreateClicked()
		{
			if (CreateType == CreateTypeEnum.Variable)
			{
				CreateOrEditVariableDialog(null, list: false);
			}
			else if (CreateType == CreateTypeEnum.List)
			{
				CreateOrEditVariableDialog(null, list: true);
			}
			else if (CreateType == CreateTypeEnum.Expression)
			{
				ShowCreateCustomNodeDialog(CreateTypeEnum.Expression);
			}
			else if (CreateType == CreateTypeEnum.Instruction)
			{
				ShowCreateCustomNodeDialog(CreateTypeEnum.Instruction);
			}
		}

		private void OnButtonHelpClicked()
		{
			WebUtility.OpenUrl(Game.SimpleRocketsWebsiteUrl + "/Client/RedirectVizzyHelp");
		}

		private void OnButtonImportClicked()
		{
			LoadProgramViewModel viewModel = new LoadProgramViewModel(VizzyUI, import: true);
			Game.Instance.UserInterface.CreateListView(viewModel);
		}

		private void OnButtonLoadClicked()
		{
			LoadProgramViewModel viewModel = new LoadProgramViewModel(VizzyUI, import: false);
			Game.Instance.UserInterface.CreateListView(viewModel);
		}

		private void OnButtonNewClicked()
		{
			ModApi.Ui.MessageDialogScript dialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			dialog.MessageText = "Are you sure you want to create a new program? Unsaved changes will be lost.";
			dialog.OkayClicked += delegate
			{
				dialog.Close();
				VizzyUI.LoadNewFlightProgram();
			};
		}

		private void OnButtonRedoClicked()
		{
			VizzyUI.Redo();
		}

		private void OnButtonSaveClicked()
		{
			ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.InputPlaceholderText = "PROGRAM NAME";
			inputDialogScript.MessageText = "SAVE PROGRAM";
			inputDialogScript.OkayButtonText = "SAVE";
			inputDialogScript.CancelButtonText = "CANCEL";
			inputDialogScript.InputText = Utilities.ScrubFileName(VizzyUI.FlightProgram.Name);
			inputDialogScript.InvalidCharacters.AddRange(Path.GetInvalidFileNameChars());
			inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				SaveProgramToFile(d.InputText, overwrite: false);
				d.Close();
			};
		}

		private void OnButtonUndoClicked()
		{
			VizzyUI.Undo();
		}

		private void OnCategoryButtonClicked(XmlElement xmlElement)
		{
			if (SelectedCategoryButton != xmlElement)
			{
				SelectedCategoryButton = xmlElement;
				RefreshCategory();
			}
			else
			{
				ClosePanel();
			}
		}

		private void OnEditVariableClicked(XmlElement image)
		{
			ExpressionElementScript componentInChildren = image.parentElement.GetComponentInChildren<ExpressionElementScript>();
			VariableExpression variableExpression = componentInChildren.Expression as VariableExpression;
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.ThreeButtons);
			messageDialogScript.MessageText = "Would you like to rename this variable or delete it from the program?";
			messageDialogScript.MiddleButtonText = "RENAME";
			messageDialogScript.OkayButtonText = "DELETE";
			messageDialogScript.UseDangerButtonStyle = true;
			string variableName = variableExpression.VariableName;
			messageDialogScript.MiddleClicked += delegate(ModApi.Ui.MessageDialogScript editDialog)
			{
				editDialog.Close();
				CreateOrEditVariableDialog(variableName, variableExpression.IsList);
			};
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript editDialog)
			{
				editDialog.Close();
				VizzyUI.DeleteVariable(variableName);
				RefreshCategory();
			};
		}

		private void OnGridEnabledChanged()
		{
			GridEnabled = _gridToggle.isOn;
		}

		private void OnUpgradeClicked()
		{
			Game.Instance.InAppPurchases.CreatePurchaseDialog(Game.Instance.InAppPurchases.Features.Vizzy.ProductId);
		}

		private void RefreshCategory()
		{
			if (SelectedCategoryButton != null)
			{
				string attribute = SelectedCategoryButton.GetAttribute("data-category-id");
				UpdateCategory(attribute);
			}
		}

		private void SaveProgramToFile(string programName, bool overwrite)
		{
			FileInfo flightProgramFile = VizzyUIScript.GetFlightProgramFile(programName);
			if (!overwrite && flightProgramFile.Exists)
			{
				ModApi.Ui.MessageDialogScript dialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
				dialog.UseDangerButtonStyle = true;
				dialog.MessageText = "A program already exists with that name. Do you wish to overwrite it?";
				dialog.OkayClicked += delegate
				{
					dialog.Close();
					SaveProgramToFile(programName, overwrite: true);
				};
			}
			else
			{
				VizzyUI.FlightProgram.Name = programName;
				XElement xElement = VizzyUI.SaveFlightProgram();
				new XDocument(xElement).Save(flightProgramFile.FullName);
			}
		}

		private void ShowCreateCustomNodeDialog(CreateTypeEnum createType)
		{
			string nodeType = ((createType == CreateTypeEnum.Expression) ? "Expression" : "Instruction");
			ModApi.Ui.InputDialogScript input = Game.Instance.UserInterface.CreateInputDialog();
			input.MessageText = $"Enter a name for this Custom {nodeType}.";
			input.InputPlaceholderText = nodeType + " Name";
			input.InvalidCharacters.AddRange("([{|)]}|");
			input.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				string name = input.InputText.Trim();
				if (!string.IsNullOrWhiteSpace(name))
				{
					if ((VizzyUI.FlightProgram.CustomExpressions.Any((CustomExpression x) => string.Compare(x.Name, name, ignoreCase: true) == 0) && createType == CreateTypeEnum.Expression) || (VizzyUI.FlightProgram.CustomInstructions.Any((CustomInstruction x) => string.Compare(x.Name, name, ignoreCase: true) == 0) && createType == CreateTypeEnum.Instruction))
					{
						Game.Instance.UserInterface.CreateMessageDialog().MessageText = $"There is already a Custom {nodeType} with this name. Please choose a different name.";
					}
					else
					{
						CreateCustomNodeDialogScript.Create(base.transform).Initialize(this, createType == CreateTypeEnum.Expression, input.InputText);
						d.Close();
					}
				}
			};
		}

		private void ShowMessage(string message, bool error, float time = 7f)
		{
			_messageText.Show();
			_messageText.SetAndApplyAttribute("text", message);
			if (error)
			{
				_messageText.AddClass("error");
			}
			else
			{
				_messageText.RemoveClass("error");
			}
			_messageTime = time;
			if (!string.IsNullOrWhiteSpace(message))
			{
				_messageBackground.gameObject.SetActive(value: true);
				RectTransform rectTransform = _messageText.rectTransform;
				TextMeshProUGUI component = _messageText.GetComponent<TextMeshProUGUI>();
				float b = component.preferredWidth + 10f;
				b = Mathf.Min(rectTransform.rect.width, b);
				_messageBackground.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, b + 10f);
				_messageBackground.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, component.preferredHeight + 10f);
				_messageBackground.position = rectTransform.position - new Vector3(0f, component.preferredHeight / 2f, 0f);
			}
		}

		private void UpdateCategory(string categoryId)
		{
			VizzyToolbox.NodeCategory category = VizzyUI.Toolbox.GetCategory(categoryId);
			XmlElement elementById = base.xmlLayout.GetElementById("toolbox-node-parent");
			foreach (Transform item in elementById.transform)
			{
				item.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(item.gameObject);
			}
			XmlElement elementById2 = base.xmlLayout.GetElementById("toolbox");
			XmlElement elementById3 = base.xmlLayout.GetElementById("menu");
			if (categoryId == "Menu")
			{
				elementById2.Hide();
				elementById3.Show();
				return;
			}
			elementById3.Hide();
			elementById2.Show();
			base.xmlLayout.GetElementById("category-text").SetText(categoryId);
			float num = 0f;
			switch (categoryId)
			{
			case "Custom Instructions":
			{
				CreateType = CreateTypeEnum.Instruction;
				List<ProgramNode> list4 = new List<ProgramNode>();
				foreach (CustomInstruction item2 in VizzyUI.FlightProgram.CustomInstructions.OrderBy((CustomInstruction x) => x.Name).ToList())
				{
					CallCustomInstruction callCustomInstruction = new CallCustomInstruction();
					callCustomInstruction.Call = item2.Name;
					callCustomInstruction.Style = "call-custom-instruction";
					int numExpressionsInFormat2 = NodeFormat.GetNumExpressionsInFormat(item2.CallFormat);
					callCustomInstruction.InitializeExpressions(new ProgramExpression[numExpressionsInFormat2]);
					for (int num3 = 0; num3 < numExpressionsInFormat2; num3++)
					{
						callCustomInstruction.SetExpression(num3, new ConstantExpression(0.0));
					}
					list4.Add(callCustomInstruction);
				}
				num = LoadNodes(list4, elementById.rectTransform, null).x;
				break;
			}
			case "Custom Expressions":
			{
				CreateType = CreateTypeEnum.Expression;
				List<ProgramNode> list2 = new List<ProgramNode>();
				foreach (CustomExpression item3 in VizzyUI.FlightProgram.CustomExpressions.OrderBy((CustomExpression x) => x.Name).ToList())
				{
					CallCustomExpression callCustomExpression = new CallCustomExpression();
					callCustomExpression.Call = item3.Name;
					callCustomExpression.Style = "call-custom-expression";
					int numExpressionsInFormat = NodeFormat.GetNumExpressionsInFormat(item3.CallFormat);
					callCustomExpression.InitializeExpressions(new ProgramExpression[numExpressionsInFormat]);
					for (int num2 = 0; num2 < numExpressionsInFormat; num2++)
					{
						callCustomExpression.SetExpression(num2, new ConstantExpression(0.0));
					}
					list2.Add(callCustomExpression);
				}
				num = LoadNodes(list2, elementById.rectTransform, null).x;
				break;
			}
			case "Lists":
			{
				CreateType = CreateTypeEnum.List;
				List<ProgramNode> list3 = new List<ProgramNode>();
				foreach (Variable item4 in VizzyUI.FlightProgram.GlobalVariables.Variables.Where((Variable x) => x.IsList).OrderBy((Variable x) => x.Name, StringComparer.OrdinalIgnoreCase).ToList())
				{
					VariableExpression variableExpression2 = new VariableExpression(list: true);
					variableExpression2.VariableName = item4.Name;
					list3.Add(variableExpression2);
				}
				Vector2 vector3 = LoadNodes(category.Nodes, elementById.rectTransform, null);
				Vector2 vector4 = LoadNodes(startingPosition: vector3.y, nodes: list3, parent: elementById.rectTransform, template: base.xmlLayout.GetElementById("template-variable"));
				num = Mathf.Max(vector3.x, vector4.x);
				break;
			}
			case "Variables":
			{
				CreateType = CreateTypeEnum.Variable;
				List<ProgramNode> list = new List<ProgramNode>();
				foreach (Variable item5 in VizzyUI.FlightProgram.GlobalVariables.Variables.Where((Variable x) => !x.IsList).OrderBy((Variable x) => x.Name, StringComparer.OrdinalIgnoreCase).ToList())
				{
					VariableExpression variableExpression = new VariableExpression();
					variableExpression.VariableName = item5.Name;
					list.Add(variableExpression);
				}
				Vector2 vector = LoadNodes(category.Nodes, elementById.rectTransform, null);
				Vector2 vector2 = LoadNodes(startingPosition: vector.y, nodes: list, parent: elementById.rectTransform, template: base.xmlLayout.GetElementById("template-variable"));
				num = Mathf.Max(vector.x, vector2.x);
				break;
			}
			default:
				CreateType = CreateTypeEnum.None;
				num = LoadNodes(category.Nodes, elementById.rectTransform, null).x;
				break;
			}
			elementById2.SetAndApplyAttribute("width", Mathf.Clamp(num + 30f, 250f, 500f).ToString());
		}
	}
}
