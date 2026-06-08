using UnityEngine;
using UnityEngine.UI;

public class SpeakerIconSwitcher : MonoBehaviour
{
	[SerializeField]
	private Sprite mute;

	[SerializeField]
	private Sprite speaker;

	[SerializeField]
	private Image speakerImage;

	public void OnVolumeChanged()
	{
		speakerImage.sprite = ((GetComponent<Slider>().value == 0f) ? mute : speaker);
	}
}
