using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;

namespace MemoryPack
{
	public class MemoryPackSerializationException : Exception
	{
		public MemoryPackSerializationException(string message)
		{
		}

		public MemoryPackSerializationException(string message, Exception innerException)
		{
		}

		[DoesNotReturn]
		public static void ThrowMessage(string message)
		{
		}

		[DoesNotReturn]
		public static void ThrowInvalidPropertyCount(byte expected, byte actual)
		{
		}

		[DoesNotReturn]
		public static void ThrowInvalidPropertyCount(Type type, byte expected, byte actual)
		{
		}

		[DoesNotReturn]
		public static void ThrowInvalidCollection()
		{
		}

		[DoesNotReturn]
		public static void ThrowInvalidRange(int expected, int actual)
		{
		}

		[DoesNotReturn]
		public static void ThrowInvalidAdvance()
		{
		}

		[DoesNotReturn]
		public static void ThrowSequenceReachedEnd()
		{
		}

		[DoesNotReturn]
		public static void ThrowWriteInvalidMemberCount(byte memberCount)
		{
		}

		[DoesNotReturn]
		public static void ThrowInsufficientBufferUnless(int length)
		{
		}

		[DoesNotReturn]
		public static void ThrowNotRegisteredInProvider(Type type)
		{
		}

		[DoesNotReturn]
		public static void ThrowRegisterInProviderFailed(Type type, Exception innerException)
		{
		}

		[DoesNotReturn]
		public static void ThrowNotFoundInUnionType(Type actualType, Type baseType)
		{
		}

		[DoesNotReturn]
		public static void ThrowInvalidTag(ushort tag, Type baseType)
		{
		}

		[DoesNotReturn]
		public static void ThrowReachedDepthLimit(Type type)
		{
		}

		[DoesNotReturn]
		public static void ThrowInvalidConcurrrentCollectionOperation()
		{
		}

		[DoesNotReturn]
		public static void ThrowDeserializeObjectIsNull(string target)
		{
		}

		[DoesNotReturn]
		public static void ThrowFailedEncoding(OperationStatus status)
		{
		}

		[DoesNotReturn]
		public static void ThrowCompressionFailed(OperationStatus status)
		{
		}

		[DoesNotReturn]
		public static void ThrowCompressionFailed()
		{
		}

		[DoesNotReturn]
		public static void ThrowAlreadyDecompressed()
		{
		}

		[DoesNotReturn]
		public static void ThrowDecompressionSizeLimitExceeded(int limit, int size)
		{
		}
	}
}
