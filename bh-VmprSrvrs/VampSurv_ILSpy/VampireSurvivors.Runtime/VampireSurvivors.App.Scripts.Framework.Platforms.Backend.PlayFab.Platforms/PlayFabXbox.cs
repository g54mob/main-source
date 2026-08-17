using System;
using System.Collections.Generic;
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

public class PlayFabXbox : IPlatform, IPlatformAuthentication
{
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public bool createAccount;

		public TaskCompletionSource<ILoginResult> t;

		public Action<global::PlayFab.ClientModels.LoginResult> _003C_003E9__3;

		public Action<PlayFabError> _003C_003E9__4;

		internal void _003CLoginOrRegisterInternal_003Eb__0(PlatformAuthToken authToken)
		{
			//IL_0013: Expected O, but got I4
			LoginWithXboxRequest loginWithXboxRequest = new LoginWithXboxRequest();
			loginWithXboxRequest.CreateAccount = (bool?)(object)1;
			loginWithXboxRequest.XboxToken = authToken._003CToken_003Ek__BackingField;
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			loginWithXboxRequest.CustomTags = customTags;
			Action<global::PlayFab.ClientModels.LoginResult> action = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				action = (_003C_003E9__3 = delegate(global::PlayFab.ClientModels.LoginResult result)
				{
					Debug.Log("PlayFab: Successfully logged in with Xbox");
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
					Debug.LogWarning("Encountered error whilst trying to log in with Xbox");
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
			if (loginWithXboxRequest.AuthenticationContext == null)
			{
			}
			string titleId = loginWithXboxRequest.TitleId;
			if (loginWithXboxRequest.TitleId == null)
			{
				titleId = PlayFabSettings.staticSettings.TitleId;
			}
			loginWithXboxRequest.TitleId = titleId;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
		}

		internal void _003CLoginOrRegisterInternal_003Eb__3(global::PlayFab.ClientModels.LoginResult result)
		{
			Debug.Log("PlayFab: Successfully logged in with Xbox");
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
			Debug.LogWarning("Encountered error whilst trying to log in with Xbox");
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

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public bool force;

		public TaskCompletionSource<ILinkResult> t;

		public Action<LinkXboxAccountResult> _003C_003E9__3;

		public Action<PlayFabError> _003C_003E9__4;

		internal void _003CLinkAccount_003Eb__0(PlatformAuthToken authToken)
		{
			//IL_0013: Expected O, but got I4
			LinkXboxAccountRequest linkXboxAccountRequest = new LinkXboxAccountRequest();
			linkXboxAccountRequest.ForceLink = (bool?)(object)1;
			linkXboxAccountRequest.XboxToken = authToken._003CToken_003Ek__BackingField;
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			linkXboxAccountRequest.CustomTags = customTags;
			Action<LinkXboxAccountResult> action = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				action = (_003C_003E9__3 = delegate
				{
					Debug.Log("PlayFab: Successfully linked with Xbox");
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
					Debug.LogWarning("Encountered error whilst trying to link with Xbox");
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
			PlayFabAuthenticationContext playFabAuthenticationContext = linkXboxAccountRequest.AuthenticationContext;
			if (linkXboxAccountRequest.AuthenticationContext == null)
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

		internal void _003CLinkAccount_003Eb__3(LinkXboxAccountResult result)
		{
			Debug.Log("PlayFab: Successfully linked with Xbox");
			TaskCompletionSource<ILinkResult> taskCompletionSource = t;
			PlayFabLinkSuccess result2 = new PlayFabLinkSuccess();
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)result2))
			{
				bool flag = ((Task<ILinkResult>)(object)taskCompletionSource).TrySetResult((ILinkResult)result2);
			}
		}

		internal void _003CLinkAccount_003Eb__4(PlayFabError error)
		{
			Debug.LogWarning("Encountered error whilst trying to link with Xbox");
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

		internal void _003CLinkAccount_003Eb__1(string errorMessage)
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

		internal void _003CLinkAccount_003Eb__2(TokenAbortReason abortReason)
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

	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CUnlinkAccount_003Eb__0(UnlinkXboxAccountResult result)
		{
			Debug.Log("Successfully unlinked Xbox account");
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
			Debug.LogWarning("Encountered error whilst trying to unlink with Xbox");
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

	public PlatformType GetPlatformName()
	{
		return PlatformType.XBOX;
	}

	public Task<ILoginResult> Login()
	{
		return LoginOrRegisterInternal(createAccount: false);
	}

	public Task<ILoginResult> LoginOrRegister()
	{
		return LoginOrRegisterInternal(createAccount: true);
	}

	private unsafe Task<ILoginResult> LoginOrRegisterInternal(bool createAccount)
	{
		//IL_003d: Expected O, but got Ref
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass3_0();
		if (CS_0024_003C_003E8__locals16 != null)
		{
			CS_0024_003C_003E8__locals16.createAccount = createAccount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Attempting to log in with Xbox. Create account: {0}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			TaskCompletionSource<ILoginResult> t = (TaskCompletionSource<ILoginResult>)(object)new TaskCompletionSource<object>();
			CS_0024_003C_003E8__locals16.t = t;
			Action<PlatformAuthToken> onSuccess = delegate(PlatformAuthToken authToken)
			{
				//IL_0013: Expected O, but got I4
				LoginWithXboxRequest loginWithXboxRequest = new LoginWithXboxRequest();
				loginWithXboxRequest.CreateAccount = (bool?)(object)1;
				loginWithXboxRequest.XboxToken = authToken._003CToken_003Ek__BackingField;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				loginWithXboxRequest.CustomTags = customTags;
				Action<global::PlayFab.ClientModels.LoginResult> action2 = CS_0024_003C_003E8__locals16._003C_003E9__3;
				if (CS_0024_003C_003E8__locals16._003C_003E9__3 == null)
				{
					action2 = (CS_0024_003C_003E8__locals16._003C_003E9__3 = delegate(global::PlayFab.ClientModels.LoginResult result)
					{
						Debug.Log("PlayFab: Successfully logged in with Xbox");
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
						Debug.LogWarning("Encountered error whilst trying to log in with Xbox");
						string message2 = error.GenerateErrorReport();
						Debug.LogWarning(message2);
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
				if (loginWithXboxRequest.AuthenticationContext == null)
				{
				}
				string titleId = loginWithXboxRequest.TitleId;
				if (loginWithXboxRequest.TitleId == null)
				{
					titleId = PlayFabSettings.staticSettings.TitleId;
				}
				loginWithXboxRequest.TitleId = titleId;
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
			action._002Ector((object)CS_0024_003C_003E8__locals16, (IntPtr)(nint)__ldftn(_003C_003Ec__DisplayClass3_0._003CLoginOrRegisterInternal_003Eb__1));
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

	public unsafe Task<ILinkResult> LinkAccount(bool force = false)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass4_0();
		if (CS_0024_003C_003E8__locals16 != null)
		{
			CS_0024_003C_003E8__locals16.force = force;
			TaskCompletionSource<ILinkResult> t = (TaskCompletionSource<ILinkResult>)(object)new TaskCompletionSource<object>();
			CS_0024_003C_003E8__locals16.t = t;
			Action<PlatformAuthToken> onSuccess = delegate(PlatformAuthToken authToken)
			{
				//IL_0013: Expected O, but got I4
				LinkXboxAccountRequest linkXboxAccountRequest = new LinkXboxAccountRequest();
				linkXboxAccountRequest.ForceLink = (bool?)(object)1;
				linkXboxAccountRequest.XboxToken = authToken._003CToken_003Ek__BackingField;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				linkXboxAccountRequest.CustomTags = customTags;
				Action<LinkXboxAccountResult> action2 = CS_0024_003C_003E8__locals16._003C_003E9__3;
				if (CS_0024_003C_003E8__locals16._003C_003E9__3 == null)
				{
					action2 = (CS_0024_003C_003E8__locals16._003C_003E9__3 = delegate
					{
						Debug.Log("PlayFab: Successfully linked with Xbox");
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
						Debug.LogWarning("Encountered error whilst trying to link with Xbox");
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
				PlayFabAuthenticationContext playFabAuthenticationContext = linkXboxAccountRequest.AuthenticationContext;
				if (linkXboxAccountRequest.AuthenticationContext == null)
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
			action._002Ector((object)CS_0024_003C_003E8__locals16, (IntPtr)(nint)__ldftn(_003C_003Ec__DisplayClass4_0._003CLinkAccount_003Eb__1));
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
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass5_0();
		TaskCompletionSource<bool> t = new TaskCompletionSource<bool>();
		CS_0024_003C_003E8__locals4.t = t;
		UnlinkXboxAccountRequest unlinkXboxAccountRequest = new UnlinkXboxAccountRequest();
		Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
		unlinkXboxAccountRequest.CustomTags = customTags;
		Action<UnlinkXboxAccountResult> action = delegate
		{
			Debug.Log("Successfully unlinked Xbox account");
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
			Debug.LogWarning("Encountered error whilst trying to unlink with Xbox");
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
		PlayFabAuthenticationContext playFabAuthenticationContext = unlinkXboxAccountRequest.AuthenticationContext;
		if (unlinkXboxAccountRequest.AuthenticationContext == null)
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
}
