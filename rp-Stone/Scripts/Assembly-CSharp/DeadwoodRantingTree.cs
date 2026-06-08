using System;
using System.Collections.Generic;
using UnityEngine;

public class DeadwoodRantingTree : Decoration
{
	private enum State
	{
		Waiting = 0,
		IntroApproach = 1,
		IntroSmallPause = 2,
		IntroApproach2 = 3,
		ApproachHatchet = 4,
		ApproachSightstone = 5,
		Intro1 = 6,
		Intro2 = 7,
		Revisit1 = 8,
		Revisit2 = 9,
		Hatchet1 = 10,
		Hatchet2 = 11,
		HatchetCanceled = 12,
		SightstoneAnimation = 13,
		Sightstone1 = 14,
		Sightstone2 = 15,
		SightstonePassing1 = 16,
		SightstonePassing2 = 17,
		Exiting = 18,
		Scripted = 19
	}

	private enum Expression
	{
		Sleeping = 0,
		Angry = 1,
		Aloof = 2,
		Pain = 3,
		Surprised = 4,
		Suspicious = 5
	}

	public float camShakeAmount = 3f;

	public float camShakeDuration = 0.15f;

	public int heroApproachOffsetX = -10;

	public int heroHaltOffsetX = 2;

	public int heroSightstonePassingOffsetX = 4;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	private State currentState;

	private State previousState;

	private int stateElapsedTics;

	public AsciiSprite sleepingFace;

	public AsciiSprite angryFace;

	public AsciiSprite aloofFace;

	public AsciiSprite painFace;

	public AsciiSprite surprisedFace;

	public AsciiSprite suspiciousFace;

	public AsciiSprite lookRightFace;

	public AsciiSprite mouthAnm;

	public AsciiSprite leftHand;

	public AsciiSprite rightHandHalt;

	public AsciiSprite rightHandWave;

	private AsciiSprite currentFace;

	private bool suspiciousLook;

	[StonescriptNativeProperty]
	public int LastDrawX => base.lastDrawX;

	[StonescriptNativeProperty]
	public int LastDrawY => base.lastDrawY;

	[StonescriptNativeMethod]
	public object SetFace(List<object> parameters, InvocationContext ctx)
	{
		switch (parameters[0] as string)
		{
		case "sleeping":
			currentFace = sleepingFace;
			break;
		case "angry":
			currentFace = angryFace;
			break;
		case "aloof":
			currentFace = aloofFace;
			break;
		case "pain":
			currentFace = painFace;
			break;
		case "surprised":
			currentFace = surprisedFace;
			break;
		case "suspicious":
			currentFace = suspiciousFace;
			break;
		case "lookRight":
			currentFace = lookRightFace;
			break;
		}
		return null;
	}

	[StonescriptNativeMethod]
	public object SetState(List<object> parameters, InvocationContext ctx)
	{
		string value = parameters[0] as string;
		State state = (State)Enum.Parse(typeof(State), value);
		SetState(state);
		return null;
	}

