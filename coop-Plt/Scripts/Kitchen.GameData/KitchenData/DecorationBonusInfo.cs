using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenData
{
	public class DecorationBonusInfo : Localisation
	{
		public Dictionary<DecorationType, string> Icons;

		public Dictionary<DecorationBonus, string> Text;

		public void CopyKeys(DecorationBonusInfo other, bool confirm = false)
		{
			Icons = new Dictionary<DecorationType, string>();
			Text = new Dictionary<DecorationBonus, string>();
			foreach (KeyValuePair<DecorationType, string> icon in other.Icons)
			{
				Icons[icon.Key] = "XXX";
			}
			foreach (KeyValuePair<DecorationBonus, string> item in other.Text)
			{
				Text[item.Key] = "XXX";
			}
		}

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			foreach (KeyValuePair<DecorationType, string> icon in Icons)
			{
				context.Add(icon.Key.ToString(), icon.Value);
			}
			foreach (KeyValuePair<DecorationBonus, string> item in Text)
			{
				context.Add(item.Key.ToString(), item.Value);
			}
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Icons = new Dictionary<DecorationType, string>();
			Text = new Dictionary<DecorationBonus, string>();
			foreach (DecorationType item in Enum.GetValues(typeof(DecorationType)).Cast<DecorationType>())
			{
				Icons[item] = context.Get(item.ToString());
			}
			foreach (DecorationBonus item2 in Enum.GetValues(typeof(DecorationBonus)).Cast<DecorationBonus>())
			{
				Text[item2] = context.Get(item2.ToString());
			}
		}
	}
}
