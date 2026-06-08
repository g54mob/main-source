namespace ProtoBuf.Internal
{
	internal interface IValueChecker<in T>
	{
		bool HasNonTrivialValue(T value);

		bool IsNull(T value);
	}
}
