using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MemoryPack
{
	internal sealed class ErrorMemoryPackFormatter : IMemoryPackFormatter
	{
		private readonly Type type;

		private readonly string? message;

		public ErrorMemoryPackFormatter(Type type)
		{
		}

		public ErrorMemoryPackFormatter(Type type, string message)
		{
		}

		public void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref object? value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		public void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref object? value)
		{
		}

		[DoesNotReturn]
		private void Throw()
		{
		}
	}
	internal sealed class ErrorMemoryPackFormatter<T> : MemoryPackFormatter<T>
	{
		private readonly Exception? exception;

		private readonly string? message;

		public ErrorMemoryPackFormatter()
		{
		}

		public ErrorMemoryPackFormatter(Exception exception)
		{
		}

		public ErrorMemoryPackFormatter(string message)
		{
		}

		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref T? value)
		{
		}

		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref T? value)
		{
		}

		[DoesNotReturn]
		private void Throw()
		{
		}
	}
}
