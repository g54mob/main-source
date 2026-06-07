using System;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public abstract class Menu : MonoBehaviour, IActivable, ICancelInputReceiver
	{
		[Header("Menu References")]
		[SerializeField]
		private Canvas m_canvas;

		[SerializeField]
		private GraphicRaycaster m_raycaster;

		[SerializeField]
		private NavBox m_navBox;

		[SerializeField]
		private EnabledValue<Button> m_backButton;

		protected Menus Manager { get; private set; }

		protected NavBox NavBox => m_navBox;

		protected Canvas Canvas => m_canvas;

		protected GraphicRaycaster Raycaster => m_raycaster;

		public bool IsActive { get; private set; }

		public event Action<Menu> WantsBack;

		protected virtual void OnEnable()
		{
			EventManager.OnMenuEvent += OnMenuEvent;
			InputManager.DeviceChanged += OnDeviceChange;
			if (m_backButton.IsEnabled(out var value))
			{
				value.onClick.AddListener(Back);
			}
			if (m_navBox != null)
			{
				m_navBox.Cancelled += OnBoxCancelled;
			}
		}

		protected virtual void OnDisable()
		{
			EventManager.OnMenuEvent -= OnMenuEvent;
			InputManager.DeviceChanged -= OnDeviceChange;
			if (m_backButton.IsEnabled(out var value))
			{
				value.onClick.RemoveListener(Back);
			}
			if (m_navBox != null)
			{
				m_navBox.Cancelled -= OnBoxCancelled;
			}
		}

		protected virtual void OnMenuEvent(EMenuEvent menuEvent)
		{
			if (menuEvent == EMenuEvent.MENU_REGISTRATION)
			{
				Menus.RegisterMenu(this, out var menus);
				Manager = menus;
			}
		}

		protected virtual void OnDeviceChange(EInputDeviceType type)
		{
			if (IsActive)
			{
				m_navBox.OnDeviceChange(type);
			}
		}

		public void SetActive(bool active)
		{
			if (IsActive != active)
			{
				IsActive = active;
				m_canvas.enabled = IsActive;
				m_raycaster.enabled = IsActive;
				if (IsActive)
				{
					OnSetActive();
				}
				else
				{
					OnSetInactive();
				}
			}
		}

		protected virtual void OnSetActive()
		{
			CanvasManager.SetMainCanvas(m_canvas);
			ICancelInputReceiverOnActive();
			if (m_navBox != null)
			{
				m_navBox.SetActive();
			}
		}

		protected virtual void OnSetInactive()
		{
			ICancelInputReceiverOnInactive();
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD || m_navBox != null)
			{
				m_navBox.SetInactive();
			}
		}

		protected virtual void ICancelInputReceiverOnActive()
		{
			ICancelInputReceiver.SetCurrent(this);
		}

		protected virtual void ICancelInputReceiverOnInactive()
		{
			ICancelInputReceiver.SetCurrent(null);
		}

		public virtual void OnCancel()
		{
			Back();
		}

		protected virtual void Back()
		{
			this.WantsBack?.Invoke(this);
		}

		protected virtual void OnBoxCancelled()
		{
			Back();
		}
	}
}
