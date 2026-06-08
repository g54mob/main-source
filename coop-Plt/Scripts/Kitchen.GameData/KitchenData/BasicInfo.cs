using UnityEngine;

namespace KitchenData
{
	public class BasicInfo : Localisation
	{
		public string Name;

		[TextArea(7, 10)]
		public string Description;

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			context.Add("NAME", Name);
			context.Add("DESCRIPTION", Description);
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Name = context.Get("NAME");
			Description = context.Get("DESCRIPTION");
		}
	}
}
