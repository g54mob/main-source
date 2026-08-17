using System.Runtime.CompilerServices;
using Coherence.Cloud;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class OnlinePlayerInviteButton : MonoBehaviour
{
	private SelectableUI _selectable;

	private RoomSelectionPage _roomSelectionPage;

	private void Start()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public unsafe void ButtonClicked()
	{
		//IL_0041: Expected O, but got Ref
		//IL_00b6: Expected O, but got I
		RoomSelectionPage roomSelectionPage = _roomSelectionPage;
		LobbiesManager lobbiesManager = roomSelectionPage._lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		object obj2 = default(object);
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = activeLobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+98]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		if (OnlinePlatformSupport.OnlinePlatformSupportInstance == null)
		{
			OnlinePlatformSupport.Setup();
		}
		string lobbyId = default(string);
		OnlinePlatformSupport.OnlinePlatformSupportInstance.InvitePlayers(lobbyId);
	}

	public OnlinePlayerInviteButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
