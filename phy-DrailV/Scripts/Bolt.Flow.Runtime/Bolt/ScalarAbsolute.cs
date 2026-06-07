using UnityEngine;

namespace Bolt
{
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Absolute")]
	public sealed class ScalarAbsolute : Absolute<float>
	{
		protected override float Operation(float input)
		{
			return Mathf.Abs(input);
		}
	}
}
