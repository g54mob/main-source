using UnityEngine;

public class TempleNPC : Decoration
{
	public enum State
	{
		Waiting = 0,
		StopSweeping = 1,
		Hello = 2,
		HelloOut = 3,
		WorryNot = 4,
		VestMask = 5,
		YouShouldWear = 6,
		PreTravelPause = 7,
		ThoughtsOfTravel = 8,
		ChantYesNo = 9,
		MuchToClean = 10,
		ClearsThroat = 11,
		PoemLeadUsToNewWorld = 12,
		PoemRaudrWillReturn = 13,
		PoemRaudrWail = 14,
		PoemTremble = 15,
		PoemStreamOfSilent = 16,
		PoemBrightGreen = 17,
		PoemAcropolisFall = 18,
		PoemGreatBattle = 19,
		PoemSwallowBattle = 20,
		PoemSwallowMoons = 21,
		PoemANewWorld = 22,
		PoemOhGreatNagaraja = 23,
		PoemDone = 24,
		SeeTheSacrifice = 25,
		ResumesSweeping = 26,
		Done = 27
	}

	private const int CHANT_AUTO_SKIP_DURATION = 154;

	public int heroApproachOffsetX = -5;

	public AsciiAnimation sweepingAnm;

	public AsciiAnimation sweepingWithMaskAnm;

	public AsciiAnimation stopSweepingAnm;

	public AsciiAnimation helloAnm;

	public AsciiAnimation helloOutAnm;

	public AsciiAnimation shhAnm;

	public AsciiAnimation vestingMaskAnm;

	public AsciiAnimation thoughtsAnm;

	public AsciiAnimation clearThroatAnm;

	public AsciiAnimation mopUpAnm;

	public AsciiAnimation mopDownAnm;

	public AsciiAnimation wailAnm;

	public AsciiAnimation rotatingAnm;

	public AsciiAnimation unionAnm;

	public AsciiAnimation smashAnm;

	public AsciiAnimation growAnm;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	private State currentState;

	private int stateElapsedTics;

	private AsciiAnimation currentAnim;

	private Sfx chantingSfx;

	public int bubbleOffsetX = -12;

	public int bubbleOffsetY = 3;

