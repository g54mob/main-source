using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace MalbersAnimations.InputSystem
{
	[AddComponentMenu("Input/MInput Link [New Input System]")]
	[DisallowMultipleComponent]
	public class MInputLink : MonoBehaviour, IInputSource
	{
		public readonly string versionInput = "Link between the New Unity Input System and any component using Unity Events";

		[RequiredField]
		public PlayerInput playerInput;

		[Tooltip("If the Input is disabled, clear the Player Input Reference (Useful for Mounts like the Horse)")]
		public bool clearPlayerInput;

		protected ICharacterMove character;

		public InputActionAsset InputActions;

		[Tooltip("Current Active Map to Activate on Enable\n if there are more Input links on the scene the last Input Link will set its Action Map as Active")]
		[SerializeField]
		internal int ActiveActionMapIndex;

		[HideInInspector]
		[SerializeField]
		private int ShowMapIndex;

		public bool debug;

		public MInputActionMap ActiveMActionMap;

		public List<MInputActionMap> m_MapButtons;

		[SerializeField]
		[HideInInspector]
		private int Editor_Tabs1;

		public bool showInputEvents;

		public IntEvent OnInputEnabled = new IntEvent();

		public IntEvent OnInputDisabled = new IntEvent();

		public StringEvent OnActionMapChanged = new StringEvent();

		public StringEvent CurrentControlScheme = new StringEvent();

		public PlayerInputManager.PlayerJoinedEvent OnControlsChanged = new PlayerInputManager.PlayerJoinedEvent();

		public PlayerInputManager.PlayerJoinedEvent OnDeviceLost = new PlayerInputManager.PlayerJoinedEvent();

		public PlayerInputManager.PlayerJoinedEvent OnDeviceRegained = new PlayerInputManager.PlayerJoinedEvent();

		[Tooltip("All Inputs will be ignored on Time.Scale = 0")]
		public BoolReference IgnoreOnPause = new BoolReference(value: true);

		private InputActionMap PlayerMap;

		public static List<MInputLink> MInputLinks { get; protected set; }

		public Action<Vector3> OnMoveAxis { get; set; } = delegate
		{
		};

		public int ActiveMapIndex => ActiveActionMapIndex - 1;

		public string ActiveMap { get; set; }

		public MInputActionMap DefaultMap { get; protected set; }

		public bool Connected { get; protected set; }

		public Vector3 MoveAxis { get; set; }

		public bool MoveCharacter { get; set; }

		Transform IInputSource.transform => base.transform;

		private void OnUserChange(InputUser user, InputUserChange change, InputDevice device)
		{
			if (user.index == playerInput.playerIndex && change != InputUserChange.DeviceLost && change != InputUserChange.DeviceRegained && change == InputUserChange.ControlsChanged && user.controlScheme.HasValue)
			{
				CurrentControlScheme.Invoke(user.controlScheme.Value.name);
			}
		}

		private void ControlsChanged(PlayerInput input)
		{
			OnControlsChanged.Invoke(input);
		}

		private void DeviceLost(PlayerInput input)
		{
			OnDeviceLost.Invoke(input);
		}

		private void DeviceRegained(PlayerInput input)
		{
			OnDeviceRegained.Invoke(input);
		}

		private void ValidateInputActions()
		{
			if (playerInput == null || InputActions == null)
			{
				return;
			}
			if (m_MapButtons == null || (m_MapButtons.Count == 0 && InputActions != null))
			{
				m_MapButtons = new List<MInputActionMap>();
				for (int i = 0; i < InputActions.actionMaps.Count; i++)
				{
					m_MapButtons.Add(new MInputActionMap(InputActions.actionMaps[i], i));
				}
				MTools.SetDirty(this);
			}
			if (!Application.isPlaying && ActiveMapIndex >= 0 && m_MapButtons.Count < ActiveMapIndex)
			{
				ActiveMActionMap = m_MapButtons[ActiveMapIndex];
			}
		}

		private void Awake()
		{
			character = GetComponent<ICharacterMove>();
			ActiveMActionMap = m_MapButtons[ActiveMapIndex];
			DefaultMap = m_MapButtons[ActiveMapIndex];
		}

		public virtual void Enable(bool val)
		{
			base.enabled = val;
		}

		public virtual void ClearPlayerInput()
		{
			playerInput = null;
		}

		public void PlayerInput(IInputSource player)
		{
			playerInput = player.transform.GetComponent<PlayerInput>();
		}

		private void OnEnable()
		{
			if (MInputLinks == null)
			{
				MInputLinks = new List<MInputLink>();
			}
			MInputLinks.Add(this);
			if (playerInput == null)
			{
				playerInput = this.FindComponent<PlayerInput>();
			}
			if (playerInput == null)
			{
				MInputLink[] componentsInChildren = GetComponentsInChildren<MInputLink>();
				foreach (MInputLink mInputLink in componentsInChildren)
				{
					if (mInputLink.playerInput != null)
					{
						playerInput = mInputLink.playerInput;
						break;
					}
				}
			}
			if (playerInput != null && playerInput.enabled)
			{
				ConnectActionMap();
				InputUser.onChange += OnUserChange;
				if (playerInput != null)
				{
					playerInput.notificationBehavior = PlayerNotifications.InvokeCSharpEvents;
					playerInput.onControlsChanged += ControlsChanged;
					playerInput.onDeviceLost += DeviceLost;
					playerInput.onDeviceRegained += DeviceRegained;
					ControlsChanged(playerInput);
				}
				UpdateActiveMap();
				OnInputEnabled.Invoke(playerInput.playerIndex);
				foreach (MInputActionMap mapButton in m_MapButtons)
				{
					foreach (MInputAction button in mapButton.buttons)
					{
						if (button != null && button.action != null && !(button.reference == null) && button.interaction != MInputInteraction.Vector2 && button.action.expectedControlType == "Vector2")
						{
							Debug.LogWarning("Button <" + button.name + "> has an action control Type of [" + button.action.expectedControlType + "]. 'Vector2' is expected. Please change the Interaction Type to Vector2. Disabling Button");
							button.Active = false;
						}
					}
				}
				MoveAxis = Vector3.zero;
				if (playerInput.user.valid && playerInput.user.controlScheme.HasValue)
				{
					CurrentControlScheme.Invoke(playerInput.user.controlScheme.Value.name);
				}
			}
			else
			{
				Debug.Log("[" + base.name + "]. Player Input not found. MInputLink component disabled.", this);
				base.enabled = false;
			}
		}

		private void OnDisable()
		{
			MInputLinks.Remove(this);
			DisconnectActionMap();
			MoveAxis = Vector3.zero;
			InputUser.onChange -= OnUserChange;
			if (playerInput != null)
			{
				playerInput.onControlsChanged -= ControlsChanged;
				playerInput.onDeviceLost += DeviceLost;
				playerInput.onDeviceRegained += DeviceRegained;
				OnInputDisabled.Invoke(playerInput.playerIndex);
			}
			ActiveMActionMap = null;
			if (clearPlayerInput)
			{
				playerInput = null;
			}
		}

		public virtual void ConnectActionMap()
		{
			if (Connected)
			{
				return;
			}
			UpdateActiveMap();
			foreach (MInputActionMap mapButton in m_MapButtons)
			{
				if (mapButton != null)
				{
					ConnectMove(mapButton);
					ConnectUpDown(mapButton);
					ConnectButtons(mapButton);
				}
			}
			Connected = true;
		}

		private void UpdateActiveMap()
		{
			ActiveMActionMap = m_MapButtons.Find((MInputActionMap x) => x.ActionMap.id == playerInput.currentActionMap.id);
			OnActionMapChanged.Invoke(ActiveMActionMap.ActionMap.name);
		}

		public virtual void SwitchActionMap(string map)
		{
			if (!string.IsNullOrEmpty(map))
			{
				string val = "";
				if (playerInput != null && playerInput.currentActionMap.name != map)
				{
					playerInput.SwitchCurrentActionMap(map);
					PlayerMap = playerInput.currentActionMap;
					playerInput.defaultActionMap = PlayerMap.id.ToString();
					OnActionMapChanged.Invoke(map);
					UpdateActiveMap();
					Debug.Log("Action Map Switched <B>[" + map + "]</B>");
				}
				Debuggin(val);
			}
		}

		public virtual void DisconnectActionMap()
		{
			if (!Connected)
			{
				return;
			}
			foreach (MInputActionMap mapButton in m_MapButtons)
			{
				DisconnectButtons(mapButton);
				DisconnectMove(mapButton);
				DisconnectUpDown(mapButton);
			}
			Connected = false;
		}

		private void ConnectButtons(MInputActionMap map)
		{
			foreach (MInputAction button in map.buttons)
			{
				if (button.reference != null)
				{
					button.action = ResolveForPlayer(button.reference, playerInput.playerIndex);
					ConnectAction(button.action, button);
					button.MCoroutine = this;
				}
			}
		}

		private void DisconnectButtons(MInputActionMap map)
		{
			foreach (MInputAction button in map.buttons)
			{
				if (button.reference != null)
				{
					DisconnectAction(button.action, button);
					button.MCoroutine = null;
					if (button.ResetOnDisable.Value)
					{
						BoolEvent onInputChanged = button.OnInputChanged;
						bool arg = (button.InputValue = false);
						onInputChanged.Invoke(arg);
					}
				}
			}
		}

		public void ConnectInput(string name, UnityAction<bool> action)
		{
			foreach (MInputActionMap mapButton in m_MapButtons)
			{
				mapButton.buttons.Find((MInputAction x) => x.name == name)?.OnInputChanged.AddListener(action);
			}
		}

		public void DisconnectInput(string name, UnityAction<bool> action)
		{
			foreach (MInputActionMap mapButton in m_MapButtons)
			{
				mapButton.buttons.Find((MInputAction x) => x.name == name)?.OnInputChanged.RemoveListener(action);
			}
		}

		public void ConnectAction(InputAction action, MInputAction btn)
		{
			action.started += btn.TranslateInput;
			action.performed += btn.TranslateInput;
			action.canceled += btn.TranslateInput;
		}

		public void DisconnectAction(InputAction action, MInputAction btn)
		{
			action.started -= btn.TranslateInput;
			action.performed -= btn.TranslateInput;
			action.canceled -= btn.TranslateInput;
		}

		private void ConnectMove(MInputActionMap map)
		{
			if (map.Move != null)
			{
				map.MoveAction = ResolveForPlayer(map.Move, playerInput.playerIndex);
				map.MoveAction.performed += OnMove;
				map.MoveAction.canceled += OnMove;
			}
		}

		private void DisconnectMove(MInputActionMap map)
		{
			if (map.Move != null)
			{
				map.MoveAction.performed -= OnMove;
				map.MoveAction.canceled -= OnMove;
			}
			character?.Move(Vector3.zero);
		}

		private void ConnectUpDown(MInputActionMap map)
		{
			if (map.UpDown != null)
			{
				map.UpDownAction = ResolveForPlayer(map.UpDown, playerInput.playerIndex);
				map.UpDownAction.performed += OnUpDown;
				map.UpDownAction.canceled += OnUpDown;
			}
		}

		private void DisconnectUpDown(MInputActionMap map)
		{
			if (map.UpDown != null)
			{
				map.UpDownAction.performed -= OnUpDown;
				map.UpDownAction.canceled -= OnUpDown;
			}
			character?.Move(Vector3.zero);
		}

		protected InputAction ResolveForPlayer(InputActionReference actionRef, int PlayerIndex)
		{
			if (actionRef == null || actionRef.action == null)
			{
				return null;
			}
			InputAction inputAction = actionRef.action;
			if (PlayerIndex != -1)
			{
				PlayerIndex = Math.Clamp(PlayerIndex, 0, InputUser.all.Count - 1);
				inputAction = GetFirstMatch(InputUser.all[PlayerIndex], actionRef);
			}
			if (inputAction != null && inputAction.enabled != actionRef.action.enabled)
			{
				if (actionRef.action.enabled)
				{
					inputAction.Enable();
				}
				else
				{
					inputAction.Disable();
				}
			}
			return inputAction;
			InputAction GetFirstMatch(in InputUser user, InputActionReference aRef)
			{
				foreach (InputAction action in user.actions)
				{
					if (action.id == aRef.action.id)
					{
						return action;
					}
				}
				Debug.LogWarning("Action Reference [" + aRef.action.name + "] Not Found. Make sure the Player is Using the Same Action MAP", this);
				return null;
			}
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			Vector2 vector = context.ReadValue<Vector2>();
			Vector3 moveAxis = MoveAxis;
			moveAxis.x = vector.x * ActiveMActionMap.MoveMult.x;
			moveAxis.z = vector.y * ActiveMActionMap.MoveMult.z;
			MoveAxis = moveAxis;
			character?.SetInputAxis(MoveAxis);
			OnMoveAxis(moveAxis);
		}

		public void OnUpDown(InputAction.CallbackContext context)
		{
			float num = context.ReadValue<float>();
			Vector3 moveAxis = MoveAxis;
			moveAxis.y = ActiveMActionMap.MoveMult.y * num;
			MoveAxis = moveAxis;
			character?.SetInputAxis(moveAxis);
			OnMoveAxis(moveAxis);
		}

		private void Update()
		{
			if (playerInput == null || !playerInput.enabled)
			{
				Debug.Log("Player Input is Null or Disabled. Disabling MInputLink.", this);
				base.enabled = false;
			}
			else if (!IgnoreOnPause || Time.timeScale != 0f)
			{
				if (PlayerMap != playerInput.currentActionMap)
				{
					UpdateActiveMap();
					PlayerMap = playerInput.currentActionMap;
				}
				character?.SetInputAxis(MoveAxis);
			}
		}

		public IInputAction GetInput(string name)
		{
			return DefaultMap.buttons.Find((MInputAction x) => x.Name == name);
		}

		public virtual void EnableInput(string name)
		{
			EnableInput(name, value: true);
		}

		public virtual void DisableInput(string name)
		{
			EnableInput(name, value: false);
		}

		public virtual void EnableInput(string input_name, bool value)
		{
			if (ActiveMActionMap == null)
			{
				return;
			}
			List<MInputAction> list = ActiveMActionMap.buttons.FindAll((MInputAction x) => input_name.Contains(x.Name));
			if (list == null)
			{
				return;
			}
			foreach (MInputAction item in list)
			{
				item.active.Value = value;
			}
		}

		public virtual void SetInput(string input_name, bool value)
		{
			if (ActiveMActionMap == null || ActiveMActionMap.buttons == null)
			{
				return;
			}
			List<MInputAction> list = ActiveMActionMap.buttons.FindAll((MInputAction x) => input_name.Contains(x.Name));
			if (list == null)
			{
				return;
			}
			foreach (MInputAction item in list)
			{
				item.InputValue = value;
			}
		}

		public void ResetInput(string name)
		{
			SetInput(name, value: false);
		}

		internal void ResetButtonMap()
		{
			m_MapButtons = null;
			ActiveActionMapIndex = 0;
		}

		public virtual void PlayerInput_Set(GameObject gameObject)
		{
			playerInput = gameObject.GetComponent<PlayerInput>();
		}

		public virtual void PlayerInput_Set(Component component)
		{
			playerInput = component.GetComponent<PlayerInput>();
		}

		public virtual void PlayerInput_Set(TransformVar var)
		{
			playerInput = var.Value.GetComponent<PlayerInput>();
		}

		public virtual void PlayerInput_Set(GameObjectVar var)
		{
			playerInput = var.Value.GetComponent<PlayerInput>();
		}

		public virtual void PlayerInput_Set(PlayerInput player)
		{
			playerInput = player;
		}

		private void Debuggin(string val)
		{
			if (debug && !string.IsNullOrEmpty(val))
			{
				Debug.Log(val);
			}
		}
	}
}
