using System;

namespace BestHTTP.Logger
{
	public interface ILogOutput : IDisposable
	{
		void Write(Loglevels level, string logEntry);
	}
}
