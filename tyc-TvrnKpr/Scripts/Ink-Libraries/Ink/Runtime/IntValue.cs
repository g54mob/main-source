namespace Ink.Runtime
{
	public class IntValue : Value<int>
	{
		public override ValueType valueType => default(ValueType);

		public override bool isTruthy => false;

		public IntValue(int intVal)
			: base((int)default(_00210))
		{
		}//IL_000f: Expected I4, but got O


		public IntValue()
			: base((int)default(_00210))
		{
		}//IL_000f: Expected I4, but got O


		public override Value Cast(ValueType newType)
		{
			return null;
		}
	}
}
