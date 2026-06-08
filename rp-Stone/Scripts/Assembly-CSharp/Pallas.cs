using UnityEngine;

public class Pallas : Enemy
{
	public bool regrowArm = true;

	public Character armReplacement;

	public int armRespawnDelay = 90;

	private int armRespawnRemaining;

	private Enemy swordArm;

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (armRespawnRemaining > 0)
		{
			armRespawnRemaining--;
			if (armRespawnRemaining == 0)
			{
				Character character = Object.Instantiate(armReplacement);
				character.PositionX = base.PositionX;
				character.PositionY = base.PositionY;
				character.PositionZ = base.PositionZ;
				GameStates.Singleton.level.AddCharacter(character);
				character.SetLevel(level);
			}
		}
	}

	private void HandleCharacterDied(Character c, DeathReason reason, Damage damage)
	{
		if (c == swordArm)
		{
			swordArm = null;
			if (regrowArm)
			{
				armRespawnRemaining = armRespawnDelay;
			}
		}
	}

	private void HandleCharacterCreated(Character c)
	{
		if (c.id == "skeleton_boss_sword_arm")
		{
			swordArm = c as Enemy;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterDied += HandleCharacterDied;
		Character.OnCharacterCreated += HandleCharacterCreated;
	}

	protected override void OnDestroy()
	{
		Character.OnCharacterDied -= HandleCharacterDied;
		Character.OnCharacterCreated -= HandleCharacterCreated;
		swordArm = null;
		base.OnDestroy();
	}

	public override int GetStateNumericRepresentation()
	{
		if (armRespawnRemaining > 0)
		{
			return 100;
		}
		if (swordArm != null)
		{
			return swordArm.GetStateNumericRepresentation();
		}
		return 0;
	}

	public override int GetStateTimeRepresentation()
	{
		if (swordArm != null)
		{
			return swordArm.GetStateTimeRepresentation();
		}
		return armRespawnRemaining;
	}
}
