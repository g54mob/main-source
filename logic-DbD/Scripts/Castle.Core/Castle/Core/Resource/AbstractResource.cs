using System;
using System.IO;
using System.Text;

namespace Castle.Core.Resource
{
	public abstract class AbstractResource : IResource, IDisposable
	{
		protected static readonly string DefaultBasePath = AppDomain.CurrentDomain.BaseDirectory;

		public virtual string FileBasePath => DefaultBasePath;

		public abstract TextReader GetStreamReader();

		public abstract TextReader GetStreamReader(Encoding encoding);

		public abstract IResource CreateRelative(string relativePath);

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
