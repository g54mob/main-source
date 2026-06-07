using System.Collections;
using System.Collections.Generic;
using CTS.Core.Utilities;

namespace CTS.BBT.AI
{
	public class AgentActionDrink : AgentAction<Agent>
	{
		private Drink _drink;

		private List<AnimKey> _possibleAnimations = new List<AnimKey>();

		public AgentActionDrink()
		{
			_possibleAnimations.Add(AgentAnim.Drink);
			_possibleAnimations.Add(AgentAnim.Drink01);
			_possibleAnimations.Add(AgentAnim.Drink02);
			_possibleAnimations.Add(AgentAnim.Drink03);
			_possibleAnimations.Add(AgentAnim.Drink04);
			_possibleAnimations.Add(AgentAnim.Drink06);
		}

		public override bool CanBePerformed(Agent p_agent)
		{
			return p_agent.ObjectHolding.IsHolding(Drink.IsNotEmptyFilter);
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			_drink = base.ActionAgent.ObjectHolding.GetHeldObject<Drink>();
			bool isDrinkFull = _drink.IsFull;
			yield return base.ActionAgent.Animator.PlayPunctual(_possibleAnimations.GetRandom(), 0f);
			base.ActionAgent.ProceduralAnimator.EnableGrab(_drink.ProceduralGrabData[0]);
			float toAdd = _drink.DecrementQuantity();
			base.ActionAgent.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Thirst, toAdd);
			base.ActionAgent.Statistics.TryAddToStatisticUnitInterval(EAgentStatistics.Hunger, toAdd);
			if (isDrinkFull && base.ActionAgent is Customer customer)
			{
				_ = customer.IsVampire;
			}
			if (base.ActionAgent.TryGetComponent<SituationnalBarks_Customer>(out var component))
			{
				component.Getdrink();
			}
		}

		public override void OnComplete()
		{
			base.OnComplete();
			if (_drink.IsEmpty)
			{
				if (base.ActionAgent is Customer customer)
				{
					customer.CurrentDrinks++;
				}
				base.ActionAgent.Statistics.TryAddToStatistic(EAgentStatistics.Alcohol, _drink.DrinkData.AlcoholValue);
			}
		}

		public override void OnCancel()
		{
		}

		protected override void OnStopped()
		{
		}
	}
}
