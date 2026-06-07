using UnityEngine;

namespace Bolt
{
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Per Second")]
	public sealed class ScalarPerSecond : PerSecond<float>
	{
		public override float Operation(float input)
		{
			return input * Time.deltaTime;
		}
	}
}
