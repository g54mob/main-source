using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CTS.UI
{
	public class CTSToggle : Toggle, ISelectable, ILockable
	{
		[SerializeField]
		private StringKey _idKey;

		[SerializeField]
		private bool _interactableAtStartup = true;

		[SerializeField]
		private bool _toggleOffOnDisable;

		private ESelectionState _currentState;

		private bool _awake;

		[field: SerializeField]
		public UnityEvent ToggledOn { get; private set; }

		[field: SerializeField]
		public UnityEvent ToggledOff { get; private set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public Transform Transform => base.transform;

		Component ISelectable.Component => this;

		public ESelectionState CurrentState
		{
			get
			{
				if (!_awake)
				{
					return (ESelectionState)base.currentSelectionState;
				}
				return _currentState;
			}
			private set
			{
				_currentState = value;
			}
		}

		public event Action<ESelectionState> SelectionStateChanged;

		public event Action Pressed;

		protected override void Awake()
		{
			base.Awake();
			if (Application.isPlaying)
			{
				_awake = true;
				CurrentState = (ESelectionState)base.currentSelectionState;
				base.interactable = !ObjectLock.IsLocked() && _interactableAtStartup;
			}
		}

		protected override void Start()
		{
			base.Start();
			if (Application.isPlaying && base.isOn)
			{
				OnValueChanged(value: true);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Application.isPlaying)
			{
				if (_idKey.IsValid())
				{
					CTSSelectable.Add(_idKey, this);
				}
				onValueChanged.AddListener(OnValueChanged);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (Application.isPlaying && _idKey.IsValid())
			{
				CTSSelectable.Remove(_idKey);
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				SendPressEvent();
			}
			base.OnPointerClick(eventData);
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			SendPressEvent();
			base.OnSubmit(eventData);
		}

		private void SendPressEvent()
		{
			if (IsActive() && IsInteractable())
			{
				this.Pressed?.Invoke();
			}
		}

		private void OnValueChanged(bool value)
		{
			if (value)
			{
				ToggledOn.Invoke();
			}
			else
			{
				ToggledOff.Invoke();
			}
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			base.DoStateTransition(state, instant);
			SetCurrentState((ESelectionState)state);
		}

		protected override void InstantClearState()
		{
			base.InstantClearState();
			SetCurrentState(ESelectionState.Disabled);
		}

		private void SetCurrentState(ESelectionState state)
		{
			if (CurrentState == state)
			{
				return;
			}
			CurrentState = state;
			if (CurrentState == ESelectionState.Disabled && _toggleOffOnDisable)
			{
				base.isOn = false;
			}
			try
			{
				this.SelectionStateChanged?.Invoke(CurrentState);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		void ILockable.OnLocked()
		{
			base.interactable = false;
		}

		void ILockable.OnUnlocked()
		{
			base.interactable = _interactableAtStartup;
		}
	}
}
