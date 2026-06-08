namespace KitchenData
{
	public interface ILocalised
	{
		void Export(LocalisationContext context);

		void Import(LocalisationContext context);
	}
}
