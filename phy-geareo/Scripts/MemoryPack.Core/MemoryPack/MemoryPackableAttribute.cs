using System;

namespace MemoryPack
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public sealed class MemoryPackableAttribute : Attribute
	{
		public GenerateType GenerateType { get; }

		public SerializeLayout SerializeLayout { get; }

		public MemoryPackableAttribute(GenerateType generateType = GenerateType.Object)
		{
		}

		public MemoryPackableAttribute(SerializeLayout serializeLayout)
		{
		}

		public MemoryPackableAttribute(GenerateType generateType, SerializeLayout serializeLayout)
		{
		}
	}
}
