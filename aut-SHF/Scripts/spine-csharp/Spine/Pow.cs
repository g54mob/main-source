namespace Spine
{
	public class Pow : IInterpolation
	{
		public float Power { get; set; }

		public Pow(float power)
		{
		}

		protected override float Apply(float a)
		{
			return 0f;
		}
	}
}
