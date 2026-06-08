namespace ProtoBuf.Internal
{
	internal sealed class ReferenceValueChecker : IValueChecker<object>
	{
		public static readonly ReferenceValueChecker Instance = new ReferenceValueChecker();

		private ReferenceValueChecker()
		{
		}

		bool IValueChecker<object>.HasNonTrivialValue(object value)
		{
			return value != null;
		}

		bool IValueChecker<object>.IsNull(object value)
		{
			return value == null;
		}
	}
}
