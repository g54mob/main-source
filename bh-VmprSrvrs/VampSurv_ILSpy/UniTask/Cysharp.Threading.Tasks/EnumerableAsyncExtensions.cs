using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public static class EnumerableAsyncExtensions
{
	public static IEnumerable<UniTask> Select<T>(IEnumerable<T> source, Func<T, UniTask> selector)
	{
		//IL_0013: Expected O, but got I
		nint num = 0;
		object obj = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v38 @ r10_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public static IEnumerable<UniTask<TR>> Select<T, TR>(IEnumerable<T> source, Func<T, UniTask<TR>> selector)
	{
		//IL_0013: Expected O, but got I
		nint num = 0;
		object obj = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v38 @ r10_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public static IEnumerable<UniTask> Select<T>(IEnumerable<T> source, Func<T, int, UniTask> selector)
	{
		//IL_0013: Expected O, but got I
		nint num = 0;
		object obj = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v38 @ r10_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public static IEnumerable<UniTask<TR>> Select<T, TR>(IEnumerable<T> source, Func<T, int, UniTask<TR>> selector)
	{
		//IL_0013: Expected O, but got I
		nint num = 0;
		object obj = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v38 @ r10_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}
}
