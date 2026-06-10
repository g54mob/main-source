using System;
using System.Diagnostics.CodeAnalysis;

namespace ZLogger.Entries
{
	public struct MessageLogState<TPayload> : IZLoggerState
	{
		public static readonly Func<MessageLogState<TPayload>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Message;

		public MessageLogState([AllowNull] TPayload payload, string message)
		{
			Payload = payload;
			Message = message;
		}

		private static IZLoggerEntry factory(MessageLogState<TPayload> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return MessageLogEntry<TPayload>.Create(in logInfo, in this);
		}
	}
}
