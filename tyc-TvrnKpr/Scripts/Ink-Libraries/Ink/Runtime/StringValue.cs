namespace Ink.Runtime
{
	public class StringValue : Value<string>
	{
		public override ValueType valueType => default(ValueType);

		public override bool isTruthy => false;

		public bool isNewline { get; private set; }

		public bool isInlineWhitespace { get; private set; }

		public bool isNonWhitespace => false;

		public StringValue(string str)
			: base((string)null)
		{
		}

		public StringValue()
			: base((string)null)
		{
		}

		public override Value Cast(ValueType newType)
		{
			return null;
		}
	}
}
