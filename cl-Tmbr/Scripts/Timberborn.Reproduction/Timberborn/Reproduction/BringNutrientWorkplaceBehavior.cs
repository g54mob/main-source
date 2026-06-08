using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.BehaviorSystem;
using Timberborn.Carrying;
using Timberborn.Goods;
using Timberborn.WorkSystem;

namespace Timberborn.Reproduction
{
	internal class BringNutrientWorkplaceBehavior : WorkplaceBehavior, IAwakableComponent
	{
		private BreedingPod _breedingPod;

		public void Awake()
		{
			_breedingPod = GetComponent<BreedingPod>();
		}

		public override Decision Decide(BehaviorAgent agent)
		{
			if (_breedingPod.NeedsNutrients && StartCarrying(agent))
			{
				return Decision.ReleaseNextTick();
			}
			return Decision.ReleaseNow();
		}

		private bool StartCarrying(BehaviorAgent agent)
		{
			CarrierInventoryFinder component = agent.GetComponent<CarrierInventoryFinder>();
			ImmutableArray<GoodAmountSpec>.Enumerator enumerator = _breedingPod.NutrientsPerCycle.GetEnumerator();
			while (enumerator.MoveNext())
			{
				GoodAmountSpec current = enumerator.Current;
				if (component.TryCarryFromAnyInventory(current.Id, _breedingPod.Inventory))
				{
					return true;
				}
			}
			return false;
		}
	}
}
