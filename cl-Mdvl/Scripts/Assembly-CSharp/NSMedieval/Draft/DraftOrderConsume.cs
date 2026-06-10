using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Draft
{
	public class DraftOrderConsume : DraftOrder
	{
		private ResourcePileInstance pile;

		private WorkerGoapAgent agent;

		private bool drink;

		public DraftOrderConsume(ResourcePileInstance pile, bool isDrink = false)
			: base(DraftOrderType.ConsumeItem)
		{
			this.pile = pile;
			drink = isDrink;
		}

		public override bool CheckRequirements(HumanoidInstance instance, DraftOrder lastDraftOrder)
		{
			agent = instance.GetGoapAgent() as WorkerGoapAgent;
			return true;
		}

		public override void Execute(HumanoidInstance instance)
		{
			if (agent != null && pile != null && !pile.HasDisposed && pile.GetStoredResource() != null && !(pile.GetStoredResource().Blueprint == null) && (!drink || (pile.GetStoredResource().Blueprint.Category & ResourceCategory.CtgAlcohol) != ResourceCategory.None) && (drink || (pile.GetStoredResource().Blueprint.Category & ResourceCategory.CtgEdible) != ResourceCategory.None))
			{
				instance.ForceEatPile = pile;
				instance.WorkerBehaviour.ShowPathDestinationLine(pile.GetPosition());
				agent.ForceNextGoal(drink ? "DrinkGoal" : "HungerGoal");
			}
		}
	}
}
