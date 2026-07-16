using UnityEngine;

[CreateAssetMenu(fileName = "33MinigameSlowTime", menuName = "Radar/33MinigameSlowTime")]
public class RadarMinigameSlowTime : EnhancementRadar
{
	[SerializeField]
	private float minigameTimescale = 0.5f;

	public override void OnApplied()
	{
		GameManager.Instance.MinigameTimescale = minigameTimescale;
	}

	public override void OnRemoved()
	{
		GameManager.Instance.MinigameTimescale = 1f;
	}
}
