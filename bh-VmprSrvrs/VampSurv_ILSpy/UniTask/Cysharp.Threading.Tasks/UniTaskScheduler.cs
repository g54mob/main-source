using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks;

public static class UniTaskScheduler
{
	private static Action<Exception> m_UnobservedTaskException;

	public static bool PropagateOperationCanceledException = false;

	public static LogType UnobservedExceptionWriteLogType = LogType.Exception;

	public static bool DispatchUnityMainThread = true;

	private static readonly SendOrPostCallback handleExceptionInvoke;

	public static event Action<Exception> UnobservedTaskException
	{
		add
		{
			Delegate obj = UniTaskScheduler.m_UnobservedTaskException;
			Action<Exception> action = default(Action<Exception>);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				Action<Exception> unobservedTaskException;
				if ((object)obj2 == null)
				{
					unobservedTaskException = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = action == null;
					unobservedTaskException = action;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = (object)obj == UniTaskScheduler.m_UnobservedTaskException;
				Delegate obj3;
				if ((object)obj == UniTaskScheduler.m_UnobservedTaskException)
				{
					UniTaskScheduler.m_UnobservedTaskException = unobservedTaskException;
					obj3 = obj;
				}
				else
				{
					obj3 = UniTaskScheduler.m_UnobservedTaskException;
				}
				Delegate obj4 = obj;
				if (!flag2)
				{
					obj4 = obj3;
				}
				bool flag3 = (object)obj4 != obj;
				obj = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			Delegate obj = UniTaskScheduler.m_UnobservedTaskException;
			Action<Exception> action = default(Action<Exception>);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				Action<Exception> unobservedTaskException;
				if ((object)obj2 == null)
				{
					unobservedTaskException = null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = action == null;
					unobservedTaskException = action;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = (object)obj == UniTaskScheduler.m_UnobservedTaskException;
				Delegate obj3;
				if ((object)obj == UniTaskScheduler.m_UnobservedTaskException)
				{
					UniTaskScheduler.m_UnobservedTaskException = unobservedTaskException;
					obj3 = obj;
				}
				else
				{
					obj3 = UniTaskScheduler.m_UnobservedTaskException;
				}
				Delegate obj4 = obj;
				if (!flag2)
				{
					obj4 = obj3;
				}
				bool flag3 = (object)obj4 != obj;
				obj = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private static void InvokeUnobservedTaskException(object state)
	{
		//IL_0013: Expected I, but got O
		//IL_0038: Expected I, but got O
		//IL_0048: Expected O, but got I
		//IL_0084: Expected O, but got I
		Action<Exception> unobservedTaskException = UniTaskScheduler.m_UnobservedTaskException;
		nint num = (nint)typeof(Exception);
		if (state != null)
		{
			nint num2 = (nint)state;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v2 (Il2CppClass<System.Exception>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r8_v4 (Il2CppClass<System.Object>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v2 (Il2CppClass<System.Exception>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r8_v4 (Il2CppClass<System.Object>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v11+FFFFFFF8+v74 @ rax_v10*8]");
				if (0 == (nint)typeof(Exception))
				{
					goto IL_00b1;
				}
			}
			throw new InvalidCastException();
		}
		goto IL_00b1;
		IL_00b1:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ r9_v1 (System.Action`1<System.Exception>)+18] (should have been resolved before IL gen)");
	}

	internal static void PublishUnobservedTaskException(Exception ex)
	{
		//IL_0018: Expected I, but got O
		//IL_0020: Expected I, but got O
		//IL_0030: Expected O, but got I
		//IL_005c: Expected I, but got O
		//IL_007a: Expected O, but got I
		//IL_00a4: Expected I, but got O
		//IL_00f7: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		if (ex == null)
		{
			return;
		}
		if (!PropagateOperationCanceledException)
		{
			nint num = (nint)typeof(OperationCanceledException);
			nint num2 = (nint)ex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v7 (Il2CppClass<System.OperationCanceledException>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v2 (Il2CppClass<System.Exception>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v7 (Il2CppClass<System.OperationCanceledException>)+130]");
			bool flag = num3 < 0;
			nint num4 = (nint)typeof(OperationCanceledException);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v2 (Il2CppClass<System.Exception>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v62+FFFFFFF8+v258 @ rax_v61*8]");
				bool flag2 = 0 == (nint)typeof(OperationCanceledException);
				num4 = (nint)typeof(OperationCanceledException);
				if (flag2)
				{
					return;
				}
			}
		}
		if (UniTaskScheduler.m_UnobservedTaskException == null)
		{
			bool flag3 = UnobservedExceptionWriteLogType == LogType.Exception;
			string message = null;
			if (!flag3)
			{
				string text = ex.ToString();
				string text2 = "UnobservedTaskException: " + text;
				message = text2;
			}
			bool flag4 = UnobservedExceptionWriteLogType == LogType.Error;
			if (!flag4)
			{
				object obj3 = UnobservedExceptionWriteLogType - 1;
				if (flag4)
				{
					return;
				}
				object obj4 = obj3 - 1;
				if (!flag4)
				{
					object obj5 = obj4 - 1;
					if (!flag4)
					{
						if ((nint)obj5 == 1)
						{
							Debug.LogException(ex);
						}
					}
					else
					{
						Debug.Log(message);
					}
				}
				else
				{
					Debug.LogWarning(message);
				}
			}
			else
			{
				Debug.LogError(message);
			}
			return;
		}
		if (DispatchUnityMainThread)
		{
			Thread currentThread = Thread.CurrentThread;
			int managedThreadId = currentThread.ManagedThreadId;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185D6F7F0");
			object obj6 = default(object);
			if (managedThreadId != (nint)obj6)
			{
				PlayerLoopHelper.unitySynchronizationContext.Post(handleExceptionInvoke, ex);
				return;
			}
		}
		Action<Exception> unobservedTaskException = UniTaskScheduler.m_UnobservedTaskException;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v142 @ r9_v3 (System.Action`1<System.Exception>)+18] (should have been resolved before IL gen)");
	}

	static UniTaskScheduler()
	{
		SendOrPostCallback sendOrPostCallback = InvokeUnobservedTaskException;
		handleExceptionInvoke = sendOrPostCallback;
	}
}
