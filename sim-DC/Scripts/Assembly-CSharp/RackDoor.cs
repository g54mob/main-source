using EPOOutline;
using UnityEngine;

public class RackDoor : Interact
{
	private bool isOpened;

	private Outlinable outlineEffect;

	private Vector3 initialRotation;

	[SerializeField]
	private Vector3 openRotation;

	[SerializeField]
	private float openDuration;

	private BoxCollider boxCollider;

	public override void Awake()
	{
	}

	public override void InteractOnClick()
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}
}
