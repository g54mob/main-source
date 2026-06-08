using UnityEngine;

namespace KitchenData
{
	public class ResearchLocalisation : Localisation
	{
		public string Name;

		[TextArea(7, 10)]
		public string FlavourText;

		[TextArea(7, 10)]
		public string Description;

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			context.Add("NAME", Name);
			context.Add("DESCRIPTION", Description);
			context.Add("FLAVOUR", FlavourText);
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Name = context.Get("NAME");
			Description = context.Get("DESCRIPTION");
			FlavourText = context.Get("FLAVOUR");
		}
	}
}
