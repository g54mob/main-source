using System;
using System.Collections.Generic;

namespace Jundroo.Common.DataTypes
{
	public struct UnsafePooledString : IDisposable
	{
		private static class StringPool
		{
			private static readonly object _lock = new object();

			private static Dictionary<int, Stack<string>> _pool = new Dictionary<int, Stack<string>>();

			public unsafe static string Get(Span<char> value)
			{
				int length = value.Length;
				string result;
				lock (_lock)
				{
					if (!_pool.TryGetValue(length, out var value2))
					{
						value2 = new Stack<string>();
						_pool.Add(length, value2);
					}
					if (!value2.TryPop(out result))
					{
						return new string(value);
					}
				}
				fixed (char* ptr = result)
				{
					for (int i = 0; i < length; i++)
					{
						ptr[i] = value[i];
					}
				}
				return result;
			}

			public static void Return(string value)
			{
				if (value == null)
				{
					return;
				}
				int length = value.Length;
				lock (_lock)
				{
					if (!_pool.TryGetValue(length, out var value2))
					{
						value2 = new Stack<string>();
						_pool.Add(length, value2);
					}
					value2.Push(value);
				}
			}
		}

		public string Value { get; private set; }

		private UnsafePooledString(string value)
		{
			Value = value;
		}

		public static UnsafePooledString Create(Span<char> value)
		{
			return new UnsafePooledString(StringPool.Get(value));
		}

		public void Dispose()
		{
			StringPool.Return(Value);
			Value = null;
		}
	}
}
