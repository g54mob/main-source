using UnityEngine;

public class Xyloalgus : Enemy
{
	private enum XyloState
	{
		Waiting = 0,
		Talking1 = 1,
		Talking2 = 2,
		DeathTalk = 3,
		Done = 4
	}

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public bool includeDeathMessage;

	public int dialogPosOffsetX = -12;

	public int dialogPosOffsetY = -5;

	private XyloState xyloState;

	private int xyloStateElapsedTics;

	private void SetXyloState(XyloState newState)
	{
		switch (newState)
		{
		case XyloState.Talking1:
			SetupDialog(Te.xt("Puny things should not be moving about."));
			StopHeroAI();
			break;
		case XyloState.Talking2:
			SetupDialog(Te.xt("I, Xyloalgia, will rebind you to the ground."));
			break;
		case XyloState.DeathTalk:
			SetupDialog(Te.xt("You will never ascend to [color=#00ffff]Acropolis[/color]!"));
			StopHeroAI();
			break;
		case XyloState.Done:
			RestoreHeroAI();
			break;
		}
		xyloState = newState;
		xyloStateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		xyloStateElapsedTics++;
		if (xyloState == XyloState.Waiting && base.PositionX - GameStates.Singleton.hero.PositionX <= 40 && GameStates.Singleton.previousState == GameStates.State.SightstoneCharacterDialog && GameStates.Singleton.stateElapsedTics == 1 && GameStates.Singleton.level.QuestData.level <= 5)
		{
			SetXyloState(XyloState.Talking1);
		}
		if (xyloState == XyloState.Talking1 || xyloState == XyloState.Talking2)
		{
			dialogBubble.UpdateTic();
			base.SetState(State.Engaging);
			base.weapon.SetState(Weapon.State.Waiting);
		}
		else if (xyloState == XyloState.DeathTalk)
		{
			dialogBubble.UpdateTic();
			if (xyloStateElapsedTics >= 120)
			{
				dialogBubble.Hide();
			}
			else if (dialogBubble.CurrentState == DialogNineSlice.State.Idle)
			{
				deathDurationTics++;
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (xyloState == XyloState.Talking1 || xyloState == XyloState.Talking2 || xyloState == XyloState.DeathTalk)
		{
			dialogBubble.SetNPCMouthPosition(base.lastDrawX + mouthOffsetX, base.lastDrawY + mouthOffsetY);
			int offsetX2 = (r.width - dialogBubble.Width >> 1) + dialogPosOffsetX;
			int offsetY2 = base.lastDrawY - dialogBubble.Height + dialogPosOffsetY;
			dialogBubble.Draw(r, offsetX2, offsetY2);
		}
	}

	private void StopHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
		GameStates.Singleton.hero.GetComponent<HeroAI>().enabled = false;
		GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
	}

	private void RestoreHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
	}

	private void SetupDialog(string message)
	{
		dialogBubble.PositionX = 0;
		dialogBubble.PositionY = 0;
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	private void HandleDialogButtonDone()
	{
		if (xyloState == XyloState.Talking1)
		{
			SetXyloState(XyloState.Talking2);
		}
		else if (xyloState == XyloState.DeathTalk)
		{
			deathDurationTics = 0;
			SetXyloState(XyloState.Done);
		}
		else
		{
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
			SetXyloState(XyloState.Done);
		}
	}

	private void HandleCharacterGoingToTakeDamage(Character character, Damage dmg)
	{
		if (character == this)
		{
			if (xyloState == XyloState.Talking1 || xyloState == XyloState.Talking2 || xyloState == XyloState.DeathTalk)
			{
				dmg.amount = 0;
			}
			else if (dmg.tags.Contains("hatchet"))
			{
				dmg.amount += 3;
			}
		}
	}

	private void HandleCharacterDied(Character character, DeathReason reason, Damage damage)
	{
		if (character == this)
		{
			if (includeDeathMessage && OuroborosWeapon.IsEnabled())
			{
				SetXyloState(XyloState.DeathTalk);
			}
			else if (xyloState != XyloState.Waiting && xyloState != XyloState.Done)
			{
				SetXyloState(XyloState.Done);
			}
			AchievementController.singleton.ReportXyloDefeated(this);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogButtonDone;
		Character.OnCharacterDied += HandleCharacterDied;
		Character.OnCharacterGoingToTakeDamage += HandleCharacterGoingToTakeDamage;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogButtonDone;
			Object.Destroy(dialogBubble.gameObject);
		}
		Character.OnCharacterDied -= HandleCharacterDied;
		Character.OnCharacterGoingToTakeDamage -= HandleCharacterGoingToTakeDamage;
	}
}
