using TMPro;
using UnityEngine;

public class TechTreePanelRequirement : Icon
{
	[SerializeField]
	private TextMeshProUGUI _amountField;

	public void Initialize(TechTreeRequirement requirement)
	{
		Initialize(requirement, false);
		if (requirement.TryGetAmount(out var amount))
		{
			_amountField.enabled = true;
			_amountField.text = amount.ToString();
		}
		else
		{
			_amountField.enabled = false;
		}
		base.gameObject.SetActive(value: true);
	}
}
