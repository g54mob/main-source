using System;
using Jundroo.Juicy.Helpers;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class RectOffsetAttribute<T> : Attribute where T : class
	{
		public override string SchemaType => "rectOffset";

		public Action<T, RectOffset> Setter { get; set; }

		public RectOffsetAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			RectOffset arg = StringParser.ToRectOffset(s);
			Setter(w as T, arg);
		}
	}
}
