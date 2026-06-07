using System;
using Simulator;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public abstract class UI_CollectionPopup : MonoBehaviour, IActivable, ICancelInputReceiver
	{
		[SerializeField]
		private EnabledValue<NavButton> m_closeButton;

		public bool IsActive { get; private set; }

		public event Action<UI_CollectionPopup, bool> Activated;

		protected virtual void OnEnable()
		{
			if (m_closeButton.IsEnabled(out var value))
			{
				value.Button.onClick.AddListener(OnButtonBack);
			}
		}

		protected virtual void OnDisable()
		{
			if (m_closeButton.IsEnabled(out var value))
			{
				value.Button.onClick.RemoveListener(OnButtonBack);
			}
		}

		private void OnButtonBack()
		{
			SetActive(active: false);
		}

		protected void SelectCloseButton()
		{
			if (m_closeButton.IsEnabled(out var value) && TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
			{
				value.Select();
			}
		}

		public void SetActive(bool active)
		{
			if (IsActive != active)
			{
				IsActive = active;
				if (IsActive)
				{
					OnSetActive();
				}
				else
				{
					OnSetInactive();
				}
				this.Activated?.Invoke(this, active);
			}
		}

		protected virtual void OnSetActive()
		{
			ICancelInputReceiver.Stack(this);
		}

		protected virtual void OnSetInactive()
		{
			ICancelInputReceiver.PopCurrent();
		}

		public abstract bool CanBeClosed();

		public virtual void OnCancel()
		{
			SetActive(active: false);
		}
	}
}
