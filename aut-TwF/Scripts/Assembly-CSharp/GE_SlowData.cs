using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu(fileName = "GE_slowData_default", menuName = "Tower Factory/GameplayEffect/EnemiesEffects/Slow")]
public class GE_SlowData : GameplayEffectData
{
	[Header("Slow")]
	[SerializeField]
	private int stacksPerSlowStep = 1;

	[SerializeField]
	private float starterSlowPercentage = -0.1f;

	[SerializeField]
	private float slowPercentagePerSlowStep = -0.1f;

	[SerializeField]
	private int stacksRemovedPerTick = 1;

	public int StacksPerSlowStep => stacksPerSlowStep;

	public float SlowPercentagePerSlowStep => slowPercentagePerSlowStep;

	public float StarterSlowPercentage => starterSlowPercentage;

	public int StacksRemovedPerTick => stacksRemovedPerTick;

	public override string DisplayName => LocalizationSettings.StringDatabase.GetLocalizedString("GameplayEffects", "GE_slow_name", null, FallbackBehavior.UseProjectSettings);

	public override string Description => string.Format(new LocalizedString("GameplayEffects", "GE_slow_description").GetLocalizedString(), Mathf.Abs(StarterSlowPercentage) * 100f, Mathf.Abs(SlowPercentagePerSlowStep) * 100f, stacksPerSlowStep, StacksRemovedPerTick);

	private void OnValidate()
	{
		base.HasTickTime = false;
		base.HasDuration = true;
		base.Duration = 1f;
		base.RefreshDurationOnAddStacks = false;
		base.EndDurationPolicy = EEndDurationPolicy.RemoveStacks;
		base.StacksToRemove = StacksRemovedPerTick;
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_Slow();
	}

	protected override bool ShowNameInInspector()
	{
		return false;
	}

	protected override bool ShowDescriptionInInspector()
	{
		return false;
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}

	protected override bool ShowDurationInInspector()
	{
		return false;
	}
}
