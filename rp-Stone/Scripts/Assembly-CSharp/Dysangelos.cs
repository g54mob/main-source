using UnityEngine;

public class Dysangelos : Decoration, IPostAsciiRendererEffect
{
	private enum State
	{
		Waiting = 0,
		Approach = 1,
		PreEnterSmallPause = 2,
		DysangelosEnter = 3,
		PostEnterSmallPause = 4,
		Sightstone = 5,
		TalkIntro1 = 6,
		TalkIntroName = 7,
		NameInput = 8,
		TalkIntro2 = 9,
		TalkIntro3 = 10,
		TalkIntro4 = 11,
		TalkIntro5a = 12,
		TalkIntro5b = 13,
		TalkIntro5c = 14,
		TalkIntro5d = 15,
		TalkIntro6 = 16,
		TalkIntro7 = 17,
		TalkIntro8 = 18,
		TalkIntro9 = 19,
		TalkIntro10 = 20,
		Tip1 = 21,
		TipYesNo = 22,
		Tip2 = 23,
		Done = 24
	}

	private const string INTRO_COMPLETE_FLAG = "dysangelos_intro_complete";

	private int heroApproachOffsetX = -15;

	private int heroApproachOffsetZ = 6;

	public AsciiAnimation dysangelosEnterAnm;

	public AsciiAnimation dysangelosIdleAnm;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public NameInputDialog nameInputDialogPrefab;

	private NameInputDialog nameInputDialog;

	private State previousState;

	private State currentState;

	private int stateElapsedTics;

