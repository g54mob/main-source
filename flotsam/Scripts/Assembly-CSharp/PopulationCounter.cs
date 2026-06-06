using TMPro;
using UnityEngine;

public class PopulationCounter : SceneBehaviour
{
	[Header("Components")]
	public TextMeshProUGUI PopulationText;

	public TextMeshProUGUI HousesText;

	private int _agentsInCommunity;

	private int _houseCapacity;

	private void Start()
	{
		Community.PlayerCommunity.HouseUpdateEvent += UpdateCounter;
		Community.PlayerCommunity.AgentsUpdatedEvent += UpdateCounter;
		UpdateCounter();
	}

	private void OnDestroy()
	{
		Community.PlayerCommunity.HouseUpdateEvent -= UpdateCounter;
		Community.PlayerCommunity.AgentsUpdatedEvent -= UpdateCounter;
	}

	public void UpdateCounter()
	{
		_houseCapacity = Community.PlayerCommunity.ReturnMaximumAgentCapacity();
		_agentsInCommunity = Community.PlayerCommunity.Agents.Count;
		PopulationText.text = _agentsInCommunity.ToString();
		HousesText.text = _houseCapacity.ToString();
	}
}
