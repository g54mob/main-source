using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public class AsyncLazy
{
	private static Action<object> continuation;

	private Func<UniTask> taskFactory;

	private UniTaskCompletionSource completionSource;

	private UniTask.Awaiter awaiter;

	private object syncLock;

	private bool initialized;

	public unsafe UniTask Task
	{
		get
		{
			//IL_0049: Expected native int or pointer, but got O
			if (!initialized)
			{
				EnsureInitializedCore();
			}
			if (completionSource != null)
			{
				UniTask uniTask = default(UniTask);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, completionSource);
				return uniTask;
			}
			return (UniTask)new NullReferenceException();
		}
	}

	public AsyncLazy(Func<UniTask> taskFactory)
	{
		this.taskFactory = taskFactory;
		UniTaskCompletionSource uniTaskCompletionSource = new UniTaskCompletionSource();
		completionSource = uniTaskCompletionSource;
		object obj = new object();
		syncLock = obj;
		initialized = false;
	}

	internal AsyncLazy(UniTask task)
	{
		taskFactory = null;
		UniTaskCompletionSource uniTaskCompletionSource = new UniTaskCompletionSource();
		completionSource = uniTaskCompletionSource;
		syncLock = null;
		initialized = true;
		if (task.source != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw esi,xmm6,4\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
			object obj = default(object);
			if (obj == null)
			{
				this.awaiter = (UniTask.Awaiter)task.source;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D14B0");
				return;
			}
		}
		UniTask.Awaiter awaiter = default(UniTask.Awaiter);
		SetCompletionSource(ref awaiter);
	}

	public unsafe UniTask.Awaiter GetAwaiter()
	{
		//IL_0066: Expected native int or pointer, but got O
		if (!initialized)
		{
			EnsureInitializedCore();
		}
		if (completionSource == null)
		{
			return (UniTask.Awaiter)new NullReferenceException();
		}
		UniTask.Awaiter awaiter = default(UniTask.Awaiter);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask.Awaiter*)(nint)awaiter)->task, (UniTask)completionSource);
		return awaiter;
	}

	private void EnsureInitialized()
	{
		if (!initialized)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 17 Invalid \"Jump target not found in method: 0x185D45DE0\"");
		}
	}

	private unsafe void EnsureInitializedCore()
	{
		//IL_01db: Expected I, but got O
		//IL_0058: Expected I, but got I8
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0099: Expected I, but got I8
		//IL_00b7: Expected O, but got I
		//IL_017f: Expected O, but got I4
		//IL_011d: Expected I, but got O
		//IL_0158: Expected O, but got I
		//IL_0167: Expected I, but got O
		object obj = default(object);
		if (obj == null)
		{
			object obj2 = default(object);
			if (obj2 != null)
			{
				nint num;
				if (obj == null)
				{
					Monitor.Enter(obj2);
					num = unchecked((nint)4294967295L);
					if (!initialized)
					{
						object obj3 = this + 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807B0C80");
						object obj4 = default(object);
						bool flag = obj4 == null;
						num = unchecked((nint)4294967295L);
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v28+18]");
							Action<object> action = (Action<object>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v28+40]");
							num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v238 @ rax_v28+18] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1842F6520");
							object obj5 = default(object);
							UniTask.Awaiter awaiter = default(UniTask.Awaiter);
							if (obj5 == null)
							{
								this.awaiter = awaiter;
								Action<object> action2 = continuation;
								if ((object)awaiter != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw eax,xmm6,4\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D14B0");
									UniTask.Awaiter awaiter2 = awaiter;
									action = continuation;
									num = (nint)typeof(IUniTaskSource);
								}
								else
								{
									bool flag2 = continuation == null;
									UniTask.Awaiter awaiter2 = awaiter;
									if (flag2)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdi_v8 (System.Action`1<System.Object>)+28]");
									awaiter2 = (UniTask.Awaiter)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v296 @ rdi_v8 (System.Action`1<System.Object>)+18] (should have been resolved before IL gen)");
									num = (nint)this;
								}
							}
							else
							{
								SetCompletionSource(ref awaiter);
								UniTask.Awaiter awaiter2 = (UniTask.Awaiter)0;
								num = (nint)(&awaiter);
							}
							initialized = true;
						}
					}
					object obj6 = default(object);
					if (obj6 != null)
					{
						if (obj2 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj7 = default(object);
							throw obj7;
						}
						Monitor.Exit(obj2);
					}
					return;
				}
				ArgumentException ex = new ArgumentException();
				num = unchecked((nint)null);
				throw ex;
			}
			ArgumentNullException ex2 = new ArgumentNullException("obj");
			ex2._002Ector("obj");
			throw ex2;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}

	private void SetCompletionSource([In] ref UniTask.Awaiter awaiter)
	{
		if ((object)awaiter != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
		}
		bool flag = completionSource.TrySignalCompletion(UniTaskStatus.Succeeded);
	}

	private static void SetCompletionSource(object state)
	{
		//IL_012e: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_0059: Expected O, but got I
		//IL_00d9: Expected O, but got I4
		//IL_00f4: Expected O, but got I
		nint num = (nint)typeof(AsyncLazy);
		object obj = default(object);
		if (obj != null)
		{
			nint num2 = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<Cysharp.Threading.Tasks.AsyncLazy>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v9 (Il2CppClass<System.Object>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<Cysharp.Threading.Tasks.AsyncLazy>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v9 (Il2CppClass<System.Object>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v28+FFFFFFF8+v42 @ rax_v27 (System.Object)*8]");
				if (0 == (nint)typeof(AsyncLazy))
				{
					goto IL_0086;
				}
			}
			throw new InvalidCastException();
		}
		goto IL_0086;
		IL_0086:
		object obj4 = default(object);
		if (obj4 != null)
		{
			object obj5 = obj4 + 32;
			object obj6 = obj4;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
				obj6 = obj4;
				object obj7 = 2;
			}
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v15+18]");
				bool flag = ((UniTaskCompletionSource)0).TrySignalCompletion(UniTaskStatus.Succeeded);
				_ = 0;
				return;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	static AsyncLazy()
	{
		Action<object> action = SetCompletionSource;
		continuation = action;
	}
}
public class AsyncLazy<T>
{
	private static Action<object> continuation;

