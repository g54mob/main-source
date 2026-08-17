using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using PlayFab.Json;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public class AccountDeletionService
{
	[StructLayout((LayoutKind)3)]
	private struct _003CCancelDeletion_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		private TaskAwaiter<JsonObject> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_01d1: Expected I4, but got I8
			//IL_00a6: Expected O, but got I4
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_0117: Expected O, but got Ref
			//IL_0188: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<JsonObject>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<JsonObject> task2 = BackendFacade.ExecuteCloudScript("cancelDeletion");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task3 = default(Task);
				int num = task3.m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = task3;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<JsonObject>)task3;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rbx_v7 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
					}
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<JsonObject> awaiter = default(TaskAwaiter<JsonObject>);
					((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder2)->SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CGetDeletionStatus_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<DeletionStatusResponse> _003C_003Et__builder;

		private TaskAwaiter<JsonObject> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0027: Expected O, but got I
			//IL_0084: Expected O, but got I4
			//IL_019d: Expected O, but got I
			//IL_00fb: Expected O, but got I4
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_034f: Expected O, but got Ref
			//IL_01ea: Expected O, but got I
			//IL_0270: Expected O, but got I
			//IL_038f: Expected O, but got I
			//IL_04b7: Expected I4, but got I8
			//IL_0312: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<JsonObject>)0;
				_003C_003E1__state = -1;
				IntPtr intPtr = default(IntPtr);
				Dictionary<string, string> dictionary = (Dictionary<string, string>)(nint)intPtr;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<JsonObject> task2 = BackendFacade.ExecuteCloudScript("getDeletionStatus");
				bool flag = task2 == null;
				Dictionary<string, string> dictionary = null;
				ref DeletionStatus reference = ref *(DeletionStatus*)null;
				if (flag)
				{
					throw new NullReferenceException();
				}
				TaskAwaiter<JsonObject> taskAwaiter = (TaskAwaiter<JsonObject>)Enum.TryParse<DeletionStatus>((string)(object)task2, ignoreCase: false, out *(DeletionStatus*)null);
				bool flag2 = (object)taskAwaiter == null;
				dictionary = null;
				reference = ref *(DeletionStatus*)null;
				if (flag2)
				{
					throw new NullReferenceException();
				}
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag3 = num == 0;
				bool flag4 = num < 0;
				bool flag5 = !flag4;
				object obj = !flag5;
				object obj2 = obj | flag3;
				dictionary = null;
				reference = ref *(DeletionStatus*)null;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<DeletionStatusResponse> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<DeletionStatusResponse>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<JsonObject> awaiter = default(TaskAwaiter<JsonObject>);
					((AsyncTaskMethodBuilder<DeletionStatusResponse>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			if (task != null)
			{
				int num2 = task.m_stateFlags & 0x11000000;
				if (num2 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					Dictionary<string, string> dictionary = null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v8 (System.Threading.Tasks.Task)+50]");
				object obj3 = 0;
				DeletionStatusResponse deletionStatusResponse = new DeletionStatusResponse();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v8 (System.Threading.Tasks.Task)+50]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r14_v7+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r14_v7+10]");
						bool flag6 = ((Dictionary<object, object>)0).TryGetValue("status", out var value);
						string value2 = Convert.ToString(value, null);
						if (Enum.TryParse<DeletionStatus>(value2, ignoreCase: false, out var result))
						{
							deletionStatusResponse.Status = result;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r14_v7+10]");
							bool flag7 = ((Dictionary<object, object>)0).TryGetValue("deletionTime", out var value3);
							if (value3 != null)
							{
								string s = Convert.ToString(value3, null);
								bool flag8 = DateTime.TryParse(s, out var result2);
								DateTime dateTime = DateTime.SpecifyKind(result2, DateTimeKind.Utc);
								DateTime now = DateTime.Now;
								TimeSpan deletionTimeSpan = dateTime - now;
								deletionStatusResponse.DeletionTimeSpan = deletionTimeSpan;
							}
							_003C_003E1__state = -2;
							AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
							((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(deletionStatusResponse);
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
						string message = default(string);
						Exception ex = new Exception(message);
						Dictionary<string, string> dictionary = (Dictionary<string, string>)0;
						ref DeletionStatus reference = ref *(DeletionStatus*)null;
						throw ex;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
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

	[StructLayout((LayoutKind)3)]
	private struct _003CMarkForDeletion_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		private TaskAwaiter<JsonObject> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_01d1: Expected I4, but got I8
			//IL_00a6: Expected O, but got I4
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_0117: Expected O, but got Ref
			//IL_0188: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<JsonObject>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<JsonObject> task2 = BackendFacade.ExecuteCloudScript("markForDeletion");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task3 = default(Task);
				int num = task3.m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = task3;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<JsonObject>)task3;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rbx_v7 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
					}
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<JsonObject> awaiter = default(TaskAwaiter<JsonObject>);
					((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder2)->SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public Task<DeletionStatusResponse> GetDeletionStatus()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetDeletionStatus_003Ed__0 stateMachine = default(_003CGetDeletionStatus_003Ed__0);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<DeletionStatusResponse>)(object)asyncTaskMethodBuilder.Task;
	}

	public unsafe Task MarkForDeletion()
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CMarkForDeletion_003Ed__1 stateMachine = default(_003CMarkForDeletion_003Ed__1);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	public unsafe Task CancelDeletion()
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CCancelDeletion_003Ed__2 stateMachine = default(_003CCancelDeletion_003Ed__2);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}
}
