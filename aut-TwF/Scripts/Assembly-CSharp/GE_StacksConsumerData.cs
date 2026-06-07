using UnityEngine;

public abstract class GE_StacksConsumerData : GameplayEffectData
{
	[Header("Stacks consumer")]
	[SerializeField]
	private GameplayEffectData gameplayEffectToConsume;

	[SerializeField]
	private bool autoConsumeStacks = true;

	[SerializeField]
	[Tooltip("<= 0 consume todas las cargas que tiene el objetivo")]
	private int maxStacksToConsume;

	public GameplayEffectData GameplayEffectToConsume => gameplayEffectToConsume;

	public bool AutoConsumeStacks => autoConsumeStacks;

	public int MaxStacksToConsume
	{
		get
		{
			return maxStacksToConsume;
		}
		set
		{
			maxStacksToConsume = value;
		}
	}

	public override GameplayEffect InstantiateEffect()
	{
		return null;
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}
}
