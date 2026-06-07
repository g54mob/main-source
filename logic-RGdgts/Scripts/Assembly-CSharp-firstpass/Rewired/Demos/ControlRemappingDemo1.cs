using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Demos
{
	public class ControlRemappingDemo1 : MonoBehaviour
	{
		private class ControllerSelection
		{
			private int _id;

			private int _idPrev;

			private ControllerType _type;

			private ControllerType _typePrev;

			public int id
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public ControllerType type
			{
				get
				{
					return default(ControllerType);
				}
				set
				{
				}
			}

			public int idPrev => 0;

			public ControllerType typePrev => default(ControllerType);

			public bool hasSelection => false;

			public void Set(int id, ControllerType type)
			{
			}

			public void Clear()
			{
			}
		}

		private class DialogHelper
		{
			public enum DialogType
			{
				None = 0,
				JoystickConflict = 1,
				ElementConflict = 2,
				KeyConflict = 3,
				DeleteAssignmentConfirmation = 10,
				AssignElement = 11
			}

			private const float openBusyDelay = 0.25f;

			private const float closeBusyDelay = 0.1f;

			private DialogType _type;

			private bool _enabled;

			private float _busyTime;

			private bool _busyTimerRunning;

			private Action<int> drawWindowDelegate;

			private GUI.WindowFunction drawWindowFunction;

			private WindowProperties windowProperties;

			private int currentActionId;

			private Action<int, UserResponse> resultCallback;

			private float busyTimer => 0f;

			public bool enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public DialogType type
			{
				get
				{
					return default(DialogType);
				}
				set
				{
				}
			}

			public bool busy => false;

			public void StartModal(int queueActionId, DialogType type, WindowProperties windowProperties, Action<int, UserResponse> resultCallback)
			{
			}

			public void StartModal(int queueActionId, DialogType type, WindowProperties windowProperties, Action<int, UserResponse> resultCallback, float openBusyDelay)
			{
			}

			public void Update()
			{
			}

			public void Draw()
			{
			}

			public void DrawConfirmButton()
			{
			}

			public void DrawConfirmButton(string title)
			{
			}

			public void DrawConfirmButton(UserResponse response)
			{
			}

			public void DrawConfirmButton(UserResponse response, string title)
			{
			}

			public void DrawCancelButton()
			{
			}

			public void DrawCancelButton(string title)
			{
			}

			public void Confirm()
			{
			}

			public void Confirm(UserResponse response)
			{
			}

			public void Cancel()
			{
			}

			private void DrawWindow(int windowId)
			{
			}

			private void UpdateTimers()
			{
			}

			private void StartBusyTimer(float time)
			{
			}

			private void Close()
			{
			}

			private void StateChanged(float delay)
			{
			}

			private void Reset()
			{
			}

			private void ResetTimers()
			{
			}

			public void FullReset()
			{
			}
		}

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

			public UserResponse response { get; protected set; }

			protected static int nextId => 0;

			public QueueEntry(QueueActionType queueActionType)
			{
			}

			public void Confirm(UserResponse response)
			{
			}

			public void Cancel()
			{
			}
		}

		private class JoystickAssignmentChange : QueueEntry
		{
			public int playerId { get; private set; }

			public int joystickId { get; private set; }

			public bool assign { get; private set; }

			public JoystickAssignmentChange(int newPlayerId, int joystickId, bool assign)
			{
			}
		}

		private class ElementAssignmentChange : QueueEntry
		{
			public ElementAssignmentChangeType changeType { get; set; }

			public InputMapper.Context context { get; private set; }

			public ElementAssignmentChange(ElementAssignmentChangeType changeType, InputMapper.Context context)
			{
			}

			public ElementAssignmentChange(ElementAssignmentChange other)
			{
			}
		}

		private class FallbackJoystickIdentification : QueueEntry
		{
			public int joystickId { get; private set; }

			public string joystickName { get; private set; }

			public FallbackJoystickIdentification(int joystickId, string joystickName)
			{
			}
		}

		private class Calibration : QueueEntry
		{
			public int selectedElementIdentifierId;

			public bool recording;

			public Player player { get; private set; }

			public ControllerType controllerType { get; private set; }

			public Joystick joystick { get; private set; }

			public CalibrationMap calibrationMap { get; private set; }

			public Calibration(Player player, Joystick joystick, CalibrationMap calibrationMap)
			{
			}
		}

		private struct WindowProperties
		{
			public int windowId;

			public Rect rect;

			public Action<string, string> windowDrawDelegate;

			public string title;

			public string message;
		}

		private enum QueueActionType
		{
			None = 0,
			JoystickAssignment = 1,
			ElementAssignment = 2,
			FallbackJoystickIdentification = 3,
			Calibrate = 4
		}

		private enum ElementAssignmentChangeType
		{
			Add = 0,
			Replace = 1,
			Remove = 2,
			ReassignOrRemove = 3,
			ConflictCheck = 4
		}

		public enum UserResponse
		{
			Confirm = 0,
			Cancel = 1,
			Custom1 = 2,
			Custom2 = 3
		}

		private const float defaultModalWidth = 250f;

		private const float defaultModalHeight = 200f;

		private const float assignmentTimeout = 5f;

		private DialogHelper dialog;

		private InputMapper inputMapper;

		private InputMapper.ConflictFoundEventData conflictFoundEventData;

		private bool guiState;

		private bool busy;

		private bool pageGUIState;

		private Player selectedPlayer;

		private int selectedMapCategoryId;

		private ControllerSelection selectedController;

		private ControllerMap selectedMap;

		private bool showMenu;

		private bool startListening;

		private Vector2 actionScrollPos;

		private Vector2 calibrateScrollPos;

		private Queue<QueueEntry> actionQueue;

		private bool setupFinished;

		[NonSerialized]
		private bool initialized;

		private bool isCompiling;

		private GUIStyle style_wordWrap;

		private GUIStyle style_centeredBox;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Initialize()
		{
		}

		private void Setup()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		public void OnGUI()
		{
		}

		private void HandleMenuControl()
		{
		}

		private void Close()
		{
		}

		private void Open()
		{
		}

		private void DrawInitialScreen()
		{
		}

		private void DrawPage()
		{
		}

		private void DrawPlayerSelector()
		{
		}

		private void DrawMouseAssignment()
		{
		}

		private void DrawJoystickSelector()
		{
		}

		private void DrawControllerSelector()
		{
		}

		private void DrawCalibrateButton()
		{
		}

		private void DrawMapCategories()
		{
		}

		private void DrawCategoryActions()
		{
		}

		private void DrawActionAssignmentButton(int playerId, InputAction action, AxisRange actionRange, ControllerSelection controller, ControllerMap controllerMap, ActionElementMap elementMap)
		{
		}

		private void DrawInvertButton(int playerId, InputAction action, Pole actionAxisContribution, ControllerSelection controller, ControllerMap controllerMap, ActionElementMap elementMap)
		{
		}

		private void DrawAddActionMapButton(int playerId, InputAction action, AxisRange actionRange, ControllerSelection controller, ControllerMap controllerMap)
		{
		}

		private void ShowDialog()
		{
		}

		private void DrawModalWindow(string title, string message)
		{
		}

		private void DrawModalWindow_OkayOnly(string title, string message)
		{
		}

		private void DrawElementAssignmentWindow(string title, string message)
		{
		}

		private void DrawElementAssignmentProtectedConflictWindow(string title, string message)
		{
		}

		private void DrawElementAssignmentNormalConflictWindow(string title, string message)
		{
		}

		private void DrawReassignOrRemoveElementAssignmentWindow(string title, string message)
		{
		}

		private void DrawFallbackJoystickIdentificationWindow(string title, string message)
		{
		}

		private void DrawCalibrationWindow(string title, string message)
		{
		}

		private void DialogResultCallback(int queueActionId, UserResponse response)
		{
		}

		private Rect GetScreenCenteredRect(float width, float height)
		{
			return default(Rect);
		}

		private void EnqueueAction(QueueEntry entry)
		{
		}

		private void ProcessQueue()
		{
		}

		private bool ProcessJoystickAssignmentChange(JoystickAssignmentChange entry)
		{
			return false;
		}

		private bool ProcessElementAssignmentChange(ElementAssignmentChange entry)
		{
			return false;
		}

		private bool ProcessRemoveOrReassignElementAssignment(ElementAssignmentChange entry)
		{
			return false;
		}

		private bool ProcessRemoveElementAssignment(ElementAssignmentChange entry)
		{
			return false;
		}

		private bool ProcessAddOrReplaceElementAssignment(ElementAssignmentChange entry)
		{
			return false;
		}

		private bool ProcessElementAssignmentConflictCheck(ElementAssignmentChange entry)
		{
			return false;
		}

		private bool ProcessFallbackJoystickIdentification(FallbackJoystickIdentification entry)
		{
			return false;
		}

		private bool ProcessCalibration(Calibration entry)
		{
			return false;
		}

		private void PlayerSelectionChanged()
		{
		}

		private void ControllerSelectionChanged()
		{
		}

		private void ClearControllerSelection()
		{
		}

		private void ClearMapSelection()
		{
		}

		private void ResetAll()
		{
		}

		private void ClearWorkingVars()
		{
		}

		private void SetGUIStateStart()
		{
		}

		private void SetGUIStateEnd()
		{
		}

		private void JoystickConnected(ControllerStatusChangedEventArgs args)
		{
		}

		private void JoystickPreDisconnect(ControllerStatusChangedEventArgs args)
		{
		}

		private void JoystickDisconnected(ControllerStatusChangedEventArgs args)
		{
		}

		private void OnConflictFound(InputMapper.ConflictFoundEventData data)
		{
		}

		private void OnStopped(InputMapper.StoppedEventData data)
		{
		}

		public void IdentifyAllJoysticks()
		{
		}

		protected void CheckRecompile()
		{
		}

		private void RecompileWindow(int windowId)
		{
		}
	}
}
