using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.Goap.Goals
{
	public class DrinkGoal : HungerGoal
	{
		protected override DietModel DietModel
		{
			get
			{
				if (base.AgentOwner is IHungerAgent hungerAgent)
				{
					return hungerAgent.CurrentDrinkDietModel;
				}
				return null;
			}
		}

		protected override bool ShouldEatAtTable => true;

		protected override bool FireRoomEffector => false;

		protected override int MaxAmountToTake => 1;

		protected override string EatAtTableEffector => null;

		protected override string EatWithoutTableEffector => null;

		protected override bool IsConsumingAllowed => ((IHungerAgent)base.AgentOwner).IsDrinkAllowed;

		protected override bool UseFoodStorage => false;

		protected override bool CanCreatureConsume(IHungerAgent hungerAgent, ResourcePileInstance resourcePile)
		{
			if (hungerAgent.CurrentDrinkDietModel == null)
			{
				return false;
			}
			if (!CommonGoalMethods.CheckPrisonConditions(hungerAgent as HumanoidInstance, resourcePile.GetRoom()))
			{
				return false;
			}
			return hungerAgent.CanConsume(hungerAgent.CurrentDrinkDietModel, resourcePile);
		}

		protected override bool CanCreatureConsume(IHungerAgent hungerAgent, PlantMapResourceInstance resourcePile)
		{
			if (hungerAgent.CurrentDrinkDietModel == null)
			{
				return false;
			}
			if (!CommonGoalMethods.CheckPrisonConditions(hungerAgent as HumanoidInstance, resourcePile.GetRoom()))
			{
				return false;
			}
			return hungerAgent.CanConsume(hungerAgent.CurrentDrinkDietModel, resourcePile);
		}

		protected override StatInstance GetHungerStat()
		{
			if (!(base.AgentOwner is CreatureBase creatureBase))
			{
				return null;
			}
			return creatureBase.Stats.GetStat(StatType.Alcohol);
		}

		protected override void OnConsumedResource(ResourceInstance resourceInstance)
		{
			MonoSingleton<ResourceCommonController>.Instance.OnDrankResource(resourceInstance, base.Agent);
		}

		public DrinkGoal(Agent selfAgent)
			: base("DrinkGoal", selfAgent, "Drink", "drink_cup_item")
		{
		}
	}
}
