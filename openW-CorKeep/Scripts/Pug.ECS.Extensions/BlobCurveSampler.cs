using Unity.Entities;

public struct BlobCurveSampler : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<BlobCurve> Curve;

	internal BlobCurveCache Cache;

	public BlobCurveSampler(BlobAssetReference<BlobCurve> curve)
	{
		Curve = curve;
		Cache = BlobCurveCache.Empty;
	}
}
