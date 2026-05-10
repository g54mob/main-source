using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class AreaEffectModule_GEApplier : AreaEffectModule
{
	[Serializable]
	private struct FGameplayEffect
	{
		[SerializeField]
		private GameplayEffectData gameplayEffectData;

		[SerializeField]
		private int stacks;

		public GameplayEffectData GameplayEffectData => gameplayEffectData;

		public int Stacks => stacks;

		public FGameplayEffect(GameplayEffectData gameplayEffectData, int stacks)
		{
			this.gameplayEffectData = gameplayEffectData;
			this.stacks = stacks;
		}
	}

	[SerializeField]
	private List<FGameplayEffect> gameplayEffectsToApply;

	public override string DisplayName
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object> { 
			{
				"ge-name",
				gameplayEffectsToApply[0].GameplayEffectData.DisplayName
			} };
			return new LocalizedString("GameplayEffects", "GE_areaEffectModule_GEApplier_name").GetLocalizedString(dictionary);
		}
	}

	public override string Description
	{
		get
		{
			AreaEffect component = GetComponent<AreaEffect>();
			string text = "";
			foreach (FGameplayEffect item in gameplayEffectsToApply)
			{
				if (text.Length > 0)
				{
					text += ", ";
				}
				text += item.GameplayEffectData.DisplayName;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ "ge-name", text },
				{
					"stacks",
					gameplayEffectsToApply[0].Stacks
				},
				{ "tick-time", component.TickTime },
				{ "duration", component.Duration },
				{
					"enemy-type",
					component.GetAffectedEnemyTypesString()
				}
			};
			string text2 = new LocalizedString("GameplayEffects", "GE_areaEffectModule_GEApplier_description").GetLocalizedString(dictionary);
			foreach (FGameplayEffect item2 in gameplayEffectsToApply)
			{
				text2 += "\n\n";
				text2 += item2.GameplayEffectData.DisplayName;
				text2 += "\n";
				text2 += item2.GameplayEffectData.Description;
			}
			return text2;
		}
	}

	public override void DoModuleEffect(IEnumerable<Enemy> enemies)
	{
		foreach (Enemy enemy in enemies)
		{
			for (int i = 0; i < gameplayEffectsToApply.Count; i++)
			{
				enemy.GameplayEffectsComponent.ApplyEffect(gameplayEffectsToApply[i].GameplayEffectData, gameplayEffectsToApply[i].Stacks);
			}
		}
	}
}
