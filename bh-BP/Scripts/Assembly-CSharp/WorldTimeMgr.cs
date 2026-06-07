using UnityEngine;

public class WorldTimeMgr : MonoBehaviour
{
	public static WorldTimeMgr I;

	private float _timeProgress;

	public DelegateUtl.NoArgsEvent OnSecondPassed;

	private void Awake()
	{
	}

	private float GetTimeThreshold()
	{
		return 0f;
	}

	private void Update()
	{
	}

	public void AddWorldSeconds(int amt, bool isIdle, float idleScale = 0f)
	{
	}
}
