using JetBrains.Annotations;
using Unity.Burst;
using Unity.Mathematics;

namespace DV.OriginShift
{
	public class OriginShiftBurst
	{
		[UsedImplicitly]
		private class CurrentMoveKey
		{
		}

		public static readonly SharedStatic<float3> CurrentMove = SharedStatic<float3>.GetOrCreate<OriginShiftBurst, CurrentMoveKey>();
	}
}
