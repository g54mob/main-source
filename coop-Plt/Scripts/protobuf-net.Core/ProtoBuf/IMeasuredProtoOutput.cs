using System.Diagnostics.CodeAnalysis;

namespace ProtoBuf
{
	public interface IMeasuredProtoOutput<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TOutput> : IProtoOutput<TOutput>
	{
		MeasureState<T> Measure<T>(T value, object userState = null);

		void Serialize<T>(MeasureState<T> measured, TOutput destination);
	}
}
