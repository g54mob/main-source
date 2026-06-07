namespace Assets.Scripts.Craft.Wings
{
	public interface IInterpolatedData<T> where T : struct, IInterpolatedData<T>
	{
		float Position { get; }

		T Interpolate(T other, float pos);
	}
}
