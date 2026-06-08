using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	public class DictionaryInfo : Localisation
	{
		public Dictionary<string, string> Text;

		private void Add(DictionaryInfo other)
		{
			foreach (KeyValuePair<string, string> item in other.Text)
			{
				Text[item.Key] = item.Value;
			}
		}

		private void CopyKeys(DictionaryInfo other, string value = "", bool confirm = false)
		{
			Debug.Log(value);
			if (!confirm)
			{
				return;
			}
			foreach (KeyValuePair<string, string> item in other.Text)
			{
				Text[item.Key] = value;
			}
		}

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			foreach (KeyValuePair<string, string> item in Text)
			{
				context.Add(item.Key, item.Value);
			}
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Text = new Dictionary<string, string>();
			context.GetAll(Text);
		}
	}
}
