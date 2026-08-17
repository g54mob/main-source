using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public static class StateExtensions
{
	public static ReadOnlyAsyncReactiveProperty<T> ToReadOnlyAsyncReactiveProperty<T>(IUniTaskAsyncEnumerable<T> source, CancellationToken cancellationToken)
	{
		ReadOnlyAsyncReactiveProperty<T> result = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v56 @ r10_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		return result;
	}

	public unsafe static ReadOnlyAsyncReactiveProperty<T> ToReadOnlyAsyncReactiveProperty<T>(IUniTaskAsyncEnumerable<T> source, T initialValue, CancellationToken cancellationToken)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0038: Expected O, but got I
		//IL_00d2: Expected O, but got Ref
		//IL_00da: Expected O, but got Ref
		//IL_00f6: Expected O, but got I
		//IL_0085: Expected O, but got I
		//IL_009f: Expected O, but got Ref
		//IL_0148: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v1 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v1 (Il2CppClass<T>)+FC]");
		object obj4 = default(object);
		T val;
		if ((nint)obj3 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			obj4 = (object)(&obj2);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v2 (Il2CppClass<T>)+28]");
			object obj5 = (nint)0 >> 31;
			if (obj5 == null)
			{
				goto IL_0113;
			}
		}
		val = initialValue;
		goto IL_0113;
		IL_0113:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		ReadOnlyAsyncReactiveProperty<T> result = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v3 (Il2CppClass<T>)+28]");
		object obj6 = (nint)0 >> 31;
		bool flag = obj6 != null;
		object obj7 = (object)(&obj2);
		if (!flag)
		{
			obj7 = obj4;
		}
		obj = obj7;
		nint num4 = 0;
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v122 @ r10_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		return result;
	}
}
