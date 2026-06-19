using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct PredictedTilePositions : IComponentData, IQueryTypeParameter
{
	public NativeHashMap<int2, NetworkTick> predictedPositions;
}
