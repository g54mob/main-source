using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	public class CTSSlider : Slider, ISelectable, ILockable
	{
		[SerializeField]
		private StringKey _idKey;

		[SerializeField]
		private bool _interactableAtStartup = true;

		private ESelectionState _currentState;

		private bool _awake;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		Component ISelectable.Component => this;

		public Transform Transform => base.transform;

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
				if (_currentState == ESelectionState.Pressed)
				{
					this.Pressed?.Invoke();
				}
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

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Application.isPlaying && _idKey.IsValid())
			{
				CTSSelectable.Add(_idKey, this);
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
