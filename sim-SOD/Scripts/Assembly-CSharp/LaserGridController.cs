using NaughtyAttributes;
using UnityEngine;

public class LaserGridController : SwitchSyncBehaviour
{
	[Header("Components")]
	public Transform movementParent;

	public Transform laserParent;

	public Transform laser;

	public InteractableController controller;

	[Header("Settings")]
	public float speed;

	public float range;

	public bool useMovementX;

	[EnableIf("useMovementX")]
	public AnimationCurve movementX;

	public bool useMovementY;

	[EnableIf("useMovementY")]
	public AnimationCurve movementY;

	public bool useMovementZ;

	[EnableIf("useMovementZ")]
	public AnimationCurve movementZ;

	public bool useRotationX;

	[EnableIf("useRotationX")]
	public AnimationCurve rotationX;

	public bool useRotationY;

	[EnableIf("useRotationY")]
	public AnimationCurve rotationY;

	public bool useRotationZ;

	[EnableIf("useRotationZ")]
	public AnimationCurve rotationZ;

	[Header("State")]
	public float cycle;

	public bool bounce;

	public float randomMultiplier;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
