using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.Platforms;

public struct ErroInfo
{
	public static readonly ErroInfo NonError;

	public readonly int NativeErrorCode;

	public readonly Exception NativeException;

	public readonly string Message;

	public ErroInfo(int nativeErrorCode, string msg = null)
	{
		NativeErrorCode = nativeErrorCode;
		Message = msg;
		NativeException = null;
	}

	public ErroInfo(Exception ex, string msg = null)
	{
		//IL_001e: Expected I4, but got I8
		NativeException = ex;
		Message = msg;
		NativeErrorCode = -1;
	}

	public unsafe override string ToString()
	{
		//IL_0064: Expected O, but got Ref
		//IL_00ef: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2983]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = default(object);
		if (NativeException == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg, Message);
			return string.FormatHelper((IFormatProvider)null, "Error code: {0}, Msg: {1}", (System.ParamsArray)(&obj));
		}
		if (NativeException != null)
		{
			object message = NativeException.Message;
			if (NativeException != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg2 = default(object);
				System.ParamsArray paramsArray = new System.ParamsArray(message, arg2, Message);
				return string.FormatHelper((IFormatProvider)null, "Native Error msg: {0}, HResult: {1}, Msg: {2}", (System.ParamsArray)(&obj));
			}
		}
		return (string)(object)new NullReferenceException();
	}

	static ErroInfo()
	{
		//IL_0013: Expected I, but got O
		//IL_002d: Expected O, but got I4
		nint num = (nint)typeof(ErroInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v6 (Il2CppClass<VampireSurvivors.Framework.Platforms.ErroInfo>)+B8]");
		nint num2 = 0;
		NonError = (ErroInfo)0;
	}
}
