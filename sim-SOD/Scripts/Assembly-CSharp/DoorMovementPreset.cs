using UnityEngine;

[CreateAssetMenu(fileName = "doormovement_data", menuName = "Database/Door Movement Preset")]
public class DoorMovementPreset : SoCustomComparison
{
	public enum PhysicsBehaviour
	{
		ignore = 0,
		physicsEnabled = 1,
		stopDoorMovement = 2
	}

	[Header("Relative State Positions")]
	public Vector3 closedRelativePos;

	public Vector3 openRelativePos;

	[Space(5f)]
	public Vector3 closedRelativeEuler;

	public Vector3 openRelativeEuler;

	[Space(5f)]
	public Vector3 closedRelativeScale;

	public Vector3 openRelativeScale;

	[Header("State Movement")]
	[Tooltip("How fast the door opens")]
	public float doorOpenSpeed;

	[Tooltip("How fast the door closes")]
	public float doorCloseSpeed;

	public AnimationCurve animationCurve;

	[Header("Physics")]
	public PhysicsBehaviour collisionBehaviour;

	public bool behaviourAppliesWhenOpening;

	public bool behaviourAppliesWhenClosing;

	[Header("Audio")]
	public AudioEvent openAction;

	public AudioEvent closeAction;

	public AudioEvent openFinished;

	public AudioEvent closeFinished;

	public AudioEvent objectImpact;

	[Tooltip("If this is true then occlusion won't be calculated.")]
	public bool ignoreOcclusion;

	[Tooltip("If true then switch state 1 will be active while animating")]
	public bool switchState1AnimationSync;

	public bool useFixedUpdate;
}
