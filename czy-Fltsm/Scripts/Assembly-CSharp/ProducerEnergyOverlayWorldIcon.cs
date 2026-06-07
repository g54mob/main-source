using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProducerEnergyOverlayWorldIcon : OverlayBehaviour
{
	[SerializeField]
	private Producer _producer;

	[SerializeField]
	private TextMeshProUGUI _amountText;

	[SerializeField]
	private Image _backgroundImage;

	[SerializeField]
	private Material _greyMaterial;

	protected override void Awake()
	{
		base.Awake();
		_amountText.text = "-" + _producer.ProductionProperties.EnergyCost.ToString("F0");
	}

	private void Update()
	{
		if (_producer.ProductionRecipe != null && _producer.ProductionRecipe.RecipeStage == QueuedRecipe.Stage.Producing)
		{
			_backgroundImage.material = null;
		}
		else
		{
			_backgroundImage.material = _greyMaterial;
		}
	}
}
