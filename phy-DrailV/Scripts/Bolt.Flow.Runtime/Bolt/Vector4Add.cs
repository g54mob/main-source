using UnityEngine;

namespace Bolt
{
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Add")]
	public sealed class Vector4Add : Add<Vector4>
	{
		protected override Vector4 defaultB => Vector4.zero;

		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return a + b;
		}
	}
}
