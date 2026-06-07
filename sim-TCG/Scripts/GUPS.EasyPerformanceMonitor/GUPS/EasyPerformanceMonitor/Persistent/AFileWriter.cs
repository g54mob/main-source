using System;
using System.Threading.Tasks;

namespace GUPS.EasyPerformanceMonitor.Persistent
{
	internal abstract class AFileWriter<T> : IDisposable
	{
		public string Path { get; private set; }

		public AFileWriter(string _Path)
		{
			Path = _Path;
		}

		public abstract void Write(T _Object);

		public abstract Task WriteAsync(T _Object);

		public abstract void Flush();

		public abstract Task FlushAsync();

		public abstract void Dispose();
	}
}
