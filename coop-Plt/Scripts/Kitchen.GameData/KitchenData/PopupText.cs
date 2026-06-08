using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenData
{
	public class PopupText : Localisation
	{
		public Dictionary<PopupType, PopupDetails> Text;

		public void CopyKeys(PopupText other, bool confirm = false)
		{
			Text = new Dictionary<PopupType, PopupDetails>();
			foreach (KeyValuePair<PopupType, PopupDetails> item in other.Text)
			{
				Text[item.Key] = new PopupDetails
				{
					Title = "XXX",
					Description = "XXX"
				};
			}
		}

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			foreach (KeyValuePair<PopupType, PopupDetails> item in Text)
			{
				context.Add(item.Key.ToString() + "/TITLE", item.Value.Title);
				context.Add(item.Key.ToString() + "/DESCRIPTION", item.Value.Description);
			}
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Text = new Dictionary<PopupType, PopupDetails>();
			foreach (PopupType item in Enum.GetValues(typeof(PopupType)).Cast<PopupType>())
			{
				Text[item] = new PopupDetails
				{
					Title = context.Get(item.ToString() + "/TITLE"),
					Description = context.Get(item.ToString() + "/DESCRIPTION")
				};
			}
		}
	}
}
