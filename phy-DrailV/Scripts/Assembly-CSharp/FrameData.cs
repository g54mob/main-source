using System;
using System.Collections.Generic;

[Serializable]
public class FrameData
{
	public int fixedUpdateFrame;

	public float fixedDeltaTime;

	public List<TrainStressFrameData> trainStressData = new List<TrainStressFrameData>();
}
