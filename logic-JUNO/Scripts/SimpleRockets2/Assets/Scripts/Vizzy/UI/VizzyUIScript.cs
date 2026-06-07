using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Ui;
using Assets.Scripts.Vizzy.UI.Elements;
using ModApi;
using ModApi.Audio;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Expressions;
using ModApi.Craft.Program.Instructions;
using ModApi.Input;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI
{
	public class VizzyUIScript : MonoBehaviour, IVizzyUI
	{
		public const string NewProgramName = "__new__";

		private static bool _achievementUnlocked;

		private Action<XElement> _applyCallback;

		private VizzyUIController _controller;

		[SerializeField]
		private GameObject _controllerGameObject;

		[SerializeField]
		private NodeBuilderScript _nodeBuilder;

		private BlockElementScript _selectedElement;

		private IUserInterface _userInterface;

		public static string FlightProgramsFolderPath => Utilities.CombinePaths(Game.PersistentDataPath, "UserData/FlightPrograms/");

		public Camera Camera => null;

		public DragSelection DragSelection { get; private set; }

		public RectTransform DragTransform => _controller.DragTransform;

		public FlightProgram FlightProgram { get; private set; }

		public bool Interactable { get; set; } = true;

		public bool IsMfdPart { get; private set; }

		public INodeBuilder NodeBuilder => _nodeBuilder;

		public RectTransform ProgramTransform => _controller.ProgramTransform;

		public BlockElementScript SelectedElement
		{
			get
			{
				return _selectedElement;
			}
			set
			{
				if (_selectedElement != null)
				{
					_selectedElement.VisualState = BlockElementScript.VisualStateType.Normal;
				}
				if (_selectedElement == value)
				{
					_selectedElement = null;
				}
				else
				{
					_selectedElement = value;
				}
				if (_selectedElement != null)
				{
					_nodeBuilder.BlockContextMenu.CurrentBlock = _selectedElement;
					_selectedElement.VisualState = BlockElementScript.VisualStateType.Brighter2;
				}
				else
				{
					_nodeBuilder.BlockContextMenu.CurrentBlock = null;
				}
			}
		}

		public VizzyToolbox Toolbox { get; private set; }

		public UndoHistory<UndoStep> UndoHistory { get; private set; } = new UndoHistory<UndoStep>(50);

		public event EventHandler Closed;

		public static FileInfo GetFlightProgramFile(string programName)
		{
			return new FileInfo(Path.Combine(FlightProgramsFolderPath, programName + ".xml"));
		}

		public static XElement LoadXml(string programName)
		{
			FileInfo flightProgramFile = GetFlightProgramFile(programName);
			if (flightProgramFile.Exists)
			{
				return XDocument.Load(flightProgramFile.FullName).Root;
			}
			return null;
		}

		public void ApplyChangesToCraft()
		{
			XElement obj = SaveFlightProgram();
			_applyCallback(obj);
			if (!_achievementUnlocked && (FlightProgram.RootExpressions.Count != 0 || FlightProgram.RootInstructions.Count != 1 || FlightProgram.RootInstructions[0].Next != null))
			{
				_achievementUnlocked = true;
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.CreateFlightProgram);
			}
		}

		public void Close()
		{
			this.Closed?.Invoke(this, new EventArgs());
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public BlockElementScript CreateElementForNode(ProgramNode programNode)
		{
			BlockElementScript blockElementScript = NodeBuilder.BuildProgramNodeElement(programNode);
			blockElementScript.RectTransform.SetParent(ProgramTransform, worldPositionStays: false);
			blockElementScript.OnChildSizeChanged();
			return blockElementScript;
		}

		public void CreateUndoStep(string ignoreKey = null)
		{
			if (UndoHistory.ShouldPushUndo(ignoreKey))
			{
				CreateUndoStep(ignoreKey, head: false);
			}
		}

		public void DeleteVariable(string variableName)
		{
			foreach (VariableElementScript variableElement in GetVariableElements(variableName))
			{
				variableElement.Destroy();
			}
			FlightProgram.GlobalVariables.DeleteVariable(variableName);
		}

		public void DisplayConnectionHint(Vector2 source, Vector2 target)
		{
			Vector2 vector = target - source;
			float z = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
			_controller.ConnectionHintLine.rotation = Quaternion.Euler(0f, 0f, z);
			_controller.ConnectionHintLine.position = (source + target) * 0.5f;
			float x = vector.magnitude / Game.UiScale;
			Vector2 sizeDelta = _controller.ConnectionHintLine.sizeDelta;
			sizeDelta.x = x;
			_controller.ConnectionHintLine.sizeDelta = sizeDelta;
			_controller.ConnectionHintLine.gameObject.SetActive(value: true);
		}

		public void DragBegin(List<BlockElementScript> blocks, Vector2 position)
		{
			if (DragSelection == null)
			{
				PlaySound(AudioLibrary.Vizzy.DisconnectNode);
				DragSelection = new DragSelection(this, position, blocks);
				_controller.ShowDragUI(show: true);
			}
		}

		public void DragEnd(Vector2 position)
		{
			bool flag = false;
			bool flag2 = false;
			if (DragSelection != null)
			{
				if (DragSelection.EndSelection())
				{
					PlaySound(AudioLibrary.Vizzy.ConnectNode);
				}
				else if (_controller.TrashCanDropZone.Selected)
				{
					string text = CanDeleteSelection(DragSelection);
					if (text == string.Empty)
					{
						foreach (BlockElementScript block in DragSelection.Blocks)
						{
							if (block.Node is CustomExpression)
							{
								FlightProgram.RemoveCustomExpression(block.Node as CustomExpression);
								flag = true;
							}
							else if (block.Node is CustomInstruction)
							{
								FlightProgram.RemoveCustomInstruction(block.Node as CustomInstruction);
								flag = true;
							}
							block.Destroy();
						}
						PlaySound(AudioLibrary.Vizzy.DeleteNode);
					}
					else
					{
						Game.Instance.UserInterface.CreateMessageDialog("Selection cannot be deleted:\n" + text);
						flag2 = true;
					}
				}
				else
				{
					flag2 = true;
					PlaySound(AudioLibrary.Vizzy.DropNode);
				}
				DragSelection = null;
			}
			_controller.ShowDragUI(show: false);
			string ignoreKey = null;
			if (flag2)
			{
				ignoreKey = "drag-no-connection";
			}
			CreateUndoStep(ignoreKey);
			if (flag)
			{
				_controller.RefreshUI();
			}
		}

		public void DragUpdate(Vector2 position)
		{
			DragSelection?.Update(position, _controller.TrashCanDropZone.Selected);
			_controller.TrashCanDropZone.UpdateDropZone(position);
		}

		public void HideConnectionHint()
		{
			_controller.ConnectionHintLine.gameObject.SetActive(value: false);
		}

		public void ImportFlightProgram(XElement programXml)
		{
			LoadFlightProgram(programXml, loadNewOnFailure: false, import: true, new Vector2(100f, 50f));
			_controller.ShowMessage("Imported Program");
		}

		public void Initialize(Transform parent, XElement flightProgramXml, bool isMfdPart, Action<XElement> applyCallback)
		{
			_applyCallback = applyCallback;
			_userInterface = Game.Instance.UserInterface;
			GetComponent<RectTransform>().SetParent(parent, worldPositionStays: false);
			string text = Game.Instance.ResourceLoader.LoadText("Ui/Xml/Vizzy/VizzyToolbox");
			Toolbox = new VizzyToolbox(XElement.Parse(text), isMfdPart);
			IsMfdPart = isMfdPart;
			CreateController();
			_nodeBuilder.Initialize(this);
			if (flightProgramXml != null)
			{
				LoadFlightProgram(flightProgramXml);
			}
			else
			{
				LoadNewFlightProgram();
			}
		}

		public void LoadFlightProgram(XElement programXml)
		{
			LoadFlightProgram(programXml, loadNewOnFailure: true, import: false, Vector2.zero);
			_controller.ShowMessage("Loaded Program");
		}

		public void LoadNewFlightProgram()
		{
			XElement programXml = LoadXml("__new__");
			LoadFlightProgram(programXml, loadNewOnFailure: false, import: false, Vector2.zero);
		}

		public AudioSource PlaySound(AudioFile audioFile)
		{
			return Game.Instance.Designer?.PlaySound(audioFile);
		}

		public void Redo()
		{
			UndoStep nextRedoStep = UndoHistory.GetNextRedoStep();
			if (nextRedoStep != null)
			{
				ShowMessage("Redo complete.");
				LoadFlightProgram(nextRedoStep.Xml);
			}
		}

		public void RenameVariable(string oldName, string newName)
		{
			List<VariableElementScript> variableElements = GetVariableElements(oldName);
			Variable variable = FlightProgram.GlobalVariables.GetVariable(oldName);
			FlightProgram.GlobalVariables.DeleteVariable(oldName);
			FlightProgram.GlobalVariables.AddVariable(new Variable(newName, variable.Value));
			foreach (VariableElementScript item in variableElements)
			{
				(item.Node as VariableExpression).VariableName = newName;
				item.OnChildSizeChanged();
			}
		}

		public XElement SaveFlightProgram()
		{
			ProgramSerializer programSerializer = new ProgramSerializer();
			FlightProgram.RootInstructions.Clear();
			FlightProgram.RootExpressions.Clear();
			FlightProgram.RequiresMfd = IsMfdPart;
			foreach (Transform item in ProgramTransform)
			{
				InstructionElementScript component = item.GetComponent<InstructionElementScript>();
				if (component != null)
				{
					if (component.PrevInstruction == null)
					{
						FlightProgram.RootInstructions.Add(component.Instruction);
						component.Instruction.EditorPosition = component.RectTransform.anchoredPosition3D;
					}
					continue;
				}
				ExpressionElementScript component2 = item.GetComponent<ExpressionElementScript>();
				if (component2 != null)
				{
					component2.Expression.EditorPosition = component2.RectTransform.anchoredPosition3D;
					FlightProgram.RootExpressions.Add(component2.Expression);
				}
			}
			return programSerializer.SerializeFlightProgram(FlightProgram);
		}

		public void ShowMessage(string message, float time = 7f)
		{
			_controller.ShowMessage(message, time);
		}

		public void ShowValidationError(string message)
		{
			_controller.ShowValidationError(message);
		}

		public void Undo()
		{
			if (!UndoHistory.RedoStepsAvailable)
			{
				CreateUndoStep(null, head: true);
			}
			UndoStep nextUndoStep = UndoHistory.GetNextUndoStep();
			if (nextUndoStep != null)
			{
				ShowMessage("Undo complete.");
				LoadFlightProgram(nextUndoStep.Xml, loadNewOnFailure: true, import: false, Vector2.zero);
			}
		}

		protected virtual void Update()
		{
			if (!_userInterface.AnyDialogsOpen && !_userInterface.IsTextInputFocused)
			{
				IGameInputs inputs = Game.Instance.Inputs;
				if (inputs.Undo.GetButtonDownIfEnabled() && UndoHistory.UndoStepsAvailable)
				{
					Undo();
				}
				else if (inputs.Redo.GetButtonDownIfEnabled() && UndoHistory.RedoStepsAvailable)
				{
					Redo();
				}
			}
		}

		private string CanDeleteSelection(DragSelection dragSelection)
		{
			string text = string.Empty;
			ProgramTransform.GetComponentsInChildren<BlockElementScript>();
			foreach (BlockElementScript block in DragSelection.Blocks)
			{
				CustomExpression ce = block.Node as CustomExpression;
				if (ce != null)
				{
					int num = (from x in ProgramTransform.GetComponentsInChildren<BlockElementScript>()
						where x.Node is CallCustomExpression
						select x.Node as CallCustomExpression).Distinct().ToList().Count((CallCustomExpression x) => x.Call == ce.Name);
					if (num > 0)
					{
						text += $"Custom Expression '{ce.Name}' is used in the program and cannot be deleted ({num} references).\n";
					}
				}
				CustomInstruction ci = block.Node as CustomInstruction;
				if (ci != null)
				{
					int num2 = (from x in ProgramTransform.GetComponentsInChildren<BlockElementScript>()
						where x.Node is CallCustomInstruction
						select x.Node as CallCustomInstruction).Distinct().ToList().Count((CallCustomInstruction x) => x.Call == ci.Name);
					if (num2 > 0)
					{
						text += $"Custom Instruction '{ci.Name}' is used in the program and cannot be deleted ({num2} references).\n";
					}
				}
			}
			return text;
		}

		private void CreateController()
		{
			XmlLayout xmlLayout = _controllerGameObject.AddComponent<XmlLayout>();
			_controller = _controllerGameObject.AddComponent<VizzyUIController>();
			_controller.Initialize(this);
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Vizzy/VizzyUI", xmlLayout);
		}

		private void CreateUndoStep(string ignoreKey, bool head)
		{
			UndoStep undoStep = new UndoStep(SaveFlightProgram(), null, DateTime.Now);
			undoStep.IsHead = head;
			UndoHistory.PushUndo(undoStep, ignoreKey);
		}

		private List<VariableElementScript> GetVariableElements(string variableName)
		{
			List<VariableElementScript> list = new List<VariableElementScript>();
			VariableElementScript[] componentsInChildren = ProgramTransform.GetComponentsInChildren<VariableElementScript>();
			foreach (VariableElementScript variableElementScript in componentsInChildren)
			{
				VariableExpression variableExpression = variableElementScript.Node as VariableExpression;
				if (variableExpression.VariableName == variableName && !variableExpression.IsLocal)
				{
					list.Add(variableElementScript);
				}
			}
			return list;
		}

		private void LoadFlightProgram(XElement programXml, bool loadNewOnFailure, bool import, Vector2 positionOffset)
		{
			try
			{
				SelectedElement = null;
				FlightProgram flightProgram = new ProgramSerializer().DeserializeFlightProgram(programXml);
				if (import)
				{
					List<string> list = new List<string>();
					foreach (CustomExpression customExpression in flightProgram.CustomExpressions)
					{
						if (FlightProgram.CustomExpressions.Any((CustomExpression x) => string.Compare(x.Name, customExpression.Name) == 0))
						{
							list.Add($"Cannot import custom expression with name '{customExpression.Name}' because that name is already being used in the program.");
						}
					}
					foreach (CustomInstruction customInstruction in flightProgram.CustomInstructions)
					{
						if (FlightProgram.CustomInstructions.Any((CustomInstruction x) => string.Compare(x.Name, customInstruction.Name) == 0))
						{
							list.Add($"Cannot import custom instruction with name '{customInstruction.Name}' because that name is already being used in the program.");
						}
					}
					if (list.Count > 0)
					{
						int num = 5;
						string text = string.Join("\n", list.Take(num));
						if (list.Count > num)
						{
							text += $"\nThere are {list.Count - num} more error(s) that have been truncated.";
						}
						ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
						messageDialogScript.MessageText = "Unable to import program because of the following errors:\n\n" + text;
						messageDialogScript.ExtraWide = true;
						return;
					}
					foreach (CustomExpression customExpression2 in flightProgram.CustomExpressions)
					{
						FlightProgram.AddCustomExpression(customExpression2);
					}
					foreach (CustomInstruction customInstruction2 in flightProgram.CustomInstructions)
					{
						FlightProgram.AddCustomInstruction(customInstruction2);
					}
					foreach (Variable variable in flightProgram.GlobalVariables.Variables)
					{
						if (FlightProgram.GlobalVariables.GetVariable(variable.Name) == null)
						{
							Debug.LogFormat("Importing Global Variable: {0}", variable.Name);
							FlightProgram.GlobalVariables.AddVariable(variable);
						}
						else
						{
							Debug.LogFormat("Skipping Global Variable because it already exists in the program: {0}", variable.Name);
						}
					}
				}
				else
				{
					BlockElementScript[] componentsInChildren = ProgramTransform.GetComponentsInChildren<BlockElementScript>();
					for (int num2 = 0; num2 < componentsInChildren.Length; num2++)
					{
						componentsInChildren[num2].Destroy();
					}
					FlightProgram = flightProgram;
				}
				foreach (ProgramInstruction rootInstruction in flightProgram.RootInstructions)
				{
					rootInstruction.EditorPosition = (rootInstruction.EditorPosition.HasValue ? (rootInstruction.EditorPosition.Value + positionOffset) : positionOffset);
					CreateElementForNode(rootInstruction);
				}
				foreach (ProgramExpression rootExpression in flightProgram.RootExpressions)
				{
					rootExpression.EditorPosition = (rootExpression.EditorPosition.HasValue ? (rootExpression.EditorPosition.Value + positionOffset) : positionOffset);
					CreateElementForNode(rootExpression);
				}
				_controller.RefreshUI();
				if (flightProgram.RequiresMfd && !IsMfdPart)
				{
					ModApi.Ui.MessageDialogScript messageDialogScript2 = Game.Instance.UserInterface.CreateMessageDialog();
					messageDialogScript2.UseDangerButtonStyle = true;
					messageDialogScript2.MessageText = "This program might require an MFD and therefore might not work correctly on this part.";
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				if (loadNewOnFailure)
				{
					LoadNewFlightProgram();
					return;
				}
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Unable to load flight program.";
				throw new Exception("Unable to load flight program.", ex);
			}
		}
	}
}
