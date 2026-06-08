namespace KitchenData
{
	public abstract class LocalisationSet<T> : GameDataObject, ILocalised where T : Localisation
	{
		public int LocalisationID => ID;

		public abstract LocalisationObject<T> LocalisationInfo { get; }

		protected virtual void SetContext(LocalisationContext context)
		{
			context.CurrentSourceID = LocalisationID;
			context.CurrentSourceName = base.name;
		}

		public virtual void Export(LocalisationContext context)
		{
			SetContext(context);
			foreach (Locale locale in context.Locales)
			{
				LocalisationInfo.Get(locale).Export(context);
			}
		}

		public virtual void Import(LocalisationContext context)
		{
			SetContext(context);
		}
	}
}
