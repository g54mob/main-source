using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManualEnergyProducerEnergyOverlayWorldIcon : OverlayBehaviour
{
	[SerializeField]
	private EnergyManualProducer _producer;

	[SerializeField]
	private TextMeshProUGUI _amountText;

	[SerializeField]
	private Image _backgroundImage;

	[SerializeField]
	private Material _greyMaterial;

	[SerializeField]
	private Image _efficiencyImage;

	[SerializeField]
	private Sprite _goodEfficiencySprite;

	[SerializeField]
	private Sprite _badEfficiencySprite;

	private void Update()
	{
		UpdateAmount();
		if (_producer.IsGenerating)
		{
			_backgroundImage.material = null;
		}
		else
		{
			_backgroundImage.material = _greyMaterial;
		}
	}

	private void UpdateAmount()
	{
		_amountText.text = "+" + _producer.ReturnAgentEnergyGeneration().ToString("F0");
		int num = ReturnAgentAttributePoints(_producer.GeneratingAgent);
		if (num == 0)
		{
			if (_efficiencyImage.gameObject.activeSelf)
			{
				_efficiencyImage.gameObject.SetActive(value: false);
			}
			return;
		}
		if (!_efficiencyImage.gameObject.activeSelf)
		{
			_efficiencyImage.gameObject.SetActive(value: true);
		}
		_efficiencyImage.sprite = ((num < 0) ? _badEfficiencySprite : _goodEfficiencySprite);
	}

	private int ReturnAgentAttributePoints(Agent agent)
	{
		if (agent == null)
		{
			return 0;
		}
		return agent.Attributes.ReturnTotalAttributePoints(_producer.GenerationAttribute);
	}
}
