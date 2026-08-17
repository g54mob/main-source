using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using Unity.IL2CPP.Metadata;

namespace Cysharp.Threading.Tasks;

public static class UniTaskAsyncEnumerableExtensions
{
	public unsafe static UniTaskCancelableAsyncEnumerable<T> WithCancellation<T>(IUniTaskAsyncEnumerable<T> source, CancellationToken cancellationToken)
	{
		//IL_0040: Expected O, but got I4
		//IL_0051: Expected O, but got I
		//IL_004c: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ r9+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		IUniTaskAsyncEnumerable<T> uniTaskAsyncEnumerable = (IUniTaskAsyncEnumerable<T>)0;
		IntPtr intPtr = default(IntPtr);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)source, new UniTaskCancelableAsyncEnumerable<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>((IUniTaskAsyncEnumerable<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>)cancellationToken, (CancellationToken)(nint)intPtr));
		return (UniTaskCancelableAsyncEnumerable<T>)source;
	}
}
