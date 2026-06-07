using System.Collections.Generic;

namespace SimpleHttp
{
	public class SimpleHttpResponse
	{
		private Dictionary<string, List<string>> headers;

		public string HttpVersion { get; set; }

		public string StatusMessage { get; set; }

		public int StatusCode { get; set; }

		public string Body { get; set; }

		public void AddHeader(string name, string value)
		{
		}

		public string GetHeader(string name)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public bool IsRedirect()
		{
			return false;
		}
	}
}
