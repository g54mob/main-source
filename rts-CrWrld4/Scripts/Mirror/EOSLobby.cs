using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Epic.OnlineServices.Lobby;
using UnityEngine;

public class EOSLobby : MonoBehaviour
{
	public delegate void CreateLobbySuccess(List<Attribute> attributes);

	public delegate void CreateLobbyFailure(string errorMessage);

	public delegate void JoinLobbySuccess(List<Attribute> attributes);

	public delegate void JoinLobbyFailure(string errorMessage);

	public delegate void FindLobbiesSuccess(List<LobbyDetails> foundLobbies);

	public delegate void FindLobbiesFailure(string errorMessage);

	public delegate void LeaveLobbySuccess();

	public delegate void LeaveLobbyFailure(string errorMessage);

	public delegate void UpdateAttributeSuccess(string key);

	public delegate void UpdateAttributeFailure(string key, string errorMessage);

	public delegate void LobbyMemberStatusUpdate(LobbyMemberStatusReceivedCallbackInfo callback);

	public delegate void LobbyAttributeUpdate(LobbyUpdateReceivedCallbackInfo callback);

	[SerializeField]
	public string[] AttributeKeys;

	private const string DefaultAttributeKey = "default";

	public const string hostAddressKey = "host_address";

	private string currentLobbyId;

	private bool isLobbyOwner;

	private List<LobbyDetails> foundLobbies;

	private List<Attribute> lobbyData;

	private ulong lobbyMemberStatusNotifyId;

	private ulong lobbyAttributeUpdateNotifyId;

	[HideInInspector]
	public bool ConnectedToLobby { get; private set; }

	public LobbyDetails ConnectedLobbyDetails { get; private set; }

	public event CreateLobbySuccess CreateLobbySucceeded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event CreateLobbyFailure CreateLobbyFailed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event JoinLobbySuccess JoinLobbySucceeded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event JoinLobbyFailure JoinLobbyFailed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event FindLobbiesSuccess FindLobbiesSucceeded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event FindLobbiesFailure FindLobbiesFailed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event LeaveLobbySuccess LeaveLobbySucceeded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event LeaveLobbyFailure LeaveLobbyFailed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event UpdateAttributeSuccess AttributeUpdateSucceeded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event UpdateAttributeFailure AttributeUpdateFailed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event LobbyMemberStatusUpdate LobbyMemberStatusUpdated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event LobbyAttributeUpdate LobbyAttributeUpdated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public virtual void Start()
	{
	}

	public virtual void CreateLobby(uint maxConnections, LobbyPermissionLevel permissionLevel, bool presenceEnabled, AttributeData[] lobbyData = null)
	{
	}

	public virtual void FindLobbies(uint maxResults = 100u, LobbySearchSetParameterOptions[] lobbySearchSetParameterOptions = null)
	{
	}

	public virtual void JoinLobby(LobbyDetails lobbyToJoin, string[] attributeKeys = null, bool presenceEnabled = false)
	{
	}

	public virtual void LeaveLobby()
	{
	}

	public virtual void RemoveAttribute(string key)
	{
	}

	private void UpdateAttribute(AttributeData attribute)
	{
	}

	public void UpdateLobbyAttribute(string key, bool newValue)
	{
	}

	public void UpdateLobbyAttribute(string key, int newValue)
	{
	}

	public void UpdateLobbyAttribute(string key, double newValue)
	{
	}

	public void UpdateLobbyAttribute(string key, string newValue)
	{
	}
}
