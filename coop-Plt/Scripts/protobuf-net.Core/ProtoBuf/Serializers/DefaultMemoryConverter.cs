using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	public sealed class DefaultMemoryConverter<T> : IMemoryConverter<T[], T>, IMemoryConverter<ArraySegment<T>, T>, IMemoryConverter<Memory<T>, T>, IMemoryConverter<ReadOnlyMemory<T>, T>
	{
		public static DefaultMemoryConverter<T> Instance { get; } = new DefaultMemoryConverter<T>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static IMemoryConverter<TStorage, T> GetFor<TStorage>(TypeModel model)
		{
			return (model?.GetSerializerCore<TStorage>(CompatibilityLevel.NotSpecified) as IMemoryConverter<TStorage, T>) ?? (Instance as IMemoryConverter<TStorage, T>) ?? NotSupported<TStorage>();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static IMemoryConverter<TStorage, T> NotSupported<TStorage>()
		{
			ThrowHelper.ThrowInvalidOperationException("No memory-converter is available for storage " + typeof(TStorage).NormalizeName() + " with element-type " + typeof(T).NormalizeName() + ".");
			return null;
		}

		private DefaultMemoryConverter()
		{
		}

		T[] IMemoryConverter<T[], T>.NonNull(in T[] value)
		{
			return value ?? Array.Empty<T>();
		}

		int IMemoryConverter<T[], T>.GetLength(in T[] value)
		{
			if (value != null)
			{
				return value.Length;
			}
			return 0;
		}

		Memory<T> IMemoryConverter<T[], T>.GetMemory(in T[] value)
		{
			return new Memory<T>(value);
		}

		Memory<T> IMemoryConverter<T[], T>.Expand(ISerializationContext context, ref T[] value, int additionalCapacity)
		{
			int num = ((value != null) ? value.Length : 0);
			Array.Resize(ref value, num + additionalCapacity);
			return new Memory<T>(value, num, additionalCapacity);
		}

		ArraySegment<T> IMemoryConverter<ArraySegment<T>, T>.NonNull(in ArraySegment<T> value)
		{
			return value;
		}

		int IMemoryConverter<ArraySegment<T>, T>.GetLength(in ArraySegment<T> value)
		{
			return value.Count;
		}

		Memory<T> IMemoryConverter<ArraySegment<T>, T>.GetMemory(in ArraySegment<T> value)
		{
			return new Memory<T>(value.Array, value.Offset, value.Count);
		}

		Memory<T> IMemoryConverter<ArraySegment<T>, T>.Expand(ISerializationContext context, ref ArraySegment<T> value, int additionalCapacity)
		{
			int count = value.Count;
			T[] array = new T[count + additionalCapacity];
			Array.Copy(value.Array, value.Offset, array, 0, count);
			value = new ArraySegment<T>(array);
			return new Memory<T>(array, count, additionalCapacity);
		}

		Memory<T> IMemoryConverter<Memory<T>, T>.NonNull(in Memory<T> value)
		{
			return value;
		}

		int IMemoryConverter<Memory<T>, T>.GetLength(in Memory<T> value)
		{
			return value.Length;
		}

		Memory<T> IMemoryConverter<Memory<T>, T>.GetMemory(in Memory<T> value)
		{
			return value;
		}

		Memory<T> IMemoryConverter<Memory<T>, T>.Expand(ISerializationContext context, ref Memory<T> value, int additionalCapacity)
		{
			Memory<T> memory = value;
			value = new T[memory.Length + additionalCapacity];
			memory.CopyTo(value);
			return value.Slice(memory.Length);
		}

		ReadOnlyMemory<T> IMemoryConverter<ReadOnlyMemory<T>, T>.NonNull(in ReadOnlyMemory<T> value)
		{
			return value;
		}

		int IMemoryConverter<ReadOnlyMemory<T>, T>.GetLength(in ReadOnlyMemory<T> value)
		{
			return value.Length;
		}

		Memory<T> IMemoryConverter<ReadOnlyMemory<T>, T>.GetMemory(in ReadOnlyMemory<T> value)
		{
			return MemoryMarshal.AsMemory(value);
		}

		Memory<T> IMemoryConverter<ReadOnlyMemory<T>, T>.Expand(ISerializationContext context, ref ReadOnlyMemory<T> value, int additionalCapacity)
		{
			int length = value.Length;
			Memory<T> memory = new T[length + additionalCapacity];
			value.CopyTo(memory);
			value = memory;
			return memory.Slice(length);
		}
	}
}
