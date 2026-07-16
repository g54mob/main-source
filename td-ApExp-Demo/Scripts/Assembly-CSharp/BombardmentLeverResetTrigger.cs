using UnityEngine;

public class BombardmentLeverResetTrigger : BombardmentEventTrigger
{
	public int currentSafeLine = 1;

	public int nextSafeLine = 1;

	public bool lastMinigameTrack;

	protected override void OnTrigger()
	{
		base.OnTrigger();
		Debug.Log("ringggg RESET LEVER");
		GameManager.Instance.minigameTurnReady = false;
		Train.Instance.DirectionLever.SetDir(TrainDirections.Straight);
		if (lastMinigameTrack)
		{
			SpecialTrack componentInParent = GetComponentInParent<SpecialTrack>();
			switch (GameManager.Instance.ringMinigame.currentTrackID)
			{
			case 3:
				componentInParent.pathStraight = componentInParent.turnTypes[SpecialTrackTurn.StraightTop];
				break;
			case 2:
				componentInParent.pathStraight = componentInParent.turnTypes[SpecialTrackTurn.StraightMid];
				break;
			case 1:
				componentInParent.pathStraight = componentInParent.turnTypes[SpecialTrackTurn.StraightBot];
				break;
			}
			return;
		}
		if (GameManager.Instance.ringMinigame.lastRingOutcome)
		{
			GameManager.Instance.ringMinigame.currentTrackID = currentSafeLine;
		}
		GameManager.Instance.ringMinigame.lastRingOutcome = false;
		if (nextSafeLine == GameManager.Instance.ringMinigame.currentTrackID)
		{
			GameManager.Instance.ringMinigame.ForceEndEvent();
		}
		else if (GameManager.Instance.ringMinigame.numberOfTurnsMade < 5)
		{
			GameManager.Instance.ringMinigame.StartEvent(startedSuccessfully: true);
		}
		switch (nextSafeLine)
		{
		case 3:
			if ((double)Train.Instance.Wagons[0].transform.position.y > 0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightTop;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.None;
			}
			else if ((double)Train.Instance.Wagons[0].transform.position.y < 0.1 && (double)Train.Instance.Wagons[0].transform.position.y > -0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightMid;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.MtoT;
			}
			else if ((double)Train.Instance.Wagons[0].transform.position.y < -0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightBot;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.BtoT;
			}
			break;
		case 2:
			if ((double)Train.Instance.Wagons[0].transform.position.y > 0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightTop;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.TtoM;
			}
			else if ((double)Train.Instance.Wagons[0].transform.position.y < 0.1 && (double)Train.Instance.Wagons[0].transform.position.y > -0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightMid;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.None;
			}
			else if ((double)Train.Instance.Wagons[0].transform.position.y < -0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightBot;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.BtoM;
			}
			break;
		case 1:
			if ((double)Train.Instance.Wagons[0].transform.position.y > 0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightTop;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.TtoB;
			}
			else if ((double)Train.Instance.Wagons[0].transform.position.y < 0.1 && (double)Train.Instance.Wagons[0].transform.position.y > -0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightMid;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.MtoB;
			}
			else if ((double)Train.Instance.Wagons[0].transform.position.y < -0.1)
			{
				GameManager.Instance.ringMinigame.straightTrack = SpecialTrackTurn.StraightBot;
				GameManager.Instance.ringMinigame.otherTrack = SpecialTrackTurn.None;
			}
			break;
		}
	}
}
