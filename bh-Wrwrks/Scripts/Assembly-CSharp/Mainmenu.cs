using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : Menu
{
	public enum State
	{
		Start = 0,
		Collection = 1,
		Settings = 2,
		Quit = 3,
		Intro = 4,
		Wish = 5,
		Continue = 6
	}

	public enum animState
	{
		None = 0,
		Opening = 1,
		Closing = 2
	}

	public UIButton startButton;

	public UIButton collectionButton;

	public UIButton settingsButton;

	public UIButton quitButton;

	public UIButton[] buttons;

	public Dungeon dungeon;

	public GameObject lineObj;

	public Line activeLine;

	private Vector3 lineStart = Vector3.zero;

	public State currState = State.Intro;

	private State prevState = State.Intro;

	public Sprite ngSprite;

	public Sprite contSprite;

	public GameObject corruptSaveError;

	public SpriteRenderer transitionSprite;

	public List<Sprite> transAnim;

	public GameObject clickBlocker;

	public SpriteRenderer menuBG;

	public Sprite pauseMenuSprite;

	public Sprite resumeButton;

	public Sprite mainmenuButton;

	public UIButton creditsButton;

	public UIButton discButton;

	private bool quitting;

	public List<Sprite> animSprites;

	public List<Sprite> animSpritesBase;

	public List<Sprite> animSpritesNewGame;

	public List<Sprite> animSpritesCollection;

	public List<Sprite> animSpritesSettings;

	public List<Sprite> animSpritesQuit;

	public List<Sprite> animSpritesWish;

	public List<Sprite> animSpritesCont;

	public Sprite extraSprite;

	public SpriteRenderer boxFrame;

	private int currFrame = 12;

	public GameObject[] menuObjects;

	public animState anim;

	private Coroutine animCoroutine;

	public GameObject currMenu;

	private Coroutine sfxCoroutine;

	public GameObject ResolutionContainer;

	public GameObject resPopup;

	public GameObject applyButton;

	public GameObject revertButton;

	public TMP_Text resolutionCofirmText;

	private int origRes;

	private int resTimer;

	private Coroutine reverter;

	public UIButton[] langButtons;

	public UIButton langMenuButton;

	private bool showingLang;

	private void Start()
	{
		if (activeLine != null)
		{
			Object.Destroy(activeLine.gameObject);
		}
		GameObject gameObject = Object.Instantiate(lineObj);
		activeLine = gameObject.GetComponent<Line>();
		activeLine.line.sortingOrder = 5;
		activeLine.order = activeLine.line.sortingOrder;
		activeLine.line.sortingLayerName = "UI";
		LineRenderer line = activeLine.line;
		float startWidth = (activeLine.line.endWidth = 0.35f);
		line.startWidth = startWidth;
		activeLine.line.numCapVertices = 5;
		activeLine.line.numCornerVertices = 5;
		activeLine.hitbox.enabled = false;
		activeLine.Clear();
		lineStart = startButton.transform.position + new Vector3(3.5625f, 0.0625f, 0f);
		if (dungeon.demo && RestartManager.Instance.win && dungeon.saveData.currDifficulty == 1)
		{
			SetState(State.Wish, silent: true);
		}
		else if (dungeon.saveData.savedRun)
		{
			buttons[0].bg.sprite = dungeon.currentLocale.continueButton;
			buttons[0].data = 6;
			SetState(State.Continue, silent: true);
		}
		else
		{
			buttons[0].bg.sprite = dungeon.currentLocale.newGame;
			SetState(State.Start, silent: true);
		}
		bool silent = false;
		if (RestartManager.Instance.restarter)
		{
			StartCoroutine(ResetAnim());
			RestartManager.Instance.restarter = false;
			silent = true;
		}
		if (RestartManager.Instance.menuTransition)
		{
			StartCoroutine(GameQuitTransition());
			RestartManager.Instance.menuTransition = false;
		}
		RestartManager.Instance.win = false;
		StartCoroutine(MusicDelay(silent));
	}

	private IEnumerator GameQuitTransition()
	{
		clickBlocker.SetActive(value: true);
		transitionSprite.sprite = transAnim[transAnim.Count - 1];
		yield return Dungeon.WaitUI(5);
		for (int i = transAnim.Count - 1; i >= 0; i--)
		{
			transitionSprite.sprite = transAnim[i];
			yield return AnimationManager.WaitUI(1);
		}
		clickBlocker.SetActive(value: false);
	}

	private IEnumerator GameClose()
	{
		clickBlocker.SetActive(value: true);
		transitionSprite.sprite = transAnim[0];
		yield return Dungeon.WaitUI(5);
		for (int i = 0; i < transAnim.Count; i++)
		{
			transitionSprite.sprite = transAnim[i];
			yield return AnimationManager.WaitUI(1);
		}
	}

	private IEnumerator ResetAnim()
	{
		clickBlocker.SetActive(value: true);
		transitionSprite.sprite = transAnim[transAnim.Count - 1];
		SetState((!dungeon.demo) ? State.Collection : State.Wish, silent: true);
		yield return Dungeon.WaitUI(1);
		dungeon.InitBoard();
		yield return Dungeon.WaitUI(4);
		Camera.main.transform.position = new Vector3(0f, 0f, -50f);
		buttons[0].bg.sprite = dungeon.currentLocale.resume;
		buttons[3].bg.sprite = dungeon.currentLocale.mainmenu;
		menuBG.sprite = pauseMenuSprite;
		creditsButton.transform.localScale = Vector3.zero;
		discButton.transform.localScale = Vector3.zero;
		for (int i = transAnim.Count - 1; i >= 0; i--)
		{
			transitionSprite.sprite = transAnim[i];
			yield return AnimationManager.WaitUI(1);
		}
		clickBlocker.SetActive(value: false);
	}

	private IEnumerator MusicDelay(bool silent = false)
	{
		yield return Dungeon.WaitUI(animSprites.Count);
		if (!silent)
		{
			sfxCoroutine = StartCoroutine(slideSFX(State.Start, open: true));
		}
		dungeon.audioManager.PlayMusic(AudioManager.Music.Title);
	}

	private void Update()
	{
		if (Camera.main.transform.position.x < -10f)
		{
			UIButton uIButton = buttons[(int)currState];
			lineStart = Vector3.Lerp(lineStart, uIButton.transform.position + new Vector3(3.5625f, 0.0625f, 0f), 0.6f);
			Vector3 vector = base.transform.position + new Vector3(-0.8125f, 0.0625f, 0f);
			DrawLine(lineStart, vector);
		}
	}

	private void DrawLine(Vector2 pos, Vector2 target)
	{
		activeLine.Clear();
		foreach (Vector2 item in dungeon.animationManager.GetCable(pos, target))
		{
			activeLine.UpdateLine(item);
		}
	}

	public void SetState(State s, bool silent = false)
	{
		if (quitting)
		{
			return;
		}
		RevertRes();
		if (dungeon.paused && s == State.Start)
		{
			dungeon.Unpause();
		}
		else if (currState == s)
		{
			if (s == State.Start && anim == animState.None)
			{
				StartGame();
			}
			if (s == State.Wish && anim == animState.None)
			{
				SteamManager.Wishlist();
			}
			if (s == State.Quit && !dungeon.paused && anim == animState.None)
			{
				QuitGame();
			}
		}
		else
		{
			prevState = currState;
			currState = s;
			TransitionMenu(silent);
		}
	}

	public void AbandonRun()
	{
		dungeon.saveData.savedRun = false;
		dungeon.saveManager.SaveGame();
		SetState(State.Start);
		buttons[0].bg.sprite = dungeon.currentLocale.newGame;
		buttons[0].data = 0;
		BounceButton(buttons[0], 2, silent: true);
	}

	private IEnumerator corruptError()
	{
		GameObject g = Object.Instantiate(corruptSaveError);
		g.GetComponent<SpriteRenderer>().sprite = dungeon.currentLocale.errorPopups[2];
		g.transform.localScale = Vector3.zero;
		g.transform.position = new Vector3(-43.375f, 5.4f, 0f);
		dungeon.animationManager.LerpZoom(g, Vector3.one, 8f, 0.1f);
		dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Error);
		yield return Dungeon.WaitUI(90);
		dungeon.animationManager.LerpZoom(g, Vector3.zero, 8f, 0f, destroy: true);
	}

	public void StartGame(bool cont = false)
	{
		if (cont)
		{
			try
			{
				dungeon.saveManager.LoadRunData(dungeon.saveData.currentRun);
			}
			catch
			{
				Debug.Log("Save file corrupt");
				dungeon.saveManager.UnloadCorruptData();
				SetState(State.Start);
				StartCoroutine(corruptError());
				return;
			}
		}
		else
		{
			dungeon.InitBoard();
		}
		StartCoroutine(start_transition());
	}

	public void ResetScene(bool resetGame = false)
	{
		if (resetGame)
		{
			dungeon.saveData.savedRun = false;
		}
		else if (!dungeon.gameover)
		{
			dungeon.saveData.savedRun = true;
			dungeon.saveManager.SaveRunData();
		}
		StartCoroutine(reset_scene(resetGame));
	}

	public void QuitGame()
	{
		if (!quitting)
		{
			quitting = true;
			StartCoroutine(GameClose());
			StartCoroutine(transitionAnim(silent: false, quit: true));
		}
	}

	private IEnumerator reset_scene(bool resetGame)
	{
		clickBlocker.SetActive(value: true);
		for (int i = 0; i < transAnim.Count; i++)
		{
			transitionSprite.sprite = transAnim[i];
			yield return AnimationManager.WaitUI(1);
		}
		yield return AnimationManager.WaitUI(5);
		if (resetGame)
		{
			RestartManager.Instance.restarter = true;
		}
		else
		{
			RestartManager.Instance.menuTransition = true;
		}
		dungeon.saveManager.SaveGame();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private IEnumerator start_transition()
	{
		clickBlocker.SetActive(value: true);
		for (int i = 0; i < transAnim.Count; i++)
		{
			transitionSprite.sprite = transAnim[i];
			yield return AnimationManager.WaitUI(1);
		}
		SetState((!dungeon.demo) ? State.Collection : State.Wish, silent: true);
		yield return AnimationManager.WaitUI(15);
		Camera.main.transform.position = new Vector3(0f, 0f, -50f);
		buttons[0].bg.sprite = dungeon.currentLocale.resume;
		buttons[0].data = 0;
		buttons[3].bg.sprite = dungeon.currentLocale.mainmenu;
		menuBG.sprite = pauseMenuSprite;
		creditsButton.transform.localScale = Vector3.zero;
		discButton.transform.localScale = Vector3.zero;
		for (int i = transAnim.Count - 1; i >= 0; i--)
		{
			transitionSprite.sprite = transAnim[i];
			yield return AnimationManager.WaitUI(1);
		}
		if (!dungeon.saveData.tutorials[0])
		{
			dungeon.saveManager.PopupTutorial(0);
		}
		yield return null;
		clickBlocker.SetActive(value: false);
	}

	public override void BounceButton(UIButton b, int f = 2, bool silent = false)
	{
		if (!silent)
		{
			if (f == 1)
			{
				dungeon.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f, 0.8f);
			}
			else
			{
				dungeon.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.9f, 0.5f);
			}
		}
		base.BounceButton(b, f, silent);
	}

	public void TransitionMenu(bool silent)
	{
		if (anim == animState.Opening && animCoroutine != null)
		{
			StopCoroutine(animCoroutine);
		}
		if (anim != animState.Closing)
		{
			animCoroutine = StartCoroutine(transitionAnim(silent));
		}
	}

	private void CreateMenu(State s)
	{
		dungeon.tooltip.Hide(force: true);
		if (currMenu != null)
		{
			Object.Destroy(currMenu);
		}
		currMenu = Object.Instantiate(menuObjects[(int)s]);
		currMenu.transform.position = base.transform.position;
		switch (s)
		{
		case State.Start:
			animSprites = animSpritesNewGame;
			break;
		case State.Collection:
			animSprites = animSpritesCollection;
			break;
		case State.Settings:
			animSprites = animSpritesSettings;
			break;
		case State.Quit:
			animSprites = animSpritesQuit;
			break;
		case State.Wish:
			animSprites = animSpritesWish;
			break;
		case State.Continue:
			animSprites = animSpritesCont;
			break;
		case State.Intro:
			break;
		}
	}

	private IEnumerator slideSFX(State s, bool open)
	{
		float pitch = (open ? 1f : 0.9f);
		switch (s)
		{
		case State.Start:
			dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Menu_Slide_0, pitch);
			break;
		case State.Collection:
			dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Menu_Slide_0, pitch);
			break;
		case State.Settings:
			dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Menu_Slide_0, pitch);
			break;
		case State.Quit:
			dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Menu_Slide_0, pitch);
			break;
		case State.Wish:
			dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Menu_Slide_0, pitch);
			break;
		case State.Continue:
			dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Menu_Slide_0, pitch);
			break;
		}
		yield return null;
	}

	private IEnumerator transitionAnim(bool silent, bool quit = false)
	{
		anim = animState.Closing;
		if (!silent)
		{
			sfxCoroutine = StartCoroutine(slideSFX(prevState, open: false));
		}
		if (currMenu != null)
		{
			currMenu.GetComponent<Menu>().CloseEffect();
		}
		for (int i = currFrame; i < animSprites.Count; i++)
		{
			boxFrame.sprite = animSprites[i];
			currFrame = i;
			yield return AnimationManager.WaitUI(1);
		}
		yield return AnimationManager.WaitUI(15);
		if (quit)
		{
			dungeon.saveManager.SaveGame();
			quitting = false;
			anim = animState.None;
			Application.Quit();
			yield break;
		}
		CreateMenu(currState);
		if (!silent)
		{
			sfxCoroutine = StartCoroutine(slideSFX(currState, open: true));
		}
		anim = animState.Opening;
		for (int i = animSprites.Count - 1; i >= 0; i--)
		{
			boxFrame.sprite = animSprites[i];
			currFrame = i;
			yield return AnimationManager.WaitUI(1);
		}
		boxFrame.sprite = animSprites[0];
		anim = animState.None;
	}

	public void ShowResolutionConfirm(int originalRes)
	{
		bool flag = reverter != null;
		resTimer = 15;
		SaveManager.Language language = dungeon.saveData.language;
		if (language == SaveManager.Language.English || language != SaveManager.Language.Japanese)
		{
			resolutionCofirmText.SetText($"CONFIRM CHANGES?\r\nWILL REVERT IN ({resTimer})\r\n ");
		}
		else
		{
			resolutionCofirmText.SetText($"<size=6.25>変更を維持しますか？</size>\r\n{resTimer}<SIZE=6.25>秒後に元に戻ります</SIZE>\r\n ");
		}
		if (!flag)
		{
			StartCoroutine(showBox());
			origRes = originalRes;
			reverter = StartCoroutine(ResReverter(originalRes));
		}
	}

	public void ApplyRes()
	{
		if (reverter != null)
		{
			StopCoroutine(reverter);
			reverter = null;
			resTimer = 0;
			StartCoroutine(hideBox(4));
		}
	}

	private IEnumerator showBox()
	{
		ResolutionContainer.transform.position += new Vector3(0f, -20f);
		dungeon.animationManager.LerpZoom(resPopup, Vector3.one, 4f, 0.1f, destroy: false, UI: true);
		applyButton.GetComponent<BoxCollider2D>().enabled = false;
		revertButton.GetComponent<BoxCollider2D>().enabled = false;
		dungeon.animationManager.LerpZoom(applyButton, Vector3.one, 4f, 0.1f, destroy: false, UI: true);
		dungeon.animationManager.LerpZoom(revertButton, Vector3.one, 4f, 0.1f, destroy: false, UI: true);
		yield return Dungeon.WaitUI(5);
		applyButton.GetComponent<BoxCollider2D>().enabled = true;
		revertButton.GetComponent<BoxCollider2D>().enabled = true;
	}

	private IEnumerator hideBox(int f)
	{
		dungeon.animationManager.LerpZoom(resPopup, Vector3.zero, f, 0f, destroy: false, UI: true);
		dungeon.animationManager.LerpZoom(applyButton, Vector3.zero, f, 0f, destroy: false, UI: true);
		dungeon.animationManager.LerpZoom(revertButton, Vector3.zero, f, 0f, destroy: false, UI: true);
		applyButton.GetComponent<BoxCollider2D>().enabled = false;
		revertButton.GetComponent<BoxCollider2D>().enabled = false;
		yield return Dungeon.WaitUI(f);
		ResolutionContainer.transform.position += new Vector3(0f, 20f);
	}

	public void RevertRes()
	{
		if (reverter != null)
		{
			dungeon.saveData.videoPrefs.resolution = origRes;
			if (currState == State.Settings)
			{
				currMenu.GetComponent<SettingsMenu>().resButton.bg.sprite = Dungeon.Instance.currentLocale.resolutionText[origRes];
				currMenu.GetComponent<SettingsMenu>().BounceButton(currMenu.GetComponent<SettingsMenu>().resButton, 2, silent: true);
			}
			Dungeon.Instance.saveManager.SetScreen();
			Dungeon.Instance.saveManager.SaveGame();
			StopCoroutine(reverter);
			reverter = null;
			StartCoroutine(hideBox(4));
		}
	}

	private IEnumerator ResReverter(int original)
	{
		while (resTimer > 0)
		{
			resTimer--;
			SaveManager.Language language = dungeon.saveData.language;
			if (language == SaveManager.Language.English || language != SaveManager.Language.Japanese)
			{
				resolutionCofirmText.SetText($"CONFIRM CHANGES?\r\nWILL REVERT IN ({resTimer})\r\n ");
			}
			else
			{
				resolutionCofirmText.SetText($"<size=6.25>変更を維持しますか？</size>\r\n{resTimer}<SIZE=6.25>秒後に元に戻ります</SIZE>\r\n ");
			}
			for (int i = 0; i < 60; i++)
			{
				if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Backspace))
				{
					resTimer = 0;
				}
				yield return Dungeon.WaitUI(1);
			}
		}
		StartCoroutine(hideBox(4));
		if (currState == State.Settings)
		{
			currMenu.GetComponent<SettingsMenu>().resButton.bg.sprite = Dungeon.Instance.currentLocale.resolutionText[original];
			currMenu.GetComponent<SettingsMenu>().BounceButton(currMenu.GetComponent<SettingsMenu>().resButton, 2, silent: true);
		}
		dungeon.saveData.videoPrefs.resolution = original;
		Dungeon.Instance.saveManager.SetScreen();
		Dungeon.Instance.saveManager.SaveGame();
		reverter = null;
		resTimer = 0;
	}

	public void ShowLangButtons()
	{
		if (!showingLang)
		{
			showingLang = true;
			StartCoroutine(langshower());
		}
	}

	private IEnumerator langshower()
	{
		UIButton[] array = langButtons;
		foreach (UIButton uIButton in array)
		{
			uIButton.hitbox.enabled = true;
			dungeon.animationManager.LerpZoom(uIButton.gameObject, Vector3.one, 6f, 0.1f, destroy: false, UI: true);
		}
		yield return Dungeon.WaitUI(8);
		while (!Input.GetMouseButtonUp(0) && !Input.GetMouseButtonUp(1) && !Input.GetMouseButtonUp(2))
		{
			yield return Dungeon.WaitUI(1);
		}
		array = langButtons;
		foreach (UIButton uIButton2 in array)
		{
			uIButton2.hitbox.enabled = false;
			dungeon.animationManager.LerpZoom(uIButton2.gameObject, Vector3.zero, 6f, 0f, destroy: false, UI: true);
		}
		yield return Dungeon.WaitUI(6);
		showingLang = false;
	}
}
