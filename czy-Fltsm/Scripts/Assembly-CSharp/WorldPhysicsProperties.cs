using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Physics/World Physics")]
public class WorldPhysicsProperties : ScriptableObject
{
	[Header("Relative Flotsam Movement")]
	[Tooltip("Relative direction of the flotsam moving direction.")]
	public Vector3 RelativeFlotsamDirection = Vector3.zero;

	[Tooltip("The relative force that will be applied to the flotsam.")]
	public float RelativeFlotsamSpeed;

	[Tooltip("The maximum force the flotsam can receive.")]
	public float MaximumFlotsamForce = 150f;

	[Header("World Rigid body Properties")]
	[Tooltip("The mass for the rigid body on the world.")]
	public float WorldMass = 10f;

	[Tooltip("The world drag for the rigid body on the world.")]
	public float WorldDrag = 0.8f;

	[Tooltip("The world angular drag for the rigid body on the world.")]
	public float WorldAngularDrag = 0.2f;

	[Header("Construction Sink")]
	[Tooltip("The multiplier for the mass when sinking objects.")]
	public float MassMultiplier = 15f;

	[Tooltip("The new drag for the rigid body when sinking objects.")]
	public float NewDrag;

	[Header("Miscellaneous")]
	[Tooltip("The multiplier that will be used to calculate the navigator speed in the water.")]
	public float NavigatorWorldSpeedMultiplier = 0.0025f;

	[Tooltip("The height to destroy a objects when it sinks under it.")]
	public float DestructionHeight = -30f;
}
