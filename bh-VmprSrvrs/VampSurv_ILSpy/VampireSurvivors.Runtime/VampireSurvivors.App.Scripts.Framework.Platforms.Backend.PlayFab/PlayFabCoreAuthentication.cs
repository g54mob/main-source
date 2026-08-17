using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cpp2ILInjected;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;

public class PlayFabCoreAuthentication : ICoreAuthentication
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<ContactEmailInfoModel> _003C_003E9__11_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CGetPlayerProfile_003Eb__11_2(ContactEmailInfoModel c)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2F8B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (c != null)
			{
				string name = c.Name;
				object obj = "Primary";
				if ((object)c.Name != "Primary")
				{
					if (c.Name != null && "Primary" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte second = ref *(byte*)("Primary" + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(c.Name + 20), ref second, length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CRemoveContactEmail_003Eb__0(RemoveContactEmailResult result)
		{
			Debug.Log("Successfully removed contact email address.");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CRemoveContactEmail_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to remove contact email address.");
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

	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public TaskCompletionSource<IPlayerProfile> t;

		internal unsafe void _003CGetPlayerProfile_003Eb__0(GetPlayerProfileResult result)
		{
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected I4, but got Unknown
			PlayerProfileModel playerProfile = result.PlayerProfile;
			Predicate<ContactEmailInfoModel> match = _003C_003Ec._003C_003E9__11_2;
			if (_003C_003Ec._003C_003E9__11_2 == null)
			{
				match = (_003C_003Ec._003C_003E9__11_2 = delegate(ContactEmailInfoModel c)
				{
					//IL_0144: Expected I4, but got O
					//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
					//IL_00e6: Expected Ref, but got Unknown
					//IL_00fd: Expected I8, but got I4
					//IL_010b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0110: Expected Ref, but got Unknown
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2F8B]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (c == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					string name = c.Name;
					object obj3 = "Primary";
					if ((object)c.Name != "Primary")
					{
						if (c.Name != null && "Primary" != null)
						{
							int stringLength = name._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("Primary" + 20);
								ulong length = (ulong)(name._stringLength + name._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(c.Name + 20), ref second, length);
							}
						}
						return false;
					}
					return true;
				});
			}
			ContactEmailInfoModel contactEmailInfoModel = playerProfile.ContactEmailAddresses.Find(match);
			PlayFabPlayerProfile playFabPlayerProfile = null;
			playFabPlayerProfile._contactEmailAddress = "";
			playFabPlayerProfile._isContactEmailAddressVerified = false;
			bool flag = contactEmailInfoModel == null;
			PlayFabPlayerProfile result2 = playFabPlayerProfile;
			if (!flag)
			{
				object obj = (object?)contactEmailInfoModel.VerificationStatus >> 32;
				PlayFabPlayerProfile playFabPlayerProfile2 = null;
				playFabPlayerProfile2._contactEmailAddress = contactEmailInfoModel.EmailAddress;
				object obj2 = obj - 2;
				bool flag2 = obj2 == null;
				bool isContactEmailAddressVerified = (byte)((flag2 & (_003F?)contactEmailInfoModel.VerificationStatus) ? 1 : 0) != 0;
				playFabPlayerProfile2._isContactEmailAddressVerified = isContactEmailAddressVerified;
				result2 = playFabPlayerProfile2;
			}
			TaskCompletionSource<IPlayerProfile> taskCompletionSource = t;
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)result2))
			{
				bool flag3 = ((Task<IPlayerProfile>)(object)taskCompletionSource).TrySetResult((IPlayerProfile)result2);
			}
		}

		internal void _003CGetPlayerProfile_003Eb__1(PlayFabError error)
		{
			Debug.LogWarning("Encountered error whilst trying to get player profile.");
			string message = error.GenerateErrorReport();
			Debug.LogWarning(message);
			TaskCompletionSource<IPlayerProfile> taskCompletionSource = t;
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

	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CLinkCustomID_003Eb__0(LinkCustomIDResult result)
		{
			Debug.Log("Successfully linked with custom id.");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CLinkCustomID_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to link with custom id");
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

	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CUnlinkCustomID_003Eb__0(UnlinkCustomIDResult result)
		{
			Debug.Log("Successfully unlinked with custom id.");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CUnlinkCustomID_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to unlink with custom id");
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

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public TaskCompletionSource<ILoginResult> t;

		internal void _003CLoginWithCustomID_003Eb__0(LoginResult result)
		{
			Debug.Log("Successfully logged in with custom id.");
			PlayFabLoginSuccess playFabLoginSuccess = new PlayFabLoginSuccess();
			playFabLoginSuccess.AuthenticationContext = result.AuthenticationContext;
			TaskCompletionSource<ILoginResult> taskCompletionSource = t;
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)playFabLoginSuccess))
			{
				bool flag = ((Task<ILoginResult>)(object)taskCompletionSource).TrySetResult((ILoginResult)playFabLoginSuccess);
			}
		}

		internal void _003CLoginWithCustomID_003Eb__1(PlayFabError error)
		{
			Debug.LogWarning("Encountered error whilst trying to login with custom id");
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
	}

	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public TaskCompletionSource<AccountDetails> t;

		internal void _003CGetAccountDetails_003Eb__0(GetAccountInfoResult result)
		{
			AccountDetails result2 = AccountDetails.FromApiResult(result);
			TaskCompletionSource<AccountDetails> taskCompletionSource = t;
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)result2))
			{
				bool flag = ((Task<AccountDetails>)(object)taskCompletionSource).TrySetResult(result2);
			}
		}

		internal void _003CGetAccountDetails_003Eb__1(PlayFabError error)
		{
			Debug.LogWarning("Encountered error whilst trying to fetch account details");
			string message = error.GenerateErrorReport();
			Debug.LogWarning(message);
			TaskCompletionSource<AccountDetails> taskCompletionSource = t;
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

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CRequestPasswordReset_003Eb__0(SendAccountRecoveryEmailResult result)
		{
			Debug.Log("Successfully sent account recovery email");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CRequestPasswordReset_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying send account recovery email");
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

	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CAddBasicCredentials_003Eb__0(AddUsernamePasswordResult result)
		{
			Debug.Log("Successfully added email/password.");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CAddBasicCredentials_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to add email/password");
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

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public TaskCompletionSource<ILoginResult> t;

		internal void _003CLogin_003Eb__0(LoginResult result)
		{
			Debug.Log("Successfully logged in with email.");
			PlayFabLoginSuccess playFabLoginSuccess = new PlayFabLoginSuccess();
			playFabLoginSuccess.AuthenticationContext = result.AuthenticationContext;
			TaskCompletionSource<ILoginResult> taskCompletionSource = t;
			if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)playFabLoginSuccess))
			{
				bool flag = ((Task<ILoginResult>)(object)taskCompletionSource).TrySetResult((ILoginResult)playFabLoginSuccess);
			}
		}

		internal void _003CLogin_003Eb__1(PlayFabError error)
		{
			Debug.LogWarning("Encountered error whilst trying to log in with email");
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
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CRegister_003Eb__0(RegisterPlayFabUserResult result)
		{
			Debug.Log("Successfully registered.");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CRegister_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to register with email");
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

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CAddOrUpdateContactEmail_003Eb__0(AddOrUpdateContactEmailResult result)
		{
			Debug.Log("Successfully set contact email address.");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CAddOrUpdateContactEmail_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to set contact email address.");
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

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public TaskCompletionSource<bool> t;

		internal void _003CResendVerificationEmail_003Eb__0(WriteEventResponse result)
		{
			Debug.Log("Successfully triggered resend_verification_email event.");
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CResendVerificationEmail_003Eb__1(PlayFabError error)
		{
			//IL_007d: Expected O, but got I
			//IL_00a0: Expected O, but got I
			Debug.LogWarning("Encountered error whilst trying to trigger resend_verification_email event.");
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

	public void Logout()
	{
		PlayFabSettings.staticPlayer.ForgetAllCredentials();
	}

	public bool IsLoggedIn()
	{
		return PlayFabClientAPI.IsClientLoggedIn();
	}

	public string GetAccountId()
	{
		PlayFabAuthenticationContext staticPlayer = PlayFabSettings.staticPlayer;
		if (PlayFabSettings.staticPlayer != null)
		{
			return staticPlayer.PlayFabId;
		}
		return (string)(object)new NullReferenceException();
	}

	public Task<AccountDetails> GetAccountDetails()
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass3_0();
		AssertPlayFabSettings();
		TaskCompletionSource<AccountDetails> taskCompletionSource = (TaskCompletionSource<AccountDetails>)(object)new TaskCompletionSource<object>();
		((TaskCompletionSource<object>)(object)taskCompletionSource)._002Ector();
		CS_0024_003C_003E8__locals5.t = taskCompletionSource;
		PlayFabAuthenticationContext playFabAuthenticationContext;
		if (PlayFabClientAPI.IsClientLoggedIn())
		{
			GetAccountInfoRequest getAccountInfoRequest = new GetAccountInfoRequest();
			Action<GetAccountInfoResult> action = delegate(GetAccountInfoResult result3)
			{
				AccountDetails result2 = AccountDetails.FromApiResult(result3);
				TaskCompletionSource<AccountDetails> t3 = CS_0024_003C_003E8__locals5.t;
				if (!((Task<object>)(object)t3._task).TrySetResult((object)result2))
				{
					bool flag = ((Task<AccountDetails>)(object)t3).TrySetResult(result2);
				}
			};
			Action<PlayFabError> action2 = delegate(PlayFabError error)
			{
				Debug.LogWarning("Encountered error whilst trying to fetch account details");
				string message = error.GenerateErrorReport();
				Debug.LogWarning(message);
				TaskCompletionSource<AccountDetails> t3 = CS_0024_003C_003E8__locals5.t;
				PlayFabApiException ex3 = PlayFabApiException.FromPlayFabError(error);
				if (ex3 != null)
				{
					if (!((Task)t3._task).TrySetException((object)ex3) && !t3._task.IsCompleted)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
				}
			};
			if (getAccountInfoRequest != null)
			{
				playFabAuthenticationContext = getAccountInfoRequest.AuthenticationContext;
				if (getAccountInfoRequest.AuthenticationContext != null)
				{
					goto IL_00ca;
				}
			}
			playFabAuthenticationContext = PlayFabSettings.staticPlayer;
			goto IL_00ca;
		}
		Debug.Log("Can't get account details unless logged in.");
		TaskCompletionSource<AccountDetails> t = CS_0024_003C_003E8__locals5.t;
		NotAuthenticatedException ex = new NotAuthenticatedException();
		if (ex != null)
		{
			if (!((Task)t._task).TrySetException((object)ex) && !t._task.IsCompleted)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
			}
			goto IL_01d2;
		}
		System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
		Task<AccountDetails> result = default(Task<AccountDetails>);
		return result;
		IL_00ca:
		string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
		if (playFabAuthenticationContext.ClientSessionTicket != null && clientSessionTicket._stringLength > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
			goto IL_01d2;
		}
		PlayFabException ex2 = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
		ex2._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
		throw ex2;
		IL_01d2:
		TaskCompletionSource<AccountDetails> t2 = CS_0024_003C_003E8__locals5.t;
		return t2._task;
	}

	public Task RequestPasswordReset(string emailAddress)
	{
		//IL_0138: Expected O, but got I
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass4_0();
		AssertPlayFabSettings();
		TaskCompletionSource<bool> t = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804E2230");
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.t = t;
			SendAccountRecoveryEmailRequest sendAccountRecoveryEmailRequest = new SendAccountRecoveryEmailRequest();
			if (sendAccountRecoveryEmailRequest != null)
			{
				sendAccountRecoveryEmailRequest.Email = emailAddress;
				string titleId = PlayFabSettings.TitleId;
				sendAccountRecoveryEmailRequest.TitleId = titleId;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				sendAccountRecoveryEmailRequest.CustomTags = customTags;
				Action<SendAccountRecoveryEmailResult> action = delegate
				{
					Debug.Log("Successfully sent account recovery email");
					TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals6.t;
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
					Debug.LogWarning("Encountered error whilst trying send account recovery email");
					string message = error.GenerateErrorReport();
					Debug.LogWarning(message);
					TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals6.t;
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
				};
				if (sendAccountRecoveryEmailRequest.AuthenticationContext == null)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
				TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals6.t;
				if (CS_0024_003C_003E8__locals6.t != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v29 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
					return (Task)0;
				}
			}
		}
		return (Task)(object)new NullReferenceException();
	}

	public Task<bool> AddBasicCredentials(string email, string password)
	{
		//IL_019d: Expected O, but got I
		//IL_0200: Expected O, but got I
		//IL_01c0: Expected O, but got I
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass5_0();
		AssertPlayFabSettings();
		TaskCompletionSource<bool> t = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804E2230");
		CS_0024_003C_003E8__locals5.t = t;
		if (PlayFabClientAPI.IsClientLoggedIn())
		{
			string username = GenerateUsername();
			AddUsernamePasswordRequest addUsernamePasswordRequest = new AddUsernamePasswordRequest();
			addUsernamePasswordRequest.Email = email;
			addUsernamePasswordRequest.Username = username;
			addUsernamePasswordRequest.Password = password;
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			addUsernamePasswordRequest.CustomTags = customTags;
			Action<AddUsernamePasswordResult> action = delegate
			{
				Debug.Log("Successfully added email/password.");
				TaskCompletionSource<bool> t4 = CS_0024_003C_003E8__locals5.t;
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
				Debug.LogWarning("Encountered error whilst trying to add email/password");
				string message = error.GenerateErrorReport();
				Debug.LogWarning(message);
				TaskCompletionSource<bool> t4 = CS_0024_003C_003E8__locals5.t;
				PlayFabApiException ex3 = PlayFabApiException.FromPlayFabError(error);
				if (ex3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
					if (!((Task)0).TrySetException((object)ex3))
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
			PlayFabAuthenticationContext playFabAuthenticationContext = addUsernamePasswordRequest.AuthenticationContext;
			if (addUsernamePasswordRequest.AuthenticationContext == null)
			{
				playFabAuthenticationContext = PlayFabSettings.staticPlayer;
			}
			string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
			if (playFabAuthenticationContext.ClientSessionTicket == null || clientSessionTicket._stringLength <= 0)
			{
				PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
		}
		else
		{
			Debug.Log("Can't add email/password unless logged in.");
			TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals5.t;
			NotAuthenticatedException ex2 = new NotAuthenticatedException();
			if (ex2 == null)
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
				Task<bool> result = default(Task<bool>);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rbx_v8 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			if (!((Task)0).TrySetException((object)ex2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rbx_v8 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).IsCompleted)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
				}
			}
		}
		TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals5.t;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v22 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
		return (Task<bool>)0;
	}

	public Task<ILoginResult> Login(string email, string password)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass6_0();
		AssertPlayFabSettings();
		TaskCompletionSource<ILoginResult> taskCompletionSource = (TaskCompletionSource<ILoginResult>)(object)new TaskCompletionSource<object>();
		((TaskCompletionSource<object>)(object)taskCompletionSource)._002Ector();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.t = taskCompletionSource;
			LoginWithEmailAddressRequest loginWithEmailAddressRequest = new LoginWithEmailAddressRequest();
			if (loginWithEmailAddressRequest != null)
			{
				loginWithEmailAddressRequest.Email = email;
				loginWithEmailAddressRequest.Password = password;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				loginWithEmailAddressRequest.CustomTags = customTags;
				Action<LoginResult> action = delegate(LoginResult result)
				{
					Debug.Log("Successfully logged in with email.");
					PlayFabLoginSuccess playFabLoginSuccess = new PlayFabLoginSuccess();
					playFabLoginSuccess.AuthenticationContext = result.AuthenticationContext;
					TaskCompletionSource<ILoginResult> t2 = CS_0024_003C_003E8__locals6.t;
					if (!((Task<object>)(object)t2._task).TrySetResult((object)playFabLoginSuccess))
					{
						bool flag = ((Task<ILoginResult>)(object)t2).TrySetResult((ILoginResult)playFabLoginSuccess);
					}
				};
				Action<PlayFabError> action2 = delegate(PlayFabError error)
				{
					Debug.LogWarning("Encountered error whilst trying to log in with email");
					string message = error.GenerateErrorReport();
					Debug.LogWarning(message);
					TaskCompletionSource<ILoginResult> t2 = CS_0024_003C_003E8__locals6.t;
					PlayFabApiException ex = PlayFabApiException.FromPlayFabError(error);
					if (ex != null)
					{
						if (!((Task)t2._task).TrySetException((object)ex) && !t2._task.IsCompleted)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
					}
				};
				if (loginWithEmailAddressRequest.AuthenticationContext == null)
				{
				}
				string titleId = loginWithEmailAddressRequest.TitleId;
				if (loginWithEmailAddressRequest.TitleId == null)
				{
					if (PlayFabSettings.staticSettings == null)
					{
						goto IL_014a;
					}
					titleId = PlayFabSettings.staticSettings.TitleId;
				}
				loginWithEmailAddressRequest.TitleId = titleId;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
				TaskCompletionSource<ILoginResult> t = CS_0024_003C_003E8__locals6.t;
				if (CS_0024_003C_003E8__locals6.t != null)
				{
					return t._task;
				}
			}
		}
		goto IL_014a;
		IL_014a:
		return (Task<ILoginResult>)(object)new NullReferenceException();
	}

	public Task<bool> Register(string email, string password)
	{
		//IL_0084: Expected O, but got I4
		//IL_015c: Expected O, but got I
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass7_0();
		AssertPlayFabSettings();
		TaskCompletionSource<bool> t = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804E2230");
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.t = t;
			RegisterPlayFabUserRequest registerPlayFabUserRequest = new RegisterPlayFabUserRequest();
			if (registerPlayFabUserRequest != null)
			{
				registerPlayFabUserRequest.Email = email;
				registerPlayFabUserRequest.Password = password;
				registerPlayFabUserRequest.RequireBothUsernameAndEmail = (bool?)(object)1;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				registerPlayFabUserRequest.CustomTags = customTags;
				Action<RegisterPlayFabUserResult> action = delegate
				{
					Debug.Log("Successfully registered.");
					TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals6.t;
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
					Debug.LogWarning("Encountered error whilst trying to register with email");
					string message = error.GenerateErrorReport();
					Debug.LogWarning(message);
					TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals6.t;
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
				};
				if (registerPlayFabUserRequest.AuthenticationContext == null)
				{
				}
				string titleId = registerPlayFabUserRequest.TitleId;
				if (registerPlayFabUserRequest.TitleId == null)
				{
					if (PlayFabSettings.staticSettings == null)
					{
						goto IL_015c;
					}
					titleId = PlayFabSettings.staticSettings.TitleId;
				}
				registerPlayFabUserRequest.TitleId = titleId;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
				TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals6.t;
				if (CS_0024_003C_003E8__locals6.t != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v32 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
					return (Task<bool>)0;
				}
			}
		}
		goto IL_015c;
		IL_015c:
		return (Task<bool>)(object)new NullReferenceException();
	}

	public Task<bool> AddOrUpdateContactEmail(string email)
	{
		//IL_01f8: Expected O, but got I
		//IL_025b: Expected O, but got I
		//IL_021b: Expected O, but got I
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass8_0();
		AssertPlayFabSettings();
		TaskCompletionSource<bool> t = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804E2230");
		CS_0024_003C_003E8__locals6.t = t;
		NotAuthenticatedException ex3;
		if (PlayFabClientAPI.IsClientLoggedIn())
		{
			if (email != null)
			{
				AddOrUpdateContactEmailRequest addOrUpdateContactEmailRequest = new AddOrUpdateContactEmailRequest();
				addOrUpdateContactEmailRequest.EmailAddress = email;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				addOrUpdateContactEmailRequest.CustomTags = customTags;
				Action<AddOrUpdateContactEmailResult> action = delegate
				{
					Debug.Log("Successfully set contact email address.");
					TaskCompletionSource<bool> t4 = CS_0024_003C_003E8__locals6.t;
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
					Debug.LogWarning("Encountered error whilst trying to set contact email address.");
					string message = error.GenerateErrorReport();
					Debug.LogWarning(message);
					TaskCompletionSource<bool> t4 = CS_0024_003C_003E8__locals6.t;
					PlayFabApiException ex5 = PlayFabApiException.FromPlayFabError(error);
					if (ex5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
						if (!((Task)0).TrySetException((object)ex5))
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
				PlayFabAuthenticationContext playFabAuthenticationContext = addOrUpdateContactEmailRequest.AuthenticationContext;
				if (addOrUpdateContactEmailRequest.AuthenticationContext == null)
				{
					playFabAuthenticationContext = PlayFabSettings.staticPlayer;
				}
				string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
				if (playFabAuthenticationContext.ClientSessionTicket != null && clientSessionTicket._stringLength > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
					goto IL_023c;
				}
				PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				throw ex;
			}
			Debug.Log("Can't update contact email address to null.");
			TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals6.t;
			Exception ex2 = new Exception();
			ex2.Init();
			ex3 = (NotAuthenticatedException)ex2;
		}
		else
		{
			Debug.Log("Can't update contact email address unless logged in.");
			TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals6.t;
			NotAuthenticatedException ex4 = new NotAuthenticatedException();
			ex3 = ex4;
		}
		if (ex3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rbx_v9 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			if (!((Task)0).TrySetException((object)ex3))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rbx_v9 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).IsCompleted)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
				}
			}
			goto IL_023c;
		}
		System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
		Task<bool> result = default(Task<bool>);
		return result;
		IL_023c:
		TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals6.t;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v22 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
		return (Task<bool>)0;
	}

	public Task<bool> ResendVerificationEmail()
	{
		//IL_0193: Expected O, but got I
		//IL_01f6: Expected O, but got I
		//IL_01b6: Expected O, but got I
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass9_0();
		AssertPlayFabSettings();
		TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
		taskCompletionSource._002Ector();
		CS_0024_003C_003E8__locals5.t = taskCompletionSource;
		if (PlayFabClientAPI.IsClientLoggedIn())
		{
			WriteClientPlayerEventRequest writeClientPlayerEventRequest = new WriteClientPlayerEventRequest();
			writeClientPlayerEventRequest.EventName = "resend_verification_email";
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			writeClientPlayerEventRequest.CustomTags = customTags;
			Action<WriteEventResponse> action = delegate
			{
				Debug.Log("Successfully triggered resend_verification_email event.");
				TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals5.t;
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
				Debug.LogWarning("Encountered error whilst trying to trigger resend_verification_email event.");
				string message = error.GenerateErrorReport();
				Debug.LogWarning(message);
				TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals5.t;
				PlayFabApiException ex3 = PlayFabApiException.FromPlayFabError(error);
				if (ex3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
					if (!((Task)0).TrySetException((object)ex3))
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
			PlayFabAuthenticationContext playFabAuthenticationContext = writeClientPlayerEventRequest.AuthenticationContext;
			if (writeClientPlayerEventRequest.AuthenticationContext == null)
			{
				playFabAuthenticationContext = PlayFabSettings.staticPlayer;
			}
			string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
			if (playFabAuthenticationContext.ClientSessionTicket == null || clientSessionTicket._stringLength <= 0)
			{
				PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
		}
		else
		{
			Debug.Log("Can't resend verification email unless logged in.");
			TaskCompletionSource<bool> t = CS_0024_003C_003E8__locals5.t;
			NotAuthenticatedException ex2 = new NotAuthenticatedException();
			if (ex2 == null)
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
				Task<bool> result = default(Task<bool>);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v9 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			if (!((Task)0).TrySetException((object)ex2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v9 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).IsCompleted)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
				}
			}
		}
		TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals5.t;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v22 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
		return (Task<bool>)0;
	}

	public Task<bool> RemoveContactEmail()
	{
		//IL_0180: Expected O, but got I
		//IL_01e3: Expected O, but got I
		//IL_01a3: Expected O, but got I
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass10_0();
		AssertPlayFabSettings();
		TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
		taskCompletionSource._002Ector();
		CS_0024_003C_003E8__locals5.t = taskCompletionSource;
		if (PlayFabClientAPI.IsClientLoggedIn())
		{
			RemoveContactEmailRequest removeContactEmailRequest = new RemoveContactEmailRequest();
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			removeContactEmailRequest.CustomTags = customTags;
			Action<RemoveContactEmailResult> action = delegate
			{
				Debug.Log("Successfully removed contact email address.");
				TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals5.t;
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
				Debug.LogWarning("Encountered error whilst trying to remove contact email address.");
				string message = error.GenerateErrorReport();
				Debug.LogWarning(message);
				TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals5.t;
				PlayFabApiException ex3 = PlayFabApiException.FromPlayFabError(error);
				if (ex3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
					if (!((Task)0).TrySetException((object)ex3))
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
			PlayFabAuthenticationContext playFabAuthenticationContext = removeContactEmailRequest.AuthenticationContext;
			if (removeContactEmailRequest.AuthenticationContext == null)
			{
				playFabAuthenticationContext = PlayFabSettings.staticPlayer;
			}
			string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
			if (playFabAuthenticationContext.ClientSessionTicket == null || clientSessionTicket._stringLength <= 0)
			{
				PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
		}
		else
		{
			Debug.Log("Can't remove contact email address unless logged in.");
			TaskCompletionSource<bool> t = CS_0024_003C_003E8__locals5.t;
			NotAuthenticatedException ex2 = new NotAuthenticatedException();
			if (ex2 == null)
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
				Task<bool> result = default(Task<bool>);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v9 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			if (!((Task)0).TrySetException((object)ex2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rbx_v9 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).IsCompleted)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
				}
			}
		}
		TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals5.t;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v22 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
		return (Task<bool>)0;
	}

	public unsafe Task<IPlayerProfile> GetPlayerProfile()
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass11_0();
		AssertPlayFabSettings();
		TaskCompletionSource<IPlayerProfile> taskCompletionSource = (TaskCompletionSource<IPlayerProfile>)(object)new TaskCompletionSource<object>();
		((TaskCompletionSource<object>)(object)taskCompletionSource)._002Ector();
		CS_0024_003C_003E8__locals5.t = taskCompletionSource;
		if (PlayFabClientAPI.IsClientLoggedIn())
		{
			GetPlayerProfileRequest getPlayerProfileRequest = new GetPlayerProfileRequest();
			PlayerProfileViewConstraints playerProfileViewConstraints = new PlayerProfileViewConstraints();
			playerProfileViewConstraints.ShowContactEmailAddresses = true;
			getPlayerProfileRequest.ProfileConstraints = playerProfileViewConstraints;
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			getPlayerProfileRequest.CustomTags = customTags;
			Action<GetPlayerProfileResult> action = delegate(GetPlayerProfileResult getPlayerProfileResult)
			{
				//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c4: Expected O, but got Unknown
				//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e5: Expected I4, but got Unknown
				PlayerProfileModel playerProfile = getPlayerProfileResult.PlayerProfile;
				Predicate<ContactEmailInfoModel> match = _003C_003Ec._003C_003E9__11_2;
				if (_003C_003Ec._003C_003E9__11_2 == null)
				{
					match = (_003C_003Ec._003C_003E9__11_2 = delegate(ContactEmailInfoModel c)
					{
						//IL_0144: Expected I4, but got O
						//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
						//IL_00e6: Expected Ref, but got Unknown
						//IL_00fd: Expected I8, but got I4
						//IL_010b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0110: Expected Ref, but got Unknown
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2F8B]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (c == null)
						{
							NullReferenceException ex3 = new NullReferenceException();
							return (byte)(int)ex3 != 0;
						}
						string name = c.Name;
						object obj3 = "Primary";
						if ((object)c.Name != "Primary")
						{
							if (c.Name != null && "Primary" != null)
							{
								int stringLength = name._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
								if ((nint)stringLength == 0)
								{
									ref byte second = ref *(byte*)("Primary" + 20);
									ulong length = (ulong)(name._stringLength + name._stringLength);
									return System.SpanHelpers.SequenceEqual(ref *(byte*)(c.Name + 20), ref second, length);
								}
							}
							return false;
						}
						return true;
					});
				}
				ContactEmailInfoModel contactEmailInfoModel = playerProfile.ContactEmailAddresses.Find(match);
				PlayFabPlayerProfile playFabPlayerProfile = null;
				playFabPlayerProfile._contactEmailAddress = "";
				playFabPlayerProfile._isContactEmailAddressVerified = false;
				bool flag = contactEmailInfoModel == null;
				PlayFabPlayerProfile result2 = playFabPlayerProfile;
				if (!flag)
				{
					object obj = (object?)contactEmailInfoModel.VerificationStatus >> 32;
					PlayFabPlayerProfile playFabPlayerProfile2 = null;
					playFabPlayerProfile2._contactEmailAddress = contactEmailInfoModel.EmailAddress;
					object obj2 = obj - 2;
					bool flag2 = obj2 == null;
					bool isContactEmailAddressVerified = (byte)((flag2 & (_003F?)contactEmailInfoModel.VerificationStatus) ? 1 : 0) != 0;
					playFabPlayerProfile2._isContactEmailAddressVerified = isContactEmailAddressVerified;
					result2 = playFabPlayerProfile2;
				}
				TaskCompletionSource<IPlayerProfile> t3 = CS_0024_003C_003E8__locals5.t;
				if (!((Task<object>)(object)t3._task).TrySetResult((object)result2))
				{
					bool flag3 = ((Task<IPlayerProfile>)(object)t3).TrySetResult((IPlayerProfile)result2);
				}
			};
			Action<PlayFabError> action2 = delegate(PlayFabError error)
			{
				Debug.LogWarning("Encountered error whilst trying to get player profile.");
				string message = error.GenerateErrorReport();
				Debug.LogWarning(message);
				TaskCompletionSource<IPlayerProfile> t3 = CS_0024_003C_003E8__locals5.t;
				PlayFabApiException ex3 = PlayFabApiException.FromPlayFabError(error);
				if (ex3 != null)
				{
					if (!((Task)t3._task).TrySetException((object)ex3) && !t3._task.IsCompleted)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
				}
			};
			PlayFabAuthenticationContext playFabAuthenticationContext = getPlayerProfileRequest.AuthenticationContext;
			if (getPlayerProfileRequest.AuthenticationContext == null)
			{
				playFabAuthenticationContext = PlayFabSettings.staticPlayer;
			}
			string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
			if (playFabAuthenticationContext.ClientSessionTicket == null || clientSessionTicket._stringLength <= 0)
			{
				PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
		}
		else
		{
			Debug.Log("Can't get player profile unless logged in.");
			TaskCompletionSource<IPlayerProfile> t = CS_0024_003C_003E8__locals5.t;
			NotAuthenticatedException ex2 = new NotAuthenticatedException();
			if (ex2 == null)
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
				Task<IPlayerProfile> result = default(Task<IPlayerProfile>);
				return result;
			}
			if (!((Task)t._task).TrySetException((object)ex2) && !t._task.IsCompleted)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
			}
		}
		TaskCompletionSource<IPlayerProfile> t2 = CS_0024_003C_003E8__locals5.t;
		return t2._task;
	}

	public Task<bool> LinkCustomID(string id)
	{
		//IL_006f: Expected O, but got I4
		//IL_0132: Expected O, but got I
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass12_0();
		AssertPlayFabSettings();
		TaskCompletionSource<bool> t = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804E2230");
		CS_0024_003C_003E8__locals4.t = t;
		LinkCustomIDRequest linkCustomIDRequest = new LinkCustomIDRequest();
		linkCustomIDRequest.CustomId = id;
		Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
		linkCustomIDRequest.CustomTags = customTags;
		linkCustomIDRequest.ForceLink = (bool?)(object)257;
		Action<LinkCustomIDResult> action = delegate
		{
			Debug.Log("Successfully linked with custom id.");
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
			Debug.LogWarning("Encountered error whilst trying to link with custom id");
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
		PlayFabAuthenticationContext playFabAuthenticationContext = linkCustomIDRequest.AuthenticationContext;
		if (linkCustomIDRequest.AuthenticationContext == null)
		{
			playFabAuthenticationContext = PlayFabSettings.staticPlayer;
		}
		string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
		if (playFabAuthenticationContext.ClientSessionTicket != null && clientSessionTicket._stringLength > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
			TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals4.t;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v35 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			return (Task<bool>)0;
		}
		PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
		ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
		throw ex;
	}

	public Task<bool> UnlinkCustomID(string id)
	{
		//IL_0124: Expected O, but got I
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass13_0();
		AssertPlayFabSettings();
		TaskCompletionSource<bool> t = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804E2230");
		CS_0024_003C_003E8__locals4.t = t;
		UnlinkCustomIDRequest unlinkCustomIDRequest = new UnlinkCustomIDRequest();
		unlinkCustomIDRequest.CustomId = id;
		Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
		unlinkCustomIDRequest.CustomTags = customTags;
		Action<UnlinkCustomIDResult> action = delegate
		{
			Debug.Log("Successfully unlinked with custom id.");
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
			Debug.LogWarning("Encountered error whilst trying to unlink with custom id");
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
		PlayFabAuthenticationContext playFabAuthenticationContext = unlinkCustomIDRequest.AuthenticationContext;
		if (unlinkCustomIDRequest.AuthenticationContext == null)
		{
			playFabAuthenticationContext = PlayFabSettings.staticPlayer;
		}
		string clientSessionTicket = playFabAuthenticationContext.ClientSessionTicket;
		if (playFabAuthenticationContext.ClientSessionTicket != null && clientSessionTicket._stringLength > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830E4050");
			TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals4.t;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v34 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			return (Task<bool>)0;
		}
		PlayFabException ex = new PlayFabException(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
		ex._002Ector(PlayFabExceptionCode.NotLoggedIn, "Must be logged in to call this method");
		throw ex;
	}

	public Task<ILoginResult> LoginWithCustomID(string id, bool forceCreate = false)
	{
		//IL_0071: Expected O, but got I4
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass14_0();
		AssertPlayFabSettings();
		TaskCompletionSource<ILoginResult> taskCompletionSource = (TaskCompletionSource<ILoginResult>)(object)new TaskCompletionSource<object>();
		((TaskCompletionSource<object>)(object)taskCompletionSource)._002Ector();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.t = taskCompletionSource;
			LoginWithCustomIDRequest loginWithCustomIDRequest = new LoginWithCustomIDRequest();
			if (loginWithCustomIDRequest != null)
			{
				loginWithCustomIDRequest.CreateAccount = (bool?)(object)1;
				loginWithCustomIDRequest.CustomId = id;
				Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
				loginWithCustomIDRequest.CustomTags = customTags;
				Action<LoginResult> resultCallback = delegate(LoginResult result)
				{
					Debug.Log("Successfully logged in with custom id.");
					PlayFabLoginSuccess playFabLoginSuccess = new PlayFabLoginSuccess();
					playFabLoginSuccess.AuthenticationContext = result.AuthenticationContext;
					TaskCompletionSource<ILoginResult> t2 = CS_0024_003C_003E8__locals6.t;
					if (!((Task<object>)(object)t2._task).TrySetResult((object)playFabLoginSuccess))
					{
						bool flag = ((Task<ILoginResult>)(object)t2).TrySetResult((ILoginResult)playFabLoginSuccess);
					}
				};
				Action<PlayFabError> errorCallback = delegate(PlayFabError error)
				{
					Debug.LogWarning("Encountered error whilst trying to login with custom id");
					string message = error.GenerateErrorReport();
					Debug.LogWarning(message);
					TaskCompletionSource<ILoginResult> t2 = CS_0024_003C_003E8__locals6.t;
					PlayFabApiException ex = PlayFabApiException.FromPlayFabError(error);
					if (ex != null)
					{
						if (!((Task)t2._task).TrySetException((object)ex) && !t2._task.IsCompleted)
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
				PlayFabClientAPI.LoginWithCustomID(loginWithCustomIDRequest, resultCallback, errorCallback, null, extraHeaders);
				TaskCompletionSource<ILoginResult> t = CS_0024_003C_003E8__locals6.t;
				if (CS_0024_003C_003E8__locals6.t != null)
				{
					return t._task;
				}
			}
		}
		return (Task<ILoginResult>)(object)new NullReferenceException();
	}

	public static void AssertPlayFabSettings()
	{
		//IL_000d: Expected I, but got O
		PlayFabApiSettings staticSettings = PlayFabSettings.staticSettings;
		nint num = (nint)staticSettings;
		string titleId = staticSettings.TitleId;
		if (titleId != null && titleId._stringLength > 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
		Debug.LogError("PlayFab not initialised! TitleId is null or empty.");
		Exception ex = new Exception("PlayFab not initialised! TitleId is null or empty.");
		throw ex;
	}

	private unsafe string GenerateUsername()
	{
		//IL_0040: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0226: Expected I4, but got I8
		object obj = default(object);
		global::Interop.GetRandomBytes((byte*)(&obj), 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Guid guid = default(Guid);
		string text = guid.ToString("D", null);
		Regex regex = new Regex("[^a-zA-Z0-9]");
		if (text != null)
		{
			object obj2 = regex.roptions & RegexOptions.RightToLeft;
			bool flag = obj2 == null;
			bool flag2 = (nint)obj2 < 0;
			bool flag3 = !flag2;
			object obj3 = !flag3;
			object obj4 = obj3 | flag;
			if (obj4 == null)
			{
			}
			int startat = default(int);
			string text2 = regex.Replace(text, "", -1, startat);
			if (text2._stringLength >= 0)
			{
				bool flag4 = text2._stringLength < 20;
				bool flag5 = text2._stringLength == 20;
				if (!flag4)
				{
					string result = text2;
					if (!flag5)
					{
						string text3 = text2.InternalSubString(0, 20);
						result = text3;
					}
					return result;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
				ex._002Ector("length", "Index and length must refer to a location within the string.");
				throw ex;
			}
			ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
			ex2._002Ector("startIndex", "startIndex cannot be larger than length of string.");
			throw ex2;
		}
		ArgumentNullException ex3 = new ArgumentNullException("input");
		ex3._002Ector("input");
		throw ex3;
	}
}
