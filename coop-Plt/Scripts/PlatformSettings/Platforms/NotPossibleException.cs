namespace Platforms
{
	public class NotPossibleException : PlatformException
	{
		public NotPossibleException(string m = "")
			: base(m)
		{
		}
	}
}
