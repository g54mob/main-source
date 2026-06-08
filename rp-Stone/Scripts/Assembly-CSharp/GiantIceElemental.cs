using UnityEngine;

public class GiantIceElemental : Enemy
{
	private enum BossState
	{
		Sleeping = 0,
		Idle = 1,
		PreAttack1 = 2,
		PreAttack2 = 3,
		PreAttack3 = 4,
		PreAttack4 = 5,
		PreAttack5 = 6,
		PreAttack6 = 7,
		PreAttack7 = 8,
		Attack = 9
	}

	public Enemy iceElementalPrefab;

	public int minPreAttackTics = 4;

	public int maxPreAttackTics = 60;

	public int elementalOffsetX = 8;

	private BossState currentBossState;

	private int elapsedBossTics;

	private int clockOffsetX = 3;

	private int clockOffsetY = -3;

	private void SetBossState(BossState newState)
	{
		if (newState == BossState.Attack)
		{
			base.weapon.SetState(Weapon.State.Waiting);
		}
		currentBossState = newState;
		elapsedBossTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedBossTics++;
		if (elapsedBossTics >= maxPreAttackTics)
		{
			if (currentBossState >= BossState.Idle && currentBossState < BossState.Attack)
			{
				SetBossState(currentBossState + 1);
			}
			else if (currentBossState == BossState.Attack)
			{
				SetBossState(BossState.Idle);
			}
		}
	}

	private void NextAttackState()
	{
		if (elapsedBossTics < minPreAttackTics)
		{
			return;
		}
		if (currentBossState >= BossState.Idle && currentBossState < BossState.Attack)
		{
			SetBossState(currentBossState + 1);
			if (currentBossState == BossState.Attack)
			{
				SpawnElemental();
			}
		}
		else if (currentBossState == BossState.Attack && base.CurrentState != State.Attacking && base.weapon.CurrentState == Weapon.State.Cooldown)
		{
			SetBossState(BossState.Idle);
		}
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
		if (currentBossState == BossState.Sleeping && base.CurrentState != State.Sleeping && base.CurrentState != State.WakingUp)
		{
			SetBossState(BossState.Idle);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (!Alive)
		{
			return;
		}
		AsciiCellProcedural cell = r.GetCell(base.lastDrawX + clockOffsetX, base.lastDrawY + clockOffsetY);
		if (cell != null)
		{
			if (currentBossState == BossState.Idle)
			{
				cell.SetValue(124);
			}
			else if (currentBossState == BossState.PreAttack1)
			{
				cell.SetValue(47);
			}
			else if (currentBossState == BossState.PreAttack2)
			{
				cell.SetValue(SpecialSymbols.Map('─'));
			}
			else if (currentBossState == BossState.PreAttack3)
			{
				cell.SetValue(92);
			}
			else if (currentBossState == BossState.PreAttack4)
			{
				cell.SetValue(124);
			}
			else if (currentBossState == BossState.PreAttack5)
			{
				cell.SetValue(47);
			}
			else if (currentBossState == BossState.PreAttack6)
			{
				cell.SetValue(SpecialSymbols.Map('─'));
			}
			else if (currentBossState == BossState.PreAttack7)
			{
				cell.SetValue(43);
			}
			else if (currentBossState == BossState.Attack)
			{
				cell.SetValue(111);
			}
			cell.SetForeground(ColorConstants.white);
		}
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (c == this && dmg.type != Damage.Type.Dot)
		{
			NextAttackState();
		}
	}

	private void SpawnElemental()
	{
		Character character = Object.Instantiate(iceElementalPrefab);
		character.PositionX = base.PositionX + elementalOffsetX;
		character.PositionY = base.PositionY;
		character.PositionZ = base.PositionZ;
		GameStates.Singleton.level.AddCharacter(character);
		Enemy enemy = character as Enemy;
		if ((bool)enemy)
		{
			enemy.WakeUp();
		}
		character.SetLevel(level);
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.OnDestroy();
	}
}
