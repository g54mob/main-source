namespace MessagePack
{
	public class FormatterNotRegisteredException : MessagePackSerializationException
	{
		public FormatterNotRegisteredException(string message)
			: base(message)
		{
		}
	}
}
