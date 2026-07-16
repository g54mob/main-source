using System;

public class TrackEventSwitch : TrackEvent
{
	public TrainDirections trackSwitchDir;

	public static bool IsTurnSignalActivated;

	public static bool IsTurnNorth;

	public static bool IsTurnSouth;

	private bool showedDirectionUI;

	private bool hiddenDirectionUI;

	public static event Action<bool> OnTurnSignalActivated;

	public TrackEventSwitch(float schedule, TrainDirections dir)
	{
		base.ScheduledDistance = schedule;
		trackSwitchDir = dir;
	}

	public override void Update()
	{
		base.Update();
		if (Train.Instance.moveDirection != TrainDirections.Straight || !IsWithinRange() || TrackManager.Instance.DestroyNextObstacle)
		{
			if (!hiddenDirectionUI)
			{
				hiddenDirectionUI = true;
				showedDirectionUI = false;
				ShowUIDirection(showUI: false);
			}
			return;
		}
		if (!showedDirectionUI)
		{
			showedDirectionUI = true;
			hiddenDirectionUI = false;
			ShowUIDirection(showUI: true);
		}
		int radarLevel = UIManager.Instance.radarLevel;
		if (!indicator)
		{
			return;
		}
		if (radarLevel == 0)
		{
			indicator.SetColor(UIManager.Instance.ColorGreen);
			indicator.DistancePanelTf.gameObject.SetActive(value: false);
			return;
		}
		if (radarLevel >= 1)
		{
			indicator.SetColor(distanceColor);
		}
		if (radarLevel == 2)
		{
			indicator.DistancePanelTf.gameObject.SetActive(value: true);
			indicator.DistanceText.text = coloredDistanceString;
		}
	}

	public override void StartEvent()
	{
		base.StartEvent();
		if (trackSwitchDir == TrainDirections.Left)
		{
			indicator = UIManager.Instance.IndicatorUp;
		}
		else
		{
			indicator = UIManager.Instance.IndicatorDown;
		}
		if (Train.Instance.moveDirection != trackSwitchDir)
		{
			Train.Instance.moveDirection = TrainDirections.Straight;
		}
		if (ProbUtils.CheckWithReverseLuck(TrackManager.Instance.ChanceForFakeTurns) && ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z4_Snow")
		{
			TrackManager.Instance.isNextTurnFake.Enqueue(item: true);
			indicator.SkullIcon.gameObject.SetActive(value: true);
		}
		else
		{
			TrackManager.Instance.isNextTurnFake.Enqueue(item: false);
			indicator.SkullIcon.gameObject.SetActive(value: false);
		}
	}

	public override void EndEvent()
	{
		indicator?.StopWarning();
		Train.Instance.DirectionLever.ResetDirStraight();
	}

	private void ShowUIDirection(bool showUI)
	{
		if (showUI)
		{
			if ((bool)indicator)
			{
				indicator.StartWarning();
			}
			bool flag = (IsTurnNorth = trackSwitchDir == TrainDirections.Left);
			IsTurnSouth = !flag;
			TrackEventSwitch.OnTurnSignalActivated?.Invoke(flag);
			IsTurnSignalActivated = true;
		}
		else
		{
			indicator?.StopWarning();
		}
	}
}
