using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace __Project__.Scripts.ControllerInputModule
{
	public class GamepadUISelectable : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[HideInInspector]
		public Selectable selectable;

		public GamePadUIPanel parentPanel;

		[SerializeField]
		private bool m_willDisableInteractionOnGamepad;

		[SerializeField]
		private bool m_isSelectableNative;

		[SerializeField]
		private bool m_SwitchOverride;

		[SerializeField]
		private bool m_InteractableOverride;

		[SerializeField]
		private bool m_OverrideIsInteractable;

		private List<GamepadSwitch> m_gamepadSwitches;

		private GamepadSelectableParent m_selectableParent;

		private GamepadUIFunctionLibrary m_connectedLibrary;

		private bool m_isInitialized;

		[Header("Actions")]
		public UnityEvent leftJoystickActionDec;

		public UnityEvent leftJoystickActionInc;

		public UnityEvent dPadDec;

		public UnityEvent dPadInc;

		public UnityEvent rightJoystickActionDec;

		public UnityEvent rightJoystickActionInc;

		public UnityEvent backAction;

		public bool isConfirmGoingInside;

		public UnityEvent submitAction;

		public bool isRightJoystickGoingInside;

		public UnityEvent rightJoystickClickAction;

		public bool isNorthGoingInside;

		public UnityEvent northAction;

		public bool isWestGoingInside;

		public UnityEvent westAction;

		public bool isLeftTriggerGoingInside;

		public UnityEvent leftTriggerAction;

		public bool isRightTriggerGoingInside;

		public UnityEvent rightTriggerAction;

		public bool IsInObject
		{
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void Initialize()
		{
		}

		private void OnControllerSwitch(bool isConnected)
		{
		}

		public void ForceInteractableSet(bool willInteract)
		{
		}

		public void SetNeighboursGrid(GamepadUISelectable left, GamepadUISelectable right, GamepadUISelectable up, GamepadUISelectable down, GamePadUIPanel parentPanelRef)
		{
		}

		public void SetNeighboursVertical(GamepadUISelectable up, GamepadUISelectable down, GamePadUIPanel parentPanelRef, GamepadUISelectable left = null)
		{
		}

		private void OnDestroy()
		{
		}

		public virtual void OnSelect(BaseEventData eventData)
		{
		}

		public void SwitchHints(bool willOpen)
		{
		}

		public void SetNeighboursHorizontal(GamepadUISelectable left, GamepadUISelectable right, GamePadUIPanel gamePadUIPanel)
		{
		}
	}
}
