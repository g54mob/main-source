namespace Spine
{
	public class PowOut : Pow
	{
		public PowOut(float power)
			: base(0f)
		{
		}

		protected override float Apply(float a)
		{
			return 0f;
		}
	}
}
