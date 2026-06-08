using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ProtoBuf.Serializers
{
	public abstract class ExternalSerializer<TCollection, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T> : RepeatedSerializer<TCollection, T> where TCollection : IEnumerable<T>
	{
		internal override long Measure(TCollection values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			IEnumerator<T> values2 = null;
			try
			{
				values2 = values.GetEnumerator();
				return RepeatedSerializer<TCollection, T>.Measure(ref values2, serializer, context, wireType);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		internal override void WritePacked(ref ProtoWriter.State state, TCollection values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			IEnumerator<T> values2 = null;
			try
			{
				values2 = values.GetEnumerator();
				RepeatedSerializer<TCollection, T>.WritePacked(ref state, ref values2, serializer, wireType);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, TCollection values, ISerializer<T> serializer, SerializerFeatures features)
		{
			IEnumerator<T> values2 = null;
			try
			{
				values2 = values.GetEnumerator();
				RepeatedSerializer<TCollection, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
			}
			finally
			{
				values2?.Dispose();
			}
		}
	}
}
