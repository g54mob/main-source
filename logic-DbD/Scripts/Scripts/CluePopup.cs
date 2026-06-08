using UnityEngine;
using UnityEngine.UI;

public class CluePopup : Panel
{
	public const string IMAGE_PATH = "Image";

	public void SetImage(Sprite image)
	{
		Image component = base.transform.Find("Image").GetComponent<Image>();
		component.sprite = image;
		component.preserveAspect = true;
	}

	public void SetAudio(AudioClip clip, string transcript)
	{
		AudioClueManager component = base.transform.GetComponent<AudioClueManager>();
		component.SetTranscript(transcript);
		component.SetAudioClip(clip);
		component.PlayAudio();
	}

	public void SetTransform(Rect scale)
	{
		RectTransform component = base.transform.GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale.width);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, scale.height);
	}
}