	private Func<UniTask<T>> taskFactory;

	private UniTaskCompletionSource<T> completionSource;

	private UniTask<T>.Awaiter awaiter;

	private object syncLock;

	private bool initialized;

	public unsafe UniTask<T> Task
	{
		get
		{
			//IL_0008: Expected O, but got Ref
			//IL_0018: Expected O, but got I
			//IL_0037: Expected O, but got I
			//IL_0047: Expected O, but got I
			//IL_005d: Expected O, but got I
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			//IL_0132: Expected O, but got I
			//IL_0142: Expected O, but got I
			//IL_0152: Expected O, but got I
			//IL_016c: Expected O, but got I
			//IL_017c: Expected O, but got I
			//IL_018c: Expected O, but got I
			//IL_019c: Expected O, but got I
			//IL_01ac: Expected O, but got I
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Expected O, but got Unknown
			//IL_008e: Expected O, but got I8
			//IL_00b0: Expected O, but got I
			//IL_00be: Expected O, but got Ref
			//IL_00d3: Expected O, but got I
			//IL_00e3: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v1+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r9_v1+20]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
			object obj6 = (nint)0 + (nint)15;
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
			if ((nint)obj7 <= 0)
			{
				obj6 = 1152921504606846960L;
			}
			object obj8 = obj6 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v5+C0]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v1+70]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v48 @ rax_v6] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v8+C0]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v3+8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v9+80]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v4+50]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v4+58]");
			object obj17 = 0 + this;
			object obj18 = obj17 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v10+28]");
			if ((nint)0 >= (nint)0)
			{
				obj18 = obj17;
			}
			if (obj18 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
				object obj19 = 0;
				object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12+C0]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v7+78]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v89 @ r10_v1+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				UniTask<T> result = default(UniTask<T>);
				return result;
			}
			return (UniTask<T>)new NullReferenceException();
		}
	}

	public AsyncLazy(Func<UniTask<T>> taskFactory)
	{
		//IL_0141: Expected O, but got I
		//IL_0151: Expected O, but got I
		//IL_0161: Expected O, but got I
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_00ca: Expected O, but got I
		//IL_00da: Expected O, but got I
		//IL_00ea: Expected O, but got I
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_002b: Expected O, but got I
		//IL_004b: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_006b: Expected O, but got I
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_01ec: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_020c: Expected O, but got I
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_01c4: Expected O, but got I4
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v3+80]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdx_v1+30]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdx_v1+38]");
		object obj4 = 0 + this;
		object obj5 = obj4 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v4+28]");
		object obj6 = default(object);
		object obj12;
		if ((nint)0 < (nint)0)
		{
			obj5 = taskFactory;
			nint num2 = 0;
			obj6 = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+18]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v148 @ r8_v4] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v11+80]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v6+50]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v6+58]");
			object obj11 = 0 + this;
			obj12 = obj11 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v12+28]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_00ab;
			}
		}
		obj12 = obj6;
		goto IL_00ab;
		IL_00ab:
		object obj13 = new object();
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v16+80]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdx_v9+90]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdx_v9+98]");
		object obj17 = 0 + this;
		object obj18 = obj17 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v17+28]");
		if ((nint)0 < (nint)0)
		{
			obj18 = obj13;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rcx_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v15+80]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rcx_v20+B0]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rcx_v20+B8]");
			object obj22 = 0 + this;
			object obj23 = obj22 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v16+28]");
			if ((nint)0 >= (nint)0)
			{
				/*Error: End of method reached without returning.*/;
			}
			obj23 = 0;
		}
	}

	internal unsafe AsyncLazy(UniTask<T> task)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002d: Expected O, but got I
		//IL_0043: Expected O, but got I
		//IL_026f: Expected O, but got I
		//IL_02b8: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_02d8: Expected O, but got I
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_0088: Expected O, but got I
		//IL_00a8: Expected O, but got I
		//IL_00b8: Expected O, but got I
		//IL_00c8: Expected O, but got I
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_0321: Expected O, but got I4
		//IL_0116: Expected O, but got Ref
		//IL_0131: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_0366: Expected O, but got I
		//IL_0376: Expected O, but got I
		//IL_0386: Expected O, but got I
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		//IL_0240: Expected O, but got I
		//IL_033c: Expected O, but got I4
		//IL_03dc: Expected O, but got I
		//IL_03ec: Expected O, but got I
		//IL_03fc: Expected O, but got I
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected O, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_01ab: Expected O, but got I
		//IL_01c1: Expected O, but got I
		//IL_034a: Expected O, but got I4
		//IL_01f0: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_021b: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
		if ((nint)obj4 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			object obj5 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			if ((nint)obj5 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v13+80]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v4+30]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v4+38]");
			object obj9 = 0 + this;
			object obj10 = obj9 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v14+28]");
			if ((nint)0 >= (nint)0)
			{
			}
			obj10 = 0;
		}
		nint num3 = 0;
		object obj11 = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rdx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+18]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v183 @ r8_v5] (should have been resolved before IL gen)");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v13+80]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdx_v8+50]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdx_v8+58]");
		object obj16 = 0 + this;
		object obj17 = obj16 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rcx_v14+28]");
		if ((nint)0 < (nint)0)
		{
			obj17 = obj11;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v16 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v23+80]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v17+90]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v17+98]");
			object obj21 = 0 + this;
			object obj22 = obj21 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v24+28]");
			if ((nint)0 < (nint)0)
			{
				obj22 = 0;
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v27+80]");
			object obj24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v20+B0]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v20+B8]");
			object obj26 = 0 + this;
			object obj27 = obj26 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v28+28]");
			if ((nint)0 >= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				/*Error: End of method reached without returning.*/;
			}
			obj27 = 1;
		}
		object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = ref obj2;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rcx_v22 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+28]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v438 @ r10_v4+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v25 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+40]");
		object obj30 = 0;
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v468 @ rax_v34] (should have been resolved before IL gen)");
		object obj31 = default(object);
		if (obj31 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v32 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
			object obj32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ rax_v42+80]");
			object obj33 = (nint)0 + (nint)96;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rcx_v37 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+60]");
			object obj34 = 0;
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rax_v50+B8]");
			object obj35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ r8_v21 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+68]");
			object obj36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v506 @ r10_v6] (should have been resolved before IL gen)");
		}
		else
		{
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rcx_v29 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+50]");
			object obj37 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v492 @ r9_v7] (should have been resolved before IL gen)");
		}
	}

	public unsafe UniTask<T>.Awaiter GetAwaiter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_002d: Expected O, but got I
		//IL_003d: Expected O, but got I
		//IL_004d: Expected O, but got I
		//IL_005d: Expected O, but got I
		//IL_006d: Expected O, but got I
		//IL_0083: Expected O, but got I
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0167: Expected O, but got I
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01b9: Expected O, but got I
		//IL_00b4: Expected O, but got I8
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_020f: Expected O, but got I
		//IL_021d: Expected O, but got Ref
		//IL_0232: Expected O, but got I
		//IL_0242: Expected O, but got I
		//IL_00c6: Expected O, but got I8
		//IL_00ed: Expected O, but got I
		//IL_00fb: Expected O, but got Ref
		//IL_0110: Expected O, but got I
		//IL_0120: Expected O, but got I
		//IL_00d8: Expected O, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v1+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ r9_v1+20]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+20]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3+C0]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ r9_v2+38]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v4+FC]");
		object obj9 = (nint)0 + (nint)15;
		object obj10 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v4+FC]");
		if ((nint)obj10 <= 0)
		{
			obj9 = 1152921504606846960L;
		}
		object obj11 = obj9 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rax_v2+FC]");
		object obj12 = (nint)0 + (nint)15;
		object obj13 = obj12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rax_v2+FC]");
		if ((nint)obj13 <= 0)
		{
			obj12 = 1152921504606846960L;
		}
		object obj14 = obj12 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rax_v2+FC]");
		object obj15 = (nint)0 + (nint)15;
		object obj16 = obj15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rax_v2+FC]");
		if ((nint)obj16 <= 0)
		{
			obj15 = 1152921504606846960L;
		}
		object obj17 = obj15 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+20]");
		object obj18 = 0;
		object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v12+C0]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v8+80]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ r10_v1+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+20]");
		object obj22 = 0;
		object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v15+C0]");
		object obj24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v11+28]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v125 @ r10_v2+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		UniTask<T>.Awaiter result = default(UniTask<T>.Awaiter);
		return result;
	}

	private void EnsureInitialized()
	{
		//IL_0016: Expected O, but got I
		//IL_0026: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_009e: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v2+80]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ r8_v2+B0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ r8_v2+B8]");
		object obj4 = 0 + this;
		object obj5 = obj4 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v3+28]");
		if ((nint)0 >= (nint)0)
		{
			obj5 = obj4;
		}
		if (obj5 == null)
		{
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+88]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v41 @ rax_v6] (should have been resolved before IL gen)");
		}
	}

	private unsafe void EnsureInitializedCore()
	{
		//IL_0008: Expected O, but got Ref
		//IL_001e: Expected O, but got I
		//IL_0041: Expected O, but got I
		//IL_0057: Expected O, but got I
		//IL_0485: Expected O, but got I
		//IL_04c4: Expected O, but got I
		//IL_05dc: Expected O, but got Ref
		//IL_05ef: Expected O, but got Ref
		//IL_04f5: Expected O, but got Ref
		//IL_0515: Expected O, but got I
		//IL_055e: Expected O, but got I
		//IL_056e: Expected O, but got I
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected O, but got Unknown
		//IL_0590: Expected O, but got I
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Expected O, but got Unknown
		//IL_0421: Expected O, but got I4
		//IL_0431: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_00fc: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_012e: Expected O, but got I
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_0664: Expected O, but got I
		//IL_0184: Expected O, but got I
		//IL_0194: Expected O, but got I
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b6: Expected O, but got I
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_069b: Expected O, but got I
		//IL_0404: Expected O, but got I
		//IL_020c: Expected O, but got I
		//IL_0222: Expected O, but got I
		//IL_0235: Expected O, but got Ref
		//IL_025f: Expected O, but got I
		//IL_0272: Expected O, but got Ref
		//IL_02a1: Expected O, but got I
		//IL_03a1: Expected O, but got I
		//IL_03bf: Expected O, but got I
		//IL_06e4: Expected O, but got I
		//IL_06f4: Expected O, but got I
		//IL_0701: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Expected O, but got Unknown
		//IL_0716: Expected O, but got I
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected O, but got Unknown
		//IL_02f1: Expected O, but got I
		//IL_0307: Expected O, but got I
		//IL_0761: Expected O, but got I4
		//IL_0336: Expected O, but got I
		//IL_034b: Expected O, but got I
		//IL_0361: Expected O, but got I
		//IL_0377: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
		_ = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ r8_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+38]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v4+FC]");
		object obj5 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v4+FC]");
		object obj11 = default(object);
		object obj13;
		if ((nint)obj5 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
			object obj6 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
			if ((nint)obj6 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
			object obj7 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
			if ((nint)obj7 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			obj = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v4+FC]");
			object obj8 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v4+FC]");
			if ((nint)obj8 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v25+80]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v5+98]");
			obj11 = 0 + this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v5+90]");
			object obj12 = 0;
			obj13 = obj11 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v26+28]");
			if ((nint)0 < (nint)0)
			{
				goto IL_05c3;
			}
		}
		obj13 = obj11;
		goto IL_05c3;
		IL_0744:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
		object obj14 = default(object);
		throw obj14;
		IL_05c3:
		_ = 0;
		object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+90]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+A0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+90]");
				object obj19;
				AsyncLazy<T> asyncLazy;
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+A0]");
					Monitor.Enter(0);
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v23 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
					object obj17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v48+80]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v24+B8]");
					obj19 = 0 + this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v24+B0]");
					object obj20 = 0;
					object obj21 = obj19 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v49+28]");
					if ((nint)0 >= (nint)0)
					{
						obj21 = obj19;
					}
					bool flag = obj21 != null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v4+FC]");
					asyncLazy = (AsyncLazy<T>)0;
					if (!flag)
					{
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rcx_v30 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v55+80]");
						object obj23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v31+38]");
						obj19 = 0 + this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v31+30]");
						object obj24 = 0;
						object obj25 = obj19 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rax_v56+28]");
						if ((nint)0 >= (nint)0)
						{
							obj25 = obj19;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807B0C80");
						object obj26 = default(object);
						bool flag2 = obj26 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v4+FC]");
						asyncLazy = (AsyncLazy<T>)0;
						if (!flag2)
						{
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdx_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+98]");
							object obj27 = 0;
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ r8_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+98]");
							object obj28 = 0;
							_ = ref obj2;
							object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v462 @ rdx_v20+10] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rcx_v38 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+28]");
							object obj30 = 0;
							_ = ref obj2;
							object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v476 @ rdx_v22+10] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rcx_v41 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+40]");
							object obj32 = 0;
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v487 @ rax_v65] (should have been resolved before IL gen)");
							object obj33 = default(object);
							if (obj33 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
								nint num11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rcx_v54 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
								object obj34 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rax_v78+80]");
								object obj35 = (nint)0 + (nint)96;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
								nint num12 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rcx_v59 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+60]");
								object obj36 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v86+B8]");
								object obj37 = 0;
								nint num13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ r8_v20 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+68]");
								object obj38 = 0;
								nint num14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ r8_v21 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+68]");
								object obj39 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v604 @ rax_v89] (should have been resolved before IL gen)");
								asyncLazy = this;
							}
							else
							{
								nint num15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rcx_v50 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+50]");
								object obj40 = 0;
								object obj39 = obj40;
								nint num16 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v513 @ rcx_v51 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+50]");
								asyncLazy = (AsyncLazy<T>)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v510 @ rax_v73] (should have been resolved before IL gen)");
							}
							nint num17 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rcx_v45 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
							object obj41 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v70+80]");
							object obj42 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rcx_v46+B8]");
							obj19 = 0 + this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rcx_v46+B0]");
							object obj43 = 0;
							object obj44 = obj19 - 16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rax_v71+28]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_0744;
							}
							obj44 = 1;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+90]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+A0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+A0]");
							Monitor.Exit(0);
							return;
						}
						goto IL_0744;
					}
					return;
				}
				ArgumentException ex = new ArgumentException();
				obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v4+FC]");
				asyncLazy = (AsyncLazy<T>)0;
				throw ex;
			}
			ArgumentNullException ex2 = new ArgumentNullException("obj");
			ex2._002Ector("obj");
			throw ex2;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}

	private unsafe void SetCompletionSource([In] ref UniTask<T>.Awaiter awaiter)
	{
		//IL_0008: Expected O, but got Ref
		//IL_001e: Expected O, but got I
		//IL_0034: Expected O, but got I
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_01a5: Expected O, but got I
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e9: Expected O, but got Ref
		//IL_01ff: Expected O, but got I
		//IL_0065: Expected O, but got I8
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_025b: Expected O, but got I
		//IL_026e: Expected O, but got Ref
		//IL_0077: Expected O, but got I8
		//IL_00a4: Expected O, but got I
		//IL_00b4: Expected O, but got I
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00d6: Expected O, but got I
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_0089: Expected O, but got I8
		//IL_012c: Expected O, but got I
		//IL_0142: Expected O, but got I
		//IL_015c: Expected O, but got Ref
		//IL_02ac: Expected O, but got I
		//IL_02bf: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+A8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v2+FC]");
		if ((nint)obj5 <= 0)
		{
			obj4 = 1152921504606846960L;
		}
		object obj6 = obj4 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v2+FC]");
		object obj7 = (nint)0 + (nint)15;
		object obj8 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v2+FC]");
		if ((nint)obj8 <= 0)
		{
			obj7 = 1152921504606846960L;
		}
		object obj9 = obj7 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		object obj10 = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v2+FC]");
		object obj11 = (nint)0 + (nint)15;
		object obj12 = obj11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v2+FC]");
		if ((nint)obj12 <= 0)
		{
			obj11 = 1152921504606846960L;
		}
		object obj13 = obj11 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+A0]");
		object obj14 = 0;
		_ = ref obj2;
		object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v107 @ rdx_v3+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+8]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v15+80]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v12+58]");
		object obj18 = 0 + this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v12+50]");
		object obj19 = 0;
		object obj20 = obj18 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v16+28]");
		if ((nint)0 >= (nint)0)
		{
			obj20 = obj18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v16 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+A8]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v20+28]");
		object obj22 = (nint)0 >> 31;
		bool flag = obj22 != null;
		object obj23 = (object)(&obj2);
		if (!flag)
		{
			obj23 = obj10;
		}
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rcx_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+B0]");
		object obj24 = 0;
		object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v176 @ rdx_v6+10] (should have been resolved before IL gen)");
	}

	private unsafe static void SetCompletionSource(object state)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0420: Expected O, but got I
		//IL_0023: Expected O, but got I
		//IL_0046: Expected O, but got I
		//IL_0445: Expected O, but got I
		//IL_0075: Expected O, but got I
		//IL_0085: Expected O, but got I
		//IL_0476: Expected O, but got Ref
		//IL_048c: Expected O, but got I
		//IL_04cf: Expected O, but got I
		//IL_04df: Expected O, but got I
		//IL_0128: Expected O, but got Ref
		//IL_013b: Expected O, but got Ref
		//IL_014e: Expected O, but got Ref
		//IL_0183: Expected O, but got I
		//IL_0193: Expected O, but got I
		//IL_055e: Expected O, but got I
		//IL_056e: Expected O, but got I
		//IL_057e: Expected O, but got I
		//IL_059b: Expected O, but got I
		//IL_05ab: Expected O, but got I
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Expected O, but got Unknown
		//IL_0092: Expected I, but got O
		//IL_00a2: Expected O, but got I
		//IL_0710: Expected O, but got I
		//IL_05ee: Expected O, but got I
		//IL_05fe: Expected O, but got I
		//IL_060e: Expected O, but got I
		//IL_00e6: Expected O, but got I
		//IL_01b5: Expected O, but got I
		//IL_01c5: Expected O, but got I
		//IL_01d8: Expected O, but got Ref
		//IL_01fc: Expected O, but got I
		//IL_020c: Expected O, but got I
		//IL_021c: Expected O, but got I
		//IL_0231: Expected O, but got I
		//IL_0241: Expected O, but got I
		//IL_0251: Expected O, but got I
		//IL_026e: Expected O, but got I
		//IL_027e: Expected O, but got I
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_0634: Expected O, but got Ref
		//IL_02ce: Expected O, but got I
		//IL_02de: Expected O, but got I
		//IL_0662: Expected O, but got I
		//IL_0672: Expected O, but got I
		//IL_0688: Expected O, but got I
		//IL_06a2: Expected O, but got Ref
		//IL_0725: Expected O, but got I
		//IL_06c0: Expected O, but got I
		//IL_06d0: Expected O, but got I
		//IL_06e0: Expected O, but got I
		//IL_0300: Expected O, but got I
		//IL_0310: Expected O, but got I
		//IL_0330: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+A8]");
		object obj3 = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+38]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v4+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+FC]");
		object obj5 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+FC]");
		object obj7 = default(object);
		if ((nint)obj5 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+FC]");
			object obj6 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+FC]");
			if ((nint)obj6 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			obj7 = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+FC]");
			object obj8 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+FC]");
			if ((nint)obj8 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+A8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v21+20]");
			object obj10 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v23+C0]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v24+8]");
		object obj12 = 0;
		object obj14;
		if (state != null)
		{
			nint num3 = (nint)state;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v4+130]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v16 (Il2CppClass<System.Object>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v4+130]");
			bool flag = num4 < 0;
			obj14 = state;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v16 (Il2CppClass<System.Object>)+C8]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v88+FFFFFFF8+v173 @ rax_v87*8]");
				bool flag2 = 0 != (nint)obj12;
				obj14 = state;
				if (!flag2)
				{
					goto IL_0115;
				}
			}
			throw new InvalidCastException();
		}
		goto IL_0115;
		IL_0115:
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+A8]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ r8_v7+20]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v42+C0]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v43+8]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rcx_v20+80]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v8+78]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+B8]");
		object obj24 = num5 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v8+70]");
		object obj25 = 0;
		object obj26 = obj24 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v44+28]");
		if ((nint)0 >= (nint)0)
		{
			obj26 = obj24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ r8_v7+20]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v46+C0]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v47+A0]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ r8_v7+20]");
		object obj30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v49+C0]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v50+A0]");
		object obj32 = 0;
		_ = ref obj2;
		object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v361 @ rbx_v6+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+B8]");
		obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+A8]");
		object obj34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rax_v54+20]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rax_v56+C0]");
		object obj36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v57+8]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v29+80]");
		object obj38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ r8_v10+58]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+B8]");
		object obj39 = num6 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ r8_v10+50]");
		object obj40 = 0;
		object obj41 = obj39 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rax_v58+28]");
		if ((nint)0 >= (nint)0)
		{
			obj41 = obj39;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		bool flag3 = obj41 == null;
		object obj42 = (object)(&obj2);
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+A8]");
			object obj43 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rdx_v15+20]");
			object obj44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v66+C0]");
			object obj45 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v67+A8]");
			object obj46 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rcx_v35+28]");
			object obj47 = (nint)0 >> 31;
			bool flag4 = obj47 != null;
			object obj48 = (object)(&obj2);
			if (!flag4)
			{
				obj48 = obj7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rdx_v15+20]");
			object obj49 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v71+C0]");
			object obj50 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v72+B0]");
			obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rdx_v15+20]");
			object obj51 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v74+C0]");
			object obj52 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rax_v75+B0]");
			object obj53 = 0;
			obj = obj48;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v271 @ rbx_v2 (System.Object)+10] (should have been resolved before IL gen)");
			object obj54 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184121B20");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+38]");
			if ((nint)0 == 0)
			{
				return;
			}
			throw null;
		}
		throw new NullReferenceException();
	}

	static AsyncLazy()
	{
		//IL_003c: Expected O, but got I
		//IL_0051: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+C0]");
		Action<object> action = new Action<object>(null, (IntPtr)0);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+C0]");
		action._002Ector((object)null, (IntPtr)0);
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncLazy`1>)+60]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+B8]");
		object obj2 = 0;
		obj2 = action;
	}
}
