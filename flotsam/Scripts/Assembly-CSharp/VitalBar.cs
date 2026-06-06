using UnityEngine;

public class VitalBar : AgentReferenceUIElement
{
	[SerializeField]
	private VitalType _type = VitalType.None;

	[SerializeField]
	private ImageSegmentBar _segmentBar;

	private int _max;

	protected override void Subscribe(Agent agent)
	{
		agent.Vitals.ReturnVitalEvent(_type).AddListener(UpdateBar);
		UpdateBar();
	}

	protected override void UpdateAgent(Agent agent)
	{
		_max = agent.Vitals.ReturnVitalLimit(_type);
		base.UpdateAgent(agent);
	}

	protected override void Unsubscribe(Agent agent)
	{
		agent.Vitals.ReturnVitalEvent(_type).RemoveListener(UpdateBar);
	}

	private void UpdateBar()
	{
		int amount = ((!(_agent == null)) ? _agent.Vitals.ReturnVitalAmount(_type) : 0);
		SetAmount(amount, _max);
	}

	public void SetAmount(int amount, int max)
	{
		_segmentBar.SetValue(max - amount, max);
	}
}
