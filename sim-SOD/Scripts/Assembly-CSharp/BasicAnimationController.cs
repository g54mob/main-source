using NaughtyAttributes;
using UnityEngine;

public class BasicAnimationController : SwitchSyncBehaviour
{
	public bool isSetup;

	public InteractableController controller;

	public DoorMovementPreset preset;

	public bool oscillate;

	public Transform animatedTransform;

	[ReadOnly]
	[Tooltip("This animator has a warm-up time")]
	public float normalizedSpeed;

	[ReadOnly]
	public float progress;

	[ReadOnly]
	public bool inOut;

	[Space(7f)]
	public Vector3 closedLocalPos;

	public Vector3 openLocalPos;

	public Vector3 closedLocalEuler;

	public Vector3 openLocalEuler;

	public Vector3 closedLocalScale;

	public Vector3 openLocalScale;

	private void Start()
	{
	}

	public void Setup()
	{
	}

	public override void SetOn(bool val)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}
}
