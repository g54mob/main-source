using System.Collections.Generic;

public class GainArmorOnEnemyStatMod : StatModifier
{
	private List<Character> enemiesEngaged = new List<Character>();

	private void HandleEnemyEngaged(Enemy e)
	{
		if (base.sourceItem != null && base.sourceItem.Owner != null && ItemData.Counters(base.sourceItem.element) == e.GetElement() && !enemiesEngaged.Contains(e))
		{
			enemiesEngaged.Add(e);
			float num = ComputeStatForSourceItemLevelAndRarity();
			base.sourceItem.Owner.Armor += num;
			base.sourceItem.Owner.LimitArmorToCeiling();
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
