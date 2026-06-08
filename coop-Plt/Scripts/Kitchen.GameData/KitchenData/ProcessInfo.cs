namespace KitchenData
{
	public class ProcessInfo : Localisation
	{
		public string Name;

		public string Icon;

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			context.Add("NAME", Name);
			context.Add("ICON", Icon);
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Name = context.Get("NAME");
			Icon = context.Get("ICON");
		}
	}
}
