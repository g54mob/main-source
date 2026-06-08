namespace Platforms
{
	public class CancelledByUserException : PlatformException
	{
		public CancelledByUserException(string m = "")
			: base(m)
		{
		}
	}
}
