using System;
using M4.Session;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class PlayerStatistics : IStatistic
{
	private IUser player;

	private UnityAction onInitializedCallback;

	[SerializeField]
	private AchievementStatistics achievementStatistics;

	public AchievementStatistics Achievements => achievementStatistics;

	public bool IsInitialized { get; private set; }

	public PlayerStatistics()
	{
		IsInitialized = false;
	}

	public void Initialize(IUser player, UnityAction initialize_callback)
	{
		this.player = player;
		if (achievementStatistics == null)
		{
			achievementStatistics = new AchievementStatistics();
		}
		achievementStatistics.Initialize(player, null);
		initialize_callback();
	}
}
