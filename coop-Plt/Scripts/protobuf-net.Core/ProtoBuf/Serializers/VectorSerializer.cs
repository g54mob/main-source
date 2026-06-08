using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal sealed class VectorSerializer<T> : RepeatedSerializer<T[], T>
	{
		[StructLayout(LayoutKind.Auto)]
		private struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			private readonly T[] _array;

			private int _index;

			public T Current => _array[_index];

			object IEnumerator.Current => _array[_index];

			public void Reset()
			{
				ThrowHelper.ThrowNotSupportedException();
			}

			public Enumerator(T[] array)
			{
				_array = array;
				_index = -1;
			}

			public bool MoveNext()
			{
				return ++_index < _array.Length;
			}

			public void Dispose()
			{
			}
		}

		protected override T[] Initialize(T[] values, ISerializationContext context)
		{
			return values ?? Array.Empty<T>();
		}

		protected override T[] Clear(T[] values, ISerializationContext context)
		{
			return Array.Empty<T>();
		}

		protected override T[] AddRange(T[] values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			T[] array = new T[values.Length + newValues.Count];
			Array.Copy(values, 0, array, 0, values.Length);
			Array.Copy(newValues.Array, newValues.Offset, array, values.Length, newValues.Count);
			return array;
		}

		protected override int TryGetCount(T[] values)
		{
			if (values != null)
			{
				return values.Length;
			}
			return 0;
		}

		internal override long Measure(T[] values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			Enumerator values2 = new Enumerator(values);
			return Measure(ref values2, serializer, context, wireType);
		}

		internal override void WritePacked(ref ProtoWriter.State state, T[] values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			Enumerator values2 = new Enumerator(values);
			WritePacked(ref state, ref values2, serializer, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, T[] values, ISerializer<T> serializer)
		{
			Enumerator values2 = new Enumerator(values);
			Write(ref state, fieldNumber, category, wireType, ref values2, serializer);
		}
	}
}
