using PajamaLlama.Generic;
using PajamaLlama.Math;
using TMPro;
using UnityEngine;

public class EnergyGridEfficiencyUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _efficiency;

	[SerializeField]
	private RangedFloat _efficiencyNeedleLimits = new RangedFloat(-90f, 90f);

	[SerializeField]
	private RectTransform _efficiencyNeedle;

	public void CalculateEfficiency(EnergyGrid grid)
	{
		_efficiency.text = $"{grid.GridEfficiency:0%}";
		_efficiencyNeedle.rotation = Quaternion.Euler(_efficiencyNeedle.rotation.eulerAngles.SetZ(_efficiencyNeedleLimits.Evaluate(grid.GridEfficiency)));
	}
}
