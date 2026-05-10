using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CTS.UI
{
	public class Highlighter : CTSBehaviour, ISelectable, ILockable, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public Transform Transform => base.transform;

		Component ISelectable.Component => this;

		public ESelectionState CurrentState { get; private set; }

		public event Action<ESelectionState> SelectionStateChanged;

		public event Action Pressed;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			UpdateState();
		}

		private void UpdateState()
		{
			if (RectTransformUtility.RectangleContainsScreenPoint((RectTransform)base.transform, Input.mousePosition))
			{
				OnPointerEnter(null);
			}
			else
			{
				OnPointerExit(null);
			}
		}

		void ILockable.OnLocked()
		{
			CurrentState = ESelectionState.Disabled;
		}

		void ILockable.OnUnlocked()
		{
			UpdateState();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!ObjectLock.IsLocked())
			{
				SetCurrentState(ESelectionState.Highlighted);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (!ObjectLock.IsLocked())
			{
				SetCurrentState(ESelectionState.Normal);
			}
		}

		private void SetCurrentState(ESelectionState state)
		{
			if (CurrentState != state)
			{
				CurrentState = state;
				this.SelectionStateChanged?.Invoke(CurrentState);
			}
		}
	}
}
