using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Jack of all trades")]
public class JackOfAllTrades : AchievementBase
{
	[Header("Jack Of All Trades")]
	[SerializeField]
	private DrifterAttributes.AttributeType[] _attributeTypes;

	[SerializeField]
	[Tooltip("The required attribute level to trigger the achievement.")]
	private int _requirement;

	protected override void Initialize()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentAttributeLeveled, OnAttributeLeveled);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentAttributeLeveled, OnAttributeLeveled);
	}

	private void OnAttributeLeveled(GameEvent gameEvent)
	{
		if (!(gameEvent is AttributeEvent attributeEvent) || attributeEvent.Agent.Attributes.ReturnExpertise(attributeEvent.AttributeType) < _requirement)
		{
			return;
		}
		DrifterAttributes.AttributeType[] attributeTypes = _attributeTypes;
		foreach (DrifterAttributes.AttributeType type in attributeTypes)
		{
			if (attributeEvent.Agent.Attributes.ReturnExpertise(type) < _requirement)
			{
				return;
			}
		}
		if (UnlockAchievement())
		{
			Uninitialize();
		}
	}
}
