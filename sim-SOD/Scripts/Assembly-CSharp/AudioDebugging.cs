using NaughtyAttributes;
using UnityEngine;

public class AudioDebugging : MonoBehaviour
{
	[Header("Debug Controls")]
	public bool overrideSmokeStackEmissionFrequency;

	[InfoBox("Controls how often the chem plant smoke plumes appear in in-game minutes (roughly). This will only take effect after the last plume.", EInfoBoxType.Normal)]
	[EnableIf("overrideSmokeStackEmissionFrequency")]
	public float chemSmokeStackEmissionFrequency;

	[Space(7f)]
	public bool overrideThunderDelay;

	[EnableIf("overrideThunderDelay")]
	[InfoBox("Controls how often thunder happens in storms", EInfoBoxType.Normal)]
	public float thunderDelay;

	[InfoBox("The distance threshold at which the ThunderDistance param passes 1 instead of 0 (1 = 1m) 2D distance with world height not taken into account", EInfoBoxType.Normal)]
	public float thunderDistanceThreshold;

	[Space(7f)]
	[InfoBox("At what point in the closing door animation does the closeDoor event trigger? 0 = completely closed, 1 = completely open", EInfoBoxType.Normal)]
	public float doorCloseTriggerPoint;

	[InfoBox("A multiplier that controls how far a citizen moves before creating a footstep sound & footprint", EInfoBoxType.Normal)]
	[Space(7f)]
	public float citizenFootstepDistanceMultiplier;

	[InfoBox("Spawn an object infront of the player by choosing a config using the below, then use the spawn object button.", EInfoBoxType.Normal)]
	[Header("Object Spawn")]
	public InteractablePreset spawnObject;

	private static AudioDebugging _instance;

	public static AudioDebugging Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SpawnObject()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TriggerNextTVShow()
	{
	}
}
