using UnityEngine;

[DisallowMultipleComponent]
public class MusicAreaAuthoring : MonoBehaviour
{
	public bool activeWhenEntityIsInCombat;

	public bool deactivateWhenEntityIsInState;

	public StateID stateToDeactivateIn;

	public MusicRosterType musicRosterType;

	public float fadeTime = 0.5f;

	public bool playOtherMusicWhenInCombat;

	public MusicRosterType otherMusicRosterType;

	public float otherFadeTime = 0.5f;

	public float startAtDistance;

	public float stopAtDistance;

	public float minCooldownToPlay;

	public float maxCooldownToPlay;

	public bool isInactive;

	public int prio;
}
