using UnityEngine;

namespace WorldEnvironment
{
	public static class ObjectUpAxisExtensions
	{
		public static Vector3 ToVector(this ObjectUpAxis axis)
		{
			return axis switch
			{
				ObjectUpAxis.Y => Vector3.up, 
				ObjectUpAxis.X => Vector3.right, 
				ObjectUpAxis.Z => Vector3.forward, 
				ObjectUpAxis.NegativeY => -Vector3.up, 
				ObjectUpAxis.NegativeX => -Vector3.right, 
				ObjectUpAxis.NegativeZ => -Vector3.forward, 
				_ => Vector3.up, 
			};
		}
	}
}
