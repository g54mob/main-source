using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public static class ExceptionExtensions
{
	public static bool IsOperationCanceledException(Exception exception)
	{
		//IL_0019: Expected I, but got O
		//IL_0021: Expected I, but got O
		//IL_0031: Expected O, but got I
		//IL_00b1: Expected O, but got I4
		//IL_006d: Expected O, but got I
		//IL_00a3: Expected O, but got I4
		if (exception == null)
		{
			return true;
		}
		nint num = (nint)typeof(OperationCanceledException);
		nint num2 = (nint)exception;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v1 (Il2CppClass<System.OperationCanceledException>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v1 (Il2CppClass<System.Exception>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v1 (Il2CppClass<System.OperationCanceledException>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v1 (Il2CppClass<System.Exception>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v9+FFFFFFF8+v56 @ rax_v2*8]");
			if (0 == (nint)typeof(OperationCanceledException))
			{
				obj3 = 1;
				goto IL_00e3;
			}
		}
		obj3 = 0;
		goto IL_00e3;
		IL_00e3:
		bool flag = obj3 == null;
		Exception ex = null;
		if (!flag)
		{
			ex = exception;
		}
		bool flag2 = ex == null;
		return !flag2;
	}
}
