using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenData
{
	public class TutorialText : Localisation
	{
		public Dictionary<TutorialMessage, TutorialDetails> Text;

		public void CopyKeys(TutorialText other, bool confirm = false)
		{
			Text = new Dictionary<TutorialMessage, TutorialDetails>();
			foreach (KeyValuePair<TutorialMessage, TutorialDetails> item in other.Text)
			{
				Text[item.Key] = new TutorialDetails
				{
					Description = "XXX"
				};
			}
		}

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			foreach (KeyValuePair<TutorialMessage, TutorialDetails> item in Text)
			{
				context.Add(item.Key.ToString(), item.Value.Description);
			}
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Text = new Dictionary<TutorialMessage, TutorialDetails>();
			foreach (TutorialMessage item in Enum.GetValues(typeof(TutorialMessage)).Cast<TutorialMessage>())
			{
				Text[item] = new TutorialDetails
				{
					Description = context.Get(item.ToString())
				};
			}
		}
	}
}
