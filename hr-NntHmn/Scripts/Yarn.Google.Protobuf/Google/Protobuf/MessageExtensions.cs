using System;
using System.Buffers;
using System.IO;

namespace Google.Protobuf
{
	public static class MessageExtensions
	{
		public static void MergeFrom(this IMessage message, byte[] data)
		{
		}

		public static void MergeFrom(this IMessage message, byte[] data, int offset, int length)
		{
		}

		public static void MergeFrom(this IMessage message, ByteString data)
		{
		}

		public static void MergeFrom(this IMessage message, Stream input)
		{
		}

		public static void MergeFrom(this IMessage message, ReadOnlySpan<byte> span)
		{
		}

		public static void MergeFrom(this IMessage message, ReadOnlySequence<byte> sequence)
		{
		}

		public static void MergeDelimitedFrom(this IMessage message, Stream input)
		{
		}

		public static byte[] ToByteArray(this IMessage message)
		{
			return null;
		}

		public static void WriteTo(this IMessage message, Stream output)
		{
		}

		public static void WriteDelimitedTo(this IMessage message, Stream output)
		{
		}

		public static ByteString ToByteString(this IMessage message)
		{
			return null;
		}

		public static void WriteTo(this IMessage message, IBufferWriter<byte> output)
		{
		}

		public static void WriteTo(this IMessage message, Span<byte> output)
		{
		}

		public static bool IsInitialized(this IMessage message)
		{
			return false;
		}

		internal static void MergeFrom(this IMessage message, byte[] data, bool discardUnknownFields, ExtensionRegistry registry)
		{
		}

		internal static void MergeFrom(this IMessage message, byte[] data, int offset, int length, bool discardUnknownFields, ExtensionRegistry registry)
		{
		}

		internal static void MergeFrom(this IMessage message, ByteString data, bool discardUnknownFields, ExtensionRegistry registry)
		{
		}

		internal static void MergeFrom(this IMessage message, Stream input, bool discardUnknownFields, ExtensionRegistry registry)
		{
		}

		internal static void MergeFrom(this IMessage message, ReadOnlySequence<byte> data, bool discardUnknownFields, ExtensionRegistry registry)
		{
		}

		internal static void MergeFrom(this IMessage message, ReadOnlySpan<byte> data, bool discardUnknownFields, ExtensionRegistry registry)
		{
		}

		internal static void MergeDelimitedFrom(this IMessage message, Stream input, bool discardUnknownFields, ExtensionRegistry registry)
		{
		}
	}
}
