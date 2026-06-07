using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Buildable Built")]
public class BuildableAchievement : AchievementBase
{
	[Header("Buildable Achievement")]
	[SerializeField]
	private BuildableProperties _buildableProperties;

	[SerializeField]
	[Min(1f)]
	private int _requirement = 1;

	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, OnBuildableBuilt);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, OnBuildableBuilt);
	}

	private void OnBuildableBuilt(GameEvent gameEvent)
	{
		if (!(gameEvent is BuildableEvent buildableEvent) || !(buildableEvent.BuildableProperties == _buildableProperties))
		{
			return;
		}
		if (_requirement == 1 && UnlockAchievement())
		{
			Uninitialize();
		}
		int num = 0;
		foreach (Buildable buildable in Community.PlayerCommunity.Buildables)
		{
			if (buildable.Properties == _buildableProperties)
			{
				num++;
			}
		}
		if (num >= _requirement && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
