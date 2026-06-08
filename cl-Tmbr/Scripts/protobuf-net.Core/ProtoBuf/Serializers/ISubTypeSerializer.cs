using System.Diagnostics.CodeAnalysis;

namespace ProtoBuf.Serializers
{
	public interface ISubTypeSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T> where T : class
	{
		void WriteSubType(ref ProtoWriter.State state, T value);

		T ReadSubType(ref ProtoReader.State state, SubTypeState<T> value);
	}
}
