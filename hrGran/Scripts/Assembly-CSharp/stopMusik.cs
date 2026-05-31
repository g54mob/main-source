using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class stopMusik : MonoBehaviour
{
	[Header("Theme Music Clips")]
	[Tooltip("The default menu music clip.")]
	[SerializeField]
	private AudioClip defaultMusicClip;

	[Tooltip("The Halloween-themed music clip.")]
	[SerializeField]
	private AudioClip halloweenMusicClip;

	[Tooltip("The Christmas-themed music clip.")]
	[SerializeField]
	private AudioClip christmasMusicClip;

	[Tooltip("The Nightmare-themed music clip.")]
	[SerializeField]
	private AudioClip nightmareMusicClip;

	private const string MUSIC_TOGGLE_KEY = "musikOnOff";

	private const string HALLOWEEN_KEY = "HalloweenOnOff";

	private const string CHRISTMAS_KEY = "ChristmasOnOff";

	private const string NIGHTMARE_KEY = "NightMareOnOff";

	public virtual void Start()
	{
	}

	private AudioClip GetTargetClip()
	{
		return null;
	}

	private void ApplyAndPlayThemeMusic(AudioSource audioSource)
	{
	}

	public void ChangeThemeMusic()
	{
	}

	public virtual void turnOn()
	{
	}

	public virtual void turnOff()
	{
	}
}
