using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProducerOverviewUI : EnergyGridOverviewSlotUI
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TMP_Text _costText;

	private Producer _producer;

	private static List<ProducerOverviewUI> _uiList;

	protected override GameObject SelectionGameObject => _producer.gameObject;

	private void Awake()
	{
		if (_uiList == null)
		{
			_uiList = new List<ProducerOverviewUI>();
		}
		_uiList.Add(this);
	}

	private void OnDestroy()
	{
		_uiList.Remove(this);
	}

	public void Initialize(Producer producer)
	{
		_producer = producer;
		_image.sprite = producer.Buildable.Properties.IconSprite;
		_producer.OnStartProducing.AddListener(OnProductionUpdated);
		_producer.OnStopProducing.AddListener(OnProductionUpdated);
		_costText.text = $"-{_producer.ProductionProperties.EnergyCost:F0}";
		UpdateOverview();
		base.gameObject.SetActive(value: true);
	}

	private void OnDisable()
	{
		_producer.OnStartProducing.RemoveListener(OnProductionUpdated);
		_producer.OnStopProducing.RemoveListener(OnProductionUpdated);
	}

	protected override void UpdateOverview()
	{
		if (!(_producer == null))
		{
			float energyCost = _producer.ProductionProperties.EnergyCost;
			if (_producer.IsProducingItems)
			{
				base.EnergyAddition = energyCost;
				_costText.color = base.Activecolor;
			}
			else
			{
				base.EnergyAddition = 0f;
				_costText.color = base.InactiveColor;
			}
		}
	}

	private void OnProductionUpdated(Buildable buildable)
	{
		UpdateOverview();
	}

	public static bool TryReturnAvailableUI(out ProducerOverviewUI ui)
	{
		ui = null;
		if (_uiList == null)
		{
			return false;
		}
		foreach (ProducerOverviewUI ui2 in _uiList)
		{
			if (!ui2.gameObject.activeSelf)
			{
				ui = ui2;
				return true;
			}
		}
		return false;
	}
}
