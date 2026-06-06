using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Town Weight Achievement")]
public class TownWeightAchievement : AchievementBase
{
	[Header("Town Weight Achievement")]
	[SerializeField]
	[Tooltip("The minimum required town weigt to unlock this Achievement")]
	private int _requirement;

	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.TownWeightUpdated, OnTownWeightUpdated);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.TownWeightUpdated, OnTownWeightUpdated);
	}

	private void OnTownWeightUpdated(GameEvent gameEvent)
	{
		if (Engine.TownWeight >= (float)_requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
