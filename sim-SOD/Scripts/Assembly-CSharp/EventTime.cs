using System.Runtime.CompilerServices;
using UnityEngine;

public class EventTime
{
	public enum RecallAccuracy
	{
		veryLow = 0,
		low = 1,
		med = 2,
		high = 3,
		veryHigh = 4
	}

	public delegate void OnCalledUponTimeUpdate();

	public TimelineEvent parentMemory;

	public bool forcedAccuracy;

	public int forcedAccuracyToMinutes;

	public bool forcedRange;

	public Vector2 forcedTimeRange;

	public float timeStart;

	public float timeEnd;

	public float timeMidPoint;

	public Vector2 timeRange;

	public string accurateString;

	public string startString;

	public string endString;

	public float roundedTo;

	public RecallAccuracy recallAccuracy;

	public event OnCalledUponTimeUpdate OnCalledUponTimeUpdated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public EventTime(TimelineEvent newParent, bool forceAccuracy = false, int forceAccuracyToMinutes = 0, bool forceRange = false, float forcedFrom = 0f, float forcedTo = 0f)
	{
	}

	public void CalculateTimings()
	{
	}
}
