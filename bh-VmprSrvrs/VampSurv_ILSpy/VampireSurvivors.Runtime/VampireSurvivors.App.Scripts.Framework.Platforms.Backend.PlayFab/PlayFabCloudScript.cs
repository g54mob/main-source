using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using PlayFab;
using PlayFab.CloudScriptModels;
using PlayFab.Json;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;

public class PlayFabCloudScript
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public TaskCompletionSource<JsonObject> t;

		internal void _003CExecuteCloudScript_003Eb__0(ExecuteFunctionResult result)
		{
			//IL_0020: Expected I, but got O
			//IL_004a: Expected I, but got O
			//IL_005a: Expected O, but got I
			//IL_0096: Expected O, but got I
			object functionResult = result.FunctionResult;
			nint num = (nint)typeof(JsonObject);
			if (result.FunctionResult != null)
			{
				nint num2 = (nint)functionResult;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v3 (Il2CppClass<PlayFab.Json.JsonObject>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v6 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v3 (Il2CppClass<PlayFab.Json.JsonObject>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v6 (Il2CppClass<System.Object>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v13+FFFFFFF8+v103 @ rax_v12*8]");
					if (0 == (nint)typeof(JsonObject))
					{
						goto IL_00c3;
					}
				}
				throw new InvalidCastException();
			}
			goto IL_00c3;
			IL_00c3:
			TaskCompletionSource<JsonObject> taskCompletionSource = t;
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult(result.FunctionResult))
			{
				bool flag = ((Task<JsonObject>)(object)taskCompletionSource).TrySetResult((JsonObject)result.FunctionResult);
			}
		}

		internal void _003CExecuteCloudScript_003Eb__1(PlayFabError error)
		{
			Debug.LogWarning("Encountered error whilst execute cloud function");
			string message = error.GenerateErrorReport();
			Debug.LogWarning(message);
			TaskCompletionSource<JsonObject> taskCompletionSource = t;
			PlayFabApiException ex = PlayFabApiException.FromPlayFabError(error);
			if (ex != null)
			{
				if (!((Task)taskCompletionSource._task).TrySetException((object)ex) && !taskCompletionSource._task.IsCompleted)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
			}
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CExecute_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<JsonObject> _003C_003Et__builder;

		public string fnName;

		public Dictionary<string, string> parameters;

		private int _003Cattempt_003E5__2;

		private TaskAwaiter<JsonObject> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_008b: Expected O, but got I4
			//IL_009a: Expected I4, but got I8
			//IL_003c: Expected O, but got I4
			//IL_004b: Expected I4, but got I8
			//IL_01af: Expected I4, but got I8
			//IL_013a: Expected O, but got I4
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Expected O, but got Unknown
			//IL_01bf: Expected O, but got Ref
			//IL_01d4: Expected O, but got I
			//IL_028d: Expected I4, but got I8
			//IL_0204: Expected O, but got Ref
			int num = _003C_003E1__state;
			if (_003C_003E1__state != 0)
			{
				if (_003C_003E1__state == 1)
				{
					Task task = (Task)_003C_003Eu__2;
					_003C_003Eu__2 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					if ((object)_003C_003Eu__2 == null)
					{
						throw new NullReferenceException();
					}
					int num2 = task.m_stateFlags & 0x11000000;
					if (num2 != 16777216)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification((Task)_003C_003Eu__2);
					}
					Debug.Log("Cloud function timed out, retrying...");
					int num3 = _003Cattempt_003E5__2 + 1;
					_003Cattempt_003E5__2 = num3;
					num = -1;
				}
				else
				{
					_003Cattempt_003E5__2 = 1;
				}
				if (_003Cattempt_003E5__2 > 2)
				{
					string message = "Got into an invalid state whilst executing cloud script: " + fnName;
					Exception ex = new Exception(message);
					throw ex;
				}
			}
			Task task2;
			if (num == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<JsonObject>)0;
				_003C_003E1__state = -1;
				task2 = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<JsonObject> task3 = ExecuteCloudScript(fnName, parameters);
				if (task3 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<JsonObject> taskAwaiter = default(TaskAwaiter<JsonObject>);
				int num4 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num4 == 0;
				bool flag2 = num4 < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task2 = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<JsonObject> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<JsonObject>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<JsonObject> awaiter = default(TaskAwaiter<JsonObject>);
					((AsyncTaskMethodBuilder<JsonObject>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num5 = task2.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rbx_v11 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(0);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public Task<JsonObject> Execute(string fnName, Dictionary<string, string> parameters = null)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CExecute_003Ed__0 stateMachine = default(_003CExecute_003Ed__0);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<JsonObject>)(object)asyncTaskMethodBuilder.Task;
	}

	private static Task<JsonObject> ExecuteCloudScript(string fnName, Dictionary<string, string> parameters)
	{
		//IL_00b9: Expected O, but got I4
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass1_0();
		TaskCompletionSource<JsonObject> t = (TaskCompletionSource<JsonObject>)(object)new TaskCompletionSource<object>();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.t = t;
			bool flag = parameters != null;
			Dictionary<string, string> functionParameter = parameters;
			if (!flag)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				functionParameter = dictionary;
			}
			ExecuteFunctionRequest executeFunctionRequest = new ExecuteFunctionRequest();
			if (executeFunctionRequest != null)
			{
				executeFunctionRequest.FunctionName = fnName;
				executeFunctionRequest.FunctionParameter = functionParameter;
				executeFunctionRequest.GeneratePlayStreamEvent = (bool?)(object)257;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				executeFunctionRequest.CustomTags = customTags;
				Action<ExecuteFunctionResult> resultCallback = delegate(ExecuteFunctionResult result)
				{
					//IL_0020: Expected I, but got O
					//IL_004a: Expected I, but got O
					//IL_005a: Expected O, but got I
					//IL_0096: Expected O, but got I
					object functionResult = result.FunctionResult;
					nint num = (nint)typeof(JsonObject);
					if (result.FunctionResult != null)
					{
						nint num2 = (nint)functionResult;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v3 (Il2CppClass<PlayFab.Json.JsonObject>)+130]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v6 (Il2CppClass<System.Object>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v3 (Il2CppClass<PlayFab.Json.JsonObject>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v6 (Il2CppClass<System.Object>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v13+FFFFFFF8+v103 @ rax_v12*8]");
							if (0 == (nint)typeof(JsonObject))
							{
								goto IL_00c3;
							}
						}
						throw new InvalidCastException();
					}
					goto IL_00c3;
					IL_00c3:
					TaskCompletionSource<JsonObject> t3 = CS_0024_003C_003E8__locals6.t;
					if (!((Task<object>)(object)t3._task).TrySetResult(result.FunctionResult))
					{
						bool flag2 = ((Task<JsonObject>)(object)t3).TrySetResult((JsonObject)result.FunctionResult);
					}
				};
				Action<PlayFabError> errorCallback = delegate(PlayFabError error)
				{
					Debug.LogWarning("Encountered error whilst execute cloud function");
					string message = error.GenerateErrorReport();
					Debug.LogWarning(message);
					TaskCompletionSource<JsonObject> t3 = CS_0024_003C_003E8__locals6.t;
					PlayFabApiException ex = PlayFabApiException.FromPlayFabError(error);
					if (ex != null)
					{
						if (!((Task)t3._task).TrySetException((object)ex) && !t3._task.IsCompleted)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
					}
				};
				Dictionary<string, string> extraHeaders = default(Dictionary<string, string>);
				PlayFabCloudScriptAPI.ExecuteFunction(executeFunctionRequest, resultCallback, errorCallback, null, extraHeaders);
				TaskCompletionSource<JsonObject> t2 = CS_0024_003C_003E8__locals6.t;
				if (CS_0024_003C_003E8__locals6.t != null)
				{
					return t2._task;
				}
			}
		}
		return (Task<JsonObject>)(object)new NullReferenceException();
	}
}
