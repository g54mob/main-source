using System;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	[RequireComponent(typeof(HUDPopupModuleSound))]
	public abstract class HUDPopupModule : MonoBehaviour, IActivable
	{
		[SerializeField]
		private GameObject m_container;

		[SerializeField]
		private CursorState m_cursor;

		[SerializeField]
		private NavBox m_navBox;

		[SerializeField]
		private EnabledValue<NavButton> m_closeNavButton;

		[SerializeField]
		private bool m_canCloseWithBack = true;

		public bool IsActive { get; private set; }

		public abstract EHUDPopupModuleType Type { get; }

		public virtual bool HideHUD => false;

		public virtual bool StackInputMap => false;

		protected CursorState Cursor => m_cursor;

		public NavBox NavBox => m_navBox;

		public event Action Closing;

		public event Action Activated;

		public event Action<HUDPopupModule> Validated;

		protected virtual void OnEnable()
		{
			if (TryGetCloseButton(out var closeButton))
			{
				closeButton.onClick.AddListener(OnCloseButtonClicked);
			}
		}

		protected virtual void OnDisable()
		{
			if (TryGetCloseButton(out var closeButton))
			{
				closeButton.onClick.RemoveListener(OnCloseButtonClicked);
			}
		}

		public void SetActive(bool active)
		{
			if (IsActive != active)
			{
				IsActive = active;
				m_container.SetActive(active);
				if (IsActive)
				{
					OnSetActive();
				}
				else
				{
					OnSetInactive();
				}
				if (CameraManager.IsBlending)
				{
					CameraManager.BlendFinished += OnCameraBlendFinished;
				}
				else
				{
					NavBoxSelectFirstChild();
				}
			}
			void OnCameraBlendFinished()
			{
				CameraManager.BlendFinished -= OnCameraBlendFinished;
				NavBoxSelectFirstChild();
			}
		}

		protected virtual void OnSetActive()
		{
			SetCursor();
			this.Activated?.Invoke();
			if ((bool)m_navBox)
			{
				m_navBox.RegisterToDeviceChange(register: true);
				m_navBox.SetActive();
				if (TryGetCloseNavButton(out var _) && m_canCloseWithBack)
				{
					m_navBox.Cancelled += OnCloseButtonClicked;
				}
			}
		}

		protected virtual void OnSetInactive()
		{
			ResetCursor();
			if ((bool)m_navBox)
			{
				m_navBox.SetInactive();
				m_navBox.RegisterToDeviceChange(register: false);
				m_navBox.Cancelled -= OnCloseButtonClicked;
			}
		}

		protected bool TryGetCloseNavButton(out NavButton closeNavButton)
		{
			return m_closeNavButton.IsEnabled(out closeNavButton);
		}

		private bool TryGetCloseButton(out Button closeButton)
		{
			if (!TryGetCloseNavButton(out var closeNavButton))
			{
				closeButton = null;
				return false;
			}
			closeButton = closeNavButton.Button;
			return true;
		}

		protected virtual void OnValidated()
		{
		}

		protected void Validate()
		{
			OnValidated();
			this.Validated?.Invoke(this);
		}

		protected void ShowCloseButton(bool show)
		{
			if (TryGetCloseNavButton(out var closeNavButton))
			{
				closeNavButton.gameObject.SetActive(show);
			}
		}

		protected virtual void OnCloseButtonClicked()
		{
			TriggerClosed();
		}

		protected void TriggerClosed()
		{
			this.Closing?.Invoke();
		}

		public virtual bool OverrideCancel()
		{
			return false;
		}

		public virtual void Cancel()
		{
		}

		protected virtual void SetCursor()
		{
			CursorManager.SetBaseState(m_cursor);
		}

		protected virtual void ResetCursor()
		{
		}

		private void NavBoxSelectFirstChild()
		{
			if (m_navBox != null)
			{
				m_navBox.SelectFirstChild();
			}
		}
	}
}
