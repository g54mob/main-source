using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishFarmPanel : MonoBehaviour, IBuildablePanelElement
{
	[Header("Header")]
	[SerializeField]
	private TextMeshProUGUI _nameField;

	[SerializeField]
	private Image _icon;

	[Header("Daily Consumption")]
	[SerializeField]
	private InventoryPanelItemSlot _dailyConsumptionItemSlot;

	[SerializeField]
	private TextMeshProUGUI _availableFeedField;

	[SerializeField]
	private TextMeshProUGUI _dailyConsumptionField;

	[Header("Pages")]
	[SerializeField]
	private FishFarmHatcheryPage _hatcheryPage;

	[SerializeField]
	private FishFarmNurseryPage _nurseryPage;

	[SerializeField]
	private FishFarmInfoPage _infoPage;

	private AquaFarm _aquaFarm;

	private FishProperties _fishProperties;

	private ItemToDistribute _itemToDistribute;

	private int _availableFeed;

	public BuildablePanelElementId Id => BuildablePanelElementId.FishFarm;

	private void OnEnable()
	{
		SetActiveFishProperties(_fishProperties);
	}

	private void LateUpdate()
	{
		if (_itemToDistribute != null)
		{
			int num = Mathf.CeilToInt(_itemToDistribute.Available);
			if (_availableFeed != num)
			{
				_availableFeed = num;
				_availableFeedField.text = _availableFeed.ToString();
			}
		}
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<AquaFarm>(out _aquaFarm))
		{
			_aquaFarm.UpdatedEvent.AddListener(UpdateValues);
			if (base.gameObject.activeInHierarchy)
			{
				SetActiveFishProperties(_fishProperties);
			}
			else
			{
				base.gameObject.SetActive(value: true);
			}
			return true;
		}
		return false;
	}

	public void SetActiveFishProperties(FishProperties fishProperties)
	{
		if (!(_aquaFarm == null) && !(fishProperties == null))
		{
			_fishProperties = fishProperties;
			_aquaFarm.SetActiveFishProperties(fishProperties);
			_hatcheryPage.Initialize(_aquaFarm, fishProperties);
			_nurseryPage.Initialize(_aquaFarm, fishProperties);
			_infoPage.Initialize(_aquaFarm, fishProperties);
			UpdateValues();
		}
	}

	public void Deactivate()
	{
		if ((bool)_aquaFarm)
		{
			_aquaFarm.UpdatedEvent.RemoveListener(UpdateValues);
			_aquaFarm = null;
		}
		base.gameObject.SetActive(value: false);
	}

	private void UpdateValues()
	{
		if (!_aquaFarm.ItemDistributer.TryReturnItemToDistribute(_fishProperties.FeedItemProperties, out _itemToDistribute))
		{
			_itemToDistribute = null;
		}
		_nameField.text = _fishProperties.BroodItemProperties.LocalizedName;
		_icon.sprite = _fishProperties.HeaderIcon;
		int num = Mathf.CeilToInt((float)_aquaFarm.ReturnBroodstockCount(_fishProperties) * _fishProperties.FeedConsumptionPerDay);
		int num2 = Mathf.CeilToInt((float)_aquaFarm.ReturnConsumingFishCount(_fishProperties) * _fishProperties.FeedConsumptionPerDay);
		int num3 = num + num2;
		int itemCount = Mathf.CeilToInt((float)num3 / (float)_aquaFarm.ItemDistributer.UnitsPerItem);
		_dailyConsumptionItemSlot.Initialize(_fishProperties.FeedItemProperties, itemCount);
		_dailyConsumptionField.text = num3.ToString();
		_availableFeed = ((_itemToDistribute != null) ? Mathf.CeilToInt(_itemToDistribute.Available) : 0);
		_availableFeedField.text = _availableFeed.ToString();
	}
}
