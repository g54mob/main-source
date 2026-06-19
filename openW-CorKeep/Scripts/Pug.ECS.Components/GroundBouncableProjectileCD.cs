using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.NetCode;

public struct GroundBouncableProjectileCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public NetworkTick startFallTick;

	[GhostField]
	public bool fallingInWater;

	public BlobAssetReference<BlobCurve> verticalCurve;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool CanExplode(NetworkTick currentTick, uint tickRate)
	{
		if (!startFallTick.IsValid || fallingInWater)
		{
			return true;
		}
		return NetworkTimeUtilities.TimeBetweenTicksInSeconds(startFallTick, currentTick, tickRate) < 0.5f;
	}
}
