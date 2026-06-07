using UnityEngine;
using UnityEngine.UI;

public class DrifterAttributesPanel : MonoBehaviour
{
	[SerializeField]
	private Slider _levelSlider;

	[SerializeField]
	private DrifterTotalExperienceTooltip _levelTooltip;

	[SerializeField]
	private DrifterAttributeSpendablePointCounter _spendablePointCounter;

	private Agent _agent;

	public void Initialize(Agent agent)
	{
		_agent = agent;
		_levelTooltip.Initialize(agent.Attributes);
		_spendablePointCounter.Initialize(agent.Attributes);
	}

	private void Update()
	{
		_levelSlider.value = _agent.Attributes.ReturnNormalizedExperience();
	}
}
