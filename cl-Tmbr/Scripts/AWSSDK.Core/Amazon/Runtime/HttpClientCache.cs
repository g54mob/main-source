using System;
using System.Net.Http;
using System.Threading;

namespace Amazon.Runtime
{
	public class HttpClientCache : IDisposable
	{
		private HttpClient[] _clients;

		private int count;

		public HttpClientCache(HttpClient[] clients)
		{
			_clients = clients;
		}

		public HttpClient GetNextClient()
		{
			if (_clients.Length == 1)
			{
				return _clients[0];
			}
			int num = Math.Abs(Interlocked.Increment(ref count) % _clients.Length);
			return _clients[num];
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && _clients != null)
			{
				HttpClient[] clients = _clients;
				for (int i = 0; i < clients.Length; i++)
				{
					clients[i].Dispose();
				}
			}
		}
	}
}
