using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal static class StateTuple
{
	public unsafe static StateTuple<T1> Create<T1>(T1 item1)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002e: Expected O, but got I
		//IL_00c8: Expected O, but got Ref
		//IL_00d0: Expected O, but got Ref
		//IL_00ec: Expected O, but got I
		//IL_007b: Expected O, but got I
		//IL_0095: Expected O, but got Ref
		//IL_0126: Expected O, but got Ref
		//IL_0148: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ r8_v1 (Il2CppClass<T1>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ r8_v1 (Il2CppClass<T1>)+FC]");
		object obj4 = default(object);
		T1 val;
		if ((nint)obj3 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			val = (T1)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
			obj4 = (object)(&obj2);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v2 (Il2CppClass<T1>)+28]");
			object obj5 = (nint)0 >> 31;
			if (obj5 == null)
			{
				goto IL_0109;
			}
		}
		val = item1;
		goto IL_0109;
		IL_0109:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v6 (Il2CppClass<T1>)+28]");
		object obj6 = (nint)0 >> 31;
		bool flag = obj6 != null;
		object obj7 = (object)(&obj2);
		if (!flag)
		{
			obj7 = obj4;
		}
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ r10_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		return (StateTuple<T1>)0;
	}

	public unsafe static StateTuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
	{
		//IL_001c: Expected O, but got Ref
		object obj = default(object);
		return StatePool<T1, T2>.Create(item1, (T2)(&obj));
	}

	public unsafe static StateTuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
	{
		//IL_0020: Expected O, but got Ref
		object obj = default(object);
		return StatePool<T1, T2, T3>.Create(item1, (T2)(&obj), item3);
	}
}
internal class StateTuple<T1> : IDisposable
{
	public T1 Item1;

	public unsafe void Deconstruct(out T1 item1)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0028: Expected O, but got I
		//IL_003e: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_00a0: Expected O, but got I
		//IL_00b0: Expected O, but got I
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rdx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StateTuple`1>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rax_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rax_v2+FC]");
		object obj8 = default(object);
		object obj9;
		if ((nint)obj4 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StateTuple`1>)+8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v8+80]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v2+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v2+18]");
			obj8 = 0 + this;
			obj9 = obj8 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v9+28]");
			if ((nint)0 < (nint)0)
			{
				goto IL_00f5;
			}
		}
		obj9 = obj8;
		goto IL_00f5;
		IL_00f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
	}

	public void Dispose()
	{
		//IL_0020: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StateTuple`1>)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rax_v6] (should have been resolved before IL gen)");
	}
}
internal class StateTuple<T1, T2> : IDisposable
{
	public T1 Item1;

	public T2 Item2;

	public unsafe void Deconstruct(out T1 item1, out T2 item2)
	{
		ref T1 reference = ref *(T1*)Item1;
		ref T2 reference2 = ref *(T2*)Item2;
	}

	public void Dispose()
	{
		//IL_0020: Expected O, but got I
		//IL_0052: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_0077: Expected O, but got I
		//IL_008c: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StateTuple`2>)+28]");
		object obj = 0;
		Item1 = (T1)null;
		Item2 = (T2)null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v2+20]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v16+C0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v17+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v19+B8]");
		object obj5 = 0;
		((ConcurrentQueue<object>)obj5).Enqueue((object)this);
	}
}
internal class StateTuple<T1, T2, T3> : IDisposable
{
	public T1 Item1;

	public T2 Item2;

	public T3 Item3;

	public unsafe void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
	{
		ref T1 reference = ref *(T1*)Item1;
		ref T2 reference2 = ref *(T2*)Item2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.StateTuple`3<T1, T2, T3>)+28]");
		ref T3 reference3 = ref *(T3*)null;
	}

	public void Dispose()
	{
		//IL_0020: Expected O, but got I
		//IL_0058: Expected O, but got I
		//IL_006d: Expected O, but got I
		//IL_007d: Expected O, but got I
		//IL_0092: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StateTuple`3>)+38]");
		object obj = 0;
		Item1 = (T1)null;
		Item2 = (T2)null;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rbx_v2+20]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v16+C0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v17+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v19+B8]");
		object obj5 = 0;
		((ConcurrentQueue<object>)obj5).Enqueue((object)this);
	}
}
