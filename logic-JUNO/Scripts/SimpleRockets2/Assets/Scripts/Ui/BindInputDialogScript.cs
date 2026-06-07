using System;
using System.Collections;
using Assets.Scripts.Input;
using Assets.Scripts.Ui.Settings;
using ModApi.Ui;
using Rewired;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class BindInputDialogScript : DialogScript
	{
		private ActionElementMap _actionMap;

		private XmlElement _buttonPanel;

		private ControlSettingsDialogScript.RowButtonType _buttonType;

		private XmlElement _centerStickPanel;

		private ControllerMap _controllerMap;

		private Controller _controllerToListenFor;

		private InputMapper.ConflictFoundEventData _currentConflict;

		private Coroutine _currentCoroutine;

		private InputMapper _inputMapper = new InputMapper();

		private TextMeshProUGUI _label;

		private XmlElement _panel;

		private ControlSettingsRowScript _row;

		private TextMeshProUGUI _timerText;

		private TextMeshProUGUI _title;

		public string MapCategory { get; set; }

		public Button CancelButton { get; private set; }

		public Button CenterButton { get; private set; }

		public XmlElement CenterButtonText { get; private set; }

		public string MessageText
		{
			get
			{
				return _label.text;
			}
			set
			{
				_label.SetText(value);
			}
		}

		public Button RightButton { get; private set; }

		public XmlElement RightButtonText { get; private set; }

		public float WaitTime { get; set; }

		public static BindInputDialogScript Create(Transform parent, ControlSettingsRowScript row, ControlSettingsDialogScript.RowButtonType buttonType, Controller controllerToListenFor)
		{
			BindInputDialogScript bindInputDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/Settings/BindInputDialog", parent, delegate(BindInputDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
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
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
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
			_panel.Show();
			_title.SetText("Binding " + _row.ActionNameText.GetAttribute("text"));
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

		private void BindMode()
		{
			if (_controllerToListenFor.type == ControllerType.Keyboard)
			{
				_buttonPanel.Hide();
				StartListeningForInput(_row, _buttonType);
				return;
			}
			ShowCenterAxesImage();
			_buttonPanel.Hide();
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
			_timerText.SetText(string.Empty);
			string text = ((conflictData.conflicts[0].elementMap.axisRange == AxisRange.Full) ? conflictData.conflicts[0].action.descriptiveName : ((conflictData.conflicts[0].elementMap.axisRange == AxisRange.Positive) ? conflictData.conflicts[0].action.positiveDescriptiveName : conflictData.conflicts[0].action.negativeDescriptiveName));
			for (int i = 1; i < conflictData.conflicts.Count; i++)
			{
				text = ((i != conflictData.conflicts.Count - 1 || i <= 0) ? (text + ", ") : (text + ", and "));
				text += ((conflictData.conflicts[i].elementMap.axisRange == AxisRange.Full) ? conflictData.conflicts[i].action.descriptiveName : ((conflictData.conflicts[i].elementMap.axisRange == AxisRange.Positive) ? conflictData.conflicts[i].action.positiveDescriptiveName : conflictData.conflicts[i].action.negativeDescriptiveName));
			}
			string text2 = conflictData.assignment.elementDisplayName;
			if (_controllerToListenFor.type == ControllerType.Keyboard)
			{
				text2 = InputUtilities.GetKeyCodeDisplayName(conflictData.assignment.keyCode, conflictData.assignment.elementDisplayName);
			}
			MessageText = text2 + " is already in use by " + text + ". \n Do you want to replace it? \n You may also choose to add the assignment anyway.";
			_timerText.SetText(string.Empty);
			RightButtonText.SetText("Replace");
			CenterButtonText.SetText("Add");
			_buttonPanel.Show();
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

		private void OnCancelClicked()
		{
			Close();
		}

		private void OnCenterButtonClicked()
		{
			if (_currentConflict != null)
			{
				_currentConflict.responseCallback(InputMapper.ConflictResponse.Add);
			}
			else if (CenterButtonText.GetAttribute("text") == "Remove")
			{
				_controllerMap.DeleteElementMap(_actionMap.id);
				switch (_buttonType)
				{
				case ControlSettingsDialogScript.RowButtonType.Controller:
					_row.ControllerText.SetText(string.Empty);
					break;
				case ControlSettingsDialogScript.RowButtonType.Keyboard:
					_row.KeyboardText.SetText(string.Empty);
					break;
				case ControlSettingsDialogScript.RowButtonType.KeyboardAlternate:
					_row.KeyboardAlternateText.SetText(string.Empty);
					break;
				}
				Close();
			}
		}

		private void OnInputMapped(InputMapper.InputMappedEventData obj)
		{
			_row.OnInputMapped(obj);
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_title = xmlLayout.GetElementById<TextMeshProUGUI>("label-title");
			_label = xmlLayout.GetElementById<TextMeshProUGUI>("label-text");
			CancelButton = xmlLayout.GetElementById<Button>("cancel-button");
			CenterButton = xmlLayout.GetElementById<Button>("center-button");
			RightButton = xmlLayout.GetElementById<Button>("right-button");
			_timerText = xmlLayout.GetElementById<TextMeshProUGUI>("timer-text");
			_centerStickPanel = xmlLayout.GetElementById("center-stick-panel");
			_buttonPanel = xmlLayout.GetElementById("button-panel");
			CenterButtonText = xmlLayout.GetElementById("center-button-text");
			RightButtonText = xmlLayout.GetElementById("right-button-text");
			_panel.SetAttribute("active", "false");
		}

		private void OnMappingStopped(InputMapper.StoppedEventData obj)
		{
			_row.OnMappingStopped(obj);
		}

		private void OnRightButtonClicked()
		{
			if (_currentConflict != null)
			{
				_currentConflict.responseCallback(InputMapper.ConflictResponse.Replace);
			}
			else if (CenterButtonText.GetAttribute("text") == "Remove")
			{
				BindMode();
			}
		}

		private void ReplaceOrRemoveMode()
		{
			ShowCenterAxesImage(show: false);
			_timerText.text = string.Empty;
			MessageText = InputUtilities.GetBindingDisplayName(_actionMap);
			RightButtonText.SetText("Replace");
			CenterButtonText.SetText("Remove");
			_buttonPanel.Show();
		}

		private void StartListeningForInput(ControlSettingsRowScript row, ControlSettingsDialogScript.RowButtonType buttonType)
		{
			ShowCenterAxesImage(show: false);
			if (_controllerToListenFor.type == ControllerType.Keyboard)
			{
				MessageText = "Press a key to assign it to " + row.ActionNameText.GetAttribute("text") + ".\nModifier keys may also be used. To assign a modifier key alone, hold it down for 1 second.";
			}
			else
			{
				MessageText = "Now press a button or move an axis to assign it to " + row.ActionNameText.GetAttribute("text") + ".";
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
				_timerText.SetText(WaitTime.ToString("0.0"));
				if (skipWaitOnButtonUp && _controllerToListenFor.GetAnyButtonUp())
				{
					break;
				}
			}
			onComplete?.Invoke();
		}
	}
}
