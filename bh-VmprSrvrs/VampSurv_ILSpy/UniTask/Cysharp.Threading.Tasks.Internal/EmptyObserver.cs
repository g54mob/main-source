using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal class EmptyObserver<T> : IObserver<T>
{
	public static readonly EmptyObserver<T> Instance;

	private EmptyObserver()
	{
	}

	public void OnCompleted()
	{
	}

	public void OnError(Exception error)
	{
	}

	public void OnNext(T value)
	{
	}

	static EmptyObserver()
	{
		//IL_0035: Expected O, but got I
		//IL_004a: Expected O, but got I
		nint num = 0;
		object obj = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.EmptyObserver`1>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12+B8]");
		object obj3 = 0;
		obj3 = obj;
	}
}
