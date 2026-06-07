namespace Bolt
{
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Add")]
	public sealed class ScalarAdd : Add<float>
	{
		protected override float defaultB => 1f;

		public override float Operation(float a, float b)
		{
			return a + b;
		}
	}
}
