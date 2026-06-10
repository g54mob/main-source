using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UnityEngine;

namespace ZLogger.Providers
{
	public class UnityDebugLogProcessor : IAsyncLogProcessor, IAsyncDisposable
	{
		private readonly ZLoggerOptions options;

		public UnityDebugLogProcessor(ZLoggerOptions options)
		{
			this.options = options;
		}

		public ValueTask DisposeAsync()
		{
			return default(ValueTask);
		}

		public void Post(IZLoggerEntry log)
		{
			try
			{
				string message = log.FormatToString(options, null);
				switch (log.LogInfo.LogLevel)
				{
				case LogLevel.Trace:
				case LogLevel.Debug:
				case LogLevel.Information:
					Debug.Log(message);
					break;
				case LogLevel.Warning:
					Debug.LogWarning(message);
					break;
				case LogLevel.Critical:
					Debug.LogError(message);
					break;
				case LogLevel.Error:
					if (log.LogInfo.Exception != null)
					{
						Debug.LogException(log.LogInfo.Exception);
					}
					else
					{
						Debug.LogError(message);
					}
					break;
				case LogLevel.None:
					break;
				}
			}
			finally
			{
				log.Return();
			}
		}
	}
}
