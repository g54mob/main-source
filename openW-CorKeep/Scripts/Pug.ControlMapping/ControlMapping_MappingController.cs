using System;
using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

public class ControlMapping_MappingController
{
	public delegate void ActionMappingChangeDelegate(ActionElementMap mapping);

	private abstract class QueueEntry
	{
		public enum State
		{
			Waiting = 0,
			Confirmed = 1,
			Canceled = 2
		}

		private static int uidCounter;

		public int id { get; protected set; }

		public QueueActionType queueActionType { get; protected set; }

		public State state { get; protected set; }

		public ControlMappingUserResponse response { get; protected set; }

		protected static int nextId
		{
			get
			{
				int result = uidCounter;
				uidCounter++;
				return result;
			}
		}

		public QueueEntry(QueueActionType queueActionType)
		{
			id = nextId;
			this.queueActionType = queueActionType;
		}

		public void Confirm(ControlMappingUserResponse response)
		{
			state = State.Confirmed;
			this.response = response;
		}

		public void Cancel()
		{
			state = State.Canceled;
		}

		public override string ToString()
		{
			return string.Format("{0}: entry id - {1}, type - {2}, state - {3}", "QueueEntry", id, queueActionType, state);
		}
	}

	private class ElementAssignmentChange : QueueEntry
	{
		public ElementAssignmentChangeType changeType { get; set; }

		public InputMapper.Context context { get; private set; }

		public ElementAssignmentChange(ElementAssignmentChangeType changeType, InputMapper.Context context)
			: base(QueueActionType.ElementAssignment)
		{
			this.changeType = changeType;
			this.context = context;
		}

		public ElementAssignmentChange(ElementAssignmentChange other)
			: this(other.changeType, other.context.Clone())
		{
		}
	}

	private class Calibration : QueueEntry
	{
		public enum CalibrationTarget
		{
			Zero = 0,
			Range = 1
		}

		private const string ZERO_TITLE_KEY = "ControlMapper/calibrateAxisStep1WindowTitle";

		private const string ZERO_MESSAGE_KEY = "ControlMapper/calibrateAxisStep1WindowMessage";

		private const string RANGE_TITLE_KEY = "ControlMapper/calibrateAxisStep2WindowTitle";

		private const string RANGE_MESSAGE_KEY = "ControlMapper/calibrateAxisStep2WindowMessage";

		private AxisCalibrationData _data;

		private int _axisIndex;

		public AxisCalibration AxisCalibration { get; }

		public Joystick Joystick { get; }

		public TimerSimple Timer { get; }

		public CalibrationTarget Target { get; }

		public int ElementIdentifier { get; }

		public AxisCalibrationData Data => _data;

		public Calibration(CalibrationTarget target, AxisCalibrationData data, Joystick joystick, AxisCalibration axisCalibration, int elementIdentifier, float duration)
			: base(QueueActionType.Calibrate)
		{
			Target = target;
			_data = data;
			AxisCalibration = axisCalibration;
			Joystick = joystick;
			ElementIdentifier = elementIdentifier;
			Timer = new TimerSimple(duration, unscaled: true, startTimer: true);
			_axisIndex = Joystick.GetAxisIndexById(elementIdentifier);
		}

