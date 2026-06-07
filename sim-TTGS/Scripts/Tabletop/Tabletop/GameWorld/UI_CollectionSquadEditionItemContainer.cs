using Simulator;
using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tabletop.GameWorld
{
	public class UI_CollectionSquadEditionItemContainer : NavBox, IUIInputReceiver
	{
		[SerializeField]
		private UI_CollectionSquadEditionScreen m_editionScreen;

		private bool m_canNavigate = true;

		private UI_CollectionSquadItem m_itemToMove;

		protected override void OnEnable()
		{
			base.OnEnable();
			IUIInputReceiver.SetCurrent(this);
		}

		protected override void OnDisable()
		{
			m_canNavigate = true;
			m_itemToMove = null;
			IUIInputReceiver.SetCurrent(null);
		}

		public void AddItem(UI_CollectionSquadItem item)
		{
			AddChild(item);
			item.EnterGamepadNavigationMode += OnEnterGamepadNavigationMode;
		}

		public void RemoveItem(UI_CollectionSquadItem item)
		{
			RemoveChild(item);
			item.EnterGamepadNavigationMode -= OnEnterGamepadNavigationMode;
		}

		private void OnEnterGamepadNavigationMode(UI_CollectionSquadItem item)
		{
			m_canNavigate = false;
			m_itemToMove = item;
		}

		private void OnExitNavigationMode()
		{
			m_canNavigate = true;
			m_itemToMove = null;
		}

		public override void OnChildMove(AxisEventData eventData)
		{
			if (m_canNavigate)
			{
				base.OnChildMove(eventData);
			}
			else if (!(m_itemToMove == null))
			{
				UI_CollectionSquadMiniatureSlot uI_CollectionSquadMiniatureSlot = eventData.moveDir switch
				{
					MoveDirection.Right => m_editionScreen.GetRightSlot(m_itemToMove.Slot.Index), 
					MoveDirection.Left => m_editionScreen.GetLeftSlot(m_itemToMove.Slot.Index), 
					_ => null, 
				};
				if (!(uI_CollectionSquadMiniatureSlot == null))
				{
					m_itemToMove.OnMoveItem(uI_CollectionSquadMiniatureSlot);
					m_itemToMove.ItemSubmitted += OnExitNavigationMode;
				}
			}
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
			if (base.HasSelection && base.CurrentElement != null && base.CurrentElement.TryGetComponent<UI_CollectionSquadItem>(out var component))
			{
				component.Delete();
			}
		}

		public void OnUIInput_GamepadWestButton()
		{
		}

		public void OnUIInput_ExitWorkshop()
		{
		}
	}
}
