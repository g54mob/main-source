using TMPro;
using UnityEngine;

public class FishFarmNurseryPage : MonoBehaviour
{
	[SerializeField]
	private ItemCounterSlot _fishCountSlot;

	[SerializeField]
	private TextMeshProUGUI _dailyConsumptionField;

	[SerializeField]
	private TextMeshProUGUI _emptyLabel;

	[SerializeField]
	private ChildBehaviourCache<FishFarmNurserySlot> _slotCache;

	private AquaFarm _aquaFarm;

	private FishProperties _fishProperties;

	private void OnEnable()
	{
		OnUpdated();
	}

	public void Initialize(AquaFarm aquaFarm, FishProperties fishProperties)
	{
		if ((bool)_aquaFarm)
		{
			_aquaFarm.UpdatedEvent.RemoveListener(OnUpdated);
		}
		_aquaFarm = aquaFarm;
		_aquaFarm.UpdatedEvent.AddListener(OnUpdated);
		_fishProperties = fishProperties;
		OnUpdated();
	}

	private void OnUpdated()
	{
		if (_aquaFarm == null)
		{
			return;
		}
		int count = _aquaFarm.ReturnFishCount(_fishProperties);
		int num = Mathf.CeilToInt((float)_aquaFarm.ReturnConsumingFishCount(_fishProperties) * _fishProperties.FeedConsumptionPerDay);
		_fishCountSlot.Initialize(_fishProperties.NurseryIcon, _fishProperties.SlotBackgroundColor, count);
		_dailyConsumptionField.text = $"{Mathf.CeilToInt(num)} g";
		_slotCache.Reset();
		foreach (AquaFarm.Fish fish in _aquaFarm.Fishes)
		{
			if (fish.FishProperties == _fishProperties)
			{
				_slotCache.Get(active: true).Initialize(fish);
			}
		}
		_slotCache.Trim();
		_emptyLabel.gameObject.SetActive(_slotCache.Count == 0);
	}
}
