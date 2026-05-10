using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameplayEffect : ISavable
{
	[Savable("effectData", true, false)]
	private GameplayEffectData effectData;

	private GameplayEffectsComponent owner;

	[Savable("remainingDuration", true, false)]
	protected float remainingDuration;

	[Savable("remainingTickTime", true, false)]
	protected float remainingTickTime;

	private float durationMultiplier = 1f;

	[Savable("currentStacks", true, false)]
	private int currentStacks;

	public int CurrentStacks
	{
		get
		{
			return currentStacks;
		}
		protected set
		{
			int num = currentStacks;
			currentStacks = value;
			if (num != currentStacks)
			{
				this.onStacksChanged?.Invoke(currentStacks, num);
			}
		}
	}

	public GameplayEffectData EffectData
	{
		get
		{
			return effectData;
		}
		protected set
		{
			effectData = value;
		}
	}

	public GameplayEffectsComponent Owner
	{
		get
		{
			return owner;
		}
		protected set
		{
			owner = value;
		}
	}

	public float DurationMultiplier
	{
		get
		{
			return durationMultiplier;
		}
		set
		{
			float num = value / durationMultiplier;
			durationMultiplier = value;
			remainingDuration *= num;
		}
	}

	protected virtual int StacksToRemove => EffectData.StacksToRemove;

	protected virtual float Duration => EffectData.Duration;

	public event Action<int, int> onStacksChanged;

	public void InitEffect(GameplayEffectData data, GameplayEffectsComponent owner)
	{
		EffectData = data;
		Owner = owner;
		remainingDuration = Duration * DurationMultiplier;
		remainingTickTime = data.TickTime;
		CurrentStacks = 0;
		OnInitEffect();
	}

	public void Tick(float tickTime)
	{
		if (EffectData.HasTickTime)
		{
			remainingTickTime -= tickTime;
			if (remainingTickTime <= 0f)
			{
				remainingTickTime = EffectData.TickTime;
				OnTick(tickTime);
			}
		}
		if (EffectData.HasDuration)
		{
			remainingDuration -= tickTime;
			if (remainingDuration <= 0f)
			{
				EndDuration();
			}
		}
	}

	protected void EndDuration()
	{
		OnEndDuration();
		if (EffectData.EndDurationPolicy == GameplayEffectData.EEndDurationPolicy.RemoveEffect)
		{
			RemoveStacks(CurrentStacks, callStacksRemovedEvent: true);
		}
		else if (EffectData.EndDurationPolicy == GameplayEffectData.EEndDurationPolicy.RemoveStacks)
		{
			RemoveStacks(StacksToRemove, callStacksRemovedEvent: true);
			if (CurrentStacks > 0)
			{
				remainingDuration = Duration;
			}
		}
	}

	public bool IsEffectExpired()
	{
		return remainingDuration <= 0f;
	}

	public virtual void AddStacks(int stacks)
	{
		int num = CurrentStacks;
		CurrentStacks += stacks;
		ClampStacks();
		if (EffectData.RefreshDurationOnAddStacks)
		{
			remainingDuration = Duration;
		}
		OnStacksAdded(CurrentStacks - num);
	}

	public void RemoveStacks(bool callStacksRemovedEvent)
	{
		RemoveStacks(CurrentStacks, callStacksRemovedEvent);
	}

	public virtual void RemoveStacks(int stacks, bool callStacksRemovedEvent)
	{
		int num = CurrentStacks;
		CurrentStacks -= stacks;
		ClampStacks();
		if (callStacksRemovedEvent)
		{
			OnStacksRemoved(num - currentStacks);
		}
		if (CurrentStacks <= 0)
		{
			OnEndEffect();
		}
	}

	protected virtual int ClampStacksToRemove(int stacks)
	{
		return stacks;
	}

	private void ClampStacks()
	{
		CurrentStacks = Mathf.Clamp(CurrentStacks, 0, (EffectData.MaxStacks > 0) ? EffectData.MaxStacks : int.MaxValue);
	}

	protected virtual void OnInitEffect()
	{
	}

	protected virtual void OnEndEffect()
	{
	}

	protected virtual void OnTick(float tickTime)
	{
	}

	protected virtual void OnEndDuration()
	{
	}

	protected virtual void OnStacksAdded(int addedStacks)
	{
	}

	protected virtual void OnStacksRemoved(int removedStacks)
	{
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}

	public bool IgnoreSave()
	{
		return !effectData.Savable;
	}
}
