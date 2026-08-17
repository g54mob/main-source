using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal static class StatePool<T1>
{
	private static readonly ConcurrentQueue<StateTuple<T1>> queue;

	[MethodImpl((MethodImplOptions)256)]
	public unsafe static StateTuple<T1> Create(T1 item1)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002d: Expected O, but got I
		//IL_0043: Expected O, but got I
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0074: Expected O, but got I8
		//IL_009e: Expected O, but got I
		//IL_00b3: Expected O, but got I
		//IL_00eb: Expected O, but got I
		//IL_0104: Expected O, but got Ref
		//IL_02be: Expected O, but got Ref
		//IL_02ce: Expected O, but got I
		//IL_02e4: Expected O, but got I
		//IL_0153: Expected O, but got I
		//IL_0228: Expected O, but got I
		//IL_0242: Expected O, but got I
		//IL_0181: Expected O, but got Ref
		//IL_0191: Expected O, but got I
		//IL_01a7: Expected O, but got I
		//IL_01ec: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+28]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v2+FC]");
		if ((nint)obj5 <= 0)
		{
			obj4 = 1152921504606846960L;
		}
		object obj6 = obj4 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v16+B8]");
		object obj8 = 0;
		if (obj8 != null)
		{
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v22 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+18]");
			object obj9 = 0;
			nint num4 = 0;
			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v217 @ rcx_v13] (should have been resolved before IL gen)");
			object obj11 = default(object);
			StateTuple<T1> stateTuple;
			if (obj11 != null)
			{
				nint num5 = 0;
				T1 val = (T1)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v29 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+28]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v19+28]");
				object obj13 = (nint)0 >> 31;
				if (obj13 != null)
				{
					val = item1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
				if ((nint)0 == 0)
				{
					goto IL_0247;
				}
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v35 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+30]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
				stateTuple = (StateTuple<T1>)0;
			}
			else
			{
				nint num7 = 0;
				stateTuple = null;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rax_v47 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+38]");
				object obj15 = 0;
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v372 @ rcx_v29] (should have been resolved before IL gen)");
				nint num10 = 0;
				T1 val2 = (T1)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rax_v53 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+28]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rcx_v33+28]");
				object obj17 = (nint)0 >> 31;
				if (obj17 != null)
				{
					val2 = item1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				if (stateTuple == null)
				{
					goto IL_0247;
				}
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rax_v59 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+30]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
			}
			return stateTuple;
		}
		goto IL_0247;
		IL_0247:
		return (StateTuple<T1>)(object)new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public static void Return(StateTuple<T1> tuple)
	{
		//IL_001b: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_0046: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00d0: Expected O, but got I
		//IL_00e5: Expected O, but got I
		//IL_0105: Expected O, but got I
		//IL_0120: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+28]");
		object obj = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+30]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v4+80]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v1+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v1+18]");
		object obj5 = 0 + tuple;
		object obj6 = obj5 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v7+28]");
		if ((nint)0 >= (nint)0)
		{
			obj6 = obj5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v17 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v19+B8]");
		object obj8 = 0;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v24 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+40]");
		object obj9 = 0;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v27 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+40]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v173 @ rsi_v1+10] (should have been resolved before IL gen)");
	}

	static StatePool()
	{
		//IL_0030: Expected O, but got I
		//IL_0060: Expected O, but got I
		//IL_0075: Expected O, but got I
		nint num = 0;
		object obj = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+48]");
		object obj2 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rcx_v5] (should have been resolved before IL gen)");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`1>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v17+B8]");
		object obj4 = 0;
		obj4 = obj;
	}
}
internal static class StatePool<T1, T2>
{
	private static readonly ConcurrentQueue<StateTuple<T1, T2>> queue;

	[MethodImpl((MethodImplOptions)256)]
	public static StateTuple<T1, T2> Create(T1 item1, T2 item2)
	{
		//IL_002a: Expected O, but got I
		//IL_003f: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`2>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v11+B8]");
		object obj2 = 0;
		ConcurrentQueue<object> concurrentQueue = (ConcurrentQueue<object>)obj2;
		if (obj2 != null && concurrentQueue._head != null)
		{
			StateTuple<T1, T2> stateTuple;
			if (!concurrentQueue._head.TryDequeue(out var item3) && !((ConcurrentQueue<object>)obj2).TryDequeueSlow(out item3))
			{
				nint num2 = 0;
				stateTuple = null;
				if (stateTuple == null)
				{
					goto IL_015b;
				}
				stateTuple.Item1 = item1;
				stateTuple.Item2 = item2;
			}
			else
			{
				if (item3 == null || item3 == null)
				{
					goto IL_015b;
				}
				stateTuple = (StateTuple<T1, T2>)item3;
			}
			return stateTuple;
		}
		goto IL_015b;
		IL_015b:
		return (StateTuple<T1, T2>)(object)new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public static void Return(StateTuple<T1, T2> tuple)
	{
		//IL_003e: Expected O, but got I
		//IL_0053: Expected O, but got I
		tuple.Item1 = (T1)null;
		tuple.Item2 = (T2)null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`2>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v14+B8]");
		object obj2 = 0;
		((ConcurrentQueue<object>)obj2).Enqueue((object)tuple);
	}

	static StatePool()
	{
		//IL_003b: Expected O, but got I
		//IL_0050: Expected O, but got I
		nint num = 0;
		ConcurrentQueue<object> concurrentQueue = new ConcurrentQueue<object>();
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`2>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v14+B8]");
		object obj2 = 0;
		obj2 = concurrentQueue;
	}
}
internal static class StatePool<T1, T2, T3>
{
	private static readonly ConcurrentQueue<StateTuple<T1, T2, T3>> queue;

	[MethodImpl((MethodImplOptions)256)]
	public static StateTuple<T1, T2, T3> Create(T1 item1, T2 item2, T3 item3)
	{
		//IL_002a: Expected O, but got I
		//IL_003f: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`3>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v11+B8]");
		object obj2 = 0;
		ConcurrentQueue<object> concurrentQueue = (ConcurrentQueue<object>)obj2;
		if (obj2 != null && concurrentQueue._head != null)
		{
			StateTuple<T1, T2, T3> stateTuple;
			if (!concurrentQueue._head.TryDequeue(out var item4) && !((ConcurrentQueue<object>)obj2).TryDequeueSlow(out item4))
			{
				nint num2 = 0;
				stateTuple = null;
				if (stateTuple == null)
				{
					goto IL_0187;
				}
				stateTuple.Item1 = item1;
				stateTuple.Item2 = item2;
			}
			else
			{
				if (item4 == null || item4 == null || item4 == null)
				{
					goto IL_0187;
				}
				stateTuple = (StateTuple<T1, T2, T3>)item4;
			}
			return stateTuple;
		}
		goto IL_0187;
		IL_0187:
		return (StateTuple<T1, T2, T3>)(object)new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public static void Return(StateTuple<T1, T2, T3> tuple)
	{
		//IL_0044: Expected O, but got I
		//IL_0059: Expected O, but got I
		tuple.Item1 = (T1)null;
		tuple.Item2 = (T2)null;
		_ = 0;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`3>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v14+B8]");
		object obj2 = 0;
		((ConcurrentQueue<object>)obj2).Enqueue((object)tuple);
	}

	static StatePool()
	{
		//IL_003b: Expected O, but got I
		//IL_0050: Expected O, but got I
		nint num = 0;
		ConcurrentQueue<object> concurrentQueue = new ConcurrentQueue<object>();
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.StatePool`3>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v14+B8]");
		object obj2 = 0;
		obj2 = concurrentQueue;
	}
}
