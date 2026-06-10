using UnityEngine;

namespace Aura2API
{
	public static class Texture3DExtensions
	{
		private static Vector3 _tmpVector3;

		public static Vector3 GetSize(this Texture3D texture)
		{
			_tmpVector3.x = texture.width;
			_tmpVector3.y = texture.height;
			_tmpVector3.z = texture.depth;
			return _tmpVector3;
		}
	}
}
