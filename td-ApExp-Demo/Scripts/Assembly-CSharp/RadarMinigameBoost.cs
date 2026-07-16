using UnityEngine;

[CreateAssetMenu(fileName = "18MinigameBoost", menuName = "Radar/18MinigameBoost")]
public class RadarMinigameBoost : EnhancementRadar
{
	[SerializeField]
	private float minigameBoostPercent;

	public override void OnApplied()
	{
		GlobalFields.Instance.TimingMinigameGainModifier += minigameBoostPercent;
	}

	public override void OnRemoved()
	{
		GlobalFields.Instance.TimingMinigameGainModifier -= minigameBoostPercent;
	}
}
