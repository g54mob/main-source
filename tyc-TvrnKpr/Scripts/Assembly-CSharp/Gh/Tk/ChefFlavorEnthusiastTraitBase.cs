namespace Gh.Tk
{
	public abstract class ChefFlavorEnthusiastTraitBase : ChefTraitBase
	{
		[PersistenceOptIn]
		protected FlavorProfilePart _part;

		protected ChefFlavorEnthusiastTraitBase()
		{
		}

		public ChefFlavorEnthusiastTraitBase(Staff owner, FlavorProfilePart part)
		{
		}

		public override void ApplyEffectToCraftedIngredient(Ingredient ingredient)
		{
		}
	}
}
