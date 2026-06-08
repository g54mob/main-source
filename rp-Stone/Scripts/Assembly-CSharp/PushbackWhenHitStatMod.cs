using UnityEngine;

public class PushbackWhenHitStatMod : StatModifier
{
	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		Character owner = dmg.Owner;
		if (c == base.character && owner != null && owner.Alive && !owner.tags.Contains("unpushable"))
		{
			int num = Mathf.RoundToInt(ComputeStatForSourceItemLevelAndRarity());
			int positionX = Mathf.Min(owner.PositionX + num, GameStates.Singleton.level.GetEnemyLimitX(owner));
			owner.PositionX = positionX;
		}
	}

	public override void Init()
	{
		base.Init();
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
	}

	public override void End()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		base.End();
	}
}
