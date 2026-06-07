using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Input;
using ModApi;
using ModApi.Input;
using ModApi.Ui;
using Rewired;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Settings
{
	public class ControlSettingsDialogScript : DialogScript
	{
		public enum RowButtonType
		{
			Keyboard = 0,
			KeyboardAlternate = 1,
			Controller = 2,
			None = 3
		}

		private const string PrimaryButtonClass = "btn-primary";

		private XmlElement _calibrateButton;

		private XmlElement _categorySeparatorTemplate;

		private List<XmlElement> _controlCategories;

		private XmlElement _controlCategoriesPanel;

		private SpinnerScript _controllerSpinner;

		private BindInputDialogScript _currentBindInputDialogForListening;

		private CalibrateControllerDialogScript _currentCalibrator;

		private XmlElement _itemContextMenu;

		private XmlElement _itemsParent;

		private XmlElement _panel;

		private List<ControlSettingsRowScript> _rows = new List<ControlSettingsRowScript>();

		private XmlElement _rowTemplate;

		private Controller _selectedController;

		private SliderControl _sensitivitySlider;

		private List<XmlElement> _separators = new List<XmlElement>();

		public static bool CurrentlyBindingInput { get; private set; }

		public XmlElement SelectedCategory
		{
			get
			{
				return _controlCategories.FirstOrDefault((XmlElement x) => x.HasClass("btn-primary"));
			}
			set
			{
				XmlElement selectedCategory = SelectedCategory;
				if (selectedCategory != value)
				{
					selectedCategory.RemoveClass("btn-primary");
					selectedCategory.ApplyAttributes();
					value.AddClass("btn-primary");
					value.ApplyAttributes();
				}
			}
		}

		public static ControlSettingsDialogScript Create(Transform parent)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/Settings/ControlSettingsDialog", parent, delegate(ControlSettingsDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
		}

		public static ActionElementMap GetActionElementMapForRow(ControllerMap controllerMap, ControlSettingsRowScript row, Controller controller, int ignoreNumber = 0)
		{
			if (controller == null)
			{
				return null;
			}
			if (controllerMap != null && controllerMap.ContainsAction(row.Action.id))
			{
				int num = 0;
				ActionElementMap[] elementMapsWithAction = controllerMap.GetElementMapsWithAction(row.Action.id);
				foreach (ActionElementMap actionElementMap in elementMapsWithAction)
				{
					if (actionElementMap.ShowInField(row.AxisDirection))
					{
						num++;
						if (num > ignoreNumber)
						{
							return actionElementMap;
						}
					}
				}
			}
			return null;
		}

		public override void Close()
		{
			base.Close();
			ReInput.ControllerConnectedEvent -= OnControllerConnected;
			ReInput.ControllerPreDisconnectEvent -= OnControllerPreDisconnectEvent;
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show();
			if (_controllerSpinner.Values.Count > 0)
			{
				_selectedController = ReInput.players.GetPlayer(0).controllers.Controllers.FirstOrDefault((Controller x) => x.name == _controllerSpinner.Values[0]);
				_controllerSpinner.Value = _selectedController.name;
			}
			else
			{
				_selectedController = null;
			}
			BuildRows(SelectedCategory);
			ReInput.ControllerConnectedEvent += OnControllerConnected;
			ReInput.ControllerPreDisconnectEvent += OnControllerPreDisconnectEvent;
			InputWrapper.SetControllerUINavigationEnabled(enabled: true);
			Controller selectedController = _selectedController;
			SetSelectedSensitivityType(selectedController != null && selectedController.type == ControllerType.Mouse);
			if (Game.Instance.Settings.HasOpenedControlSettings)
			{
				return;
			}
			if (Game.Instance.Device.IsMobileBuild)
			{
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
				messageDialogScript.MessageText = "The mobile version of Juno: New Origins does not require any additional keyboards or controllers to be fully enjoyed. \n\n For players who do wish to use these devices however, this dialog can be used to configure those controls.";
				messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript msg)
				{
					Game.Instance.Settings.HasOpenedControlSettings = true;
					Game.Instance.Settings.Save();
					msg.Close();
				};
			}
			else
			{
				Game.Instance.Settings.HasOpenedControlSettings = true;
				Game.Instance.Settings.Save();
			}
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					Close();
				}
				if (CurrentlyBindingInput && _currentBindInputDialogForListening == null)
				{
					CurrentlyBindingInput = false;
				}
			}
		}

		private void BuildRows(XmlElement category)
		{
			foreach (ControlSettingsRowScript row in _rows)
			{
				UnityEngine.Object.Destroy(row.gameObject);
			}
			foreach (XmlElement separator in _separators)
			{
				UnityEngine.Object.Destroy(separator.gameObject);
			}
			_rows.Clear();
			_separators.Clear();
			string internalId = category.internalId;
			List<InputCategory> actionCategories = ReInput.mapping.ActionCategories.ToList();
			if (internalId == "FlightCommon")
			{
				List<InputCategory> source = actionCategories.ToList();
				actionCategories.Clear();
				actionCategories.Add(source.First((InputCategory x) => x.name == "Navigation"));
				actionCategories.Add(source.First((InputCategory x) => x.name == "TimeControl"));
				actionCategories.Add(source.First((InputCategory x) => x.name == "MapView"));
				actionCategories.Add(source.First((InputCategory x) => x.name == "ActivationGroups"));
				actionCategories.Add(source.First((InputCategory x) => x.name == "FlightOther"));
				actionCategories.Add(source.First((InputCategory x) => x.name == "CameraLook"));
				actionCategories.AddRange(source.Where((InputCategory x) => !actionCategories.Contains(x)));
			}
			else if (internalId == "PlanetStudio")
			{
				List<InputCategory> source2 = actionCategories.ToList();
				actionCategories.Clear();
				actionCategories.Add(source2.First((InputCategory x) => x.name == "PlanetStudio"));
				actionCategories.Add(source2.First((InputCategory x) => x.name == "Designer"));
				actionCategories.AddRange(source2.Where((InputCategory x) => !actionCategories.Contains(x)));
			}
			_ = string.Empty;
			foreach (InputCategory item in actionCategories)
			{
				if (!item.userAssignable)
				{
					continue;
				}
				bool flag = false;
				IGameInputs inputs = Game.Instance.Inputs;
				foreach (InputAction item2 in ReInput.mapping.ActionsInCategory(item.id, sort: true))
				{
					if (item2.userAssignable && inputs.IsActionInMapCategory(internalId, item2.name))
					{
						if (!flag && (!(internalId == "PlanetStudio") || !(item.name == "Designer")))
						{
							CreateSeparator(item.descriptiveName);
							_ = item.descriptiveName;
							flag = true;
						}
						string text = item2.descriptiveName;
						if (text.EndsWith("(with modifier)"))
						{
							text = text.Insert(text.Length - 15, "<size=80%>");
						}
						ControlSettingsRowScript controlSettingsRowScript = CreateRow(text, internalId);
						controlSettingsRowScript.Action = item2;
						controlSettingsRowScript.IsAxis = item2.type == InputActionType.Axis;
						controlSettingsRowScript.AxisDirection = ((item2.type != InputActionType.Axis) ? AxisRange.Positive : AxisRange.Full);
						if (item2.type == InputActionType.Axis)
						{
							controlSettingsRowScript.InvertChangedEvent = (Action<ControlSettingsRowScript, bool>)Delegate.Combine(controlSettingsRowScript.InvertChangedEvent, new Action<ControlSettingsRowScript, bool>(OnRowInvertChanged));
							ControlSettingsRowScript controlSettingsRowScript2 = CreateRow(item2.positiveDescriptiveName, internalId);
							controlSettingsRowScript2.Action = item2;
							controlSettingsRowScript2.AxisDirection = AxisRange.Positive;
							ControlSettingsRowScript controlSettingsRowScript3 = CreateRow(item2.negativeDescriptiveName, internalId);
							controlSettingsRowScript3.Action = item2;
							controlSettingsRowScript3.AxisDirection = AxisRange.Negative;
						}
					}
				}
			}
			LoadRowInputsForController(_selectedController);
			LoadRowInputsForKeyboard();
		}

		private ControlSettingsRowScript CreateRow(string actionName, string mapCategory)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_rowTemplate, _itemsParent);
			ControlSettingsRowScript rowScript = xmlElement.gameObject.AddComponent<ControlSettingsRowScript>();
			rowScript.Initialize(xmlElement, mapCategory);
			rowScript.ActionNameText.SetText(actionName);
			rowScript.ControllerButton.AddOnClickEvent(delegate
			{
				OnBindingClicked(rowScript, RowButtonType.Controller);
			});
			rowScript.KeyboardButton.AddOnClickEvent(delegate
			{
				OnBindingClicked(rowScript, RowButtonType.Keyboard);
			});
			rowScript.KeyboardAlternateButton.AddOnClickEvent(delegate
			{
				OnBindingClicked(rowScript, RowButtonType.KeyboardAlternate);
			});
			ControlSettingsRowScript controlSettingsRowScript = rowScript;
			controlSettingsRowScript.InputMappedEvent = (Action<InputMapper.InputMappedEventData, ControlSettingsRowScript, RowButtonType>)Delegate.Combine(controlSettingsRowScript.InputMappedEvent, new Action<InputMapper.InputMappedEventData, ControlSettingsRowScript, RowButtonType>(InputMapped));
			_rows.Add(rowScript);
			return rowScript;
		}

		private XmlElement CreateSeparator(string subCategoryName)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_categorySeparatorTemplate, _itemsParent);
			xmlElement.SetAndApplyAttribute("text", subCategoryName);
			_separators.Add(xmlElement);
			return xmlElement;
		}

		private void InputMapped(InputMapper.InputMappedEventData obj, ControlSettingsRowScript mappedRow, RowButtonType buttonType)
		{
			switch (buttonType)
			{
			case RowButtonType.Controller:
				LoadRowInputsForController(_selectedController);
				break;
			case RowButtonType.Keyboard:
				LoadRowInputsForKeyboard();
				break;
			case RowButtonType.KeyboardAlternate:
				LoadRowInputsForKeyboard();
				break;
			}
			_currentBindInputDialogForListening?.Close();
		}

		private IEnumerator ListenForAddControllerInput()
		{
			float timeLeft = 5f;
			ModApi.Ui.MessageDialogScript messageBox = Game.Instance.UserInterface.CreateMessageDialog();
			messageBox.OkayButtonText = "Cancel";
			messageBox.OkayClicked += delegate
			{
				timeLeft = 0f;
			};
			messageBox.MessageText = "Press any button or move an axis on the controller you would like to use. \n \n" + timeLeft.ToString("0.00");
			Controller addedController = null;
			while (timeLeft > 0f)
			{
				yield return new WaitForEndOfFrame();
				timeLeft -= Time.unscaledDeltaTime;
				timeLeft = Mathf.Clamp(timeLeft, 0f, float.PositiveInfinity);
				messageBox.MessageText = "Press any button or move an axis on the controller you would like to use. \n \n" + timeLeft.ToString("0.0");
				ControllerPollingInfo controllerPollingInfo = ReInput.controllers.polling.PollAllControllersOfTypeForFirstElementDown(ControllerType.Joystick);
				if (controllerPollingInfo.success)
				{
					if (!ReInput.players.GetPlayer(0).controllers.ContainsController(controllerPollingInfo.controllerType, controllerPollingInfo.controllerId))
					{
						ReInput.players.GetPlayer(0).controllers.AddController(controllerPollingInfo.controllerType, controllerPollingInfo.controllerId, removeFromOtherPlayers: false);
						timeLeft = 0f;
						addedController = controllerPollingInfo.controller;
					}
					continue;
				}
				controllerPollingInfo = ReInput.controllers.polling.PollAllControllersOfTypeForFirstAxis(ControllerType.Mouse);
				if (controllerPollingInfo.success && !ReInput.players.GetPlayer(0).controllers.ContainsController(controllerPollingInfo.controllerType, controllerPollingInfo.controllerId))
				{
					ReInput.players.GetPlayer(0).controllers.AddController(controllerPollingInfo.controllerType, controllerPollingInfo.controllerId, removeFromOtherPlayers: false);
					timeLeft = 0f;
					addedController = controllerPollingInfo.controller;
				}
			}
			if (addedController != null)
			{
				OnControllerConnected(new ControllerStatusChangedEventArgs(addedController.name, addedController.id, addedController.type));
			}
			messageBox.Close();
		}

		private void LoadRowInputsForController(Controller controller)
		{
			foreach (ControlSettingsRowScript row in _rows)
			{
				ControllerMap controllerMap = InputUtilities.GetControllerMap(controller, row.MapCategory, "Default");
				if (controllerMap != null)
				{
					ActionElementMap actionElementMapForRow = GetActionElementMapForRow(controllerMap, row, controller);
					string text = ((actionElementMapForRow == null) ? string.Empty : actionElementMapForRow.elementIdentifierName);
					row.ControllerText.SetText(text);
					row.Inverted = actionElementMapForRow?.invert ?? false;
				}
				else
				{
					row.ControllerText.SetText(string.Empty);
					row.Inverted = false;
				}
			}
		}

		private void LoadRowInputsForKeyboard()
		{
			Controller keyboard = ReInput.players.GetPlayer(0).controllers.Keyboard;
			foreach (ControlSettingsRowScript row in _rows)
			{
				ControllerMap controllerMap = InputUtilities.GetControllerMap(keyboard, row.MapCategory, "Default");
				if (controllerMap != null)
				{
					ActionElementMap actionElementMapForRow = GetActionElementMapForRow(controllerMap, row, keyboard);
					string defaultDisplayName = ((actionElementMapForRow == null) ? string.Empty : actionElementMapForRow.elementIdentifierName);
					row.KeyboardText.SetText(InputUtilities.GetKeyCodeDisplayName(actionElementMapForRow?.keyCode, defaultDisplayName));
					ActionElementMap actionElementMapForRow2 = GetActionElementMapForRow(controllerMap, row, keyboard, 1);
					defaultDisplayName = ((actionElementMapForRow2 == null) ? string.Empty : actionElementMapForRow2.elementIdentifierName);
					row.KeyboardAlternateText.SetText(InputUtilities.GetKeyCodeDisplayName(actionElementMapForRow2?.keyCode, defaultDisplayName));
				}
			}
		}

		private void OnAddControllerClicked()
		{
			StartCoroutine(ListenForAddControllerInput());
			_itemContextMenu.ToggleVisibility();
		}

		private void OnBindingClicked(ControlSettingsRowScript row, RowButtonType buttonType)
		{
			if (_selectedController == null && buttonType == RowButtonType.Controller)
			{
				Debug.Log("No controller selected");
				return;
			}
			Controller controllerToListenFor = _selectedController;
			if (buttonType != RowButtonType.Controller)
			{
				controllerToListenFor = ReInput.players.GetPlayer(0).controllers.Keyboard;
			}
			_currentBindInputDialogForListening = BindInputDialogScript.Create(base.transform.parent, row, buttonType, controllerToListenFor);
			CurrentlyBindingInput = true;
		}

		private void OnCalibrateButtonClicked()
		{
			_currentCalibrator = CalibrateControllerDialogScript.Create(base.transform.parent, _selectedController);
		}

		private void OnCategoryClicked(XmlElement category)
		{
			if (!category.HasClass("btn-primary"))
			{
				SelectedCategory = category;
				BuildRows(category);
			}
		}

		private void OnContextMenuButtonClicked()
		{
			_itemContextMenu.ToggleVisibility();
		}

		private void OnControllerChanged(string obj)
		{
			_selectedController = ReInput.players.GetPlayer(0).controllers.Controllers.FirstOrDefault((Controller x) => x.name == obj);
			LoadRowInputsForController(_selectedController);
			SetSelectedSensitivityType(_selectedController.type == ControllerType.Mouse);
		}

		private void OnControllerConnected(ControllerStatusChangedEventArgs obj)
		{
			if (!_controllerSpinner.Values.Contains(obj.name))
			{
				_controllerSpinner.Values.Add(obj.name);
			}
		}

		private void OnControllerPreDisconnectEvent(ControllerStatusChangedEventArgs obj)
		{
			if (_selectedController.name == obj.name)
			{
				if (_currentBindInputDialogForListening != null)
				{
					_currentBindInputDialogForListening.Close();
				}
				if (_currentCalibrator != null)
				{
					_currentCalibrator.Close();
				}
			}
			if (_controllerSpinner.Values.Contains(obj.name))
			{
				if (_selectedController.name == obj.name)
				{
					_controllerSpinner.Value = _controllerSpinner.Values.NextValue(obj.name);
				}
				_controllerSpinner.Values.Remove(obj.name);
				_selectedController = ReInput.players.GetPlayer(0).controllers.Controllers.FirstOrDefault((Controller x) => x.name == _controllerSpinner.Value);
				LoadRowInputsForController(_selectedController);
			}
		}

		private void OnDoneButtonClicked()
		{
			ReInput.userDataStore.Save();
			InputWrapper.SetControllerUINavigationEnabled(enabled: false);
			InputWrapper.OnControlsChanged();
			Close();
		}

		private void OnInputSensitivityChanged(float sensitivity)
		{
			sensitivity = (float)Math.Round(sensitivity, 2);
			Controller selectedController = _selectedController;
			if (selectedController != null && selectedController.type == ControllerType.Mouse)
			{
				ReInput.mapping.GetInputBehavior(0, 0).mouseXYAxisSensitivity = sensitivity;
				ReInput.mapping.GetInputBehavior(0, 2).mouseXYAxisSensitivity = sensitivity;
			}
			else
			{
				ReInput.mapping.GetInputBehavior(0, 0).joystickAxisSensitivity = sensitivity;
				ReInput.mapping.GetInputBehavior(0, 2).joystickAxisSensitivity = sensitivity;
			}
			_sensitivitySlider.Slider.value = sensitivity;
			_sensitivitySlider.ValueText.SetText(Utilities.FormatPercentage(sensitivity));
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_controlCategoriesPanel = xmlLayout.GetElementById("control-categories");
			_panel = xmlLayout.GetElementById("panel");
			_itemContextMenu = xmlLayout.GetElementById("item-context-menu");
			_rowTemplate = xmlLayout.GetElementById("row-template");
			_categorySeparatorTemplate = xmlLayout.GetElementById("category-separator-template");
			_itemsParent = xmlLayout.GetElementById("items-parent");
			_controllerSpinner = xmlLayout.GetElementById<SpinnerScript>("controller-spinner");
			_sensitivitySlider = new SliderControl(xmlLayout.GetElementById("sensitivity-slider"));
			_calibrateButton = xmlLayout.GetElementById("calibrate-button");
			_sensitivitySlider.Slider.onValueChanged.AddListener(OnInputSensitivityChanged);
			SpinnerScript controllerSpinner = _controllerSpinner;
			controllerSpinner.OnValueChanged = (Action<string>)Delegate.Combine(controllerSpinner.OnValueChanged, new Action<string>(OnControllerChanged));
			_categorySeparatorTemplate.SetActive(active: false);
			_rowTemplate.SetActive(active: false);
			_panel.SetAttribute("active", "false");
			_controlCategories = new List<XmlElement>();
			foreach (XmlElement category in _controlCategoriesPanel.childElements)
			{
				if (!string.IsNullOrWhiteSpace(category.internalId))
				{
					category.AddOnClickEvent(delegate
					{
						OnCategoryClicked(category);
					});
					_controlCategories.Add(category);
				}
			}
			IEnumerable<Controller> enumerable = ReInput.players.GetPlayer(0).controllers.Controllers.Where((Controller x) => x.type != ControllerType.Keyboard && x.type != ControllerType.Custom);
			foreach (Controller item in enumerable)
			{
				if (item.type != ControllerType.Mouse)
				{
					_controllerSpinner.Values.Add(item.name);
				}
			}
			Controller controller = enumerable.FirstOrDefault((Controller x) => x.type == ControllerType.Mouse);
			if (controller != null)
			{
				_controllerSpinner.Values.Add(controller.name);
			}
		}

		private void OnOpenDevConsoleClicked()
		{
			Game.Instance.DevConsole.OpenConsole();
		}

		private void OnRemoveControllerClicked()
		{
			if (_selectedController != null)
			{
				ReInput.players.GetPlayer(0).controllers.RemoveController(_selectedController);
				if (_controllerSpinner.Values.Contains(_selectedController.name))
				{
					OnControllerPreDisconnectEvent(new ControllerStatusChangedEventArgs(_selectedController.name, _selectedController.id, _selectedController.type));
					_selectedController = ReInput.players.GetPlayer(0).controllers.Controllers.FirstOrDefault((Controller x) => x.name == _controllerSpinner.Value);
				}
			}
			_itemContextMenu.ToggleVisibility();
		}

		private void OnRestoreDefaultsButtonClicked()
		{
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = "This will reset all inputs to the default input configuration, removing any custom input mappings. \n\n Are you certain you want to do this?";
			messageDialogScript.OkayButtonText = "Yes";
			messageDialogScript.CancelButtonText = "No";
			messageDialogScript.UseDangerButtonStyle = true;
			messageDialogScript.OkayClicked += RestoreDefaults;
		}

		private void OnRowInvertChanged(ControlSettingsRowScript row, bool inverted)
		{
			if (_selectedController != null)
			{
				ActionElementMap actionElementMapForRow = GetActionElementMapForRow(InputUtilities.GetControllerMap(_selectedController, row.MapCategory, "Default"), row, _selectedController);
				if (actionElementMapForRow != null)
				{
					actionElementMapForRow.invert = inverted;
				}
				else
				{
					row.Inverted = false;
				}
			}
		}

		private void RestoreDefaults(ModApi.Ui.MessageDialogScript dialog)
		{
			IList<Player> players = ReInput.players.Players;
			for (int i = 0; i < players.Count; i++)
			{
				Player player = players[i];
				player.controllers.maps.LoadDefaultMaps(ControllerType.Joystick);
				player.controllers.maps.LoadDefaultMaps(ControllerType.Keyboard);
				player.controllers.maps.LoadDefaultMaps(ControllerType.Mouse);
				player.controllers.maps.LoadDefaultMaps(ControllerType.Custom);
			}
			ReInput.mapping.GetInputBehavior(0, 0).Reset();
			ReInput.mapping.GetInputBehavior(0, 2).Reset();
			float num = 1f;
			Controller selectedController = _selectedController;
			num = ((selectedController == null || selectedController.type != ControllerType.Mouse) ? ReInput.mapping.GetInputBehavior(0, 0).joystickAxisSensitivity : ReInput.mapping.GetInputBehavior(0, 0).mouseXYAxisSensitivity);
			_sensitivitySlider.Slider.value = num;
			_sensitivitySlider.ValueText.SetText(Utilities.FormatPercentage(num));
			LoadRowInputsForController(_selectedController);
			LoadRowInputsForKeyboard();
			dialog.Close();
		}

		private void SetSelectedSensitivityType(bool mouse = false)
		{
			if (mouse)
			{
				_sensitivitySlider.LabelText.SetText("Mouse XY Sensitivity");
				_sensitivitySlider.Slider.value = ReInput.mapping.GetInputBehavior(0, 0).mouseXYAxisSensitivity;
				_sensitivitySlider.ValueText.SetText(Utilities.FormatPercentage(_sensitivitySlider.Slider.value));
				_calibrateButton.SetActive(active: false);
			}
			else
			{
				_sensitivitySlider.LabelText.SetText("Controller Sensitivity");
				_sensitivitySlider.Slider.value = ReInput.mapping.GetInputBehavior(0, 0).joystickAxisSensitivity;
				_sensitivitySlider.ValueText.SetText(Utilities.FormatPercentage(_sensitivitySlider.Slider.value));
				_calibrateButton.SetActive(active: true);
			}
		}
	}
}
