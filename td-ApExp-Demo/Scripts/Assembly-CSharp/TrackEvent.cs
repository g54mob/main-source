using UnityEngine;

public class TrackEvent
{
	protected Color distanceColor;

	protected string coloredDistanceString;

	protected TrackEventIndicator indicator;

	public float ScheduledDistance { get; protected set; }

	public float DistanceRemaining { get; protected set; }

	public virtual void Update()
	{
		DistanceRemaining = ScheduledDistance - Train.Instance.LevelDistance;
		string arg = DistanceHelper.UnitsToMetricString(DistanceRemaining);
		float time = DistanceRemaining / 30f;
		distanceColor = UIManager.Instance.GradientGYR.Evaluate(time);
		coloredDistanceString = $"<color=#{ColorUtility.ToHtmlStringRGB(distanceColor)}>{arg}</color>";
	}

	public virtual void StartEvent()
	{
		_ = GameManager.Instance.minigameInProgress;
	}

	public virtual void EndEvent()
	{
	}

	public bool IsWithinRange()
	{
		if (DistanceRemaining <= (float)(int)((float)LevelManager.Instance.Config.EventNoticeUnits * GameManager.Instance.GameSpeedModifier))
		{
			return DistanceRemaining > 0f;
		}
		return false;
	}
}
