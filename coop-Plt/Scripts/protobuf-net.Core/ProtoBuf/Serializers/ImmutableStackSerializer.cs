using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableStackSerializer<T> : RepeatedSerializer<ImmutableStack<T>, T>
	{
		[StructLayout(LayoutKind.Auto)]
		private struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			private ImmutableStack<T>.Enumerator _iter;

			T IEnumerator<T>.Current => _iter.Current;

			object IEnumerator.Current => _iter.Current;

			public Enumerator(ImmutableStack<T> stack)
			{
				_iter = stack.GetEnumerator();
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				return _iter.MoveNext();
			}

			void IEnumerator.Reset()
			{
				ThrowHelper.ThrowNotImplementedException("Reset");
			}
		}

		protected override ImmutableStack<T> Initialize(ImmutableStack<T> values, ISerializationContext context)
		{
			return values ?? ImmutableStack<T>.Empty;
		}

		protected override ImmutableStack<T> AddRange(ImmutableStack<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				return values.Push(RepeatedSerializer.Singleton(ref newValues));
			}
			RepeatedSerializer.ReverseInPlace(ref newValues);
			Span<T> span = MemoryExtensions.AsSpan(newValues);
			for (int i = 0; i < span.Length; i++)
			{
				T value = span[i];
				values = values.Push(value);
			}
			return values;
		}

		protected override ImmutableStack<T> Clear(ImmutableStack<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(ImmutableStack<T> values)
		{
			if (values != null && !values.IsEmpty)
			{
				return -1;
			}
			return 0;
		}

		internal override long Measure(ImmutableStack<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			Enumerator values2 = new Enumerator(values);
			return Measure(ref values2, serializer, context, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, ImmutableStack<T> values, ISerializer<T> serializer)
		{
			Enumerator values2 = new Enumerator(values);
			Write(ref state, fieldNumber, category, wireType, ref values2, serializer);
		}

		internal override void WritePacked(ref ProtoWriter.State state, ImmutableStack<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			Enumerator values2 = new Enumerator(values);
			WritePacked(ref state, ref values2, serializer, wireType);
		}
	}
}
