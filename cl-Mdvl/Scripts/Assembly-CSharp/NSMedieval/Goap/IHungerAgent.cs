using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.Goap
{
	public interface IHungerAgent : IStorageAgent
	{
		ResourcePileInstance ForceEatPile { get; set; }

		ResourceInstance ForceEatResource { get; set; }

		StatsInstance Stats { get; }

		DietModel CurrentDietModel { get; }

		DietModel CurrentDrinkDietModel { get; }

		bool IsFoodAllowed { get; }

		bool IsDrinkAllowed { get; }

		bool CanConsume(DietModel dietModel, ResourcePileInstance resourcePile);

		bool CanConsume(DietModel dietModel, PlantMapResourceInstance plantMapResource);

		bool CanConsume(DietModel dietModel, ResourceInstance resourceInstance);
	}
}
