using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(menuName = "BBT/AI/Autonomy/Drink")]
	public class AutonomousActionDrink : AgentAutonomousAction<ActionHubDrink>
	{
		[SerializeField]
		private int _drinkInHandScore = 20;

		[SerializeField]
		private int _drinkNotInHandScore = 20;

		protected override ActionHubDrink CreateActionInstance(Agent agent)
		{
			return new ActionHubDrink();
		}

		protected override int CalculateScore(Agent agent, ActionHubDrink hubAction)
		{
			if (!(agent is Customer customer))
			{
				return -1;
			}
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				return -1;
			}
			if (customer.ObjectHolding.IsHolding<Drink>())
			{
				Drink heldObject = customer.ObjectHolding.GetHeldObject<Drink>();
				hubAction.SetDrink(heldObject);
				if (!heldObject.OnCooldown)
				{
					return _drinkInHandScore;
				}
				return -1;
			}
			CustomerOrder.EStatus? eStatus = customer.CurrentOrder?.Status;
			if (eStatus.HasValue && eStatus == CustomerOrder.EStatus.Delivered && customer.CurrentOrder.PreparedDrink.TryGetValue(out var outValue) && !outValue.IsEmpty)
			{
				hubAction.SetDrink(customer.CurrentOrder.PreparedDrink);
				if (!customer.ObjectHolding.IsHolding((Drink)customer.CurrentOrder.PreparedDrink))
				{
					return _drinkNotInHandScore;
				}
			}
			return -1;
		}
	}
}
