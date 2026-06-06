using UnityEngine;

namespace Pathfinding.Util
{
	public class MutableGraphTransform : GraphTransform
	{
		public MutableGraphTransform(Matrix4x4 matrix)
			: base(default(Matrix4x4))
		{
		}

		public void SetMatrix(Matrix4x4 matrix)
		{
		}
	}
}
