using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Diseases/AcidGass")]
public class AcidGass : Disease
{
	[SerializeField]
	private AcidGassMoraleEfect _effect;

	[SerializeField]
	private float _effectRadius;

	private int _effectIndex;

	public override void StartDisease(Agent agent)
	{
		base.StartDisease(agent);
		_effectIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(_effect);
	}

	protected override void AddEffectsToTooltip(TooltipBuilder builder)
	{
		builder.AppendEffect(GetEffectDescription());
	}

	public override string GetEffectDescription()
	{
		return Regex.Replace(EffectDescription, "%MORALE_EFFECT%", _effect.ReturnDescription(), RegexOptions.IgnoreCase);
	}
}
