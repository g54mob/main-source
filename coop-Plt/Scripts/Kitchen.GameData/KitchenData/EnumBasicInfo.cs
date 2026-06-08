using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenData
{
	public class EnumBasicInfo<T> : Localisation where T : Enum
	{
		public Dictionary<T, GenericLocalisationStruct> Text;

		public override void Export(LocalisationContext context)
		{
			base.SetContext(context);
			foreach (KeyValuePair<T, GenericLocalisationStruct> item in Text)
			{
				context.Add(item.Key.ToString() + "/NAME", item.Value.Name);
				context.Add(item.Key.ToString() + "/DESCRIPTION", item.Value.Description);
			}
		}

		public override void Import(LocalisationContext context)
		{
			base.SetContext(context);
			Text = new Dictionary<T, GenericLocalisationStruct>();
			foreach (T item in Enum.GetValues(typeof(T)).Cast<T>())
			{
				Text.Add(item, new GenericLocalisationStruct
				{
					Name = context.Get(item.ToString() + "/NAME"),
					Description = context.Get(item.ToString() + "/DESCRIPTION")
				});
			}
		}
	}
}
