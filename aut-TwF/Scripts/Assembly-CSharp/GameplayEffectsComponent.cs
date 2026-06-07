using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayEffectsComponent : MonoBehaviour, ISavable
{
	[SerializeField]
	private List<GameplayEffectData> initialEffects;

	[SerializeField]
	[Savable("activeEffects", true, false)]
	private List<GameplayEffect> activeEffects = new List<GameplayEffect>();

	[Savable("tickableEffects", true, false)]
	private List<GameplayEffect> tickableEffects = new List<GameplayEffect>();

	private Coroutine updateEffectsCoroutine;

	private StatsComponent statsComponent;

	public StatsComponent StatsComponent
	{
		get
		{
			return statsComponent;
		}
		protected set
		{
			statsComponent = value;
		}
	}

	public event Action<GameplayEffect> onEffectAdded;

	public event Action<GameplayEffect> onEffectRemoved;

	private void Awake()
	{
		StatsComponent = GetComponent<StatsComponent>();
	}

	private void Start()
	{
		foreach (GameplayEffectData initialEffect in initialEffects)
		{
			ApplyEffect(initialEffect, 1);
		}
	}

	private void OnDestroy()
	{
		foreach (GameplayEffect effect in GetEffects())
		{
			effect.RemoveStacks(callStacksRemovedEvent: false);
			this.onEffectRemoved?.Invoke(effect);
		}
	}

	public GameplayEffect ApplyEffect(GameplayEffectData effectData)
	{
		return ApplyEffect(effectData, 1);
	}

	public GameplayEffect ApplyEffect(GameplayEffectData effectData, int stacks)
	{
		GameplayEffect gameplayEffect = FindEffect(effectData);
		if (gameplayEffect == null)
		{
			gameplayEffect = effectData.InstantiateEffect();
			if (effectData.HasDuration || effectData.HasTickTime)
			{
				tickableEffects.Add(gameplayEffect);
				gameplayEffect.InitEffect(effectData, this);
				this.StartCoroutineCheckingVar(UpdateEffectsCoroutine(), ref updateEffectsCoroutine);
			}
			else
			{
				activeEffects.Add(gameplayEffect);
				gameplayEffect.InitEffect(effectData, this);
			}
			this.onEffectAdded?.Invoke(gameplayEffect);
		}
		gameplayEffect.AddStacks(stacks);
		return gameplayEffect;
	}

	public void RemoveEffect(GameplayEffectData effectData, int stacksToRemove, bool notifiyStacksRemoved = true)
	{
		GameplayEffect gameplayEffect = FindEffect(effectData);
		if (gameplayEffect != null)
		{
			gameplayEffect.RemoveStacks(stacksToRemove, notifiyStacksRemoved);
			if (gameplayEffect.CurrentStacks <= 0)
			{
				activeEffects.Remove(gameplayEffect);
				tickableEffects.Remove(gameplayEffect);
				this.onEffectRemoved?.Invoke(gameplayEffect);
			}
		}
	}

	public void RemoveEffect(GameplayEffectData effectData, bool notifyStacksRemoved = true)
	{
		GameplayEffect gameplayEffect = FindEffect(effectData);
		if (gameplayEffect != null)
		{
			gameplayEffect.RemoveStacks(gameplayEffect.CurrentStacks, notifyStacksRemoved);
			activeEffects.Remove(gameplayEffect);
			tickableEffects.Remove(gameplayEffect);
			this.onEffectRemoved?.Invoke(gameplayEffect);
		}
	}

	public GameplayEffect FindEffect(GameplayEffectData effectToFind)
	{
		for (int i = 0; i < activeEffects.Count; i++)
		{
			if (activeEffects[i].EffectData == effectToFind)
			{
				return activeEffects[i];
			}
		}
		for (int j = 0; j < tickableEffects.Count; j++)
		{
			if (tickableEffects[j].EffectData == effectToFind)
			{
				return tickableEffects[j];
			}
		}
		return null;
	}

	public GameplayEffect FindEffect<T>()
	{
		for (int i = 0; i < activeEffects.Count; i++)
		{
			if (activeEffects[i] is T)
			{
				return activeEffects[i];
			}
		}
		for (int j = 0; j < tickableEffects.Count; j++)
		{
			if (tickableEffects[j] is T)
			{
				return tickableEffects[j];
			}
		}
		return null;
	}

	public List<GameplayEffect> GetEffects(bool excludeHiddenEffects = false)
	{
		List<GameplayEffect> list = new List<GameplayEffect>();
		list.AddRange(activeEffects);
		list.AddRange(tickableEffects);
		if (excludeHiddenEffects)
		{
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (list[num].EffectData.HideToPlayer)
				{
					list.RemoveAt(num);
				}
			}
		}
		return list;
	}

	public List<GameplayEffectData> GetInitialEffects(bool excludeHiddenEffects = false)
	{
		List<GameplayEffectData> list = new List<GameplayEffectData>();
		list.AddRange(initialEffects);
		if (excludeHiddenEffects)
		{
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (list[num].HideToPlayer)
				{
					list.RemoveAt(num);
				}
			}
		}
		return list;
	}

	private IEnumerator UpdateEffectsCoroutine()
	{
		while (true)
		{
			for (int num = tickableEffects.Count - 1; num >= 0; num--)
			{
				tickableEffects[num].Tick(Time.deltaTime);
				if (tickableEffects[num].IsEffectExpired())
				{
					GameplayEffect obj = tickableEffects[num];
					tickableEffects.RemoveAt(num);
					this.onEffectRemoved?.Invoke(obj);
				}
			}
			yield return null;
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!hasLoadedSomething)
		{
			return;
		}
		if (data.ContainsKey("activeEffects"))
		{
			foreach (Dictionary<string, object> item in data["activeEffects"] as List<Dictionary<string, object>>)
			{
				GameplayEffectData gameplayEffectDataById = LTAssetsReferences.instance.GetGameplayEffectDataById((item["effectData"] as Dictionary<string, object>)["id"] as string);
				if ((bool)gameplayEffectDataById && gameplayEffectDataById.Savable)
				{
					SaveSystem.LoadObjectData(ApplyEffect(gameplayEffectDataById, (int)item["currentStacks"]), item);
				}
			}
		}
		if (!data.ContainsKey("tickableEffects"))
		{
			return;
		}
		foreach (Dictionary<string, object> item2 in data["tickableEffects"] as List<Dictionary<string, object>>)
		{
			GameplayEffectData gameplayEffectDataById2 = LTAssetsReferences.instance.GetGameplayEffectDataById((item2["effectData"] as Dictionary<string, object>)["id"] as string);
			if ((bool)gameplayEffectDataById2 && gameplayEffectDataById2.Savable)
			{
				SaveSystem.LoadObjectData(ApplyEffect(gameplayEffectDataById2, (int)item2["currentStacks"]), item2);
			}
		}
	}
}
