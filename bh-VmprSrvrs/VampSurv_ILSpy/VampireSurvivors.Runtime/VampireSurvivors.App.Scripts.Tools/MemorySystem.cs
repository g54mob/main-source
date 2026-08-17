using System;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Profiling;
using Zenject;

namespace VampireSurvivors.App.Scripts.Tools;

public class MemorySystem : IInitializable, IDisposable
{
	public delegate void LowOnMemoryEvent();

	public static LowOnMemoryEvent OnLowMemoryEvent;

	public void Initialize()
	{
		Application.LowMemoryCallback b = OnApplicationLowOnMemory;
		Delegate obj = Application.lowMemory;
		while (true)
		{
			Delegate obj2 = Delegate.Combine(obj, b);
			bool flag = (object)obj2 == null;
			Delegate obj3 = null;
			if (!flag)
			{
				bool flag2 = (object)obj2.GetType() != typeof(Application.LowMemoryCallback);
				obj3 = null;
				if (!flag2)
				{
					obj3 = obj2;
				}
				if ((object)obj3 == null)
				{
					break;
				}
			}
			bool flag3 = (object)obj == Application.lowMemory;
			Delegate obj4;
			if ((object)obj == Application.lowMemory)
			{
				Application.lowMemory = (Application.LowMemoryCallback)obj3;
				obj4 = obj;
			}
			else
			{
				obj4 = Application.lowMemory;
			}
			Delegate obj5 = obj;
			if (!flag3)
			{
				obj5 = obj4;
			}
			bool flag4 = (object)obj5 != obj;
			obj = obj5;
			if (!flag4)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	public void Dispose()
	{
		Application.LowMemoryCallback value = OnApplicationLowOnMemory;
		Delegate obj = Application.lowMemory;
		while (true)
		{
			Delegate obj2 = Delegate.Remove(obj, value);
			bool flag = (object)obj2 == null;
			Delegate obj3 = null;
			if (!flag)
			{
				bool flag2 = (object)obj2.GetType() != typeof(Application.LowMemoryCallback);
				obj3 = null;
				if (!flag2)
				{
					obj3 = obj2;
				}
				if ((object)obj3 == null)
				{
					break;
				}
			}
			bool flag3 = (object)obj == Application.lowMemory;
			Delegate obj4;
			if ((object)obj == Application.lowMemory)
			{
				Application.lowMemory = (Application.LowMemoryCallback)obj3;
				obj4 = obj;
			}
			else
			{
				obj4 = Application.lowMemory;
			}
			Delegate obj5 = obj;
			if (!flag3)
			{
				obj5 = obj4;
			}
			bool flag4 = (object)obj5 != obj;
			obj = obj5;
			if (!flag4)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	public static long GetTotalAllocatedMemoryInBytes()
	{
		//IL_0006: Expected O, but got I
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ rax_v2 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public unsafe static void LogMemoryStats()
	{
		//IL_009f: Expected O, but got I8
		//IL_00cf: Expected O, but got Ref
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = stringBuilder.Append("[SYSTEM] Current RAM stats:");
		string newLine = Environment.NewLine;
		StringBuilder stringBuilder3 = stringBuilder.Append(newLine);
		object obj = Profiler.GetTotalAllocatedMemoryLong();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string value = string.FormatHelper((IFormatProvider)null, "Allocated: {0}mb", (System.ParamsArray)(&obj2));
		StringBuilder stringBuilder4 = stringBuilder.Append(value);
		string newLine2 = Environment.NewLine;
		StringBuilder stringBuilder5 = stringBuilder.Append(newLine2);
		string message = stringBuilder.ToString();
		Debug.LogWarning(message);
	}

	private void OnApplicationLowOnMemory()
	{
		LowOnMemoryEvent onLowMemoryEvent = OnLowMemoryEvent;
		if (OnLowMemoryEvent != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v31.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		Debug.LogWarning("[SYSTEM] Unity is reporting we are low on memory");
		LogMemoryStats();
	}
}
