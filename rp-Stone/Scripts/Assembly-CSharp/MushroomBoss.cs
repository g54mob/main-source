using UnityEngine;

public class MushroomBoss : Enemy
{
	private enum Behavior
	{
		Punch = 0,
		Shoot = 1
	}

	public int totalShots = 3;

	public AsciiSprite shotCast;

	public AsciiSprite shotPerf;

	public Weapon punchWeapon;

	public Weapon shootWeapon;

	public bool spawnsPhase2 = true;

	private Behavior behavior;

	private int shots;

	private AsciiSprite punchCast;

	private AsciiSprite punchPerf;

	private int showOutroCountdown;

	protected override void SetState(State newState)
	{
		if (base.CurrentState == State.Attacking)
		{
			if (behavior == Behavior.Punch)
			{
				behavior = Behavior.Shoot;
				base.weapon = shootWeapon;
				shots = 0;
				attackCastSprite = shotCast;
				attackPerfSprite = shotPerf;
			}
			else
			{
				shots++;
				if (shots >= totalShots)
				{
					behavior = Behavior.Punch;
					base.weapon = punchWeapon;
					attackCastSprite = punchCast;
					attackPerfSprite = punchPerf;
				}
			}
		}
		base.SetState(newState);
	}

	private void HandleCharacterDied(Character c, DeathReason reason, Damage damage)
	{
		if (!(c != this))
		{
			if (spawnsPhase2)
			{
				GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
				GameStates.Singleton.hero.SetMoveDestination(base.PositionX - 15, base.PositionZ);
			}
			else if (!QuestController.singleton.IsAvailable("undead_crypt_intro"))
			{
				showOutroCountdown = 40;
			}
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (showOutroCountdown > 0)
		{
			showOutroCountdown--;
			if (showOutroCountdown <= 0)
			{
				GameStates.Singleton.ShowPlayChoiceDialog("An ancient gateway lies beyond the fungii garden. Its rusty railing a haunting, ominous grin.", "Continue", KeyCode.Return);
				GameStates.Singleton.playChoiceDialog.buttonSingle.OnPressed += HandleButtonPressed;
			}
		}
	}

	private void HandleButtonPressed(DialogButton btn)
	{
		btn.OnPressed -= HandleButtonPressed;
		GameStates.Singleton.SetState(GameStates.State.Playing);
	}

	public static void RestoreAI()
	{
		GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
		GameStates.Singleton.hero.RestoreAI();
	}

	protected override void Awake()
	{
		base.Awake();
		punchCast = attackCastSprite;
		punchPerf = attackPerfSprite;
		shotCast.Load();
		shotPerf.Load();
		base.weapon = punchWeapon;
		shootWeapon.Owner = this;
		Character.OnCharacterDied += HandleCharacterDied;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterDied -= HandleCharacterDied;
	}
}
