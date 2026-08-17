using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal sealed class PooledDelegate<T> : ITaskPoolNode<PooledDelegate<T>>
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			//IL_0035: Expected O, but got I
			//IL_004a: Expected O, but got I
			nint num = 0;
			object obj = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.PooledDelegate`1+<>c>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12+B8]");
			object obj3 = 0;
			obj3 = obj;
		}

		internal int _003C_002Ecctor_003Eb__4_0()
		{
			//IL_0020: Expected O, but got I
			//IL_0036: Expected O, but got I
			//IL_008a: Expected O, but got I
			//IL_0063: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.PooledDelegate`1+<>c>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v5+135]");
			object obj2 = (nint)0 & (nint)1;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v5+B8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v9+4]");
				return 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v6+B8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v7+4]");
			return 0;
		}
	}

	private static TaskPool<PooledDelegate<T>> pool;

	private PooledDelegate<T> nextNode;

	private readonly Action<T> runDelegate;

	private Action continuation;

	public unsafe ref PooledDelegate<T> NextNode
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected Ref, but got Unknown
			return ref *(PooledDelegate<T>*)(this + 16);
		}
	}

	static PooledDelegate()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0078: Expected O, but got I
		//IL_008d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.PooledDelegate`1>)+10]");
		Type type;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type2 = default(Type);
			type = type2;
		}
		else
		{
			type = null;
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.PooledDelegate`1>)+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v16+B8]");
		object obj4 = 0;
		Func<int> getSize = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
		TaskPool.RegisterSizeGetter(type, getSize);
	}

	private PooledDelegate()
	{
		nint num = 0;
		Action<T> action = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AE82B0");
		runDelegate = action;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static Action<T> Create(Action continuation)
	{
		//IL_0035: Expected O, but got I
		//IL_00dc: Expected O, but got I
		nint num = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.PooledDelegate`1>)+50]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183AEA500");
		object obj2 = default(object);
		object obj3 = default(object);
		object obj4;
		if (obj2 == null)
		{
			nint num3 = 0;
			obj3 = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806AE1A0");
			obj4 = obj3;
		}
		else
		{
			object obj5 = default(object);
			obj4 = obj5;
		}
		if (obj4 != null && obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v34+18]");
			return (Action<T>)0;
		}
		return (Action<T>)(object)new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	private unsafe void Run(T _)
	{
		//IL_0055: Expected O, but got I
		Action action = continuation;
		continuation = null;
		if (continuation != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.PooledDelegate`1>)+50]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v9+B8]");
			bool flag = ((TaskPool<object>*)null)->TryPush(this);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v18.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}
}
