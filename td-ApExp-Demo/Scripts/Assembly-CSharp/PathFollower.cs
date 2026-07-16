using PathCreation;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
	public PathCreator currentPath;

	public PathFollower parentPf;

	public float globalDistance;

	private float parentPfOffset;

	private Track currentTrack;

	private float lastShakeDistance;

	private float nextShakeStep = 0.1f;

	private float yShakeOffset;

	private void Start()
	{
		ResetDistance();
	}

	private void Update()
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		if (!parentPf)
		{
			float num = Train.Instance.SpeedCurrent * Time.deltaTime;
			globalDistance += num;
			Train.Instance.OnDistanceTraveled(num);
		}
		else
		{
			globalDistance = parentPf.globalDistance - parentPfOffset;
		}
		Track trackAtDistance = TrackManager.Instance.GetTrackAtDistance(globalDistance);
		if (trackAtDistance == null)
		{
			return;
		}
		if (trackAtDistance != currentTrack)
		{
			NewTrack(trackAtDistance);
			currentTrack = trackAtDistance;
		}
		if (currentPath != null)
		{
			float dst = globalDistance % 4.8f;
			base.transform.position = new Vector3(base.transform.position.x, currentPath.path.GetPointAtDistance(dst).y);
			base.transform.rotation = currentPath.path.GetRotationAtDistance(dst);
			if (Mathf.Abs(globalDistance - lastShakeDistance) > nextShakeStep)
			{
				lastShakeDistance = globalDistance;
				nextShakeStep = Random.Range(2f, 10f);
				yShakeOffset = Random.Range(-0.01f, 0.01f);
			}
			base.transform.position += new Vector3(0f, yShakeOffset, 0f);
		}
	}

	private void NewTrack(Track newTrack)
	{
		if (GameManager.Instance.minigameInProgress && newTrack is SpecialTrack specialTrack)
		{
			if (specialTrack.turnTypes.ContainsKey(GameManager.Instance.ringMinigame.straightTrack))
			{
				specialTrack.pathStraight = specialTrack.turnTypes[GameManager.Instance.ringMinigame.straightTrack];
			}
			if (GameManager.Instance.ringMinigame.otherTrack != SpecialTrackTurn.None && specialTrack.turnTypes.ContainsKey(GameManager.Instance.ringMinigame.otherTrack))
			{
				specialTrack.pathOther = specialTrack.turnTypes[GameManager.Instance.ringMinigame.otherTrack];
			}
		}
		PathCreator pathCreator = null;
		if (currentPath != null)
		{
			pathCreator = ((!(currentPath == currentTrack.pathOther)) ? currentTrack.pathOther : currentTrack.pathStraight);
		}
		if (pathCreator != null)
		{
			if (currentPath == currentTrack.pathStraight)
			{
				currentPath = newTrack.pathStraight;
			}
			else
			{
				currentPath = newTrack.pathOther;
			}
		}
		else if (parentPf != null)
		{
			currentPath = parentPf.currentPath;
		}
		else if (Train.Instance.moveDirection == LevelManager.Instance.CurrentSwitchEvent?.trackSwitchDir || GameManager.Instance.minigameTurnReady)
		{
			currentPath = newTrack.pathOther;
		}
		else
		{
			currentPath = newTrack.pathStraight;
		}
	}

	public void ResetDistance()
	{
		parentPfOffset = 0f - base.transform.localPosition.x;
	}

	public bool IsTurning()
	{
		if ((bool)currentPath && (bool)currentTrack && (bool)currentTrack.pathOther)
		{
			if (currentPath == currentTrack.pathOther)
			{
				return true;
			}
			return false;
		}
		return false;
	}
}
