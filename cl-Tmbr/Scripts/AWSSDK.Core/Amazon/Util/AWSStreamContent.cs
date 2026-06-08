using System;
using System.IO;
using System.Net.Http;

namespace Amazon.Util
{
	public class AWSStreamContent : IDisposable
	{
		private bool disposed;

		internal StreamContent StreamContent { get; set; }

		public AWSStreamContent(Stream content)
		{
			StreamContent = new StreamContent(content);
		}

		public AWSStreamContent(Stream content, int bufferSize)
		{
			StreamContent = new StreamContent(content, bufferSize);
		}

		public bool RemoveHttpContentHeader(string name)
		{
			return StreamContent.Headers.Remove(name);
		}

		public void AddHttpContentHeader(string name, string value)
		{
			StreamContent.Headers.Add(name, value);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					StreamContent.Dispose();
				}
				disposed = true;
			}
		}
	}
}
