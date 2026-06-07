using System;
using System.IO;

namespace BestHTTP.Logger
{
	public sealed class FileOutput : ILogOutput, IDisposable
	{
		private Stream fileStream;

		public FileOutput(string fileName)
		{
		}

		public void Write(Loglevels level, string logEntry)
		{
		}

		public void Dispose()
		{
		}
	}
}
