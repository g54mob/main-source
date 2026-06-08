using UnityEngine;

public class DysangelosEpilogue : Decoration, IPostAsciiRendererEffect
{
	private enum State
	{
		Waiting = 0,
		WhiteFadeBack = 1,
		FallingToGround = 2,
		ExperienceDialog = 3,
		TalkDenial = 4,
		TalkAnger = 5,
		ShowingMoondial = 6,
		TalkBargain = 7,
		DroppingMoondial = 8,
		Devolving = 9,
		TalkDepression = 10,
		TalkAcceptance = 11,
		TalkVisitMe = 12,
		WaitingForCredits = 13,
		TalkExpectingYouToEvolve = 14,
		HeroEvolves = 15,
		TalkReally = 16,
		TalkWow = 17,
		TalkNoFlying = 18,
		TalkDisturbance = 19,
		Completed = 20
	}

	private int heroApproachOffsetX = -24;

	private int heroAfterPickupOffsetX = -14;

	public AsciiAnimation returningStonesAnm;

	public AsciiAnimation fallingToGroundAnm;

	public AsciiAnimation showsMoondialAnm;

	public AsciiAnimation dropsMoondialAnm;

	public AsciiAnimation devolvingAnm;

	public AsciiAnimation devolvedIdleAnm;

	public AsciiAnimation bigHeadVfxAnm;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public string moondialDropPath;

	private int elapsedStateTics;

	private Weapon rememberWeaponLeft;

	private Weapon rememberWeaponRight;

	private int dropOffsetX = 4;

	private int dropTravelTics = 30;

	private float dropTravelX = -0.48f;

	private float whiteScreenPercent;

