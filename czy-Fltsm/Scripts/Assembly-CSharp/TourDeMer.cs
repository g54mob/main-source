using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Biker Boys")]
public class TourDeMer : AchievementBase
{
	[Header("Tour de Mer")]
	[SerializeField]
	[Tooltip("The required amount of energy that should be generated to unlock the achievement.")]
	private float _requirement = 150f;

	private List<EnergyManualProducer> _activeProducers;

	protected override AchievementId DefaultId => AchievementId.Challenge_TourDeMer;

	protected override void Initialize()
	{
		_activeProducers = new List<EnergyManualProducer>();
		GameEventDispatcher.AddListener(GameEventType.ManualPowerGenerationStarted, OnManualPowerGenerationStarted);
		GameEventDispatcher.AddListener(GameEventType.ManualPowerGenerationStopped, OnManualPowerGenerationStopped);
	}

	public override void Uninitialize()
	{
		_activeProducers?.Clear();
		GameEventDispatcher.RemoveListener(GameEventType.ManualPowerGenerationStarted, OnManualPowerGenerationStarted);
		GameEventDispatcher.RemoveListener(GameEventType.ManualPowerGenerationStopped, OnManualPowerGenerationStopped);
	}

	private void OnManualPowerGenerationStarted(GameEvent gameEvent)
	{
		if (!(gameEvent is AchievementEvent achievementEvent) || !achievementEvent.EnergyManualProducer || !_activeProducers.AddUnique(achievementEvent.EnergyManualProducer))
		{
			return;
		}
		float num = 0f;
		foreach (EnergyManualProducer activeProducer in _activeProducers)
		{
			num += activeProducer.ReturnAgentEnergyGeneration();
		}
		if (num >= _requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}

	private void OnManualPowerGenerationStopped(GameEvent gameEvent)
	{
		if (gameEvent is AchievementEvent achievementEvent)
		{
			_activeProducers.Remove(achievementEvent.EnergyManualProducer);
		}
	}
}
