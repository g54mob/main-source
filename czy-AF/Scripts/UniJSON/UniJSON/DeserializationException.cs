namespace UniJSON
{
	public class DeserializationException : TreeValueException
	{
		public DeserializationException(string msg)
			: base(msg)
		{
		}
	}
}
