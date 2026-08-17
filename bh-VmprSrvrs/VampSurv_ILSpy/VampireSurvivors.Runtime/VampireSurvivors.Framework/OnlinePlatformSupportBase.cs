using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework;

public class OnlinePlatformSupportBase
{
	public virtual bool WaitForServerResponseOnEnteringOnline => true;

	public virtual void Initialise()
	{
		Debug.Log("<OnlinePlatformSupportBase.Initialise>");
	}

	public virtual void OnLobbyOpen(string lobbyID)
	{
		string message = "<OnlinePlatformSupportBase.OnLobbyOpen> - " + lobbyID;
		Debug.Log(message);
	}

	public virtual void OnLobbyClosed(string lobbyID)
	{
		string message = "<OnlinePlatformSupportBase.OnLobbyClosed> - " + lobbyID;
		Debug.Log(message);
	}

	public virtual void CheckInternetConnectionState(Action<bool> callback)
	{
		//IL_0024: Expected O, but got I
		//IL_0034: Expected O, but got I
		//IL_0044: Expected O, but got I
		while (true)
		{
			Debug.Log("<OnlinePlatformSupportBase.CheckConnectionState>");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v5 (should have been resolved before IL gen)");
		}
	}

	public virtual void OnConnectionError()
	{
		Debug.Log("<OnlinePlatformSupportBase.InternetConnectionLost>");
	}

	public virtual void CheckAgeOk(Action<bool> callback)
	{
		//IL_003c: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_005c: Expected O, but got I
		Debug.Log("<OnlinePlatformSupportBase.CheckAgeOk>");
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v4 (should have been resolved before IL gen)");
		}
	}

	public virtual void CheckOnlineEntitlement(Action<bool> callback)
	{
		//IL_003c: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_005c: Expected O, but got I
		Debug.Log("<OnlinePlatformSupportBase.CheckOnlineEntitlement>");
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ rdx (System.Action`1<System.Boolean>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v4 (should have been resolved before IL gen)");
		}
	}

	public virtual void OnCreatedOnlineSession(string lobbyID, Action<bool> callback)
	{
		//IL_003c: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_005c: Expected O, but got I
		Debug.Log("<OnlinePlatformSupportBase.OnCreatedOnlineSession>");
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v4 (should have been resolved before IL gen)");
		}
	}

	public virtual void OnJoinedOnlineSession(string lobbyID, Action<bool> callback)
	{
		//IL_003c: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_005c: Expected O, but got I
		Debug.Log("<OnlinePlatformSupportBase.OnJoinedOnlineSession>");
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v4 (should have been resolved before IL gen)");
		}
	}

	public virtual void OnRemotePlayerJoinedRoom(string lobbyID, Action<bool> callback)
	{
		//IL_003c: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_005c: Expected O, but got I
		Debug.Log("<OnlinePlatformSupportBase.OnRemotePlayerJoinedRoom>");
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v4 (should have been resolved before IL gen)");
		}
	}

	public virtual void OnPlayerLeftOnlineSession(string lobbyID, Action<bool> callback)
	{
		//IL_003c: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_005c: Expected O, but got I
		Debug.Log("<OnlinePlatformSupportBase.OnLeftOnlineSession>");
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v4 (should have been resolved before IL gen)");
		}
	}

	public virtual void OnEndOnlineSession(string lobbyID, Action<bool> callback)
	{
		//IL_003c: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_005c: Expected O, but got I
		Debug.Log("<OnlinePlatformSupportBase.OnEndOnlineSession>");
		if (callback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [callback @ r8 (System.Action`1<System.Boolean>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v4 (should have been resolved before IL gen)");
		}
	}

	public virtual void ShowUsersProfile(string userId)
	{
		Debug.Log("<OnlinePlatformSupportBase.ShowUsersProfile>");
	}

	public virtual void InvitePlayers(string lobbyId)
	{
		Debug.Log("<OnlinePlatformSupportBase.InvitePlayers>");
	}

	public virtual void OnUpdate()
	{
	}
}
