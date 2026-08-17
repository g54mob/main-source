using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

internal static class UniTaskCompletionSourceCoreShared
{
	internal static readonly Action<object> s_sentinel;

	private static void CompletionSentinel(object _)
	{
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}

	static UniTaskCompletionSourceCoreShared()
	{
		Action<object> action = CompletionSentinel;
		s_sentinel = action;
	}
}
