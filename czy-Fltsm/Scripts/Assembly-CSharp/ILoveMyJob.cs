using PajamaLlama.Flotsam.Morale;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/I Love My Job")]
public class ILoveMyJob : AchievementBase
{
	[Header("I Love My Job")]
	[SerializeField]
	[Min(1f)]
	[Tooltip("The minimum required number of WorkingAffinityMoraleEffects that should be simultaneously active")]
	private int _requirement;

	private int _count;

	protected override AchievementId DefaultId => AchievementId.Challenge_ILoveMyJob;

	protected override void Initialize()
	{
		_count = 0;
		GameEventDispatcher.AddListener(GameEventType.MoraleEffectActivated, OnMoraleEffectActivated);
		GameEventDispatcher.AddListener(GameEventType.MoraleEffectDeactivated, OnMoraleEffectDeactivated);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MoraleEffectActivated, OnMoraleEffectActivated);
		GameEventDispatcher.RemoveListener(GameEventType.MoraleEffectDeactivated, OnMoraleEffectDeactivated);
	}

	private void OnMoraleEffectActivated(GameEvent gameEvent)
	{
		if (gameEvent is AchievementEvent achievementEvent && achievementEvent.MoraleEffect is WorkingAffinityMoraleEffect)
		{
			_count++;
			if (_count >= _requirement && UnlockAchievement())
			{
				Uninitialize();
			}
		}
	}

	private void OnMoraleEffectDeactivated(GameEvent gameEvent)
	{
		if (_count != 0 && gameEvent is AchievementEvent achievementEvent && achievementEvent.MoraleEffect is WorkingAffinityMoraleEffect)
		{
			_count--;
		}
	}
}
