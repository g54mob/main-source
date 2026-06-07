using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyItemProducerOverviewUI : EnergyGridOverviewSlotUI
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TMP_Text _gainText;

	[SerializeField]
	private Slider _energyPercentageSlider;

	private EnergyItemProducer _producer;

	private static List<EnergyItemProducerOverviewUI> _uiList;

	protected override GameObject SelectionGameObject => _producer.gameObject;

	private void Awake()
	{
		if (_uiList == null)
		{
			_uiList = new List<EnergyItemProducerOverviewUI>();
		}
		_uiList.Add(this);
	}

	private void OnDestroy()
	{
		_uiList.Remove(this);
	}

	public void Initialize(EnergyItemProducer producer)
	{
		_producer = producer;
		_image.sprite = producer.Buildable.Properties.IconSprite;
		_producer.OnStartEnergyItemProducing.AddListener(OnStartProducing);
		_producer.OnStopEnergyItemProducing.AddListener(OnStopProducing);
		_producer.OnEnergyFillPercentageUpdated.AddListener(UpdateEnergyFillSlider);
		UpdateEnergyFillSlider();
		_gainText.text = $"+{_producer.PowerRate:F0}";
		if (_producer.IsGenerating)
		{
			OnStartProducing();
		}
		else
		{
			OnStopProducing();
		}
		base.gameObject.SetActive(value: true);
	}

	private void OnDisable()
	{
		_producer.OnStartEnergyItemProducing.RemoveListener(OnStartProducing);
		_producer.OnStopEnergyItemProducing.RemoveListener(OnStopProducing);
		_producer.OnEnergyFillPercentageUpdated.RemoveListener(UpdateEnergyFillSlider);
	}

	private void UpdateEnergyFillSlider()
	{
		if (!(_producer == null))
		{
			_energyPercentageSlider.SetValueWithoutNotify(_producer.EnergyFillPercentage);
		}
	}

	public void SetEnergyFillPercentage(float percentage)
	{
		if (!(_producer == null))
		{
			_producer.SetEnergyFillPercentage(Mathf.Round(percentage * 100f) / 100f);
		}
	}

	private void OnStartProducing()
	{
		if (!(_producer == null))
		{
			float powerRate = _producer.PowerRate;
			base.EnergyAddition = powerRate;
			_gainText.color = base.Activecolor;
		}
	}

	private void OnStopProducing()
	{
		if (!(_producer == null))
		{
			_ = _producer.PowerRate;
			base.EnergyAddition = 0f;
			_gainText.color = base.InactiveColor;
		}
	}

	protected override void UpdateOverview()
	{
	}

	public static bool TryReturnAvailableUI(out EnergyItemProducerOverviewUI ui)
	{
		ui = null;
		if (_uiList == null)
		{
			return false;
		}
		foreach (EnergyItemProducerOverviewUI ui2 in _uiList)
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
