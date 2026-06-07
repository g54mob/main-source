using System;
using System.Collections.Generic;

[Serializable]
public class StressDebugSession
{
	public string startTimestamp;

	public int numCars;

	public List<FrameData> frames = new List<FrameData>();
}
