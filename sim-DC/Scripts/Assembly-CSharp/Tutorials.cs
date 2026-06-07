using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorials : MonoBehaviour
{
	public static Tutorials instance;

	[SerializeField]
	private GameObject tutorialPanel;

	[SerializeField]
	private VideoPlayer videoPlayer;

	[SerializeField]
	private TextMeshProUGUI textTutorial;

	[SerializeField]
	private TextMeshProUGUI pauseMenuTextTutorial;

	private int tutorialIndex;

	private int[] tutorialTextIndexLocalisation;

	private bool wasSkippedTutorials;

	private Action<InputAction.CallbackContext> escapePerformed;

	[SerializeField]
	private ButtonExtended shopButton;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void ShowTutorial(int i)
	{
	}

	private void PlayVideo(int _tutorialIndex, bool isInPauseMenu = false)
	{
	}

	public void ButtonShowTutorialInPauseMenu(int i)
	{
	}

	public void StopVideoInPauseMenu()
	{
	}

	private void OnVideoPrepared(VideoPlayer vp)
	{
	}

	private void StopTutorial()
	{
	}

	public void ButtonOK()
	{
	}

	public void SkipTutorials()
	{
	}
}
