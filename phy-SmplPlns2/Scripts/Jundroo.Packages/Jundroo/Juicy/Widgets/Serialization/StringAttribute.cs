using System;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class StringAttribute<T> : Attribute where T : class
	{
		public override string SchemaType => "xs:string";

		public Action<T, string> Setter { get; set; }

		public StringAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			Setter(w as T, s);
		}
	}
}
