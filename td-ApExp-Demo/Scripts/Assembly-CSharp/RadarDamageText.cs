using UnityEngine;

[CreateAssetMenu(fileName = "14DamageText", menuName = "Radar/14DamageText")]
public class RadarDamageText : EnhancementRadar
{
	public override void OnApplied()
	{
		UIManager.Instance.FloatingHealthChangeDisplay.enabled = true;
	}

	public override void OnRemoved()
	{
		UIManager.Instance.FloatingHealthChangeDisplay.enabled = false;
	}
}
