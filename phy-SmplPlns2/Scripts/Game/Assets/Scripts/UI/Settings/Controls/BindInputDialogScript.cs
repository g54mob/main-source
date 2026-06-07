using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Input;
using Jundroo.Juicy.Widgets;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.UI.Settings.Controls
{
	public class BindInputDialogScript : PanelDialogScript
	{
		private ActionElementMap _actionMap;

		private Widget _buttonPanel;

		private ControlSettingsDialogScript.RowButtonType _buttonType;

		private Widget _centerStickPanel;

		private ControllerMap _controllerMap;

		private Controller _controllerToListenFor;

		private InputMapper.ConflictFoundEventData _currentConflict;

		private Coroutine _currentCoroutine;

		private InputMapper _inputMapper = new InputMapper();

		private TextWidget _label;

		private ControlSettingsRowScript _row;

		private TextWidget _timerText;

		public TextWidget CenterButtonText { get; private set; }

		public string MapCategory { get; set; }

		public string MessageText
		{
			get
			{
				return _label.Text;
			}
			set
			{
				_label.Text = value;
			}
		}

		public TextWidget RightButtonText { get; private set; }

		public float WaitTime { get; set; }

		public static BindInputDialogScript Create(ControlSettingsRowScript row, ControlSettingsDialogScript.RowButtonType buttonType, Controller controllerToListenFor)
		{
			BindInputDialogScript bindInputDialogScript = Game.Instance.UserInterface.CreateDialog<BindInputDialogScript>("Xml/Dialogs/Controls/BindInputDialog");
			bindInputDialogScript._row = row;
			bindInputDialogScript._buttonType = buttonType;
			bindInputDialogScript._controllerToListenFor = controllerToListenFor;
			bindInputDialogScript.MapCategory = row.MapCategory;
			return bindInputDialogScript;
		}

		public override void Close()
		{
			base.Close();
			if (_inputMapper.status != InputMapper.Status.Idle)
			{
				_inputMapper.Stop();
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_label = widget.FindWidget<TextWidget>("label-text");
			_timerText = widget.FindWidget<TextWidget>("timer-text");
			_centerStickPanel = widget.FindWidget("center-stick-panel");
			_buttonPanel = widget.FindWidget("button-row");
			CenterButtonText = widget.FindWidget<TextWidget>("center-button-text");
			RightButtonText = widget.FindWidget<TextWidget>("right-button-text");
			widget.FindWidget("content-bottom-spacer").Visible = false;
		}

		public void ShowCenterAxesImage(bool show = true)
		{
			if (show)
			{
				_centerStickPanel.Show();
			}
			else
			{
				_centerStickPanel.Hide();
			}
		}

		public void WaitFor(float time, Action onComplete, bool skipWaitOnButtonUp)
		{
			WaitTime = time;
			if (_currentCoroutine != null)
			{
				StopCoroutine(_currentCoroutine);
			}
			_currentCoroutine = StartCoroutine(Wait(onComplete, skipWaitOnButtonUp));
		}

		protected override void Start()
		{
			base.Start();
			base.Title = "Bind Input";
			string mapCategory = MapCategory;
			_controllerMap = InputUtilities.GetControllerMap(_controllerToListenFor, mapCategory, "Default");
			_actionMap = ControlSettingsDialogScript.GetActionElementMapForRow(_controllerMap, _row, _controllerToListenFor, (_buttonType == ControlSettingsDialogScript.RowButtonType.KeyboardAlternate) ? 1 : 0);
			if (_actionMap != null && (_actionMap.keyCode != KeyCode.None || _buttonType == ControlSettingsDialogScript.RowButtonType.Controller))
			{
				ReplaceOrRemoveMode();
			}
			else
			{
				BindMode();
			}
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
		}

		private static string GetHighlightedConflictName(ElementAssignmentConflictInfo conflictData)
		{
			return HighlightText((conflictData.elementMap.axisRange == AxisRange.Full) ? conflictData.action.descriptiveName : ((conflictData.elementMap.axisRange == AxisRange.Positive) ? conflictData.action.positiveDescriptiveName : conflictData.action.negativeDescriptiveName)) ?? "";
		}

		private static string HighlightText(string s)
		{
			return "<color=#ffff00>" + s + "</color>";
		}

		private void BindMode()
		{
			if (_controllerToListenFor.type == ControllerType.Keyboard)
			{
				_buttonPanel.Visible = false;
				StartListeningForInput(_row, _buttonType);
				return;
			}
			ShowCenterAxesImage();
			_buttonPanel.Visible = false;
			MessageText = "First center or zero all sticks and axes, then press any button or wait for the timer to finish.";
			WaitFor(5f, delegate
			{
				StartListeningForInput(_row, _buttonType);
			}, skipWaitOnButtonUp: true);
		}

		private void ConflictMode(InputMapper.ConflictFoundEventData conflictData)
		{
			_currentConflict = conflictData;
			ShowCenterAxesImage(show: false);
			_timerText.Text = string.Empty;
			_timerText.Visible = false;
			List<string> list = new List<string>();
			foreach (ElementAssignmentConflictInfo conflict in conflictData.conflicts)
			{
				list.Add(GetHighlightedConflictName(conflict));
			}
			list = list.Distinct().ToList();
			string text = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				text = ((i != list.Count - 1 || i <= 0) ? (text + ", ") : (text + ", and "));
				text += list[i];
			}
			string s = conflictData.assignment.elementDisplayName;
			if (_controllerToListenFor.type == ControllerType.Keyboard)
			{
				s = InputUtilities.GetKeyCodeDisplayName(conflictData.assignment.keyCode, conflictData.assignment.elementDisplayName);
			}
			MessageText = HighlightText(s) + " is already in use by:\n" + text + "\n\nDo you want to replace it? You may also choose to add the assignment to this action as well.";
			_timerText.Text = string.Empty;
			_timerText.Visible = false;
			RightButtonText.Text = "Replace";
			CenterButtonText.Text = "Add";
			_buttonPanel.Visible = true;
			if (_currentCoroutine != null)
			{
				StopCoroutine(_currentCoroutine);
			}
		}

		private void HandleConflict(InputMapper.ConflictFoundEventData conflictData)
		{
			ConflictMode(conflictData);
		}

		private bool IsElementAllowed(ControllerPollingInfo element)
		{
			if (element.keyboardKey == KeyCode.Escape)
			{
				return false;
			}
			if (Game.Instance.Device.IsMobileBuild && (element.elementIdentifierName.ToUpper() == "LEFT MOUSE BUTTON" || element.elementIdentifierName.ToUpper() == "RIGHT MOUSE BUTTON"))
			{
				return false;
			}
			return true;
		}

		private void OnCancelClicked(Widget widget)
		{
			Close();
		}

		private void OnCenterButtonClicked(Widget widget)
		{
			if (_currentConflict != null)
			{
				_currentConflict.responseCallback(InputMapper.ConflictResponse.Add);
			}
			else if (CenterButtonText.Text == "Remove")
			{
				_controllerMap.DeleteElementMap(_actionMap.id);
				switch (_buttonType)
				{
				case ControlSettingsDialogScript.RowButtonType.Controller:
					_row.ControllerText.Text = string.Empty;
					break;
				case ControlSettingsDialogScript.RowButtonType.Keyboard:
					_row.KeyboardText.Text = string.Empty;
					break;
				case ControlSettingsDialogScript.RowButtonType.KeyboardAlternate:
					_row.KeyboardAlternateText.Text = string.Empty;
					break;
				}
				Close();
			}
		}

		private void OnInputMapped(InputMapper.InputMappedEventData obj)
		{
			_row.OnInputMapped(obj);
		}

		private void OnMappingStopped(InputMapper.StoppedEventData obj)
		{
			_row.OnMappingStopped(obj);
		}

		private void OnRightButtonClicked(Widget widget)
		{
			if (_currentConflict != null)
			{
				_currentConflict.responseCallback(InputMapper.ConflictResponse.Replace);
			}
			else if (CenterButtonText.Text == "Remove")
			{
				BindMode();
			}
		}

		private void ReplaceOrRemoveMode()
		{
			ShowCenterAxesImage(show: false);
			_timerText.Text = string.Empty;
			_timerText.Visible = false;
			MessageText = HighlightText(_row.ActionNameText.Text) + " is currently bound to " + HighlightText(InputUtilities.GetBindingDisplayName(_actionMap)) + "\n\nWould you like to remove or replace this binding?";
			RightButtonText.Text = "Replace";
			CenterButtonText.Text = "Remove";
			_buttonPanel.Visible = true;
		}

		private void StartListeningForInput(ControlSettingsRowScript row, ControlSettingsDialogScript.RowButtonType buttonType)
		{
			ShowCenterAxesImage(show: false);
			if (_controllerToListenFor.type == ControllerType.Keyboard)
			{
				MessageText = "Press a key to assign it to\n" + HighlightText(row.ActionNameText.Text) + "\n\nModifier keys may also be used. To assign a modifier key alone, hold it down for 1 second.";
			}
			else
			{
				MessageText = "Now press a button or move an axis to assign it to\n" + HighlightText(row.ActionNameText.Text);
			}
			_inputMapper.options.checkForConflicts = true;
			_inputMapper.options.allowKeyboardKeysWithModifiers = true;
			_inputMapper.options.allowKeyboardModifierKeyAsPrimary = true;
			_inputMapper.options.holdDurationToMapKeyboardModifierKeyAsPrimary = 1f;
			InputMapper.Options options = _inputMapper.options;
			options.isElementAllowedCallback = (Predicate<ControllerPollingInfo>)Delegate.Combine(options.isElementAllowedCallback, new Predicate<ControllerPollingInfo>(IsElementAllowed));
			if (Game.Instance.Device.IsMobileBuild)
			{
				_inputMapper.options.ignoreMouseXAxis = true;
				_inputMapper.options.ignoreMouseYAxis = true;
			}
			_inputMapper.InputMappedEvent += OnInputMapped;
			_inputMapper.StoppedEvent += OnMappingStopped;
			_inputMapper.ConflictFoundEvent += HandleConflict;
			row.MappingType = buttonType;
			InputMapper.Context mappingContext = new InputMapper.Context
			{
				actionId = row.Action.id,
				actionRange = row.AxisDirection,
				controllerMap = _controllerMap,
				actionElementMapToReplace = _actionMap
			};
			_inputMapper.Start(mappingContext);
			WaitFor(5f, delegate
			{
				Close();
			}, skipWaitOnButtonUp: false);
		}

		private IEnumerator Wait(Action onComplete, bool skipWaitOnButtonUp = false)
		{
			while (WaitTime > 0f)
			{
				yield return new WaitForEndOfFrame();
				WaitTime -= Time.unscaledDeltaTime;
				WaitTime = Mathf.Clamp(WaitTime, 0f, float.PositiveInfinity);
				_timerText.Visible = true;
				_timerText.Text = WaitTime.ToString("0.0");
				if (skipWaitOnButtonUp && _controllerToListenFor.GetAnyButtonUp())
				{
					break;
				}
			}
			onComplete?.Invoke();
		}
	}
}
