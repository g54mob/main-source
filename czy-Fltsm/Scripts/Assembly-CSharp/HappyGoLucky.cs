using PajamaLlama.Flotsam.Morale;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Happy Go-Lucky")]
public class HappyGoLucky : AchievementBase
{
	[Header("Happy Go-Lucky")]
	[SerializeField]
	private MoraleCategoryId _moraleCategoryId;

	[SerializeField]
	private int _drifterCount;

	protected override AchievementId DefaultId => AchievementId.Challenge_HappyGoLucky;

	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentMoraleUpdate, OnAgentMoraleUpdate);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentMoraleUpdate, OnAgentMoraleUpdate);
	}

	private void OnAgentMoraleUpdate(GameEvent gameEvent)
	{
		int num = 0;
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (agent.Morale.CurrentMoraleCategory.Id == _moraleCategoryId)
			{
				num++;
			}
		}
		if (num >= _drifterCount && UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
