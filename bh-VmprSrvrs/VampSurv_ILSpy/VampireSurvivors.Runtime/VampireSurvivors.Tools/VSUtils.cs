using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Doozy.Engine;
using UnityEngine;

namespace VampireSurvivors.Tools;

public static class VSUtils
{
	[StructLayout((LayoutKind)3)]
	private struct _003CRestartAppWithFrameDelay_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

		private Cysharp.Threading.Tasks.YieldAwaitable.Awaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0051: Expected O, but got I4
			//IL_0060: Expected I4, but got I8
			//IL_0091: Expected O, but got I4
			//IL_015f: Expected I4, but got I8
			//IL_016a: Expected O, but got Ref
			//IL_00fc: Expected O, but got I4
			//IL_0107: Expected O, but got Ref
			//IL_00c8: Expected O, but got I4
			//IL_00d3: Expected O, but got Ref
			CancellationToken cancellationToken = default(CancellationToken);
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)0;
				_003C_003E1__state = -1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					_003C_003Eu__2 = (Cysharp.Threading.Tasks.YieldAwaitable.Awaiter)0;
					_003C_003E1__state = -1;
					_003C_003E1__state = -2;
					object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
					return;
				}
				SwitchToMainThreadAwaitable.Awaiter awaiter = default(SwitchToMainThreadAwaitable.Awaiter);
				bool isCompleted = awaiter.IsCompleted;
				bool flag = !isCompleted;
				cancellationToken = (CancellationToken)0;
				if (flag)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (SwitchToMainThreadAwaitable.Awaiter)8;
					AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			cancellationToken.ThrowIfCancellationRequested();
			_003C_003E1__state = 1;
			_003C_003Eu__2 = (Cysharp.Threading.Tasks.YieldAwaitable.Awaiter)13;
			AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder2 = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cysharp.Threading.Tasks.YieldAwaitable.Awaiter awaiter2 = default(Cysharp.Threading.Tasks.YieldAwaitable.Awaiter);
			((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class _003CRestartAppWithFrameDelayRoutine_003Ed__4(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_006e: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				RestartApp();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public static bool IsEditor()
	{
		return false;
	}

	public unsafe static string FormatTime(float seconds)
	{
		//IL_007f: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		float num = seconds / 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(CultureInfo.invariant_culture_info);
		string text = System.Number.FormatSingle(seconds, null, instance);
		if (text != null)
		{
			string arg = text.PadLeft(2, '0');
			object arg2 = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg2, arg);
			object obj = default(object);
			return string.FormatHelper((IFormatProvider)null, "{0}:{1}", (System.ParamsArray)(&obj));
		}
		return (string)(object)new NullReferenceException();
	}

	public static void RestartApp()
	{
	}

	public static void RestartAppWithFrameDelayCoroutine()
	{
		_003CRestartAppWithFrameDelayRoutine_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		Coroutine coroutine = Coroutiner.Start(obj);
	}

	private static IEnumerator RestartAppWithFrameDelayRoutine()
	{
		_003CRestartAppWithFrameDelayRoutine_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		return obj;
	}

	public static UniTaskVoid RestartAppWithFrameDelay()
	{
		//IL_001a: Expected O, but got I4
		_003CRestartAppWithFrameDelay_003Ed__5 obj = default(_003CRestartAppWithFrameDelay_003Ed__5);
		obj.MoveNext();
		return (UniTaskVoid)0;
	}
}
