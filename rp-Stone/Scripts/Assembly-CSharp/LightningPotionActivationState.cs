using System.Collections.Generic;
using UnityEngine;

public class LightningPotionActivationState : BasePotionActivationState
{
	public class LightningState : PotionState
	{
		public static readonly State Sweeping = new State("Sweeping");

		public static readonly State Damaging = new State("Damaging");
	}

	private const int DAMAGE_AMOUNT = 200;

	public Decoration lightningCloudPrefab;

	private Decoration cloud;

	public override void Activate()
	{
		base.Activate();
		SfxController.singleton.Play("potion_lightning");
	}

	protected override void SetState(State newState)
	{
		if (newState == LightningState.Sweeping)
		{
			MakeLightningCloud();
		}
		else if (newState == LightningState.Damaging)
		{
			DamageFoes();
		}
		else if (newState == State.Done)
		{
			cloud.Die(Character.DeathReason.DecorationCleanup);
		}
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == PotionState.BottleMorphing && stateElapsedTics == 13)
		{
			SetState(LightningState.Sweeping);
		}
		else if (base.currentState == LightningState.Sweeping)
		{
			if (stateElapsedTics == 90)
			{
				SetState(LightningState.Damaging);
			}
			else if (stateElapsedTics % 2 == 0)
			{
				cloud.PositionX++;
			}
		}
		else if (base.currentState == LightningState.Damaging && stateElapsedTics == 10)
		{
			SetState(State.Done);
		}
	}

	private void MakeLightningCloud()
	{
		Hero hero = GameStates.Singleton.hero;
		cloud = Object.Instantiate(lightningCloudPrefab);
		cloud.PositionX = hero.PositionX;
		cloud.PositionY = hero.PositionY;
		cloud.PositionZ = hero.PositionZ + 1;
		GameStates.Singleton.level.AddCharacter(cloud);
	}

	private void DamageFoes()
	{
		Hero hero = GameStates.Singleton.hero;
		int positionX = hero.PositionX;
		List<Enemy> enemies = GameStates.Singleton.level.Enemies;
		for (int i = 0; i < enemies.Count; i++)
		{
			Enemy enemy = enemies[i];
			if (enemy.PositionX - positionX < 70)
			{
				Damage damage = new Damage();
				damage.type = Damage.Type.Super;
				damage.amount = 200;
				damage.isCritical = true;
				damage.Owner = hero;
				damage.tags.Add("lightning_potion");
				enemy.InflictDamage(damage);
			}
		}
	}
}
