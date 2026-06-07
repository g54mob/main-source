using UnityEngine;

public class HighlightSound : MonoBehaviour, IHoverReaction
{
	public AudioClip sound;

	private void Awake()
	{
	}

	public void OnHovered()
	{
		sound.Play2D();
	}

	public void OnUnhovered()
	{
	}
}
