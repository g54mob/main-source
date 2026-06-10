using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "physicsprofile_data", menuName = "Database/Physics Profile")]
public class PhysicsProfile : SoCustomComparison
{
	[Header("Physics")]
	[Tooltip("Mass of the object when physics is enabled")]
	public float mass;

	[Tooltip("'How much air resistance affects the object when moving from forces. 0 means no air resistance, and infinity makes the object stop moving immediately.'")]
	public float drag;

	[Tooltip("'How much air resistance affects the object when rotating from torque. 0 means no air resistance. Note that you cannot make the object stop rotating just by setting its Angular Drag to infinity.'")]
	public float angularDrag;

	[Tooltip("If the object is held, it will default to this euler")]
	public Vector3 heldEuler;

	[Tooltip("Add this on to the base tamper distance before it is considered a crime")]
	public float tamperDistanceModifier;

	[Tooltip("Muliply the throw force in the gameplay settings by this.")]
	public float throwForceMultiplier;

	[Tooltip("Multiply any damage caused by throw impact with this")]
	public float throwDamageMultiplier;

	[Tooltip("Treat the audio event as caused by player, therefore making AI react to it")]
	public bool treatAsCausedByPlayer;

	[Tooltip("The default collision detection mode")]
	public CollisionDetectionMode collisionMode;

	[Tooltip("If true, this will be destroyed/removed if it's position needs to be reset. If false it will be reset to spawn position.")]
	public bool removeOnReset;

	[Header("Audio")]
	[Tooltip("Physics collisions use this sound")]
	public AudioEvent physicsCollisionAudio;

	[Tooltip("Pass the surface parameters to the collision audio event")]
	public bool useDifferentSoundForWallImpacts;

	[ShowIf("useDifferentSoundForWallImpacts")]
	public AudioEvent wallCollisionAudio;
}
