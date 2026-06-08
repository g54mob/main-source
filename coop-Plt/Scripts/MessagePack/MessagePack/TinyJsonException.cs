namespace MessagePack
{
	public class TinyJsonException : MessagePackSerializationException
	{
		public TinyJsonException(string message)
			: base(message)
		{
		}
	}
}
