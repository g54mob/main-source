using System;
using Jundroo.Juicy.Helpers;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class IntAttribute<T> : Attribute where T : class
	{
		public int Default { get; set; }

		public override string SchemaType => "int";

		public Action<T, int> Setter { get; set; }

		public IntAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			int arg = StringParser.ToInt(s, Default);
			Setter(w as T, arg);
		}
	}
}
