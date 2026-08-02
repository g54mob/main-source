using System;

namespace MemoryPack
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public abstract class MemoryPackCustomFormatterAttribute<T> : Attribute
	{
		public abstract IMemoryPackFormatter<T> GetFormatter();
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public abstract class MemoryPackCustomFormatterAttribute<TFormatter, T> : Attribute where TFormatter : IMemoryPackFormatter<T>
	{
		public abstract TFormatter GetFormatter();
	}
}
