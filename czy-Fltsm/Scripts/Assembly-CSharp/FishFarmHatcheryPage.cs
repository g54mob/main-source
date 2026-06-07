using TMPro;
using UnityEngine;

public class FishFarmHatcheryPage : MonoBehaviour
{
	[SerializeField]
	private ItemCounterSlot _fishCountSlot;

	[SerializeField]
	private TextMeshProUGUI _dailyConsumptionField;

	[SerializeField]
	private ChildBehaviourCache<FishFarmHatcherySlot> _slotCache;

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
		if (!(_aquaFarm == null))
		{
			int num = _aquaFarm.ReturnBroodstockCount(_fishProperties);
			int num2 = Mathf.CeilToInt((float)num * _fishProperties.FeedConsumptionPerDay);
			_fishCountSlot.Initialize(_fishProperties.HatcheryIcon, _fishProperties.SlotBackgroundColor, num);
			_dailyConsumptionField.text = $"{Mathf.CeilToInt(num2)} g";
			_slotCache.Reset();
			for (int i = 0; i < _aquaFarm.Broodstock.Capacity; i++)
			{
				_slotCache.Get(active: true).Initialize((i < _aquaFarm.Broodstock.Count) ? _aquaFarm.Broodstock[i] : null, _fishProperties);
			}
			_slotCache.Trim();
		}
	}

	public void AddBroodFish()
	{
		if ((bool)_aquaFarm)
		{
			_aquaFarm.AddBroodFish();
		}
	}

	public void RemoveBroodFish()
	{
		if ((bool)_aquaFarm)
		{
			_aquaFarm.RemoveBroodFish();
		}
	}
}
