using UnityEngine;

public class CleansingPotionActivationState : BasePotionActivationState
{
	public class CleansingState : PotionState
	{
	}

	public Decoration sparkleVfxPrefab;

	private int sparkleIndex;

	public override void Activate()
	{
		base.Activate();
		SfxController.singleton.Play("potion_cleansing");
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == PotionState.BottleMorphing)
		{
			if (stateElapsedTics == 45)
			{
				CleanseAndHeal();
			}
			if (stateElapsedTics == 60)
			{
				SetState(State.Done);
			}
			else if (stateElapsedTics % 4 == 1)
			{
				MakeSparkle();
			}
		}
	}

	private void MakeSparkle()
	{
		int num = 0;
		int num2 = 0;
		if (sparkleIndex == 0)
		{
			num = -3;
			num2 = 0;
		}
		else if (sparkleIndex == 1)
		{
			num = -2;
			num2 = 1;
		}
		else if (sparkleIndex == 2)
		{
			num = 0;
			num2 = 1;
		}
		else if (sparkleIndex == 3)
		{
			num = 2;
			num2 = 1;
		}
		else if (sparkleIndex == 4)
		{
			num = 3;
			num2 = 0;
		}
		else if (sparkleIndex == 5)
		{
			num = 2;
			num2 = -1;
		}
		else if (sparkleIndex == 6)
		{
			num = 0;
			num2 = -1;
		}
		else if (sparkleIndex == 7)
		{
			num = -2;
			num2 = -1;
			sparkleIndex = -1;
		}
		sparkleIndex++;
		Hero hero = GameStates.Singleton.hero;
		Decoration decoration = Object.Instantiate(sparkleVfxPrefab);
		decoration.PositionX = hero.PositionX + num;
		decoration.PositionY = hero.PositionY;
		decoration.PositionZ = hero.PositionZ + num2;
		GameStates.Singleton.level.AddCharacter(decoration);
	}

	private void CleanseAndHeal()
	{
		Hero hero = GameStates.Singleton.hero;
		hero.Cleanse();
		if (hero.Hitpoints < hero.MaxHitpoints)
		{
			int b = hero.MaxHitpoints - hero.Hitpoints;
			int amount = Mathf.Min(hero.MaxHitpoints / 2, b);
			Damage damage = new Damage();
			damage.amount = amount;
			damage.tags.Add("potion");
			hero.ApplyHeal(damage);
			SfxController.singleton.Play("life_gain");
		}
	}

	public override void Draw(AsciiRenderProcedural r)
	{
		base.Draw(r);
	}
}