	private static int debugTipIndex;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Approach:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ + heroApproachOffsetZ);
			break;
		case State.PreEnterSmallPause:
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			break;
		case State.DysangelosEnter:
			if (!ProgressFlags.GetFlag("dysangelos_intro_complete"))
			{
				SfxController.singleton.Play("prompt_choice", ignoreDuplicateSfxInSameFrame: true, 0.2f);
			}
			dysangelosEnterAnm.Play();
			break;
		case State.PostEnterSmallPause:
			MusicController.singleton.Play("rocky_plateau_talk");
			break;
		case State.Sightstone:
			GetEquippedSightstone().Attack(this);
			break;
		case State.TalkIntro1:
			dysangelosIdleAnm.Stop();
			dysangelosIdleAnm.Play();
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			SetupDialog("Greetings simple one. I am [color=#00ffff]Dysangelos[/color], the Bearer of Bad News, Messenger of [color=#00ffff]Acropolis[/color].");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntroName:
			SetupDialog("What is your name?");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.NameInput:
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			nameInputDialog.Show();
			break;
		case State.TalkIntro2:
			SetupDialog("{0}, I bear an important message.\n\nYou may have noticed, you are not quite alive.", HeroSettings.name);
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro3:
			SetupDialog("Sins of past devolved you into mineral form. However, the [color=#00ffff]Sight Stone[/color] awakened you once more.");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro4:
			SetupDialog("The Sight Stone is one of [color=#00ffff]nine Soulstones[/color], each with unique powers.");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro5a:
			SetupDialog("I can see you have also found the\n[color=#00ffff]Star Stone[/color].");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro5b:
			SetupDialog("I can see you have also found the [color=#00ffff]Star Stone[/color] and the [color=#00ffff]Ki Stone[/color].");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro5c:
			SetupDialog("tid_dysangelos_10");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro5d:
			SetupDialog("tid_dysangelos_11");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro6:
			SetupDialog("This world exists in perpetual darkness. But it was not always this way.");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro7:
			SetupDialog("Ages ago, evil took hold of the Soulstones and plunged us into nether.");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro8:
			SetupDialog("Light may once again shine upon us, if all nine Soulstones are reunited.");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro9:
			SetupDialog("It seems the Sight Stone has chosen you for this quest.");
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.TalkIntro10:
			SetupDialog("{0}, you must unite all nine Soulstones.\n\nIf you need guidance, come see me at any time.", HeroSettings.name);
			SfxController.singleton.Play("dysangelos_intro_talk");
			break;
		case State.Tip1:
			SetupDialog("Greetings {0}.\n\nDo you need some guidance?", HeroSettings.name);
			SfxController.singleton.Play("dysangelos_guidance");
			break;
		case State.TipYesNo:
			RegisterDialogCallbacks();
			GameStates.Singleton.ShowPlayChoiceDialog("", "Yes", "No", KeyCode.Y, KeyCode.N);
			break;
		case State.Tip2:
			SetupDialog(GetTip());
			AchievementController.singleton.ReportDysangelosHelped();
			break;
		case State.Done:
		{
			ProgressFlags.SetFlag("dysangelos_intro_complete");
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			Data.Quest questData = GameStates.Singleton.level.QuestData;
			if (QuestController.singleton.GetStarDifficultyForQuest(questData.id) <= 2)
			{
				GameStates.Singleton.CompleteQuest();
			}
			else
			{
				GameStates.Singleton.EndQuest();
			}
			break;
		}
		}
		previousState = currentState;
		currentState = newState;
		stateElapsedTics = 0;
	}

	private string GetTip()
	{
		if (!QuestController.singleton.IsAvailable("anvil") || DebugTip(0))
		{
			SfxController.singleton.Play("dysangelos_guidance_1");
			return "You will need an Anvil in your quest. Find the missing [color=#00ffff]chunks of metal[/color].";
		}
		if (!Inventory.Singleton.HasItemById("xi_stone") || DebugTip(1))
		{
			SfxController.singleton.Play("dysangelos_guidance_2");
			return "tid_dysangelos_19";
		}
		if (!Inventory.Singleton.HasItemById("xp_stone") || DebugTip(2))
		{
			SfxController.singleton.Play("dysangelos_guidance_3");
			return "tid_dysangelos_20";
		}
		if (!Inventory.Singleton.HasItemById("grappling_hook") || DebugTip(3))
		{
			SfxController.singleton.Play("dysangelos_guidance_1");
			return Te.xt("tid_dysangelos_21") + " " + Te.xt("tid_dysangelos_21a");
		}
		if (!QuestController.singleton.IsAvailable("fungus_forest") || DebugTip(3))
		{
			SfxController.singleton.Play("dysangelos_guidance_1");
			return Te.xt("tid_dysangelos_21") + " " + Te.xt("tid_dysangelos_21b");
		}
		if (!Inventory.Singleton.HasItemById("quest_stone") || DebugTip(4))
		{
			SfxController.singleton.Play("dysangelos_guidance_2");
			return Te.xt("tid_dysangelos_22");
		}
		if (!Inventory.Singleton.HasItemById("bronze_key") || DebugTip(5))
		{
			SfxController.singleton.Play("dysangelos_guidance_3");
			return Te.xt("tid_dysangelos_23") + " " + Te.xt("tid_dysangelos_23b");
		}
		if (!Inventory.Singleton.HasItemById("fissure_stone") || DebugTip(6))
		{
			SfxController.singleton.Play("dysangelos_guidance_1");
			return Te.xt("tid_dysangelos_24") + " " + Te.xt("tid_dysangelos_23b");
		}
		if (!Inventory.Singleton.HasItemById("triskelion_stone") || DebugTip(7))
		{
			SfxController.singleton.Play("dysangelos_guidance_2");
			return "Atop the [color=#00ffff]Icy Ridge[/color] lies the giant Hrímnir in a permafrost prison. Free him and retrieve the [color=#00ffff]Triskelion[/color].";
		}
		if (!QuestController.singleton.IsAvailable("cross_bridge") || DebugTip(8))
		{
			SfxController.singleton.Play("dysangelos_guidance_3");
			return "The [color=#00ffff]Mountaintop Bridge[/color] has been destroyed for some time. You must repair it.";
		}
		if (!QuestController.singleton.IsAvailable("temple") || DebugTip(9))
		{
			SfxController.singleton.Play("dysangelos_guidance_1");
			return "You fix the Bridge and then you don't cross it. Why do you waste my time this way?";
		}
		if (!Inventory.Singleton.HasItemById("mind_stone") || DebugTip(10))
		{
			SfxController.singleton.Play("dysangelos_guidance_2");
			return "tid_dysangelos_26";
		}
		SfxController.singleton.Play("dysangelos_guidance_3");
		return "Perhaps you will find your way up to [color=#00ffff]Acropolis[/color].";
	}

	private bool DebugTip(int compareIndex)
	{
		if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Y) && debugTipIndex == compareIndex)
		{
			debugTipIndex++;
			return true;
		}
		return false;
	}

	private void Update()
	{
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (GameStates.Singleton.CurrentState == GameStates.State.PlayPaused)
		{
			return;
		}
		stateElapsedTics++;
		if (currentState == State.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX - 15)
		{
			SetState(State.Approach);
		}
		else if (currentState == State.Approach && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
		{
			SetState(State.PreEnterSmallPause);
		}
		else if (currentState == State.PreEnterSmallPause && stateElapsedTics >= 20)
		{
			SetState(State.DysangelosEnter);
		}
		else if (currentState == State.DysangelosEnter && !dysangelosEnterAnm.Playing)
		{
			if (IsSightstoneEquipped() && GetEquippedSightstone().CanAttack(this))
			{
				SetState(State.Sightstone);
			}
			else
			{
				SetState(State.PostEnterSmallPause);
			}
		}
		else if (currentState == State.Sightstone && stateElapsedTics >= 30)
		{
			if (previousState == State.Done)
			{
				SetState(State.Done);
			}
			else
			{
				SetState(State.PostEnterSmallPause);
				stateElapsedTics = 30;
			}
		}
		else if (currentState == State.PostEnterSmallPause && stateElapsedTics >= 30)
		{
			if (ProgressFlags.GetFlag("dysangelos_intro_complete"))
			{
				SetState(State.Tip1);
			}
			else
			{
				SetState(State.TalkIntro1);
			}
		}
		else if (currentState == State.NameInput || currentState == State.TalkIntro2)
		{
			nameInputDialog.UpdateTic();
		}
		else if (currentState == State.Tip1 && dialogBubble.npcDialogState == NPCDialogBubble.NPCDialogState.WaitingForSkip)
		{
			SetState(State.TipYesNo);
		}
		if (currentState >= State.TalkIntro1 && currentState < State.Done)
		{
			dialogBubble.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (currentState == State.DysangelosEnter)
		{
			dysangelosEnterAnm.Sprite.Draw(r, offsetX, offsetY);
		}
		else if (currentState >= State.PostEnterSmallPause)
		{
			dysangelosIdleAnm.Sprite.Draw(r, offsetX, offsetY);
		}
		if (currentState >= State.TalkIntro1)
		{
			dialogBubble.SetNPCMouthPosition(dysangelosIdleAnm.Sprite.lastDrawX + 1, dysangelosIdleAnm.Sprite.lastDrawY);
			int offsetX2 = (r.width - dialogBubble.Width >> 1) - 9;
			int offsetY2 = base.lastDrawY - dialogBubble.Height / 2 - 8;
			dialogBubble.Draw(r, offsetX2, offsetY2);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if (currentState == State.NameInput || currentState == State.TalkIntro2)
		{
			nameInputDialog.Draw(r, r.width / 2, r.height / 2);
		}
		else
		{
			r.RemovePostEffect(this);
		}
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

	private bool IsSightstoneEquipped()
	{
		Hero hero = GameStates.Singleton.hero;
		if (!(hero.RightHand != null) || !(hero.RightHand.id == "sight_stone"))
		{
			if (hero.LeftHand != null)
			{
				return hero.LeftHand.id == "sight_stone";
			}
			return false;
		}
		return true;
	}

	private Weapon GetEquippedSightstone()
	{
		Weapon weapon = GameStates.Singleton.hero.LeftHand;
		if (weapon == null || weapon.id != "sight_stone")
		{
			weapon = GameStates.Singleton.hero.RightHand;
		}
		if (weapon != null && weapon.id != "sight_stone")
		{
			return null;
		}
		return weapon;
	}

	private void SetupDialog(string message)
	{
		_SetupDialog(Te.xt(message));
	}

	private void SetupDialog(string message, string param)
	{
		_SetupDialog(string.Format(Te.xt(message), param));
	}

	private void _SetupDialog(string message)
	{
		dialogBubble.PositionX = 19;
		dialogBubble.PositionY = 14;
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	private void HandleDialogButtonDone()
	{
		if (currentState == State.TalkIntro4)
		{
			if (XPController.singleton.HasXpStone())
			{
				if (Inventory.Singleton.HasItemById("xi_stone"))
				{
					SetState(State.TalkIntro5d);
				}
				else
				{
					SetState(State.TalkIntro5c);
				}
			}
			else if (Inventory.Singleton.HasItemById("xi_stone"))
			{
				SetState(State.TalkIntro5b);
			}
			else if (Inventory.Singleton.HasItemById("star_stone"))
			{
				SetState(State.TalkIntro5a);
			}
			else
			{
				SetState(State.TalkIntro6);
			}
		}
		else if (currentState == State.TalkIntro5a || currentState == State.TalkIntro5b || currentState == State.TalkIntro5c || currentState == State.TalkIntro5d)
		{
			SetState(State.TalkIntro6);
		}
		else if (currentState == State.TalkIntro10)
		{
			SetState(State.Done);
		}
		else if (currentState != State.Tip1)
		{
			if (currentState == State.Tip2)
			{
				SetState(State.Done);
			}
			else
			{
				SetState(currentState + 1);
			}
		}
	}

	private void HandleNameInputComplete(string value)
	{
		if (currentState == State.NameInput)
		{
			HeroSettings.name = value;
			SetState(State.TalkIntro2);
		}
	}

	private void HandleButton1(DialogButton btn)
	{
		UnregisterDialogCallbacks();
		GameStates.Singleton.SetState(GameStates.State.Playing);
		GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
		SetState(State.Tip2);
	}

	private void HandleButton2(DialogButton btn)
	{
		UnregisterDialogCallbacks();
		GameStates.Singleton.SetState(GameStates.State.Playing);
		GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
		SetState(State.Done);
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

	protected override void Start()
	{
		base.Start();
		SetState(State.Waiting);
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogButtonDone;
		nameInputDialog = Object.Instantiate(nameInputDialogPrefab);
		nameInputDialog.OnComplete += HandleNameInputComplete;
	}

	private void OnDestroy()
	{
		UnregisterDialogCallbacks();
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogButtonDone;
			Object.Destroy(dialogBubble.gameObject);
		}
	}
}
