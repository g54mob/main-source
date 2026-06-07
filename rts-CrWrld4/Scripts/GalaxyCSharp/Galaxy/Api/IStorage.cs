using System;
using System.Runtime.InteropServices;

namespace Galaxy.Api
{
	public class IStorage : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal IStorage(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		~IStorage()
		{
		}

		public virtual void Dispose()
		{
		}

		public virtual void FileWrite(string fileName, byte[] data, uint dataSize)
		{
		}

		public virtual void FileDelete(string fileName)
		{
		}

		public virtual bool FileExists(string fileName)
		{
			return false;
		}

		public virtual uint GetFileCount()
		{
			return 0u;
		}

		public virtual string GetFileNameByIndex(uint index)
		{
			return null;
		}

		public virtual void FileShare(string fileName)
		{
		}

		public virtual void DownloadSharedFile(ulong sharedFileID)
		{
		}

		public virtual uint GetSharedFileSize(ulong sharedFileID)
		{
			return 0u;
		}

		public virtual uint SharedFileRead(ulong sharedFileID, byte[] data, uint dataSize)
		{
			return 0u;
		}

		public virtual void SharedFileClose(ulong sharedFileID)
		{
		}
	}
}
