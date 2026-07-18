using UnityEngine;

public class UI_SoundManager : MonoBehaviour
{
	public static UI_SoundManager Instance;

	[SerializeField]
	private SoundManager soundManager;

	[SerializeField]
	private AudioClip hoverSfx;

	[SerializeField]
	private AudioClip leaveHoverSfx;

	private void Awake()
	{
		Instance = this;
	}

	public void PlayHoverSound(bool hover)
	{
		soundManager.PlaySound(hover ? hoverSfx : leaveHoverSfx, randomPitch: true);
	}
}
