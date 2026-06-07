namespace Spine
{
	public abstract class IInterpolation
	{
		public static IInterpolation Pow2;

		public static IInterpolation Pow2Out;

		protected abstract float Apply(float a);

		public float Apply(float start, float end, float a)
		{
			return 0f;
		}
	}
}
