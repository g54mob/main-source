using System;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public abstract class EnumAttributeBase : Attribute
	{
		public abstract Type EnumType { get; }

		public EnumAttributeBase(string name)
			: base(name)
		{
		}
	}
}
