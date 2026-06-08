using System;
using System.Collections.Generic;

public class SightstoneWeapon : Weapon
{
	private List<string> charactersExamined = new List<string>();

	private Character currentTarget;

	public static event Action<Character> OnSightstoneActivated;

	public override bool CanAttack(Character target)
	{
		if (target.tags.Contains("harvest") && target.id != "ranting_tree")
		{
			return false;
		}
		return !charactersExamined.Contains(target.id);
	}

	public override void Attack(Character target)
	{
		base.Attack(target);
		currentTarget = target;
	}

	protected override void Execute()
	{
	}

	public override void SetState(State newState)
	{
		base.SetState(newState);
		if (newState == State.Cooldown && currentTarget != null && currentTarget.Alive)
		{
			charactersExamined.Add(currentTarget.id);
			GameStates.Singleton.ShowSightstoneCharacter(currentTarget);
			if (SightstoneWeapon.OnSightstoneActivated != null)
			{
				SightstoneWeapon.OnSightstoneActivated(currentTarget);
			}
			AchievementController.singleton.ReportSightStoneUsed();
		}
		if (newState == State.Casting || newState == State.Cooldown)
		{
			currentTarget = null;
		}
	}

	private void HandleUnequipped(Character c, Weapon w)
	{
		if (w == this)
		{
			charactersExamined.Clear();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterUnequippedWeapon += HandleUnequipped;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		currentTarget = null;
		charactersExamined.Clear();
		Character.OnCharacterUnequippedWeapon -= HandleUnequipped;
	}
}
