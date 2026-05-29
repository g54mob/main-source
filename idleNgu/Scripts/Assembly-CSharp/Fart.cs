using UnityEngine;

public class Fart : MonoBehaviour
{
	public HoverTooltip tooltip;

	public AudioSource fartNoise;

	public void fart()
	{
		AudioClip clip = Resources.Load<AudioClip>("Sounds/LongFart");
		fartNoise.clip = clip;
		fartNoise.mute = false;
		fartNoise.Play();
		tooltip.showOverrideTooltip("Motor Bike Fart' by Mike Koenig licensed under CC Unported 3.0. http://soundbible.com/643-Motor-Bike-Fart.html", 3f);
	}
}
