using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/Physics/Physics")]
public class PhysicsProperties : ScriptableObject
{
	[Header("General")]
	[Tooltip("Should the collider on the visual prefab be copied to the game object that has the PhysicsController component attached?")]
	public bool CopyVisualPrefabCollider = true;

	[Tooltip("This object will have a buoyancy component.")]
	public bool Buoyant = true;

	[Tooltip("The setitngs for the buoyancy.")]
	public Buoyancy.QualityLevel BuoyancySetting;

	[Tooltip("Does this object allow to reduce level of detail on buoyancy")]
	[ConditionalHide("Buoyant")]
	public bool AllowsBuoyancyLevelOfDetail;

	[Tooltip("At what distance from the camera should the buoyancy not be simulated.")]
	[ConditionalHide("Buoyant")]
	public float BuoyancyLevelOfDetailCameraDistance = float.MaxValue;

	[Tooltip("If enabled, the object will always go back to the upright rotation.")]
	[ConditionalHide("Buoyant")]
	public bool FloatUpright;

	[Tooltip("Speed at which an object rotates upright.")]
	[ConditionalHide("FloatUpright")]
	public float UprightRotationalSpeed = 1f;

	[Space]
	[Tooltip("Parent the object to the world.")]
	[ConditionalHide("Buoyant", Inverse = true)]
	public bool AttachToWorld;

	[Tooltip("This object is an agent. This means the object will need a secondary collider assigned.")]
	public bool Agent;

	[Tooltip("Should the object slow down when nearing the townheart.")]
	[FormerlySerializedAs("ShouldSlowsDownNearTownheart")]
	public bool SlowDownNearTownheart;

	[Header("Buoyancy")]
	[Tooltip("Density for the buoyant collider. Defines how easy the object will float.")]
	[ConditionalHide("Buoyant")]
	public float Density = 500f;

	[Tooltip("How many slices the collider will be divided in. This determines how many voxels you'll have.")]
	[ConditionalHide("Buoyant")]
	public Vector3 Slices = Vector3.one * 2f;

	[Tooltip("The object is concave. This will affect the buoyancy.")]
	[ConditionalHide("Buoyant")]
	public bool IsConcave;

	[Tooltip("Maximum amount of voxels that this object can be divided in.")]
	[ConditionalHide("Buoyant")]
	public int VoxelsLimit = 16;

	[Tooltip("Have this object spawn beneath the water surface.")]
	[ConditionalHide("Buoyant")]
	public bool SpawnBeneathWaterSurface = true;

	[Tooltip("The lerp value used to smooth the movement when the buoyancy is update on Update (Not FixedUpdate).")]
	[Range(0.01f, 1f)]
	public float WaterLevelLerp = 1f;

	[Space]
	[Tooltip("Set the collider as trigger.")]
	public bool IsTrigger;

	[Header("Rigid Body")]
	[ConditionalHide("Buoyant")]
	[Tooltip("The mass of the rigid body.")]
	public float Mass = 1f;

	[ConditionalHide("Buoyant")]
	[Tooltip("The drag of the object.")]
	public float Drag = 1f;

	[ConditionalHide("Buoyant")]
	[Tooltip("The angular drag of the object.")]
	public float AngularDrag = 1f;

	[ConditionalHide("Buoyant")]
	[Tooltip("Controls whether gravity affects this rigid body.")]
	public bool UseGravity = true;

	[Tooltip("Controls whether physics affects the rigid body.")]
	public bool IsKinematic;

	[Space]
	[Tooltip("Freeze the constraint for the x position.")]
	public bool FreezePositionX;

	[Tooltip("Freeze the constraint for the y position.")]
	public bool FreezePositionY;

	[Tooltip("Freeze the constraint for the z position.")]
	public bool FreezePositionZ;

	[Space]
	[Tooltip("Freeze the constraint for the x rotation.")]
	public bool FreezeRotationX;

	[Tooltip("Freeze the constraint for the y rotation.")]
	public bool FreezeRotationY;

	[Tooltip("Freeze the constraint for the z rotation.")]
	public bool FreezeRotationZ;
}
