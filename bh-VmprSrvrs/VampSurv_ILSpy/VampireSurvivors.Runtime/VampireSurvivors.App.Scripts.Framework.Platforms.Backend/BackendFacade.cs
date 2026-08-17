using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using I2.Loc;
using PlayFab;
using PlayFab.Json;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Core;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend;

public static class BackendFacade
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Task<AccountDetails>> _003C_003E9__23_0;

		public static Func<Task<ILoginResult>> _003C_003E9__24_0;

		public static Func<Task<bool>> _003C_003E9__26_0;

		public static Func<Task<string>> _003C_003E9__36_1;

		public static Func<Task<string>> _003C_003E9__37_1;

		public static Func<Task<PlayerOptionsData>> _003C_003E9__39_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal Task<AccountDetails> _003CGetAccountDetails_003Eb__23_0()
		{
			//IL_000d: Expected I, but got O
			//IL_00bc: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0045: Expected O, but got I
			//IL_004e: Expected O, but got I4
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			ICoreAuthentication coreAuthentication = _coreAuthentication;
			nint num;
			object obj2 = default(object);
			if (_coreAuthentication != null)
			{
				num = (nint)coreAuthentication;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_0085;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+B0]");
				object obj = 0;
				obj2 = 0;
				while (true)
				{
					object obj3 = obj2 + obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+v79 @ rax_v10*8]");
					if (0 == (nint)typeof(ICoreAuthentication))
					{
						break;
					}
					obj2++;
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+12E]");
					if ((nint)obj4 < 0)
					{
						continue;
					}
					goto IL_0085;
				}
				goto IL_0099;
			}
			goto IL_00ef;
			IL_00ef:
			return (Task<AccountDetails>)(object)new NullReferenceException();
			IL_0085:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v107 @ rax_v7] (should have been resolved before IL gen)");
			goto IL_0099;
			IL_0099:
			object obj5 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+8+v162 @ rcx_v9*8]");
			object obj6 = (nint)0 + (nint)8;
			object obj7 = obj6 << 4;
			object obj8 = obj7 + 312;
			object obj9 = obj8 + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v146 @ rax_v16] (should have been resolved before IL gen)");
			goto IL_00ef;
		}

		internal Task<ILoginResult> _003CLogin_003Eb__24_0()
		{
			//IL_000d: Expected I, but got O
			//IL_00bc: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0045: Expected O, but got I
			//IL_004e: Expected O, but got I4
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			IPlatformAuthentication platformAuthentication = _platformAuthentication;
			nint num;
			object obj2 = default(object);
			if (_platformAuthentication != null)
			{
				num = (nint)platformAuthentication;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.IPlatformAuthentication>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_0085;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.IPlatformAuthentication>)+B0]");
				object obj = 0;
				obj2 = 0;
				while (true)
				{
					object obj3 = obj2 + obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+v79 @ rax_v10*8]");
					if (0 == (nint)typeof(IPlatformAuthentication))
					{
						break;
					}
					obj2++;
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.IPlatformAuthentication>)+12E]");
					if ((nint)obj4 < 0)
					{
						continue;
					}
					goto IL_0085;
				}
				goto IL_0099;
			}
			goto IL_00ef;
			IL_00ef:
			return (Task<ILoginResult>)(object)new NullReferenceException();
			IL_0085:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v107 @ rax_v7] (should have been resolved before IL gen)");
			goto IL_0099;
			IL_0099:
			object obj5 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+8+v162 @ rcx_v9*8]");
			object obj6 = (nint)0 + (nint)1;
			object obj7 = obj6 << 4;
			object obj8 = obj7 + 312;
			object obj9 = obj8 + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v146 @ rax_v16] (should have been resolved before IL gen)");
			goto IL_00ef;
		}

		internal Task<bool> _003CUnlinkAccount_003Eb__26_0()
		{
			if (_platformAuthentication != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Task<bool> result = default(Task<bool>);
				return result;
			}
			return (Task<bool>)(object)new NullReferenceException();
		}

		internal Task<string> _003CLinkCustomID_003Eb__36_1()
		{
			return GetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys.LINKED_CUSTOM_IDS);
		}

		internal Task<string> _003CUnlinkCustomId_003Eb__37_1()
		{
			return GetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys.LINKED_CUSTOM_IDS);
		}

		internal Task<PlayerOptionsData> _003CGetMergeConflictSlotData_003Eb__39_0()
		{
			//IL_000d: Expected I, but got O
			//IL_00bc: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_0045: Expected O, but got I
			//IL_004e: Expected O, but got I4
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			IMultiSlotSaveStorage multiSlotSaveStorage = _multiSlotSaveStorage;
			nint num;
			object obj2 = default(object);
			if (_multiSlotSaveStorage != null)
			{
				num = (nint)multiSlotSaveStorage;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage.IMultiSlotSaveStorage>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_0085;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage.IMultiSlotSaveStorage>)+B0]");
				object obj = 0;
				obj2 = 0;
				while (true)
				{
					object obj3 = obj2 + obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+v79 @ rax_v10*8]");
					if (0 == (nint)typeof(IMultiSlotSaveStorage))
					{
						break;
					}
					obj2++;
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage.IMultiSlotSaveStorage>)+12E]");
					if ((nint)obj4 < 0)
					{
						continue;
					}
					goto IL_0085;
				}
				goto IL_0099;
			}
			goto IL_00ef;
			IL_00ef:
			return (Task<PlayerOptionsData>)(object)new NullReferenceException();
			IL_0085:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v107 @ rax_v7] (should have been resolved before IL gen)");
			goto IL_0099;
			IL_0099:
			object obj5 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+8+v162 @ rcx_v9*8]");
			object obj6 = (nint)0 + (nint)2;
			object obj7 = obj6 << 4;
			object obj8 = obj7 + 312;
			object obj9 = obj8 + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v146 @ rax_v16] (should have been resolved before IL gen)");
			goto IL_00ef;
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public string email;

		internal Task<bool> _003CAddOrUpdateContactEmail_003Eb__0()
		{
			if (_coreAuthentication != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D1A0");
				Task<bool> result = default(Task<bool>);
				return result;
			}
			return (Task<bool>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public string fnName;

		public Dictionary<string, string> parameters;

		internal Task<JsonObject> _003CExecuteCloudScript_003Eb__0()
		{
			PlayFabCloudScript playFabCloudScript = new PlayFabCloudScript();
			if (playFabCloudScript != null)
			{
				return playFabCloudScript.Execute(fnName, parameters);
			}
			return (Task<JsonObject>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public bool force;

		internal Task<ILinkResult> _003CLinkAccount_003Eb__0()
		{
			if (_platformAuthentication != null)
			{
				return _platformAuthentication.LinkAccount(force);
			}
			return (Task<ILinkResult>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public IPlatformAuthentication platformAuthentication;

		internal Task<bool> _003CUnlinkAccount_003Eb__0()
		{
			if (platformAuthentication != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Task<bool> result = default(Task<bool>);
				return result;
			}
			return (Task<bool>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public string email;

		public string password;

		internal Task<bool> _003CAddEmailAndPassword_003Eb__0()
		{
			if (_coreAuthentication != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D100");
				Task<bool> result = default(Task<bool>);
				return result;
			}
			return (Task<bool>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass36_0
	{
		public string id;

		internal Task<bool> _003CLinkCustomID_003Eb__0()
		{
			if (_coreAuthentication != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D1A0");
				Task<bool> result = default(Task<bool>);
				return result;
			}
			return (Task<bool>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass36_1
	{
		public string updatedValue;

		internal Task<bool> _003CLinkCustomID_003Eb__2()
		{
			return SetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys.LINKED_CUSTOM_IDS, updatedValue);
		}
	}

	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public string id;

		internal Task<bool> _003CUnlinkCustomId_003Eb__0()
		{
			if (_coreAuthentication != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D1A0");
				Task<bool> result = default(Task<bool>);
				return result;
			}
			return (Task<bool>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass37_1
	{
		public string updatedValue;

		internal Task<bool> _003CUnlinkCustomId_003Eb__2()
		{
			return SetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys.LINKED_CUSTOM_IDS, updatedValue);
		}
	}

	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public string id;

		public bool forceCreate;

		internal Task<ILoginResult> _003CLoginWithCustomID_003Eb__0()
		{
			if (_coreAuthentication != null)
			{
				return _coreAuthentication.LoginWithCustomID(id, forceCreate);
			}
			return (Task<ILoginResult>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public int slot;

		internal Task<PlayerOptionsData> _003CGetSlotSaveData_003Eb__0()
		{
			if (_multiSlotSaveStorage != null)
			{
				return _multiSlotSaveStorage.GetSlotData(slot);
			}
			return (Task<PlayerOptionsData>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public int slot;

		public PlayerOptionsData value;

		internal Task<bool> _003CSetSlotSaveData_003Eb__0()
		{
			if (_multiSlotSaveStorage != null)
			{
				return _multiSlotSaveStorage.SetSlotData(slot, value);
			}
			return (Task<bool>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public PlayFabPlayerData.AllowedPlayerDataKeys key;

		public string value;

		internal Task<bool> _003CSetPlayerData_003Eb__0()
		{
			if (_storage != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D070");
				Task<bool> result = default(Task<bool>);
				return result;
			}
			return (Task<bool>)(object)new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CTryGetPlatformToken_003Eb__0(PlatformAuthToken authToken)
		{
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CTryGetPlatformToken_003Eb__1(string errorMessage)
		{
			//IL_0062: Expected O, but got I
			//IL_0085: Expected O, but got I
			string message = "Obtain platform token errored. Reason: " + errorMessage;
			Debug.LogError(message);
			TaskCompletionSource<bool> taskCompletionSource = t;
			Exception ex = new Exception(errorMessage);
			if (ex != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v2 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).TrySetException((object)ex))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v2 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
					if (!((Task)0).IsCompleted)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
					}
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
			}
		}

		internal unsafe void _003CTryGetPlatformToken_003Eb__2(TokenAbortReason abortReason)
		{
			//IL_0060: Expected O, but got Ref
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			string message = "Obtain platform token aborted. Reason: " + text;
			Debug.LogError(message);
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public PlayFabPlayerData.AllowedPlayerDataKeys key;

		internal Task<string> _003CGetPlayerData_003Eb__0()
		{
			if (_storage != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9CFE0");
				Task<string> result = default(Task<string>);
				return result;
			}
			return (Task<string>)(object)new NullReferenceException();
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CAddEmailAndPassword_003Ed__28 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string email;

		public string password;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0151: Expected I4, but got I8
			//IL_0161: Expected O, but got Ref
			//IL_00dc: Expected O, but got I4
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_01a6: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass28_0();
				CS_0024_003C_003E8__locals2.email = email;
				CS_0024_003C_003E8__locals2.password = password;
				Func<Task<bool>> func = delegate
				{
					if (_coreAuthentication != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D100");
						Task<bool> result = default(Task<bool>);
						return result;
					}
					return (Task<bool>)(object)new NullReferenceException();
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
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
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->SetResult(result: false);
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
	private struct _003CAddOrUpdateContactEmail_003Ed__14 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string email;

		private bool _003Cres_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0027: Expected O, but got I
			//IL_0063: Expected O, but got I4
			//IL_0072: Expected I4, but got I8
			//IL_029f: Expected I4, but got I8
			//IL_02af: Expected O, but got Ref
			//IL_012f: Expected O, but got I4
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_022f: Expected O, but got I4
			//IL_0237: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Expected O, but got Unknown
			//IL_0326: Expected O, but got Ref
			//IL_02ee: Expected O, but got Ref
			Task task;
			Task task2;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				IntPtr intPtr = default(IntPtr);
				object obj = (nint)intPtr;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					_003C_003Eu__2 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__2;
					goto IL_0252;
				}
				_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass14_0();
				CS_0024_003C_003E8__locals2.email = email;
				Func<Task<bool>> func = delegate
				{
					if (_coreAuthentication != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D1A0");
						Task<bool> result = default(Task<bool>);
						return result;
					}
					return (Task<bool>)(object)new NullReferenceException();
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				object obj = CS_0024_003C_003E8__locals2;
				task = (Task)taskAwaiter;
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				object obj = null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v12 (System.Threading.Tasks.Task)+50]");
			_003Cres_003E5__2 = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
			AccountInformation accountInformation = default(AccountInformation);
			Task task3 = accountInformation.Fetch();
			int num3 = task3.m_stateFlags & 0x1600000;
			bool flag4 = num3 == 0;
			bool flag5 = num3 < 0;
			bool flag6 = !flag5;
			object obj4 = !flag6;
			object obj5 = obj4 | flag4;
			task2 = task3;
			if (obj5 == null)
			{
				goto IL_0252;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = (TaskAwaiter)task3;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter awaiter2 = default(TaskAwaiter);
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
			return;
			IL_0252:
			int num4 = task2.m_stateFlags & 0x11000000;
			if (num4 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder3)->SetResult(_003Cres_003E5__2);
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
	private struct _003CExecuteCloudScript_003Ed__22 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<JsonObject> _003C_003Et__builder;

		public string fnName;

		public Dictionary<string, string> parameters;

		private TaskAwaiter<JsonObject> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_015a: Expected I4, but got I8
			//IL_016a: Expected O, but got Ref
			//IL_017f: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_00e5: Expected O, but got I4
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_01af: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<JsonObject>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass22_0();
				CS_0024_003C_003E8__locals4.fnName = fnName;
				CS_0024_003C_003E8__locals4.parameters = parameters;
				Func<Task<JsonObject>> operation = delegate
				{
					PlayFabCloudScript playFabCloudScript = new PlayFabCloudScript();
					return (Task<JsonObject>)((playFabCloudScript != null) ? ((object)playFabCloudScript.Execute(CS_0024_003C_003E8__locals4.fnName, CS_0024_003C_003E8__locals4.parameters)) : ((object)new NullReferenceException()));
				};
				Task<object> task2 = TryOperationAndDoAuth((Func<Task<object>>)(object)operation);
				Task<JsonObject> task3 = ((_003C_003Ec__DisplayClass22_0)(object)task2)._003CExecuteCloudScript_003Eb__0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v30 (System.Threading.Tasks.Task`1<PlayFab.Json.JsonObject>)+38]");
				object obj = (nint)0 & (nint)0x1600000;
				bool flag = obj == null;
				bool flag2 = (nint)obj < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				task = task3;
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<JsonObject>)task3;
					AsyncTaskMethodBuilder<JsonObject> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<JsonObject>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<JsonObject> awaiter = default(TaskAwaiter<JsonObject>);
					((AsyncTaskMethodBuilder<JsonObject>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num = task.m_stateFlags & 0x11000000;
			if (num != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
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

	[StructLayout((LayoutKind)3)]
	private struct _003CGetAccountDetails_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<AccountDetails> _003C_003Et__builder;

		private TaskAwaiter<AccountDetails> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0278: Expected I, but got O
			//IL_028e: Expected O, but got I
			//IL_0198: Expected I4, but got I8
			//IL_01a8: Expected O, but got Ref
			//IL_01bd: Expected O, but got I
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected I, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_00eb: Expected O, but got I
			//IL_0123: Expected O, but got I4
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0302: Expected O, but got I4
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0317: Expected O, but got Unknown
			//IL_01ed: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<AccountDetails>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Func<Task<AccountDetails>> operation = _003C_003Ec._003C_003E9__23_0;
				if (_003C_003Ec._003C_003E9__23_0 == null)
				{
					Func<Task<AccountDetails>> func = (_003C_003Ec._003C_003E9__23_0 = delegate
					{
						//IL_000d: Expected I, but got O
						//IL_00bc: Expected O, but got I
						//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d8: Expected O, but got Unknown
						//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
						//IL_00e5: Expected O, but got Unknown
						//IL_0045: Expected O, but got I
						//IL_004e: Expected O, but got I4
						//IL_005c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0061: Expected O, but got Unknown
						ICoreAuthentication coreAuthentication = _coreAuthentication;
						nint num6;
						object obj13 = default(object);
						if (_coreAuthentication != null)
						{
							num6 = (nint)coreAuthentication;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_0085;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+B0]");
							object obj12 = 0;
							obj13 = 0;
							while (true)
							{
								object obj14 = obj13 + obj13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+v79 @ rax_v10*8]");
								if (0 == (nint)typeof(ICoreAuthentication))
								{
									break;
								}
								obj13++;
								object obj15 = obj13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+12E]");
								if ((nint)obj15 < 0)
								{
									continue;
								}
								goto IL_0085;
							}
							goto IL_0099;
						}
						goto IL_00ef;
						IL_00ef:
						return (Task<AccountDetails>)(object)new NullReferenceException();
						IL_0085:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v107 @ rax_v7] (should have been resolved before IL gen)");
						goto IL_0099;
						IL_0099:
						object obj16 = obj13 + obj13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+8+v162 @ rcx_v9*8]");
						object obj17 = (nint)0 + (nint)8;
						object obj18 = obj17 << 4;
						object obj19 = obj18 + 312;
						object obj20 = obj19 + num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v146 @ rax_v16] (should have been resolved before IL gen)");
						goto IL_00ef;
					});
					nint num = (nint)typeof(_003C_003Ec);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v46 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<>c>)+B8]");
					object obj = (nint)0 + (nint)8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag = (nint)0 == 0;
					operation = func;
					if (!flag)
					{
						object obj2 = obj >> 12;
						object obj3 = obj2 & 0x1FFFFF;
						object obj4 = obj3 >> 6;
						object obj5 = obj4 * 8;
						nint num2 = (nint)(6603577472L + obj5);
						object obj6 = obj3 & 0x3F;
						nint num4;
						do
						{
							object obj7 = 1 << (int)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							object obj8 = 0 | obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							if (num3 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
						}
						while (num4 != 0);
						operation = func;
					}
				}
				Task<object> operation2 = TryOperationAndDoAuth((Func<Task<object>>)(object)operation);
				Task<AccountDetails> task2 = TryOperationAndDoAuth((Func<Task<AccountDetails>>)(object)operation2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v24 (System.Threading.Tasks.Task`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.AccountDetails>)+38]");
				object obj9 = (nint)0 & (nint)0x1600000;
				bool flag2 = obj9 == null;
				bool flag3 = (nint)obj9 < 0;
				bool flag4 = !flag3;
				object obj10 = !flag4;
				object obj11 = obj10 | flag2;
				task = task2;
				if (obj11 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<AccountDetails>)task2;
					AsyncTaskMethodBuilder<AccountDetails> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<AccountDetails>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<AccountDetails> awaiter = default(TaskAwaiter<AccountDetails>);
					((AsyncTaskMethodBuilder<AccountDetails>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num5 = task.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v5 (System.Threading.Tasks.Task)+50]");
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

	[StructLayout((LayoutKind)3)]
	private struct _003CGetAccountEmailAddress_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

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
			//IL_020d: Expected I4, but got I8
			//IL_01c4: Expected O, but got Ref
			//IL_0187: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<AccountDetails>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<AccountDetails> accountDetails = GetAccountDetails();
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
					AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<string>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<AccountDetails> awaiter = default(TaskAwaiter<AccountDetails>);
					((AsyncTaskMethodBuilder<string>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
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
			object result;
			if (((AccountDetails)0).IsPlatformLinked(AccountDetailsType.Email))
			{
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)accountDetails2.PlatformAccounts).get_Item((System.Int32Enum)0);
				result = obj3;
			}
			else
			{
				result = null;
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->SetResult(result);
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
	private struct _003CGetMergeConflictSlotData_003Ed__39 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

		private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0278: Expected I, but got O
			//IL_028e: Expected O, but got I
			//IL_0198: Expected I4, but got I8
			//IL_01a8: Expected O, but got Ref
			//IL_01bd: Expected O, but got I
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected I, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_00eb: Expected O, but got I
			//IL_0123: Expected O, but got I4
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0302: Expected O, but got I4
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0317: Expected O, but got Unknown
			//IL_01ed: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<PlayerOptionsData>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Func<Task<PlayerOptionsData>> operation = _003C_003Ec._003C_003E9__39_0;
				if (_003C_003Ec._003C_003E9__39_0 == null)
				{
					Func<Task<PlayerOptionsData>> func = (_003C_003Ec._003C_003E9__39_0 = delegate
					{
						//IL_000d: Expected I, but got O
						//IL_00bc: Expected O, but got I
						//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d8: Expected O, but got Unknown
						//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
						//IL_00e5: Expected O, but got Unknown
						//IL_0045: Expected O, but got I
						//IL_004e: Expected O, but got I4
						//IL_005c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0061: Expected O, but got Unknown
						IMultiSlotSaveStorage multiSlotSaveStorage = _multiSlotSaveStorage;
						nint num6;
						object obj13 = default(object);
						if (_multiSlotSaveStorage != null)
						{
							num6 = (nint)multiSlotSaveStorage;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage.IMultiSlotSaveStorage>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_0085;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage.IMultiSlotSaveStorage>)+B0]");
							object obj12 = 0;
							obj13 = 0;
							while (true)
							{
								object obj14 = obj13 + obj13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+v79 @ rax_v10*8]");
								if (0 == (nint)typeof(IMultiSlotSaveStorage))
								{
									break;
								}
								obj13++;
								object obj15 = obj13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage.IMultiSlotSaveStorage>)+12E]");
								if ((nint)obj15 < 0)
								{
									continue;
								}
								goto IL_0085;
							}
							goto IL_0099;
						}
						goto IL_00ef;
						IL_00ef:
						return (Task<PlayerOptionsData>)(object)new NullReferenceException();
						IL_0085:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v107 @ rax_v7] (should have been resolved before IL gen)");
						goto IL_0099;
						IL_0099:
						object obj16 = obj13 + obj13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+8+v162 @ rcx_v9*8]");
						object obj17 = (nint)0 + (nint)2;
						object obj18 = obj17 << 4;
						object obj19 = obj18 + 312;
						object obj20 = obj19 + num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v146 @ rax_v16] (should have been resolved before IL gen)");
						goto IL_00ef;
					});
					nint num = (nint)typeof(_003C_003Ec);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v46 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<>c>)+B8]");
					object obj = (nint)0 + (nint)48;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag = (nint)0 == 0;
					operation = func;
					if (!flag)
					{
						object obj2 = obj >> 12;
						object obj3 = obj2 & 0x1FFFFF;
						object obj4 = obj3 >> 6;
						object obj5 = obj4 * 8;
						nint num2 = (nint)(6603577472L + obj5);
						object obj6 = obj3 & 0x3F;
						nint num4;
						do
						{
							object obj7 = 1 << (int)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							object obj8 = 0 | obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							if (num3 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v15 (Il2CppMethodInfo)+462E0]");
						}
						while (num4 != 0);
						operation = func;
					}
				}
				Task<object> operation2 = TryOperationAndDoAuth((Func<Task<object>>)(object)operation);
				Task<PlayerOptionsData> task2 = TryOperationAndDoAuth((Func<Task<PlayerOptionsData>>)(object)operation2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v24 (System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData>)+38]");
				object obj9 = (nint)0 & (nint)0x1600000;
				bool flag2 = obj9 == null;
				bool flag3 = (nint)obj9 < 0;
				bool flag4 = !flag3;
				object obj10 = !flag4;
				object obj11 = obj10 | flag2;
				task = task2;
				if (obj11 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<PlayerOptionsData>)task2;
					AsyncTaskMethodBuilder<PlayerOptionsData> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<PlayerOptionsData>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<PlayerOptionsData> awaiter = default(TaskAwaiter<PlayerOptionsData>);
					((AsyncTaskMethodBuilder<PlayerOptionsData>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num5 = task.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v5 (System.Threading.Tasks.Task)+50]");
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

	[StructLayout((LayoutKind)3)]
	private struct _003CGetPlayerData_003Ed__44 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public PlayFabPlayerData.AllowedPlayerDataKeys key;

		private TaskAwaiter<string> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0155: Expected I4, but got I8
			//IL_0165: Expected O, but got Ref
			//IL_017a: Expected O, but got I
			//IL_00a8: Expected O, but got I
			//IL_00e0: Expected O, but got I4
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_01aa: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass44_0();
				CS_0024_003C_003E8__locals1.key = key;
				Func<Task<string>> operation = delegate
				{
					if (_storage != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9CFE0");
						Task<string> result = default(Task<string>);
						return result;
					}
					return (Task<string>)(object)new NullReferenceException();
				};
				Task<object> task2 = TryOperationAndDoAuth((Func<Task<object>>)(object)operation);
				Task<string> task3 = ((_003C_003Ec__DisplayClass44_0)(object)task2)._003CGetPlayerData_003Eb__0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v27 (System.Threading.Tasks.Task`1<System.String>)+38]");
				object obj = (nint)0 & (nint)0x1600000;
				bool flag = obj == null;
				bool flag2 = (nint)obj < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				task = task3;
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<string>)task3;
					AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<string>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
					((AsyncTaskMethodBuilder<string>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num = task.m_stateFlags & 0x11000000;
			if (num != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
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

	[StructLayout((LayoutKind)3)]
	private struct _003CGetPlayerProfile_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<IPlayerProfile> _003C_003Et__builder;

		private TaskAwaiter<IPlayerProfile> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_003b: Expected I, but got O
			//IL_00c6: Expected O, but got I4
			//IL_0073: Expected O, but got I
			//IL_01a7: Expected I4, but got I8
			//IL_029d: Expected O, but got I4
			//IL_01b7: Expected O, but got Ref
			//IL_01cc: Expected O, but got I
			//IL_01df: Expected O, but got I4
			//IL_01f5: Expected O, but got I
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Expected O, but got Unknown
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Expected O, but got Unknown
			//IL_0132: Expected O, but got I4
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			//IL_024d: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<IPlayerProfile>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
				goto IL_0155;
			}
			ICoreAuthentication coreAuthentication = _coreAuthentication;
			nint num = (nint)coreAuthentication;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v6 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_00b3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v6 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+B0]");
			object obj = 0;
			int num2 = 0;
			while (true)
			{
				object obj2 = num2 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v7+v277 @ rax_v46*8]");
				if (0 == (nint)typeof(ICoreAuthentication))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v6 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+12E]");
				if ((nint)num3 < (nint)0)
				{
					continue;
				}
				goto IL_00b3;
			}
			object obj3 = num2 + num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v7+8+v418 @ rcx_v31*8]");
			object obj4 = (nint)0 + (nint)14;
			object obj5 = obj4 << 4;
			object obj6 = obj5 + 312;
			object obj7 = obj6 + num;
			goto IL_02cc;
			IL_0155:
			int num4 = task.m_stateFlags & 0x11000000;
			if (num4 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder)->SetResult(0);
			return;
			IL_00b3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj = 14;
			object obj8 = default(object);
			obj7 = obj8;
			goto IL_02cc;
			IL_02cc:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v425 @ rdx_v10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			TaskAwaiter<IPlayerProfile> taskAwaiter = default(TaskAwaiter<IPlayerProfile>);
			int num5 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
			bool flag = num5 == 0;
			bool flag2 = num5 < 0;
			bool flag3 = !flag2;
			object obj9 = !flag3;
			object obj10 = obj9 | flag;
			task = (Task)taskAwaiter;
			if (obj10 == null)
			{
				goto IL_0155;
			}
			_003C_003E1__state = 0;
			_003C_003Eu__1 = taskAwaiter;
			AsyncTaskMethodBuilder<IPlayerProfile> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<IPlayerProfile>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter<IPlayerProfile> awaiter = default(TaskAwaiter<IPlayerProfile>);
			((AsyncTaskMethodBuilder<IPlayerProfile>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
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
	private struct _003CGetSlotSaveData_003Ed__40 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PlayerOptionsData> _003C_003Et__builder;

		public int slot;

		private TaskAwaiter<PlayerOptionsData> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0155: Expected I4, but got I8
			//IL_0165: Expected O, but got Ref
			//IL_017a: Expected O, but got I
			//IL_00a8: Expected O, but got I
			//IL_00e0: Expected O, but got I4
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_01aa: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<PlayerOptionsData>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass40_0();
				CS_0024_003C_003E8__locals2.slot = slot;
				Func<Task<PlayerOptionsData>> operation = () => (Task<PlayerOptionsData>)((_multiSlotSaveStorage != null) ? ((object)_multiSlotSaveStorage.GetSlotData(CS_0024_003C_003E8__locals2.slot)) : ((object)new NullReferenceException()));
				Task<object> task2 = TryOperationAndDoAuth((Func<Task<object>>)(object)operation);
				Task<PlayerOptionsData> task3 = ((_003C_003Ec__DisplayClass40_0)(object)task2)._003CGetSlotSaveData_003Eb__0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v27 (System.Threading.Tasks.Task`1<VampireSurvivors.Data.PlayerOptionsData>)+38]");
				object obj = (nint)0 & (nint)0x1600000;
				bool flag = obj == null;
				bool flag2 = (nint)obj < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				task = task3;
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<PlayerOptionsData>)task3;
					AsyncTaskMethodBuilder<PlayerOptionsData> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<PlayerOptionsData>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<PlayerOptionsData> awaiter = default(TaskAwaiter<PlayerOptionsData>);
					((AsyncTaskMethodBuilder<PlayerOptionsData>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num = task.m_stateFlags & 0x11000000;
			if (num != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
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

	[StructLayout((LayoutKind)3)]
	private struct _003CLinkAccount_003Ed__25 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ILinkResult> _003C_003Et__builder;

		public bool force;

		private TaskAwaiter<ILinkResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0155: Expected I4, but got I8
			//IL_0165: Expected O, but got Ref
			//IL_017a: Expected O, but got I
			//IL_00a8: Expected O, but got I
			//IL_00e0: Expected O, but got I4
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_01aa: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILinkResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass25_0();
				CS_0024_003C_003E8__locals2.force = force;
				Func<Task<ILinkResult>> operation = () => (Task<ILinkResult>)((_platformAuthentication != null) ? ((object)_platformAuthentication.LinkAccount(CS_0024_003C_003E8__locals2.force)) : ((object)new NullReferenceException()));
				Task<object> task2 = TryOperationAndDoAuth((Func<Task<object>>)(object)operation);
				Task<ILinkResult> task3 = ((_003C_003Ec__DisplayClass25_0)(object)task2)._003CLinkAccount_003Eb__0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v27 (System.Threading.Tasks.Task`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ILinkResult>)+38]");
				object obj = (nint)0 & (nint)0x1600000;
				bool flag = obj == null;
				bool flag2 = (nint)obj < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				task = task3;
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<ILinkResult>)task3;
					AsyncTaskMethodBuilder<ILinkResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<ILinkResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILinkResult> awaiter = default(TaskAwaiter<ILinkResult>);
					((AsyncTaskMethodBuilder<ILinkResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num = task.m_stateFlags & 0x11000000;
			if (num != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
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

	[StructLayout((LayoutKind)3)]
	private struct _003CLinkCustomID_003Ed__36 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string id;

		private _003C_003Ec__DisplayClass36_0 _003C_003E8__1;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_016d: Expected O, but got I4
			//IL_017c: Expected I4, but got I8
			//IL_0189: Expected I4, but got I8
			//IL_0013: Expected O, but got I4
			//IL_079a: Expected I4, but got I8
			//IL_022b: Expected O, but got I4
			//IL_023a: Expected I4, but got I8
			//IL_0247: Expected I4, but got I8
			//IL_066e: Expected O, but got Ref
			//IL_0508: Expected O, but got I4
			//IL_0517: Expected I4, but got I8
			//IL_0352: Expected O, but got I
			//IL_02a4: Expected O, but got I
			//IL_02dc: Expected O, but got I4
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Expected O, but got Unknown
			//IL_05b2: Expected O, but got I4
			//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_05bf: Expected O, but got Unknown
			//IL_043c: Expected O, but got Ref
			//IL_0757: Expected I4, but got O
			//IL_0757: Expected O, but got I
			//IL_03d6: Expected O, but got I
			//IL_03e6: Expected O, but got I
			//IL_063d: Expected O, but got Ref
			//IL_00f8: Expected O, but got I4
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0140: Expected O, but got Ref
			int num = _003C_003E1__state;
			bool flag = _003C_003E1__state == 0;
			object obj2;
			Task task;
			TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
			if (!flag)
			{
				object obj = num - 1;
				if (flag)
				{
					goto IL_0200;
				}
				if ((nint)obj == 1)
				{
					obj2 = null;
					goto IL_06be;
				}
				_003C_003Ec__DisplayClass36_0 obj3 = new _003C_003Ec__DisplayClass36_0();
				_003C_003E8__1 = obj3;
				_003C_003Ec__DisplayClass36_0 obj4 = _003C_003E8__1;
				obj4.id = id;
				Func<Task<bool>> func = delegate
				{
					if (_coreAuthentication != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D1A0");
						Task<bool> result2 = default(Task<bool>);
						return result2;
					}
					return (Task<bool>)(object)new NullReferenceException();
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
				int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag2 = num2 == 0;
				bool flag3 = num2 < 0;
				bool flag4 = !flag3;
				object obj5 = !flag2;
				object obj6 = flag4 & obj5;
				task = (Task)taskAwaiter;
				if (obj6 == null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			else
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				num = -1;
				task = (Task)_003C_003Eu__1;
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v13 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				goto IL_0200;
			}
			bool result = false;
			goto IL_078b;
			IL_06be:
			Task task2;
			if (num == 2)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task2 = (Task)_003C_003Eu__1;
			}
			else
			{
				Func<Task<bool>> func2 = ((_003C_003Ec__DisplayClass36_1)obj2)._003CLinkCustomID_003Eb__2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
				int num4 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
				bool flag5 = num4 == 0;
				bool flag6 = num4 < 0;
				bool flag7 = !flag6;
				object obj7 = !flag7;
				object obj8 = obj7 | flag5;
				task2 = (Task)taskAwaiter2;
				if (obj8 != null)
				{
					_003C_003E1__state = 2;
					_003C_003Eu__1 = taskAwaiter2;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num5 = task2.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			goto IL_0773;
			IL_0773:
			result = true;
			goto IL_078b;
			IL_078b:
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder3)->SetResult(result);
			return;
			IL_0200:
			Task task3;
			if (num == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				num = -1;
				task3 = (Task)_003C_003Eu__2;
			}
			else
			{
				Func<Task<object>> operation = (Func<Task<object>>)(object)_003C_003Ec._003C_003E9__36_1;
				if (_003C_003Ec._003C_003E9__36_1 == null)
				{
					operation = (Func<Task<object>>)(object)(_003C_003Ec._003C_003E9__36_1 = () => GetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys.LINKED_CUSTOM_IDS));
				}
				Task<object> operation2 = TryOperationAndDoAuth(operation);
				Task<string> task4 = TryOperationAndDoAuth((Func<Task<string>>)(object)operation2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rax_v94 (System.Threading.Tasks.Task`1<System.String>)+38]");
				object obj9 = (nint)0 & (nint)0x1600000;
				bool flag8 = obj9 == null;
				bool flag9 = (nint)obj9 < 0;
				bool flag10 = !flag9;
				object obj10 = !flag10;
				object obj11 = obj10 | flag8;
				task3 = task4;
				if (obj11 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (TaskAwaiter<string>)task4;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter2 = default(TaskAwaiter<string>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
			}
			int num6 = task3.m_stateFlags & 0x11000000;
			if (num6 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rbx_v24 (System.Threading.Tasks.Task)+50]");
			string text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rbx_v24 (System.Threading.Tasks.Task)+50]");
			List<string> list2;
			if ((nint)0 != 0 && text._stringLength > 0)
			{
				bool flag11 = "," != null;
				string separator = ",";
				if (!flag11)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1451 @ rax_v86+B8]");
					object obj13 = 0;
					separator = (string)obj13;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rbx_v24 (System.Threading.Tasks.Task)+50]");
				object obj14 = default(object);
				string[] collection = ((string)0).SplitInternal(separator, (string[])null, 2147483647, (StringSplitOptions)obj14);
				List<string> list = (List<string>)(object)new List<object>(collection);
				list2 = list;
			}
			else
			{
				List<string> list3 = new List<string>();
				list2 = list3;
			}
			string platformAsString = GetPlatformAsString();
			_003C_003Ec__DisplayClass36_0 obj15 = _003C_003E8__1;
			string item = platformAsString + "_" + obj15.id;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
			object obj16 = default(object);
			if (obj16 == null)
			{
				_003C_003Ec__DisplayClass36_1 obj17 = new _003C_003Ec__DisplayClass36_1();
				list2.Add(item);
				string updatedValue = string.Join(",", list2);
				obj17.updatedValue = updatedValue;
				obj2 = obj17;
				goto IL_06be;
			}
			goto IL_0773;
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
	private struct _003CLogin_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

		private ILoginResult _003Cres_003E5__2;

		private TaskAwaiter<ILoginResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005c: Expected O, but got I4
			//IL_006b: Expected I4, but got I8
			//IL_0273: Expected I4, but got I8
			//IL_017a: Expected O, but got I
			//IL_028f: Expected O, but got Ref
			//IL_00c8: Expected O, but got I
			//IL_0100: Expected O, but got I4
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Expected O, but got Unknown
			//IL_0306: Expected O, but got Ref
			//IL_0203: Expected O, but got I4
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Expected O, but got Unknown
			//IL_02ce: Expected O, but got Ref
			Task task;
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
					_003C_003Eu__2 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__2;
					goto IL_0226;
				}
				Func<Task<object>> operation = (Func<Task<object>>)(object)_003C_003Ec._003C_003E9__24_0;
				if (_003C_003Ec._003C_003E9__24_0 == null)
				{
					operation = (Func<Task<object>>)(object)(_003C_003Ec._003C_003E9__24_0 = delegate
					{
						//IL_000d: Expected I, but got O
						//IL_00bc: Expected O, but got I
						//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d8: Expected O, but got Unknown
						//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
						//IL_00e5: Expected O, but got Unknown
						//IL_0045: Expected O, but got I
						//IL_004e: Expected O, but got I4
						//IL_005c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0061: Expected O, but got Unknown
						IPlatformAuthentication platformAuthentication = _platformAuthentication;
						nint num4;
						object obj7 = default(object);
						if (_platformAuthentication != null)
						{
							num4 = (nint)platformAuthentication;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.IPlatformAuthentication>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_0085;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.IPlatformAuthentication>)+B0]");
							object obj6 = 0;
							obj7 = 0;
							while (true)
							{
								object obj8 = obj7 + obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+v79 @ rax_v10*8]");
								if (0 == (nint)typeof(IPlatformAuthentication))
								{
									break;
								}
								obj7++;
								object obj9 = obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.IPlatformAuthentication>)+12E]");
								if ((nint)obj9 < 0)
								{
									continue;
								}
								goto IL_0085;
							}
							goto IL_0099;
						}
						goto IL_00ef;
						IL_00ef:
						return (Task<ILoginResult>)(object)new NullReferenceException();
						IL_0085:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v107 @ rax_v7] (should have been resolved before IL gen)");
						goto IL_0099;
						IL_0099:
						object obj10 = obj7 + obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4+8+v162 @ rcx_v9*8]");
						object obj11 = (nint)0 + (nint)1;
						object obj12 = obj11 << 4;
						object obj13 = obj12 + 312;
						object obj14 = obj13 + num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v146 @ rax_v16] (should have been resolved before IL gen)");
						goto IL_00ef;
					});
				}
				Task<object> operation2 = TryOperationAndDoAuth(operation);
				Task<ILoginResult> task3 = TryOperationAndDoAuth((Func<Task<ILoginResult>>)(object)operation2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rax_v80 (System.Threading.Tasks.Task`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ILoginResult>)+38]");
				object obj = (nint)0 & (nint)0x1600000;
				bool flag = obj == null;
				bool flag2 = (nint)obj < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				task = task3;
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)task3;
					AsyncTaskMethodBuilder<ILoginResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<ILoginResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILoginResult> awaiter = default(TaskAwaiter<ILoginResult>);
					((AsyncTaskMethodBuilder<ILoginResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num = task.m_stateFlags & 0x11000000;
			if (num != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v11 (System.Threading.Tasks.Task)+50]");
			_003Cres_003E5__2 = (ILoginResult)0;
			AccountInformation accountInformation = (AccountInformation)(object)TryOperationAndDoAuth((Func<Task<ILoginResult>>)(object)typeof(AccountInformation));
			Task task4 = accountInformation.Fetch();
			int num2 = task4.m_stateFlags & 0x1600000;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj4 = !flag6;
			object obj5 = obj4 | flag4;
			task2 = task4;
			if (obj5 == null)
			{
				goto IL_0226;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = (TaskAwaiter)task4;
			AsyncTaskMethodBuilder<ILoginResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<ILoginResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter awaiter2 = default(TaskAwaiter);
			((AsyncTaskMethodBuilder<ILoginResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
			return;
			IL_0226:
			int num3 = task2.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			_003C_003E1__state = -2;
			_003Cres_003E5__2 = null;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder3)->SetResult(_003Cres_003E5__2);
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
	private struct _003CLoginWithCustomID_003Ed__38 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

		public string id;

		public bool forceCreate;

		public bool requiresProfileFetch;

		private ILoginResult _003Cres_003E5__2;

		private TaskAwaiter<ILoginResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005c: Expected O, but got I4
			//IL_006b: Expected I4, but got I8
			//IL_02df: Expected I4, but got I8
			//IL_01ba: Expected O, but got I
			//IL_02fb: Expected O, but got Ref
			//IL_0108: Expected O, but got I
			//IL_0140: Expected O, but got I4
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_0372: Expected O, but got Ref
			//IL_026f: Expected O, but got I4
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Expected O, but got Unknown
			//IL_033a: Expected O, but got Ref
			Task task;
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
					_003C_003Eu__2 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__2;
					goto IL_0292;
				}
				_003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass38_0();
				CS_0024_003C_003E8__locals4.id = id;
				CS_0024_003C_003E8__locals4.forceCreate = forceCreate;
				Func<Task<ILoginResult>> operation = () => (Task<ILoginResult>)((_coreAuthentication != null) ? ((object)_coreAuthentication.LoginWithCustomID(CS_0024_003C_003E8__locals4.id, CS_0024_003C_003E8__locals4.forceCreate)) : ((object)new NullReferenceException()));
				Task<object> task3 = TryOperationAndDoAuth((Func<Task<object>>)(object)operation);
				Task<ILoginResult> task4 = ((_003C_003Ec__DisplayClass38_0)(object)task3)._003CLoginWithCustomID_003Eb__0();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v76 (System.Threading.Tasks.Task`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ILoginResult>)+38]");
				object obj = (nint)0 & (nint)0x1600000;
				bool flag = obj == null;
				bool flag2 = (nint)obj < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				task = task4;
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)task4;
					AsyncTaskMethodBuilder<ILoginResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<ILoginResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILoginResult> awaiter = default(TaskAwaiter<ILoginResult>);
					((AsyncTaskMethodBuilder<ILoginResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num = task.m_stateFlags & 0x11000000;
			if (num != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v13 (System.Threading.Tasks.Task)+50]");
			_003Cres_003E5__2 = (ILoginResult)0;
			if (requiresProfileFetch)
			{
				AccountInformation accountInformation = (AccountInformation)(object)((_003C_003Ec__DisplayClass38_0)(object)typeof(AccountInformation))._003CLoginWithCustomID_003Eb__0();
				Task task5 = accountInformation.Fetch();
				TaskAwaiter awaiter2 = task5.GetAwaiter();
				int num2 = ((Task)awaiter2).m_stateFlags & 0x1600000;
				bool flag4 = num2 == 0;
				bool flag5 = num2 < 0;
				bool flag6 = !flag5;
				object obj4 = !flag6;
				object obj5 = obj4 | flag4;
				task2 = (Task)awaiter2;
				if (obj5 == null)
				{
					goto IL_0292;
				}
				_003C_003E1__state = 1;
				_003C_003Eu__2 = awaiter2;
				AsyncTaskMethodBuilder<ILoginResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<ILoginResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				TaskAwaiter awaiter3 = default(TaskAwaiter);
				((AsyncTaskMethodBuilder<ILoginResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter3, ref this);
				return;
			}
			goto IL_02d0;
			IL_0292:
			int num3 = task2.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			goto IL_02d0;
			IL_02d0:
			_003C_003E1__state = -2;
			_003Cres_003E5__2 = null;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder3)->SetResult(_003Cres_003E5__2);
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
	private struct _003CLoginWithDeviceId_003Ed__35 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

		private ILoginResult _003Cres_003E5__2;

		private TaskAwaiter<ILoginResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0063: Expected O, but got I4
			//IL_0072: Expected I4, but got I8
			//IL_0294: Expected I4, but got I8
			//IL_019b: Expected O, but got I
			//IL_017f: Expected I, but got O
			//IL_02b0: Expected O, but got Ref
			//IL_0118: Expected O, but got I4
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Expected O, but got Unknown
			//IL_0224: Expected O, but got I4
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Expected O, but got Unknown
			//IL_0327: Expected O, but got Ref
			//IL_02ef: Expected O, but got Ref
			nint num;
			Task task;
			Task task2;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)0;
				_003C_003E1__state = -1;
				IntPtr intPtr = default(IntPtr);
				num = intPtr;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					_003C_003Eu__2 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__2;
					goto IL_0247;
				}
				string customID = GetCustomID();
				AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
				_003CLoginWithCustomID_003Ed__38 stateMachine = default(_003CLoginWithCustomID_003Ed__38);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<object> task3 = asyncTaskMethodBuilder.Task;
				((AsyncTaskMethodBuilder<ILoginResult>*)task3)->Start(ref *(_003CLoginWithCustomID_003Ed__38*)null);
				TaskAwaiter<ILoginResult> taskAwaiter = default(TaskAwaiter<ILoginResult>);
				int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num2 == 0;
				bool flag2 = num2 < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				num = 0;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<ILoginResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<ILoginResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILoginResult> awaiter = default(TaskAwaiter<ILoginResult>);
					((AsyncTaskMethodBuilder<ILoginResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				num = unchecked((nint)null);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v11 (System.Threading.Tasks.Task)+50]");
			_003Cres_003E5__2 = (ILoginResult)0;
			((AsyncTaskMethodBuilder<ILoginResult>*)typeof(AccountInformation))->Start(ref *(_003CLoginWithCustomID_003Ed__38*)num);
			AccountInformation accountInformation = default(AccountInformation);
			Task task4 = accountInformation.Fetch();
			int num4 = task4.m_stateFlags & 0x1600000;
			bool flag4 = num4 == 0;
			bool flag5 = num4 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			task2 = task4;
			if (obj4 == null)
			{
				goto IL_0247;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = (TaskAwaiter)task4;
			AsyncTaskMethodBuilder<ILoginResult> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<ILoginResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter awaiter2 = default(TaskAwaiter);
			((AsyncTaskMethodBuilder<ILoginResult>*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
			return;
			IL_0247:
			int num5 = task2.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			_003C_003E1__state = -2;
			_003Cres_003E5__2 = null;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder4)->SetResult(_003Cres_003E5__2);
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
	private struct _003CLoginWithEmail_003Ed__29 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

		public string email;

		public string password;

		private ILoginResult _003Cres_003E5__2;

		private TaskAwaiter<ILoginResult> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0064: Expected O, but got I4
			//IL_0073: Expected I4, but got I8
			//IL_0094: Expected I, but got O
			//IL_030a: Expected I4, but got I8
			//IL_0212: Expected O, but got I
			//IL_01f6: Expected I, but got O
			//IL_00cc: Expected O, but got I
			//IL_0441: Expected O, but got I4
			//IL_0329: Expected O, but got Ref
			//IL_034b: Expected O, but got I4
			//IL_0361: Expected O, but got I
			//IL_0378: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Expected O, but got Unknown
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Expected O, but got Unknown
			//IL_0182: Expected O, but got I4
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Expected O, but got Unknown
			//IL_0199: Expected I, but got O
			//IL_03f1: Expected O, but got Ref
			//IL_0292: Expected O, but got I4
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Expected O, but got Unknown
			//IL_02a7: Expected O, but got I4
			//IL_03b9: Expected O, but got Ref
			int num;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)0;
				_003C_003E1__state = -1;
				num = 0;
				task = (Task)_003C_003Eu__1;
				goto IL_01b8;
			}
			ILoginResult loginResult;
			Task task2;
			if (_003C_003E1__state == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				loginResult = null;
				task2 = (Task)_003C_003Eu__2;
				goto IL_02bd;
			}
			ICoreAuthentication coreAuthentication = _coreAuthentication;
			nint num2 = (nint)coreAuthentication;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v11 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_010c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v11 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+B0]");
			object obj = 0;
			int num3 = 0;
			while (true)
			{
				object obj2 = num3 + num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ r8_v35+v507 @ rax_v96*8]");
				if (0 == (nint)typeof(ICoreAuthentication))
				{
					break;
				}
				num3++;
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v11 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ICoreAuthentication>)+12E]");
				if ((nint)num4 < (nint)0)
				{
					continue;
				}
				goto IL_010c;
			}
			object obj3 = num3 + num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ r8_v35+8+v810 @ rcx_v57*8]");
			object obj4 = (nint)0 + (nint)2;
			object obj5 = obj4 << 4;
			object obj6 = obj5 + 312;
			object obj7 = obj6 + num2;
			goto IL_0475;
			IL_02bd:
			int num5 = task2.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			_003C_003E1__state = -2;
			_003Cres_003E5__2 = loginResult;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder)->SetResult(_003Cres_003E5__2);
			return;
			IL_0475:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v819 @ r9_v18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			TaskAwaiter<ILoginResult> taskAwaiter = default(TaskAwaiter<ILoginResult>);
			int num6 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
			bool flag = num6 == 0;
			bool flag2 = num6 < 0;
			bool flag3 = !flag2;
			object obj8 = !flag3;
			object obj9 = obj8 | flag;
			nint num7 = (nint)email;
			num = 0;
			task = (Task)taskAwaiter;
			if (obj9 == null)
			{
				goto IL_01b8;
			}
			_003C_003E1__state = 0;
			_003C_003Eu__1 = taskAwaiter;
			AsyncTaskMethodBuilder<ILoginResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<ILoginResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter<ILoginResult> awaiter = default(TaskAwaiter<ILoginResult>);
			((AsyncTaskMethodBuilder<ILoginResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
			return;
			IL_01b8:
			int num8 = task.m_stateFlags & 0x11000000;
			if (num8 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				num7 = unchecked((nint)null);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v12 (System.Threading.Tasks.Task)+50]");
			_003Cres_003E5__2 = (ILoginResult)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
			AccountInformation accountInformation = default(AccountInformation);
			Task task3 = accountInformation.Fetch();
			int num9 = task3.m_stateFlags & 0x1600000;
			bool flag4 = num9 == 0;
			bool flag5 = num9 < 0;
			bool flag6 = !flag5;
			object obj10 = !flag6;
			object obj11 = obj10 | flag4;
			loginResult = (ILoginResult)num;
			task2 = task3;
			if (obj11 == null)
			{
				goto IL_02bd;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = (TaskAwaiter)task3;
			AsyncTaskMethodBuilder<ILoginResult> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<ILoginResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter awaiter2 = default(TaskAwaiter);
			((AsyncTaskMethodBuilder<ILoginResult>*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
			return;
			IL_010c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj12 = default(object);
			obj7 = obj12;
			goto IL_0475;
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
	private struct _003CRegisterWithEmail_003Ed__31 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string email;

		public string password;

		private bool _003Cres_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005b: Expected O, but got I4
			//IL_006a: Expected I4, but got I8
			//IL_024f: Expected I4, but got I8
			//IL_025f: Expected O, but got Ref
			//IL_00ec: Expected O, but got I4
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_02d6: Expected O, but got Ref
			//IL_01df: Expected O, but got I4
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Expected O, but got Unknown
			//IL_029e: Expected O, but got Ref
			Task task;
			Task task2;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					_003C_003Eu__2 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__2;
					goto IL_0202;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D100");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
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
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rbx_v12 (System.Threading.Tasks.Task)+50]");
			_003Cres_003E5__2 = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
			AccountInformation accountInformation = default(AccountInformation);
			Task task3 = accountInformation.Fetch();
			int num3 = task3.m_stateFlags & 0x1600000;
			bool flag4 = num3 == 0;
			bool flag5 = num3 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			task2 = task3;
			if (obj4 == null)
			{
				goto IL_0202;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = (TaskAwaiter)task3;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter awaiter2 = default(TaskAwaiter);
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
			return;
			IL_0202:
			int num4 = task2.m_stateFlags & 0x11000000;
			if (num4 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder3)->SetResult(_003Cres_003E5__2);
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
	private struct _003CRemoveContactEmailAddress_003Ed__19 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0116: Expected I4, but got I8
			//IL_00a1: Expected O, but got I4
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_0126: Expected O, but got Ref
			//IL_016b: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
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
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->SetResult(result: false);
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
	private struct _003CResendAccountVerificationEmail_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		private TaskAwaiter<IPlayerProfile> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

		private TaskAwaiter<bool> _003C_003Eu__3;

		private unsafe void MoveNext()
		{
			//IL_016a: Expected O, but got I4
			//IL_0179: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0141: Expected O, but got I4
			//IL_0150: Expected I4, but got I8
			//IL_01db: Expected O, but got I
			//IL_0118: Expected O, but got I4
			//IL_0127: Expected I4, but got I8
			//IL_0596: Expected I4, but got I8
			//IL_0528: Expected O, but got Ref
			//IL_0379: Expected O, but got I4
			//IL_0381: Unknown result type (might be due to invalid IL or missing references)
			//IL_0386: Expected O, but got Unknown
			//IL_00b2: Expected O, but got I4
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Expected O, but got Unknown
			//IL_04c4: Expected O, but got Ref
			//IL_00fa: Expected O, but got Ref
			//IL_02a0: Expected O, but got I4
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Expected O, but got Unknown
			//IL_04fc: Expected O, but got Ref
			//IL_046d: Expected O, but got Ref
			bool flag = _003C_003E1__state == 0;
			Task task;
			Task task2;
			Task task3;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003Eu__2 = (TaskAwaiter<string>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__2;
					goto IL_02c3;
				}
				if ((nint)obj == 1)
				{
					_003C_003Eu__3 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__3;
					goto IL_039c;
				}
				Task<IPlayerProfile> playerProfile = GetPlayerProfile();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<IPlayerProfile> taskAwaiter = default(TaskAwaiter<IPlayerProfile>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag2 = num == 0;
				bool flag3 = num < 0;
				bool flag4 = !flag3;
				object obj2 = !flag2;
				object obj3 = flag4 & obj2;
				task3 = (Task)taskAwaiter;
				if (obj3 == null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<IPlayerProfile> awaiter = default(TaskAwaiter<IPlayerProfile>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			else
			{
				_003C_003Eu__1 = (TaskAwaiter<IPlayerProfile>)0;
				_003C_003E1__state = -1;
				task3 = (Task)_003C_003Eu__1;
			}
			int num2 = task3.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v2 (System.Threading.Tasks.Task)+50]");
			object obj4 = 0;
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v830 @ rdx_v4+198] (should have been resolved before IL gen)");
			object obj6 = default(object);
			if (obj6 == null)
			{
				AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<object>);
				_003CResetContactEmailAddress_003Ed__17 stateMachine = default(_003CResetContactEmailAddress_003Ed__17);
				asyncTaskMethodBuilder2.Start(ref stateMachine);
				Task<object> task4 = asyncTaskMethodBuilder2.Task;
				((AsyncTaskMethodBuilder<string>*)task4)->Start(ref *(_003CResetContactEmailAddress_003Ed__17*)null);
				TaskAwaiter<string> taskAwaiter2 = default(TaskAwaiter<string>);
				int num3 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
				bool flag5 = num3 == 0;
				bool flag6 = num3 < 0;
				bool flag7 = !flag6;
				object obj7 = !flag7;
				object obj8 = obj7 | flag5;
				task = (Task)taskAwaiter2;
				if (obj8 == null)
				{
					goto IL_02c3;
				}
				_003C_003E1__state = 1;
				_003C_003Eu__2 = taskAwaiter2;
				AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				TaskAwaiter<string> awaiter2 = default(TaskAwaiter<string>);
				((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
				return;
			}
			bool result = false;
			goto IL_0587;
			IL_0587:
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder4)->SetResult(result);
			return;
			IL_039c:
			int num4 = task2.m_stateFlags & 0x11000000;
			if (num4 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rbx_v17 (System.Threading.Tasks.Task)+50]");
			result = false;
			ResendVerificationEmailAllowedService resendVerificationEmailAllowedService = new ResendVerificationEmailAllowedService();
			DateTime now = DateTime.Now;
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime = dateTime2.Add(30.0, 1000);
			DateTime dateTime3 = default(DateTime);
			object arg = dateTime3;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			string value = string.FormatHelper((IFormatProvider)CultureInfo.invariant_culture_info, "{0:O}", (System.ParamsArray)(&paramsArray2));
			string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(resendVerificationEmailAllowedService.key);
			PlayerPrefs.SetString(userSpecificKey, value);
			PlayerPrefs.Save();
			goto IL_0587;
			IL_02c3:
			int num5 = task.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			TaskAwaiter<bool> taskAwaiter3 = default(TaskAwaiter<bool>);
			int num6 = ((Task)taskAwaiter3).m_stateFlags & 0x1600000;
			bool flag8 = num6 == 0;
			bool flag9 = num6 < 0;
			bool flag10 = !flag9;
			object obj9 = !flag10;
			object obj10 = obj9 | flag8;
			task2 = (Task)taskAwaiter3;
			if (obj10 == null)
			{
				goto IL_039c;
			}
			_003C_003E1__state = 2;
			_003C_003Eu__3 = taskAwaiter3;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder5 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter<bool> awaiter3 = default(TaskAwaiter<bool>);
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder5)->AwaitUnsafeOnCompleted(ref awaiter3, ref this);
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
	private struct _003CResetContactEmailAddress_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		private string _003CaccountEmailAddress_003E5__2;

		private TaskAwaiter<string> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005b: Expected O, but got I4
			//IL_006a: Expected I4, but got I8
			//IL_0163: Expected O, but got I
			//IL_0255: Expected I4, but got I8
			//IL_00eb: Expected O, but got I4
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_0271: Expected O, but got Ref
			//IL_02e8: Expected O, but got Ref
			//IL_01e0: Expected O, but got I4
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Expected O, but got Unknown
			//IL_02b0: Expected O, but got Ref
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
					_003C_003Eu__2 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__2;
					goto IL_0203;
				}
				Task<string> accountEmailAddress = GetAccountEmailAddress();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
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
					AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<string>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
					((AsyncTaskMethodBuilder<string>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v10 (System.Threading.Tasks.Task)+50]");
			_003CaccountEmailAddress_003E5__2 = (string)0;
			Task<bool> task3 = AddOrUpdateContactEmail(_003CaccountEmailAddress_003E5__2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
			int num3 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
			bool flag4 = num3 == 0;
			bool flag5 = num3 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			task2 = (Task)taskAwaiter2;
			if (obj4 == null)
			{
				goto IL_0203;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__2 = taskAwaiter2;
			AsyncTaskMethodBuilder<string> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<string>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			TaskAwaiter<bool> awaiter2 = default(TaskAwaiter<bool>);
			((AsyncTaskMethodBuilder<string>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
			return;
			IL_0203:
			int num4 = task2.m_stateFlags & 0x11000000;
			if (num4 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			_003C_003E1__state = -2;
			_003CaccountEmailAddress_003E5__2 = null;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder3)->SetResult(_003CaccountEmailAddress_003E5__2);
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
	private struct _003CSetPlayerData_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public PlayFabPlayerData.AllowedPlayerDataKeys key;

		public string value;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0160: Expected I4, but got I8
			//IL_0170: Expected O, but got Ref
			//IL_00eb: Expected O, but got I4
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_01b5: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass42_0();
				CS_0024_003C_003E8__locals2.key = key;
				CS_0024_003C_003E8__locals2.value = value;
				Func<Task<bool>> func = delegate
				{
					if (_storage != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D070");
						Task<bool> result = default(Task<bool>);
						return result;
					}
					return (Task<bool>)(object)new NullReferenceException();
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
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
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->SetResult(result: false);
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
	private struct _003CSetSlotSaveData_003Ed__41 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public int slot;

		public PlayerOptionsData value;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0160: Expected I4, but got I8
			//IL_0170: Expected O, but got Ref
			//IL_00eb: Expected O, but got I4
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_01b5: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass41_0();
				CS_0024_003C_003E8__locals4.slot = slot;
				CS_0024_003C_003E8__locals4.value = value;
				Func<Task<bool>> func = () => (Task<bool>)((_multiSlotSaveStorage != null) ? ((object)_multiSlotSaveStorage.SetSlotData(CS_0024_003C_003E8__locals4.slot, CS_0024_003C_003E8__locals4.value)) : ((object)new NullReferenceException()));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
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
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->SetResult(result: false);
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
	private struct _003CTryOperationAndDoAuth_003Ed__7<T> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

		public Func<Task<T>> operation;

		private TaskAwaiter<T> _003C_003Eu__1;

		private TaskAwaiter<ILoginResult> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_00bb: Expected O, but got I
			//IL_0093: Expected O, but got I
			//IL_00a6: Expected O, but got I8
			//IL_022a: Expected O, but got I
			//IL_023d: Expected O, but got I8
			//IL_004e: Expected O, but got I
			//IL_0061: Expected O, but got I8
			//IL_06d5: Expected O, but got I8
			//IL_0158: Expected O, but got I4
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_01e1: Expected O, but got I4
			//IL_02e4: Expected O, but got I4
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Expected O, but got Unknown
			//IL_0381: Expected O, but got I
			//IL_039d: Expected I, but got O
			//IL_0538: Expected O, but got Ref
			//IL_0596: Expected O, but got I4
			//IL_020b: Expected O, but got Ref
			//IL_05c0: Expected O, but got Ref
			//IL_0468: Expected O, but got I4
			//IL_0470: Unknown result type (might be due to invalid IL or missing references)
			//IL_0475: Expected O, but got Unknown
			//IL_0554: Expected O, but got I4
			//IL_057e: Expected O, but got Ref
			bool flag = System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == null;
			if (flag)
			{
				goto IL_0066;
			}
			nint num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref this, 1));
			Task task;
			nint num5;
			_003CTryOperationAndDoAuth_003Ed__7<T> obj;
			if (!flag)
			{
				if (num != 1)
				{
					goto IL_0066;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<TryOperationAndDoAuth>d__7`1<T>)+28]");
				task = (Task)0;
				_ = 0;
				obj = (_003CTryOperationAndDoAuth_003Ed__7<T>)4294967295L;
			}
			else
			{
				Task task2;
				if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == (void*)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<TryOperationAndDoAuth>d__7`1<T>)+30]");
					task2 = (Task)0;
					_ = 0;
					obj = (_003CTryOperationAndDoAuth_003Ed__7<T>)4294967295L;
				}
				else
				{
					Task<ILoginResult> task3 = LoginWithDeviceId();
					if (task3 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					Task task4 = default(Task);
					if (task4 == null)
					{
						throw new NullReferenceException();
					}
					int num2 = task4.m_stateFlags & 0x1600000;
					bool flag2 = num2 == 0;
					bool flag3 = num2 < 0;
					bool flag4 = !flag3;
					object obj2 = !flag4;
					object obj3 = obj2 | flag2;
					task2 = task4;
					if (obj3 != null)
					{
						obj = (_003CTryOperationAndDoAuth_003Ed__7<T>)1;
						nint num3 = 0;
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182E24FE0");
						return;
					}
				}
				if (task2 == null)
				{
					throw new NullReferenceException();
				}
				int num4 = task2.m_stateFlags & 0x11000000;
				if (num4 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
				}
				Debug.Log("Successfully auto logged in after operation failed, retrying operation...");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<TryOperationAndDoAuth>d__7`1<T>)+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<TryOperationAndDoAuth>d__7`1<T>)+20]");
				bool flag5 = (nint)0 == 0;
				num5 = unchecked((nint)null);
				if (flag5)
				{
					num = num5;
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rbx_v22+28]");
				num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v820 @ rbx_v22+18] (should have been resolved before IL gen)");
				object obj6 = default(object);
				if (obj6 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task5 = default(Task);
				if (task5 == null)
				{
					throw new NullReferenceException();
				}
				int num6 = task5.m_stateFlags & 0x1600000;
				bool flag6 = num6 == 0;
				bool flag7 = num6 < 0;
				bool flag8 = !flag7;
				object obj7 = !flag8;
				object obj8 = obj7 | flag6;
				task = task5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rbx_v22+28]");
				num = 0;
				if (obj8 != null)
				{
					obj = (_003CTryOperationAndDoAuth_003Ed__7<T>)2;
					nint num7 = 0;
					object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182E24FE0");
					return;
				}
			}
			bool flag9 = task == null;
			num5 = num;
			bool result;
			if (!flag9)
			{
				int num8 = task.m_stateFlags & 0x11000000;
				if (num8 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rbx_v27 (System.Threading.Tasks.Task)+50]");
				result = false;
				goto IL_06c8;
			}
			throw new NullReferenceException();
			IL_06c8:
			obj = (_003CTryOperationAndDoAuth_003Ed__7<T>)4294967294L;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->SetResult(result);
			return;
			IL_0066:
			Task task6;
			if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<TryOperationAndDoAuth>d__7`1<T>)+28]");
				task6 = (Task)0;
				_ = 0;
				obj = (_003CTryOperationAndDoAuth_003Ed__7<T>)4294967295L;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<TryOperationAndDoAuth>d__7`1<T>)+20]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<TryOperationAndDoAuth>d__7`1<T>)+20]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v113 @ rbx_v17+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task7 = default(Task);
				int num9 = task7.m_stateFlags & 0x1600000;
				bool flag10 = num9 == 0;
				bool flag11 = num9 < 0;
				bool flag12 = !flag11;
				object obj11 = !flag12;
				object obj12 = obj11 | flag10;
				task6 = task7;
				if (obj12 != null)
				{
					obj = (_003CTryOperationAndDoAuth_003Ed__7<T>)0;
					nint num10 = 0;
					object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182E24FE0");
					return;
				}
			}
			int num11 = task6.m_stateFlags & 0x11000000;
			if (num11 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task6);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rbx_v15 (System.Threading.Tasks.Task)+50]");
			result = false;
			goto IL_06c8;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
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
	private struct _003CUnlinkAccount_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0275: Expected I, but got O
			//IL_0195: Expected I4, but got I8
			//IL_01a5: Expected O, but got Ref
			//IL_0046: Expected O, but got I
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected I, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected I, but got Unknown
			//IL_0120: Expected O, but got I4
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_02ff: Expected O, but got I4
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Expected O, but got Unknown
			//IL_01ea: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Func<Task<bool>> func = _003C_003Ec._003C_003E9__26_0;
				if (_003C_003Ec._003C_003E9__26_0 == null)
				{
					Func<Task<bool>> func2 = (_003C_003Ec._003C_003E9__26_0 = delegate
					{
						if (_platformAuthentication != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							Task<bool> result = default(Task<bool>);
							return result;
						}
						return (Task<bool>)(object)new NullReferenceException();
					});
					nint num = (nint)typeof(_003C_003Ec);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v46 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.BackendFacade+<>c>)+B8]");
					nint num2 = (nint)0 + (nint)24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag = (nint)0 == 0;
					func = func2;
					if (!flag)
					{
						object obj = num2 >> 12;
						object obj2 = obj & 0x1FFFFF;
						object obj3 = obj2 >> 6;
						object obj4 = obj3 * 8;
						nint num3 = (nint)(6603577472L + obj4);
						num2 = (nint)(obj2 & 0x3F);
						nint num5;
						do
						{
							object obj5 = 1 << (int)num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							object obj6 = 0 | obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							if (num4 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r8_v15 (Il2CppMethodInfo)+462E0]");
							num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ r8_v15 (Il2CppMethodInfo)+462E0]");
						}
						while (num5 != 0);
						func = func2;
					}
				}
				Task<bool> task2 = ((_003C_003Ec)(object)func)._003CUnlinkAccount_003Eb__26_0();
				TaskAwaiter<bool> taskAwaiter = (TaskAwaiter<bool>)((_003C_003Ec)(object)task2)._003CUnlinkAccount_003Eb__26_0();
				int num6 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag2 = num6 == 0;
				bool flag3 = num6 < 0;
				bool flag4 = !flag3;
				object obj7 = !flag4;
				object obj8 = obj7 | flag2;
				task = (Task)taskAwaiter;
				if (obj8 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num7 = task.m_stateFlags & 0x11000000;
			if (num7 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v5 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->SetResult(result: false);
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
	private struct _003CUnlinkAccount_003Ed__27 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public IPlatformAuthentication platformAuthentication;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0151: Expected I4, but got I8
			//IL_0161: Expected O, but got Ref
			//IL_00dc: Expected O, but got I4
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_01a6: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass27_0();
				CS_0024_003C_003E8__locals2.platformAuthentication = platformAuthentication;
				Func<Task<bool>> func = delegate
				{
					if (CS_0024_003C_003E8__locals2.platformAuthentication != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						Task<bool> result = default(Task<bool>);
						return result;
					}
					return (Task<bool>)(object)new NullReferenceException();
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
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
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->SetResult(result: false);
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
	private struct _003CUnlinkCustomId_003Ed__37 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public string id;

		private _003C_003Ec__DisplayClass37_0 _003C_003E8__1;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_016d: Expected O, but got I4
			//IL_017c: Expected I4, but got I8
			//IL_0189: Expected I4, but got I8
			//IL_0013: Expected O, but got I4
			//IL_0788: Expected I4, but got I8
			//IL_022b: Expected O, but got I4
			//IL_023a: Expected I4, but got I8
			//IL_0247: Expected I4, but got I8
			//IL_065c: Expected O, but got Ref
			//IL_04f6: Expected O, but got I4
			//IL_0505: Expected I4, but got I8
			//IL_0352: Expected O, but got I
			//IL_02a4: Expected O, but got I
			//IL_02dc: Expected O, but got I4
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Expected O, but got Unknown
			//IL_05a0: Expected O, but got I4
			//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ad: Expected O, but got Unknown
			//IL_043c: Expected O, but got Ref
			//IL_0745: Expected I4, but got O
			//IL_0745: Expected O, but got I
			//IL_03d6: Expected O, but got I
			//IL_03e6: Expected O, but got I
			//IL_062b: Expected O, but got Ref
			//IL_00f8: Expected O, but got I4
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0140: Expected O, but got Ref
			int num = _003C_003E1__state;
			bool flag = _003C_003E1__state == 0;
			object obj2;
			Task task;
			TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
			if (!flag)
			{
				object obj = num - 1;
				if (flag)
				{
					goto IL_0200;
				}
				if ((nint)obj == 1)
				{
					obj2 = null;
					goto IL_06ac;
				}
				_003C_003Ec__DisplayClass37_0 obj3 = new _003C_003Ec__DisplayClass37_0();
				_003C_003E8__1 = obj3;
				_003C_003Ec__DisplayClass37_0 obj4 = _003C_003E8__1;
				obj4.id = id;
				Func<Task<bool>> func = delegate
				{
					if (_coreAuthentication != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D1A0");
						Task<bool> result2 = default(Task<bool>);
						return result2;
					}
					return (Task<bool>)(object)new NullReferenceException();
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
				int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag2 = num2 == 0;
				bool flag3 = num2 < 0;
				bool flag4 = !flag3;
				object obj5 = !flag2;
				object obj6 = flag4 & obj5;
				task = (Task)taskAwaiter;
				if (obj6 == null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			else
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				num = -1;
				task = (Task)_003C_003Eu__1;
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v13 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				goto IL_0200;
			}
			bool result = false;
			goto IL_0779;
			IL_06ac:
			Task task2;
			if (num == 2)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task2 = (Task)_003C_003Eu__1;
			}
			else
			{
				Func<Task<bool>> func2 = ((_003C_003Ec__DisplayClass37_1)obj2)._003CUnlinkCustomId_003Eb__2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BF30");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
				int num4 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
				bool flag5 = num4 == 0;
				bool flag6 = num4 < 0;
				bool flag7 = !flag6;
				object obj7 = !flag7;
				object obj8 = obj7 | flag5;
				task2 = (Task)taskAwaiter2;
				if (obj8 != null)
				{
					_003C_003E1__state = 2;
					_003C_003Eu__1 = taskAwaiter2;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num5 = task2.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			goto IL_0761;
			IL_0761:
			result = true;
			goto IL_0779;
			IL_0779:
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder3)->SetResult(result);
			return;
			IL_0200:
			Task task3;
			if (num == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				num = -1;
				task3 = (Task)_003C_003Eu__2;
			}
			else
			{
				Func<Task<object>> operation = (Func<Task<object>>)(object)_003C_003Ec._003C_003E9__37_1;
				if (_003C_003Ec._003C_003E9__37_1 == null)
				{
					operation = (Func<Task<object>>)(object)(_003C_003Ec._003C_003E9__37_1 = () => GetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys.LINKED_CUSTOM_IDS));
				}
				Task<object> operation2 = TryOperationAndDoAuth(operation);
				Task<string> task4 = TryOperationAndDoAuth((Func<Task<string>>)(object)operation2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ rax_v93 (System.Threading.Tasks.Task`1<System.String>)+38]");
				object obj9 = (nint)0 & (nint)0x1600000;
				bool flag8 = obj9 == null;
				bool flag9 = (nint)obj9 < 0;
				bool flag10 = !flag9;
				object obj10 = !flag10;
				object obj11 = obj10 | flag8;
				task3 = task4;
				if (obj11 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (TaskAwaiter<string>)task4;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter2 = default(TaskAwaiter<string>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
			}
			int num6 = task3.m_stateFlags & 0x11000000;
			if (num6 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rbx_v24 (System.Threading.Tasks.Task)+50]");
			string text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rbx_v24 (System.Threading.Tasks.Task)+50]");
			List<string> list2;
			if ((nint)0 != 0 && text._stringLength > 0)
			{
				bool flag11 = "," != null;
				string separator = ",";
				if (!flag11)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1435 @ rax_v85+B8]");
					object obj13 = 0;
					separator = (string)obj13;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rbx_v24 (System.Threading.Tasks.Task)+50]");
				object obj14 = default(object);
				string[] collection = ((string)0).SplitInternal(separator, (string[])null, 2147483647, (StringSplitOptions)obj14);
				List<string> list = (List<string>)(object)new List<object>(collection);
				list2 = list;
			}
			else
			{
				List<string> list3 = new List<string>();
				list2 = list3;
			}
			string platformAsString = GetPlatformAsString();
			_003C_003Ec__DisplayClass37_0 obj15 = _003C_003E8__1;
			string item = platformAsString + "_" + obj15.id;
			if (((List<object>)(object)list2).Remove((object)item))
			{
				_003C_003Ec__DisplayClass37_1 obj16 = new _003C_003Ec__DisplayClass37_1();
				string updatedValue = string.Join(",", list2);
				obj16.updatedValue = updatedValue;
				obj2 = obj16;
				goto IL_06ac;
			}
			goto IL_0761;
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

	private static IPlatformConfiguration _platformConfiguration;

	private static readonly IPlatform _platform;

	private static readonly ICoreAuthentication _coreAuthentication;

	private static readonly IPlatformAuthentication _platformAuthentication;

	private static readonly IPlayerDataStorage _storage;

	private static readonly IMultiSlotSaveStorage _multiSlotSaveStorage;

	static BackendFacade()
	{
		PlayFabConfig platformConfiguration = new PlayFabConfig();
		_platformConfiguration = platformConfiguration;
		PlayFabCoreAuthentication coreAuthentication = new PlayFabCoreAuthentication();
		_coreAuthentication = coreAuthentication;
		PlayFabPlayerData storage = new PlayFabPlayerData();
		_storage = storage;
		MultiSlotSaveStorage multiSlotSaveStorage = null;
		if (_storage != null)
		{
			multiSlotSaveStorage.storage = _storage;
			multiSlotSaveStorage.maxSlots = 1;
			GZipSaveDataCompressor compressor = new GZipSaveDataCompressor();
			multiSlotSaveStorage.compressor = compressor;
			_multiSlotSaveStorage = multiSlotSaveStorage;
			_platformAuthentication = (IPlatformAuthentication)(_platform = new PlayFabSteam());
			if (_platform == null)
			{
				Debug.LogWarning("Unknown platform.");
			}
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("storage");
		throw ex;
	}

	private static Task<T> TryOperationAndDoAuth<T>(Func<Task<T>> operation)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CTryOperationAndDoAuth_003Ed__7<bool> stateMachine = default(_003CTryOperationAndDoAuth_003Ed__7<bool>);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<T>)(object)asyncTaskMethodBuilder.Task;
	}

	public unsafe static string GetPlatformAsString()
	{
		//IL_0063: Expected O, but got Ref
		PlatformType platformType = GetPlatformType();
		if (HumanReadablePlatform._platformTypeToString != null)
		{
			object obj = default(object);
			if (!((Dictionary<System.Int32Enum, object>)(object)HumanReadablePlatform._platformTypeToString).TryGetValue((System.Int32Enum)platformType, out object value))
			{
				return ((Enum)(&obj)).ToString();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			return LocalizationManager.GetTranslation((string)value, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		}
		return (string)(object)new NullReferenceException();
	}

	public static PlatformType GetPlatformType()
	{
		//IL_0022: Expected I4, but got O
		if (_platform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			PlatformType result = default(PlatformType);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (PlatformType)ex;
	}

	public static string GetEnvironment()
	{
		if (_platformConfiguration != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			string result = default(string);
			return result;
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe static bool SupportsPlatformAuthentication()
	{
		//IL_001c: Expected I, but got O
		//IL_00d0: Expected O, but got I
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_0087: Expected O, but got I
		//IL_00a1: Expected O, but got I4
		//IL_0112: Expected O, but got Ref
		PlatformType platformType = GetPlatformType();
		nint num = (nint)typeof(PlatformType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.PlatformType>)+28]");
		object o;
		if ((nint)0 >= (nint)0)
		{
			o = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.PlatformType>)+60]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.PlatformType>)+135]");
				object obj = (nint)0 & (nint)8;
				bool flag = obj == null;
				object obj2 = !flag;
				o = null;
				if (obj2 != null)
				{
					goto IL_0105;
				}
			}
			object obj3 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.PlatformType>)+F8]");
			object obj4 = -16;
			object obj5 = obj3 + 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			o = obj3;
		}
		goto IL_0105;
		IL_0105:
		IntPtr intPtr = default(IntPtr);
		bool flag2 = ValueType.DefaultEquals((object)(&intPtr), o);
		return (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
	}

	public static string GetAccountId()
	{
		if (_coreAuthentication != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			string result = default(string);
			return result;
		}
		return (string)(object)new NullReferenceException();
	}

	public static bool IsLoggedIn()
	{
		//IL_0022: Expected I4, but got O
		if (_coreAuthentication != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static Task<bool> AddOrUpdateContactEmail(string email)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CAddOrUpdateContactEmail_003Ed__14 stateMachine = default(_003CAddOrUpdateContactEmail_003Ed__14);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<string> GetAccountEmailAddress()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetAccountEmailAddress_003Ed__15 stateMachine = default(_003CGetAccountEmailAddress_003Ed__15);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<string>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<IPlayerProfile> GetPlayerProfile()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetPlayerProfile_003Ed__16 stateMachine = default(_003CGetPlayerProfile_003Ed__16);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<IPlayerProfile>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<string> ResetContactEmailAddress()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CResetContactEmailAddress_003Ed__17 stateMachine = default(_003CResetContactEmailAddress_003Ed__17);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<string>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<bool> ResendAccountVerificationEmail()
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CResendAccountVerificationEmail_003Ed__18 stateMachine = default(_003CResendAccountVerificationEmail_003Ed__18);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<bool> RemoveContactEmailAddress()
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CRemoveContactEmailAddress_003Ed__19 stateMachine = default(_003CRemoveContactEmailAddress_003Ed__19);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static void Logout()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
	}

	public static void SetDefaultAuthContext(PlayFabAuthenticationContext ctx)
	{
		PlayFabSettings.staticPlayer.CopyFrom(ctx);
	}

	public static Task<JsonObject> ExecuteCloudScript(string fnName, Dictionary<string, string> parameters = null)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CExecuteCloudScript_003Ed__22 stateMachine = default(_003CExecuteCloudScript_003Ed__22);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<JsonObject>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<AccountDetails> GetAccountDetails()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetAccountDetails_003Ed__23 stateMachine = default(_003CGetAccountDetails_003Ed__23);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<AccountDetails>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<ILoginResult> Login()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CLogin_003Ed__24 stateMachine = default(_003CLogin_003Ed__24);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ILoginResult>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<ILinkResult> LinkAccount(bool force = false)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CLinkAccount_003Ed__25 stateMachine = default(_003CLinkAccount_003Ed__25);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ILinkResult>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<bool> UnlinkAccount()
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CUnlinkAccount_003Ed__26 stateMachine = default(_003CUnlinkAccount_003Ed__26);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<bool> UnlinkAccount(IPlatformAuthentication platformAuthentication)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CUnlinkAccount_003Ed__27 stateMachine = default(_003CUnlinkAccount_003Ed__27);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<bool> AddEmailAndPassword(string email, string password)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CAddEmailAndPassword_003Ed__28 stateMachine = default(_003CAddEmailAndPassword_003Ed__28);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<ILoginResult> LoginWithEmail(string email, string password)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CLoginWithEmail_003Ed__29 stateMachine = default(_003CLoginWithEmail_003Ed__29);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ILoginResult>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task SendPasswordReset(string email)
	{
		if (_coreAuthentication != null)
		{
			return _coreAuthentication.RequestPasswordReset(email);
		}
		return (Task)(object)new NullReferenceException();
	}

	public static Task<bool> RegisterWithEmail(string email, string password)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CRegisterWithEmail_003Ed__31 stateMachine = default(_003CRegisterWithEmail_003Ed__31);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static string GetCustomID()
	{
		SystemPlatform sInstance = SystemPlatform.sInstance;
		if (SystemPlatform.sInstance != null && sInstance.m_CurrentSystem != null)
		{
			string uniqueAccountID = sInstance.m_CurrentSystem.UniqueAccountID;
			string deviceUniqueIdentifier = SystemInfo.GetDeviceUniqueIdentifier();
			return uniqueAccountID + deviceUniqueIdentifier;
		}
		return (string)(object)new NullReferenceException();
	}

	public static Task<bool> LinkDeviceId()
	{
		string customID = GetCustomID();
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CLinkCustomID_003Ed__36 stateMachine = default(_003CLinkCustomID_003Ed__36);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<bool> UnlinkDeviceId()
	{
		string customID = GetCustomID();
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CUnlinkCustomId_003Ed__37 stateMachine = default(_003CUnlinkCustomId_003Ed__37);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<ILoginResult> LoginWithDeviceId()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CLoginWithDeviceId_003Ed__35 stateMachine = default(_003CLoginWithDeviceId_003Ed__35);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ILoginResult>)(object)asyncTaskMethodBuilder.Task;
	}

	private static Task<bool> LinkCustomID(string id)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CLinkCustomID_003Ed__36 stateMachine = default(_003CLinkCustomID_003Ed__36);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	private static Task<bool> UnlinkCustomId(string id)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CUnlinkCustomId_003Ed__37 stateMachine = default(_003CUnlinkCustomId_003Ed__37);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<ILoginResult> LoginWithCustomID(string id, bool forceCreate = false, bool requiresProfileFetch = true)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CLoginWithCustomID_003Ed__38 stateMachine = default(_003CLoginWithCustomID_003Ed__38);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ILoginResult>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<PlayerOptionsData> GetMergeConflictSlotData()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetMergeConflictSlotData_003Ed__39 stateMachine = default(_003CGetMergeConflictSlotData_003Ed__39);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<PlayerOptionsData>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<PlayerOptionsData> GetSlotSaveData(int slot)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetSlotSaveData_003Ed__40 stateMachine = default(_003CGetSlotSaveData_003Ed__40);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<PlayerOptionsData>)(object)asyncTaskMethodBuilder.Task;
	}

	public static Task<bool> SetSlotSaveData(int slot, PlayerOptionsData value)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CSetSlotSaveData_003Ed__41 stateMachine = default(_003CSetSlotSaveData_003Ed__41);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public static Task<bool> SetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys key, string value)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CSetPlayerData_003Ed__42 stateMachine = default(_003CSetPlayerData_003Ed__42);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public unsafe static Task<bool> TryGetPlatformToken()
	{
		//IL_00a0: Expected O, but got I
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass43_0();
		TaskCompletionSource<bool> t = new TaskCompletionSource<bool>();
		CS_0024_003C_003E8__locals6.t = t;
		Action<PlatformAuthToken> onSuccess = delegate
		{
			TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals6.t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		};
		Action<string> action = delegate(string errorMessage)
		{
			//IL_0062: Expected O, but got I
			//IL_0085: Expected O, but got I
			string message = "Obtain platform token errored. Reason: " + errorMessage;
			Debug.LogError(message);
			TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals6.t;
			Exception ex = new Exception(errorMessage);
			if (ex != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v2 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).TrySetException((object)ex))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v2 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
					if (!((Task)0).IsCompleted)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
					}
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
			}
		};
		action._002Ector((object)CS_0024_003C_003E8__locals6, (IntPtr)(nint)__ldftn(_003C_003Ec__DisplayClass43_0._003CTryGetPlatformToken_003Eb__1));
		Action<TokenAbortReason> onAbort = delegate
		{
			//IL_0060: Expected O, but got Ref
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			string message = "Obtain platform token aborted. Reason: " + text;
			Debug.LogError(message);
			TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals6.t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		};
		if (SystemPlatform.sInstance != null)
		{
			SystemPlatform.sInstance.GetAuthToken(onSuccess, action, onAbort);
			TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals6.t;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v20 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			return (Task<bool>)0;
		}
		throw new NullReferenceException();
	}

	private static Task<string> GetPlayerData(PlayFabPlayerData.AllowedPlayerDataKeys key)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetPlayerData_003Ed__44 stateMachine = default(_003CGetPlayerData_003Ed__44);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<string>)(object)asyncTaskMethodBuilder.Task;
	}
}
