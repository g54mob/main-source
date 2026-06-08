using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
	public enum State
	{
		Waiting = 0,
		IntroShopInterior = 1,
		IntroPileOfCloth = 2,
		SlideIn = 3,
		Greetings = 4,
		FingerUp = 5,
		SleeveSlide = 6,
		SpecialOfferBook = 7,
		SlideOut = 8,
		RewardSlideInWait = 9,
		RewardSlideIn = 10,
		RewardGrant = 11,
		RewardItemFound = 12,
		ExitRestock = 13,
		BigHeadSlideIn = 14,
		BigHead1 = 15,
		BigHead2 = 16,
		BigHead3 = 17,
		BigHead4 = 18,
		BigHead5 = 19,
		NoArmSlideOut = 20,
		StaffSlideOut = 21,
		GenericQueuedDialog = 22,
		PlayerChoiceButtons = 23,
		DoneIntro = 24,
		DoneReward = 25
	}

	public CreditsTextSlide introSlide;

	public AsciiAnimation slideInAnm;

	public AsciiAnimation greetingsAnm;

	public AsciiAnimation fingerUpAnm;

	public AsciiAnimation sleeveSlideAnm;

	public AsciiAnimation showBookAnm;

	public AsciiAnimation slideOutAnm;

	public AsciiAnimation giveBookAnm;

	public AsciiAnimation bookGivenAnm;

	public AsciiAnimation hideSleeveAnm;

	public AsciiAnimation hideArmUpAnm;

	public AsciiAnimation noArmSlideOutAnm;

	public AsciiAnimation showStaffAnm;

	public AsciiAnimation staffSlideOutAnm;

	public AsciiAnimation slideOutLeftAnm;

	public AsciiAnimation blank1SecAnm;

	public AsciiAnimation bfgShowAnm;

	public AsciiAnimation bfgIdleAnm;

	public AsciiAnimation bfgSleeveDropAnm;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public int joePosX;

	public int joePosY;

	public int dialogPosX;

	public int dialogPosY;

	public int dialogMouthPosX;

	public int dialogMouthPosY;

	private int stateElapsedTics;

	private AsciiAnimation currentAnimation;

	private bool isDialogActive;

	private NPCDialogSequence dialogSequence = new NPCDialogSequence();

	private bool isPlayerChoiceScheduled;

	private Sfx currentSfx;

	public State currentState { get; private set; }

	public void ActivateIntro()
	{
		ShowModalFade(jumpToTargetOpacity: true);
		SetState(State.Waiting);
	}

	public void ActivateReward()
	{
		ShowModalFade(jumpToTargetOpacity: false);
		SetState(State.RewardSlideInWait);
	}

	public void ActivateBigHead()
	{
		ShowModalFade(jumpToTargetOpacity: true);
		SetState(State.BigHeadSlideIn);
	}

	public void ActivateLoyalCustomer()
	{
		ShowModalFade(jumpToTargetOpacity: false);
		dialogSequence.Clear();
		dialogSequence.Add(slideInAnm);
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_14");
		dialogSequence.Add(greetingsAnm, "hans_talk_intro", "tid_shopkeeper_15");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_16");
		dialogSequence.Add(fingerUpAnm, "hans_talk_reward", "tid_shopkeeper_17");
		dialogSequence.Add(hideArmUpAnm, "hans_talk_reward", "tid_shopkeeper_18");
		PlayDialogSequence();
	}

	public void ActivateGhostSlayer_Case1_Intro(int defeatedAntCount)
	{
		ShowModalFade(jumpToTargetOpacity: false);
		dialogSequence.Clear();
		dialogSequence.Add(slideInAnm);
		dialogSequence.Add("hans_talk_intro", string.Format(Te.xt("tid_shopkeeper_19"), HeroSettings.name));
		dialogSequence.Add("hans_talk_intro", string.Format(Te.xt("tid_shopkeeper_20"), defeatedAntCount));
		dialogSequence.Add(greetingsAnm, "hans_talk_intro", "tid_shopkeeper_21");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_22");
		dialogSequence.Add(fingerUpAnm, "hans_talk_intro", "tid_shopkeeper_23");
		dialogSequence.Add(hideArmUpAnm, "hans_talk_intro", "tid_shopkeeper_24");
		dialogSequence.Add(showStaffAnm, "hans_talk_intro", "tid_shopkeeper_25");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_26", delegate
		{
			SchedulePlayerChoice("", "tid_shopkeeper_27", KeyCode.Return);
		});
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_28");
		PlayDialogSequence();
	}

	public void ActivateGhostSlayer_Case2_Reminder()
	{
		ShowModalFade(jumpToTargetOpacity: false);
		dialogSequence.Clear();
		dialogSequence.Add(slideInAnm);
		dialogSequence.Add("hans_talk_intro", string.Format(Te.xt("tid_shopkeeper_29"), HeroSettings.name));
		dialogSequence.Add(greetingsAnm, "hans_talk_intro", "tid_shopkeeper_30");
		dialogSequence.Add(fingerUpAnm, "hans_talk_intro", "tid_shopkeeper_31");
		dialogSequence.Add(sleeveSlideAnm, "hans_talk_intro", "tid_shopkeeper_32");
		dialogSequence.Add(hideSleeveAnm, "hans_talk_intro", "tid_shopkeeper_33");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_34");
		dialogSequence.Add(showStaffAnm, "hans_talk_intro", "tid_shopkeeper_35");
		PlayDialogSequence();
	}

	public void ActivateGhostSlayer_Case3_SkippedCases1n2()
	{
		ShowModalFade(jumpToTargetOpacity: false);
		dialogSequence.Clear();
		dialogSequence.Add(slideInAnm);
		dialogSequence.Add("hans_talk_intro", string.Format(Te.xt("tid_shopkeeper_19"), HeroSettings.name));
		dialogSequence.Add(greetingsAnm, "hans_talk_intro", "tid_shopkeeper_30");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_22");
		dialogSequence.Add(fingerUpAnm, "hans_talk_intro", "tid_shopkeeper_34");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_23");
		dialogSequence.Add(hideArmUpAnm, "hans_talk_intro", "tid_shopkeeper_24");
		dialogSequence.Add(showStaffAnm, "hans_talk_intro", "tid_shopkeeper_25");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_26", delegate
		{
			SchedulePlayerChoice("", "tid_shopkeeper_27", KeyCode.Return);
		});
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_28");
		PlayDialogSequence();
	}

	public void ActivateTitanicBundle_Intro()
	{
		ShowModalFade(jumpToTargetOpacity: false);
		dialogSequence.Clear();
		dialogSequence.Add(slideInAnm);
		dialogSequence.Add(greetingsAnm, "hans_talk_intro", string.Format(Te.xt("tid_shopkeeper_36"), HeroSettings.name));
		dialogSequence.Add(fingerUpAnm, "hans_talk_intro", "tid_shopkeeper_37");
		dialogSequence.Add(hideArmUpAnm, "hans_talk_intro", "tid_shopkeeper_38");
		dialogSequence.Add(slideOutLeftAnm);
		dialogSequence.Add(blank1SecAnm);
		dialogSequence.Add(bfgShowAnm);
		dialogSequence.Add(bfgIdleAnm, null, null, delegate
		{
			dialogBubble.PositionY--;
		});
		if (Inventory.Singleton.HasItemById("blade_of_god"))
		{
			dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_39");
			dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_40");
		}
		else
		{
			dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_41");
		}
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_42");
		dialogSequence.Add("hans_talk_intro", string.Format(Te.xt("tid_shopkeeper_43"), HeroSettings.name));
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_44", delegate
		{
			SchedulePlayerChoice("", "tid_shopkeeper_45", KeyCode.Return);
		});
		dialogSequence.Add(bfgSleeveDropAnm);
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_46");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_47");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_48");
		dialogSequence.Add("hans_talk_intro", "tid_shopkeeper_49");
		PlayDialogSequence();
	}

	private void SchedulePlayerChoice(string dialogText, string buttonLabel, KeyCode keyCodeForButton)
	{
		GameStates.Singleton.playChoiceDialog.SetupText(dialogText, buttonLabel, keyCodeForButton);
		GameStates.Singleton.playChoiceDialog.buttonSingle.OnPressed += HandlePlayerChoicePressed;
		isPlayerChoiceScheduled = true;
	}

	private void HandlePlayerChoicePressed(DialogButton btn)
	{
		btn.OnPressed -= HandlePlayerChoicePressed;
		if (dialogBubble.npcDialogState == NPCDialogBubble.NPCDialogState.WaitingForSkip)
		{
			dialogBubble.Hide();
		}
		currentState = State.GenericQueuedDialog;
	}

	private void PlayDialogSequence()
	{
		SetState(State.GenericQueuedDialog);
	}

	private void NextStepGenericQueue()
	{
		if (dialogSequence.Count > 0)
		{
			SetState(State.GenericQueuedDialog);
		}
		else if (currentAnimation == showBookAnm)
		{
			SetState(State.SlideOut);
		}
		else if (currentAnimation == showStaffAnm)
		{
			SetState(State.StaffSlideOut);
		}
		else
		{
			SetState(State.NoArmSlideOut);
		}
	}

	private void SetState(State newState)
	{
		AsciiAnimation asciiAnimation = null;
		switch (newState)
		{
		case State.IntroShopInterior:
			SetupIntroSlide("Piles of weapons line the mushroom house's circular walls. A fireplace of whimsical flames lights the interior.");
			break;
		case State.IntroPileOfCloth:
			SetupIntroSlide("A mess of old cloth, distinctly centered on the room's floor, slowly erects into a tall, hollow figure.\n\nIt rushes towards you.");
			break;
		case State.SlideIn:
			asciiAnimation = slideInAnm;
			MusicController.singleton.Play("shop");
			break;
		case State.Greetings:
			asciiAnimation = greetingsAnm;
			SetupDialog(Te.xt("tid_shopkeeper_02"));
			PlaySFX("hans_talk_intro");
			break;
		case State.FingerUp:
			asciiAnimation = fingerUpAnm;
			SetupDialog(Te.xt("If you're looking für [color=#00ffff]loot[/color], you've come to the right place."));
			PlaySFX("hans_talk_intro");
			break;
		case State.SleeveSlide:
			asciiAnimation = sleeveSlideAnm;
			SetupDialog(Te.xt("The Mushroom Forest is dangerous, full of mindless [color=#00ffff]Vigor[/color] foes. Best to gear up."));
			PlaySFX("hans_talk_intro");
			break;
		case State.SpecialOfferBook:
			asciiAnimation = showBookAnm;
			SetupDialog(Te.xt("Für meine new customers, with the purchase of any two items you get this free [color=#00ffff]Crafting Booklet[/color]."));
			PlaySFX("hans_talk_intro");
			break;
		case State.SlideOut:
			asciiAnimation = slideOutAnm;
			break;
		case State.RewardSlideIn:
			asciiAnimation = slideInAnm;
			SetupDialog(Te.xt("No purchase is the wrong purchase, but throw enough [color=#00ffff]Poison[/color] at a problem and it tends to go away. That's meine motto."));
			PlaySFX("hans_talk_reward");
			break;
		case State.RewardGrant:
			asciiAnimation = giveBookAnm;
			SetupDialog(Te.xt("Glückwunsch! Here is your 'free' Gift. I have scribed some crafting tips on the [color=#00ffff]final page[/color]."));
			PlaySFX("hans_talk_reward");
			break;
		case State.RewardItemFound:
		{
			asciiAnimation = currentAnimation;
			SfxController.singleton.Play("pickup_success");
			Item item = Inventory.Singleton.MakeReward("craft_book", 1);
			item = Inventory.Singleton.AddItem(item);
			SequentialPopupManager.singleton.ScheduleItemFound(item);
			SequentialPopupManager.singleton.itemFoundDialog.OnDone += HandleItemFoundDone;
			break;
		}
		case State.ExitRestock:
			asciiAnimation = bookGivenAnm;
			SetupDialog(Te.xt("I restock the shop [color=#00ffff]every day[/color]. So make sure to check back. Thank you für your business!"));
			PlaySFX("hans_talk_reward");
			break;
		case State.DoneReward:
			asciiAnimation = currentAnimation;
			break;
		case State.BigHeadSlideIn:
			asciiAnimation = slideInAnm;
			break;
		case State.BigHead1:
			asciiAnimation = currentAnimation;
			SetupDialog(Te.xt("You look different than the last time I saw you."));
			PlaySFX("hans_talk_intro");
			break;
		case State.BigHead2:
			asciiAnimation = greetingsAnm;
			SetupDialog(Te.xt("Don't take this the wrong way, but your head is quite big."));
			PlaySFX("hans_talk_intro");
			break;
		case State.BigHead3:
			asciiAnimation = fingerUpAnm;
			SetupDialog(Te.xt("Wunderbar! You've gathered all the [color=#00ffff]Soul Stones[/color]? Incredible!"));
			PlaySFX("hans_talk_intro");
			break;
		case State.BigHead4:
			asciiAnimation = hideArmUpAnm;
			SetupDialog(Te.xt("That explains the shortage of Bronze in Acropolis. Volks up there are agitated."));
			PlaySFX("hans_talk_reward");
			break;
		case State.BigHead5:
			asciiAnimation = currentAnimation;
			SetupDialog(Te.xt("Your secret is safe with me, but they will come looking sooner or later."));
			PlaySFX("hans_talk_reward");
			break;
		case State.NoArmSlideOut:
			asciiAnimation = noArmSlideOutAnm;
			break;
		case State.StaffSlideOut:
			asciiAnimation = staffSlideOutAnm;
			break;
		case State.GenericQueuedDialog:
		{
			NPCDialogSequence.StepReturnData stepReturnData = dialogSequence.Next();
			asciiAnimation = stepReturnData.animation;
			if (asciiAnimation == null)
			{
				asciiAnimation = currentAnimation;
			}
			string message = stepReturnData.message;
			if (message != null)
			{
				isDialogActive = true;
				SetupDialog(message);
			}
			else
			{
				isDialogActive = false;
			}
			break;
		}
		case State.PlayerChoiceButtons:
			asciiAnimation = currentAnimation;
			SfxController.singleton.Play("prompt_choice");
			GameStates.Singleton.playChoiceDialog.Show();
			break;
		}
		if (asciiAnimation != null && asciiAnimation != currentAnimation)
		{
			asciiAnimation.Stop();
			asciiAnimation.Play();
		}
		currentAnimation = asciiAnimation;
		currentState = newState;
		stateElapsedTics = 0;
	}

	public void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.Waiting && stateElapsedTics >= 7)
		{
			SetState(State.IntroShopInterior);
		}
		else if (currentState == State.IntroShopInterior || currentState == State.IntroPileOfCloth)
		{
			introSlide.UpdateTic();
			if (introSlide.IsDone())
			{
				SetState(currentState + 1);
			}
		}
		else if ((currentState == State.SlideIn || currentState == State.BigHeadSlideIn) && stateElapsedTics >= 20)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.SlideOut || currentState == State.NoArmSlideOut || currentState == State.StaffSlideOut)
		{
			if (stateElapsedTics == 10)
			{
				HideModalFade();
			}
			else if (stateElapsedTics >= 20)
			{
				SetState(State.DoneIntro);
			}
		}
		else if (currentState == State.RewardSlideInWait && stateElapsedTics >= 15)
		{
			SetState(State.RewardSlideIn);
		}
		if (currentState == State.GenericQueuedDialog)
		{
			if (isDialogActive)
			{
				dialogBubble.UpdateTic();
				if (isPlayerChoiceScheduled && dialogBubble.npcDialogState == NPCDialogBubble.NPCDialogState.WaitingForSkip)
				{
					isPlayerChoiceScheduled = false;
					SetState(State.PlayerChoiceButtons);
				}
			}
			else if (currentAnimation != null && !currentAnimation.Playing)
			{
				NextStepGenericQueue();
			}
		}
		else if (currentState == State.PlayerChoiceButtons)
		{
			GameStates.Singleton.playChoiceDialog.UpdateTic();
		}
		else if (currentState != State.Waiting && currentState != State.SlideIn && currentState != State.SlideOut && currentState != State.StaffSlideOut && currentState != State.DoneIntro && currentState != State.DoneReward && currentState != State.BigHeadSlideIn)
		{
			dialogBubble.UpdateTic();
		}
	}

	private void HandleDialogButtonDone()
	{
		if (currentState == State.GenericQueuedDialog)
		{
			NextStepGenericQueue();
		}
		else if (currentState == State.Greetings || currentState == State.FingerUp || currentState == State.SleeveSlide || currentState == State.SpecialOfferBook || currentState == State.RewardSlideIn || currentState == State.RewardGrant || (currentState >= State.BigHead1 && currentState <= State.BigHead5))
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.ExitRestock)
		{
			SetState(State.DoneReward);
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		ModalFade component = GetComponent<ModalFade>();
		if (component != null)
		{
			component.Draw(r);
		}
		if (currentState == State.IntroShopInterior || currentState == State.IntroPileOfCloth)
		{
			introSlide.Draw(r, r.width >> 1, r.height >> 1);
		}
		int num = r.width >> 1;
		int height = r.height;
		if (currentAnimation != null)
		{
			currentAnimation.Sprite.Draw(r, num + joePosX, height + joePosY);
		}
		if (currentState != State.Waiting && currentState != State.SlideIn && currentState != State.StaffSlideOut && currentState != State.DoneIntro)
		{
			dialogBubble.SetNPCMouthPosition(num + dialogMouthPosX, height + dialogMouthPosY);
			num = num - dialogBubble.Width / 2 + dialogPosX;
			height = height - dialogBubble.Height + dialogPosY;
			if (height < 1)
			{
				height = 1;
			}
			dialogBubble.Draw(r, num, height);
		}
		if (currentState == State.PlayerChoiceButtons)
		{
			GameStates.Singleton.playChoiceDialog.Draw(r, (r.width - 46) / 2, r.height);
		}
	}

	private void ShowModalFade(bool jumpToTargetOpacity)
	{
		ModalFade component = GetComponent<ModalFade>();
		if (component != null)
		{
			component.active = true;
			if (jumpToTargetOpacity)
			{
				component.JumpToTargetOpacity();
			}
		}
	}

	private void HandleItemFoundDone()
	{
		SequentialPopupManager.singleton.itemFoundDialog.OnDone -= HandleItemFoundDone;
		if (currentState == State.RewardItemFound)
		{
			SetState(State.ExitRestock);
		}
	}

	private void HideModalFade()
	{
		ModalFade component = GetComponent<ModalFade>();
		if (component != null)
		{
			component.active = false;
		}
	}

	private void SetupIntroSlide(string message)
	{
		message = Te.xt(message);
		introSlide.SetMessage(message);
	}

	private void SetupDialog(string message)
	{
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	private void PlaySFX(string sfxName)
	{
		if (currentSfx != null)
		{
			currentSfx.Stop();
		}
		currentSfx = SfxController.singleton.Play(sfxName);
	}

	protected void Awake()
	{
		dialogBubble = Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogButtonDone;
	}
}
