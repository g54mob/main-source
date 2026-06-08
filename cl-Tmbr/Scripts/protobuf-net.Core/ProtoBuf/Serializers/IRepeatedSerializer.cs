using System.Diagnostics.CodeAnalysis;

namespace ProtoBuf.Serializers
{
	public interface IRepeatedSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T> : ISerializer<T>
	{
		void WriteRepeated(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures features, T values);

		T ReadRepeated(ref ProtoReader.State state, SerializerFeatures features, T values);
	}
}
