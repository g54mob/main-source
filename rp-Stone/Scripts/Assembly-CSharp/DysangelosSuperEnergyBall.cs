using System;
using UnityEngine;

public class DysangelosSuperEnergyBall : Decoration
{
	private enum State
	{
		Flying = 0,
		Following = 1,
		Cast = 2,
		Perf = 3,
		Done = 4
	}

	public int damageBase = 30;

	public int damagePerLevel = 5;

	private int damageRadius = 3;

	private float accelerationX = 0.05f;

	private float velocityX;

	private float f_posX;

	private int initialX;

	private DysangelosPerfected dysangelos;

	private State currentState;

	private int stateElapsedTics;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Following:
			GetComponent<AsciiAnimation>().Play();
			SfxController.singleton.Play("perfected_energy_ball");
			break;
		case State.Perf:
			TryDamagePlayer();
			break;
		case State.Done:
			Die(DeathReason.LifetimeEnded);
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		stateElapsedTics++;
		Hero hero = GameStates.Singleton.hero;
		int num = 1;
		if (currentState == State.Flying)
		{
			if (velocityX > 0f || base.PositionX <= initialX - 30)
			{
				velocityX += accelerationX;
				if (velocityX > 1f)
				{
					velocityX = 1f;
				}
			}
			else if (base.PositionX >= hero.PositionX)
			{
				velocityX -= accelerationX;
				if (velocityX < -1f)
				{
					velocityX = -1f;
				}
			}
			f_posX += velocityX;
			base.PositionX = Mathf.RoundToInt(f_posX);
			if (velocityX > 0f && !hero.isInvisible && base.PositionX >= hero.PositionX + num && dysangelos != null && dysangelos.Alive)
			{
				base.PositionX = hero.PositionX + num;
				SetState(State.Following);
			}
			else if (base.PositionX > initialX + 100)
			{
				SetState(State.Done);
			}
		}
		else if (currentState == State.Following)
		{
			if (stateElapsedTics >= 21)
			{
				SetState(State.Cast);
				return;
			}
			if (hero.isInvisible)
			{
				velocityX = 0.1f;
				SetState(State.Flying);
				return;
			}
			int num2 = hero.PositionX + num;
			if (base.PositionX < num2)
			{
				base.PositionX++;
			}
			else if (base.PositionX > num2)
			{
				base.PositionX--;
			}
		}
		else if (currentState == State.Cast && stateElapsedTics >= 22)
		{
			SetState(State.Perf);
		}
		else if (currentState == State.Perf && stateElapsedTics >= 32)
		{
			SetState(State.Done);
		}
	}

	private void TryDamagePlayer()
	{
		Hero hero = GameStates.Singleton.hero;
		if (dysangelos != null && dysangelos.Alive && Mathf.Abs(hero.PositionX - base.PositionX) <= damageRadius)
		{
			Damage damage = new Damage();
			damage.amount = damageBase + damagePerLevel * level;
			damage.isCritical = true;
			damage.Owner = dysangelos;
			damage.tags.Add("magic");
			hero.InflictDamage(damage);
			SfxController.singleton.Play("perfected_energy_ball_hit");
		}
	}

	public void SetDysangelos(DysangelosPerfected inDysangelos)
	{
		inDysangelos.OnDefeated = (Action<DysangelosPerfected>)Delegate.Combine(inDysangelos.OnDefeated, new Action<DysangelosPerfected>(HandleDysangelosDefeated));
		dysangelos = inDysangelos;
	}

	private void HandleDysangelosDefeated(DysangelosPerfected inDysangelos)
	{
		inDysangelos.OnDefeated = (Action<DysangelosPerfected>)Delegate.Remove(inDysangelos.OnDefeated, new Action<DysangelosPerfected>(HandleDysangelosDefeated));
		dysangelos = null;
		SetState(State.Done);
	}

	public override void Init()
	{
		base.Init();
		initialX = base.PositionX;
		f_posX = base.PositionX;
	}

	private void OnDestroy()
	{
		dysangelos = null;
	}
}
