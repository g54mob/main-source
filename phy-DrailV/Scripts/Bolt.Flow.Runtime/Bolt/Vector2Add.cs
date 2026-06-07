using UnityEngine;

namespace Bolt
{
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Add")]
	public sealed class Vector2Add : Add<Vector2>
	{
		protected override Vector2 defaultB => Vector2.zero;

		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return a + b;
		}
	}
}
