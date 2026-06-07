using System;
using System.Collections.Generic;
using Rewired.Components;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rewired.Integration.UnityUI
{
	public sealed class RewiredStandaloneInputModule : RewiredPointerInputModule
	{
		[Serializable]
		public class PlayerSetting
		{
			public int playerId;

			public List<Rewired.Components.PlayerMouse> playerMice;

			public PlayerSetting()
			{
			}

			private PlayerSetting(PlayerSetting other)
			{
			}

			public PlayerSetting Clone()
			{
				return null;
			}
		}

		private const string DEFAULT_ACTION_MOVE_HORIZONTAL = "UIHorizontal";

		private const string DEFAULT_ACTION_MOVE_VERTICAL = "UIVertical";

		private const string DEFAULT_ACTION_SUBMIT = "UISubmit";

		private const string DEFAULT_ACTION_CANCEL = "UICancel";

		[SerializeField]
		private InputManager_Base rewiredInputManager;

		[SerializeField]
		private bool useAllRewiredGamePlayers;

		[SerializeField]
		private bool useRewiredSystemPlayer;

		[SerializeField]
		private int[] rewiredPlayerIds;

		[SerializeField]
		private bool usePlayingPlayersOnly;

		[SerializeField]
		private List<Rewired.Components.PlayerMouse> playerMice;

		[SerializeField]
		private bool moveOneElementPerAxisPress;

		[SerializeField]
		private bool setActionsById;

		[SerializeField]
		private int horizontalActionId;

		[SerializeField]
		private int verticalActionId;

		[SerializeField]
		private int submitActionId;

		[SerializeField]
		private int cancelActionId;

		[SerializeField]
		private string m_HorizontalAxis;

		[SerializeField]
		private string m_VerticalAxis;

		[SerializeField]
		private string m_SubmitButton;

		[SerializeField]
		private string m_CancelButton;

		[SerializeField]
		private float m_InputActionsPerSecond;

		[SerializeField]
		private float m_RepeatDelay;

		[SerializeField]
		private bool m_allowMouseInput;

		[SerializeField]
		private bool m_allowMouseInputIfTouchSupported;

		[SerializeField]
		private bool m_allowTouchInput;

		[SerializeField]
		private bool m_deselectIfBackgroundClicked;

		[SerializeField]
		private bool m_deselectBeforeSelecting;

		[SerializeField]
		private bool m_ForceModuleActive;

		[NonSerialized]
		private int[] playerIds;

		private bool recompiling;

		[NonSerialized]
		private bool isTouchSupported;

		[NonSerialized]
		private double m_PrevActionTime;

		[NonSerialized]
		private Vector2 m_LastMoveVector;

		[NonSerialized]
		private int m_ConsecutiveMoveCount;

		[NonSerialized]
		private bool m_HasFocus;

		public InputManager_Base RewiredInputManager
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseAllRewiredGamePlayers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseRewiredSystemPlayer
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int[] RewiredPlayerIds
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UsePlayingPlayersOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<Rewired.Components.PlayerMouse> PlayerMice
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool MoveOneElementPerAxisPress
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool allowMouseInput
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool allowMouseInputIfTouchSupported
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool allowTouchInput
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool deselectIfBackgroundClicked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool deselectBeforeSelecting
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SetActionsById
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int HorizontalActionId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int VerticalActionId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SubmitActionId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int CancelActionId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override bool isMouseSupported => false;

		private bool isTouchAllowed => false;

		[Obsolete]
		public bool allowActivationOnMobileDevice
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool forceModuleActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float inputActionsPerSecond
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float repeatDelay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string horizontalAxis
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string verticalAxis
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string submitButton
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string cancelButton
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private RewiredStandaloneInputModule()
		{
		}

		protected override void Awake()
		{
		}

		public override void UpdateModule()
		{
		}

		public override bool IsModuleSupported()
		{
			return false;
		}

		public override bool ShouldActivateModule()
		{
			return false;
		}

		public override void ActivateModule()
		{
		}

		public override void DeactivateModule()
		{
		}

		public override void Process()
		{
		}

		private bool ProcessTouchEvents()
		{
			return false;
		}

		private void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
		}

		private bool SendSubmitEventToSelectedObject()
		{
			return false;
		}

		private Vector2 GetRawMoveVector()
		{
			return default(Vector2);
		}

		private bool SendMoveEventToSelectedObject()
		{
			return false;
		}

		private void CheckButtonOrKeyMovement(out bool downHorizontal, out bool downVertical)
		{
			downHorizontal = default(bool);
			downVertical = default(bool);
		}

		private void ProcessMouseEvents()
		{
		}

		private void ProcessMouseEvent(int playerId, int pointerIndex)
		{
		}

		private bool SendUpdateEventToSelectedObject()
		{
			return false;
		}

		private void ProcessMousePress(MouseButtonEventData data)
		{
		}

		private void HandleMouseTouchDeselectionOnSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent)
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private bool ShouldIgnoreEventsOnNoFocus()
		{
			return false;
		}

		protected override void OnDestroy()
		{
		}

		protected override bool IsDefaultPlayer(int playerId)
		{
			return false;
		}

		private void InitializeRewired()
		{
		}

		private void SetupRewiredVars()
		{
		}

		private void SetUpRewiredPlayerMice()
		{
		}

		private void SetUpRewiredActions()
		{
		}

		private bool GetButton(Player player, int actionId)
		{
			return false;
		}

		private bool GetButtonDown(Player player, int actionId)
		{
			return false;
		}

		private bool GetNegativeButton(Player player, int actionId)
		{
			return false;
		}

		private bool GetNegativeButtonDown(Player player, int actionId)
		{
			return false;
		}

		private float GetAxis(Player player, int actionId)
		{
			return 0f;
		}

		private void CheckEditorRecompile()
		{
		}

		private void OnEditorRecompile()
		{
		}

		private void ClearRewiredVars()
		{
		}

		private bool DidAnyMouseMove()
		{
			return false;
		}

		private bool GetMouseButtonDownOnAnyMouse(int buttonIndex)
		{
			return false;
		}

		private void OnRewiredInitialized()
		{
		}

		private void OnRewiredShutDown()
		{
		}
	}
}