	private void SetState(State newState)
	{
		AsciiAnimation asciiAnimation = null;
		switch (newState)
		{
		case State.Waiting:
			asciiAnimation = sweepingAnm;
			break;
		case State.StopSweeping:
			asciiAnimation = stopSweepingAnm;
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			break;
		case State.Hello:
			StopHeroAI();
			asciiAnimation = helloAnm;
			SetupDialog("May [color=#00ffff]Nagaraja[/color] have us!");
			SfxController.singleton.Play("temple_npc_talk");
			break;
		case State.HelloOut:
			asciiAnimation = helloOutAnm;
			break;
		case State.WorryNot:
			asciiAnimation = shhAnm;
			SetupDialog("tid_sweeper_01");
			SfxController.singleton.Play("temple_npc_talk");
			break;
		case State.VestMask:
			asciiAnimation = vestingMaskAnm;
			break;
		case State.YouShouldWear:
			SetupDialog("You should wear your mask, or the guards may think of you an intruder.");
			SfxController.singleton.Play("temple_npc_talk");
			break;
		case State.ThoughtsOfTravel:
			asciiAnimation = thoughtsAnm;
			SetupDialog("Thoughts of travel remind me of [color=#00ffff]The Great Feast[/color]. Would you like to chant it with me?");
			SfxController.singleton.Play("temple_npc_talk");
			break;
		case State.ChantYesNo:
			RegisterDialogCallbacks();
			GameStates.Singleton.ShowPlayChoiceDialog("", "Yes", "No", KeyCode.Y, KeyCode.N);
			SfxController.singleton.Play("prompt_choice");
			break;
		case State.MuchToClean:
			asciiAnimation = sweepingWithMaskAnm;
			SetupDialog("I still have much to clean.");
			SfxController.singleton.Play("temple_npc_talk");
			break;
		case State.ClearsThroat:
			asciiAnimation = clearThroatAnm;
			dialogBubble.Hide();
			break;
		case State.PoemLeadUsToNewWorld:
			asciiAnimation = mopUpAnm;
			SetupDialog("♪ Nagaraja, the supreme serpent will lead us into a new world ♫");
			chantingSfx = SfxController.singleton.Play("temple_npc_chant");
			break;
		case State.PoemRaudrWillReturn:
			asciiAnimation = mopDownAnm;
			SetupDialog("♪ For [color=#ff0000]Raudr[/color] will return and see all the errors done in his stead ♫");
			break;
		case State.PoemRaudrWail:
			asciiAnimation = wailAnm;
			SetupDialog("♪ he will wail, a wail so loud and long that the world will tremble ♫");
			break;
		case State.PoemTremble:
			asciiAnimation = rotatingAnm;
			SetupDialog("♪ with the great tremble, the ground and sky will move ♫");
			break;
		case State.PoemStreamOfSilent:
			asciiAnimation = unionAnm;
			SetupDialog("♪ move, until the [color=#00ff00]Stream of the Silent[/color] unites with Deadwood River ♫");
			break;
		case State.PoemBrightGreen:
			SetupDialog("♪ in this union, all will turn a bright green ♫");
			break;
		case State.PoemAcropolisFall:
			asciiAnimation = smashAnm;
			SetupDialog("♪ from this green, Acropolis shall fall from the sky ♫");
			break;
		case State.PoemGreatBattle:
			asciiAnimation = mopUpAnm;
			SetupDialog("♪ upon this fall, acronians will see Raudr and fight a great battle ♫");
			break;
		case State.PoemSwallowBattle:
			asciiAnimation = wailAnm;
			SetupDialog("♪ those who battle, will be a feast for the supreme serpent ♫");
			break;
		case State.PoemSwallowMoons:
			asciiAnimation = growAnm;
			SetupDialog("♪ with this feast, Nagaraja will grow, and grow until it swallows the Moons! ♫");
			break;
		case State.PoemANewWorld:
			asciiAnimation = mopDownAnm;
			SetupDialog("♪ inside Nagaraja, a world will form anew. ♫");
			if (chantingSfx == null)
			{
				GameObject gameObject = GameObject.Find("sfx_temple_npc_chant(Clone)");
				if (gameObject != null)
				{
					chantingSfx = gameObject.GetComponent<Sfx>();
				}
			}
			if (chantingSfx != null && chantingSfx.currentSfx != null)
			{
				chantingSfx.currentSfx.loop = false;
			}
			break;
		case State.PoemOhGreatNagaraja:
			asciiAnimation = wailAnm;
			SetupDialog("♪ Oh great Nagaraja! We await The Great Feast! ♫");
			break;
		case State.PoemDone:
			asciiAnimation = mopDownAnm;
			if (chantingSfx != null)
			{
				chantingSfx.Stop();
			}
			break;
		case State.SeeTheSacrifice:
			asciiAnimation = thoughtsAnm;
			SetupDialog("There will be a sacrifice later. Maybe I'll see you there!");
			SfxController.singleton.Play("temple_npc_talk");
			break;
		case State.ResumesSweeping:
			asciiAnimation = sweepingWithMaskAnm;
			break;
		case State.Done:
			RestoreHeroAI();
			asciiAnimation = sweepingWithMaskAnm;
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			break;
		}
		if (asciiAnimation != null && currentAnim != asciiAnimation)
		{
			currentAnim = asciiAnimation;
			currentAnim.Stop();
			currentAnim.Play();
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (GameStates.Singleton.CurrentState == GameStates.State.PlayPaused)
		{
			return;
		}
		stateElapsedTics++;
		if (currentState == State.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.StopSweeping && stateElapsedTics >= 50)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.HelloOut && stateElapsedTics >= 6)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.VestMask && stateElapsedTics >= 45)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.PreTravelPause && stateElapsedTics >= 5)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.ThoughtsOfTravel && stateElapsedTics >= 5 && dialogBubble.npcDialogState == NPCDialogBubble.NPCDialogState.WaitingForSkip)
		{
			SetState(State.ChantYesNo);
		}
		else if (currentState == State.ClearsThroat)
		{
			if (stateElapsedTics == 20)
			{
				SfxController.singleton.Play("temple_npc_clear_throat");
			}
			else if (stateElapsedTics >= 60)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState >= State.PoemLeadUsToNewWorld && currentState < State.PoemOhGreatNagaraja && stateElapsedTics >= 154)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.PoemOhGreatNagaraja && stateElapsedTics >= 140 && (chantingSfx == null || chantingSfx.currentSfx == null || !chantingSfx.currentSfx.isPlaying))
		{
			SetState(State.SeeTheSacrifice);
		}
		else if (currentState == State.PoemDone && stateElapsedTics >= 40)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.ResumesSweeping && stateElapsedTics >= 6)
		{
			SetState(currentState + 1);
		}
		if (currentState >= State.Hello && currentState < State.Done)
		{
			dialogBubble.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (currentAnim != null && currentAnim.Sprite != null)
		{
			currentAnim.Sprite.Draw(r, offsetX, offsetY);
			if (currentState != State.Waiting && currentState != State.Done)
			{
				int screenX = base.MySprite.lastDrawX + mouthOffsetX;
				int screenY = base.MySprite.lastDrawY;
				dialogBubble.SetNPCMouthPosition(screenX, screenY);
				screenX = base.MySprite.lastDrawX + bubbleOffsetX;
				screenY = base.MySprite.lastDrawY + bubbleOffsetY;
				dialogBubble.Draw(r, screenX, screenY);
			}
		}
	}

	private void Update()
	{
		if (currentState > State.Waiting && currentState != State.Done && QuickCheats.SkipAheadKeyPressed())
		{
			SetState(State.Done);
		}
		if (MusicController.singleton.currentMusic != null)
		{
			float value = 0.8f;
			if (currentState >= State.StopSweeping && currentState <= State.SeeTheSacrifice)
			{
				value = 0.2f;
			}
			value = Mathf.Clamp(value, 0f, MusicController.singleton.volume);
			MusicController.singleton.currentMusic.targetVolume = value;
		}
	}

	private void SetupDialog(string message)
	{
		dialogBubble.PositionX = 0;
		dialogBubble.PositionY = 0;
		dialogBubble.SetMessage(Te.xt(message));
		dialogBubble.Show();
	}

	private void HandleDialogDone()
	{
		if (currentState == State.MuchToClean)
		{
			SetState(State.Done);
		}
		else if (currentState != State.ThoughtsOfTravel && currentState != State.ClearsThroat && (currentState < State.PoemLeadUsToNewWorld || currentState > State.PoemDone))
		{
			SetState(currentState + 1);
		}
	}

	private void HandleButton1(DialogButton btn)
	{
		UnregisterDialogCallbacks();
		GameStates.Singleton.SetState(GameStates.State.Playing);
		SetState(State.ClearsThroat);
	}

	private void HandleButton2(DialogButton btn)
	{
		UnregisterDialogCallbacks();
		GameStates.Singleton.SetState(GameStates.State.Playing);
		SetState(State.MuchToClean);
	}

	private void RegisterDialogCallbacks()
	{
		GameStates.Singleton.playChoiceDialog.button1.OnPressed += HandleButton1;
		GameStates.Singleton.playChoiceDialog.button2.OnPressed += HandleButton2;
	}

	private void UnregisterDialogCallbacks()
	{
		GameStates.Singleton.playChoiceDialog.button1.OnPressed -= HandleButton1;
		GameStates.Singleton.playChoiceDialog.button2.OnPressed -= HandleButton2;
	}

	private void StopHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
		GameStates.Singleton.hero.GetComponent<HeroAI>().enabled = false;
	}

	private void RestoreHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
	}

	protected override void Start()
	{
		base.Start();
		SfxController.singleton.Preload("temple_npc_chant");
		sweepingAnm.Sprite.Load();
		sweepingWithMaskAnm.Sprite.Load();
		stopSweepingAnm.Sprite.Load();
		helloAnm.Sprite.Load();
		helloOutAnm.Sprite.Load();
		shhAnm.Sprite.Load();
		vestingMaskAnm.Sprite.Load();
		thoughtsAnm.Sprite.Load();
		mopUpAnm.Sprite.Load();
		mopDownAnm.Sprite.Load();
		wailAnm.Sprite.Load();
		rotatingAnm.Sprite.Load();
		unionAnm.Sprite.Load();
		smashAnm.Sprite.Load();
		growAnm.Sprite.Load();
		SetState(State.Waiting);
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = Object.Instantiate(dialogBubblePrefab);
		dialogBubble.userTapSfx = "";
		dialogBubble.OnDone += HandleDialogDone;
	}

	private void OnDestroy()
	{
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogDone;
			Object.Destroy(dialogBubble.gameObject);
		}
	}
}
