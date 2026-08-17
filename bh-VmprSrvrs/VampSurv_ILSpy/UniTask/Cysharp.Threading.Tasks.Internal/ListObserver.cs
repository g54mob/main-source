using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal class ListObserver<T>(ImmutableList<IObserver<T>> observers) : IObserver<T>
{
	private readonly ImmutableList<IObserver<T>> _observers = observers;

	public void OnCompleted()
	{
		//IL_0025: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_016e: Expected I, but got O
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0085: Expected O, but got I
		//IL_008e: Expected O, but got I4
		//IL_0117: Expected O, but got I
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		ImmutableList<IObserver<T>> observers = _observers;
		IObserver<T>[] data = observers.data;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < data.Length)
		{
			IObserver<T> observer = data[obj2];
			nint num = 0;
			nint num2 = (nint)observer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+12E]");
			if ((nint)0 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+B0]");
				object obj3 = 0;
				object obj4 = 0;
				while (true)
				{
					object obj5 = obj4 + obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v3+v219 @ rax_v15*8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ListObserver`1>)+20]");
					if (num3 == 0)
					{
						break;
					}
					obj4++;
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+12E]");
					if ((nint)obj6 < 0)
					{
						continue;
					}
					goto IL_00c5;
				}
				object obj7 = obj4 + obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r9_v3+8+v248 @ rcx_v11*8]");
				object obj8 = (nint)0 + (nint)2;
				object obj9 = obj8 << 4;
				object obj10 = obj9 + 312;
				object obj11 = obj10 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v254 @ rax_v21] (should have been resolved before IL gen)");
				obj2++;
				obj = obj2;
				continue;
			}
			goto IL_00c5;
			IL_00c5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v231 @ rax_v10] (should have been resolved before IL gen)");
			obj2++;
			obj = obj2;
		}
	}

	public void OnError(Exception error)
	{
		//IL_0025: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0153: Expected I, but got O
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0085: Expected O, but got I
		//IL_008e: Expected O, but got I4
		//IL_011c: Expected O, but got I
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		ImmutableList<IObserver<T>> observers = _observers;
		IObserver<T>[] data = observers.data;
		object obj = 0;
		for (object obj2 = 0; (nint)obj < data.Length; Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v262 @ rax_v9] (should have been resolved before IL gen)"), obj2++, obj = obj2)
		{
			IObserver<T> observer = data[obj2];
			nint num = 0;
			nint num2 = (nint)observer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+12E]");
			if ((nint)0 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+B0]");
				object obj3 = 0;
				object obj4 = 0;
				while (true)
				{
					object obj5 = obj4 + obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r9_v3+v211 @ rax_v16*8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ListObserver`1>)+20]");
					if (num3 == 0)
					{
						break;
					}
					obj4++;
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+12E]");
					if ((nint)obj6 < 0)
					{
						continue;
					}
					goto IL_00c5;
				}
				object obj7 = obj4 + obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r9_v3+8+v261 @ rcx_v12*8]");
				object obj8 = (nint)0 + (nint)1;
				object obj9 = obj8 << 4;
				object obj10 = obj9 + 312;
				object obj11 = obj10 + num2;
				continue;
			}
			goto IL_00c5;
			IL_00c5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
		}
	}

	public void OnNext(T value)
	{
		//IL_0025: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0160: Expected I, but got O
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0085: Expected O, but got I
		//IL_008e: Expected O, but got I4
		//IL_0117: Expected O, but got I
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		ImmutableList<IObserver<T>> observers = _observers;
		IObserver<T>[] data = observers.data;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < data.Length)
		{
			IObserver<T> observer = data[obj2];
			nint num = 0;
			nint num2 = (nint)observer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+12E]");
			if ((nint)0 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+B0]");
				object obj3 = 0;
				object obj4 = 0;
				while (true)
				{
					object obj5 = obj4 + obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r9_v3+v225 @ rax_v15*8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ListObserver`1>)+20]");
					if (num3 == 0)
					{
						break;
					}
					obj4++;
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r10_v3 (Il2CppClass<System.IObserver`1<T>>)+12E]");
					if ((nint)obj6 < 0)
					{
						continue;
					}
					goto IL_00c5;
				}
				object obj7 = obj4 + obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r9_v3+8+v255 @ rdx_v7*8]");
				object obj8 = (nint)0 << 4;
				object obj9 = obj8 + 312;
				object obj10 = obj9 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ rax_v19] (should have been resolved before IL gen)");
				obj2++;
				obj = obj2;
				continue;
			}
			goto IL_00c5;
			IL_00c5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v238 @ rax_v10] (should have been resolved before IL gen)");
			obj2++;
			obj = obj2;
		}
	}

	internal IObserver<T> Add(IObserver<T> observer)
	{
		if (_observers != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18364EB20");
			nint num2 = 0;
			return null;
		}
		return (IObserver<T>)new NullReferenceException();
	}

	internal IObserver<T> Remove(IObserver<T> observer)
	{
		//IL_0032: Expected O, but got I
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		ImmutableList<IObserver<T>> observers = _observers;
		IObserver<T>[] data = observers.data;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ r9_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ListObserver`1>)+58]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdi_v4+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		if (observers.data != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507B80");
			object obj2 = default(object);
			IObserver<T> result;
			if ((nint)obj2 >= 0)
			{
				ImmutableList<IObserver<T>> observers2 = _observers;
				IObserver<T>[] data2 = observers2.data;
				if (data2.Length != 2)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18364ED20");
					nint num3 = 0;
					result = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D0380");
				}
				else
				{
					object obj3 = 1 - obj2;
					result = data2[obj3];
				}
			}
			else
			{
				result = this;
			}
			return result;
		}
		ArgumentNullException ex = new ArgumentNullException("array");
		ex._002Ector("array");
		throw ex;
	}
}
