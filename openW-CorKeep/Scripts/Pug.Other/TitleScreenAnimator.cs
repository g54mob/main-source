using System;
using System.Collections;
using Pug.UnityExtensions;
using UnityEngine;

public class TitleScreenAnimator : MonoBehaviour
{
	private TimerSimple readyTimer = new TimerSimple(8.3f);

	private TimerSimple thanksForPlayingTimer = new TimerSimple(8f);

	public PugText pressStart;

	public PugText legalBlurb;

	public PugText subtitle;

	public RadicalMainMenu mainMenuStandard;

	public GameObject thanksForPlayingObject;

	public GameObject thanksForPlayingText;

	public GameObject wishlistOnSteamText;

	private RadicalMainMenu mainMenu => mainMenuStandard;

	public void Start()
	{
		Manager.load.Event_OnPreUnload += OnPreUnload;
		if (Manager.input.IsAnyGamepadConnected())
		{
			pressStart.formatFields = new string[1] { "keyStart" };
		}
		else
		{
			pressStart.formatFields = new string[1] { "keyEnter" };
		}
		SetTitleTextEnabled(enable: true);
	}

	public void OnPreUnload(object sender, EventArgs args)
	{
		Manager.audio.FreeLoopingClips();
	}

	public void SetTitleTextEnabled(bool enable)
	{
		pressStart.gameObject.SetActive(enable);
		legalBlurb.gameObject.SetActive(enable);
	}

	private void OpenMenu()
	{
		SetTitleTextEnabled(enable: false);
		Manager.menu.PushMenu(mainMenu);
		Manager.input.singleplayerInputModule.SetGamepadLight(Color.blue);
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 0.6f, reuse: false, 1f, 0f);
		StartCoroutine(Co_MoveUpTitle());
		Manager.menu.OnTitleMenuOpened();
	}

	private IEnumerator Co_MoveUpTitle()
	{
		TimerSimple moveTimer = new TimerSimple(0.1f, unscaled: true);
		moveTimer.Start();
		Vector3 titleEndPosition = new Vector3(0f, 2f, 0f);
		while (moveTimer.isRunning && !moveTimer.isTimerElapsed)
		{
			base.transform.position = Vector3.Lerp(Vector3.zero, titleEndPosition, moveTimer.elapsedRatio);
			yield return null;
		}
		base.transform.position = titleEndPosition;
	}

	public void Update()
	{
		if (!Manager.load.IsScreenFadingOutOrBlack() && !Manager.menu.IsAnyMenuActive() && (Manager.input.GetAnyButton() || !pressStart.gameObject.activeSelf))
		{
			OpenMenu();
		}
	}
}
