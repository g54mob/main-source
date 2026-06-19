using System;
using Aggro.Core;
using FMODUnity;
using UnityEngine;

public class AudioObject : GlobalScriptableObject<AudioObject>
{
	[Serializable]
	public class ContractPlaylist
	{
		public EventReference[] playlist;
	}

	public EventReference lobbyTitleMusic;

	public ContractPlaylist[] contractPlaylists;

	public DeckCard<EventReference>[] lobbyPlayerJoined;

	public DeckCard<EventReference>[] breakRoomInitial;

	public DeckCard<EventReference>[] breakRoom;

	public DeckCard<EventReference>[] crashOut;

	[Space]
	public DeckCard<EventReference>[] shiftStart;

	public DeckCard<EventReference>[] organizationStartInitial;

	public DeckCard<EventReference>[] organizationStart;

	public DeckCard<EventReference>[] shiftWon;

	public DeckCard<EventReference>[] shiftLost;

	public DeckCard<EventReference>[] gameWon;

	public DeckCard<EventReference>[] incorrectOrder;

	[Space]
	public DeckCard<EventReference>[] timerWarningPhase1A;

	public DeckCard<EventReference>[] timerWarningPhase3A;

	public DeckCard<EventReference>[] timerWarningPhase4A;

	public DeckCard<EventReference>[] timerWarningPhase1B;

	public DeckCard<EventReference>[] timerWarningPhase3B;

	public DeckCard<EventReference>[] timerWarningPhase4B;
}
