using UnityEngine;

namespace KitchenData
{
	public class EffectInfo : Localisation
	{
		public string Icon;

		public string Name;

		[TextArea(7, 10)]
		public string Description;

		public void SetIcon(string icon, bool is_good = true)
		{
			string text = (is_good ? "good" : "bad");
			Icon = "<sprite=\"Decoration Sprite\" name=\"" + icon + text + "\">";
		}

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			context.Add("ICON", Icon);
			context.Add("NAME", Name);
			context.Add("DESCRIPTION", Description);
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Icon = context.Get("ICON");
			Name = context.Get("NAME");
			Description = context.Get("DESCRIPTION");
		}
	}
}
