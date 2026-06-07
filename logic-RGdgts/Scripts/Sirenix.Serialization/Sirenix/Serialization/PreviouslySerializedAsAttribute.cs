using System;

namespace Sirenix.Serialization
{
	public class PreviouslySerializedAsAttribute : Attribute
	{
		public string Name { get; private set; }

		public PreviouslySerializedAsAttribute(string name)
		{
		}
	}
}
