using System;
using System.Runtime.ExceptionServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal class ThrowObserver<T> : IObserver<T>
{
	public static readonly ThrowObserver<T> Instance;

	private ThrowObserver()
	{
	}

	public void OnCompleted()
	{
	}

	public void OnError(Exception error)
	{
		ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(error);
		throw new NullReferenceException();
	}

	public void OnNext(T value)
	{
	}

	static ThrowObserver()
	{
		//IL_0030: Expected O, but got I
		//IL_0060: Expected O, but got I
		//IL_0075: Expected O, but got I
		nint num = 0;
		object obj = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ThrowObserver`1>)+8]");
		object obj2 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rcx_v5] (should have been resolved before IL gen)");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ThrowObserver`1>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v17+B8]");
		object obj4 = 0;
		obj4 = obj;
	}
}
