using EPOOutline;
using UnityEngine;
using UnityEngine.Events;

public class WorldObjectButton : Interact
{
	private Outlinable outlineEffect;

	[Tooltip("Assign methods here to be called when the object is clicked.")]
	[SerializeField]
	private UnityEvent onClick;

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
