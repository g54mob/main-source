using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Gh.Tk;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Gh
{
	public class InputController : SingletonMonoBehaviour<InputController>
	{
		[Serializable]
		public class CameraInteractionConfig
		{
			public List<Camera> cameras;

			public LayerMask layerMask;
		}

		public struct InteractableHitData
		{
			public Tooltip3DUIView tooltip3D;

			public IInteractableUI hoveredItem;

			public ITooltipProvider tooltipProvider;
		}

		public class MouseClickEventArgs : CancelEventArgs
		{
			public RaycastHit? raycastHit;

			public IInteractableUI currentInteractable;
		}

		public bool DisableUnityEditorInput;

		private const string PLAYMODE_EDITOR_INPUT_SCHEME = "PlayMode";

		private string _previousEditorInputScheme;

		public PlayerInputActions InputActions;

		public List<CameraInteractionConfig> cameraInteractionOrder;

		public static List<Func<bool>> CanExecuteLongClickFunctions;

		private bool _isMousePositionSet;

		public const float INPUT_DELTA_TIME = 1f / 60f;

		private float _lastInputUpdateTime;

		private static float _longClickStartTime;

		private Vector3 _buttonDownPosition;

		private RaycastHit? _current3DHit;

		private IInteractableUI _currentHoveredItem;

		public const float FALLBACK_TOOLTIP_LOCK_IN_TIME = 1f;

		public const float FALLBACK_TOOLTIP_SHOW_DELAY = 0.3f;

		public const float FALLBACK_TOOLTIP_HIDE_DELAY = 0.22f;

		private Dictionary<int, (float maxDelayTime, float timeRemaining)> _tooltipDelaySeconds;

		private float _unhoverTooltipHideDelay;

		private Dictionary<INestedTooltipProvider, Tooltip3DUIView> _nestedTooltips;

		private InputMode _currentMode;

		public static EventHandler<EventArgs<InputMode>> CurrentModeChanged;

		private InputActionRebindingExtensions.RebindingOperation _currentRebindOperation;

		[Header("Debug")]
		public Camera lastCameraHit;

		public Collider lastHit;

		public static Dictionary<string, string> ControlNames { get; }

		public static Vector2 MousePosition { get; private set; }

		public static Vector2 MousePositionClamped { get; private set; }

		public static Vector2 MousePositionDelta { get; private set; }

		public static Vector2 MousePositionDeltaNormalised { get; private set; }

		public static Vector2 PreviousMousePosition { get; private set; }

		public QuickRotateScaleController QuickRotateScaleController { get; private set; }

		public static bool IsReady { get; protected set; }

		public static bool IsDragScrolling { get; set; }

		public static bool IsScrollingWheel => false;

		public static bool DidMouseClickStartOnUI { get; private set; }

		public static bool WasLeftButtonPressedThisFrame { get; private set; }

		public static bool IsLeftButtonPressed { get; private set; }

		public static bool WasLeftButtonReleasedThisFrame { get; private set; }

		public static bool WasLongLeftClickTriggeredThisFrame { get; private set; }

		public static float DoubleClickTime { get; set; }

		public static float LongClickTime { get; set; }

		public static float LongClickMoveThreshold { get; set; }

		public static bool WasRightButtonPressedThisFrame { get; private set; }

		public static bool IsRightButtonPressed { get; private set; }

		public static bool WasRightButtonReleasedThisFrame { get; private set; }

		public static Vector2 LastMousePositionWhenRightButtonWasPressed { get; private set; }

		public static bool IsInputConsumptionFrame { get; private set; }

		public static bool IsLongClickInProgress => false;

		public static bool IsLongClickThresholdBroken => false;

		public GameObject CurrentUGUIHitObj { get; private set; }

		public InteractableHitData CurrentHitData { get; private set; }

		public IInteractableUI CurrentClickedItem { get; private set; }

		public ITooltipProvider CurrentTooltipProvider { get; private set; }

		public ITooltipProvider ClosedTooltipProvider { get; private set; }

		public float DefaultTooltipDelay => 0f;

		public InputMode CurrentMode
		{
			get
			{
				return default(InputMode);
			}
			private set
			{
			}
		}

		public static event EventHandler LeftMousePressed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LeftMouseClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LongLeftMouseClickStarted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LongLeftMouseClickCancelled
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler LongLeftMouseClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler RightMousePressed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler RightMouseClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler InputControllerReady
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<MouseClickEventArgs> LeftMouseUpEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<MouseClickEventArgs> RightMouseUpEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Awake()
		{
		}

		public void CancelPrimaryClick()
		{
		}

		public void CancelSecondaryClick()
		{
		}

		private void OnDestroy()
		{
		}

		public static bool IsMouseInScreenBounds()
		{
			return false;
		}

		public void OverrideClosedTooltipProvider(ITooltipProvider tooltipProvider)
		{
		}

		public void OverrideCurrentPressedItem(IInteractableUI interactable)
		{
		}

		public void OnZoomingChanged()
		{
		}

		private void LateUpdate()
		{
		}

		protected void Update()
		{
		}

		public static void CancelLongClick()
		{
		}

		private void UpdateLongClick()
		{
		}

		private void UpdateDevInput()
		{
		}

		private bool IsMouseInteractionDisabled()
		{
			return false;
		}

		public void UpdateInteractableMouseInput()
		{
		}

		private void ProcessHit(GameObject hitObj)
		{
		}

		private void UpdateHovering(InteractableHitData input)
		{
		}

		private void UpdateMouseClick(InteractableHitData input)
		{
		}

		public void ResetTooltipDelays()
		{
		}

		private int GetTooltipDelayId(ITooltipProvider provider)
		{
			return 0;
		}

		private void UpdateTooltipDelay(InteractableHitData input)
		{
		}

		public void ForceShowTooltip(ITooltipProvider provider)
		{
		}

		public void SkipTooltipDelay(ITooltipProvider provider)
		{
		}

		private bool IsDelayFinished(ITooltipProvider tooltipProvider)
		{
			return false;
		}

		private void UpdateTooltips(InteractableHitData input)
		{
		}

		private void ShowTooltip(ITooltipProvider tooltipProvider)
		{
		}

		private void ResetHoverDelay()
		{
		}

		private void UpdateHideDelay()
		{
		}

		public void HideTooltips()
		{
		}

		public void HideNestedTooltips()
		{
		}

		private void HideTooltip(Tooltip3DUIView tooltip)
		{
		}

		public bool IsObjectHovered(GameObject obj, IEnumerable<GameObject> ignoreObjects = null)
		{
			return false;
		}

		public void SwitchTo(InputMode mode)
		{
		}

		private void SetDefaultInput()
		{
		}

		public ReadOnlyArray<InputActionMap> GetActionMaps()
		{
			return default(ReadOnlyArray<InputActionMap>);
		}

		public void RemapButtonClicked(InputAction actionToRebind, int targetBinding, Action<InputActionRebindingExtensions.RebindingOperation> onComplete, Action<InputActionRebindingExtensions.RebindingOperation> onCancel)
		{
		}

		public bool HasConflicts(InputAction inputAction, int bindingIndex, out string conflictInfo)
		{
			conflictInfo = null;
			return false;
		}

		public void ResetBinding(InputAction actionToRebind, int targetBinding)
		{
		}

		public void ResetAllBindings()
		{
		}

		public void DeleteBinding(InputAction actionToRebind, int targetBinding)
		{
		}

		private void StopBindingOperation()
		{
		}

		private void SaveInputBindingOverrides()
		{
		}

		private void LoadInputBindingOverrides()
		{
		}

		public static bool IsControlButtonPressed()
		{
			return false;
		}

		public static bool IsShiftButtonPressed()
		{
			return false;
		}

		public static bool IsAltButtonPressedThisFrame()
		{
			return false;
		}

		public static bool IsAltButtonPressed()
		{
			return false;
		}

		public static bool IsAltButtonReleasedThisFrame()
		{
			return false;
		}

		public static bool IsTooltipQuickKeyPressedThisFrame()
		{
			return false;
		}

		public static bool IsTooltipQuickKeyPressed()
		{
			return false;
		}

		public static bool IsTooltipQuickKeyReleasedThisFrame()
		{
			return false;
		}

		public static bool IsZoningConfirmButtonPressedThisFrame()
		{
			return false;
		}

		public static bool IsValidAnyButtonPressedThisFrame()
		{
			return false;
		}

		public void SetMousePosition(Vector2 pos)
		{
		}

		public static bool IsMouseHoveringInterectable()
		{
			return false;
		}
	}
}
