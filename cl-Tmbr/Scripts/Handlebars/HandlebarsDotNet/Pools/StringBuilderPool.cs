using System;
using System.Text;

namespace HandlebarsDotNet.Pools
{
	internal class StringBuilderPool : InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>
	{
		public readonly struct StringBuilderPooledObjectPolicy : IInternalObjectPoolPolicy<StringBuilder>
		{
			public readonly int InitialCapacity;

			public readonly int MaximumRetainedCapacity;

			public StringBuilderPooledObjectPolicy(int initialCapacity, int maximumRetainedCapacity = 4096)
			{
				InitialCapacity = initialCapacity;
				MaximumRetainedCapacity = maximumRetainedCapacity;
			}

			public StringBuilder Create()
			{
				return new StringBuilder(InitialCapacity);
			}

			public bool Return(StringBuilder item)
			{
				if (item.Capacity > MaximumRetainedCapacity)
				{
					return false;
				}
				item.Clear();
				return true;
			}
		}

		private static readonly Lazy<StringBuilderPool> Lazy = new Lazy<StringBuilderPool>(() => new StringBuilderPool());

		public static StringBuilderPool Shared => Lazy.Value;

		public StringBuilderPool(int initialCapacity = 16)
			: base(new StringBuilderPooledObjectPolicy(initialCapacity))
		{
		}
	}
}
