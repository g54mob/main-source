using EPOOutline;
using UnityEngine;

public class Dumpster : Interact
{
	private Outlinable outlineEffect;

	[SerializeField]
	private AudioClip soundTrashCan;

	private AudioSource audioSource;

	[SerializeField]
	private ParticleSystem trashParticleSystem;

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
