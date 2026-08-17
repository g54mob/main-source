using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using PlayFab;
using PlayFab.Json;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public class AccountLinkService
{
	[StructLayout((LayoutKind)3)]
	private struct _003CAcceptMergeConflict_003Ed__4 : IAsyncStateMachine
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
				Task<JsonObject> task2 = BackendFacade.ExecuteCloudScript("acceptMergeConflict");
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
	private struct _003CCanUnlink_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		private TaskAwaiter<AccountDetails> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0116: Expected O, but got I
			//IL_00a0: Expected O, but got I4
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_0131: Expected O, but got I
			//IL_024a: Expected I4, but got I8
			//IL_0201: Expected O, but got Ref
			//IL_01c4: Expected O, but got Ref
			//IL_0172: Expected O, but got I
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<AccountDetails>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<AccountDetails> accountDetails = BackendFacade.GetAccountDetails();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<AccountDetails> taskAwaiter = default(TaskAwaiter<AccountDetails>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<AccountDetails> awaiter = default(TaskAwaiter<AccountDetails>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v5 (System.Threading.Tasks.Task)+50]");
			AccountDetails accountDetails2 = (AccountDetails)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v5 (System.Threading.Tasks.Task)+50]");
			bool result;
			if (!((AccountDetails)0).IsPlatformLinked(AccountDetailsType.Email))
			{
				Dictionary<AccountDetailsType, string> platformAccounts = accountDetails2.PlatformAccounts;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v14 (System.Collections.Generic.Dictionary`2<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.AccountDetailsType, System.String>)+20]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v14 (System.Collections.Generic.Dictionary`2<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.AccountDetailsType, System.String>)+28]");
				object obj3 = num3 - 0;
				result = (((nint)obj3 > 1) ? true : false);
			}
			else
			{
				result = true;
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->SetResult(result);
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
	private struct _003CCheckForceLinkOnServer_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ForceLinkResponse> _003C_003Et__builder;

		public string platformAccountPlayFabId;

		public AccountDetailsType platform;

		private string _003ClinkedPlayerId_003E5__2;

		private TaskAwaiter<JsonObject> _003C_003Eu__1;

		private Task<PlayerOptionsData> _003CgetDataTask_003E5__3;

		private Task<PlayerOptionsData> _003CgetMergeConflictDataTask_003E5__4;

		private TaskAwaiter<PlayerOptionsData[]> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005b: Expected O, but got I4
			//IL_006a: Expected I4, but got I8
			//IL_00cb: Expected O, but got Ref
			//IL_01e0: Expected O, but got I
			//IL_06f8: Expected O, but got I
			//IL_074a: Expected O, but got I
			//IL_0204: Expected O, but got I
			//IL_0729: Expected O, but got I4
			//IL_0735: Expected O, but got I4
			//IL_0765: Expected O, but got I
			//IL_07b7: Expected O, but got I
			//IL_016a: Expected O, but got I4
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Expected O, but got Unknown
			//IL_0796: Expected O, but got I4
			//IL_07a2: Expected O, but got I4
			//IL_024e: Expected O, but got I
			//IL_099a: Expected O, but got Ref
			//IL_0b09: Expected I4, but got I8
			//IL_09bd: Expected O, but got Ref
			//IL_085f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0864: Expected Ref, but got Unknown
			//IL_0872: Unknown result type (might be due to invalid IL or missing references)
			//IL_0877: Expected Ref, but got Unknown
			//IL_088e: Expected I8, but got I4
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Expected Ref, but got Unknown
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Expected Ref, but got Unknown
			//IL_0327: Expected I8, but got I4
			//IL_05fa: Expected O, but got I4
			//IL_053b: Expected I, but got O
			//IL_0554: Expected O, but got I
			//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e6: Expected Ref, but got Unknown
			//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Expected Ref, but got Unknown
			//IL_040c: Expected I8, but got I4
			//IL_05ac: Expected I, but got O
			//IL_05c9: Expected O, but got I
			//IL_0635: Expected O, but got I
			//IL_066d: Expected O, but got I4
			//IL_0675: Unknown result type (might be due to invalid IL or missing references)
			//IL_067a: Expected O, but got Unknown
			//IL_095d: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter<PlayerOptionsData[]>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__2;
				goto IL_0690;
			}
			Task task2;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<JsonObject>)0;
				_003C_003E1__state = -1;
				task2 = (Task)_003C_003Eu__1;
			}
			else
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				if (dictionary == null)
				{
					throw new NullReferenceException();
				}
				bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"linkedPlayerId", (object)platformAccountPlayFabId, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				IntPtr intPtr = default(IntPtr);
				string value = ((Enum)(&intPtr)).ToString();
				bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"linkedPlatform", (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Task<JsonObject> task3 = BackendFacade.ExecuteCloudScript("prepareForceLink", dictionary);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<JsonObject> taskAwaiter = default(TaskAwaiter<JsonObject>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag3 = num == 0;
				bool flag4 = num < 0;
				bool flag5 = !flag4;
				object obj = !flag5;
				object obj2 = obj | flag3;
				task2 = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<ForceLinkResponse> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<ForceLinkResponse>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<JsonObject> awaiter = default(TaskAwaiter<JsonObject>);
					((AsyncTaskMethodBuilder<ForceLinkResponse>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task2.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rbx_v25 (System.Threading.Tasks.Task)+50]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ rbx_v26+10]");
			bool flag6 = ((Dictionary<object, object>)0).TryGetValue("linkedPlayerId", out var value2);
			string text = Convert.ToString(value2, null);
			_003ClinkedPlayerId_003E5__2 = text;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ rbx_v26+10]");
			bool flag7 = ((Dictionary<object, object>)0).TryGetValue("action", out var value3);
			string text2 = Convert.ToString(value3, null);
			object obj4 = "CONFLICT";
			ForceLinkConflictResponse result;
			if ((object)text2 != "CONFLICT")
			{
				if (text2 != null && "CONFLICT" != null)
				{
					int stringLength = text2._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2159 @ rdx_v50+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(text2 + 20);
						ref byte second = ref *(byte*)("CONFLICT" + 20);
						ulong length = (ulong)(text2._stringLength + text2._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first, ref second, length))
						{
							goto IL_04ac;
						}
					}
				}
				object obj5 = "LINK";
				if ((object)text2 == "LINK")
				{
					goto IL_047d;
				}
				if (text2 != null && "LINK" != null)
				{
					int stringLength2 = text2._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2289 @ rdx_v79+10]");
					if ((nint)stringLength2 == 0)
					{
						ref byte first2 = ref *(byte*)(text2 + 20);
						ref byte second2 = ref *(byte*)("LINK" + 20);
						ulong length2 = (ulong)(text2._stringLength + text2._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first2, ref second2, length2))
						{
							goto IL_047d;
						}
					}
				}
				ForceLinkErrorResponse forceLinkErrorResponse = new ForceLinkErrorResponse();
				forceLinkErrorResponse.LinkingPlayerId = _003ClinkedPlayerId_003E5__2;
				string currentAccountSaveData = "Unknown ForceLink API response action: " + text2;
				((ForceLinkConflictResponse)(object)forceLinkErrorResponse).CurrentAccountSaveData = (PlayerOptionsData)(object)currentAccountSaveData;
				result = (ForceLinkConflictResponse)(object)forceLinkErrorResponse;
				goto IL_0afa;
			}
			goto IL_04ac;
			IL_047d:
			ForceLinkResponse forceLinkResponse = new ForceLinkResponse();
			forceLinkResponse.LinkingPlayerId = _003ClinkedPlayerId_003E5__2;
			result = (ForceLinkConflictResponse)forceLinkResponse;
			goto IL_0afa;
			IL_0afa:
			_003C_003E1__state = -2;
			_003ClinkedPlayerId_003E5__2 = null;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(result);
			return;
			IL_0904:
			ForceLinkResponse forceLinkResponse2 = new ForceLinkResponse();
			forceLinkResponse2.LinkingPlayerId = _003ClinkedPlayerId_003E5__2;
			result = (ForceLinkConflictResponse)forceLinkResponse2;
			goto IL_0afa;
			IL_0690:
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Task<PlayerOptionsData> task4 = _003CgetDataTask_003E5__3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rcx_v31 (System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData>)+38]");
			object obj6 = (nint)0 & (nint)0x11000000;
			PlayerOptionsData playerOptionsData;
			if ((nint)obj6 != 16777216)
			{
				bool flag8 = ((Dictionary<string, object>)(object)task4).TryGetValue((string)1, out *(object*)_003CgetMergeConflictDataTask_003E5__4);
				playerOptionsData = (PlayerOptionsData)flag8;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rcx_v31 (System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData>)+50]");
				playerOptionsData = (PlayerOptionsData)0;
			}
			Task<PlayerOptionsData> task5 = _003CgetMergeConflictDataTask_003E5__4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v32 (System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData>)+38]");
			object obj7 = (nint)0 & (nint)0x11000000;
			PlayerOptionsData playerOptionsData2;
			if ((nint)obj7 != 16777216)
			{
				bool flag9 = ((Dictionary<string, object>)(object)task5).TryGetValue((string)1, out *(object*)_003CgetMergeConflictDataTask_003E5__4);
				playerOptionsData2 = (PlayerOptionsData)flag9;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v32 (System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData>)+50]");
				playerOptionsData2 = (PlayerOptionsData)0;
			}
			string text3 = playerOptionsData._003Cchecksum_003Ek__BackingField;
			string text4 = playerOptionsData2._003Cchecksum_003Ek__BackingField;
			if ((object)playerOptionsData._003Cchecksum_003Ek__BackingField == playerOptionsData2._003Cchecksum_003Ek__BackingField)
			{
				goto IL_0904;
			}
			if (playerOptionsData2._003Cchecksum_003Ek__BackingField != null && text3._stringLength == text4._stringLength)
			{
				ref byte first3 = ref *(byte*)(playerOptionsData._003Cchecksum_003Ek__BackingField + 20);
				ref byte second3 = ref *(byte*)(playerOptionsData2._003Cchecksum_003Ek__BackingField + 20);
				ulong length3 = (ulong)(text3._stringLength + text3._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref first3, ref second3, length3))
				{
					goto IL_0904;
				}
			}
			ForceLinkConflictResponse forceLinkConflictResponse = new ForceLinkConflictResponse();
			forceLinkConflictResponse.LinkingPlayerId = _003ClinkedPlayerId_003E5__2;
			forceLinkConflictResponse.CurrentAccountSaveData = playerOptionsData;
			forceLinkConflictResponse.LinkingAccountSaveData = playerOptionsData2;
			result = forceLinkConflictResponse;
			goto IL_0afa;
			IL_04ac:
			Task<PlayerOptionsData> slotSaveData = BackendFacade.GetSlotSaveData(1);
			_003CgetDataTask_003E5__3 = slotSaveData;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder3 = default(AsyncTaskMethodBuilder<object>);
			BackendFacade._003CGetMergeConflictSlotData_003Ed__39 stateMachine = default(BackendFacade._003CGetMergeConflictSlotData_003Ed__39);
			asyncTaskMethodBuilder3.Start(ref stateMachine);
			Task<object> task6 = asyncTaskMethodBuilder3.Task;
			_003CgetMergeConflictDataTask_003E5__4 = (Task<PlayerOptionsData>)(object)task6;
			Task<PlayerOptionsData>[] array = new Task<PlayerOptionsData>[2];
			if (_003CgetDataTask_003E5__3 != null)
			{
				nint num4 = (nint)array;
				Task<PlayerOptionsData> task7 = _003CgetDataTask_003E5__3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2740 @ rax_v172 (Il2CppClass<System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData>[]>)+40]");
				if (!((Dictionary<string, object>)(object)task7).TryGetValue((string)0, out *(object*)null))
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			bool flag10 = ((Dictionary<string, object>)(object)array).TryGetValue((string)null, out *(object*)_003CgetDataTask_003E5__3);
			if (_003CgetMergeConflictDataTask_003E5__4 != null)
			{
				nint num5 = (nint)array;
				Task<PlayerOptionsData> task8 = _003CgetMergeConflictDataTask_003E5__4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2767 @ rax_v170 (Il2CppClass<System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData>[]>)+40]");
				if (!((Dictionary<string, object>)(object)task8).TryGetValue((string)0, out *(object*)_003CgetDataTask_003E5__3))
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			bool flag11 = ((Dictionary<string, object>)(object)array).TryGetValue((string)1, out *(object*)_003CgetMergeConflictDataTask_003E5__4);
			Task<PlayerOptionsData[]> task9 = Task.WhenAll(array);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2876 @ rax_v146 (System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData[]>)+38]");
			object obj8 = (nint)0 & (nint)0x1600000;
			bool flag12 = obj8 == null;
			bool flag13 = (nint)obj8 < 0;
			bool flag14 = !flag13;
			object obj9 = !flag14;
			object obj10 = obj9 | flag12;
			task = task9;
			if (obj10 == null)
			{
				goto IL_0690;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = (TaskAwaiter<PlayerOptionsData[]>)task9;
			AsyncTaskMethodBuilder<ForceLinkResponse> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<ForceLinkResponse>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter<PlayerOptionsData[]> awaiter2 = default(TaskAwaiter<PlayerOptionsData[]>);
			((AsyncTaskMethodBuilder<ForceLinkResponse>*)asyncTaskMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
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
	private struct _003CPrepareForForceLink_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ForceLinkResponse> _003C_003Et__builder;

		public AccountLinkService _003C_003E4__this;

		public AccountDetailsType platform;

		private TaskAwaiter<string> _003C_003Eu__1;

		private TaskAwaiter<ForceLinkResponse> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005b: Expected O, but got I4
			//IL_006a: Expected I4, but got I8
			//IL_0266: Expected I4, but got I8
			//IL_0276: Expected O, but got Ref
			//IL_028b: Expected O, but got I
			//IL_0102: Expected O, but got I4
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_02f3: Expected O, but got Ref
			//IL_01f1: Expected O, but got I4
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Expected O, but got Unknown
			//IL_02bb: Expected O, but got Ref
			Task task;
			Task task2;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					_003C_003Eu__2 = (TaskAwaiter<ForceLinkResponse>)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__2;
					goto IL_0214;
				}
				AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
				_003CSetAccountVerificationTokenOnPlatformAccount_003Ed__3 stateMachine = default(_003CSetAccountVerificationTokenOnPlatformAccount_003Ed__3);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<object> task3 = asyncTaskMethodBuilder.Task;
				((AsyncTaskMethodBuilder<string>*)task3)->Start(ref *(_003CSetAccountVerificationTokenOnPlatformAccount_003Ed__3*)null);
				TaskAwaiter<string> taskAwaiter = default(TaskAwaiter<string>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<ForceLinkResponse> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<ForceLinkResponse>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
					((AsyncTaskMethodBuilder<ForceLinkResponse>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder3 = default(AsyncTaskMethodBuilder<object>);
			_003CCheckForceLinkOnServer_003Ed__5 stateMachine2 = default(_003CCheckForceLinkOnServer_003Ed__5);
			asyncTaskMethodBuilder3.Start(ref stateMachine2);
			Task<object> task4 = asyncTaskMethodBuilder3.Task;
			((AsyncTaskMethodBuilder<ForceLinkResponse>*)task4)->Start(ref *(_003CCheckForceLinkOnServer_003Ed__5*)null);
			TaskAwaiter<ForceLinkResponse> taskAwaiter2 = default(TaskAwaiter<ForceLinkResponse>);
			int num3 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
			bool flag4 = num3 == 0;
			bool flag5 = num3 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			task2 = (Task)taskAwaiter2;
			if (obj4 == null)
			{
				goto IL_0214;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = taskAwaiter2;
			AsyncTaskMethodBuilder<ForceLinkResponse> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<ForceLinkResponse>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter<ForceLinkResponse> awaiter2 = default(TaskAwaiter<ForceLinkResponse>);
			((AsyncTaskMethodBuilder<ForceLinkResponse>*)asyncTaskMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
			return;
			IL_0214:
			int num4 = task2.m_stateFlags & 0x11000000;
			if (num4 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder5 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rbx_v10 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder5)->SetResult(0);
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
	private struct _003CSetAccountVerificationTokenOnPlatformAccount_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		private PlayFabAuthenticationContext _003CbasicCredsAuthContext_003E5__2;

		private PlayFabLoginSuccess _003CplatformLoginResult_003E5__3;

		private TaskAwaiter<ILoginResult> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005b: Expected O, but got I4
			//IL_006a: Expected I4, but got I8
			//IL_0193: Expected O, but got I
			//IL_01a1: Expected I, but got O
			//IL_01e2: Expected I, but got O
			//IL_01f2: Expected O, but got I
			//IL_022e: Expected O, but got I
			//IL_011d: Expected O, but got I4
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Expected O, but got Unknown
			//IL_026d: Expected O, but got I
			//IL_027b: Expected I, but got O
			//IL_0283: Expected I, but got O
			//IL_0293: Expected O, but got I
			//IL_04e6: Expected O, but got Ref
			//IL_044d: Expected I4, but got I8
			//IL_02cf: Expected O, but got I
			//IL_046c: Expected O, but got Ref
			//IL_0395: Expected O, but got I4
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a2: Expected O, but got Unknown
			//IL_04ae: Expected O, but got Ref
			Task task;
			PlayFabAuthenticationContext playFabAuthenticationContext;
			Task task2;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					_003C_003Eu__2 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					playFabAuthenticationContext = null;
					task2 = (Task)_003C_003Eu__2;
					goto IL_03c0;
				}
				PlayFabAuthenticationContext playFabAuthenticationContext2 = new PlayFabAuthenticationContext();
				_003CbasicCredsAuthContext_003E5__2 = playFabAuthenticationContext2;
				_003CbasicCredsAuthContext_003E5__2.CopyFrom(PlayFabSettings.staticPlayer);
				Task<ILoginResult> task3 = BackendFacade.Login();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<ILoginResult> taskAwaiter = default(TaskAwaiter<ILoginResult>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<string>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILoginResult> awaiter = default(TaskAwaiter<ILoginResult>);
					((AsyncTaskMethodBuilder<string>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v16 (System.Threading.Tasks.Task)+50]");
			PlayFabLoginSuccess playFabLoginSuccess = (PlayFabLoginSuccess)0;
			nint num3 = (nint)typeof(PlayFabLoginSuccess);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v16 (System.Threading.Tasks.Task)+50]");
			PlayFabLoginSuccess playFabLoginSuccess2;
			if ((nint)0 == 0)
			{
				_003CplatformLoginResult_003E5__3 = null;
				playFabLoginSuccess2 = null;
				goto IL_0306;
			}
			nint num4 = (nint)playFabLoginSuccess;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rdx_v22 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ r9_v19 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rdx_v22 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ r9_v19 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v99+FFFFFFF8+v552 @ rax_v98*8]");
				if (0 == (nint)typeof(PlayFabLoginSuccess))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v16 (System.Threading.Tasks.Task)+50]");
					_003CplatformLoginResult_003E5__3 = (PlayFabLoginSuccess)0;
					nint num6 = (nint)typeof(PlayFabLoginSuccess);
					nint num7 = (nint)playFabLoginSuccess;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rdx_v30 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+130]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ r9_v17 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+130]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rdx_v30 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+130]");
					if (num8 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ r9_v17 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLoginSuccess>)+C8]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v101+FFFFFFF8+v817 @ rax_v100*8]");
						if (0 == (nint)typeof(PlayFabLoginSuccess))
						{
							playFabLoginSuccess2 = null;
							goto IL_0306;
						}
					}
					throw new InvalidCastException();
				}
			}
			throw new InvalidCastException();
			IL_03c0:
			int num9 = task2.m_stateFlags & 0x11000000;
			if (num9 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			PlayFabSettings.staticPlayer.CopyFrom(_003CbasicCredsAuthContext_003E5__2);
			PlayFabLoginSuccess playFabLoginSuccess3 = _003CplatformLoginResult_003E5__3;
			PlayFabAuthenticationContext authenticationContext = playFabLoginSuccess3.AuthenticationContext;
			_003C_003E1__state = -2;
			_003CbasicCredsAuthContext_003E5__2 = playFabAuthenticationContext;
			_003CplatformLoginResult_003E5__3 = (PlayFabLoginSuccess)(object)playFabAuthenticationContext;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(authenticationContext.PlayFabId);
			return;
			IL_0306:
			PlayFabAuthenticationContext playFabAuthenticationContext3 = _003CbasicCredsAuthContext_003E5__2;
			Task<bool> task4 = BackendFacade.SetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys.LINK_ACCOUNT_VERIFICATION_TOKEN, playFabAuthenticationContext3.PlayFabId);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
			int num10 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
			bool flag4 = num10 == 0;
			bool flag5 = num10 < 0;
			bool flag6 = !flag5;
			object obj7 = !flag6;
			object obj8 = obj7 | flag4;
			playFabAuthenticationContext = (PlayFabAuthenticationContext)(object)playFabLoginSuccess2;
			task2 = (Task)taskAwaiter2;
			if (obj8 == null)
			{
				goto IL_03c0;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = taskAwaiter2;
			AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<string>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter<bool> awaiter2 = default(TaskAwaiter<bool>);
			((AsyncTaskMethodBuilder<string>*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
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
	private struct _003CTryToUnlinkSpecificPlatform_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AccountDetailsType platform;

		public bool isCurrentPlatform;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_009a: Expected O, but got I4
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_006c: Expected O, but got I4
			//IL_007b: Expected I4, but got I8
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_04a3: Expected I4, but got I8
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_0399: Expected O, but got Ref
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_0328: Expected O, but got I4
			//IL_0330: Unknown result type (might be due to invalid IL or missing references)
			//IL_0335: Expected O, but got Unknown
			//IL_03cd: Expected O, but got Ref
			//IL_0218: Expected O, but got I4
			//IL_0220: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Expected O, but got Unknown
			//IL_02a3: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
				goto IL_034b;
			}
			bool flag = _003C_003E1__state == 1;
			Task task2;
			if (_003C_003E1__state == 1)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task2 = (Task)_003C_003Eu__1;
			}
			else
			{
				object obj = platform - 1;
				PlayFabApple playFabApple;
				if (!flag)
				{
					object obj2 = obj - 1;
					playFabApple = null;
					if (!flag)
					{
						object obj3 = obj2 - 1;
						if (!flag)
						{
							object obj4 = obj3 - 1;
							playFabApple = null;
							if (!flag)
							{
								bool flag2 = (nint)obj4 != 1;
								playFabApple = null;
								if (!flag2)
								{
									PlayFabSteam playFabSteam = new PlayFabSteam();
									playFabApple = (PlayFabApple)(object)playFabSteam;
								}
							}
						}
						else
						{
							PlayFabGoogle playFabGoogle = new PlayFabGoogle();
							playFabApple = (PlayFabApple)(object)playFabGoogle;
						}
					}
				}
				else
				{
					PlayFabApple playFabApple2 = new PlayFabApple();
					playFabApple = playFabApple2;
				}
				TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
				if (isCurrentPlatform)
				{
					Task<bool> task3 = BackendFacade.UnlinkAccount();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
					int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag3 = num == 0;
					bool flag4 = num < 0;
					bool flag5 = !flag4;
					object obj5 = !flag5;
					object obj6 = obj5 | flag3;
					task = (Task)taskAwaiter;
					if (obj6 == null)
					{
						goto IL_034b;
					}
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
				if (playFabApple == null)
				{
					Exception ex = new Exception("Unknown/unsupported platform for this operation at this time.");
					throw ex;
				}
				AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<bool>);
				BackendFacade._003CUnlinkAccount_003Ed__27 stateMachine = default(BackendFacade._003CUnlinkAccount_003Ed__27);
				asyncTaskMethodBuilder2.Start(ref stateMachine);
				Task<bool> task4 = asyncTaskMethodBuilder2.Task;
				((AsyncTaskMethodBuilder<bool>*)task4)->Start(ref *(BackendFacade._003CUnlinkAccount_003Ed__27*)null);
				TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
				int num2 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
				bool flag6 = num2 == 0;
				bool flag7 = num2 < 0;
				bool flag8 = !flag7;
				object obj7 = !flag8;
				object obj8 = obj7 | flag6;
				task2 = (Task)taskAwaiter2;
				if (obj8 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__1 = taskAwaiter2;
					AsyncTaskMethodBuilder asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task2.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			goto IL_0494;
			IL_0494:
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder4)->SetResult();
			return;
			IL_034b:
			int num4 = task.m_stateFlags & 0x11000000;
			if (num4 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			goto IL_0494;
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

	public Task<ForceLinkResponse> PrepareForForceLink(AccountDetailsType platform)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CPrepareForForceLink_003Ed__0 stateMachine = default(_003CPrepareForForceLink_003Ed__0);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ForceLinkResponse>)(object)asyncTaskMethodBuilder.Task;
	}

	public Task<bool> CanUnlink()
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CCanUnlink_003Ed__1 stateMachine = default(_003CCanUnlink_003Ed__1);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public unsafe Task TryToUnlinkSpecificPlatform(AccountDetailsType platform, bool isCurrentPlatform)
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CTryToUnlinkSpecificPlatform_003Ed__2 stateMachine = default(_003CTryToUnlinkSpecificPlatform_003Ed__2);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	private Task<string> SetAccountVerificationTokenOnPlatformAccount()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CSetAccountVerificationTokenOnPlatformAccount_003Ed__3 stateMachine = default(_003CSetAccountVerificationTokenOnPlatformAccount_003Ed__3);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<string>)(object)asyncTaskMethodBuilder.Task;
	}

	public unsafe Task AcceptMergeConflict()
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CAcceptMergeConflict_003Ed__4 stateMachine = default(_003CAcceptMergeConflict_003Ed__4);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	private Task<ForceLinkResponse> CheckForceLinkOnServer(string platformAccountPlayFabId, AccountDetailsType platform)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CCheckForceLinkOnServer_003Ed__5 stateMachine = default(_003CCheckForceLinkOnServer_003Ed__5);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ForceLinkResponse>)(object)asyncTaskMethodBuilder.Task;
	}
}
