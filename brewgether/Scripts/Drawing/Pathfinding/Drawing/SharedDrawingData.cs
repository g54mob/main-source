using Unity.Burst;

namespace Pathfinding.Drawing
{
	public static class SharedDrawingData
	{
		private class BurstTimeKey
		{
		}

		public static readonly SharedStatic<float> BurstTime;
	}
}
