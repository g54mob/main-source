using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Core;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions;
using VampireSurvivors.Framework.Platforms;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms;

public class PlayFabSteam : IPlatform, IPlatformAuthentication
{
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CLinkAccount_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ILinkResult> _003C_003Et__builder;

			public _003C_003Ec__DisplayClass3_0 _003C_003E4__this;

			private TaskAwaiter<ILinkResult> _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_0010: Expected O, but got I4
				//IL_001f: Expected I4, but got I8
				//IL_00ad: Expected O, but got I4
				//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ba: Expected O, but got Unknown
				//IL_0122: Expected I4, but got I8
				//IL_0132: Expected O, but got Ref
				//IL_0147: Expected O, but got I
				//IL_0177: Expected O, but got Ref
				_003C_003Ec__DisplayClass3_0 obj = _003C_003E4__this;
				Task task;
				if (_003C_003E1__state == 0)
				{
					_003C_003Eu__1 = (TaskAwaiter<ILinkResult>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
				}
				else
				{
					Task<ILinkResult> task2 = obj._003C_003E4__this.LinkAccountInternal(obj.force);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
					TaskAwaiter<ILinkResult> taskAwaiter = default(TaskAwaiter<ILinkResult>);
					int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag = num == 0;
					bool flag2 = num < 0;
					bool flag3 = !flag2;
					object obj2 = !flag3;
					object obj3 = obj2 | flag;
					task = (Task)taskAwaiter;
					if (obj3 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncTaskMethodBuilder<ILinkResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<ILinkResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter<ILinkResult> awaiter = default(TaskAwaiter<ILinkResult>);
						((AsyncTaskMethodBuilder<ILinkResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				int num2 = task.m_stateFlags & 0x11000000;
				if (num2 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				_003C_003E1__state = -2;
				AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
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

		public PlayFabSteam _003C_003E4__this;

		public bool force;

		internal Task<ILinkResult> _003CLinkAccount_003Eb__0()
		{
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
			_003C_003CLinkAccount_003Eb__0_003Ed stateMachine = default(_003C_003CLinkAccount_003Eb__0_003Ed);
			asyncTaskMethodBuilder.Start(ref stateMachine);
			return (Task<ILinkResult>)(object)asyncTaskMethodBuilder.Task;
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public bool createAccount;

		public TaskCompletionSource<ILoginResult> t;

		public Action<global::PlayFab.ClientModels.LoginResult> _003C_003E9__3;

		public Action<PlayFabError> _003C_003E9__4;

		internal void _003CLoginOrRegisterInternal_003Eb__0(PlatformAuthToken authToken)
		{
			//IL_0013: Expected O, but got I4
			LoginWithSteamRequest loginWithSteamRequest = new LoginWithSteamRequest();
			loginWithSteamRequest.CreateAccount = (bool?)(object)1;
			loginWithSteamRequest.SteamTicket = authToken._003CToken_003Ek__BackingField;
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			loginWithSteamRequest.CustomTags = customTags;
			Action<global::PlayFab.ClientModels.LoginResult> action = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				action = (_003C_003E9__3 = delegate(global::PlayFab.ClientModels.LoginResult result)
				{
					Debug.Log("Successfully logged in with Steam");
					PlayFabLoginSuccess playFabLoginSuccess = new PlayFabLoginSuccess();
					playFabLoginSuccess.AuthenticationContext = result.AuthenticationContext;
					TaskCompletionSource<ILoginResult> taskCompletionSource = t;
					if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)playFabLoginSuccess))
					{
						bool flag = ((Task<ILoginResult>)(object)taskCompletionSource).TrySetResult((ILoginResult)playFabLoginSuccess);
					}
				});
			}
			Action<PlayFabError> action2 = _003C_003E9__4;
			if (_003C_003E9__4 == null)
			{
				action2 = (_003C_003E9__4 = delegate(PlayFabError error)
				{
					Debug.LogWarning("Encountered error whilst trying to log in with Steam");
					string message = error.GenerateErrorReport();
					Debug.LogWarning(message);
					TaskCompletionSource<ILoginResult> taskCompletionSource = t;
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
				});
			}
			if (loginWithSteamRequest.AuthenticationContext == null)
			{
			}
			string titleId = loginWithSteamRequest.TitleId;
			if (loginWithSteamRequest.TitleId == null)
			{
				titleId = PlayFabSettings.staticSettings.TitleId;
			}
			loginWithSteamRequest.TitleId = titleId;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
		}

		internal void _003CLoginOrRegisterInternal_003Eb__3(global::PlayFab.ClientModels.LoginResult result)
		{
			Debug.Log("Successfully logged in with Steam");
			PlayFabLoginSuccess playFabLoginSuccess = new PlayFabLoginSuccess();
			playFabLoginSuccess.AuthenticationContext = result.AuthenticationContext;
			TaskCompletionSource<ILoginResult> taskCompletionSource = t;
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)playFabLoginSuccess))
			{
				bool flag = ((Task<ILoginResult>)(object)taskCompletionSource).TrySetResult((ILoginResult)playFabLoginSuccess);
			}
		}

