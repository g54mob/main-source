using System;
using Jundroo.Juicy.Helpers;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class BoolAttribute<T> : Attribute where T : class
	{
		public bool Default { get; set; }

		public override string SchemaType => "boolean";

		public Action<T, bool> Setter { get; set; }

		public BoolAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			bool arg = StringParser.ToBool(s, Default);
			Setter(w as T, arg);
		}
	}
}
