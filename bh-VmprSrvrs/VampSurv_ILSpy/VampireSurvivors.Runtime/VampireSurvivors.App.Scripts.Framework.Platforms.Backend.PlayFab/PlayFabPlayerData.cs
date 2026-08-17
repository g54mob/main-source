using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cpp2ILInjected;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;

public class PlayFabPlayerData : IPlayerDataStorage
{
	public enum AllowedPlayerDataKeys
	{
		PASSED_DOB_GATE,
		MERGE_CONFLICT_DATA,
		SAVE_DATA_SLOT_1,
		LINK_ACCOUNT_VERIFICATION_TOKEN,
		LINKED_CUSTOM_IDS
	}

	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public string keyString;

		public TaskCompletionSource<bool> t;

		internal void _003CSetPlayerData_003Eb__0(UpdateUserDataResult result)
		{
			string message = "Successfully updated player data for key: " + keyString;
			Debug.Log(message);
			TaskCompletionSource<bool> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
			}
		}

		internal void _003CSetPlayerData_003Eb__1(PlayFabError error)
		{
			//IL_007c: Expected O, but got I
			//IL_009f: Expected O, but got I
			string message = "Encountered error whilst trying to set player data for key: " + keyString;
			Debug.LogWarning(message);
			string message2 = error.GenerateErrorReport();
			Debug.LogWarning(message2);
			TaskCompletionSource<bool> taskCompletionSource = t;
			PlayFabApiException ex = PlayFabApiException.FromPlayFabError(error);
			if (ex != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).TrySetException((object)ex))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
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

	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public string keyString;

		public TaskCompletionSource<string> t;

		internal unsafe void _003CGetPlayerData_003Eb__0(GetUserDataResult result)
		{
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected Ref, but got Unknown
			//IL_0147: Expected I8, but got I4
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Expected Ref, but got Unknown
			object result2;
			Task<string> task;
			if (result.Data != null)
			{
				int num = result.Data.FindEntry(keyString);
				if (num >= 0)
				{
					UserDataRecord userDataRecord = result.Data.get_Item(keyString);
					string value = userDataRecord.Value;
					if (userDataRecord.Value != null)
					{
						object obj = "";
						if ((object)userDataRecord.Value != "")
						{
							if ("" != null)
							{
								int stringLength = value._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rdx_v19+10]");
								if ((nint)stringLength == 0)
								{
									ref byte first = ref *(byte*)(userDataRecord.Value + 20);
									ulong length = (ulong)(value._stringLength + value._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length))
									{
										goto IL_01cc;
									}
								}
							}
							TaskCompletionSource<string> taskCompletionSource = t;
							if (!((Task<object>)(object)taskCompletionSource._task).TrySetResult((object)userDataRecord.Value))
							{
								result2 = userDataRecord.Value;
								task = (Task<string>)(object)taskCompletionSource;
								goto IL_02e8;
							}
							return;
						}
					}
					goto IL_01cc;
				}
			}
			string message = "No player data for key: " + keyString + ".";
			Debug.Log(message);
			TaskCompletionSource<string> taskCompletionSource2 = t;
			PlayerDataNotExistsException ex = (PlayerDataNotExistsException)new Exception(message);
			PlayerDataNotExistsException ex2 = ex;
			goto IL_0273;
			IL_01cc:
			string message2 = "Player data for key: " + keyString + " is null or empty.";
			Debug.Log(message2);
			taskCompletionSource2 = t;
			PlayerDataNotExistsException ex3 = new PlayerDataNotExistsException(message2);
			ex2 = ex3;
			goto IL_0273;
			IL_02e8:
			bool flag = task.TrySetResult((string)result2);
			return;
			IL_0273:
			if (ex2 != null)
			{
				if (!((Task)taskCompletionSource2._task).TrySetException((object)ex2) && !taskCompletionSource2._task.IsCompleted)
				{
					result2 = null;
					task = (Task<string>)(object)taskCompletionSource2;
					goto IL_02e8;
				}
				return;
			}
			System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
		}

		internal void _003CGetPlayerData_003Eb__1(PlayFabError error)
		{
			string message = "Encountered error whilst trying to get player data for key: " + keyString;
			Debug.LogWarning(message);
			string message2 = error.GenerateErrorReport();
			Debug.LogWarning(message2);
			TaskCompletionSource<string> taskCompletionSource = t;
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

	public unsafe Task<bool> SetPlayerData(AllowedPlayerDataKeys key, string value)
	{
		//IL_0266: Expected O, but got Ref
		//IL_01c9: Expected O, but got I
		//IL_022c: Expected O, but got I
		//IL_01ec: Expected O, but got I
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass1_0();
		PlayFabCoreAuthentication.AssertPlayFabSettings();
		IntPtr intPtr = default(IntPtr);
		string keyString = ((Enum)(&intPtr)).ToString();
		CS_0024_003C_003E8__locals9.keyString = keyString;
		TaskCompletionSource<bool> t = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804E2230");
		CS_0024_003C_003E8__locals9.t = t;
		if (PlayFabClientAPI.IsClientLoggedIn())
		{
			UpdateUserDataRequest updateUserDataRequest = new UpdateUserDataRequest();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string value2 = default(string);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)CS_0024_003C_003E8__locals9.keyString, (object)value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			updateUserDataRequest.Data = dictionary;
			Dictionary<string, string> customTags = PlayFabUtils.GetCustomTags();
			updateUserDataRequest.CustomTags = customTags;
			Action<UpdateUserDataResult> action = delegate
			{
				string message = "Successfully updated player data for key: " + CS_0024_003C_003E8__locals9.keyString;
				Debug.Log(message);
				TaskCompletionSource<bool> t4 = CS_0024_003C_003E8__locals9.t;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18050A3D0");
				object obj = default(object);
				if (obj == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
				}
			};
			Action<PlayFabError> action2 = delegate(PlayFabError error)
			{
				//IL_007c: Expected O, but got I
				//IL_009f: Expected O, but got I
				string message = "Encountered error whilst trying to set player data for key: " + CS_0024_003C_003E8__locals9.keyString;
				Debug.LogWarning(message);
				string message2 = error.GenerateErrorReport();
				Debug.LogWarning(message2);
				TaskCompletionSource<bool> t4 = CS_0024_003C_003E8__locals9.t;
				PlayFabApiException ex3 = PlayFabApiException.FromPlayFabError(error);
				if (ex3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
					if (!((Task)0).TrySetException((object)ex3))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v4 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
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
			PlayFabAuthenticationContext playFabAuthenticationContext = updateUserDataRequest.AuthenticationContext;
			if (updateUserDataRequest.AuthenticationContext == null)
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
			TaskCompletionSource<bool> t2 = CS_0024_003C_003E8__locals9.t;
			NotAuthenticatedException ex2 = new NotAuthenticatedException();
			if (ex2 == null)
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
				Task<bool> result = default(Task<bool>);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v9 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
			if (!((Task)0).TrySetException((object)ex2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v9 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
				if (!((Task)0).IsCompleted)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D9F60");
				}
			}
		}
		TaskCompletionSource<bool> t3 = CS_0024_003C_003E8__locals9.t;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v23 (System.Threading.Tasks.TaskCompletionSource`1<System.Boolean>)+10]");
		return (Task<bool>)0;
	}

	public unsafe Task<string> GetPlayerData(AllowedPlayerDataKeys key)
	{
		//IL_002e: Expected O, but got Ref
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass2_0();
		PlayFabCoreAuthentication.AssertPlayFabSettings();
		TaskCompletionSource<string> taskCompletionSource = (TaskCompletionSource<string>)(object)new TaskCompletionSource<object>();
		((TaskCompletionSource<object>)(object)taskCompletionSource)._002Ector();
		CS_0024_003C_003E8__locals14.t = taskCompletionSource;
		object obj = default(object);
		string keyString = ((Enum)(&obj)).ToString();
		CS_0024_003C_003E8__locals14.keyString = keyString;
		if (PlayFabClientAPI.IsClientLoggedIn())
		{
			GetUserDataRequest getUserDataRequest = new GetUserDataRequest();
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)CS_0024_003C_003E8__locals14.keyString);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			getUserDataRequest.Keys = list;
			Action<GetUserDataResult> action = delegate(GetUserDataResult getUserDataResult)
			{
				//IL_012b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0130: Expected Ref, but got Unknown
				//IL_0147: Expected I8, but got I4
				//IL_0151: Unknown result type (might be due to invalid IL or missing references)
				//IL_0156: Expected Ref, but got Unknown
				object result2;
				Task<string> task;
				if (getUserDataResult.Data != null)
				{
					int num = getUserDataResult.Data.FindEntry(CS_0024_003C_003E8__locals14.keyString);
					if (num >= 0)
					{
						UserDataRecord userDataRecord = getUserDataResult.Data.get_Item(CS_0024_003C_003E8__locals14.keyString);
						string value = userDataRecord.Value;
						if (userDataRecord.Value != null)
						{
							object obj2 = "";
							if ((object)userDataRecord.Value != "")
							{
								if ("" != null)
								{
									int stringLength = value._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rdx_v19+10]");
									if ((nint)stringLength == 0)
									{
										ref byte first = ref *(byte*)(userDataRecord.Value + 20);
										ulong length = (ulong)(value._stringLength + value._stringLength);
										if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length))
										{
											goto IL_01cc;
										}
									}
								}
								TaskCompletionSource<string> t3 = CS_0024_003C_003E8__locals14.t;
								if (((Task<object>)(object)t3._task).TrySetResult((object)userDataRecord.Value))
								{
									return;
								}
								result2 = userDataRecord.Value;
								task = (Task<string>)(object)t3;
								goto IL_02e8;
							}
						}
						goto IL_01cc;
					}
				}
				string message = "No player data for key: " + CS_0024_003C_003E8__locals14.keyString + ".";
				Debug.Log(message);
				TaskCompletionSource<string> t4 = CS_0024_003C_003E8__locals14.t;
				PlayerDataNotExistsException ex3 = (PlayerDataNotExistsException)new Exception(message);
				PlayerDataNotExistsException ex4 = ex3;
				goto IL_0273;
				IL_01cc:
				string message2 = "Player data for key: " + CS_0024_003C_003E8__locals14.keyString + " is null or empty.";
				Debug.Log(message2);
				t4 = CS_0024_003C_003E8__locals14.t;
				PlayerDataNotExistsException ex5 = new PlayerDataNotExistsException(message2);
				ex4 = ex5;
				goto IL_0273;
				IL_02e8:
				bool flag = task.TrySetResult((string)result2);
				return;
				IL_0273:
				if (ex4 == null)
				{
					System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
					return;
				}
				if (((Task)t4._task).TrySetException((object)ex4) || t4._task.IsCompleted)
				{
					return;
				}
				result2 = null;
				task = (Task<string>)(object)t4;
				goto IL_02e8;
			};
			Action<PlayFabError> action2 = delegate(PlayFabError error)
			{
				string message = "Encountered error whilst trying to get player data for key: " + CS_0024_003C_003E8__locals14.keyString;
				Debug.LogWarning(message);
				string message2 = error.GenerateErrorReport();
				Debug.LogWarning(message2);
				TaskCompletionSource<string> t3 = CS_0024_003C_003E8__locals14.t;
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
			PlayFabAuthenticationContext playFabAuthenticationContext = getUserDataRequest.AuthenticationContext;
			if (getUserDataRequest.AuthenticationContext == null)
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
			TaskCompletionSource<string> t = CS_0024_003C_003E8__locals14.t;
			NotAuthenticatedException ex2 = new NotAuthenticatedException();
			if (ex2 == null)
			{
				System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.exception);
				Task<string> result = default(Task<string>);
				return result;
			}
			if (!((Task)t._task).TrySetException((object)ex2) && !t._task.IsCompleted)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA670");
			}
		}
		TaskCompletionSource<string> t2 = CS_0024_003C_003E8__locals14.t;
		return t2._task;
	}
}
