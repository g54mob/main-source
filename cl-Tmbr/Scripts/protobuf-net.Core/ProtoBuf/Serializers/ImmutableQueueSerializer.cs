using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableQueueSerializer<T> : RepeatedSerializer<ImmutableQueue<T>, T>
	{
		[StructLayout(LayoutKind.Auto)]
		private struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private ImmutableQueue<T>.Enumerator _iter;

			T IEnumerator<T>.Current => _iter.Current;

			object IEnumerator.Current => _iter.Current;

			public Enumerator(ImmutableQueue<T> queue)
			{
				_iter = queue.GetEnumerator();
			}

			readonly void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				return _iter.MoveNext();
			}

			readonly void IEnumerator.Reset()
			{
				ThrowHelper.ThrowNotImplementedException("Reset");
			}
		}

		protected override ImmutableQueue<T> Initialize(ImmutableQueue<T> values, ISerializationContext context)
		{
			return values ?? ImmutableQueue<T>.Empty;
		}

		protected override ImmutableQueue<T> AddRange(ImmutableQueue<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				return values.Enqueue(RepeatedSerializer.Singleton(ref newValues));
			}
			Span<T> span = newValues.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				T value = span[i];
				values = values.Enqueue(value);
			}
			return values;
		}

		protected override ImmutableQueue<T> Clear(ImmutableQueue<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(ImmutableQueue<T> values)
		{
			if (values != null && !values.IsEmpty)
			{
				return -1;
			}
			return 0;
		}

		internal override long Measure(ImmutableQueue<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			Enumerator values2 = new Enumerator(values);
			return RepeatedSerializer<ImmutableQueue<T>, T>.Measure(ref values2, serializer, context, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, ImmutableQueue<T> values, ISerializer<T> serializer, SerializerFeatures features)
		{
			Enumerator values2 = new Enumerator(values);
			RepeatedSerializer<ImmutableQueue<T>, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
		}

		internal override void WritePacked(ref ProtoWriter.State state, ImmutableQueue<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			Enumerator values2 = new Enumerator(values);
			RepeatedSerializer<ImmutableQueue<T>, T>.WritePacked(ref state, ref values2, serializer, wireType);
		}
	}
}
