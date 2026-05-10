namespace Yarn.Markup
{
	public struct MarkupValue
	{
		public int IntegerValue { get; internal set; }

		public float FloatValue { get; internal set; }

		public string StringValue { get; internal set; }

		public bool BoolValue { get; internal set; }

		public MarkupValueType Type { get; internal set; }

		public override string ToString()
		{
			return null;
		}
	}
}
