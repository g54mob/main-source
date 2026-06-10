using System.Collections.Generic;
using System.Linq;
using NSEipix;

public class PerformanceTestTracker
{
	private readonly List<float> frameTimes = new List<float>(72000);

	public string TestName { get; private set; }

	public IReadOnlyList<float> FrameTimes => frameTimes;

	public void RecordFrameTime(float frameTime)
	{
		if (!(frameTime < 0.0001f))
		{
			frameTimes.Add(frameTime);
		}
	}

	public PerformanceTestStats GetStats()
	{
		frameTimes.Sort();
		return new PerformanceTestStats
		{
			TestName = TestName,
			FrameCount = frameTimes.Count,
			AverageFrameTime = frameTimes.Average(),
			MedianFrameTime = frameTimes.MedianAssumeSorted(),
			MaxFrameTime = frameTimes.Max(),
			MinFrameTime = frameTimes.Min(),
			UpperQuartileAverageFrameTime = frameTimes.UpperQuartileAverageAssumeSorted()
		};
	}

	public void Reset(string testName)
	{
		TestName = testName;
		frameTimes.Clear();
	}

	public void Clear()
	{
		frameTimes.Clear();
	}
}
