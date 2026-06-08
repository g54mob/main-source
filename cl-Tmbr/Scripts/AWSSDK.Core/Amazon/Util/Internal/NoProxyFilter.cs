using System;

namespace Amazon.Util.Internal
{
	public class NoProxyFilter
	{
		public static readonly NoProxyFilter Instance = new NoProxyFilter();

		public bool Match(Uri uri)
		{
			return false;
		}
	}
}
