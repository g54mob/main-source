namespace Ink.Runtime
{
	public class BoolValue : Value<bool>
	{
		public override ValueType valueType => default(ValueType);

		public override bool isTruthy => false;

		public BoolValue(bool boolVal)
			: base((byte)(int)default(_00210) != 0)
		{
		}//IL_000f: Expected I4, but got O


		public BoolValue()
			: base((byte)(int)default(_00210) != 0)
		{
		}//IL_000f: Expected I4, but got O


		public override Value Cast(ValueType newType)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
