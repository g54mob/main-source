namespace TwitchLib.Api.Core.Enums
{
	public abstract class StringEnum
	{
		public string Value { get; }

		protected StringEnum(string value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
