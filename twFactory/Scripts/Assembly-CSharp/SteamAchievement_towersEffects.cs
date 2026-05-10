using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SteamAchievement_towersEffects_default", menuName = "Tower Factory/Steam Achievements/Towers Effects")]
public class SteamAchievement_towersEffects : SteamAchievement
{
	[Header("Towers Effects")]
	[SerializeField]
	private int affectedTowersAmount;

	[SerializeField]
	private GameplayEffectData[] effectsToCheck;

	[SerializeField]
	[Tooltip("requireAllEffects = false: cualquier efecto de la lista, si no tiene que tenerlos todos para que cuente.")]
	private bool requireAllEffects;

	[SerializeField]
	[Tooltip("uniqueTower = true: cada torre solo puede contar una vez")]
	private bool uniqueTower = true;

	private Dictionary<GameplayEffectsComponent, int> currentAffectedTowers;

	private bool UniqueTower
	{
		get
		{
			if (!requireAllEffects)
			{
				return uniqueTower;
			}
			return true;
		}
	}

	protected override void OnStartGame()
	{
		base.OnStartGame();
		currentAffectedTowers = new Dictionary<GameplayEffectsComponent, int>();
		LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded += OnTowerAdded;
	}

	private void CheckAchievementCompleted()
	{
		int num = currentAffectedTowers.Count;
		if (!UniqueTower)
		{
			foreach (int value in currentAffectedTowers.Values)
			{
				num += value - 1;
			}
		}
		if (num >= affectedTowersAmount)
		{
			UnlockAchievement();
			LTFunctionLibrary.GetPlayerData().onPlayerTowerAdded -= OnTowerAdded;
		}
	}

	private void OnTowerAdded(GameplayObject addedTower)
	{
		addedTower.GetComponent<GameplayEffectsComponent>().onEffectAdded += OnEffectAdded;
		addedTower.GetComponent<GameplayEffectsComponent>().onEffectRemoved += OnEffectRemoved;
	}

	private void AddAffectedTower(GameplayEffectsComponent gameplayEffectsComponent)
	{
		if (currentAffectedTowers.ContainsKey(gameplayEffectsComponent))
		{
			currentAffectedTowers[gameplayEffectsComponent]++;
		}
		else
		{
			currentAffectedTowers.Add(gameplayEffectsComponent, 1);
		}
	}

	private void RemoveAffectedTower(GameplayEffectsComponent gameplayEffectsComponent)
	{
		if (currentAffectedTowers.ContainsKey(gameplayEffectsComponent))
		{
			currentAffectedTowers[gameplayEffectsComponent]--;
			if (currentAffectedTowers[gameplayEffectsComponent] <= 0)
			{
				currentAffectedTowers.Remove(gameplayEffectsComponent);
			}
		}
	}

	private void OnEffectAdded(GameplayEffect effect)
	{
		if (!base.IsStarted || !effectsToCheck.Contains(effect.EffectData))
		{
			return;
		}
		if (requireAllEffects)
		{
			GameplayEffectData[] array = effectsToCheck;
			foreach (GameplayEffectData effectToFind in array)
			{
				if (effect.Owner.FindEffect(effectToFind) == null)
				{
					return;
				}
			}
		}
		AddAffectedTower(effect.Owner);
		CheckAchievementCompleted();
	}

	private void OnEffectRemoved(GameplayEffect effect)
	{
		if (base.IsStarted && effectsToCheck.Contains(effect.EffectData))
		{
			RemoveAffectedTower(effect.Owner);
		}
	}
}
