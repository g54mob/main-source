using System;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public sealed class fsObjectAttribute : Attribute
	{
		public Type Converter;

		public Type Processor;
	}
}
