using SE.EvilLib.AudioManager;
using UnityEngine;

public class InteractableLampHandle : Interactable
{
	private Lamp lamp;

	private float interactionStartTime;

	private Vector2 interactionMousePosition;

	private Vector2 interactionOffset;

	private bool invalidateClick;

	public bool playMovementSound;

	public AudioTypeSfx movementSound;

	private void Start()
	{
	}

	public override bool InteractionEnabled()
	{
		return false;
	}

	public override void OnInteractionDown()
	{
	}

	public override void OnInteractionUp()
	{
	}

	private bool CheckThreshold()
	{
		return false;
	}

	public override void Update()
	{
	}
}
