using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance
{
	[DebuggerDisplay("{ToString(),raw}")]
	public sealed class Box<T> where T : struct
	{
		private Box()
		{
			throw new InvalidOperationException("The CommunityToolkit.HighPerformance.Box<T> constructor should never be used.");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Box<T> GetFrom(object obj)
		{
			if (obj.GetType() != typeof(T))
			{
				ThrowInvalidCastExceptionForGetFrom();
			}
			return Unsafe.As<Box<T>>(obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Box<T> DangerousGetFrom(object obj)
		{
			return Unsafe.As<Box<T>>(obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFrom(object obj, [NotNullWhen(true)] out Box<T>? box)
		{
			if (obj.GetType() == typeof(T))
			{
				box = Unsafe.As<Box<T>>(obj);
				return true;
			}
			box = null;
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator T(Box<T> box)
		{
			return (T)box;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Box<T>(T value)
		{
			return Unsafe.As<Box<T>>(value);
		}

		public override string ToString()
		{
			return this.GetReference().ToString();
		}

		public override bool Equals(object? obj)
		{
			return object.Equals(this, obj);
		}

		public override int GetHashCode()
		{
			return this.GetReference().GetHashCode();
		}

		private static void ThrowInvalidCastExceptionForGetFrom()
		{
			throw new InvalidCastException($"Can't cast the input object to the type Box<{typeof(T)}>");
		}
	}
}
