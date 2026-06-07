using Unity.Collections;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	internal interface ITransform<TSelf, T, T2> where T : struct where T2 : struct
	{
		T AreaScalingFactor { get; }

		TSelf Identity { get; }

		TSelf Inverse();

		T2 Transform(T2 point);

		TSelf CalculatePCATransformation(NativeArray<T2> positions);

		TSelf CalculateLocalTransformation(NativeArray<T2> positions);
	}
}
