using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class FoodDrinkWaiterBehaviour : PatronBehaviour
	{
		[PersistenceOptIn]
		private bool _hadDrink;

		[PersistenceOptIn]
		private bool _hadMeal;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Actor_ConsumeItem(object sender, Actor.ActorEventArgs<Ingredient> e)
		{
		}

		protected void OnConsumeItem(Ingredient item)
		{
		}

		protected FoodDrinkWaiterBehaviour()
		{
		}

		public FoodDrinkWaiterBehaviour(Patron owner)
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
