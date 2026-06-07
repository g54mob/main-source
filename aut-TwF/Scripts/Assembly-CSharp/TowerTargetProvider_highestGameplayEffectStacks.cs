using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "TargetProvider_highestGE", menuName = "Tower Factory/Target Providers/Highest GE Stacks", order = 6)]
public class TowerTargetProvider_highestGameplayEffectStacks : TowerTargetProvider
{
	[SerializeField]
	private GameplayEffectData gameplayEffectData;

	public override string DisplayName
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> { { "ge-name", gameplayEffectData.DisplayName } };
			return new LocalizedString("UI_InGame", "UI_InGame_selectable_tower_tooltip_targetPriority_mostGEStacks").GetLocalizedString(dictionary);
		}
	}

	public override List<Enemy> GetTarget(Tower tower, List<Enemy> enemies)
	{
		auxEnemyList.Clear();
		float maxStacks = 0f;
		if ((bool)tower.Target && enemies.Contains(tower.Target))
		{
			maxStacks = tower.Target.GameplayEffectsComponent.FindEffect(gameplayEffectData)?.CurrentStacks ?? 0;
			auxEnemyList.Add(tower.Target);
		}
		float auxStacks;
		enemies.ForEach(delegate(Enemy x)
		{
			if (IsTargetValid(tower, x))
			{
				auxStacks = x.GameplayEffectsComponent.FindEffect(gameplayEffectData)?.CurrentStacks ?? 0;
				if (auxStacks > maxStacks)
				{
					auxEnemyList.Clear();
					auxEnemyList.Add(x);
					maxStacks = auxStacks;
				}
				else if (auxStacks == maxStacks)
				{
					auxEnemyList.Add(x);
				}
			}
		});
		return auxEnemyList;
	}
}
