using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Muna.API
{
	public abstract class MunaClient
	{
		public readonly string url;

		protected internal readonly string? accessKey;

		public abstract Task<T?> Request<T>(string method, string path, Dictionary<string, object?>? payload = null) where T : class;

		public abstract IAsyncEnumerable<T> Stream<T>(string method, string path, Dictionary<string, object?>? payload = null) where T : class;

		public abstract Task<Stream> Download(string url);

		public abstract Task Upload(Stream stream, string url, string? mime = null);

		protected MunaClient(string url, string? accessKey)
		{
			this.url = url;
			this.accessKey = accessKey;
		}
	}
}
