namespace Gh.Tk
{
	public class Plate : GameItemVisual
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Ingredient MainDish;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Ingredient SideDish;
	}
}
