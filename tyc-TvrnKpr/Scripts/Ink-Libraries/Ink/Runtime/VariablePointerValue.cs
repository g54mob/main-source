namespace Ink.Runtime
{
	public class VariablePointerValue : Value<string>
	{
		public string variableName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override ValueType valueType => default(ValueType);

		public override bool isTruthy => false;

		public int contextIndex { get; set; }

		public VariablePointerValue(string variableName, int contextIndex = -1)
			: base((string)null)
		{
		}

		public VariablePointerValue()
			: base((string)null)
		{
		}

		public override Value Cast(ValueType newType)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override Object Copy()
		{
			return null;
		}
	}
}
