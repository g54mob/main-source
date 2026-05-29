using System;
using System.IO;

namespace ES3Internal
{
	public class ES3FileStream : FileStream
	{
		private bool isDisposed;

		public ES3FileStream(string path, ES3FileMode fileMode, int bufferSize, bool useAsync)
			: base((IntPtr)0, default(FileAccess), ownsHandle: false, 0)
		{
		}

		protected static string GetPath(string path, ES3FileMode fileMode)
		{
			return null;
		}

		protected static FileMode GetFileMode(ES3FileMode fileMode)
		{
			return default(FileMode);
		}

		protected static FileAccess GetFileAccess(ES3FileMode fileMode)
		{
			return default(FileAccess);
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
