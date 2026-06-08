using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Recipe Localisation", menuName = "Kitchen/Localisation/Recipe")]
	public class RecipeLocalisation : LocalisationSet<RecipeInfo>
	{
		[OdinSerialize]
		public LocalisationObject<RecipeInfo> Info;

		[NonSerialized]
		[HideInInspector]
		public Dictionary<Dish, string> Text;

		public string this[Dish i]
		{
			get
			{
				if (Text.TryGetValue(i, out var value))
				{
					return value;
				}
				return "";
			}
		}

		public string this[int i]
		{
			get
			{
				foreach (KeyValuePair<Dish, string> item in Text)
				{
					if (item.Key.ID == i)
					{
						return item.Value;
					}
				}
				return "";
			}
		}

		public override LocalisationObject<RecipeInfo> LocalisationInfo => Info;

		protected override void InitialiseDefaults()
		{
		}

		public bool Has(Dish i)
		{
			return Text.ContainsKey(i);
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			RecipeInfo recipeInfo = Info.Get(locale);
			if (recipeInfo == null)
			{
				return false;
			}
			Text = new Dictionary<Dish, string>();
			foreach (KeyValuePair<Dish, string> item in recipeInfo.Text)
			{
				Text.Add(item.Key, subs.Parse(item.Value));
			}
			return true;
		}
	}
}
