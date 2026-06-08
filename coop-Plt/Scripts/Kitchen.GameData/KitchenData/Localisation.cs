namespace KitchenData
{
	public abstract class Localisation : ChildDataObject
	{
		public static Locale CurrentLocale = Locale.English;

		public static Locale FallbackLocale = Locale.English;

		public Locale Locale = Locale.English;

		protected virtual void SetContext(LocalisationContext context)
		{
			context.CurrentLocale = Locale;
		}

		public abstract void Export(LocalisationContext context);

		public abstract void Import(LocalisationContext context);
	}
}
