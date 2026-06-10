using System;
using System.Diagnostics.CodeAnalysis;

namespace ZLogger.Entries
{
	public struct FormatLogState<TPayload, T1> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public readonly T7 Arg7;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
			Arg7 = arg7;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public readonly T7 Arg7;

		public readonly T8 Arg8;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
			Arg7 = arg7;
			Arg8 = arg8;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public readonly T7 Arg7;

		public readonly T8 Arg8;

		public readonly T9 Arg9;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
			Arg7 = arg7;
			Arg8 = arg8;
			Arg9 = arg9;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public readonly T7 Arg7;

		public readonly T8 Arg8;

		public readonly T9 Arg9;

		public readonly T10 Arg10;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
			Arg7 = arg7;
			Arg8 = arg8;
			Arg9 = arg9;
			Arg10 = arg10;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public readonly T7 Arg7;

		public readonly T8 Arg8;

		public readonly T9 Arg9;

		public readonly T10 Arg10;

		public readonly T11 Arg11;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
			Arg7 = arg7;
			Arg8 = arg8;
			Arg9 = arg9;
			Arg10 = arg10;
			Arg11 = arg11;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public readonly T7 Arg7;

		public readonly T8 Arg8;

		public readonly T9 Arg9;

		public readonly T10 Arg10;

		public readonly T11 Arg11;

		public readonly T12 Arg12;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
			Arg7 = arg7;
			Arg8 = arg8;
			Arg9 = arg9;
			Arg10 = arg10;
			Arg11 = arg11;
			Arg12 = arg12;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public readonly T7 Arg7;

		public readonly T8 Arg8;

		public readonly T9 Arg9;

		public readonly T10 Arg10;

		public readonly T11 Arg11;

		public readonly T12 Arg12;

		public readonly T13 Arg13;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
			Arg7 = arg7;
			Arg8 = arg8;
			Arg9 = arg9;
			Arg10 = arg10;
			Arg11 = arg11;
			Arg12 = arg12;
			Arg13 = arg13;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.Create(in logInfo, in this);
		}
	}
	public struct FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IZLoggerState
	{
		public static readonly Func<FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, LogInfo, IZLoggerEntry> Factory = factory;

		public readonly TPayload Payload;

		public readonly string Format;

		public readonly T1 Arg1;

		public readonly T2 Arg2;

		public readonly T3 Arg3;

		public readonly T4 Arg4;

		public readonly T5 Arg5;

		public readonly T6 Arg6;

		public readonly T7 Arg7;

		public readonly T8 Arg8;

		public readonly T9 Arg9;

		public readonly T10 Arg10;

		public readonly T11 Arg11;

		public readonly T12 Arg12;

		public readonly T13 Arg13;

		public readonly T14 Arg14;

		public FormatLogState([AllowNull] TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			Payload = payload;
			Format = format;
			Arg1 = arg1;
			Arg2 = arg2;
			Arg3 = arg3;
			Arg4 = arg4;
			Arg5 = arg5;
			Arg6 = arg6;
			Arg7 = arg7;
			Arg8 = arg8;
			Arg9 = arg9;
			Arg10 = arg10;
			Arg11 = arg11;
			Arg12 = arg12;
			Arg13 = arg13;
			Arg14 = arg14;
		}

		private static IZLoggerEntry factory(FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> self, LogInfo logInfo)
		{
			return self.CreateLogEntry(logInfo);
		}

		public IZLoggerEntry CreateLogEntry(LogInfo logInfo)
		{
			return FormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.Create(in logInfo, in this);
		}
	}
}
