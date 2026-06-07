using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class SpriteEx
	{
		public static List<Vector3> GetWorldVerts(this Sprite sprite, Transform spriteTransform)
		{
			List<Vector3> list = new List<Vector3>(sprite.GetModelVerts());
			spriteTransform.TransformPoints(list);
			return list;
		}

		public static List<Vector3> GetModelVerts(this Sprite sprite)
		{
			List<Vector3> list = new List<Vector3>(7);
			Vector2[] vertices = sprite.vertices;
			foreach (Vector2 vector in vertices)
			{
				list.Add(vector);
			}
			return list;
		}
	}
}
