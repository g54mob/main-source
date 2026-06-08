using System.Collections.Generic;

public class ApplyDebuffOnEnemyStatMod : StatModifier
{
	private List<Character> enemiesEngaged = new List<Character>();

	private void HandleEnemyEngaged(Enemy e)
	{
		if (base.sourceItem != null && !enemiesEngaged.Contains(e))
		{
			enemiesEngaged.Add(e);
			ApplyDebuffOnHitStatMod.ApplyTo(this, e);
		}
	}

	private void HandleCharacterCleanedUp(Character c)
	{
		if (enemiesEngaged.Contains(c))
		{
			enemiesEngaged.Remove(c);
		}
	}

	public override void Init()
	{
		base.Init();
		Enemy.OnEnemyEngaged += HandleEnemyEngaged;
		Character.OnCharacterCleanedUp += HandleCharacterCleanedUp;
	}

	public override void End()
	{
		Enemy.OnEnemyEngaged -= HandleEnemyEngaged;
		Character.OnCharacterCleanedUp -= HandleCharacterCleanedUp;
		enemiesEngaged.Clear();
		base.End();
	}
}
