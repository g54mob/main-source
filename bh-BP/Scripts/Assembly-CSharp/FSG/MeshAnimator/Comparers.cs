using System;
using System.Collections.Generic;

namespace FSG.MeshAnimator
{
	public static class Comparers
	{
		[Serializable]
		public class StringComparer : IEqualityComparer<string>
		{
			bool IEqualityComparer<string>.Equals(string x, string y)
			{
				return false;
			}

			int IEqualityComparer<string>.GetHashCode(string obj)
			{
				return 0;
			}
		}

		[Serializable]
		public class FloatComparer : IEqualityComparer<float>
		{
			bool IEqualityComparer<float>.Equals(float x, float y)
			{
				return false;
			}

			int IEqualityComparer<float>.GetHashCode(float obj)
			{
				return 0;
			}
		}

		[Serializable]
		public class IntComparer : IEqualityComparer<int>
		{
			bool IEqualityComparer<int>.Equals(int x, int y)
			{
				return false;
			}

			int IEqualityComparer<int>.GetHashCode(int obj)
			{
				return 0;
			}
		}

		[Serializable]
		public class ByteComparer : IEqualityComparer<byte>
		{
			bool IEqualityComparer<byte>.Equals(byte x, byte y)
			{
				return false;
			}

			int IEqualityComparer<byte>.GetHashCode(byte obj)
			{
				return 0;
			}
		}

		[Serializable]
		public class BoolComparer : IEqualityComparer<bool>
		{
			bool IEqualityComparer<bool>.Equals(bool x, bool y)
			{
				return false;
			}

			int IEqualityComparer<bool>.GetHashCode(bool obj)
			{
				return 0;
			}
		}

		[Serializable]
		private class FuncEqualityComparer<T> : EqualityComparer<T>
		{
			private readonly Func<T, T, bool> equals;

			private readonly Func<T, int> hash;

			public FuncEqualityComparer(Func<T, T, bool> equals, Func<T, int> hash)
			{
			}

			public override bool Equals(T a, T b)
			{
				return false;
			}

			public override int GetHashCode(T obj)
			{
				return 0;
			}
		}

		public static readonly StringComparer String;

		public static readonly FloatComparer Float;

		public static readonly IntComparer Int;

		public static readonly ByteComparer Byte;

		public static readonly BoolComparer Bool;

		public static IEqualityComparer<T> Create<T>(Func<T, T, bool> equals, Func<T, int> hash = null)
		{
			return null;
		}
	}
}
