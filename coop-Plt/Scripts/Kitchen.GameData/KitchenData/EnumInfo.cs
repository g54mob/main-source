using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenData
{
	public class EnumInfo<T> : Localisation where T : Enum
	{
		public Dictionary<T, string> Name;

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			foreach (KeyValuePair<T, string> item in Name)
			{
				context.Add(item.Key.ToString(), item.Value);
			}
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Name = new Dictionary<T, string>();
			foreach (T item in Enum.GetValues(typeof(T)).Cast<T>())
			{
				Name[item] = context.Get(item.ToString());
			}
		}
	}
}