	private State currentState { get; set; }

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Waiting:
			GameStates.Singleton.level.preventLevelComplete++;
			break;
		case State.WhiteFadeBack:
			GameStates.Singleton.asciiRenderer.AddPostEffect(this);
			whiteScreenPercent = 1f;
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
			base.MySprite = returningStonesAnm.Sprite;
			returningStonesAnm.Play();
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			break;
		case State.FallingToGround:
			base.MySprite = fallingToGroundAnm.Sprite;
			fallingToGroundAnm.Play();
			break;
		case State.ExperienceDialog:
			GameStates.Singleton.level.XpEarned += 20;
			GameStates.Singleton.ScheduleXpDialog();
			break;
		case State.TalkDenial:
			SetupDialog("It's not possible!");
			SfxController.singleton.Play("epilogue_talk");
			MusicController.singleton.Play("rocky_plateau_epilogue");
			break;
		case State.TalkAnger:
			SetupDialog("Curse you! I give you the Sight Stone and these are your thanks?");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.ShowingMoondial:
			base.MySprite = showsMoondialAnm.Sprite;
			showsMoondialAnm.Play();
			break;
		case State.TalkBargain:
			SetupDialog("The Moondial is still bound to me. Please spare me, and I will gift it freely.");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.DroppingMoondial:
			base.MySprite = dropsMoondialAnm.Sprite;
			dropsMoondialAnm.Play();
			break;
		case State.Devolving:
			base.MySprite = devolvingAnm.Sprite;
			devolvingAnm.Play();
			SfxController.singleton.Play("epilogue_devolving");
			break;
		case State.TalkDepression:
			base.MySprite = devolvedIdleAnm.Sprite;
			devolvedIdleAnm.Play();
			SetupDialog("Why do I exist at all in such meager form? What's the point?");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.TalkAcceptance:
			SetupDialog("Take it, {0}. And do great things in my stead.", HeroSettings.name);
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.TalkVisitMe:
			SetupDialog("Perhaps you could visit me from time to time for a challenge. I would enjoy my greater form, if only for a moment.");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.WaitingForCredits:
			GameStates.Singleton.hero.RestoreAI();
			break;
		case State.TalkExpectingYouToEvolve:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroAfterPickupOffsetX, base.PositionZ);
			SetupDialog("I was expecting you to evolve, now that you have all the Soul Stones.");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.HeroEvolves:
			UnequipHero();
			bigHeadVfxAnm.Play();
			SfxController.singleton.Play("epilogue_player_evolves");
			GameStates.Singleton.HideMouse();
			break;
		case State.TalkReally:
			ReequipHero();
			GameStates.Singleton.ShowMouse();
			SetupDialog("Is that really your ultimate form?");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.TalkWow:
			SetupDialog("Wow... Ok.");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.TalkNoFlying:
			SetupDialog("You can't get to Acropolis without flying. And be warned...");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.TalkDisturbance:
			SetupDialog("We've caused quite a disturbance in the order of things.");
			SfxController.singleton.Play("epilogue_talk");
			break;
		case State.Completed:
			GameStates.Singleton.CompleteQuest();
			break;
		}
		currentState = newState;
		elapsedStateTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedStateTics++;
		if (currentState == State.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX - 5)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.WhiteFadeBack && elapsedStateTics >= 80)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.FallingToGround && elapsedStateTics >= 45)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.ExperienceDialog && elapsedStateTics >= 5)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.ShowingMoondial && elapsedStateTics >= 30)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.DroppingMoondial)
		{
			if (elapsedStateTics == 17)
			{
				DropMoondial();
			}
			else if (elapsedStateTics >= 60)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState == State.Devolving && elapsedStateTics >= 70)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.WaitingForCredits && GameStates.Singleton.previousState == GameStates.State.EpilogueCredits)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.HeroEvolves)
		{
			if (elapsedStateTics == 95)
			{
				EnableBigHead();
			}
			else if (elapsedStateTics >= 135)
			{
				SetState(currentState + 1);
			}
		}
		if (currentState == State.TalkDenial || currentState == State.TalkAnger || currentState == State.TalkBargain || currentState == State.TalkDepression || currentState == State.TalkAcceptance || currentState == State.TalkExpectingYouToEvolve || currentState == State.TalkReally || currentState == State.TalkWow || currentState == State.TalkNoFlying || currentState == State.TalkDisturbance || currentState == State.TalkVisitMe)
		{
			dialogBubble.UpdateTic();
		}
	}

	private void HandleDialogButtonDone()
	{
		SetState(currentState + 1);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (currentState == State.TalkDenial || currentState == State.TalkAnger || currentState == State.TalkBargain || currentState == State.TalkDepression || currentState == State.TalkAcceptance || currentState == State.TalkExpectingYouToEvolve || currentState == State.TalkReally || currentState == State.TalkWow || currentState == State.TalkNoFlying || currentState == State.TalkDisturbance || currentState == State.TalkVisitMe)
		{
			int num = fallingToGroundAnm.Sprite.lastDrawX + 6;
			int screenY = fallingToGroundAnm.Sprite.lastDrawY + 15;
			if (currentState >= State.TalkDepression)
			{
				num--;
			}
			dialogBubble.SetNPCMouthPosition(num, screenY);
			num = (r.width - dialogBubble.Width >> 1) - 9;
			screenY = base.lastDrawY - dialogBubble.Height - 13;
			dialogBubble.Draw(r, num, screenY);
		}
		if (currentState == State.HeroEvolves)
		{
			Hero hero = GameStates.Singleton.hero;
			bigHeadVfxAnm.Sprite.Draw(r, hero.lastDrawX, hero.lastDrawY);
		}
	}

	private void DropMoondial()
	{
		Character component = Utils.InstantiatePrefab(moondialDropPath).GetComponent<Character>();
		component.PositionX = base.PositionX + dropOffsetX;
		component.PositionY = base.PositionY;
		component.PositionZ = base.PositionZ;
		AsciiAnimation component2 = component.GetComponent<AsciiAnimation>();
		if (component2 != null)
		{
			component2.Stop();
			component2.Play();
		}
		DecorationTravelComponent decorationTravelComponent = component.gameObject.AddComponent<DecorationTravelComponent>();
		decorationTravelComponent.durationTics = dropTravelTics;
		decorationTravelComponent.velocityX = dropTravelX;
		GameStates.Singleton.level.AddCharacter(component);
	}

	private void EnableBigHead()
	{
		GameStates.Singleton.hero.GetComponentInChildren<BigHead>().Reset();
		HeroSettings.bigHeadEnabled = true;
	}

	private void UnequipHero()
	{
		Hero hero = GameStates.Singleton.hero;
		rememberWeaponLeft = hero.LeftHand;
		rememberWeaponRight = hero.RightHand;
		hero.LeftHand = null;
		hero.RightHand = null;
	}

	private void ReequipHero()
	{
		Hero hero = GameStates.Singleton.hero;
		if (rememberWeaponLeft != null)
		{
			hero.LeftHand = rememberWeaponLeft;
		}
		if (rememberWeaponRight != null)
		{
			hero.RightHand = rememberWeaponRight;
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		if (whiteScreenPercent <= 0f || GameStates.Singleton.CurrentState < GameStates.State.Playing)
		{
			r.RemovePostEffect(this);
			return;
		}
		Color offWhite = ColorConstants.offWhite;
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				Color foreground = cell.GetForeground();
				cell.SetForeground(Color.Lerp(foreground, offWhite, whiteScreenPercent));
				Color background = cell.GetBackground();
				cell.SetBackground(Color.Lerp(background, offWhite, whiteScreenPercent));
			}
		}
	}

	private void Update()
	{
		whiteScreenPercent -= Time.deltaTime * 1f;
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
		dialogBubble.PositionX = 20;
		dialogBubble.PositionY = 8;
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	public override void Init()
	{
		base.Init();
		SetState(State.Waiting);
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogButtonDone;
		Utils.PreloadAsyncPrefab(moondialDropPath);
	}

	protected void OnDestroy()
	{
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogButtonDone;
			Object.Destroy(dialogBubble.gameObject);
		}
	}
}
