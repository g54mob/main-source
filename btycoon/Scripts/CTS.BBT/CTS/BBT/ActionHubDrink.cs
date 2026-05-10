using CTS.BBT.AI;
using CTS.Core.Pooling;

namespace CTS.BBT
{
	public class ActionHubDrink : AgentHubAction
	{
		private PooledRef<Drink> _drink;

		private AgentActionPickUpItem _pickUpAction;

		public Drink Drink
		{
			get
			{
				if (!_drink.TryGetValue(out var outValue))
				{
					return null;
				}
				return outValue;
			}
			set
			{
				_drink = new PooledRef<Drink>(value);
			}
		}

		public void SetDrink(Drink drink)
		{
			if (!(drink == _drink))
			{
				Drink = drink;
				_pickUpAction.Item = new PooledRef<Item>(Drink);
			}
		}

		internal ActionHubDrink()
		{
			_pickUpAction = new AgentActionPickUpItem(null);
			AddScoredAction(_pickUpAction, CalculatePickUpDrinkScore);
			AddScoredAction(new AgentActionDrink(), CalculateDrinkScore);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			Drink drink = Drink;
			if ((bool)drink && !drink.IsEmpty)
			{
				return drink.OnCooldown;
			}
			return true;
		}

		private int CalculatePickUpDrinkScore(Agent agent)
		{
			if (agent.ObjectHolding.IsHolding(Drink))
			{
				return -1;
			}
			return 100;
		}

		private int CalculateDrinkScore(Agent agent)
		{
			if (agent.ObjectHolding.IsHolding(Drink))
			{
				return 50;
			}
			return -1;
		}
	}
}
