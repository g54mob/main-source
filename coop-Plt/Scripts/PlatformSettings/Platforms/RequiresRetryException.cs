namespace Platforms
{
	public class RequiresRetryException : PlatformException
	{
		public RequiresRetryException(string m = "")
			: base(m)
		{
		}
	}
}
