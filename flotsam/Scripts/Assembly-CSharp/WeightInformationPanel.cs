using TMPro;
using UnityEngine;

public class WeightInformationPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private TextMeshProUGUI _weight;

	[SerializeField]
	private TextMeshProUGUI _weightTierIcon;

	[SerializeField]
	private TextMeshProUGUI _weightTierValue;

	[SerializeField]
	private TextMeshProUGUI _nextTierIcon;

	[SerializeField]
	private TextMeshProUGUI _nextTierThreshold;

	[SerializeField]
	private TextMeshProUGUI _movementCost;

	public BuildablePanelElementId Id => BuildablePanelElementId.WeightInformation;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.Properties.ReturnShowElement(this, finished))
		{
			_weight.text = Community.PlayerCommunity.ReturnWeightOverCapacityString();
			int currentTownWeightTierIndex = GameplaySettings.GetCurrentTownWeightTierIndex();
			_weightTierIcon.text = currentTownWeightTierIndex.ToString();
			_weightTierValue.text = currentTownWeightTierIndex.ToString();
			if (GameplaySettings.TryGetWeightTierData(currentTownWeightTierIndex + 1, out var tierData))
			{
				_nextTierIcon.text = (currentTownWeightTierIndex + 1).ToString();
				_nextTierThreshold.text = tierData.Threshold.ToString("F0");
			}
			else
			{
				_nextTierIcon.text = "-";
				_nextTierThreshold.text = "-";
			}
			_movementCost.text = (GameplaySettings.TryGetWeightTierData(currentTownWeightTierIndex, out var tierData2) ? tierData2.EelsPerUnit.ToString("F0") : "-");
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}
}
