using System;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public sealed class fsSerializeAsAttribute : Attribute
	{
		public readonly string Name;

		public fsSerializeAsAttribute()
		{
		}

		public fsSerializeAsAttribute(string name)
		{
		}
	}
}
