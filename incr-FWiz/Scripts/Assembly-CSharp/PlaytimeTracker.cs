using UnityEngine;

public class PlaytimeTracker : MonoBehaviour
{
	[SerializeField]
	private float totalPlayTime;

	private float sessionStartTime;

	private bool isTracking;

	public static PlaytimeTracker Instance { get; private set; }

	public void SetInstance()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void CommitTime()
	{
	}

	public float GetTotalPlayTime()
	{
		return 0f;
	}

	public void ResetPlayTime()
	{
	}
}
