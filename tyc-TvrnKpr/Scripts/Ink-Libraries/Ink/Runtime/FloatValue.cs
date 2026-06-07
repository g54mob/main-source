namespace Ink.Runtime
{
	public class FloatValue : Value<float>
	{
		public override ValueType valueType => default(ValueType);

		public override bool isTruthy => false;

		public FloatValue(float val)
			: base((float)default(_00210))
		{
		}//IL_000f: Expected F4, but got O


		public FloatValue()
			: base((float)default(_00210))
		{
		}//IL_000f: Expected F4, but got O


		public override Value Cast(ValueType newType)
		{
			return null;
		}
	}
}
