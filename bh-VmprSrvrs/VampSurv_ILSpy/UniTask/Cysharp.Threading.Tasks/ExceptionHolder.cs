using System;
using System.Runtime.ExceptionServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

internal class ExceptionHolder(ExceptionDispatchInfo exception)
{
	private ExceptionDispatchInfo exception = exception;

	private bool calledGet;

	public ExceptionDispatchInfo GetException()
	{
		if (!calledGet)
		{
			calledGet = true;
			GC.SuppressFinalize(this);
		}
		return exception;
	}

	~ExceptionHolder()
	{
		//IL_0015: Expected O, but got I
		//IL_0030: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ stack_8_v2+18]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ stack_8_v2+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v3+10]");
			UniTaskScheduler.PublishUnobservedTaskException((Exception)0);
		}
	}
}
