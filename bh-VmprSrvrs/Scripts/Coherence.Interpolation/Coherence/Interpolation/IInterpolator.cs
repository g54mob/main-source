namespace Coherence.Interpolation
{
	internal interface IInterpolator<T>
	{
		T Interpolate(T value0, T value1, T value2, T value3, float t);
	}
}
