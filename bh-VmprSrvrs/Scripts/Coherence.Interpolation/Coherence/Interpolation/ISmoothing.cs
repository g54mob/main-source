namespace Coherence.Interpolation
{
	public interface ISmoothing<T>
	{
		T CurrentVelocity { get; set; }

		T Smooth(SmoothingSettings settings, T currentValue, T targetValue, double time);
	}
}
