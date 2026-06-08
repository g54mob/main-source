using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	public class RecipeInfo : Localisation
	{
		public Dictionary<Dish, string> Text;

		public void CopyKeys(RecipeInfo other, bool confirm = false)
		{
			Text = new Dictionary<Dish, string>();
			foreach (KeyValuePair<Dish, string> item in other.Text)
			{
				Text[item.Key] = "XXX";
			}
		}

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			foreach (KeyValuePair<Dish, string> item in Text)
			{
				context.Add(item.Key.ID.ToString(), item.Value);
			}
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Text = new Dictionary<Dish, string>();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			context.GetAll(dictionary);
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				int num = int.Parse(item.Key);
				if (num == 0)
				{
					Debug.LogWarning("Failed to import a recipe; dish ID was 0");
				}
				try
				{
					Text.Add(context.Constructor.Get<Dish>(num), item.Value);
				}
				catch (KeyNotFoundException)
				{
					Debug.LogWarning($"Dish import failed, no such dish: {num}");
				}
			}
		}
	}
}
