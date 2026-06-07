using TMPro;
using UnityEngine;

public class BoatCounter : SceneBehaviour
{
	[Header("Components")]
	public TextMeshProUGUI MooringPointText;

	public TextMeshProUGUI BoatsText;

	private bool _initialized;

	private void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		if (!_initialized)
		{
			Community.PlayerCommunity.MooringPointsUpdatedEvent += UpdateCounter;
			Community.PlayerCommunity.BoatsUpdatedEvent += UpdateCounter;
			UpdateCounter();
			_initialized = true;
		}
	}

	private void OnDestroy()
	{
		if (Community.PlayerCommunity != null)
		{
			Community.PlayerCommunity.MooringPointsUpdatedEvent -= UpdateCounter;
			Community.PlayerCommunity.BoatsUpdatedEvent -= UpdateCounter;
		}
	}

	public void UpdateCounter()
	{
		MooringPointText.text = Community.PlayerCommunity.ReturnAllMooringPoints().Count.ToString();
		BoatsText.text = Community.PlayerCommunity.ReturnAllBoats(returnOnlyFinished: false).Count.ToString();
	}
}
