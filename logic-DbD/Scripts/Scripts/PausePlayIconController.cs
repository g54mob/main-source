using UnityEngine;
using UnityEngine.UI;

public class PausePlayIconController : MonoBehaviour
{
	[SerializeField]
	private Sprite playButton;

	[SerializeField]
	private Sprite pauseButton;

	public void SwitchSprite()
	{
		GetComponent<Image>().sprite = (IsPaused() ? playButton : pauseButton);
	}

	public void PlaySprite()
	{
		GetComponent<Image>().sprite = playButton;
	}

	public void PauseSprite()
	{
		GetComponent<Image>().sprite = pauseButton;
	}

	public bool IsPaused()
	{
		return GetComponent<Image>().sprite == pauseButton;
	}
}
