using System;

namespace Factory
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	public class SerializableAttribute : Attribute
	{
		public int Version { get; private set; }

		public SerializableAttribute(int version = 1)
		{
			Version = version;
		}
	}
}
