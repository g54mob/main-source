using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Effect", menuName = "Status Effects/Create New Status Effect")]
public class StatusEffect : ScriptableObject
{
	protected Unit unit;

	[SerializeField]
	private bool hasDuration;

	[SerializeField]
	private float duration;

	private float timer;

	[SerializeField]
	public int maxStacks;

	private int stacks = 1;

	[SerializeField]
	private bool applicationResetsDuration;

	[SerializeField]
	[HideInInspector]
	private string guid;

	[SerializeField]
	public string Guid => guid;

	public int Stacks
	{
		get
		{
			return stacks;
		}
		private set
		{
			stacks = Mathf.Clamp(value, 0, (maxStacks == -1) ? 9999 : maxStacks);
		}
	}

	public event Delegates.StatusEffectHandler Applied;

	public event Delegates.StatusEffectHandler Expired;

	public virtual void Apply(Unit unit)
	{
		OnApplied();
		this.unit = unit;
	}

	public virtual void Expire()
	{
		OnExpired();
		this.Applied = null;
		this.Expired = null;
		UnityEngine.Object.Destroy(this);
	}

	public void OnDestroy()
	{
		Expire();
	}

	public void AddStacks(int stacksToAdd)
	{
		if (applicationResetsDuration)
		{
			timer = duration;
		}
		if (maxStacks == -1)
		{
			Stacks += stacksToAdd;
			return;
		}
		int b = maxStacks - Stacks;
		int num = Mathf.Min(stacksToAdd, b);
		Stacks += num;
	}

	public void SetStacks(int newStacks)
	{
		Stacks = newStacks;
	}

	public virtual void Update()
	{
		if (hasDuration)
		{
			timer -= Time.deltaTime;
			if (!(timer > 0f))
			{
				Expire();
			}
		}
	}

	public void SetDuration(float newDuration, bool refreshTimer = true)
	{
		if (newDuration == -1f)
		{
			hasDuration = false;
			return;
		}
		hasDuration = true;
		duration = newDuration;
		if (refreshTimer)
		{
			timer = duration;
		}
	}

	private void OnValidate()
	{
		if (string.IsNullOrEmpty(Guid))
		{
			guid = System.Guid.NewGuid().ToString();
		}
	}

	private void OnApplied()
	{
		this.Applied?.Invoke(unit, this);
	}

	private void OnExpired()
	{
		this.Expired?.Invoke(unit, this);
	}
}
