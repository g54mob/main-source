namespace Ink.Runtime
{
	public class ListValue : Value<InkList>
	{
		public override ValueType valueType => default(ValueType);

		public override bool isTruthy => false;

		public override Value Cast(ValueType newType)
		{
			return null;
		}

		public ListValue()
			: base((InkList)default(_00210))
		{
		}

		public ListValue(InkList list)
			: base((InkList)default(_00210))
		{
		}

		public ListValue(InkListItem singleItem, int singleValue)
			: base((InkList)default(_00210))
		{
		}

		public static void RetainListOriginsForAssignment(Object oldValue, Object newValue)
		{
		}
	}
}
