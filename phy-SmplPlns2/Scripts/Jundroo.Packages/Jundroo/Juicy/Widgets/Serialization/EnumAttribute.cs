using System;
using Jundroo.Juicy.Helpers;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class EnumAttribute<T, TEnum> : EnumAttributeBase where T : class where TEnum : Enum
	{
		public bool CombineList { get; internal set; }

		public override Type EnumType => typeof(TEnum);

		public override string SchemaType => EnumType.Name;

		public Action<T, TEnum> Setter { get; set; }

		public EnumAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			if (CombineList)
			{
				string[] array = s.Split(' ', ',');
				if (array.Length > 1)
				{
					int num = Convert.ToInt32(default(TEnum));
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						TEnum val = StringParser.ToEnum<TEnum>(array2[i]);
						num |= Convert.ToInt32(val);
					}
					Setter(w as T, (TEnum)Enum.ToObject(typeof(TEnum), num));
					return;
				}
			}
			Setter(w as T, StringParser.ToEnum<TEnum>(s));
		}
	}
}
