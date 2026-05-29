using Unity.Burst;

namespace Pathfinding.Drawing
{
	public static class SharedDrawingData
	{
		private class BurstTimeKey
		{
		}

		public static readonly SharedStatic<float> BurstTime = SharedStatic<float>.GetOrCreateUnsafe(4u, 4667476456522965744L, -7737948255972676495L);
	}
}
