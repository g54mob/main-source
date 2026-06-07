using UnityEngine;

namespace Simulator.GameWorld
{
	public class CashRegister : GroundFurniture
	{
		[Header("Workshop")]
		[SerializeField]
		private CashRegisterWorkshop m_workshop;

		[Header("Stands")]
		[SerializeField]
		private CheckoutStand m_checkoutStand;

		public CashRegisterWorkshop Workshop => m_workshop;

		public CheckoutStand CheckoutStand => m_checkoutStand;

		public override void Load(int phase, SaveClass_Furnitures.FurnitureState state)
		{
			base.Load(phase, state);
			if (state is SaveClass_Furnitures.CashRegisterState state2)
			{
				m_workshop.Load(phase, state2);
			}
		}

		public override SaveClass_Furnitures.FurnitureState Save()
		{
			return new SaveClass_Furnitures.CashRegisterState(this);
		}

		public override bool CanBeMoved()
		{
			return !CheckoutStand.HasClientCheckingOut;
		}

		public override void OnStartMoveBy(FurnitureMover mover)
		{
			base.OnStartMoveBy(mover);
			m_checkoutStand.SetActive(active: false);
		}

		protected override void OnStopMove()
		{
			base.OnStopMove();
			m_checkoutStand.SetActive(active: true);
		}
	}
}
