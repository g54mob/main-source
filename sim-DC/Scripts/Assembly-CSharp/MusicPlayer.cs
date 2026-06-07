using EPOOutline;
using UnityEngine;

public class MusicPlayer : Interact
{
	private Outlinable outlineEffect;

	private AudioSource audioSource;

	private bool isTurnedOn;

	[SerializeField]
	private AudioClip[] audioClipsSongs;

	public override void Awake()
	{
	}

	public override void InteractOnClick()
	{
	}

	private void PlayRandomSong()
	{
	}

	private void Update()
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}
}