		public string GetTitleLocalizationKey()
		{
			return Target switch
			{
				CalibrationTarget.Zero => "ControlMapper/calibrateAxisStep1WindowTitle", 
				CalibrationTarget.Range => "ControlMapper/calibrateAxisStep2WindowTitle", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public string GetMessageLocalizationKey()
		{
			return Target switch
			{
				CalibrationTarget.Zero => "ControlMapper/calibrateAxisStep1WindowMessage", 
				CalibrationTarget.Range => "ControlMapper/calibrateAxisStep2WindowMessage", 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public void UpdateTargetValues()
		{
			switch (Target)
			{
			case CalibrationTarget.Zero:
				_data.zero = Joystick.GetAxisRaw(_axisIndex);
				break;
			case CalibrationTarget.Range:
				_data.min = Mathf.Min(Joystick.GetAxisRaw(_axisIndex), _data.min);
				_data.max = Mathf.Max(Joystick.GetAxisRaw(_axisIndex), _data.max);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public void ApplyTargetValue()
		{
			AxisCalibration.SetData(_data);
		}
	}

	private class ResetToDefaults : QueueEntry
	{
		public ResetToDefaults(QueueActionType queueActionType)
			: base(queueActionType)
		{
		}
	}

	private class DialogHelper
	{
		public enum DialogType
		{
			None = 0,
			JoystickConflict = 1,
			Calibrate = 2,
			KeyConflict = 3,
			DeleteAssignmentConfirmation = 10,
			AssignElement = 11,
			ResetDefaults = 12
		}

		private const float openBusyDelay = 0.25f;

		private const float closeBusyDelay = 0.1f;

		private DialogType _type;

		private bool _enabled;

		private float _busyTime;

		private bool _busyTimerRunning;

		private int currentActionId;

		private Action<int, ControlMappingUserResponse> resultCallback;

		private Action updateDelegate;

		private ControlMapping_Popup _popup;

		private float busyTimer
		{
			get
			{
				if (!_busyTimerRunning)
				{
					return 0f;
				}
				return _busyTime - Time.realtimeSinceStartup;
			}
		}

		public bool enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (value)
				{
					if (_type != DialogType.None)
					{
						StateChanged(0.25f);
					}
				}
				else
				{
					_enabled = value;
					_type = DialogType.None;
					StateChanged(0.1f);
				}
			}
		}

		public DialogType type
		{
			get
			{
				if (!_enabled)
				{
					return DialogType.None;
				}
				return _type;
			}
			set
			{
				if (value == DialogType.None)
				{
					_enabled = false;
					StateChanged(0.1f);
				}
				else
				{
					_enabled = true;
					StateChanged(0.25f);
				}
				_type = value;
			}
		}

		public bool busy => _busyTimerRunning;

		public string message { get; private set; }

		public ControlMapping_Popup.DisplayConfig DefaultDisplayConfig => new ControlMapping_Popup.DisplayConfig
		{
			Localize = true,
			TitleFontFace = TextManager.FontFace.boldMedium,
			MessageFontFace = TextManager.FontFace.thinSmall,
			OptionsFontFace = TextManager.FontFace.boldMedium,
			TextMaxWidth = 14f,
			HighlightColor = Color.yellow
		};

		public ControlMapping_Popup Popup => _popup;

		public DialogHelper(ControlMapping_Popup popup)
		{
			_popup = popup;
		}

		public void StartModal(int queueActionId, DialogType type, string title, string message, Action<int, ControlMappingUserResponse> resultCallback, List<string> options = null, Action updateDelegate = null, ControlMapping_Popup.DisplayConfig? displayConfig = null, Dictionary<ControlMapping_Popup.TargetElement, List<string>> formatFields = null, bool localizeFormatFields = false)
		{
			currentActionId = queueActionId;
			this.message = message;
			this.type = type;
			this.resultCallback = resultCallback;
			this.updateDelegate = updateDelegate;
			StateChanged(0.25f);
			_popup.Show(title, message, displayConfig ?? DefaultDisplayConfig, options, OnOptionSelected, formatFields, localizeFormatFields);
		}

		private void OnOptionSelected(PopupResponse response)
		{
			if (!busy)
			{
				resultCallback?.Invoke(currentActionId, (ControlMappingUserResponse)response.Value);
				Close();
			}
		}

		public void Update()
		{
			UpdateTimers();
			if (_enabled)
			{
				updateDelegate?.Invoke();
			}
		}

		public void Confirm()
		{
			Confirm(ControlMappingUserResponse.Confirm);
		}

		public void Confirm(ControlMappingUserResponse response)
		{
			resultCallback?.Invoke(currentActionId, response);
			Close();
		}

		public void Cancel()
		{
			resultCallback?.Invoke(currentActionId, ControlMappingUserResponse.Cancel);
			Close();
		}

		private void UpdateTimers()
		{
			if (_busyTimerRunning && busyTimer <= 0f)
			{
				_busyTimerRunning = false;
			}
		}

		private void StartBusyTimer(float time)
		{
			_busyTime = time + Time.realtimeSinceStartup;
			_busyTimerRunning = true;
		}

		private void Close()
		{
			if (_enabled)
			{
				Reset();
				StateChanged(0.1f);
				_popup.Hide();
			}
		}

		private void StateChanged(float delay)
		{
			StartBusyTimer(delay);
		}

		private void Reset()
		{
			_enabled = false;
			_type = DialogType.None;
			currentActionId = -1;
			resultCallback = null;
			updateDelegate = null;
		}

		private void ResetTimers()
		{
			_busyTimerRunning = false;
		}

		public void FullReset()
		{
			Reset();
			ResetTimers();
		}
	}

	private enum QueueActionType
	{
		None = 0,
		ElementAssignment = 1,
		Calibrate = 2,
		ResetDefaults = 3
	}

	private enum ElementAssignmentChangeType
	{
		Add = 0,
		Replace = 1,
		Remove = 2,
		ReassignOrRemove = 3,
		ConflictCheck = 4
	}

	private const float CALIBRATION_DURATION = 10f;

	private DialogHelper _dialog;

	private InputMapper _inputMapper;

	private InputMapper.ConflictFoundEventData _conflictFoundEventData;

	private bool _startListening;

	private Queue<QueueEntry> _actionQueue;

	private bool _busy;

	private readonly ControlMapperLanguageData _languageData;

	private bool PendingConflictExists => _conflictFoundEventData != null;

	public bool IsBusy
	{
		get
		{
			if (!_busy)
			{
				return _dialog.busy;
			}
			return true;
		}
	}

	public event ActionMappingChangeDelegate ActionMappingChanged;

	public event Action ActionMappingStarted;

	public event Action ActionMappingConflictFound;

	public event Action<ControlMappingUserResponse> ActionMappingCompleted;

	public event Action<bool> ResetToDefaultsCompleted;

	public event Action CalibrationStarted;

	public event Action CalibrationCompleted;

	public event Action ActionRemoveOrReassignElement;

	public event Action ActionRemoveOrReassignElementCanceled;

	public ControlMapping_MappingController(ControlMapperLanguageData languageData, ControlMapping_Popup popup, float assignmentTimeout, bool ignoreMouseAxes, Predicate<ControllerPollingInfo> isElementAllowedCallback)
	{
		_languageData = languageData;
		_dialog = new DialogHelper(popup);
		_inputMapper = new InputMapper();
		_actionQueue = new Queue<QueueEntry>();
		_inputMapper.options.timeout = assignmentTimeout;
		_inputMapper.options.ignoreMouseXAxis = ignoreMouseAxes;
		_inputMapper.options.ignoreMouseYAxis = ignoreMouseAxes;
		_inputMapper.options.isElementAllowedCallback = isElementAllowedCallback;
		_inputMapper.options.checkForConflictsWithAllPlayers = false;
		_inputMapper.options.checkForConflictsWithSystemPlayer = false;
	}

	public void Update()
	{
		ProcessQueue();
		_dialog.Update();
		_busy = false;
	}

	public void StartElementAssignmentChange(InputAction action, AxisRange axisRange, ControllerMap controllerMap, ActionElementMap elementMap)
	{
		InputMapper.Context context = new InputMapper.Context
		{
			actionId = action.id,
			actionRange = axisRange,
			controllerMap = controllerMap,
			actionElementMapToReplace = elementMap
		};
		EnqueueAction(new ElementAssignmentChange(ElementAssignmentChangeType.ReassignOrRemove, context));
		_startListening = true;
		SubscribeToInputMapperEvents();
	}

	public void StartAddActionMap(InputAction action, AxisRange axisRange, ControllerMap controllerMap)
	{
		InputMapper.Context context = new InputMapper.Context
		{
			actionId = action.id,
			actionRange = axisRange,
			controllerMap = controllerMap
		};
		EnqueueAction(new ElementAssignmentChange(ElementAssignmentChangeType.Add, context));
		_startListening = true;
		SubscribeToInputMapperEvents();
	}

	public void StartCalibration(Joystick joystick, AxisCalibration axisCalibration, int elementIdentifier)
	{
		this.CalibrationStarted?.Invoke();
		AxisCalibrationData axisData = joystick.calibrationMap.GetAxisData(joystick.GetAxisIndexById(elementIdentifier));
		EnqueueAction(new Calibration(Calibration.CalibrationTarget.Zero, axisData, joystick, axisCalibration, elementIdentifier, 10f));
	}

	public void InvertAxis(ActionElementMap elementMap)
	{
		elementMap.invert = !elementMap.invert;
	}

	public void StartResetDefaults()
	{
		EnqueueAction(new ResetToDefaults(QueueActionType.ResetDefaults));
	}

	public void Cleanup()
	{
		_dialog.Cancel();
		_dialog.FullReset();
		_actionQueue.Clear();
		_busy = false;
		_startListening = false;
		_conflictFoundEventData = null;
		_inputMapper.Stop();
		UnsubscribeFromInputMapperEvents();
	}

	private void EnqueueAction(QueueEntry entry)
	{
		if (entry != null)
		{
			_busy = true;
			_actionQueue.Enqueue(entry);
		}
	}

	private void ProcessQueue()
	{
		if (_dialog.enabled || _busy || _actionQueue.Count == 0)
		{
			return;
		}
		while (_actionQueue.Count > 0)
		{
			QueueEntry queueEntry = _actionQueue.Peek();
			bool flag = false;
			switch (queueEntry.queueActionType)
			{
			case QueueActionType.ElementAssignment:
				flag = ProcessElementAssignmentChange((ElementAssignmentChange)queueEntry);
				break;
			case QueueActionType.Calibrate:
				flag = ProcessCalibration((Calibration)queueEntry);
				break;
			case QueueActionType.ResetDefaults:
				flag = ProcessResetDefaults((ResetToDefaults)queueEntry);
				break;
			}
			if (flag)
			{
				_actionQueue.Dequeue();
				continue;
			}
			break;
		}
	}

	private bool ProcessElementAssignmentChange(ElementAssignmentChange entry)
	{
		switch (entry.changeType)
		{
		case ElementAssignmentChangeType.ReassignOrRemove:
			return ProcessRemoveOrReassignElementAssignment(entry);
		case ElementAssignmentChangeType.Remove:
			return ProcessRemoveElementAssignment(entry);
		case ElementAssignmentChangeType.Add:
		case ElementAssignmentChangeType.Replace:
			return ProcessAddOrReplaceElementAssignment(entry);
		case ElementAssignmentChangeType.ConflictCheck:
			return ProcessElementAssignmentConflictCheck(entry);
		default:
			throw new NotImplementedException();
		}
	}

	private bool ProcessCalibration(Calibration entry)
	{
		if (entry.state == QueueEntry.State.Canceled)
		{
			this.CalibrationCompleted?.Invoke();
			return true;
		}
		if (entry.state == QueueEntry.State.Confirmed)
		{
			entry.ApplyTargetValue();
			if (entry.Target == Calibration.CalibrationTarget.Zero)
			{
				Calibration entry2 = new Calibration(Calibration.CalibrationTarget.Range, entry.Data, entry.Joystick, entry.AxisCalibration, entry.ElementIdentifier, 10f);
				EnqueueAction(entry2);
			}
			else if (entry.Target == Calibration.CalibrationTarget.Range)
			{
				this.CalibrationCompleted?.Invoke();
			}
			return true;
		}
		_dialog.Popup.ShowTimeout(show: true);
		string controllerButtonCharacter = Manager.ui.controllerButtonToCharTable.GetControllerButtonCharacter(entry.Joystick.type, entry.Joystick.name, entry.Joystick.ElementIdentifiers[entry.ElementIdentifier].name, fallbackToControllerButton: false);
		string item = ((controllerButtonCharacter != null) ? controllerButtonCharacter : PugFont.ApplyColorTag(_languageData.GetElementIdentifierName(entry.Joystick, entry.ElementIdentifier, AxisRange.Full), _dialog.DefaultDisplayConfig.HighlightColor));
		_dialog.StartModal(entry.id, DialogHelper.DialogType.Calibrate, entry.GetTitleLocalizationKey(), entry.GetMessageLocalizationKey(), DialogResultCallback, null, UpdateJoystickCalibration, null, new Dictionary<ControlMapping_Popup.TargetElement, List<string>> { 
		{
			ControlMapping_Popup.TargetElement.Message,
			new List<string> { item }
		} });
		return false;
	}

	private bool ProcessRemoveOrReassignElementAssignment(ElementAssignmentChange entry)
	{
		if (entry.context.controllerMap == null)
		{
			_inputMapper.Stop();
			return true;
		}
		if (entry.state == QueueEntry.State.Canceled)
		{
			_inputMapper.Stop();
			this.ActionRemoveOrReassignElementCanceled?.Invoke();
			return true;
		}
		if (entry.state == QueueEntry.State.Confirmed && entry.response == ControlMappingUserResponse.Confirm)
		{
			ElementAssignmentChange elementAssignmentChange = new ElementAssignmentChange(entry);
			elementAssignmentChange.changeType = ElementAssignmentChangeType.Remove;
			_actionQueue.Enqueue(elementAssignmentChange);
			return true;
		}
		if (entry.state == QueueEntry.State.Confirmed && entry.response == ControlMappingUserResponse.Custom1)
		{
			ElementAssignmentChange elementAssignmentChange2 = new ElementAssignmentChange(entry);
			elementAssignmentChange2.changeType = ElementAssignmentChangeType.Replace;
			_actionQueue.Enqueue(elementAssignmentChange2);
			return true;
		}
		this.ActionRemoveOrReassignElement?.Invoke();
		_dialog.StartModal(entry.id, DialogHelper.DialogType.AssignElement, "ControlMapper/ReassignRemoveTitle", "ControlMapper/ReassignRemoveMessage", DialogResultCallback, new List<string> { _languageData.cancel, _languageData.remove, _languageData.replace });
		return false;
	}

	private bool ProcessRemoveElementAssignment(ElementAssignmentChange entry)
	{
		if (entry.context.controllerMap == null)
		{
			return true;
		}
		if (entry.state == QueueEntry.State.Canceled)
		{
			return true;
		}
		if (entry.state == QueueEntry.State.Confirmed)
		{
			entry.context.controllerMap.DeleteElementMap(entry.context.actionElementMapToReplace.id);
			this.ActionMappingCompleted?.Invoke(ControlMappingUserResponse.Confirm);
			return true;
		}
		string actionName = _languageData.GetActionName(entry.context.actionId, entry.context.actionRange);
		ActionElementMap actionElementMapToReplace = entry.context.actionElementMapToReplace;
		string controllerButtonCharacter = Manager.ui.controllerButtonToCharTable.GetControllerButtonCharacter(entry.context.controllerMap.controllerType, actionElementMapToReplace.controllerMap.controller.name, actionElementMapToReplace.elementIdentifierName, fallbackToControllerButton: false);
		bool flag = controllerButtonCharacter != null;
		controllerButtonCharacter = PugText.GetButtonStringForThai(controllerButtonCharacter);
		DialogHelper dialog = _dialog;
		int id = entry.id;
		string remove = _languageData.remove;
		Action<int, ControlMappingUserResponse> resultCallback = DialogResultCallback;
		List<string> options = new List<string> { _languageData.cancel, _languageData.remove };
		Dictionary<ControlMapping_Popup.TargetElement, List<string>> formatFields = new Dictionary<ControlMapping_Popup.TargetElement, List<string>> { 
		{
			ControlMapping_Popup.TargetElement.Message,
			new List<string>
			{
				flag ? controllerButtonCharacter : PugFont.ApplyColorTag(_languageData.GetElementIdentifierName(actionElementMapToReplace), _dialog.DefaultDisplayConfig.HighlightColor),
				PugFont.ApplyColorTag(actionName, _dialog.DefaultDisplayConfig.HighlightColor)
			}
		} };
		dialog.StartModal(id, DialogHelper.DialogType.DeleteAssignmentConfirmation, remove, "ControlMapper/RemoveAssignmentMessage", resultCallback, options, null, null, formatFields);
		return false;
	}

	private bool ProcessAddOrReplaceElementAssignment(ElementAssignmentChange entry)
	{
		if (entry.state == QueueEntry.State.Canceled || entry.context.controllerMap == null)
		{
			_inputMapper.Stop();
			return true;
		}
		if (entry.context.controllerMap == null)
		{
			_inputMapper.Stop();
			return true;
		}
		if (entry.state == QueueEntry.State.Confirmed)
		{
			if (PendingConflictExists)
			{
				ElementAssignmentChange elementAssignmentChange = new ElementAssignmentChange(entry);
				elementAssignmentChange.changeType = ElementAssignmentChangeType.ConflictCheck;
				_actionQueue.Enqueue(elementAssignmentChange);
			}
			return true;
		}
		_ = 2;
		string message = ((entry.context.controllerMap.controllerType == ControllerType.Keyboard) ? _languageData.GetKeyboardElementAssignmentPollingWindowMessage(entry.context.actionName) : ((entry.context.controllerMap.controllerType != ControllerType.Mouse) ? "ControlMapper/AssignJoystickMessagePC" : _languageData.GetMouseElementAssignmentPollingWindowMessage(entry.context.actionName)));
		string actionName = _languageData.GetActionName(entry.context.actionId, entry.context.actionRange);
		_dialog.Popup.ShowTimeout(show: true);
		DialogHelper dialog = _dialog;
		int id = entry.id;
		Action<int, ControlMappingUserResponse> resultCallback = DialogResultCallback;
		Action updateDelegate = UpdateElementAssignmentChange;
		Dictionary<ControlMapping_Popup.TargetElement, List<string>> formatFields = new Dictionary<ControlMapping_Popup.TargetElement, List<string>> { 
		{
			ControlMapping_Popup.TargetElement.Message,
			new List<string> { PugFont.ApplyColorTag(actionName, _dialog.DefaultDisplayConfig.HighlightColor) }
		} };
		dialog.StartModal(id, DialogHelper.DialogType.AssignElement, "ControlMapper/Assign", message, resultCallback, null, updateDelegate, null, formatFields);
		return false;
	}

	private bool ProcessElementAssignmentConflictCheck(ElementAssignmentChange entry)
	{
		if (entry.context.controllerMap == null)
		{
			return true;
		}
		if (entry.state == QueueEntry.State.Canceled)
		{
			_inputMapper.Stop();
			return true;
		}
		if (!PendingConflictExists)
		{
			return true;
		}
		if (entry.state == QueueEntry.State.Confirmed)
		{
			if (entry.response == ControlMappingUserResponse.Confirm)
			{
				_conflictFoundEventData.responseCallback(InputMapper.ConflictResponse.Replace);
			}
			else
			{
				if (entry.response != ControlMappingUserResponse.Custom1)
				{
					throw new NotImplementedException();
				}
				_conflictFoundEventData.responseCallback(InputMapper.ConflictResponse.Add);
			}
			return true;
		}
		ActionElementMap elementMap = _conflictFoundEventData.conflicts.FirstOrDefault().elementMap;
		string controllerButtonCharacter = Manager.ui.controllerButtonToCharTable.GetControllerButtonCharacter(entry.context.controllerMap.controllerType, elementMap.controllerMap.controller.name, elementMap.elementIdentifierName, fallbackToControllerButton: false);
		bool flag = controllerButtonCharacter != null;
		string elementIdentifierName = _languageData.GetElementIdentifierName(elementMap);
		controllerButtonCharacter = (flag ? PugText.GetButtonStringForThai(controllerButtonCharacter) : PugFont.ApplyColorTag(elementIdentifierName, _dialog.DefaultDisplayConfig.HighlightColor));
		if (_conflictFoundEventData.isProtected)
		{
			string message = (flag ? _languageData.elementAlreadyInUseBlocked : _languageData.GetElementAlreadyInUseBlocked(PugFont.ApplyColorTag(elementIdentifierName, _dialog.DefaultDisplayConfig.HighlightColor)));
			DialogHelper dialog = _dialog;
			int id = entry.id;
			string elementAssignmentConflictWindowMessage = _languageData.elementAssignmentConflictWindowMessage;
			Action<int, ControlMappingUserResponse> resultCallback = DialogResultCallback;
			List<string> options = new List<string> { _languageData.cancel, "ControlMapper/Assign" };
			Action updateDelegate = UpdateElementAssignmentConflict;
			Dictionary<ControlMapping_Popup.TargetElement, List<string>> formatFields = new Dictionary<ControlMapping_Popup.TargetElement, List<string>> { 
			{
				ControlMapping_Popup.TargetElement.Message,
				new List<string> { controllerButtonCharacter }
			} };
			dialog.StartModal(id, DialogHelper.DialogType.AssignElement, elementAssignmentConflictWindowMessage, message, resultCallback, options, updateDelegate, null, formatFields);
		}
		else
		{
			string message2 = (flag ? _languageData.elementAlreadyInUseCanReplace_conflictAllowed : _languageData.GetElementAlreadyInUseCanReplace(PugFont.ApplyColorTag(elementIdentifierName, _dialog.DefaultDisplayConfig.HighlightColor), allowConflicts: true));
			DialogHelper dialog2 = _dialog;
			int id2 = entry.id;
			string elementAssignmentConflictWindowMessage2 = _languageData.elementAssignmentConflictWindowMessage;
			Action<int, ControlMappingUserResponse> resultCallback2 = DialogResultCallback;
			List<string> options2 = new List<string> { _languageData.cancel, _languageData.replace, _languageData.add };
			Action updateDelegate2 = UpdateElementAssignmentConflict;
			Dictionary<ControlMapping_Popup.TargetElement, List<string>> formatFields = new Dictionary<ControlMapping_Popup.TargetElement, List<string>> { 
			{
				ControlMapping_Popup.TargetElement.Message,
				new List<string> { controllerButtonCharacter }
			} };
			dialog2.StartModal(id2, DialogHelper.DialogType.AssignElement, elementAssignmentConflictWindowMessage2, message2, resultCallback2, options2, updateDelegate2, null, formatFields);
		}
		return false;
	}

	private bool ProcessResetDefaults(ResetToDefaults entry)
	{
		if (entry.state == QueueEntry.State.Canceled)
		{
			this.ResetToDefaultsCompleted?.Invoke(obj: false);
			return true;
		}
		if (entry.state == QueueEntry.State.Confirmed)
		{
			this.ResetToDefaultsCompleted?.Invoke(obj: true);
			return true;
		}
		_dialog.StartModal(entry.id, DialogHelper.DialogType.ResetDefaults, _languageData.restoreDefaultsWindowTitle, _languageData.restoreDefaultsWindowMessage, DialogResultCallback, new List<string> { _languageData.cancel, _languageData.yes });
		return false;
	}

	private void UpdateElementAssignmentChange()
	{
		if (!(_actionQueue.Peek() is ElementAssignmentChange elementAssignmentChange))
		{
			_dialog.Cancel();
		}
		else if (!_dialog.busy)
		{
			if (_startListening && _inputMapper.status == InputMapper.Status.Idle)
			{
				_inputMapper.Start(elementAssignmentChange.context);
				_startListening = false;
			}
			if (PendingConflictExists)
			{
				_dialog.Confirm();
				return;
			}
			_dialog.Popup.UpdateTimeout(Mathf.CeilToInt(_inputMapper.timeRemaining));
			if (_inputMapper.timeRemaining == 0f)
			{
				_dialog.Cancel();
			}
		}
		else
		{
			_dialog.Popup.UpdateTimeout(Mathf.CeilToInt(_inputMapper.options.timeout));
		}
	}

	private void UpdateElementAssignmentConflict()
	{
		if (_dialog.enabled && !(_actionQueue.Peek() is ElementAssignmentChange))
		{
			_dialog.Cancel();
		}
	}

	private void UpdateJoystickCalibration()
	{
		if (!(_actionQueue.Peek() is Calibration calibration))
		{
			_dialog.Cancel();
		}
		else if (!_dialog.busy)
		{
			_dialog.Popup.UpdateTimeout(Mathf.CeilToInt(calibration.Timer.remainingTime));
			calibration.UpdateTargetValues();
			if (calibration.Timer.isTimerElapsed || calibration.Joystick.GetAnyButtonUp())
			{
				_dialog.Confirm();
			}
		}
		else
		{
			_dialog.Popup.UpdateTimeout(Mathf.CeilToInt(10f));
		}
	}

	private void DialogResultCallback(int queueActionId, ControlMappingUserResponse response)
	{
		foreach (QueueEntry item in _actionQueue)
		{
			if (item.id == queueActionId)
			{
				if (response != ControlMappingUserResponse.Cancel)
				{
					item.Confirm(response);
				}
				else
				{
					item.Cancel();
				}
				break;
			}
		}
	}

	private void SubscribeToInputMapperEvents()
	{
		UnsubscribeFromInputMapperEvents();
		_inputMapper.ConflictFoundEvent += OnConflictFound;
		_inputMapper.StartedEvent += OnStarted;
		_inputMapper.StoppedEvent += OnStopped;
		_inputMapper.InputMappedEvent += OnInputMappedEvent;
	}

	private void UnsubscribeFromInputMapperEvents()
	{
		_inputMapper.RemoveAllEventListeners();
	}

	private void OnConflictFound(InputMapper.ConflictFoundEventData data)
	{
		_conflictFoundEventData = data;
		this.ActionMappingConflictFound?.Invoke();
	}

	private void OnStarted(InputMapper.StartedEventData data)
	{
		this.ActionMappingStarted?.Invoke();
	}

	private void OnStopped(InputMapper.StoppedEventData data)
	{
		_conflictFoundEventData = null;
		this.ActionMappingCompleted?.Invoke(ControlMappingUserResponse.Cancel);
	}

	private void OnInputMappedEvent(InputMapper.InputMappedEventData data)
	{
		if (string.IsNullOrWhiteSpace(data.actionElementMap.elementIdentifierName))
		{
			if (data.inputMapper.mappingContext.controllerMap.DeleteElementMap(data.actionElementMap.id))
			{
				Debug.LogWarning(string.Format("{0}.{1}: action id - {2} got mapped with an invalid mapping. Removing it.", "ControlMapping_MappingController", "OnInputMappedEvent", data.actionElementMap.actionId));
			}
			else
			{
				Debug.LogError(string.Format("{0}.{1}: action id - {2} got mapped with an invalid mapping. Removal failed, needs debugging.", "ControlMapping_MappingController", "OnInputMappedEvent", data.actionElementMap.actionId));
			}
		}
		else
		{
			this.ActionMappingChanged?.Invoke(data.actionElementMap);
		}
	}
}
