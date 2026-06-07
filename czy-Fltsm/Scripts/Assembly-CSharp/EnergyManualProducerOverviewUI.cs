using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManualProducerOverviewUI : EnergyGridOverviewSlotUI
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private TMP_Text _gainText;

	[SerializeField]
	private Slider _energyPercentageSlider;

	private EnergyManualProducer _producer;

	private static List<EnergyManualProducerOverviewUI> _uiList;

	protected override GameObject SelectionGameObject => _producer.gameObject;

	private void Awake()
	{
		if (_uiList == null)
		{
			_uiList = new List<EnergyManualProducerOverviewUI>();
		}
		_uiList.Add(this);
	}

	private void OnDestroy()
	{
		_uiList.Remove(this);
	}

	public void Initialize(EnergyManualProducer producer)
	{
		_producer = producer;
		_image.sprite = producer.Buildable.Properties.IconSprite;
		_producer.OnStartGenerating.AddListener(UpdateOverview);
		_producer.OnStopGenerating.AddListener(UpdateOverview);
		_producer.OnEnergyFillPercentageUpdated.AddListener(UpdateEnergyFillSlider);
		UpdateEnergyFillSlider();
		UpdateOverview();
		base.gameObject.SetActive(value: true);
	}

	private void OnDisable()
	{
		_producer.OnStartGenerating.RemoveListener(UpdateOverview);
		_producer.OnStopGenerating.RemoveListener(UpdateOverview);
		_producer.OnEnergyFillPercentageUpdated.RemoveListener(UpdateEnergyFillSlider);
	}

	protected override void UpdateOverview()
	{
		if (!(_producer == null))
		{
			float num = (int)_producer.ReturnAgentEnergyGeneration();
			if (_producer.IsGenerating)
			{
				base.EnergyAddition = num;
				_gainText.text = $"+{num:F0}";
				_gainText.color = base.Activecolor;
			}
			else
			{
				base.EnergyAddition = 0f;
				_gainText.text = $"+{_producer.RechargeSpeed:F0}";
				_gainText.color = base.InactiveColor;
			}
		}
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

	public static bool TryReturnAvailableUI(out EnergyManualProducerOverviewUI ui)
	{
		ui = null;
		if (_uiList == null)
		{
			return false;
		}
		foreach (EnergyManualProducerOverviewUI ui2 in _uiList)
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
