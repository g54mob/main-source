namespace CTS.BBT.AI
{
	public class ActionHubGroupOrder : AgentHubAction
	{
		private readonly GroupOrder _groupOrder;

		private AgentActionTakeOrder _lastAction;

		internal ActionHubGroupOrder(GroupOrder groupOrder)
		{
			_groupOrder = groupOrder;
		}

		public override string GetDisplayName()
		{
			return ContextualActionDisplayNames.GetAction(EActionName.DrinkCommand);
		}

		protected override void OnStopped()
		{
			if ((bool)base.ActionAgent && (base.CurrentAction == null || base.CurrentAction.Stopped))
			{
				AgentActionTakeOrder.ResetAnimation(base.ActionAgent);
			}
		}

		protected override bool TryFindBestAction(Agent agent, out AgentAction outAction)
		{
			_ = agent.transform.position;
			foreach (CustomerOrder order in _groupOrder.Orders)
			{
				if (CanOrderBePerformed(order))
				{
					outAction = CreateAction(order.CustomerRef);
					return true;
				}
			}
			outAction = null;
			return false;
			AgentActionTakeOrder CreateAction(Customer customer)
			{
				_lastAction = new AgentActionTakeOrder(customer);
				return _lastAction;
			}
		}

		protected override bool CanAnyActionBePerformed(Agent agent)
		{
			if (agent.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			foreach (CustomerOrder order in _groupOrder.Orders)
			{
				if (CanOrderBePerformed(order))
				{
					return true;
				}
			}
			return false;
		}

		internal bool CanOrderBePerformed(CustomerOrder customerOrder)
		{
			if (!customerOrder.CustomerRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (!customerOrder.CustomerRef.AtTable)
			{
				return false;
			}
			if (customerOrder.CustomerRef.Business.IsLocked)
			{
				return false;
			}
			return customerOrder.Status <= CustomerOrder.EStatus.WaitingToOrder;
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			return !_groupOrder.IsOrderWaiting();
		}
	}
}