		internal void _003CLoginOrRegisterInternal_003Eb__4(PlayFabError error)
		{
			Debug.LogWarning("Encountered error whilst trying to log in with Steam");
			string message = error.GenerateErrorReport();
			Debug.LogWarning(message);
			TaskCompletionSource<ILoginResult> taskCompletionSource = t;
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

		internal void _003CLoginOrRegisterInternal_003Eb__1(string errorMessage)
		{
			TaskCompletionSource<ILoginResult> taskCompletionSource = t;
			Exception ex = new Exception(errorMessage);
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

		internal void _003CLoginOrRegisterInternal_003Eb__2(TokenAbortReason abortReason)
		{
			TaskCompletionSource<ILoginResult> taskCompletionSource = t;
			PlayFabLoginAborted playFabLoginAborted = new PlayFabLoginAborted();
			playFabLoginAborted.TokenAbortReason = abortReason;
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)playFabLoginAborted))
			{
				bool flag = ((Task<ILoginResult>)(object)taskCompletionSource).TrySetResult((ILoginResult)playFabLoginAborted);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public bool force;

		public TaskCompletionSource<ILinkResult> t;

		public Action<LinkSteamAccountResult> _003C_003E9__3;

		public Action<PlayFabError> _003C_003E9__4;

		internal void _003CLinkAccountInternal_003Eb__0(PlatformAuthToken authToken)
		{
			//IL_0013: Expected O, but got I4
			//IL_0021: Expected O, but got I4
			LinkSteamAccountRequest linkSteamAccountRequest = new LinkSteamAccountRequest();
			linkSteamAccountRequest.ForceLink = (bool?)(object)1;
			linkSteamAccountRequest.TicketIsServiceSpecific = (bool?)(object)1;
			linkSteamAccountRequest.SteamTicket = authToken._003CToken_003Ek__BackingField;
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			linkSteamAccountRequest.CustomTags = customTags;
			Action<LinkSteamAccountResult> action = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				action = (_003C_003E9__3 = delegate
				{
					Debug.Log("Successfully linked Steam account");
					TaskCompletionSource<ILinkResult> taskCompletionSource = t;
					PlayFabLinkSuccess result2 = new PlayFabLinkSuccess();
					if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)result2))
					{
						bool flag = ((Task<ILinkResult>)(object)taskCompletionSource).TrySetResult((ILinkResult)result2);
					}
				});
			}
			Action<PlayFabError> action2 = _003C_003E9__4;
			if (_003C_003E9__4 == null)
			{
				action2 = (_003C_003E9__4 = delegate(PlayFabError error)
				{
					Debug.LogWarning("Encountered error whilst trying to link with Steam");
					string message = error.GenerateErrorReport();
					Debug.LogWarning(message);
					TaskCompletionSource<ILinkResult> taskCompletionSource = t;
					PlayFabApiException ex2 = PlayFabApiException.FromPlayFabError(error);
					if (ex2 != null)
					{
						if (!((Task)taskCompletionSource._task).TrySetException((object)ex2) && !taskCompletionSource._task.IsCompleted)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
					}
				});
			}
			PlayFabAuthenticationContext playFabAuthenticationContext = linkSteamAccountRequest.AuthenticationContext;
			if (linkSteamAccountRequest.AuthenticationContext == null)
			{
				playFabAuthenticationContext = PlayFabSettings.staticPlayer;
			}
			string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
			if (playFabAuthenticationContext.ClientSessionTicket != null && clientSessionTicket._stringLength > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
				return;
			}
			PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
			ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
			throw ex;
		}

		internal void _003CLinkAccountInternal_003Eb__3(LinkSteamAccountResult result)
		{
			Debug.Log("Successfully linked Steam account");
			TaskCompletionSource<ILinkResult> taskCompletionSource = t;
			PlayFabLinkSuccess result2 = new PlayFabLinkSuccess();
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)result2))
			{
				bool flag = ((Task<ILinkResult>)(object)taskCompletionSource).TrySetResult((ILinkResult)result2);
			}
		}

		internal void _003CLinkAccountInternal_003Eb__4(PlayFabError error)
		{
			Debug.LogWarning("Encountered error whilst trying to link with Steam");
			string message = error.GenerateErrorReport();
			Debug.LogWarning(message);
			TaskCompletionSource<ILinkResult> taskCompletionSource = t;
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

		internal void _003CLinkAccountInternal_003Eb__1(string errorMessage)
		{
			TaskCompletionSource<ILinkResult> taskCompletionSource = t;
			Exception ex = new Exception(errorMessage);
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

		internal void _003CLinkAccountInternal_003Eb__2(TokenAbortReason abortReason)
		{
			TaskCompletionSource<ILinkResult> taskCompletionSource = t;
			PlayFabLinkAborted playFabLinkAborted = new PlayFabLinkAborted();
			playFabLinkAborted.TokenAbortReason = abortReason;
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)playFabLinkAborted))
			{
				bool flag = ((Task<ILinkResult>)(object)taskCompletionSource).TrySetResult((ILinkResult)playFabLinkAborted);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CUnlinkAccount_003Eb__0(UnlinkSteamAccountResult result)
		{
			Debug.Log("Successfully unlinked Steam account");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CUnlinkAccount_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to unlink with Steam");
			string message = error.GenerateErrorReport();
			Debug.LogWarning(message);
			TaskCompletionSource<bool> taskCompletionSource = t;
			PlayFabApiException ex = PlayFabApiException.FromPlayFabError(error);
			if (ex != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).TrySetException((object)ex))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
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
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CLinkAccount_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ILinkResult> _003C_003Et__builder;

		public PlayFabSteam _003C_003E4__this;

		public bool force;

		private TaskAwaiter<ILinkResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0178: Expected I4, but got I8
			//IL_0188: Expected O, but got Ref
			//IL_019d: Expected O, but got I
			//IL_00cb: Expected O, but got I
			//IL_0103: Expected O, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected O, but got Unknown
			//IL_01cd: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILinkResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass3_0();
				CS_0024_003C_003E8__locals2._003C_003E4__this = _003C_003E4__this;
				CS_0024_003C_003E8__locals2.force = force;
				Func<Task<ILinkResult>> action = delegate
				{
					AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder3 = default(AsyncTaskMethodBuilder<object>);
					_003C_003Ec__DisplayClass3_0._003C_003CLinkAccount_003Eb__0_003Ed stateMachine = default(_003C_003Ec__DisplayClass3_0._003C_003CLinkAccount_003Eb__0_003Ed);
					asyncTaskMethodBuilder3.Start(ref stateMachine);
					return (Task<ILinkResult>)(object)asyncTaskMethodBuilder3.Task;
				};
				Task<ILinkResult> task2 = _003C_003E4__this.RetryAction(action);
				Task<ILinkResult> task3 = ((PlayFabSteam)(object)task2).RetryAction(action, 3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v30 (System.Threading.Tasks.Task`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ILinkResult>)+38]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
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
	private struct _003CLogin_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

		public PlayFabSteam _003C_003E4__this;

		private TaskAwaiter<ILoginResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0149: Expected I4, but got I8
			//IL_009c: Expected O, but got I
			//IL_00d4: Expected O, but got I4
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_0159: Expected O, but got Ref
			//IL_016e: Expected O, but got I
			//IL_019e: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Func<Task<ILoginResult>> action = _003C_003E4__this.TryLoginInternal;
				Task<ILoginResult> task2 = _003C_003E4__this.RetryAction(action);
				Task<ILoginResult> task3 = ((PlayFabSteam)(object)task2).RetryAction(action, 3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v24 (System.Threading.Tasks.Task`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ILoginResult>)+38]");
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
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
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
	private struct _003CLoginOrRegister_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<ILoginResult> _003C_003Et__builder;

		public PlayFabSteam _003C_003E4__this;

		private TaskAwaiter<ILoginResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0149: Expected I4, but got I8
			//IL_009c: Expected O, but got I
			//IL_00d4: Expected O, but got I4
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_0159: Expected O, but got Ref
			//IL_016e: Expected O, but got I
			//IL_019e: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILoginResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Func<Task<ILoginResult>> action = _003C_003E4__this.TryLoginOrRegisterInternal;
				Task<ILoginResult> task2 = _003C_003E4__this.RetryAction(action);
				Task<ILoginResult> task3 = ((PlayFabSteam)(object)task2).RetryAction(action, 3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v24 (System.Threading.Tasks.Task`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication.ILoginResult>)+38]");
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
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
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
	private struct _003CRetryAction_003Ed__9<T> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

		public Func<Task<T>> action;

		public int maxAttempts;

		private int _003Cattempt_003E5__2;

		private bool _003CtryAgain_003E5__3;

		private Exception _003Cerror_003E5__4;

		private TaskAwaiter<T> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_036c: Expected O, but got Ref
			//IL_0099: Expected O, but got I
			//IL_0071: Expected O, but got I
			//IL_0084: Expected O, but got I8
			//IL_0032: Expected O, but got I
			//IL_0045: Expected O, but got I8
			//IL_0334: Expected O, but got I
			//IL_01ae: Expected O, but got I8
			//IL_02ad: Expected O, but got Ref
			//IL_027c: Expected O, but got I
			//IL_0136: Expected O, but got I4
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Expected O, but got Unknown
			//IL_01fd: Expected O, but got I4
			//IL_03e2: Expected O, but got I8
			//IL_01d9: Expected O, but got Ref
			//IL_01ee: Expected O, but got I
			//IL_022c: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			_003CRetryAction_003Ed__9<T> obj2;
			if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) != null)
			{
				if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == (void*)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+48]");
					Task task = (Task)0;
					_ = 0;
					obj2 = (_003CRetryAction_003Ed__9<T>)4294967295L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+48]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					int num = task.m_stateFlags & 0x11000000;
					if (num != 16777216)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+48]");
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification((Task)0);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					System.ParamsArray paramsArray2 = default(System.ParamsArray);
					string message = string.FormatHelper((IFormatProvider)null, "Attempt {0}: Failed to authenticate with Steam, retrying...", (System.ParamsArray)(&paramsArray2));
					Debug.Log(message);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+2C]");
					_ = (nint)0 + (nint)1;
					obj = 4294967295L;
				}
				else
				{
					_ = 1;
					_ = 1;
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+30]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+2C]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+28]");
					if (num2 <= 0)
					{
						goto IL_03e7;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+38]");
				object obj3 = 0;
				throw obj3;
			}
			goto IL_03e7;
			IL_03e7:
			Task task2;
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+40]");
				task2 = (Task)0;
				_ = 0;
				obj2 = (_003CRetryAction_003Ed__9<T>)4294967295L;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+20]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.Platforms.PlayFabSteam+<RetryAction>d__9`1<T>)+20]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v250 @ rbx_v9+18] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task3 = default(Task);
				int num3 = task3.m_stateFlags & 0x1600000;
				bool flag = num3 == 0;
				bool flag2 = num3 < 0;
				bool flag3 = !flag2;
				object obj5 = !flag3;
				object obj6 = obj5 | flag;
				task2 = task3;
				if (obj6 != null)
				{
					obj2 = (_003CRetryAction_003Ed__9<T>)0;
					nint num4 = 0;
					object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182E31670");
					return;
				}
			}
			int num5 = task2.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			obj2 = (_003CRetryAction_003Ed__9<T>)4294967294L;
			_ = 0;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder)->SetResult(0);
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

	public PlatformType GetPlatformName()
	{
		return PlatformType.STEAM;
	}

	public Task<ILoginResult> LoginOrRegister()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CLoginOrRegister_003Ed__1 stateMachine = default(_003CLoginOrRegister_003Ed__1);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ILoginResult>)(object)asyncTaskMethodBuilder.Task;
	}

	public Task<ILoginResult> Login()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CLogin_003Ed__2 stateMachine = default(_003CLogin_003Ed__2);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ILoginResult>)(object)asyncTaskMethodBuilder.Task;
	}

	public Task<ILinkResult> LinkAccount(bool force = false)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CLinkAccount_003Ed__3 stateMachine = default(_003CLinkAccount_003Ed__3);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<ILinkResult>)(object)asyncTaskMethodBuilder.Task;
	}

	private Task<ILoginResult> TryLoginOrRegisterInternal()
	{
		return LoginOrRegisterInternal(createAccount: true);
	}

	private Task<ILoginResult> TryLoginInternal()
	{
		return LoginOrRegisterInternal(createAccount: false);
	}

	private unsafe Task<ILoginResult> LoginOrRegisterInternal(bool createAccount)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass6_0();
		if (CS_0024_003C_003E8__locals16 != null)
		{
			CS_0024_003C_003E8__locals16.createAccount = createAccount;
			TaskCompletionSource<ILoginResult> t = (TaskCompletionSource<ILoginResult>)(object)new TaskCompletionSource<object>();
			CS_0024_003C_003E8__locals16.t = t;
			Action<PlatformAuthToken> onSuccess = delegate(PlatformAuthToken authToken)
			{
				//IL_0013: Expected O, but got I4
				LoginWithSteamRequest loginWithSteamRequest = new LoginWithSteamRequest();
				loginWithSteamRequest.CreateAccount = (bool?)(object)1;
				loginWithSteamRequest.SteamTicket = authToken._003CToken_003Ek__BackingField;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				loginWithSteamRequest.CustomTags = customTags;
				Action<global::PlayFab.ClientModels.LoginResult> action2 = CS_0024_003C_003E8__locals16._003C_003E9__3;
				if (CS_0024_003C_003E8__locals16._003C_003E9__3 == null)
				{
					action2 = (CS_0024_003C_003E8__locals16._003C_003E9__3 = delegate(global::PlayFab.ClientModels.LoginResult result)
					{
						Debug.Log("Successfully logged in with Steam");
						PlayFabLoginSuccess playFabLoginSuccess = new PlayFabLoginSuccess();
						playFabLoginSuccess.AuthenticationContext = result.AuthenticationContext;
						TaskCompletionSource<ILoginResult> t3 = CS_0024_003C_003E8__locals16.t;
						if (!((Task<object>)(object)t3._task).TrySetResult((object)playFabLoginSuccess))
						{
							bool flag = ((Task<ILoginResult>)(object)t3).TrySetResult((ILoginResult)playFabLoginSuccess);
						}
					});
				}
				Action<PlayFabError> action3 = CS_0024_003C_003E8__locals16._003C_003E9__4;
				if (CS_0024_003C_003E8__locals16._003C_003E9__4 == null)
				{
					action3 = (CS_0024_003C_003E8__locals16._003C_003E9__4 = delegate(PlayFabError error)
					{
						Debug.LogWarning("Encountered error whilst trying to log in with Steam");
						string message = error.GenerateErrorReport();
						Debug.LogWarning(message);
						TaskCompletionSource<ILoginResult> t3 = CS_0024_003C_003E8__locals16.t;
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
					});
				}
				if (loginWithSteamRequest.AuthenticationContext == null)
				{
				}
				string titleId = loginWithSteamRequest.TitleId;
				if (loginWithSteamRequest.TitleId == null)
				{
					titleId = PlayFabSettings.staticSettings.TitleId;
				}
				loginWithSteamRequest.TitleId = titleId;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
			};
			Action<string> action = delegate(string errorMessage)
			{
				TaskCompletionSource<ILoginResult> t3 = CS_0024_003C_003E8__locals16.t;
				Exception ex = new Exception(errorMessage);
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
			action._002Ector((object)CS_0024_003C_003E8__locals16, (IntPtr)(nint)__ldftn(_003C_003Ec__DisplayClass6_0._003CLoginOrRegisterInternal_003Eb__1));
			Action<TokenAbortReason> onAbort = delegate(TokenAbortReason abortReason)
			{
				TaskCompletionSource<ILoginResult> t3 = CS_0024_003C_003E8__locals16.t;
				PlayFabLoginAborted playFabLoginAborted = new PlayFabLoginAborted();
				playFabLoginAborted.TokenAbortReason = abortReason;
				if (!((Task<object>)(object)t3._task).TrySetResult((object)playFabLoginAborted))
				{
					bool flag = ((Task<ILoginResult>)(object)t3).TrySetResult((ILoginResult)playFabLoginAborted);
				}
			};
			if (SystemPlatform.sInstance != null)
			{
				SystemPlatform.sInstance.GetAuthToken(onSuccess, action, onAbort);
				TaskCompletionSource<ILoginResult> t2 = CS_0024_003C_003E8__locals16.t;
				if (CS_0024_003C_003E8__locals16.t != null)
				{
					return t2._task;
				}
			}
		}
		return (Task<ILoginResult>)(object)new NullReferenceException();
	}

	private unsafe Task<ILinkResult> LinkAccountInternal(bool force = false)
	{
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass7_0();
		if (CS_0024_003C_003E8__locals16 != null)
		{
			CS_0024_003C_003E8__locals16.force = force;
			TaskCompletionSource<ILinkResult> t = (TaskCompletionSource<ILinkResult>)(object)new TaskCompletionSource<object>();
			CS_0024_003C_003E8__locals16.t = t;
			Action<PlatformAuthToken> onSuccess = delegate(PlatformAuthToken authToken)
			{
				//IL_0013: Expected O, but got I4
				//IL_0021: Expected O, but got I4
				LinkSteamAccountRequest linkSteamAccountRequest = new LinkSteamAccountRequest();
				linkSteamAccountRequest.ForceLink = (bool?)(object)1;
				linkSteamAccountRequest.TicketIsServiceSpecific = (bool?)(object)1;
				linkSteamAccountRequest.SteamTicket = authToken._003CToken_003Ek__BackingField;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				linkSteamAccountRequest.CustomTags = customTags;
				Action<LinkSteamAccountResult> action2 = CS_0024_003C_003E8__locals16._003C_003E9__3;
				if (CS_0024_003C_003E8__locals16._003C_003E9__3 == null)
				{
					action2 = (CS_0024_003C_003E8__locals16._003C_003E9__3 = delegate
					{
						Debug.Log("Successfully linked Steam account");
						TaskCompletionSource<ILinkResult> t3 = CS_0024_003C_003E8__locals16.t;
						PlayFabLinkSuccess result2 = new PlayFabLinkSuccess();
						if (!((Task<object>)(object)t3._task).TrySetResult((object)result2))
						{
							bool flag = ((Task<ILinkResult>)(object)t3).TrySetResult((ILinkResult)result2);
						}
					});
				}
				Action<PlayFabError> action3 = CS_0024_003C_003E8__locals16._003C_003E9__4;
				if (CS_0024_003C_003E8__locals16._003C_003E9__4 == null)
				{
					action3 = (CS_0024_003C_003E8__locals16._003C_003E9__4 = delegate(PlayFabError error)
					{
						Debug.LogWarning("Encountered error whilst trying to link with Steam");
						string message = error.GenerateErrorReport();
						Debug.LogWarning(message);
						TaskCompletionSource<ILinkResult> t3 = CS_0024_003C_003E8__locals16.t;
						PlayFabApiException ex2 = PlayFabApiException.FromPlayFabError(error);
						if (ex2 != null)
						{
							if (!((Task)t3._task).TrySetException((object)ex2) && !t3._task.IsCompleted)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
							}
						}
						else
						{
							System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
						}
					});
				}
				PlayFabAuthenticationContext playFabAuthenticationContext = linkSteamAccountRequest.AuthenticationContext;
				if (linkSteamAccountRequest.AuthenticationContext == null)
				{
					playFabAuthenticationContext = PlayFabSettings.staticPlayer;
				}
				string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
				if (playFabAuthenticationContext.ClientSessionTicket != null && clientSessionTicket._stringLength > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
					return;
				}
				PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				throw ex;
			};
			Action<string> action = delegate(string errorMessage)
			{
				TaskCompletionSource<ILinkResult> t3 = CS_0024_003C_003E8__locals16.t;
				Exception ex = new Exception(errorMessage);
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
			action._002Ector((object)CS_0024_003C_003E8__locals16, (IntPtr)(nint)__ldftn(_003C_003Ec__DisplayClass7_0._003CLinkAccountInternal_003Eb__1));
			Action<TokenAbortReason> onAbort = delegate(TokenAbortReason abortReason)
			{
				TaskCompletionSource<ILinkResult> t3 = CS_0024_003C_003E8__locals16.t;
				PlayFabLinkAborted playFabLinkAborted = new PlayFabLinkAborted();
				playFabLinkAborted.TokenAbortReason = abortReason;
				if (!((Task<object>)(object)t3._task).TrySetResult((object)playFabLinkAborted))
				{
					bool flag = ((Task<ILinkResult>)(object)t3).TrySetResult((ILinkResult)playFabLinkAborted);
				}
			};
			if (SystemPlatform.sInstance != null)
			{
				SystemPlatform.sInstance.GetAuthToken(onSuccess, action, onAbort);
				TaskCompletionSource<ILinkResult> t2 = CS_0024_003C_003E8__locals16.t;
				if (CS_0024_003C_003E8__locals16.t != null)
				{
					return t2._task;
				}
			}
		}
		return (Task<ILinkResult>)(object)new NullReferenceException();
	}

	public Task<bool> UnlinkAccount()
	{
		//IL_0103: Expected O, but got I
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass8_0();
		TaskCompletionSource<bool> t = new TaskCompletionSource<bool>();
		CS_0024_003C_003E8__locals4.t = t;
		UnlinkSteamAccountRequest unlinkSteamAccountRequest = new UnlinkSteamAccountRequest();
		Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
		unlinkSteamAccountRequest.CustomTags = customTags;
		Action<UnlinkSteamAccountResult> action = delegate
		{
			Debug.Log("Successfully unlinked Steam account");
			TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals4.t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		};
		Action<PlayFabError> action2 = delegate(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to unlink with Steam");
			string message = error.GenerateErrorReport();
			Debug.LogWarning(message);
			TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals4.t;
			PlayFabApiException ex2 = PlayFabApiException.FromPlayFabError(error);
			if (ex2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).TrySetException((object)ex2))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
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
		PlayFabAuthenticationContext playFabAuthenticationContext = unlinkSteamAccountRequest.AuthenticationContext;
		if (unlinkSteamAccountRequest.AuthenticationContext == null)
		{
			playFabAuthenticationContext = PlayFabSettings.staticPlayer;
		}
		string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
		if (playFabAuthenticationContext.ClientSessionTicket != null && clientSessionTicket._stringLength > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
			TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals4.t;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v32 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			return (Task<bool>)0;
		}
		PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
		ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
		throw ex;
	}

	private Task<T> RetryAction<T>(Func<Task<T>> action, int maxAttempts = 3)
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CRetryAction_003Ed__9<object> stateMachine = default(_003CRetryAction_003Ed__9<object>);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<T>)(object)asyncTaskMethodBuilder.Task;
	}
}
