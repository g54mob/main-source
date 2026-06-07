using System;

namespace HTTP
{
	public interface IHTTP
	{
		void Get(string url, Action<string, bool> callback);
	}
}
