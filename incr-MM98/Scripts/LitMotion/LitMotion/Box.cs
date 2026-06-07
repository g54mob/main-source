using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace LitMotion
{
	internal static class Box
	{
		private static readonly Box<int> BoxMinus1 = new Box<int>(-1);

		private static readonly Box<int> Box0 = new Box<int>(0);

		private static readonly Box<int> Box1 = new Box<int>(1);

		private static readonly Box<int> Box2 = new Box<int>(2);

		private static readonly Box<int> Box3 = new Box<int>(3);

		private static readonly Box<int> Box4 = new Box<int>(4);

		private static readonly Box<int> Box5 = new Box<int>(5);

		private static readonly Box<int> Box6 = new Box<int>(6);

		private static readonly Box<int> Box7 = new Box<int>(7);

		private static readonly Box<int> Box8 = new Box<int>(8);

		private static readonly Box<int> Box9 = new Box<int>(9);

		private static readonly Box<bool> BoxTrue = new Box<bool>(value: true);

		private static readonly Box<bool> BoxFalse = new Box<bool>(value: true);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Box<T> Create<T>(T value) where T : struct
		{
			if (typeof(T) == typeof(int))
			{
				Box<int> from = Create(UnsafeUtility.As<T, int>(ref value));
				return UnsafeUtility.As<Box<int>, Box<T>>(ref from);
			}
			if (typeof(T) == typeof(bool))
			{
				Box<bool> from2 = Create(UnsafeUtility.As<T, bool>(ref value));
				return UnsafeUtility.As<Box<bool>, Box<T>>(ref from2);
			}
			return new Box<T>(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Box<int> Create(int value)
		{
			return value switch
			{
				-1 => BoxMinus1, 
				0 => Box0, 
				1 => Box1, 
				2 => Box2, 
				3 => Box3, 
				4 => Box4, 
				5 => Box5, 
				6 => Box6, 
				7 => Box7, 
				8 => Box8, 
				9 => Box9, 
				_ => new Box<int>(value), 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Box<bool> Create(bool value)
		{
			if (!value)
			{
				return BoxFalse;
			}
			return BoxTrue;
		}
	}
	internal sealed record Box<T> where T : struct
	{
		public T Value { get; }

		internal Box(T value)
		{
			Value = value;
		}
	}
}
