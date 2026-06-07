namespace UnityWebSocketSharp.Net
{
	internal sealed class HttpListenerPrefix
	{
		private string _host;

		private HttpListener _listener;

		private string _original;

		private string _path;

		private string _port;

		private string _prefix;

		private bool _secure;

		public string Host => null;

		public bool IsSecure => false;

		public HttpListener Listener => null;

		public string Original => null;

		public string Path => null;

		public string Port => null;

		internal HttpListenerPrefix(string uriPrefix, HttpListener listener)
		{
		}

		private void parse(string uriPrefix)
		{
		}

		public static void CheckPrefix(string uriPrefix)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
