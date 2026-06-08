namespace ProtoBuf.Internal
{
	internal sealed class StructValueChecker<T> : IValueChecker<T?>, IValueChecker<T> where T : struct
	{
		public static readonly StructValueChecker<T> Instance = new StructValueChecker<T>();

		private StructValueChecker()
		{
		}

		bool IValueChecker<T?>.HasNonTrivialValue(T? value)
		{
			return value.HasValue;
		}

		bool IValueChecker<T?>.IsNull(T? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<T>.HasNonTrivialValue(T value)
		{
			return true;
		}

		bool IValueChecker<T>.IsNull(T value)
		{
			return false;
		}
	}
}
