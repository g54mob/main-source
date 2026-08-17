using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks;

public struct TriggerEvent<T>
{
	private ITriggerHandler<T> head;

	private ITriggerHandler<T> iteratingHead;

	private ITriggerHandler<T> iteratingNode;

	private void LogError(Exception ex)
	{
		Debug.LogException(ex);
	}

	public unsafe void SetResult(T value)
	{
		//IL_0027: Expected O, but got Ref
		//IL_01a4: Expected I, but got O
		//IL_005b: Expected O, but got I
		//IL_00f8: Expected O, but got I
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		if (head == null)
		{
			ITriggerHandler<T> triggerHandler = (ITriggerHandler<T>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			object obj7 = default(object);
			ITriggerHandler<T> triggerHandler4 = default(ITriggerHandler<T>);
			while (triggerHandler != null)
			{
				head = triggerHandler;
				nint num = 0;
				nint num2 = (nint)triggerHandler;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r10_v2 (Il2CppClass<Cysharp.Threading.Tasks.ITriggerHandler`1<T>>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_0097;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r10_v2 (Il2CppClass<Cysharp.Threading.Tasks.ITriggerHandler`1<T>>)+B0]");
				object obj = 0;
				ITriggerHandler<T> triggerHandler2 = null;
				while (true)
				{
					object obj2 = (object)triggerHandler2 + (object)triggerHandler2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v2+v386 @ rax_v40*8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v23 (Il2CppRgctx<Cysharp.Threading.Tasks.TriggerEvent`1>)+8]");
					if (num3 == 0)
					{
						break;
					}
					triggerHandler2 = (ITriggerHandler<T>)(triggerHandler2 + 1);
					ITriggerHandler<T> triggerHandler3 = triggerHandler2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r10_v2 (Il2CppClass<Cysharp.Threading.Tasks.ITriggerHandler`1<T>>)+12E]");
					if ((nint)triggerHandler3 < 0)
					{
						continue;
					}
					goto IL_0097;
				}
				object obj3 = (object)triggerHandler2 + (object)triggerHandler2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v2+8+v439 @ rcx_v31*8]");
				object obj4 = (nint)0 << 4;
				object obj5 = obj4 + 312;
				object obj6 = obj5 + num2;
				goto IL_0243;
				IL_0097:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj6 = obj7;
				goto IL_0243;
				IL_0243:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v446 @ r8_v13] (should have been resolved before IL gen)");
				if (triggerHandler == head)
				{
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					triggerHandler = triggerHandler4;
				}
				else
				{
					triggerHandler = head;
				}
			}
			head = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
			if ((nint)0 != 0)
			{
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E716B0");
				_ = 0;
			}
			return;
		}
		object obj8 = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj8;
	}

	public unsafe void SetCanceled(CancellationToken cancellationToken)
	{
		//IL_0027: Expected O, but got Ref
		if (head == null)
		{
			ITriggerHandler<T> triggerHandler = (ITriggerHandler<T>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			ITriggerHandler<T> triggerHandler3 = default(ITriggerHandler<T>);
			while (triggerHandler != null)
			{
				head = triggerHandler;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FA8E0");
				ITriggerHandler<T> triggerHandler2;
				if (triggerHandler == head)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					triggerHandler2 = triggerHandler3;
				}
				else
				{
					triggerHandler2 = head;
				}
				head = null;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E71AB0");
				triggerHandler = triggerHandler2;
			}
			head = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v6 (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
			if ((nint)0 != 0)
			{
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E716B0");
				_ = 0;
			}
			return;
		}
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}

	public unsafe void SetCompleted()
	{
		//IL_0027: Expected O, but got Ref
		if (head == null)
		{
			ITriggerHandler<T> triggerHandler = (ITriggerHandler<T>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			ITriggerHandler<T> triggerHandler3 = default(ITriggerHandler<T>);
			while (triggerHandler != null)
			{
				head = triggerHandler;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				ITriggerHandler<T> triggerHandler2;
				if (triggerHandler == head)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					triggerHandler2 = triggerHandler3;
				}
				else
				{
					triggerHandler2 = head;
				}
				head = null;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E71AB0");
				triggerHandler = triggerHandler2;
			}
			head = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
			if ((nint)0 != 0)
			{
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E716B0");
				_ = 0;
			}
			return;
		}
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}

	public unsafe void SetError(Exception exception)
	{
		//IL_0027: Expected O, but got Ref
		if (head == null)
		{
			ITriggerHandler<T> triggerHandler = (ITriggerHandler<T>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			ITriggerHandler<T> triggerHandler3 = default(ITriggerHandler<T>);
			while (triggerHandler != null)
			{
				head = triggerHandler;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				ITriggerHandler<T> triggerHandler2;
				if (triggerHandler == head)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					triggerHandler2 = triggerHandler3;
				}
				else
				{
					triggerHandler2 = head;
				}
				head = null;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E71AB0");
				triggerHandler = triggerHandler2;
			}
			head = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
			if ((nint)0 != 0)
			{
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E716B0");
				_ = 0;
			}
			return;
		}
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}

	public unsafe void Add(ITriggerHandler<T> handler)
	{
		//IL_0078: Expected O, but got Ref
		//IL_0199: Expected O, but got I
		//IL_0145: Expected O, but got Ref
		//IL_00ec: Expected O, but got I
		//IL_0102: Expected O, but got I4
		//IL_020a: Expected O, but got I
		//IL_0225: Expected O, but got I
		//IL_023b: Expected O, but got I4
		object obj3;
		object obj6;
		object obj7;
		object obj8;
		if (handler != null)
		{
			if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == null)
			{
				return;
			}
			object obj4;
			if (head == null)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				object obj2 = default(object);
				bool flag = obj2 == null;
				obj3 = obj2;
				if (!flag)
				{
					goto IL_00a2;
				}
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
				if ((nint)0 == 0)
				{
					return;
				}
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
				object obj = 0;
				object obj5 = default(object);
				bool flag2 = obj5 != null;
				obj3 = obj5;
				if (flag2)
				{
					goto IL_00a2;
				}
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
				obj4 = 0;
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v20 (Il2CppRgctx<Cysharp.Threading.Tasks.TriggerEvent`1>)+8]");
			obj6 = 0;
			obj7 = obj4;
			obj8 = 5;
			goto IL_0287;
		}
		ArgumentNullException ex = new ArgumentNullException("handler");
		throw ex;
		IL_0287:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
		return;
		IL_00a2:
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ rax_v66 (Il2CppRgctx<Cysharp.Threading.Tasks.TriggerEvent`1>)+8]");
		obj6 = 0;
		obj7 = obj3;
		obj8 = 5;
		goto IL_0287;
	}

	public unsafe void Remove(ITriggerHandler<T> handler)
	{
		//IL_009a: Invalid comparison between O and Ref
		//IL_01b8: Invalid comparison between O and Ref
		//IL_0214: Expected O, but got I
		//IL_01ea: Expected O, but got I
		//IL_0340: Expected O, but got I
		//IL_0356: Expected O, but got I4
		//IL_02d8: Expected O, but got I
		//IL_02eb: Expected O, but got I4
		if (handler != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			ITriggerHandler<T> triggerHandler = default(ITriggerHandler<T>);
			ITriggerHandler<T> triggerHandler3 = default(ITriggerHandler<T>);
			if (triggerHandler != null)
			{
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				ITriggerHandler<T> triggerHandler2 = triggerHandler3;
			}
			if (!System.Runtime.CompilerServices.Unsafe.AreSame(ref *(byte*)handler, ref System.Runtime.CompilerServices.Unsafe.As<TriggerEvent<T>, byte>(ref this)))
			{
				if (triggerHandler3 != null)
				{
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
					ITriggerHandler<T> triggerHandler2 = triggerHandler;
				}
			}
			else
			{
				TriggerEvent<T> triggerEvent = (TriggerEvent<T>)triggerHandler;
			}
			if (handler == head)
			{
				head = triggerHandler;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
			if (handler == null)
			{
			}
			if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) != null)
			{
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj = default(object);
				if (obj == handler)
				{
					if (System.Runtime.CompilerServices.Unsafe.AreSame(ref *(byte*)triggerHandler3, ref System.Runtime.CompilerServices.Unsafe.As<TriggerEvent<T>, byte>(ref this)))
					{
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v854 @ rax_v91 (Il2CppRgctx<Cysharp.Threading.Tasks.TriggerEvent`1>)+8]");
						object obj2 = 0;
						ITriggerHandler<T> triggerHandler2 = null;
					}
					else
					{
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rax_v84 (Il2CppRgctx<Cysharp.Threading.Tasks.TriggerEvent`1>)+8]");
						object obj2 = 0;
						ITriggerHandler<T> triggerHandler2 = triggerHandler3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TriggerEvent`1<T>)+8]");
			if ((nint)0 != 0)
			{
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj3 = default(object);
				if (obj3 == handler)
				{
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj4 = default(object);
					if (triggerHandler3 == obj4)
					{
						nint num10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v945 @ rax_v65 (Il2CppRgctx<Cysharp.Threading.Tasks.TriggerEvent`1>)+8]");
						object obj5 = 0;
						ITriggerHandler<T> triggerHandler4 = null;
						object obj6 = 5;
					}
					else
					{
						nint num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ rax_v58 (Il2CppRgctx<Cysharp.Threading.Tasks.TriggerEvent`1>)+8]");
						object obj5 = 0;
						ITriggerHandler<T> triggerHandler4 = triggerHandler3;
						object obj6 = 5;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				}
			}
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("handler");
		throw ex;
	}
}
