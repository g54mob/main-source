using System;
using Jundroo.Juicy.Helpers;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class ColorBlockAttribute<T> : Attribute where T : class
	{
		public override string SchemaType => "xs:string";

		public Action<T, ColorBlock> Setter { get; set; }

		public ColorBlockAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			ColorBlock arg = StringParser.ToColorBlock(s);
			Setter(w as T, arg);
		}
	}
}
