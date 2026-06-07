using UnityEngine;
using UnityEngine.UI;

public class PauseButtonMgmt : MonoBehaviour
{
	public Sprite pausedSprite;

	public Sprite playingSprite;

	public GameObject pauseButton;

	public Text pauseButtonText;

	public Image pauseButtonImage;

	public GameObject topPauseButton;

	private bool pauseButtonPaused;

	private void LateUpdate()
	{
	}

	public void OnPause()
	{
	}
}
