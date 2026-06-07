using Factory;
using FixMath;

namespace Server
{
	[Serializable(1)]
	public class Clock
	{
		[Serialize(true, null)]
		public int FrameCount { get; private set; }

		public int ModelFrameIndex { get; private set; }

		[Serialize(true, null)]
		public Fix64 Time { get; private set; }

		public void Step(Fix64 deltaTime)
		{
			FrameCount++;
			ModelFrameIndex = 1 - ModelFrameIndex;
			Time += deltaTime;
		}

		public void Rewind()
		{
			FrameCount--;
			ModelFrameIndex = 1 - ModelFrameIndex;
		}
	}
}
