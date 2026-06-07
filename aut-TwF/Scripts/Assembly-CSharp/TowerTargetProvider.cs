using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public abstract class TowerTargetProvider : ScriptableObject
{
	[SerializeField]
	private string id;

	[SerializeField]
	private LocalizedString displayName;

	[SerializeField]
	private Sprite icon;

	protected List<Enemy> auxEnemyList;

	public string Id => id;

	public virtual string DisplayName => displayName.GetLocalizedString();

	public Sprite Icon => icon;

	private void SetNameAsID()
	{
		id = base.name;
	}

	protected TowerTargetProvider()
	{
		auxEnemyList = new List<Enemy>();
	}

	public abstract List<Enemy> GetTarget(Tower tower, List<Enemy> enemies);

	protected virtual bool IsTargetValid(Tower tower, Enemy target)
	{
		if ((bool)target && target.CombatComponent.IsTargetable())
		{
			return tower.CombatComponent.CanTargetEnemy(target);
		}
		return false;
	}
}
