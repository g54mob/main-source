using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableArraySerializer<T> : RepeatedSerializer<ImmutableArray<T>, T>
	{
		[StructLayout(LayoutKind.Auto)]
		private struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private ImmutableArray<T>.Enumerator _iter;

			public T Current => _iter.Current;

			object IEnumerator.Current => _iter.Current;

			public readonly void Reset()
			{
				ThrowHelper.ThrowNotSupportedException();
			}

			public Enumerator(ImmutableArray<T> array)
			{
				_iter = array.GetEnumerator();
			}

			public bool MoveNext()
			{
				return _iter.MoveNext();
			}

			public readonly void Dispose()
			{
			}
		}

		protected override ImmutableArray<T> Initialize(ImmutableArray<T> values, ISerializationContext context)
		{
			if (!values.IsDefault)
			{
				return values;
			}
			return ImmutableArray<T>.Empty;
		}

		protected override ImmutableArray<T> Clear(ImmutableArray<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override ImmutableArray<T> AddRange(ImmutableArray<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count != 1)
			{
				return values.AddRange(new ReadOnlySpan<T>(newValues.Array, newValues.Offset, newValues.Count));
			}
			return values.Add(RepeatedSerializer.Singleton(ref newValues));
		}

		protected override int TryGetCount(ImmutableArray<T> values)
		{
			if (!values.IsDefaultOrEmpty)
			{
				return values.Length;
			}
			return 0;
		}

		internal override long Measure(ImmutableArray<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			Enumerator values2 = new Enumerator(values);
			return RepeatedSerializer<ImmutableArray<T>, T>.Measure(ref values2, serializer, context, wireType);
		}

		internal override void WritePacked(ref ProtoWriter.State state, ImmutableArray<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			Enumerator values2 = new Enumerator(values);
			RepeatedSerializer<ImmutableArray<T>, T>.WritePacked(ref state, ref values2, serializer, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, ImmutableArray<T> values, ISerializer<T> serializer, SerializerFeatures features)
		{
			Enumerator values2 = new Enumerator(values);
			RepeatedSerializer<ImmutableArray<T>, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
		}
	}
}
