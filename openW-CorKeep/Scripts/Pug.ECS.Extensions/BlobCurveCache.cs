using Unity.Mathematics;

public struct BlobCurveCache
{
	public static readonly BlobCurveCache Empty = new BlobCurveCache
	{
		Index = int.MinValue,
		NeighborhoodTimes = float.NaN
	};

	public float2 NeighborhoodTimes;

	public int Index;
}
