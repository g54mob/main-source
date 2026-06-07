using System;
using System.Runtime.InteropServices;

namespace TriLib
{
	public class FileLoadData : IDisposable
	{
		public string Filename;

		public string BasePath;

		public virtual void Dispose()
		{
		}

		public virtual void AddBuffer(GCHandle bufferHandle)
		{
		}
	}
}
