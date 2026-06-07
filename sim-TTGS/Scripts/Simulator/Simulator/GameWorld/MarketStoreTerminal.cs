using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class MarketStoreTerminal : Workshop, IUIInputReceiver
	{
		[Header("Market Store Terminal")]
		[SerializeField]
		private Canvas m_canvas;

		[SerializeField]
		private UI_MarketStore m_interface;

		[SerializeField]
		private CursorState m_cursor;

		public event Action OnControlled;

		protected override void OnEnable()
		{
			base.OnEnable();
			EventManager.OnWorldEvent += OnWorldEvents;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			EventManager.OnWorldEvent -= OnWorldEvents;
		}

		private void OnWorldEvents(EWorldEvent worldEvent)
		{
			if (worldEvent == EWorldEvent.INITIALISATION && m_canvas != null)
			{
				m_canvas.worldCamera = TransientManager<CameraManager>.Instance.Camera;
			}
		}

		public override void OnControlledBy(Controller controller)
		{
			base.OnControlledBy(controller);
			CursorManager.SetBaseState(m_cursor);
			TransientManager<InputManager>.Instance.SetMap(InputManager.EMap.UI);
			CanvasManager.SetMainCanvas(m_canvas);
			m_interface.OnControlled();
			m_interface.NavBox.Cancelled += OnCancel;
			this.OnControlled?.Invoke();
			IUIInputReceiver.SetCurrent(this);
		}

		public override void OnUncontrolledBy(Controller controller)
		{
			base.OnUncontrolledBy(controller);
			m_interface.OnUncontrolled();
			m_interface.NavBox.Cancelled -= OnCancel;
			TransientManager<InputManager>.Instance.SetMap(InputManager.EMap.PLAYER);
			IUIInputReceiver.SetCurrent(null);
		}

		protected override void OnQuitWorkshop()
		{
			base.OnQuitWorkshop();
			m_interface.GoToBrowser();
		}

		protected override bool CanQuitWorkshop()
		{
			if (m_interface.CartPageActive)
			{
				m_interface.CloseCart();
				return false;
			}
			return true;
		}

		public void OnUIInput_Navigate(Vector2 direction)
		{
		}

		public void OnUIInput_Point(Vector2 mousePosition)
		{
		}

		public void OnUIInput_Submit()
		{
		}

		public void OnUIInput_Space()
		{
		}

		public void OnUIInput_Memo()
		{
		}

		public void OnUIInput_GamepadNorthButton()
		{
		}

		public void OnUIInput_GamepadWestButton()
		{
		}

		public void OnUIInput_ExitWorkshop()
		{
			QuitWorkshop();
		}
	}
}
