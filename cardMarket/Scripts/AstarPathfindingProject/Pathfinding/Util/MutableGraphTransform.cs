using UnityEngine;

namespace Pathfinding.Util
{
	public class MutableGraphTransform : GraphTransform
	{
		public MutableGraphTransform(Matrix4x4 matrix)
			: base(matrix)
		{
		}

		public void SetMatrix(Matrix4x4 matrix)
		{
			Set(matrix);
		}
	}
}
