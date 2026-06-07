using UnityEngine;

namespace Bolt
{
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Normalize")]
	public sealed class Vector4Normalize : Normalize<Vector4>
	{
		public override Vector4 Operation(Vector4 input)
		{
			return Vector4.Normalize(input);
		}
	}
}