	private void SetState(State newState)
	{
		if (newState == State.IntroApproach || newState == State.IntroSmallPause || newState == State.IntroApproach2 || newState == State.ApproachHatchet || newState == State.ApproachSightstone || newState == State.Intro1 || newState == State.Intro2 || newState == State.Revisit1 || newState == State.Revisit2 || newState == State.HatchetCanceled || newState == State.SightstoneAnimation || newState == State.Sightstone1 || newState == State.Sightstone2 || (previousState >= State.Hatchet1 && previousState <= State.HatchetCanceled && newState == State.Exiting && IsSightstoneEquipped()))
		{
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
		}
		else if (newState != State.Waiting && ProgressFlags.GetFlag("deadwood_valley_1"))
		{
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
		}
		switch (newState)
		{
		case State.Waiting:
			SetExpression(Expression.Sleeping);
			break;
		case State.IntroApproach:
			AnalyticsMacros.ApproachedGilbert();
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
			break;
		case State.IntroSmallPause:
			StopHeroAI();
			GameStates.Singleton.hero.SetState(Hero.State.Idle);
			break;
		case State.IntroApproach2:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroHaltOffsetX, base.PositionZ + 1);
			break;
		case State.ApproachHatchet:
			RestoreHeroAI();
			break;
		case State.ApproachSightstone:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
			break;
		case State.Intro1:
			SetupDialog("\nHalt!\n");
			SetExpression(Expression.Angry);
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ + 1);
			CameraShake.singleton.ShakeCamera(camShakeAmount, camShakeDuration);
			SfxController.singleton.Play("ranting_tree_halt");
			SfxController.singleton.Play("ranting_tree_talk_halt");
			rightHandHalt.GetComponentInChildren<AsciiAnimation>().Play();
			break;
		case State.Intro2:
			SetupDialog("Return whence you came, or jump in the water. I care not which.");
			SfxController.singleton.Play("ranting_tree_talk_very_well");
			break;
		case State.Revisit1:
			SetupDialog("You again? Begone!");
			SetExpression(Expression.Angry);
			SfxController.singleton.Play("ranting_tree_talk_again");
			break;
		case State.Revisit2:
			SetupDialog("Xyloalgia does not wish botheration from Acronian rejects.");
			SetExpression(Expression.Aloof);
			SfxController.singleton.Play("ranting_tree_talk_extra");
			break;
		case State.Hatchet1:
			SetupDialog("Ahg! How dare you unmake me!");
			SetExpression(Expression.Pain);
			SfxController.singleton.Play("ranting_tree_talk_how_dare");
			break;
		case State.Hatchet2:
			SetupDialog("Xyloalgia will avenge me!");
			SetExpression(Expression.Sleeping);
			SfxController.singleton.Play("ranting_tree_talk_avenge");
			break;
		case State.HatchetCanceled:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroApproachOffsetX, base.PositionZ);
			SetupDialog("tid_ranting_06");
			SetExpression(Expression.Angry);
			SfxController.singleton.Play("ranting_tree_talk_get_out");
			break;
		case State.SightstoneAnimation:
			GetEquippedSightstone().Attack(this);
			break;
		case State.Sightstone1:
			SetupDialog("Is that a Soul Stone? Impressive.");
			SetExpression(Expression.Surprised);
			SfxController.singleton.Play("ranting_tree_talk_impressive");
			break;
		case State.Sightstone2:
			ProgressFlags.SetFlag("ranting_tree_saw_sightstone");
			SetupDialog("Very well, you may squeeze by. Xyloalgia will be interested in this.");
			SetExpression(Expression.Aloof);
			SfxController.singleton.Play("ranting_tree_talk_very_well");
			rightHandWave.GetComponentInChildren<AsciiAnimation>().Play();
			break;
		case State.SightstonePassing1:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + heroSightstonePassingOffsetX, base.PositionZ + 1);
			if (Inventory.Singleton.HasItemById("dirty_sword") && ProgressFlags.GetFlag("got_metal_2_from_boulder"))
			{
				QuestController.singleton.MakeAvailable("upgrade_workstation_2");
				QuestController.singleton.MakeAvailable("utility_belt");
			}
			AchievementController.singleton.ReportPassingRantingTreeWithoutUnmaking();
			break;
		case State.SightstonePassing2:
			RestoreHeroAI();
			break;
		}
		previousState = currentState;
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (GameStates.Singleton.CurrentState == GameStates.State.PlayPaused || currentState == State.Scripted)
		{
			return;
		}
		stateElapsedTics++;
		if (currentState == State.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX - 15)
		{
			SetState(State.IntroApproach);
		}
		if (currentState == State.IntroApproach && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
		{
			if (ProgressFlags.GetFlag("ranting_tree_saw_sightstone"))
			{
				SetState(State.SightstonePassing1);
				rightHandWave.GetComponentInChildren<AsciiAnimation>().Play();
				suspiciousLook = true;
				SetExpression(Expression.Suspicious);
			}
			else if (IsSightstoneEquipped())
			{
				SetState(State.ApproachSightstone);
			}
			else if (IsHatchetEquipped())
			{
				SetState(State.ApproachHatchet);
			}
			else if (ProgressFlags.GetFlag("deadwood_valley_1"))
			{
				SetState(State.Revisit1);
			}
			else
			{
				SetState(State.IntroSmallPause);
			}
		}
		else if (currentState == State.IntroSmallPause && stateElapsedTics >= 20)
		{
			SetState(State.IntroApproach2);
		}
		else if (currentState == State.IntroApproach2 && GameStates.Singleton.hero.PositionX >= base.PositionX + heroHaltOffsetX)
		{
			SetState(State.Intro1);
		}
		else if (currentState == State.ApproachHatchet)
		{
			if (!IsHatchetEquipped())
			{
				SetState(State.Revisit2);
			}
		}
		else if (currentState == State.ApproachSightstone && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
		{
			if (!IsSightstoneEquipped())
			{
				SetState(State.Revisit2);
			}
			else
			{
				SetState(State.SightstoneAnimation);
			}
		}
		else if (currentState == State.Hatchet1 || currentState == State.Hatchet2)
		{
			if (!IsHatchetEquipped())
			{
				SetState(State.HatchetCanceled);
			}
		}
		else if (currentState == State.SightstoneAnimation && stateElapsedTics >= 30)
		{
			SetState(State.Sightstone1);
		}
		else if (currentState == State.SightstonePassing1 && GameStates.Singleton.hero.PositionX >= base.PositionX + heroSightstonePassingOffsetX)
		{
			SetState(State.SightstonePassing2);
		}
		if (currentState >= State.Intro1 && currentState <= State.Sightstone2)
		{
			dialogBubble.UpdateTic();
		}
		if (currentState == State.Exiting && stateElapsedTics >= 10)
		{
			if (IsHatchetEquipped())
			{
				SetState(State.ApproachHatchet);
			}
			else if (IsSightstoneEquipped())
			{
				SetState(State.ApproachSightstone);
			}
			else if (ProgressFlags.GetFlag("show_items"))
			{
				GameStates.Singleton.Pause();
			}
			else
			{
				GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EndQuest);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (currentState >= State.Intro1 && currentState <= State.Sightstone2)
		{
			dialogBubble.SetNPCMouthPosition(base.lastDrawX, base.lastDrawY - 6);
			int offsetX2 = (r.width - dialogBubble.Width >> 1) - 9;
			int offsetY2 = base.lastDrawY - 4 - dialogBubble.Height;
			dialogBubble.Draw(r, offsetX2, offsetY2);
		}
		if (currentFace != null)
		{
			DrawSprite(r, offsetX, offsetY, currentFace);
		}
		if (dialogBubble.CurrentState != DialogNineSlice.State.In)
		{
			_ = dialogBubble.CurrentState;
			_ = 3;
		}
		if (currentState == State.Revisit2)
		{
			DrawSprite(r, offsetX, offsetY, leftHand);
		}
		if (currentState == State.Intro1)
		{
			DrawSprite(r, offsetX, offsetY, rightHandHalt);
		}
		else if (currentState == State.Sightstone2 || suspiciousLook)
		{
			DrawSprite(r, offsetX, offsetY, rightHandWave);
		}
	}

	private void DrawSprite(AsciiRenderProcedural r, int offsetX, int offsetY, AsciiSprite sprite)
	{
		if (base.damagedTics <= 0)
		{
			sprite.Draw(r, offsetX, offsetY);
		}
		else if (base.damagedTics == 1)
		{
			sprite.Draw(r, offsetX, offsetY, 0.775f);
		}
		else
		{
			sprite.Draw(r, offsetX, offsetY, 0.55f);
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

	private bool IsHatchetEquipped()
	{
		if (GameStates.Singleton.hero.RightHand != null)
		{
			return GameStates.Singleton.hero.RightHand.id == "hatchet_lv1";
		}
		return false;
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
		Weapon rightHand = GameStates.Singleton.hero.LeftHand;
		if (rightHand == null || rightHand.id != "sight_stone")
		{
			rightHand = GameStates.Singleton.hero.RightHand;
		}
		if (rightHand != null && rightHand.id != "sight_stone")
		{
			return null;
		}
		return rightHand;
	}

	private void SetupDialog(string message)
	{
		dialogBubble.PositionX = 0;
		dialogBubble.PositionY = 0;
		dialogBubble.SetMessage(Te.xt(message));
		dialogBubble.Show();
	}

	private void SetExpression(Expression expression)
	{
		switch (expression)
		{
		case Expression.Sleeping:
			currentFace = sleepingFace;
			break;
		case Expression.Angry:
			currentFace = angryFace;
			break;
		case Expression.Aloof:
			currentFace = aloofFace;
			break;
		case Expression.Pain:
			currentFace = painFace;
			break;
		case Expression.Surprised:
			currentFace = surprisedFace;
			break;
		case Expression.Suspicious:
			currentFace = suspiciousFace;
			break;
		}
	}

	private void HandleDialogButtonDone()
	{
		if (currentState == State.Intro1)
		{
			SetState(State.Intro2);
		}
		else if (currentState == State.Revisit1)
		{
			SetState(State.Revisit2);
		}
		else if (currentState == State.Intro2 || currentState == State.Revisit2 || currentState == State.HatchetCanceled)
		{
			SetState(State.Exiting);
		}
		else if (currentState == State.Sightstone1)
		{
			SetState(State.Sightstone2);
		}
		else if (currentState == State.Sightstone2)
		{
			SetState(State.SightstonePassing1);
		}
	}

	private void HandleCharacterTookDamage(Character character, Damage dmg)
	{
		if (character == this)
		{
			if (currentState != State.Hatchet2 && base.Hitpoints <= base.MaxHitpoints / 2)
			{
				SetState(State.Hatchet2);
			}
			else if (currentState != State.Hatchet1 && currentState != State.Hatchet2)
			{
				SetState(State.Hatchet1);
			}
		}
	}

	public override void Die(DeathReason reason, Damage dmg)
	{
		base.Die(reason, dmg);
		if (reason == DeathReason.DamageTaken)
		{
			GameStates.Singleton.hero.PauseAI(0.7f);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = UnityEngine.Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogButtonDone;
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
		SetState(State.Waiting);
	}

	private void OnDestroy()
	{
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogButtonDone;
			UnityEngine.Object.Destroy(dialogBubble.gameObject);
			Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		}
	}
}
