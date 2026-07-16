using UnityEngine;

[CreateAssetMenu(fileName = "20EventNotice", menuName = "Radar/20EventNotice")]
public class RadarEventNotice : EnhancementRadar
{
	[SerializeField]
	private int eventNoticeIncrease = 15;

	public override void OnApplied()
	{
		eventNoticeIncrease = (int)(15f * GameManager.Instance.GameSpeedModifier);
		LevelManager.Instance.Config.EventNoticeUnits += eventNoticeIncrease;
	}

	public override void OnRemoved()
	{
		eventNoticeIncrease = (int)(15f * GameManager.Instance.GameSpeedModifier);
		LevelManager.Instance.Config.EventNoticeUnits -= eventNoticeIncrease;
	}
}
