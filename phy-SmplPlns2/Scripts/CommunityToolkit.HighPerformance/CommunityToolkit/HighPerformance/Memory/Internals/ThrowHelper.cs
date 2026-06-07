using System;

namespace CommunityToolkit.HighPerformance.Memory.Internals
{
	internal static class ThrowHelper
	{
		public static void ThrowArgumentExceptionForManagedType()
		{
			throw new ArgumentException("Can't use a void* constructor when T is a managed type.");
		}

		public static void ThrowArgumentExceptionForDestinationTooShort()
		{
			throw new ArgumentException("The target span is too short to copy all the current items to.");
		}

		public static void ThrowArgumentExceptionForDestinationWithNotSameShape()
		{
			throw new ArgumentException("The target span does not have the same shape as the source one.");
		}

		public static void ThrowArrayTypeMismatchException()
		{
			throw new ArrayTypeMismatchException("The given array doesn't match the specified type T.");
		}

		public static void ThrowArgumentExceptionForUnsupportedType()
		{
			throw new ArgumentException("The specified object type is not supported.");
		}

		public static void ThrowIndexOutOfRangeException()
		{
			throw new IndexOutOfRangeException();
		}

		public static void ThrowArgumentException()
		{
			throw new ArgumentException("One or more input parameters were invalid.");
		}

		public static void ThrowArgumentOutOfRangeExceptionForDepth()
		{
			throw new ArgumentOutOfRangeException("depth");
		}

		public static void ThrowArgumentOutOfRangeExceptionForRow()
		{
			throw new ArgumentOutOfRangeException("row");
		}

		public static void ThrowArgumentOutOfRangeExceptionForColumn()
		{
			throw new ArgumentOutOfRangeException("column");
		}

		public static void ThrowArgumentOutOfRangeExceptionForOffset()
		{
			throw new ArgumentOutOfRangeException("offset");
		}

		public static void ThrowArgumentOutOfRangeExceptionForHeight()
		{
			throw new ArgumentOutOfRangeException("height");
		}

		public static void ThrowArgumentOutOfRangeExceptionForWidth()
		{
			throw new ArgumentOutOfRangeException("width");
		}

		public static void ThrowArgumentOutOfRangeExceptionForPitch()
		{
			throw new ArgumentOutOfRangeException("pitch");
		}
	}
}
