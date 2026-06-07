using System;
using Jundroo.Juicy.Helpers;
using Jundroo.Juicy.Widgets.Extra;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class SoundAttribute<T> : Attribute where T : class
	{
		public override string SchemaType => "sound";

		public Action<T, SoundData> Setter { get; set; }

		public SoundAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			SoundData arg = null;
			if (!string.IsNullOrEmpty(s))
			{
				arg = StringParser.ToSoundData(s);
			}
			Setter(w as T, arg);
		}
	}
}
