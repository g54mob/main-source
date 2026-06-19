using System.Collections.Generic;
using System.Text;

namespace TH20
{
	public class StringBuilderPool
	{
		private const int UnfathomablyLargeBuilderSize = 500;

		private const int HugeBuilderSize = 200;

		private const int BigBuilderSize = 70;

		private const int MaxBuildersToKeep = 10;

		public static StringBuilderPool GlobalStringBuilderPool = new StringBuilderPool();

		private readonly Stack<StringBuilder> _builders = new Stack<StringBuilder>();

		private readonly Stack<StringBuilder> _bigBuilders = new Stack<StringBuilder>();

		private readonly Stack<StringBuilder> _hugeBuilders = new Stack<StringBuilder>();

		public StringBuilder GetBuilder(int expectedLength = 0)
		{
			if (expectedLength > 500)
			{
				return new StringBuilder();
			}
			if (expectedLength > 200)
			{
				if (_hugeBuilders.Count != 0)
				{
					return _hugeBuilders.Pop();
				}
				return new StringBuilder();
			}
			if (expectedLength > 70)
			{
				if (_bigBuilders.Count != 0)
				{
					return _bigBuilders.Pop();
				}
				return new StringBuilder();
			}
			if (_builders.Count != 0)
			{
				return _builders.Pop();
			}
			return new StringBuilder();
		}

		public void ReturnBuilder(StringBuilder builder)
		{
			if (builder.Capacity > 1000)
			{
				return;
			}
			if (builder.Capacity > 400)
			{
				if (_hugeBuilders.Count < 10)
				{
					builder.Length = 0;
					_hugeBuilders.Push(builder);
				}
			}
			else if (builder.Capacity > 140)
			{
				if (_bigBuilders.Count < 10)
				{
					builder.Length = 0;
					_bigBuilders.Push(builder);
				}
			}
			else if (_builders.Count < 10)
			{
				builder.Length = 0;
				_builders.Push(builder);
			}
		}
	}
}
