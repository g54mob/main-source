using System;
using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MusicAreaCD : IComponentData, IQueryTypeParameter
{
	public bool activeWhenEntityIsInCombat;

	public bool deactivateWhenEntityIsInState;

	public StateID stateToDeactivateIn;

	[GhostField]
	public MusicRosterType musicRosterType;

	public bool playOtherMusicWhenInCombat;

	public MusicRosterType otherMusicRosterType;

	[NonSerialized]
	public MusicRosterType originalRosterType;

	public float startAtDistance;

	public float stopAtDistance;

	public float minCooldownToPlay;

	public float maxCooldownToPlay;

	[GhostField]
	public float fadeTime;

	public float otherFadeTime;

	public float originalFadeTime;

	[GhostField]
	public bool isInactive;

	public int prio;
}
