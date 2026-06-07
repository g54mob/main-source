using System.Text.RegularExpressions;
using UnityEngine;

public class EnergyOverlayManualProducerTooltip : Tooltip
{
	[SerializeField]
	private EnergyManualProducer _energyProducer;

	public override string ParsedText()
	{
		string input = Regex.Replace(((string)LocalizedText == null) ? LocalizedText.mTerm : LocalizedText.ToString(), "%ENERGY_BASE%", string.Format("<b>{0}</b>", _energyProducer.RechargeSpeed, RegexOptions.IgnoreCase));
		float num = _energyProducer.ReturnAgentEnergyModifier();
		string arg = ((!(num <= 0f)) ? ("+" + num.ToString("F0")) : num.ToString("F0"));
		return Regex.Replace(input, "%ENERGY_MODIFIER%", string.Format("<b>{0}</b>", arg, RegexOptions.IgnoreCase));
	}
}
