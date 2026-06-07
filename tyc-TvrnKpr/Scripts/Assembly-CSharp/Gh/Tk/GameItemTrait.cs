using LitJson;

namespace Gh.Tk
{
	public abstract class GameItemTrait : GameObjectXTrait
	{
		[JsonIgnore]
		internal GameItem _gameItem;

		public GameItem GameItem => null;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool CarriesOverInCrafting { get; set; }

		protected GameItemTrait()
		{
		}

		public GameItemTrait(GameObjectX owner)
		{
		}

		public virtual void OnCraftProcess(CraftProcess process, RecipeInput[] inputs, Ingredient output)
		{
		}

		public void OnSpawn()
		{
		}

		public override void OnRemoving()
		{
		}
	}
}
