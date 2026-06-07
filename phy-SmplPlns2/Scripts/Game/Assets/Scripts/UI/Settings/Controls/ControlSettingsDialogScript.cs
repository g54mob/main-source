using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Input;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.UI.Settings.Controls
{
	public class ControlSettingsDialogScript : PanelDialogScript
	{
		public enum RowButtonType
		{
			Keyboard = 0,
			KeyboardAlternate = 1,
			Controller = 2,
			None = 3
		}

		private class ActionRowGroup
		{
			public Widget Header { get; set; }

			public List<ControlSettingsRowScript> Rows { get; private set; } = new List<ControlSettingsRowScript>();
		}

		private const string SelectedCategoryClass = "btn-primary";

		private SpinnerControl _controllerSpinner;

		private SpinnerControl _controllerSpinner2;

		private BindInputDialogScript _currentBindInputDialogForListening;

		private CalibrateControllerDialogScript _currentCalibrator;

		private ActionRowGroup _currentGroup;

		private bool _dropdownnMenuVisible;

		private List<ActionRowGroup> _groups = new List<ActionRowGroup>();

		private Widget _itemsParent;

		private Widget _itemsPool;

		private Queue<ControlSettingsRowScript> _pool = new Queue<ControlSettingsRowScript>();

		private List<ControlSettingsRowScript> _rows = new List<ControlSettingsRowScript>();

		private string _searchFilter;

		private Widget _selectedCategory;

		private Controller _selectedController;

		private SliderControl _sensitivitySlider;

		public static bool CurrentlyBindingInput { get; private set; }

		public Widget SelectedCategory
		{
			get
			{
				return _selectedCategory;
			}
			set
			{
				if (_selectedCategory != value)
				{
					if (_selectedCategory != null)
					{
						_selectedCategory.RemoveClass("btn-primary");
					}
					_selectedCategory = value;
					if (_selectedCategory != null)
					{
						_selectedCategory.AddClass("btn-primary");
						BuildRows(_selectedCategory);
						FilterRows();
					}
				}
			}
		}

		public Controller SelectedController
		{
			get
			{
				return _selectedController;
			}
			private set
			{
				if (_selectedController != value)
				{
					_selectedController = value;
					SetControllerSpinnerValue(_selectedController?.name);
					LoadRowInputsForController(_selectedController);
				}
			}
		}

		private bool DropdownMenuVisible
		{
			get
			{
				return _dropdownnMenuVisible;
			}
			set
			{
				if (_dropdownnMenuVisible != value)
				{
					_dropdownnMenuVisible = value;
					Widget widget = base.Widget.FindWidget("popup-menu");
					if (value)
					{
						widget.Show(force: true);
					}
					else
					{
						widget.Hide(null, force: true);
					}
				}
			}
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
			InputWrapper.Player.controllers.maps.SetAllMapsEnabled(state: false);
			ReInput.userDataStore.Save();
			InputWrapper.ApplySceneControls();
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			widget.FindWidget<InputWidget>("search-input").Input.onValueChanged.AddListener(delegate(string s)
			{
				OnSearchChanged(s);
			});
			_itemsParent = widget.FindWidget("items-parent");
			_itemsPool = widget.FindWidget("items-pool");
			_controllerSpinner = new SpinnerControl(widget.FindWidget("controller-spinner"));
			SpinnerControl controllerSpinner = _controllerSpinner;
			controllerSpinner.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(controllerSpinner.OnValueChanged, new OnValueChanged<string>(OnControllerChanged));
			_controllerSpinner2 = new SpinnerControl(widget.FindWidget("controller-spinner-2"));
			SpinnerControl controllerSpinner2 = _controllerSpinner2;
			controllerSpinner2.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(controllerSpinner2.OnValueChanged, new OnValueChanged<string>(OnControllerChanged));
			_sensitivitySlider = new SliderControl(widget.FindWidget("sensitivity-slider"));
			_sensitivitySlider.Slider.ValueChanged += delegate(float x)
			{
				OnInputSensitivityChanged(x);
			};
			_sensitivitySlider.ValueFormatter = (float x) => Utilities.FormatPercentage(x, 1);
			IEnumerable<Controller> enumerable = ReInput.players.GetPlayer(0).controllers.Controllers.Where((Controller x) => x.type != ControllerType.Keyboard && x.type != ControllerType.Custom);
			foreach (Controller item in enumerable)
			{
				if (item.type != ControllerType.Mouse)
				{
					AddControllerSpinnerValue(item.name);
				}
			}
			Controller controller = enumerable.FirstOrDefault((Controller x) => x.type == ControllerType.Mouse);
			if (controller != null)
			{
				AddControllerSpinnerValue(controller.name);
			}
		}

		protected override void Start()
		{
			base.Start();
			string id = (GameState.Instance.IsInDesigner ? "category-designer" : "category-craft");
			if (!GameState.Instance.IsInDesigner && FlightSceneScript.Instance?.LocalPlayer != null && FlightSceneScript.Instance.LocalPlayer.Aircraft == null)
			{
				id = "category-character";
			}
			SelectedCategory = base.Widget.FindWidget(id);
			if (_controllerSpinner.Values.Count > 0)
			{
				SelectedController = ReInput.players.GetPlayer(0).controllers.Controllers.FirstOrDefault((Controller x) => x.name == _controllerSpinner.Values[0]);
			}
			else
			{
				SelectedController = null;
			}
			ReInput.ControllerConnectedEvent += OnControllerConnected;
			ReInput.ControllerPreDisconnectEvent += OnControllerPreDisconnectEvent;
			InputWrapper.SetControllerUINavigationEnabled(enabled: true);
			if (Game.Instance.Settings.App.HasOpenedControlSettings)
			{
				return;
			}
			if (Game.Instance.Device.IsMobileBuild)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog();
				messageDialogScript.MessageText = "The mobile version of SimplePlanes 2 does not require any additional keyboards or controllers to be fully enjoyed. \n\n For players who do wish to use these devices however, this dialog can be used to configure those controls.";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript msg)
				{
					Game.Instance.Settings.App.HasOpenedControlSettings = true;
					Game.Instance.Settings.App.Save();
					msg.Close();
				};
			}
			else
			{
				Game.Instance.Settings.App.HasOpenedControlSettings = true;
				Game.Instance.Settings.App.Save();
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

		private void AddControllerSpinnerValue(string value)
		{
			_controllerSpinner.Values.Add(value);
			_controllerSpinner2.Values.Add(value);
		}

		private void BuildRows(Widget category)
		{
			Stopwatch.StartNew();
			foreach (ControlSettingsRowScript row in _rows)
			{
				_pool.Enqueue(row);
				row.Widget.Visible = false;
			}
			foreach (ActionRowGroup group in _groups)
			{
				group.Header.Destroy();
			}
			_rows.Clear();
			_groups.Clear();
			string data = category.Data;
			List<InputCategory> list = ReInput.mapping.ActionCategories.ToList();
			_ = string.Empty;
			foreach (InputCategory item in list)
			{
				if (!item.userAssignable)
				{
					continue;
				}
				bool flag = false;
				GameInputs inputs = Game.Inputs;
				foreach (InputAction item2 in ReInput.mapping.ActionsInCategory(item.id, sort: true))
				{
					if (item2.userAssignable && inputs.IsActionInMapCategory(data, item2.name))
					{
						if (!flag && 0 == 0)
						{
							_currentGroup = CreateActionRowGroup(item.descriptiveName);
							_ = item.descriptiveName;
							flag = true;
						}
						string text = item2.descriptiveName;
						if (text.EndsWith("(with modifier)"))
						{
							text = text.Insert(text.Length - 15, "<size=80%>");
						}
						ControlSettingsRowScript controlSettingsRowScript = CreateRow(text, data);
						controlSettingsRowScript.Action = item2;
						controlSettingsRowScript.IsAxis = item2.type == InputActionType.Axis;
						controlSettingsRowScript.AxisDirection = ((item2.type != InputActionType.Axis) ? AxisRange.Positive : AxisRange.Full);
						if (item2.type == InputActionType.Axis)
						{
							ControlSettingsRowScript controlSettingsRowScript2 = CreateRow(item2.positiveDescriptiveName, data);
							controlSettingsRowScript2.Action = item2;
							controlSettingsRowScript2.AxisDirection = AxisRange.Positive;
							controlSettingsRowScript2.IsAxis = false;
							ControlSettingsRowScript controlSettingsRowScript3 = CreateRow(item2.negativeDescriptiveName, data);
							controlSettingsRowScript3.Action = item2;
							controlSettingsRowScript3.AxisDirection = AxisRange.Negative;
							controlSettingsRowScript3.IsAxis = false;
						}
					}
				}
			}
			LoadRowInputsForKeyboard();
			LoadRowInputsForController(_selectedController);
		}

		private ActionRowGroup CreateActionRowGroup(string subCategoryName)
		{
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("sub-category", _itemsParent);
			widget.FindWidget<TextWidget>("label-text").Text = subCategoryName;
			ActionRowGroup actionRowGroup = new ActionRowGroup
			{
				Header = widget
			};
			_groups.Add(actionRowGroup);
			return actionRowGroup;
		}

		private ControlSettingsRowScript CreateRow(string actionName, string mapCategory)
		{
			ControlSettingsRowScript rowScript;
			if (_pool.Count > 0)
			{
				rowScript = _pool.Dequeue();
				rowScript.Widget.Visible = true;
				rowScript.Widget.SetIndex(-1);
			}
			else
			{
				Widget widget = base.Widget.Context.CreateWidgetFromTemplate("input-row", _itemsParent);
				rowScript = widget.gameObject.AddComponent<ControlSettingsRowScript>();
				rowScript.Initialize(widget);
				rowScript.ControllerButton.Clicked += delegate
				{
					OnBindingClicked(rowScript, RowButtonType.Controller);
				};
				rowScript.KeyboardButton.Clicked += delegate
				{
					OnBindingClicked(rowScript, RowButtonType.Keyboard);
				};
				rowScript.KeyboardAlternateButton.Clicked += delegate
				{
					OnBindingClicked(rowScript, RowButtonType.KeyboardAlternate);
				};
				ControlSettingsRowScript controlSettingsRowScript = rowScript;
				controlSettingsRowScript.InputMappedEvent = (Action<InputMapper.InputMappedEventData, ControlSettingsRowScript, RowButtonType>)Delegate.Combine(controlSettingsRowScript.InputMappedEvent, new Action<InputMapper.InputMappedEventData, ControlSettingsRowScript, RowButtonType>(InputMapped));
				ControlSettingsRowScript controlSettingsRowScript2 = rowScript;
				controlSettingsRowScript2.InvertChangedEvent = (Action<ControlSettingsRowScript, bool>)Delegate.Combine(controlSettingsRowScript2.InvertChangedEvent, new Action<ControlSettingsRowScript, bool>(OnRowInvertChanged));
			}
			rowScript.MapCategory = mapCategory;
			rowScript.ActionNameText.Text = actionName;
			_rows.Add(rowScript);
			_currentGroup?.Rows?.Add(rowScript);
			return rowScript;
		}

		private void FilterRows()
		{
			IEnumerable<string> enumerable = _searchFilter?.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			IEnumerable<string> enumerable2 = enumerable ?? Enumerable.Empty<string>();
			foreach (ControlSettingsRowScript row in _rows)
			{
				bool visible = true;
				foreach (string item in enumerable2)
				{
					if (!string.IsNullOrEmpty(item) && !row.Action.descriptiveName.Contains(item, StringComparison.OrdinalIgnoreCase))
					{
						visible = false;
						break;
					}
				}
				row.Widget.Visible = visible;
			}
			foreach (ActionRowGroup group in _groups)
			{
				if (group.Header != null)
				{
					group.Header.Visible = group.Rows.Any((ControlSettingsRowScript x) => x.Widget.Visible);
				}
			}
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
			MessageDialogScript messageBox = Game.Instance.UserInterface.CreateMessageDialog();
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
					row.ControllerText.Text = text;
					row.Inverted = actionElementMapForRow?.invert ?? false;
				}
				else
				{
					row.ControllerText.Text = string.Empty;
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
					row.KeyboardText.Text = InputUtilities.GetKeyCodeDisplayName(actionElementMapForRow?.keyCode, defaultDisplayName);
					ActionElementMap actionElementMapForRow2 = GetActionElementMapForRow(controllerMap, row, keyboard, 1);
					defaultDisplayName = ((actionElementMapForRow2 == null) ? string.Empty : actionElementMapForRow2.elementIdentifierName);
					row.KeyboardAlternateText.Text = InputUtilities.GetKeyCodeDisplayName(actionElementMapForRow2?.keyCode, defaultDisplayName);
				}
			}
		}

		private void OnAddControllerClicked(Widget widget)
		{
			StartCoroutine(ListenForAddControllerInput());
			DropdownMenuVisible = false;
		}

		private void OnBindingClicked(ControlSettingsRowScript row, RowButtonType buttonType)
		{
			if (_selectedController == null && buttonType == RowButtonType.Controller)
			{
				UnityEngine.Debug.Log("No controller selected");
				return;
			}
			Controller controllerToListenFor = _selectedController;
			if (buttonType != RowButtonType.Controller)
			{
				controllerToListenFor = ReInput.players.GetPlayer(0).controllers.Keyboard;
			}
			_currentBindInputDialogForListening = BindInputDialogScript.Create(row, buttonType, controllerToListenFor);
			CurrentlyBindingInput = true;
		}

		private void OnCalibrateClicked(Widget widget)
		{
			Controller selectedController = _selectedController;
			if (selectedController != null && selectedController.type == ControllerType.Mouse)
			{
				CalibrateMouseDialogScript.Create();
			}
			else
			{
				_currentCalibrator = CalibrateControllerDialogScript.Create(_selectedController);
			}
		}

		private void OnCategoryClicked(Widget widget)
		{
			SelectedCategory = widget;
		}

		private void OnCloseClicked(Widget widget)
		{
			InputWrapper.SetControllerUINavigationEnabled(enabled: false);
			InputWrapper.ApplySceneControls();
			Close();
		}

		private void OnControllerChanged(string oldValue, string newValue)
		{
			SelectedController = ReInput.players.GetPlayer(0).controllers.Controllers.FirstOrDefault((Controller x) => x.name == newValue);
		}

		private void OnControllerConnected(ControllerStatusChangedEventArgs obj)
		{
			if (!_controllerSpinner.Values.Contains(obj.name))
			{
				AddControllerSpinnerValue(obj.name);
			}
		}

		private void OnControllerPreDisconnectEvent(ControllerStatusChangedEventArgs obj)
		{
			if (_selectedController.name == obj.name)
			{
				if (_currentBindInputDialogForListening != null)
				{
					_currentBindInputDialogForListening.Close();
					_currentBindInputDialogForListening = null;
				}
				if (_currentCalibrator != null)
				{
					_currentCalibrator.Close();
				}
			}
			if (_controllerSpinner.Values.Contains(obj.name))
			{
				string nextController = string.Empty;
				if (_selectedController.name == obj.name)
				{
					nextController = _controllerSpinner.Values.NextValue(obj.name);
				}
				RemoveControllerSpinnerValue(obj.name);
				SelectedController = ReInput.players.GetPlayer(0).controllers.Controllers.FirstOrDefault((Controller x) => x.name == nextController);
			}
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
		}

		private void OnOpenDevConsoleClicked(Widget widget)
		{
			Game.Instance.DevConsole.ToggleConsole();
		}

		private void OnPopupMenuClicked(Widget widget)
		{
			DropdownMenuVisible = !DropdownMenuVisible;
		}

		private void OnRemoveControllerClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Confirm that you wish to remove the controller '" + _controllerSpinner.Value + "'").OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				if (_selectedController != null)
				{
					ReInput.players.GetPlayer(0).controllers.RemoveController(_selectedController);
					if (_controllerSpinner.Values.Contains(_selectedController.name))
					{
						OnControllerPreDisconnectEvent(new ControllerStatusChangedEventArgs(_selectedController.name, _selectedController.id, _selectedController.type));
						SelectedController = ReInput.players.GetPlayer(0).controllers.Controllers.FirstOrDefault((Controller x) => x.name == _controllerSpinner.Value);
					}
				}
				DropdownMenuVisible = false;
			};
		}

		private void OnRestoreDefaultsButtonClicked(Widget widget)
		{
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
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

		private void OnSearchChanged(string searchFilter)
		{
			_searchFilter = searchFilter ?? string.Empty;
			FilterRows();
		}

		private void RemoveControllerSpinnerValue(string value)
		{
			_controllerSpinner.Values.Remove(value);
			_controllerSpinner2.Values.Remove(value);
		}

		private void RestoreDefaults(IDialog dialog)
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
			_sensitivitySlider.SetValue(num, events: true);
			LoadRowInputsForController(_selectedController);
			LoadRowInputsForKeyboard();
			dialog.Close();
		}

		private void SetControllerSpinnerValue(string value)
		{
			_controllerSpinner.Value = value;
			_controllerSpinner2.Value = value;
			Controller selectedController = _selectedController;
			bool flag = selectedController != null && selectedController.type == ControllerType.Mouse;
			foreach (Widget item in base.Widget.FindWidgetsByClass("no-mouse"))
			{
				item.Visible = !flag;
			}
			if (flag)
			{
				_sensitivitySlider.LabelText = "Mouse Sensitivity";
				_sensitivitySlider.SetValue(ReInput.mapping.GetInputBehavior(0, 0).mouseXYAxisSensitivity);
			}
			else
			{
				_sensitivitySlider.LabelText = "Controller Sensitivity";
				_sensitivitySlider.SetValue(ReInput.mapping.GetInputBehavior(0, 0).joystickAxisSensitivity);
			}
		}
	}
}
