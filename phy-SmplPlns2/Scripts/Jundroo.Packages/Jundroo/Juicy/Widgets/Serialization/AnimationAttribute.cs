using System;
using Jundroo.Juicy.Helpers;
using Jundroo.Juicy.Widgets.Extra;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class AnimationAttribute<T> : Attribute where T : class
	{
		public float Default { get; set; }

		public override string SchemaType => "animation";

		public Action<T, AnimationData> Setter { get; set; }

		public AnimationAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			AnimationData arg = StringParser.ToAnimationData(s);
			Setter(w as T, arg);
		}
	}
}
