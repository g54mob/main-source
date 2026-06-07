using UnityEngine;

public class WalkwayTrapdoor : MonoBehaviour
{
	public enum CasterUsage
	{
		None = 0,
		ForWalkway = 1,
		ForPushers = 2,
		ForAll = 3
	}

	public string walkwayId;

	public CasterUsage casterUsage;

	[WalkwayBuilt]
	public Walkway walkway;

	[WalkwayBuilt]
	public WalkwayFloor floor = new WalkwayFloor();

	public bool shouldCastForWalkway
	{
		get
		{
			return casterUsage == CasterUsage.ForWalkway || casterUsage == CasterUsage.ForAll;
		}
	}

	public bool shouldCastForPushers
	{
		get
		{
			return casterUsage == CasterUsage.ForPushers || casterUsage == CasterUsage.ForAll;
		}
	}

	private void OnEnable()
	{
	}
}
