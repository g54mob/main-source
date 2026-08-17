using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal struct ValueStopwatch
{
	private static readonly double TimestampToTicks;

	private readonly long startTimestamp;

	public TimeSpan Elapsed
	{
		get
		{
			//IL_001e: Expected O, but got I8
			long elapsedTicks = ElapsedTicks;
			return (TimeSpan)elapsedTicks;
		}
	}

	public bool IsInvalid => startTimestamp == 0;

	public long ElapsedTicks
	{
		get
		{
			//IL_007e: Expected I8, but got I4
			if (startTimestamp != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B21B10");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rbx\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [rax]\"");
				return 0L;
			}
			object obj = new InvalidOperationException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
			throw obj;
		}
	}

	public static ValueStopwatch StartNew()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B21B10");
		ValueStopwatch result = default(ValueStopwatch);
		return result;
	}

	private ValueStopwatch(long startTimestamp)
	{
		this.startTimestamp = startTimestamp;
	}

	static ValueStopwatch()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,qword ptr [rax]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
		TimestampToTicks = 10000000.0;
	}
}
